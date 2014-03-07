using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace OPMedia.Core
{
    /// <summary>
    /// Provides a mechanism to check if you're on the main thread, and the ability to invoke onto it.
    /// </summary>
    public class MainThread
    {
        private static MainThread _instance;

        private readonly Control _control;
        private readonly SynchronizationContext _context;
        private readonly Form _mainForm;
        private readonly Thread _mainThread;

        public static Form ModalForm
        {
            get
            {
                if (Application.OpenForms != null)
                {
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.Modal)
                            return form;
                    }
                }

                return null;
            }
        }

        public static bool AreModalFormsOpen
        {
            get
            {
                return (ModalForm != null);
            }
        }
      
        private MainThread(Form mainForm)
        {
            _context = WindowsFormsSynchronizationContext.Current;
            _mainThread = Thread.CurrentThread;

            _mainForm = mainForm;
            _control = new Control();
            
            // force handle creation
            IntPtr handle = _control.Handle;
        }

        public static void Initialize(Form mainForm)
        {
            if (_instance == null)
            {
                _instance = new MainThread(mainForm);
            }
        }

        public static bool IsOnMainThread
        {
            get
            {
                try
                {
                    if (_instance != null && _instance._control != null)
                    {
                        // OPMedia Winforms app
                        return !_instance._control.InvokeRequired;
                    }
                }
                catch { }

                // Non-Winforms app
                return true;
            }
        }

        public static Form MainWindow
        {
            get 
            { 
                if (_instance != null)
                    return _instance._mainForm;

                return null;
            }
        }

        public static Thread Thread
        {
            get 
            {
                if (_instance != null)
                    return _instance._mainThread;

                return null;
            }
        }
        /*
        /// <summary>
        /// Checks to see if you're on the main thread.
        /// </summary>
        public static bool InvokeRequired
        {
            get 
            {
                if (_instance != null && _instance._control != null)
                    return _instance._control.InvokeRequired;

                return false;
            }
        }

        /// <summary>
        /// Allows you to invoke onto the main thread.
        /// </summary>
        /// <param name="d">The delegate.</param>
        public static void Invoke(Delegate d)
        {
            _instance._control.Invoke(d);
        }
        
        public static void VerifyOnMainThread()
        {
            if (!IsOnMainThread)
            {
                throw new SystemException("Call required to be on main thread.");
            }
        }
        */

        /// <summary>
        /// Send a message to the main thread
        /// </summary>
        /// <param name="callback">The code to run.</param>
        /// <param name="state">Object to send to the callback.</param>
        private static void SendOrPost(SendOrPostCallback callback, bool send, object state = null)
        {
            if (IsOnMainThread)
            {
                callback(state);
            }
            else if (_instance != null)
            {
                if (send)
                {
                    _instance._context.Send(callback, state);
                }
                else
                {
                    _instance._context.Post(callback, state);
                }
            }
        }

        public static void Post(SendOrPostCallback callback, object state = null)
        {
            SendOrPost(callback, false, state);
        }

        public static void Send(SendOrPostCallback callback, object state = null)
        {
            SendOrPost(callback, true, state);
        }
    }
}
