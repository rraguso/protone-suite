using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Core;
using System.Runtime.InteropServices;
using OPMedia.Core.ComTypes;
using System.Windows.Forms;
using System.Drawing;
using OPMedia.Core.Configuration;

namespace OPMedia.UI.Controls
{
    public class TaskbarThumbnailManager
    {
        private static TaskbarThumbnailManager _instance = new TaskbarThumbnailManager();

        public static TaskbarThumbnailManager Instance { get { return _instance; } }

        public bool IsAvailable { get { return _taskbarList != null; } }

        private ITaskbarList4 _taskbarList = null;

        private readonly Guid TaskbarListClass = new Guid("56FDF344-FD6D-11d0-958A-006097C9A090");

        private List<ThumbButton> _buttons = new List<ThumbButton>();

        public void AddThumbnailButton(string name, Bitmap image, int buttonId)
        {
            if (_taskbarList != null && _buttons.Count < 7)
            {
                ThumbButton btn = new ThumbButton();
                btn.Flags = ThumbButtonOptions.Enabled | ThumbButtonOptions.DismissOnClick;
                btn.Icon = image.GetHicon();
                btn.Id = (uint)buttonId;
                btn.Mask = ThumbButtonMask.Icon | ThumbButtonMask.Tooltip | ThumbButtonMask.THB_FLAGS;
                btn.Tip = name;

                _buttons.Add(btn);
            }
        }

        bool _addedOnce = false;

        public void UpdateProgress(ulong completed, ulong total)
        {
            if (_taskbarList != null)
            {
                MainThread.Post(delegate(object x)
                {
                    _taskbarList.SetProgressValue(MainThread.MainWindow.Handle, completed, total);
                });
            }
        }

        public void SetProgressStatus(TaskbarProgressBarStatus status)
        {
            if (_taskbarList != null)
            {
                MainThread.Post(delegate(object x)
                {
                    _taskbarList.SetProgressState(MainThread.MainWindow.Handle, status);
                });
            }
        }

        public void SubmitThumbnailButtons(bool add)
        {
            int hr = -1;

            if (MainThread.MainWindow.IsDisposed ||
                MainThread.MainWindow.Disposing)
                return;

            if (_taskbarList != null && _buttons.Count > 0)
            {
                if (add || !_addedOnce)
                {
                    hr = _taskbarList.ThumbBarAddButtons(MainThread.MainWindow.Handle,
                        (uint)Math.Min(_buttons.Count, 7), _buttons.ToArray());

                    _addedOnce = true;
                }
                else
                {
                    hr = _taskbarList.ThumbBarUpdateButtons(MainThread.MainWindow.Handle,
                        (uint)Math.Min(_buttons.Count, 7), _buttons.ToArray());
                }
            }

            _buttons.Clear();
        }

        private TaskbarThumbnailManager()
        {
            try
            {
                if (AppConfig.OSVersion >= AppConfig.VerWin7)
                {

                    _taskbarList = Activator.CreateInstance(Type.GetTypeFromCLSID(TaskbarListClass))
                        as ITaskbarList4;

                    _taskbarList.HrInit();
                }
            }
            catch
            {
                _taskbarList = null;
                return;
            }
        }

    }
}
