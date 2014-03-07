using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Threading;
using OPMedia.Core.TranslationSupport;
using System.Windows.Forms;
using OPMedia.Core.Logging;
using OPMedia.UI.Controls;
using OPMedia.Core.ComTypes;

namespace OPMedia.UI
{
    public delegate void TaskStepInitHandler(StepDetail currentStep);
    public delegate void TaskProgressHandler(StepDetail currentStep, int stepsDone);
    public delegate void TaskCancelledHandler();
    public delegate void TaskFinishedHandler();

    public abstract class BackgroundTask
    {
        public event TaskStepInitHandler TaskStepInit = null;
        public event TaskProgressHandler TaskProgress = null;
        public event TaskCancelledHandler TaskCancelled = null;
        public event TaskFinishedHandler TaskFinished = null;

        public abstract int CurrentStep { get; }
        public abstract int TotalSteps { get; }
        public abstract bool IsFinished { get; }
        public abstract StepDetail RunNextStep();
        public abstract void Reset();

        private ManualResetEvent _pauseEvent = new ManualResetEvent(false);

        public void PauseExecution()
        {
            TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.Paused);
            Logger.LogInfo("Task execution paused");
            _pauseEvent.Set();
        }

        public void ResumeExecution()
        {
            TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.Normal);
            Logger.LogInfo("Task execution resumed");
            _pauseEvent.Reset();
        }

        public bool IsExecutionPaused(int timeout)
        {
            return _pauseEvent.WaitOne(timeout);
        }

        public void RaiseTaskStepInitEvent(StepDetail currentStepDetail)
        {
            if (TaskStepInit != null)
            {
                TaskStepInit(currentStepDetail);
            }
        }
        
        public void RaiseTaskProgressEvent(StepDetail currentStepDetail, int stepsDone)
        {
            TaskbarThumbnailManager.Instance.UpdateProgress((ulong)stepsDone, (ulong)TotalSteps);

            if (TaskProgress != null)
            {
                TaskProgress(currentStepDetail, stepsDone);
            }
        }

        public void RaiseTaskCancelledEvent()
        {
            TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.NoProgress);

            if (TaskCancelled != null)
            {
                TaskCancelled();
            }
        }

        public void RaiseTaskFinishedEvent()
        {
            TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.NoProgress);

            if (TaskFinished != null)
            {
                TaskFinished();
            }
        }

        internal void StartRequested()
        {
            OnTaskStarted();
        }

        internal void CancelRequested()
        {
            OnTaskCancelled();
        }

        internal void FinishRequested()
        {
            OnTaskFinished();
        }

        protected virtual void OnTaskStarted() { }
        protected virtual void OnTaskCancelled() { }
        protected virtual void OnTaskFinished() { }
    }

    public class StepDetail
    {
        public bool IsSuccess;
        public string Description;
        public string Results;
    }

    public class TaskRunner
    {
        private BackgroundTask _task = null;
        private BackgroundWorker _worker = null;

        private ManualResetEvent _endEvent = new ManualResetEvent(false);

        public TaskRunner(BackgroundTask task)
            : base()
        {
            _task = task;

            _worker = new BackgroundWorker();
            _worker.WorkerSupportsCancellation = true;
            
            _worker.DoWork += new DoWorkEventHandler(_worker_DoWork);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_worker_RunWorkerCompleted);
        }

        void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    Logger.LogInfo("Task cancelled at step {0} of {1}", _task.CurrentStep, _task.TotalSteps);
                    _task.RaiseTaskCancelledEvent();
                    return;
                }

                Logger.LogInfo("Task finished");
                _task.RaiseTaskFinishedEvent();
            }
            finally
            {
                _endEvent.Set();
            }
        }

        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _task.StartRequested();

            while (!_task.IsFinished)
            {
                if (_worker.CancellationPending)
                {
                    Logger.LogInfo("The task has been canceled. Background processing aborted.");
                    e.Cancel = true;
                    TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.NoProgress);
                    return;
                }

                if (_task.IsExecutionPaused(50))
                {
                    Thread.Sleep(50);
                    continue;
                }

                if (_worker.CancellationPending)
                {
                    Logger.LogInfo("The task has been canceled. Background processing aborted.");
                    e.Cancel = true;
                    TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.NoProgress);
                    return;
                }

                _task.RaiseTaskProgressEvent(_task.RunNextStep(), _task.CurrentStep);
            }

            _task.FinishRequested();
        }

        public void Run()
        {
            if (!_worker.IsBusy)
            {
                _worker.RunWorkerAsync();
            }
        }

        public bool Cancel()
        {
            // Cannot be canceled, once it's finished.
            if (_task.IsFinished)
                return false;

            string message = Translator.Translate("TXT_TASK_CANCEL_MSG");

            if (_worker.IsBusy)
            {
                _task.PauseExecution();

                if (MessageDisplay.Query(message, "TXT_TASK_CANCEL", MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _task.CancelRequested();

                    Logger.LogInfo("Requesting to cancel the task ...");
                    _worker.CancelAsync();

                    Logger.LogInfo("Waiting the task to effectively cancel...");
                    _endEvent.WaitOne(2000);

                    TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.NoProgress);

                    return true;
                }

                _task.ResumeExecution();
            }

            return false;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_worker.IsBusy)
            {
                _worker.CancelAsync();
                _worker.Dispose();
                _worker = null;
            }
        }

        #endregion
    }
}
