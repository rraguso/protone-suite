using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace OPMedia.UI.Controls.ThemedScrollBars
{
    public static class ScrollBarSkinner
    {
        #region Private members

        private static List<SkinScrollCore> _skinCores = new List<SkinScrollCore>();
        private static List<SkinScrollCore> _initializationList = new List<SkinScrollCore>();
        private static System.Windows.Forms.Timer _initializationTimer = null;
        private static object _initializationLock = new object();

        #endregion

        #region Properties

        private static Color _normalColor = Color.Empty;
        public static Color NormalColor
        {
            get
            {
                return _normalColor;
            }
            set
            {
                _normalColor = value;
                UpdateColors();
            }
        }

        private static Color _hoverColor = Color.Empty;
        public static Color HoverColor
        {
            get
            {
                return _hoverColor;
            }
            set
            {
                _hoverColor = value;
                UpdateColors();
            }
        }

        private static Color _pressedColor = Color.Empty;
        public static Color PressedColor
        {
            get
            {
                return _pressedColor;
            }
            set
            {
                _pressedColor = value;
                UpdateColors();
            }
        }

        private static Color _backColor = Color.Empty;
        public static Color BackColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
                UpdateColors();
            }
        }

        private static Color _trackColor = Color.Empty;
        public static Color TrackColor
        {
            get
            {
                return _trackColor;
            }
            set
            {
                _trackColor = value;
                UpdateColors();
            }
        }

        private static Color _trackPressedColor = Color.Empty;
        public static Color TrackPressedColor
        {
            get
            {
                return _trackPressedColor;
            }
            set
            {
                _trackPressedColor = value;
                UpdateColors();
            }
        }

        #endregion

        public static void SkinTopWindow(Control ctl)
        {
            foreach (Control child in ctl.Controls)
                SkinTopWindow(child);

            SkinWindow(ctl);
        }

        public static void SkinWindow(Control ctrl)
        {
            if (SkinScrollCore.IsControlSupported(ctrl))
            {
                int index = _skinCores.Count - 1;
                while (index >= 0)
                {
                    if (_skinCores[index].IsDestroyed)
                        _skinCores.RemoveAt(index);
                    else if (_skinCores[index].OriginalControl == ctrl)
                    {
                        return;//control already skinned
                    }
                    index--;
                }
                AddCore(ctrl);
            }
        }

        private static void AddCore(Control ctrl)
        {
            SkinScrollCore core = new SkinScrollCore();
            if (core.SkinWindow(ctrl))
            {
                _skinCores.Add(core);
                InitializeCore(core);
            }
            else
                core.ControlReady += new EventHandler<EventArgs>(OnControlReady);
        }

        //private static void AddCore(SkinScrollCore core)
        //{
        //    if (core != null &&
        //        core.OriginalControl != null &&
        //        core.SkinWindow(core.OriginalControl))
        //    {
        //        _skinCores.Add(core);
        //        InitializeCore(core);
        //    }
        //    else
        //    {
        //        core.ControlReady += new EventHandler<EventArgs>(OnControlReady);
        //    }
        //}

        private static void OnControlReady(object sender, EventArgs args)
        {
            SkinScrollCore core = (SkinScrollCore)sender;
            core.ControlReady -= new EventHandler<EventArgs>(OnControlReady);
            
            AddCore(core.OriginalControl);
        }

        private static void UpdateColors()
        {
            int index = _skinCores.Count - 1;
            while (index >= 0)
            {
                if (_skinCores[index].IsDestroyed)
                    _skinCores.RemoveAt(index);
                else
                    _skinCores[index].UpdateColors();
                index--;
            }
        }

        private static void InitializeCore(SkinScrollCore core)
        {
            lock (_initializationLock)
            {
                if (_initializationTimer == null)
                {
                    _initializationTimer = new System.Windows.Forms.Timer();
                    _initializationTimer.Interval = 200;
                    _initializationTimer.Tick += new EventHandler(InitializationTick);
                    _initializationTimer.Start();
                }
                _initializationList.Add(core);
            }
        }

        private static void InitializationTick(object sender, EventArgs e)
        {
            lock (_initializationLock)
            {
                for (int index = _initializationList.Count - 1; index >= 0; index--)
                {
                    if (_initializationList[index].UpdateScrollBars())
                    {
                        _initializationList.RemoveAt(index);
                    }
                }
            }
        }
    }

    public class SkinScrollCore
    {
        #region Constants

        private const int SB_HORZ = 0;
        private const int SB_VERT = 1;
        private const int SB_LINEUP = 0;
        private const int SB_LINELEFT = 0;
        private const int SB_LINEDOWN = 1;
        private const int SB_LINERIGHT = 1;
        private const int SB_PAGEUP = 2;
        private const int SB_PAGELEFT = 2;
        private const int SB_PAGEDOWN = 3;
        private const int SB_PAGERIGHT = 3;
        private const int SB_THUMBPOSITION = 4;
        private const int SB_THUMBTRACK = 5;
        private const int SB_TOP = 6;
        private const int SB_LEFT = 6;
        private const int SB_BOTTOM = 7;
        private const int SB_RIGHT = 7;
        private const int SB_ENDSCROLL = 8;
        private const int GWL_WNDPROC = -4;
        private const int GWL_STYLE = -16;
        private const int GWL_EXSTYLE = (-20);
        private const int WM_DESTROY = 0x0002;
        private const int WM_SIZE = 0x5;
        private const int WM_SIZING = 0x0214;
        private const int WM_WINDOWPOSCHANGED = 0x0047;
        private const int WM_NCCALCSIZE = 0x0083;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_VSCROLL = 0x0115;
        private const int WM_HSCROLL = 0x0114;
        private const int WM_CTLCOLORLISTBOX = 0x0134;
        private const int WM_MOUSEWHEEL = 0x020A;
        private const int WM_CTLCOLORSCROLLBAR = 0x0137;
        private const int WS_VSCROLL = 0x00200000;
        private const int WS_HSCROLL = 0x00100000;
        private const int WS_EX_LEFTSCROLLBAR = 0x00004000;
        private const long WS_POPUP = 0x80000000;
        private const long WS_CHILD = 0x40000000;
        private const long WS_VISIBLE = 0x10000000;
        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_ERASEBKGND = 0x0014;
        private const int WM_PAINT = 0x000F;
        private const int WM_SHOWWINDOW = 0x0018;
        private const long WS_EX_TOOLWINDOW = 0x00000080;
        private const long WS_EX_TOPMOST = 0x00000008;
        private const long WS_EX_APPWINDOW = 0x00040000;
        private const long WS_BORDER = 0x00800000L;
        private const int LVM_FIRST = 0x1000;
        private const int LVM_SCROLL = LVM_FIRST + 20;
        private const int TV_FIRST = 0x1100;
        private const int TVM_INSERTITEMA = (TV_FIRST + 0);
        private const int TVM_INSERTITEMW = (TV_FIRST + 50);
        private const int TVM_DELETEITEM = (TV_FIRST + 1);
        private const int TVM_EXPAND = (TV_FIRST + 2);
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;
        private const int VK_LBUTTON = 0x01;
        private const int KEY_PRESSED = 0x8000;
        private const int WHEEL_DELTA = 120;
        private const int LB_ADDSTRING = 0x180;
        private const int LB_INSERTSTRING = 0x181;
        private const int LB_DELETESTRING = 0x182;
        private const int LB_RESETCONTENT = 0x184;
        private IntPtr HWND_TOPMOST = new IntPtr(-1);
        private IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        private IntPtr HWND_TOP = new IntPtr(0);
        private IntPtr HWND_BOTTOM = new IntPtr(1);

        private static string _uniqueID = "14B96716-57D5-4CC3-8BF0-EEC1147EF653";

        #endregion

        #region Structures & Enums

        [StructLayout(LayoutKind.Sequential)]
        struct SCROLLINFO
        {
            public uint cbSize;
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }

        private enum ScrollBarDirection
        {
            SB_HORZ = 0,
            SB_VERT = 1,
            SB_CTL = 2,
            SB_BOTH = 3
        }

        private enum ScrollInfoMask
        {
            SIF_RANGE = 0x1,
            SIF_PAGE = 0x2,
            SIF_POS = 0x4,
            SIF_DISABLENOSCROLL = 0x8,
            SIF_TRACKPOS = 0x10,
            SIF_ALL = SIF_RANGE + SIF_PAGE + SIF_POS + SIF_TRACKPOS
        }

        [StructLayout(LayoutKind.Sequential)]
        struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct NCCALCSIZE_PARAMS
        {
            public RECT rgrc0, rgrc1, rgrc2;
            public IntPtr lppos;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct WINDOWPOS
        {
            public IntPtr hwnd, hwndInsertAfter;
            public int x, y, cx, cy;
            public uint flags;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct COMBOBOXINFO
        {
            public int cbSize;
            public RECT rcItem;
            public RECT rcButton;
            public IntPtr stateButton;
            public IntPtr hwndCombo;
            public IntPtr hwndEdit;
            public IntPtr hwndList;
        }

        public enum SystemMetric : int
        {
            /// <summary>
            /// Width of a vertical scroll bar, in pixels.
            /// </summary>
            SM_CXVSCROLL = 2,
            /// <summary>
            /// Width of a window border, in pixels. This is equivalent to the SM_CXEDGE value for windows with the 3-D look.
            /// </summary>
            SM_CXBORDER = 5,
            /// <summary>
            /// Width of a 3-D border, in pixels. This is the 3-D counterpart of SM_CXBORDER
            /// </summary>
            SM_CXEDGE = 45,
        }

        public enum SetWindowPosFlags
        {
            NOSIZE = 0x0001,
            NOMOVE = 0x0002,
            NOZORDER = 0x0004,
            NOREDRAW = 0x0008,
            NOACTIVATE = 0x0010,
            DRAWFRAME = 0x0020,
            FRAMECHANGED = 0x0020,
            SHOWWINDOW = 0x0040,
            HIDEWINDOW = 0x0080,
            NOCOPYBITS = 0x0100,
            NOOWNERZORDER = 0x0200,
            NOREPOSITION = 0x0200,
            NOSENDCHANGING = 0x0400,
            DEFERERASE = 0x2000,
            ASYNCWINDOWPOS = 0x4000,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator POINT(System.Drawing.Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }

        #endregion

        #region Dll Imports

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr newWndProc);

        [DllImport("user32.dll")]
        static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("user32.dll")]
        static extern int GetSystemMetrics(SystemMetric smIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
        internal static extern void MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int SetScrollPos(IntPtr hWnd, int wBar, int nPos, bool bRedraw);

        [DllImport("user32")]
        private static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref COMBOBOXINFO info);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

        [DllImport("user32.dll")]
        static extern short GetKeyState(int nVirtKey);

        #endregion

        #region Private Members

        delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        private IntPtr _oldWndProcPointer = IntPtr.Zero;
        private IntPtr _newWndProcPointer = IntPtr.Zero;
        private WndProcDelegate _newWndProc = null;

        private ScrollBarEx _vScrollBar = null;
        private ScrollBarEx _hScrollBar = null;

        private IntPtr _targetHandle = IntPtr.Zero;
        private ScrollBar _targetVScrollBar = null;
        private ScrollBar _targetHScrollBar = null;
        private Control _parentControl = null;

        #endregion

        #region Public Properties

        private Control _originalControl = null;
        public Control OriginalControl
        {
            get
            {
                return _originalControl;
            }
        }

        private Control _originalParentControl = null;
        public Control OriginalParentControl
        {
            get
            {
                return _originalParentControl;
            }
        }

        private Control _referenceControl = null;
        public Control ReferenceControl
        {
            get
            {
                return _referenceControl;
            }
        }

        public void UpdateColors()
        {
            if (_vScrollBar != null)
                SetColors(_vScrollBar);
            if (_hScrollBar != null)
                SetColors(_hScrollBar);
        }

        private bool _isDestroyed = false;
        public bool IsDestroyed
        {
            get
            {
                return _isDestroyed;
            }
            set
            {
                _isDestroyed = value;
            }
        }

        #endregion

        #region Public Events

        public EventHandler<EventArgs> ControlReady;

        #endregion

        ~SkinScrollCore()
        {
            UnskinWindow();
        }

        private void SetColors(ScrollBarEx scrollBar)
        {
            if ((scrollBar.NormalColor != ScrollBarSkinner.NormalColor) && (!ScrollBarSkinner.NormalColor.IsEmpty))
                scrollBar.NormalColor = ScrollBarSkinner.NormalColor;
            if ((scrollBar.HoverColor != ScrollBarSkinner.HoverColor) && (!ScrollBarSkinner.HoverColor.IsEmpty))
                scrollBar.HoverColor = ScrollBarSkinner.HoverColor;
            if ((scrollBar.PressedColor != ScrollBarSkinner.PressedColor) && (!ScrollBarSkinner.PressedColor.IsEmpty))
                scrollBar.PressedColor = ScrollBarSkinner.PressedColor;
            if ((scrollBar.BackColor != ScrollBarSkinner.BackColor) && (!ScrollBarSkinner.BackColor.IsEmpty))
                scrollBar.BackColor = ScrollBarSkinner.BackColor;
            if ((scrollBar.TrackColor != ScrollBarSkinner.TrackColor) && (!ScrollBarSkinner.TrackColor.IsEmpty))
                scrollBar.TrackColor = ScrollBarSkinner.TrackColor;
            if ((scrollBar.TrackPressedColor != ScrollBarSkinner.TrackPressedColor) && (!ScrollBarSkinner.TrackPressedColor.IsEmpty))
                scrollBar.TrackPressedColor = ScrollBarSkinner.TrackPressedColor;
        }

        public static bool IsControlSupported(Control ctrl)
        {
            try
            {
                if (
                    (ctrl is ComboBox) ||
                    (ctrl is ListBox) ||
                    (ctrl is DataGridView) ||
                    (ctrl is TreeView) ||
                    (ctrl is RichTextBox && (ctrl as RichTextBox).Multiline) ||
                    (ctrl is TextBox && (ctrl as TextBox).Multiline) ||
                    (ctrl is ListView) ||
                    ((ctrl is ScrollableControl) && ((ScrollableControl)ctrl).AutoScroll == true) ||
                    false)

                    return true;
            }
            catch
            {
            }

            return false;
        }

        public bool SkinWindow(Control ctrl)
        {
            _originalControl = ctrl;
            if ((ctrl != null) && ((string.Compare(ctrl.Name, _uniqueID, false) != 0)))
            {
                if ((!ctrl.IsHandleCreated) || (ctrl.Parent == null))
                {
                    ctrl.HandleCreated += new EventHandler(ControlReadyHandler);
                    ctrl.ParentChanged += new EventHandler(ControlReadyHandler);
                }
                else
                    return InitializeControl(ctrl);
            }
            return false;
        }

        void ControlReadyHandler(object sender, EventArgs e)
        {
            if ((((Control)sender).IsHandleCreated) && (((Control)sender).Parent != null))
            {
                ((Control)sender).HandleCreated -= new EventHandler(ControlReadyHandler);
                ((Control)sender).ParentChanged -= new EventHandler(ControlReadyHandler);
                if (ControlReady != null)
                    ControlReady(this, null);
            }
        }

        public void UnskinWindow()
        {
            try
            {
                _targetHandle = IntPtr.Zero;
                if (_oldWndProcPointer != IntPtr.Zero)
                    SetWindowLong(_targetHandle, GWL_WNDPROC, _oldWndProcPointer);

                if (_referenceControl != null)
                {
                    _referenceControl.HandleCreated -= new EventHandler(ReferenceControlHandleCreated);
                    _referenceControl.HandleDestroyed -= new EventHandler(ReferenceControlHandleDestroyed);
                }

                if (_originalControl != null)
                {
                    if (_originalControl is ScrollableControl)
                    {
                        _originalControl.ControlAdded -= new ControlEventHandler(ContentChanged);
                        _originalControl.ControlRemoved -= new ControlEventHandler(ContentChanged);
                    }

                    _originalControl.ParentChanged -= new EventHandler(OriginalControlParentChanged);

                    if (_originalControl is DataGridView)
                    {
                        ((DataGridView)_originalControl).RowsRemoved -= new DataGridViewRowsRemovedEventHandler(ContentChanged);
                        ((DataGridView)_originalControl).RowsAdded -= new DataGridViewRowsAddedEventHandler(ContentChanged);
                        ((DataGridView)_originalControl).ColumnAdded -= new DataGridViewColumnEventHandler(ContentChanged);
                        ((DataGridView)_originalControl).ColumnRemoved -= new DataGridViewColumnEventHandler(ContentChanged);
                    }
                    
                }
            }
            catch { }
            _isDestroyed = true;
        }

        private bool InitializeControl(Control ctrl)
        {
            if ((ctrl.IsHandleCreated) && (string.Compare(ctrl.Name, _uniqueID, false) != 0))
            {
                _originalControl = ctrl;
                _originalParentControl = ctrl.Parent;

                if (InitializeHandle(_originalControl))
                {
                    if (_originalControl is ScrollableControl)
                    {
                        _originalControl.ControlAdded += new ControlEventHandler(ContentChanged);
                        _originalControl.ControlRemoved += new ControlEventHandler(ContentChanged);
                    }
                    _referenceControl.HandleCreated += new EventHandler(ReferenceControlHandleCreated);
                    _referenceControl.HandleDestroyed += new EventHandler(ReferenceControlHandleDestroyed);
                    
                    _originalControl.ParentChanged += new EventHandler(OriginalControlParentChanged);

                    if (_originalControl is DataGridView)
                    {
                        ((DataGridView)_originalControl).RowsRemoved += new DataGridViewRowsRemovedEventHandler(ContentChanged);
                        ((DataGridView)_originalControl).RowsAdded += new DataGridViewRowsAddedEventHandler(ContentChanged);
                        ((DataGridView)_originalControl).ColumnAdded += new DataGridViewColumnEventHandler(ContentChanged);
                        ((DataGridView)_originalControl).ColumnRemoved += new DataGridViewColumnEventHandler(ContentChanged);
                    }

                    AdjustWindow(true);
                    return true;
                }
            }
            return false;
        }

        private bool InitializeHandle(Control ctrl)
        {
            IntPtr oldTargetHandle = _targetHandle;
            if (ctrl is ComboBox)
            {
                _referenceControl = ctrl;
                COMBOBOXINFO cbInfo = new COMBOBOXINFO();
                cbInfo.cbSize = Marshal.SizeOf(cbInfo);
                GetComboBoxInfo(((Control)ctrl).Handle, ref cbInfo);
                _targetHandle = cbInfo.hwndList;
            }
            else
            {
                _referenceControl = ctrl;
                _targetHandle = ctrl.Handle;
            }

            if ((_targetHandle != oldTargetHandle) && (_targetHandle != IntPtr.Zero))
            {
                if (_oldWndProcPointer == IntPtr.Zero)
                    _oldWndProcPointer = (IntPtr)GetWindowLong(_targetHandle, GWL_WNDPROC);
                else
                {
                    if (oldTargetHandle != IntPtr.Zero)
                        SetWindowLong(_targetHandle, GWL_WNDPROC, _oldWndProcPointer);
                }
                if (_newWndProcPointer == IntPtr.Zero)
                {
                    _newWndProc = new WndProcDelegate(WndProc);
                    _newWndProcPointer = Marshal.GetFunctionPointerForDelegate(_newWndProc);
                }
                SetWindowLong(_targetHandle, GWL_WNDPROC, _newWndProcPointer);
                return true;
            }
            else
                return false;
        }

        private bool UpdateParent()
        {
            if ((_parentControl == null) && (_originalParentControl != null))
            {
                if ((_originalParentControl is TableLayoutPanel) || (_originalParentControl is FlowLayoutPanel))
                {
                    _parentControl = new PanelEx();
                    _parentControl.Name = _uniqueID;

                    //_parentControl.Margin = _originalControl.Margin;
                    //_parentControl.Padding = new Padding(0);

                    _parentControl.Padding = _originalControl.Margin;
                    _parentControl.Margin = new Padding(0);

                    _parentControl.Dock = _originalControl.Dock;
                    _parentControl.Anchor = _originalControl.Anchor;
                    _parentControl.Location = _originalControl.Location;

                    _parentControl.Size = _originalControl.Size;
                    _parentControl.Width += _parentControl.Padding.Horizontal;
                    _parentControl.Height += _parentControl.Padding.Vertical;

                    //_parentControl.BackColor = Color.FromArgb(200, 50, 50);
                    if (_originalParentControl is TableLayoutPanel)
                    {
                        TableLayoutPanel panel = ((TableLayoutPanel)_originalParentControl);
                        panel.SuspendLayout();
                        TableLayoutPanelCellPosition pos = panel.GetCellPosition(_originalControl);
                        int columnSpan = panel.GetColumnSpan(_originalControl);
                        int rowSpan = panel.GetRowSpan(_originalControl);

                        int index = panel.Controls.IndexOf(_originalControl);
                        
                        panel.Controls.RemoveAt(index);

                        panel.Controls.Add(_parentControl);
                        panel.Controls.SetChildIndex(_parentControl, index);
                        panel.SetCellPosition(_parentControl, pos);
                        panel.SetColumnSpan(_parentControl, columnSpan);
                        panel.SetRowSpan(_parentControl, rowSpan);
                        panel.Layout -= new LayoutEventHandler(OriginalParentControlLayoutChanged);
                        panel.Layout += new LayoutEventHandler(OriginalParentControlLayoutChanged);
                        panel.ResumeLayout();
                    }
                    else if (_originalParentControl is FlowLayoutPanel)
                    {
                        FlowLayoutPanel panel = (FlowLayoutPanel)_originalParentControl;
                        panel.SuspendLayout();
                        int index = panel.Controls.IndexOf(_originalControl);
                        panel.Controls.RemoveAt(index);
                        panel.Controls.Add(_parentControl);
                        panel.Controls.SetChildIndex(_parentControl, index);
                        panel.ResumeLayout();
                    }
                    _parentControl.UseWaitCursor = _parentControl.Parent.UseWaitCursor;
                    int selectedIndex = -1;
                    if (_originalControl is ComboBox)
                        selectedIndex = ((ComboBox)_originalControl).SelectedIndex;
                    
                    _parentControl.TabIndex = _originalControl.TabIndex;
                    _originalControl.Parent = _parentControl;

                    if (_originalControl is ComboBox)
                        ((ComboBox)_originalControl).SelectedIndex = selectedIndex;

                    _originalControl.Margin = new Padding(0);
                    _originalControl.Anchor = AnchorStyles.None;
                    _originalControl.Dock = DockStyle.Fill;
                    _originalControl.SizeChanged += new EventHandler(OriginalControlSizeChanged);
                    _originalControl.LocationChanged += new EventHandler(OriginalControlLocationChanged);
                }
                else
                {
                    if (_originalControl is SplitterPanel)
                    {
                        _parentControl = _originalControl.Parent.Parent;//cannot add child controls to SplitContainer
                    }
                    else
                    {
                        _parentControl = _originalControl.Parent;
                    }
                }
            }
            return (_parentControl != null);
        }

        private void OriginalParentControlLayoutChanged(object sender, LayoutEventArgs e)
        {
            if (sender is TableLayoutPanel)
            {
                int columnSpan = ((TableLayoutPanel)(sender)).GetColumnSpan(_originalControl);
                int rowSpan = ((TableLayoutPanel)(sender)).GetRowSpan(_originalControl);
                int column = ((TableLayoutPanel)(sender)).GetColumn(_originalControl);
                int row = ((TableLayoutPanel)(sender)).GetRow(_originalControl);

                if (columnSpan != ((TableLayoutPanel)(sender)).GetColumnSpan(_parentControl))
                {
                    ((TableLayoutPanel)(sender)).SetColumnSpan(_parentControl, columnSpan);
                }
                if (rowSpan != ((TableLayoutPanel)(sender)).GetRowSpan(_parentControl))
                {
                    ((TableLayoutPanel)(sender)).SetRowSpan(_parentControl, rowSpan);
                }
                if (column != ((TableLayoutPanel)(sender)).GetColumn(_parentControl))
                {
                    ((TableLayoutPanel)(sender)).SetColumn(_parentControl, column);
                }
                if (row != ((TableLayoutPanel)(sender)).GetRow(_parentControl))
                {
                    ((TableLayoutPanel)(sender)).SetRow(_parentControl, row);
                }
            }
        }

        private void OriginalControlLocationChanged(object sender, EventArgs e)
        {
            if (_parentControl != null)
                _parentControl.Location = ((Control)sender).Location;
        }

        private void OriginalControlSizeChanged(object sender, EventArgs e)
        {
            if (_parentControl != null)
                _parentControl.Size = ((Control)sender).Size;
        }

        private void OriginalControlParentChanged(object sender, EventArgs e)
        {
            if ((((Control)sender).Parent != null) && (((Control)sender).Parent != _parentControl))
            {
                _vScrollBar = null;
                _hScrollBar = null;
                _originalParentControl = ((Control)sender).Parent;
                _parentControl = null;
                AdjustWindow(true);
            }
        }

        private void ReferenceControlHandleDestroyed(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv != null && lv.RecreatingHandle)
            {
                _oldWndProcPointer = IntPtr.Zero;
                _newWndProcPointer = IntPtr.Zero;
                lv.HandleCreated += new EventHandler(OnListViewHandleRecreated);
            }
            else
            {
                UnskinWindow();
            }
        }

        void OnListViewHandleRecreated(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv != null)
            {
                lv.HandleCreated -= new EventHandler(OnListViewHandleRecreated);
                ReferenceControlHandleCreated(sender, e);
            }
        }

        private void ReferenceControlHandleCreated(object sender, EventArgs e)
        {
            if (InitializeHandle(_originalControl))
            {
                if ((_originalControl.Parent != null) && (_originalControl.Parent != _parentControl))
                {
                    _vScrollBar = null;
                    _hScrollBar = null;
                    _originalParentControl = _originalControl.Parent;
                    _parentControl = null;
                    AdjustWindow(true);
                }
            }
        }

        private void ContentChanged(object sender, EventArgs e)
        {
            AdjustWindow(true);
        }

        private void AdjustWindow()
        {
            AdjustWindow(false);
        }

        private void AdjustWindow(bool updateScroll)
        {
            bool hasFocus = false;
            if (_originalControl != null)
                hasFocus = _originalControl.Focused;
            try
            {
                if (_targetHandle != IntPtr.Zero)
                {
                    if (_referenceControl is ComboBox)
                    {
                        RECT clientRectangle = new RECT();
                        GetClientRect(_targetHandle, out clientRectangle);
                        Point p1 = new Point(clientRectangle.Left, clientRectangle.Top);
                        Point p2 = new Point(clientRectangle.Right, clientRectangle.Bottom);
                        ClientToScreen(_targetHandle, ref p1);
                        ClientToScreen(_targetHandle, ref p2);
                        clientRectangle.Left = p1.X;
                        clientRectangle.Top = p1.Y;
                        clientRectangle.Right = p2.X;
                        clientRectangle.Bottom = p2.Y;

                        int systemScrollWidth = GetSystemMetrics(SystemMetric.SM_CXVSCROLL);
                        int nBorder = GetSystemMetrics(SystemMetric.SM_CXBORDER);
                        int wndStyle = GetWindowLong(_targetHandle, GWL_STYLE);
                        int wndStyleEx = GetWindowLong(_targetHandle, GWL_EXSTYLE);
                        bool leftScroll = ((wndStyleEx & WS_EX_LEFTSCROLLBAR) != 0);
                        bool vScroll = ((wndStyle & WS_VSCROLL) != 0);

                        if (vScroll)
                        {
                            if (_vScrollBar == null)
                            {
                                if (UpdateParent())
                                {
                                    _vScrollBar = new ScrollBarEx();
                                    long targetStyleEx = GetWindowLong(_vScrollBar.Handle, GWL_EXSTYLE);
                                    targetStyleEx |= WS_EX_TOOLWINDOW;
                                    //ShowWindow(_vScrollBar.Handle, SW_HIDE);
                                    SetWindowLong(_vScrollBar.Handle, GWL_EXSTYLE, (IntPtr)targetStyleEx);
                                    //ShowWindow(_vScrollBar.Handle, SW_SHOW);
                                    _vScrollBar.Orientation = ScrollOrientation.VerticalScroll;
                                    SetParent(_vScrollBar.Handle, GetParent(_targetHandle));
                                }
                            }
                        }
                        if (_vScrollBar != null)
                        {
                            if (vScroll && IsWindowVisible(_targetHandle))
                            {
                                _vScrollBar.Visible = true;
                                SetWindowPos(_vScrollBar.Handle, HWND_TOPMOST, clientRectangle.Right, clientRectangle.Top, systemScrollWidth, clientRectangle.Bottom - clientRectangle.Top, SetWindowPosFlags.SHOWWINDOW);
                                SetColors(_vScrollBar);
                            }
                            else
                                _vScrollBar.Visible = false;
                        }
                    }
                    else if (_referenceControl is DataGridView)
                    {
                        foreach (Control c in _referenceControl.Controls)
                        {
                            if (c is VScrollBar)
                                _targetVScrollBar = (ScrollBar)c;
                            else if (c is HScrollBar)
                                _targetHScrollBar = (ScrollBar)c;
                        }
                        if ((_targetVScrollBar != null) && (_targetVScrollBar.Visible))
                        {
                            if (UpdateParent())
                            {
                                if (_vScrollBar == null)
                                {
                                    _vScrollBar = new ScrollBarEx();
                                    _vScrollBar.Orientation = ScrollOrientation.VerticalScroll;
                                    _vScrollBar.Parent = _parentControl;
                                    _vScrollBar.Scroll += new ScrollEventHandler(OnScroll);
                                }
                                Rectangle rect = _targetVScrollBar.Parent.RectangleToScreen(_targetVScrollBar.Bounds);
                                rect = _parentControl.RectangleToClient(rect);
                                _vScrollBar.Location = rect.Location;
                                _vScrollBar.Size = rect.Size;
                            }
                        }
                        if (_vScrollBar != null)
                        {
                            if ((_targetVScrollBar != null) && (_targetVScrollBar.Visible))
                            {
                                _vScrollBar.Visible = true;
                                _vScrollBar.BringToFront();
                                SetColors(_vScrollBar);
                            }
                            else
                                _vScrollBar.Visible = false;
                        }
                        if ((_targetHScrollBar != null) && (_targetHScrollBar.Visible))
                        {
                            if (UpdateParent())
                            {
                                if (_hScrollBar == null)
                                {
                                    _hScrollBar = new ScrollBarEx();
                                    _hScrollBar.Orientation = ScrollOrientation.HorizontalScroll;
                                    _hScrollBar.Parent = _parentControl;
                                    _hScrollBar.Scroll += new ScrollEventHandler(OnScroll);
                                }
                                Rectangle rect = _targetVScrollBar.Parent.RectangleToScreen(_targetHScrollBar.Bounds);
                                rect = _parentControl.RectangleToClient(rect);
                                _hScrollBar.Location = rect.Location;
                                _hScrollBar.Size = rect.Size;
                            }
                        }
                        if (_hScrollBar != null)
                        {
                            if ((_targetHScrollBar != null) && (_targetHScrollBar.Visible))
                            {
                                _hScrollBar.Visible = true;
                                _hScrollBar.BringToFront();
                                SetColors(_hScrollBar);
                            }
                            else
                                _hScrollBar.Visible = false;
                        }
                    }
                    else
                    {
                        int systemScrollWidth = GetSystemMetrics(SystemMetric.SM_CXVSCROLL);
                        int nBorder = GetSystemMetrics(SystemMetric.SM_CXBORDER);
                        int wndStyle = GetWindowLong(_targetHandle, GWL_STYLE);
                        int wndStyleEx = GetWindowLong(_targetHandle, GWL_EXSTYLE);
                        bool leftScroll = ((wndStyleEx & WS_EX_LEFTSCROLLBAR) != 0);
                        bool vScroll = ((wndStyle & WS_VSCROLL) != 0) || (_referenceControl is PropertyGrid);
                        bool hScroll = ((wndStyle & WS_HSCROLL) != 0) || (_referenceControl is PropertyGrid);

                        if (vScroll || hScroll)
                        {
                            if (UpdateParent())
                            {
                                RECT clientRectangle = new RECT();
                                GetClientRect(_targetHandle, out clientRectangle);
                                Point p1 = new Point(clientRectangle.Left, clientRectangle.Top);
                                Point p2 = new Point(clientRectangle.Right, clientRectangle.Bottom);
                                ClientToScreen(_targetHandle, ref p1);
                                ClientToScreen(_targetHandle, ref p2);
                                clientRectangle.Left = p1.X;
                                clientRectangle.Top = p1.Y;
                                clientRectangle.Right = p2.X;
                                clientRectangle.Bottom = p2.Y;

                                RECT fullRectangle = new RECT();
                                GetClientRect(_parentControl.Handle, out fullRectangle);
                                p1 = new Point(fullRectangle.Left, fullRectangle.Top);
                                p2 = new Point(fullRectangle.Right, fullRectangle.Bottom);
                                ClientToScreen(_parentControl.Handle, ref p1);
                                ClientToScreen(_parentControl.Handle, ref p2);
                                fullRectangle.Left = p1.X;
                                fullRectangle.Top = p1.Y;
                                fullRectangle.Right = p2.X;
                                fullRectangle.Bottom = p2.Y;

                                if (vScroll)
                                {
                                    if (_vScrollBar == null)
                                    {
                                        _vScrollBar = new ScrollBarEx();
                                        _vScrollBar.Orientation = ScrollOrientation.VerticalScroll;
                                        _vScrollBar.Parent = _parentControl;
                                        _vScrollBar.Scroll += new ScrollEventHandler(OnScroll);
                                    }
                                    _vScrollBar.Size = new Size(systemScrollWidth, (clientRectangle.Bottom - clientRectangle.Top));
                                    _vScrollBar.Location = new Point(clientRectangle.Left - fullRectangle.Left + (clientRectangle.Right - clientRectangle.Left) - 1 + nBorder, clientRectangle.Top - fullRectangle.Top);
                                }
                                if (hScroll)
                                {
                                    if (_hScrollBar == null)
                                    {
                                        _hScrollBar = new ScrollBarEx();
                                        _hScrollBar.Orientation = ScrollOrientation.HorizontalScroll;
                                        _hScrollBar.Parent = _parentControl;
                                        _hScrollBar.Scroll += new ScrollEventHandler(OnScroll);
                                    }

                                    _hScrollBar.Size = new Size(clientRectangle.Right - clientRectangle.Left, systemScrollWidth);
                                    _hScrollBar.Location = new Point(clientRectangle.Left - fullRectangle.Left, clientRectangle.Top - fullRectangle.Top + (clientRectangle.Bottom - clientRectangle.Top) - 1 + nBorder);
                                }
                                if (leftScroll)
                                {
                                    if (vScroll)
                                    {
                                        _vScrollBar.Location = new Point(clientRectangle.Left - fullRectangle.Left - _vScrollBar.Width, clientRectangle.Top - fullRectangle.Top);
                                        if (_hScrollBar != null)
                                            _hScrollBar.Left = _vScrollBar.Right;
                                    }
                                }
                            }
                        }
                        if (_vScrollBar != null)
                        {
                            if (vScroll && _referenceControl.Visible)
                            {
                                _vScrollBar.Visible = true;
                                _vScrollBar.BringToFront();
                                SetColors(_vScrollBar);
                            }
                            else
                                _vScrollBar.Visible = false;
                        }
                        if (_hScrollBar != null)
                        {
                            if (hScroll && _referenceControl.Visible)
                            {
                                _hScrollBar.Visible = true;
                                _hScrollBar.BringToFront();
                                SetColors(_hScrollBar);
                            }
                            else
                                _hScrollBar.Visible = false;
                        }
                    }
                    if (updateScroll)
                        UpdateScrollBars();
                }
            }
            catch { }
            if (hasFocus)
            {
                if (!_originalControl.Focused)
                    _originalControl.Focus();
            }
        }

        public bool UpdateScrollBars()
        {
            return UpdateScrollBars(-1);
        }

        public bool UpdateScrollBars(int scrollAction)
        {
            bool retValue = false;
            try
            {
                if ((_vScrollBar != null) && (_vScrollBar.Visible))
                {
                    IntPtr scrollHandle = IntPtr.Zero;
                    int oldValue = _vScrollBar.Value;
                    if (_targetVScrollBar != null)
                    {
                        scrollHandle = _targetVScrollBar.Handle;
                        _vScrollBar.Maximum = ((ScrollBar)_targetVScrollBar).Maximum;
                        _vScrollBar.Minimum = ((ScrollBar)_targetVScrollBar).Minimum;
                        _vScrollBar.SmallChange = ((ScrollBar)_targetVScrollBar).SmallChange;
                        _vScrollBar.LargeChange = ((ScrollBar)_targetVScrollBar).LargeChange;
                        _vScrollBar.Value = ((ScrollBar)_targetVScrollBar).Value;
                        _vScrollBar.SetScrollInfo(
                            ((ScrollBar)_targetVScrollBar).SmallChange,
                            ((ScrollBar)_targetVScrollBar).LargeChange,
                            ((ScrollBar)_targetVScrollBar).Minimum,
                            ((ScrollBar)_targetVScrollBar).Maximum,
                            ((ScrollBar)_targetVScrollBar).Value);

                        if ((((ScrollBar)_targetVScrollBar).SmallChange != 0) && (((ScrollBar)_targetVScrollBar).LargeChange != 0))
                            retValue = true;
                    }
                    else
                    {
                        SCROLLINFO si = new SCROLLINFO();
                        si.cbSize = (uint)Marshal.SizeOf(si);
                        si.fMask = (uint)ScrollInfoMask.SIF_ALL;
                        GetScrollInfo(_targetHandle, (int)ScrollBarDirection.SB_VERT, ref si);
                        _vScrollBar.SetScrollInfo(
                            (int)si.nPage,
                            si.nMin,
                            si.nMax,
                            si.nPos);
                        if (si.nPage != 0)
                            retValue = true;
                    }
                    if ((scrollAction == SB_LINEDOWN) && (oldValue > _vScrollBar.Value))
                    {
                        SendMessage(_targetHandle, WM_VSCROLL, (IntPtr)SB_BOTTOM, scrollHandle);
                        SendMessage(_targetHandle, WM_VSCROLL, (IntPtr)SB_ENDSCROLL, scrollHandle);
                    }
                    else if ((scrollAction == SB_LINEUP) && (oldValue < _vScrollBar.Value))
                    {
                        SendMessage(_targetHandle, WM_VSCROLL, (IntPtr)SB_TOP, scrollHandle);
                        SendMessage(_targetHandle, WM_VSCROLL, (IntPtr)SB_ENDSCROLL, scrollHandle);
                    }
                }

                if ((_hScrollBar != null) && (_hScrollBar.Visible))
                {
                    IntPtr scrollHandle = IntPtr.Zero;
                    int oldValue = _hScrollBar.Value;
                    if (_targetHScrollBar != null)
                    {
                        scrollHandle = _targetHScrollBar.Handle;
                        _hScrollBar.Maximum = ((ScrollBar)_targetHScrollBar).Maximum;
                        _hScrollBar.Minimum = ((ScrollBar)_targetHScrollBar).Minimum;
                        _hScrollBar.SmallChange = ((ScrollBar)_targetHScrollBar).SmallChange;
                        _hScrollBar.LargeChange = ((ScrollBar)_targetHScrollBar).LargeChange;
                        _hScrollBar.Value = ((ScrollBar)_targetHScrollBar).Value;
                        _hScrollBar.SetScrollInfo(
                            ((ScrollBar)_targetHScrollBar).SmallChange,
                            ((ScrollBar)_targetHScrollBar).LargeChange,
                            ((ScrollBar)_targetHScrollBar).Minimum,
                            ((ScrollBar)_targetHScrollBar).Maximum,
                            ((ScrollBar)_targetHScrollBar).Value);
                        if ((((ScrollBar)_targetHScrollBar).SmallChange != 0) && (((ScrollBar)_targetHScrollBar).LargeChange != 0))
                            retValue = true;
                    }
                    else
                    {
                        SCROLLINFO si = new SCROLLINFO();
                        si.cbSize = (uint)Marshal.SizeOf(si);
                        si.fMask = (uint)ScrollInfoMask.SIF_ALL;
                        GetScrollInfo(_targetHandle, (int)ScrollBarDirection.SB_HORZ, ref si);
                        _hScrollBar.Maximum = si.nMax;
                        _hScrollBar.Minimum = si.nMin;
                        _hScrollBar.PageSize = (int)si.nPage;
                        _hScrollBar.Value = si.nPos;
                        _hScrollBar.SetScrollInfo(
                            (int)si.nPage,
                            si.nMin,
                            si.nMax,
                            si.nPos);
                        if (si.nPage != 0)
                            retValue = true;
                    }
                    if ((scrollAction == SB_LINELEFT) && (oldValue > _hScrollBar.Value))
                    {
                        SendMessage(_targetHandle, WM_HSCROLL, (IntPtr)SB_LEFT, scrollHandle);
                        SendMessage(_targetHandle, WM_HSCROLL, (IntPtr)SB_ENDSCROLL, scrollHandle);
                    }
                    else if ((scrollAction == SB_LINERIGHT) && (oldValue > _hScrollBar.Value))
                    {
                        SendMessage(_targetHandle, WM_HSCROLL, (IntPtr)SB_RIGHT, scrollHandle);
                        SendMessage(_targetHandle, WM_HSCROLL, (IntPtr)SB_ENDSCROLL, scrollHandle);
                    }
                }
            }
            catch { }
            return retValue;
        }

        public IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            IntPtr result = IntPtr.Zero;
            /*if (msg == WM_DESTROY)
            {
                if (_originalControl == _referenceControl)
                {
                    _originalControl.ControlAdded -= new ControlEventHandler(ContentChanged);
                    _originalControl.ControlRemoved -= new ControlEventHandler(ContentChanged);

                    if (_originalControl is DataGridView)
                    {
                        ((DataGridView)_originalControl).RowsRemoved -= new DataGridViewRowsRemovedEventHandler(ContentChanged);
                        ((DataGridView)_originalControl).RowsAdded -= new DataGridViewRowsAddedEventHandler(ContentChanged);
                        ((DataGridView)_originalControl).ColumnAdded -= new DataGridViewColumnEventHandler(ContentChanged);
                        ((DataGridView)_originalControl).ColumnRemoved -= new DataGridViewColumnEventHandler(ContentChanged);
                    }
                    else if (_originalControl is KryptonDataGridView)
                    {
                        ((KryptonDataGridView)_originalControl).RowsRemoved -= new DataGridViewRowsRemovedEventHandler(ContentChanged);
                        ((KryptonDataGridView)_originalControl).RowsAdded -= new DataGridViewRowsAddedEventHandler(ContentChanged);
                        ((KryptonDataGridView)_originalControl).ColumnAdded -= new DataGridViewColumnEventHandler(ContentChanged);
                        ((KryptonDataGridView)_originalControl).ColumnRemoved -= new DataGridViewColumnEventHandler(ContentChanged);
                    }

                    _originalControl.HandleCreated -= new EventHandler(OriginalControlHandleCreated);
                    _originalControl.ParentChanged -= new EventHandler(OriginalControlParentChanged);
                    _isDestroyed = true;
                }

                _targetHandle = IntPtr.Zero;
                _referenceControl.HandleCreated -= new EventHandler(ReferenceControlHandleCreated);
                _referenceControl.HandleCreated += new EventHandler(ReferenceControlHandleCreated);

                SetWindowLong(_targetHandle, GWL_WNDPROC, _oldWndProc);
                return CallWindowProc(_oldWndProc, hWnd, msg, wParam, lParam);
            }*/

            if (_referenceControl is ComboBox)
            {
                switch (msg)
                {
                    case WM_MOUSEMOVE:
                        {
                            if (_vScrollBar != null)
                            {
                                int x = GET_X_LPARAM(lParam);
                                int y = GET_Y_LPARAM(lParam);
                                Point p = new Point(x, y);
                                ClientToScreen(_targetHandle, ref p);
                                RECT rect = new RECT();
                                GetWindowRect(_vScrollBar.Handle, out rect);
                                if ((p.X >= rect.Left) && (p.Y >= rect.Top) && (p.X < rect.Right) && (p.Y < rect.Bottom))
                                {
                                    POINT clientP = new POINT(p.X, p.Y);
                                    ScreenToClient(_vScrollBar.Handle, ref clientP);
                                    if (_vScrollBar != null)
                                        _vScrollBar.InnerMouseMove(clientP.X, clientP.Y);
                                }
                                else
                                    _vScrollBar.InnerMouseLeave();
                            }
                        }
                        break;
                    case WM_LBUTTONDOWN:
                        {
                            if (_vScrollBar != null)
                            {
                                int x = GET_X_LPARAM(lParam);
                                int y = GET_Y_LPARAM(lParam);
                                Point p = new Point(x, y);
                                ClientToScreen(_targetHandle, ref p);
                                RECT rect = new RECT();
                                GetWindowRect(_vScrollBar.Handle, out rect);
                                if ((p.X >= rect.Left) && (p.Y >= rect.Top) && (p.X < rect.Right) && (p.Y < rect.Bottom))
                                {
                                    POINT clientP = new POINT(p.X, p.Y);
                                    ScreenToClient(_vScrollBar.Handle, ref clientP);
                                    if (_vScrollBar != null)
                                        _vScrollBar.InnerMouseDown(clientP.X, clientP.Y, false);
                                }
                            }
                        }
                        break;
                }
                if (!Convert.ToBoolean(GetKeyState(VK_LBUTTON) & KEY_PRESSED))
                {
                    if (_vScrollBar != null)
                        _vScrollBar.InnerMouseUp();
                }
            }

            
            result = CallWindowProc(_oldWndProcPointer, hWnd, msg, wParam, lParam);
            switch (msg)
            {
                case WM_VSCROLL:
                case WM_HSCROLL:
                    UpdateScrollBars(LOWORD(wParam));
                    break;
                case WM_MOUSEWHEEL:
                case WM_KEYDOWN:
                    UpdateScrollBars();
                    break;
                case WM_WINDOWPOSCHANGED:
                    AdjustWindow(true);
                    break;
                case WM_PAINT:
                case WM_ERASEBKGND:
                    AdjustWindow(true);
                    break;
                case LB_ADDSTRING:
                case LB_INSERTSTRING:
                case LB_DELETESTRING:
                case LB_RESETCONTENT:
                    AdjustWindow(true);
                    break;
                case TVM_INSERTITEMA:
                case TVM_INSERTITEMW:
                case TVM_DELETEITEM:
                case TVM_EXPAND:
                    AdjustWindow(true);
                    break;
                case WM_CTLCOLORSCROLLBAR:
                    AdjustWindow(true);
                    break;
                default:
                    break;
            }

            return result;
        }


        void OnScroll(object sender, ScrollEventArgs e)
        {
            if (_targetHandle != null)
            {
                if (ReferenceControl is ScrollableControl)
                {
                    if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
                    {
                        ((ScrollableControl)_referenceControl).AutoScrollPosition = new Point(-((ScrollableControl)_referenceControl).AutoScrollPosition.X, e.NewValue);
                    }
                    else
                    {
                        ((ScrollableControl)_referenceControl).AutoScrollPosition = new Point(e.NewValue, -((ScrollableControl)_referenceControl).AutoScrollPosition.Y);
                    }
                }
                else
                {
                    if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
                    {
                        IntPtr scrollHandle = IntPtr.Zero;
                        if (_targetVScrollBar != null)
                        {
                            _targetVScrollBar.Value = e.NewValue;
                            scrollHandle = _targetVScrollBar.Handle;
                        }

                        if ((e.Type == ScrollEventType.ThumbPosition) || (e.Type == ScrollEventType.ThumbTrack))
                        {
                            if (_referenceControl is ListView)
                            {
                                SCROLLINFO si = new SCROLLINFO();
                                si.cbSize = (uint)Marshal.SizeOf(si);
                                si.fMask = (uint)ScrollInfoMask.SIF_ALL;
                                GetScrollInfo(_targetHandle, (int)ScrollBarDirection.SB_VERT, ref si);
                                SendMessage(_targetHandle, LVM_SCROLL, IntPtr.Zero, (IntPtr)((int)(((e.NewValue - si.nPos) * _referenceControl.ClientRectangle.Height) / si.nPage)));
                            }
                            else
                            {
                                if (_referenceControl is TreeView)
                                {
                                    SetScrollPos(_targetHandle, WM_VSCROLL, e.NewValue, true);
                                }
                                if (e.Type == ScrollEventType.ThumbPosition)
                                    SendMessage(_targetHandle, WM_VSCROLL, (IntPtr)MakeLong((short)SB_THUMBPOSITION, (short)e.NewValue), scrollHandle);
                                else if (e.Type == ScrollEventType.ThumbTrack)
                                    SendMessage(_targetHandle, WM_VSCROLL, (IntPtr)MakeLong((short)SB_THUMBTRACK, (short)e.NewValue), scrollHandle);
                                SendMessage(_targetHandle, WM_VSCROLL, (IntPtr)SB_ENDSCROLL, scrollHandle);
                            }
                        }
                        else
                        {
                            if (e.Type == ScrollEventType.SmallDecrement)
                                SendMessage(_targetHandle, WM_VSCROLL, (IntPtr)SB_LINEUP, scrollHandle);
                            else if (e.Type == ScrollEventType.SmallIncrement)
                                SendMessage(_targetHandle, WM_VSCROLL, (IntPtr)SB_LINEDOWN, scrollHandle);
                            if (e.Type == ScrollEventType.LargeDecrement)
                                SendMessage(_targetHandle, WM_VSCROLL, (IntPtr)SB_PAGEUP, scrollHandle);
                            else if (e.Type == ScrollEventType.LargeIncrement)
                                SendMessage(_targetHandle, WM_VSCROLL, (IntPtr)SB_PAGEDOWN, scrollHandle);
                            SendMessage(_targetHandle, WM_VSCROLL, (IntPtr)SB_ENDSCROLL, scrollHandle);
                        }
                    }
                    else if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                    {
                        IntPtr scrollHandle = IntPtr.Zero;
                        if (_targetHScrollBar != null)
                        {
                            _targetHScrollBar.Value = e.NewValue;
                            scrollHandle = _targetHScrollBar.Handle;
                        }

                        if ((e.Type == ScrollEventType.ThumbPosition) || (e.Type == ScrollEventType.ThumbTrack))
                        {
                            if (_referenceControl is ListView)
                            {
                                SCROLLINFO si = new SCROLLINFO();
                                si.cbSize = (uint)Marshal.SizeOf(si);
                                si.fMask = (uint)ScrollInfoMask.SIF_ALL;
                                GetScrollInfo(_targetHandle, (int)ScrollBarDirection.SB_HORZ, ref si);
                                SendMessage(_targetHandle, LVM_SCROLL, (IntPtr)(e.NewValue - si.nPos), IntPtr.Zero);
                            }
                            else
                            {
                                if (_referenceControl is TreeView)
                                {
                                    SetScrollPos(_targetHandle, WM_HSCROLL, e.NewValue, true);
                                }
                                if (e.Type == ScrollEventType.ThumbPosition)
                                    SendMessage(_targetHandle, WM_HSCROLL, (IntPtr)MakeLong((short)SB_THUMBPOSITION, (short)e.NewValue), scrollHandle);
                                else if (e.Type == ScrollEventType.ThumbTrack)
                                    SendMessage(_targetHandle, WM_HSCROLL, (IntPtr)MakeLong((short)SB_THUMBTRACK, (short)e.NewValue), scrollHandle);
                                SendMessage(_targetHandle, WM_HSCROLL, (IntPtr)SB_ENDSCROLL, scrollHandle);
                            }
                        }
                        else
                        {
                            if (e.Type == ScrollEventType.SmallDecrement)
                                SendMessage(_targetHandle, WM_HSCROLL, (IntPtr)SB_LINEUP, scrollHandle);
                            else if (e.Type == ScrollEventType.SmallIncrement)
                                SendMessage(_targetHandle, WM_HSCROLL, (IntPtr)SB_LINEDOWN, scrollHandle);
                            if (e.Type == ScrollEventType.LargeDecrement)
                                SendMessage(_targetHandle, WM_HSCROLL, (IntPtr)SB_PAGEUP, scrollHandle);
                            else if (e.Type == ScrollEventType.LargeIncrement)
                                SendMessage(_targetHandle, WM_HSCROLL, (IntPtr)SB_PAGEDOWN, scrollHandle);
                            SendMessage(_targetHandle, WM_HSCROLL, (IntPtr)SB_ENDSCROLL, scrollHandle);
                        }
                    }
                }
            }
        }

        void OnTargetControlResize(object sender, EventArgs e)
        {
            AdjustWindow();
        }

        public static ushort LOWORD(IntPtr l)
        {
            return (ushort)(((long)l) & 0xffff);
        }

        public static ushort HIWORD(IntPtr l)
        {
            return (ushort)((((long)l) >> 0x10) & 0xffff);
        }

        public static int GET_Y_LPARAM(IntPtr lParam)
        {
            return (short)HIWORD(lParam);
        }

        public static int GET_X_LPARAM(IntPtr lParam)
        {
            return (short)LOWORD(lParam);
        }

        public int MakeLong(short lowWord, short hiWord)
        {
            return (int)(((ushort)lowWord) | (uint)(hiWord << 16));
        }

        private int MakeLParam(int loWord, int hiWord)
        {
            int res = (int)((hiWord << 16) | (loWord & 0xffff));
            return res;
        }

    }

    /// <summary>
    /// This panel will be the parent of every skinned control
    /// </summary>
    public class PanelEx : Panel
    {
        //The Text property should return the Text value of its child
        public override string Text
        {
            get
            {
                foreach (Control ctrl in Controls)
                {
                    if (!(ctrl is ScrollBarEx))
                        return ctrl.Text;
                }
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
    }

    public class ScrollBarEx : Control
    {

        public event ScrollEventHandler Scroll;

        private Rectangle _backgroundRectangle = new Rectangle();
        private Rectangle _gripRectangle = new Rectangle();
        private Rectangle _trackRectangle = new Rectangle();
        private Rectangle _upperTrackRectangle = new Rectangle();
        private Rectangle _lowerTrackRectangle = new Rectangle();
        private Rectangle _upperArrowRectangle = new Rectangle();
        private Rectangle _lowerArrowRectangle = new Rectangle();

        private State _upperArrowState = State.Normal;
        private State _lowerArrowState = State.Normal;
        private State _gripState = State.Normal;
        private State _upperTrackState = State.Normal;
        private State _lowerTrackState = State.Normal;

        private int _grabPosition = 0;
        private int _oldValue = 0;

        private Image _upperArrowImg = null;
        private Image _lowerArrowImg = null;
        private Image _backgroundImg = null;
        private Image _gripImg = null;

        private Image _bufferImage = null;

        private System.Windows.Forms.Timer _scrollTimer = null;


        public enum BlockOrientation
        {
            Up,
            Down,
            Left,
            Right,
        }

        public enum State
        {
            Normal = 0,
            Hover = 1,
            Pressed = 2,
            PressedHover = 3,
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        struct SCROLLINFO
        {
            public uint cbSize;
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }

        ScrollOrientation _orientation = ScrollOrientation.VerticalScroll;
        public ScrollOrientation Orientation
        {
            get
            {
                return _orientation;
            }
            set
            {
                if (_orientation != value)
                {
                    _orientation = value;
                    InitializeScrollBar();
                }
            }
        }
        private int _minimumThumbHeight = 7;
        public int MinimumThumbHeight
        {
            get
            {
                return _minimumThumbHeight;
            }
            set
            {
                if (_minimumThumbHeight != value)
                {
                    _minimumThumbHeight = value;
                    InitializeScrollBar();
                }
            }
        }

        private int _smallChange = 1;
        public int SmallChange
        {
            get
            {
                return _smallChange;
            }
            set
            {
                if (_smallChange != value)
                {
                    _smallChange = value;
                    UpdateGrip();
                }
            }
        }
        private int _largeChange = 10;
        public int LargeChange
        {
            get
            {
                return _largeChange;
            }
            set
            {
                if (_largeChange != value)
                {
                    _largeChange = value;
                    _pageSize = _largeChange;
                    UpdateGrip();
                }
            }
        }
        private int _minimum = 0;
        public int Minimum
        {
            get
            {
                return _minimum;
            }
            set
            {
                if (_minimum != value)
                {
                    _minimum = value;
                    UpdateGrip();
                }
            }
        }

        private int _maximum = 99;
        public int Maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                if (_maximum != value)
                {
                    _maximum = value;
                    UpdateGrip();
                }
            }
        }

        private int _pageSize = 100;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                if (_pageSize != value)
                {
                    _pageSize = value;
                    _largeChange = _pageSize;
                    UpdateGrip();
                }
            }
        }

        private int _value = 0;
        public int Value
        {
            get
            {
                return _value;
            }

            set
            {
                if (_value != value)
                {
                    _value = value;
                    _oldValue = value;
                    UpdateGrip();
                }
            }
        }

        private Color _hoverColor = Color.FromArgb(186, 229, 248);
        public Color HoverColor
        {
            get
            {
                return _hoverColor;
            }

            set
            {
                _hoverColor = value;
                InitializeScrollBar();
            }
        }

        private Color _pressedColor = Color.FromArgb(138, 212, 243);
        public Color PressedColor
        {
            get
            {
                return _pressedColor;
            }

            set
            {
                _pressedColor = value;
                InitializeScrollBar();
            }
        }

        private Color _normalColor = Color.FromArgb(226, 242, 255);
        public Color NormalColor
        {
            get
            {
                return _normalColor;
            }

            set
            {
                _normalColor = value;
                InitializeScrollBar();
            }
        }

        private Color _trackColor = Color.Empty;
        public Color TrackColor
        {
            get
            {
                if (_trackColor.IsEmpty)
                    return _normalColor;
                else
                    return _trackColor;
            }

            set
            {
                _trackColor = value;
                InitializeScrollBar();
            }
        }

        private Color _trackPressedColor = Color.Empty;
        public Color TrackPressedColor
        {
            get
            {
                if (_trackPressedColor.IsEmpty)
                    return _pressedColor;
                else
                    return _trackPressedColor;
            }

            set
            {
                _trackPressedColor = value;
                InitializeScrollBar();
            }
        }

        public ScrollBarEx()
        {
            this.SetStyle(
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.Selectable, false);
            this.TabStop = false;
            this.Enabled = false;
        }

        public void SetScrollInfo(int smallChange, int largeChange, int nMin, int nMax, int nPos)
        {
            bool update = false;
            if (_smallChange != smallChange)
            {
                _smallChange = smallChange;
                update = true;
            }
            if (_largeChange != largeChange)
            {
                _largeChange = largeChange;
                _pageSize = _largeChange;
                update = true;
            }
            if (_minimum != nMin)
            {
                _minimum = nMin;
                update = true;
            }
            if (_maximum != nMax)
            {
                _maximum = nMax;
                update = true;
            }
            if (_value != nPos)
            {
                _value = nPos;
                update = true;
            }
            if (update)
                UpdateGrip();
        }

        public void SetScrollInfo(int nPage, int nMin, int nMax, int nPos)
        {
            bool update = false;
            if (_pageSize != nPage)
            {
                _pageSize = nPage;
                update = true;
            }
            if (_minimum != nMin)
            {
                _minimum = nMin;
                update = true;
            }
            if (_maximum != nMax)
            {
                _maximum = nMax;
                update = true;
            }
            if (_value != nPos)
            {
                _value = nPos;
                update = true;
            }
            if (update)
                UpdateGrip();
        }

        private void NotifyScroll(ScrollEventType eventType)
        {
            if (Scroll != null)
            {
                if (_oldValue != _value)
                {
                    Scroll(this, new ScrollEventArgs(eventType, _oldValue, _value, Orientation));
                    _oldValue = _value;
                }
            }
        }

        private void UpdateTrack()
        {
            UpdateTrack(true);
        }

        private void UpdateTrack(bool redraw)
        {
            Rectangle oldUpperArrowRectangle = _upperArrowRectangle;
            Rectangle oldLowerArrowRectangle = _lowerArrowRectangle;
            Rectangle oldBackgroundRectangle = _backgroundRectangle;

            _backgroundRectangle = this.ClientRectangle;

            if (Orientation == ScrollOrientation.VerticalScroll)
            {
                _upperArrowRectangle = new Rectangle(1, 1, this.Width - 2, this.Width - 1);
                _lowerArrowRectangle = new Rectangle(1, this.Height - this.Width - 1, this.Width - 2, this.Width - 1);
                if (_upperArrowRectangle.Height + _lowerArrowRectangle.Height > this.Height - 2)
                {
                    _upperArrowRectangle.Height = (this.Height - 2) / 2;
                    if (_upperArrowRectangle.Height < 0)
                        _upperArrowRectangle.Height = 0;
                    _lowerArrowRectangle.Height = _upperArrowRectangle.Height;
                    _lowerArrowRectangle.Y = _upperArrowRectangle.Bottom;
                }
                if (_lowerArrowRectangle.Top - _upperArrowRectangle.Bottom - 2 < 0)
                    _trackRectangle = new Rectangle();
                else
                    _trackRectangle = new Rectangle(1, _upperArrowRectangle.Bottom + 1, this.Width - 2, _lowerArrowRectangle.Top - _upperArrowRectangle.Bottom - 2);
            }
            else
            {
                _upperArrowRectangle = new Rectangle(1, 1, this.Height - 1, this.Height - 2);
                _lowerArrowRectangle = new Rectangle(this.Width - this.Height - 1, 1, this.Height - 1, this.Height - 2);
                if (_upperArrowRectangle.Height + _lowerArrowRectangle.Height > this.Width - 2)
                {
                    _upperArrowRectangle.Width = (this.Width - 2) / 2;
                    if (_upperArrowRectangle.Width < 0)
                        _upperArrowRectangle.Width = 0;
                    _lowerArrowRectangle.Width = _upperArrowRectangle.Width;
                    _lowerArrowRectangle.X = _upperArrowRectangle.Right;
                }
                if (_lowerArrowRectangle.Left - _upperArrowRectangle.Right - 2 < 0)
                    _trackRectangle = new Rectangle();
                else
                    _trackRectangle = new Rectangle(_upperArrowRectangle.Right + 1, 1, _lowerArrowRectangle.Left - _upperArrowRectangle.Right - 2, this.Height - 2);
            }
            bool refreshRequired = false;

            if (oldBackgroundRectangle != _backgroundRectangle)
            {
                RedrawBackground();
                refreshRequired = true;
            }
            if (oldUpperArrowRectangle != _upperArrowRectangle)
            {
                RedrawUpperArrow();
                refreshRequired = true;
            }
            if (oldLowerArrowRectangle != _lowerArrowRectangle)
            {
                RedrawLowerArrow();
                refreshRequired = true;
            }
            if (refreshRequired && redraw)
                Refresh();
        }

        private void UpdateGrip()
        {
            UpdateGrip(true);
        }

        private void UpdateGrip(bool redraw)
        {
            try
            {
                if ((_maximum > _minimum) && (_trackRectangle.Height > 0) && (_trackRectangle.Width > 0))
                {
                    Rectangle oldUpperTrackRectangle = _upperTrackRectangle;
                    Rectangle oldLowerTrackRectangle = _lowerTrackRectangle;
                    Rectangle oldGripRectangle = _gripRectangle;
                    bool refreshRequired = false;

                    if (_value < _minimum)
                        _value = _minimum;
                    else if (_value > _maximum - _pageSize + 1)
                        _value = _maximum - _pageSize + 1;

                    if (_pageSize >= _maximum - _minimum + 1)
                    {
                        _upperTrackRectangle = new Rectangle();
                        _lowerTrackRectangle = new Rectangle();
                        _gripRectangle = new Rectangle();
                        if (oldGripRectangle != _gripRectangle)
                        {
                            RedrawBackground();
                            RedrawUpperArrow();
                            RedrawLowerArrow();
                            refreshRequired = true;
                        }
                    }
                    else
                    {
                        if (Orientation == ScrollOrientation.VerticalScroll)
                        {
                            int height = (_trackRectangle.Height * _pageSize) / (_maximum - _minimum + 1);
                            if (height < MinimumThumbHeight)
                                height = MinimumThumbHeight;
                            int width = _trackRectangle.Width;
                            int left = _trackRectangle.Left;
                            int top = _trackRectangle.Top + ((_value - _minimum) * (_trackRectangle.Height - height)) / (_maximum - _minimum - _pageSize + 1);
                            if (top < _trackRectangle.Top)
                            {
                                height = 0;
                            }
                            _gripRectangle = new Rectangle(left, top, width, height);
                            if ((height > 0) && (height < _trackRectangle.Height))
                            {
                                _upperTrackRectangle = new Rectangle(_trackRectangle.Left, _trackRectangle.Top, _trackRectangle.Width, _gripRectangle.Top - _trackRectangle.Top);
                                _lowerTrackRectangle = new Rectangle(_trackRectangle.Left, _gripRectangle.Bottom, _trackRectangle.Width, _trackRectangle.Bottom - _gripRectangle.Bottom);
                            }
                            else
                            {
                                _upperTrackRectangle = new Rectangle();
                                _lowerTrackRectangle = new Rectangle();
                            }
                        }
                        else
                        {
                            int width = (_trackRectangle.Width * _pageSize) / (_maximum - _minimum + 1);
                            if (width < MinimumThumbHeight)
                                width = MinimumThumbHeight;
                            int height = _trackRectangle.Height;
                            int top = _trackRectangle.Top;
                            int left = _trackRectangle.Left + ((_value - _minimum) * (_trackRectangle.Width - width)) / (_maximum - _minimum - _pageSize + 1);
                            if (left < _trackRectangle.Left)
                            {
                                width = 0;
                            }
                            _gripRectangle = new Rectangle(left, top, width, height);
                            if ((width > 0) && (width < _trackRectangle.Width))
                            {
                                _upperTrackRectangle = new Rectangle(_trackRectangle.Left, _trackRectangle.Top, _gripRectangle.Left - _trackRectangle.Left, _trackRectangle.Height);
                                _lowerTrackRectangle = new Rectangle(_gripRectangle.Right, _trackRectangle.Top, _trackRectangle.Right - _gripRectangle.Right, _trackRectangle.Height);
                            }
                            else
                            {
                                _upperTrackRectangle = new Rectangle();
                                _lowerTrackRectangle = new Rectangle();
                            }
                        }

                        if (oldUpperTrackRectangle != _upperTrackRectangle)
                        {
                            RedrawUpperTrack();
                            refreshRequired = true;
                        }
                        if (oldLowerTrackRectangle != _lowerTrackRectangle)
                        {
                            RedrawLowerTrack();
                            refreshRequired = true;
                        }
                        if (oldGripRectangle != _gripRectangle)
                        {
                            RedrawGrip();
                            refreshRequired = true;
                        }
                    }
                    if (refreshRequired && redraw)
                        Refresh();
                }
            }
            catch { }
        }

        private void UpdateValue()
        {
            try
            {
                Rectangle oldUpperTrackRectangle = _upperTrackRectangle;
                Rectangle oldLowerTrackRectangle = _lowerTrackRectangle;
                if (Orientation == ScrollOrientation.VerticalScroll)
                {
                    _value = _minimum + ((_gripRectangle.Top - _trackRectangle.Top) * (_maximum - _minimum - _pageSize + 1)) / (_trackRectangle.Height - _gripRectangle.Height);
                    if (_value <= _minimum)
                    {
                        _value = _minimum;
                        _gripRectangle.Y = _trackRectangle.Y;
                    }
                    else if (_value >= _maximum - _pageSize + 1)
                    {
                        _value = _maximum - _pageSize + 1;
                        _gripRectangle.Y = _trackRectangle.Top + _trackRectangle.Height - _gripRectangle.Height;
                    }
                    _upperTrackRectangle.Height = _gripRectangle.Top - _trackRectangle.Top;
                    _lowerTrackRectangle.Y = _gripRectangle.Bottom;
                    _lowerTrackRectangle.Height = _trackRectangle.Bottom - _gripRectangle.Bottom;
                }
                else
                {
                    _value = _minimum + ((_gripRectangle.Left - _trackRectangle.Left) * (_maximum - _minimum - _pageSize + 1)) / (_trackRectangle.Width - _gripRectangle.Width);
                    if (_value <= _minimum)
                    {
                        _value = _minimum;
                        _gripRectangle.X = _trackRectangle.X;
                    }
                    else if (_value >= _maximum - _pageSize + 1)
                    {
                        _value = _maximum - _pageSize + 1;
                        _gripRectangle.X = _trackRectangle.Left + _trackRectangle.Width - _gripRectangle.Width;
                    }
                    _upperTrackRectangle.Width = _gripRectangle.Left - _trackRectangle.Left;
                    _lowerTrackRectangle.X = _gripRectangle.Right;
                    _lowerTrackRectangle.Width = _trackRectangle.Right - _gripRectangle.Right;
                }

                bool refreshRequired = false;
                if (oldUpperTrackRectangle != _upperTrackRectangle)
                {
                    RedrawUpperTrack();
                    refreshRequired = true;
                }
                if (oldLowerTrackRectangle != _lowerTrackRectangle)
                {
                    RedrawLowerTrack();
                    refreshRequired = true;
                }
                if (refreshRequired)
                    RedrawGrip();
                if (refreshRequired)
                    Refresh();
            }
            catch { }
        }

        private void InitializeScrollBar()
        {
            if (Orientation == ScrollOrientation.VerticalScroll)
                _smallChange = 1;
            else
                _smallChange = 6;

            _bufferImage = null;
            _backgroundRectangle = new Rectangle();
            _gripRectangle = new Rectangle();
            _trackRectangle = new Rectangle();
            _upperTrackRectangle = new Rectangle();
            _lowerTrackRectangle = new Rectangle();
            _upperArrowRectangle = new Rectangle();
            _lowerArrowRectangle = new Rectangle();
            UpdateTrack(false);
            UpdateGrip(false);
            Refresh();
        }

        private Image DrawArrow(Rectangle rect, BlockOrientation orientation, State state)
        {
            if ((rect.Width > 0) && (rect.Height > 0))
            {
                Image resultImg = new Bitmap(rect.Width, rect.Height);
                if (orientation == BlockOrientation.Up)
                    resultImg = DrawArrowUp(resultImg, new Rectangle(0, 0, rect.Width, rect.Height));
                else if (orientation == BlockOrientation.Down)
                    resultImg = DrawArrowDown(resultImg, new Rectangle(0, 0, rect.Width, rect.Height));
                else if (orientation == BlockOrientation.Left)
                    resultImg = DrawArrowLeft(resultImg, new Rectangle(0, 0, rect.Width, rect.Height));
                else if (orientation == BlockOrientation.Right)
                    resultImg = DrawArrowRight(resultImg, new Rectangle(0, 0, rect.Width, rect.Height));

                if ((state & State.Pressed) != 0)
                    return Colorize(resultImg, PressedColor);
                else if ((state & State.Hover) != 0)
                    return Colorize(resultImg, HoverColor);
                else
                    return Colorize(resultImg, NormalColor);
            }
            else
                return null;
        }

        private Image DrawGrip(Rectangle rect, ScrollOrientation orientation, State state)
        {
            if ((rect.Width > 0) && (rect.Height > 0))
            {
                Image resultImg = new Bitmap(rect.Width, rect.Height);
                if (orientation == ScrollOrientation.HorizontalScroll)
                    resultImg = DrawGripHorizontal(resultImg, new Rectangle(0, 0, rect.Width, rect.Height));
                else if (orientation == ScrollOrientation.VerticalScroll)
                    resultImg = DrawGripVertical(resultImg, new Rectangle(0, 0, rect.Width, rect.Height));

                if ((state & State.Pressed) != 0)
                    return Colorize(resultImg, PressedColor);
                else if ((state & State.Hover) != 0)
                    return Colorize(resultImg, HoverColor);
                else
                    return Colorize(resultImg, NormalColor);
            }
            else
                return null;
        }

        private Image DrawArrowRight(Image sourceImg, Rectangle rect)
        {
            int dw = rect.Width / 3;
            int dh = rect.Height >> 2;
            if ((dh > 0) && (dw > 0))
            {
                Image resultImage = DrawThumbHorizontal(sourceImg, rect);
                if (resultImage != null)
                {
                    using (Graphics g = Graphics.FromImage(resultImage))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        Point p1 = new Point(rect.Left + (dw << 1), rect.Top + (dh << 1));
                        Point p2 = new Point(rect.Left + dw, rect.Top + dh);
                        Point p3 = new Point(rect.Left + dw, rect.Top + (dh << 1) + dh);
                        LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(new Point(rect.Left + dw - 1, rect.Top + dh - 1), new Size(dw + 2, dh + 2)), Color.Empty, Color.Empty, LinearGradientMode.Horizontal);
                        ColorBlend blend = new ColorBlend(4)
                        {
                            Positions = new[] { 0f, .4f, 1f },
                            Colors = new[] {
                            Color.FromArgb(20, 20, 20),
                            Color.FromArgb(120, 120, 120),
                            Color.FromArgb(200, 200, 200)}
                        };
                        brush.InterpolationColors = blend;
                        g.FillPolygon(brush, new Point[] { p1, p2, p3 });
                    }
                }
                return resultImage;
            }
            return sourceImg;
        }

        private Image DrawArrowLeft(Image sourceImg, Rectangle rect)
        {
            int dw = rect.Width / 3;
            int dh = rect.Height >> 2;
            if ((dh > 0) && (dw > 0))
            {
                Image resultImage = DrawThumbHorizontal(sourceImg, rect);
                if (resultImage != null)
                {
                    using (Graphics g = Graphics.FromImage(resultImage))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        Point p1 = new Point(rect.Left + dw, rect.Top + (dh << 1));
                        Point p2 = new Point(rect.Left + (dw << 1), rect.Top + dh);
                        Point p3 = new Point(rect.Left + (dw << 1), rect.Top + (dh << 1) + dh);
                        LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(new Point(rect.Left + dw - 1, rect.Top + (dh << 1) - 1), new Size(dw + 1, dh + 1)), Color.Empty, Color.Empty, LinearGradientMode.ForwardDiagonal);
                        ColorBlend blend = new ColorBlend(4)
                        {
                            Positions = new[] { 0f, .4f, 1f },
                            Colors = new[] {
                            Color.FromArgb(20, 20, 20),
                            Color.FromArgb(120, 120, 120),
                            Color.FromArgb(200, 200, 200)}
                        };
                        brush.InterpolationColors = blend;
                        g.FillPolygon(brush, new Point[] { p1, p2, p3 });
                    }
                }
                return resultImage;
            }
            return sourceImg;
        }

        private Image DrawArrowUp(Image sourceImg, Rectangle rect)
        {
            int dh = rect.Height / 3;
            int dw = rect.Width >> 2;
            if ((dh > 0) && (dw > 0))
            {
                Image resultImage = DrawThumbVertical(sourceImg, rect);
                if (resultImage != null)
                {
                    using (Graphics g = Graphics.FromImage(resultImage))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        Point p1 = new Point(rect.Left + (dw << 1), rect.Top + dh);
                        Point p2 = new Point(rect.Left + dw, rect.Top + (dh << 1));
                        Point p3 = new Point(rect.Left + (dw << 1) + dw, rect.Top + (dh << 1));
                        LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(new Point(rect.Left + (dw << 1) - 1, rect.Top + dh - 1), new Size(dw + 1, dh + 2)), Color.Empty, Color.Empty, LinearGradientMode.ForwardDiagonal);
                        ColorBlend blend = new ColorBlend(4)
                        {
                            Positions = new[] { 0f, .4f, 1f },
                            Colors = new[] {
                            Color.FromArgb(20, 20, 20),
                            Color.FromArgb(120, 120, 120),
                            Color.FromArgb(200, 200, 200)}
                        };
                        brush.InterpolationColors = blend;
                        g.FillPolygon(brush, new Point[] { p1, p2, p3 });
                    }
                }
                return resultImage;
            }
            return sourceImg;
        }

        private Image DrawArrowDown(Image sourceImg, Rectangle rect)
        {
            int dh = rect.Height / 3;
            int dw = rect.Width >> 2;
            if ((dh > 0) && (dw > 0))
            {
                Image resultImage = DrawThumbVertical(sourceImg, rect);
                if (resultImage != null)
                {
                    using (Graphics g = Graphics.FromImage(resultImage))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        Point p1 = new Point(rect.Left + dw << 1, rect.Top + (dh << 1));
                        Point p2 = new Point(rect.Left + dw, rect.Top + dh);
                        Point p3 = new Point(rect.Left + (dw << 1) + dw, rect.Top + dh);
                        LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(new Point(rect.Left + dw - 1, rect.Top + dh - 1), new Size(dw + 2, dh + 2)), Color.Empty, Color.Empty, LinearGradientMode.Vertical);
                        ColorBlend blend = new ColorBlend(4)
                        {
                            Positions = new[] { 0f, .4f, 1f },
                            Colors = new[] {
                            Color.FromArgb(20, 20, 20),
                            Color.FromArgb(120, 120, 120),
                            Color.FromArgb(200, 200, 200)}
                        };
                        brush.InterpolationColors = blend;
                        g.FillPolygon(brush, new Point[] { p1, p2, p3 });
                    }
                }
                return resultImage;
            }
            return sourceImg;
        }

        private Image DrawThumbVertical(Image sourceImg, Rectangle rect)
        {
            if ((sourceImg != null) && (rect.Width > 0) && (rect.Height > 0))
            {
                Image resultImage = new Bitmap(sourceImg);
                if (resultImage != null)
                {
                    using (Graphics g = Graphics.FromImage(resultImage))
                    {
                        g.SmoothingMode = SmoothingMode.None;
                        g.DrawRectangle(new Pen(Color.FromArgb(149, 149, 149)), rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
                        Rectangle workRect = new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2);
                        if ((workRect.Width > 0) && (workRect.Height > 0))
                        {
                            g.DrawRectangle(new Pen(Color.FromArgb(243, 243, 243)), workRect.X, workRect.Y, workRect.Width - 1, workRect.Height - 1);
                            workRect = new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 4);
                            if ((workRect.Width > 0) && (workRect.Height > 0))
                            {
                                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(workRect.X - 1, workRect.Y - 1, workRect.Width + 2, workRect.Height + 2), Color.Empty, Color.Empty, LinearGradientMode.Horizontal);
                                ColorBlend blend = new ColorBlend(4)
                                {
                                    Positions = new[] { 0f, .49f, .5f, 1f },
                                    Colors = new[] {
                                    Color.FromArgb(240, 240, 240),
                                    Color.FromArgb(222, 222, 222),
                                    Color.FromArgb(210, 210, 210),
                                    Color.FromArgb(195, 195, 195)}
                                };
                                brush.InterpolationColors = blend;
                                g.FillRectangle(brush, workRect);
                            }
                            return resultImage;
                        }
                    }
                }
            }
            return sourceImg;
        }

        private Image DrawThumbHorizontal(Image sourceImg, Rectangle rect)
        {
            if ((sourceImg != null) && (rect.Width > 0) && (rect.Height > 0))
            {
                Image resultImage = new Bitmap(sourceImg);
                if (resultImage != null)
                {
                    using (Graphics g = Graphics.FromImage(resultImage))
                    {
                        g.SmoothingMode = SmoothingMode.None;
                        g.DrawRectangle(new Pen(Color.FromArgb(149, 149, 149)), rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
                        Rectangle workRect = new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2);
                        if ((workRect.Width > 0) && (workRect.Height > 0))
                        {
                            g.DrawRectangle(new Pen(Color.FromArgb(243, 243, 243)), workRect.X, workRect.Y, workRect.Width - 1, workRect.Height - 1);
                            workRect = new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 4);
                            if ((workRect.Width > 0) && (workRect.Height > 0))
                            {
                                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(workRect.X - 1, workRect.Y - 1, workRect.Width + 2, workRect.Height + 1), Color.Empty, Color.Empty, LinearGradientMode.Vertical);
                                ColorBlend blend = new ColorBlend(4)
                                {
                                    Positions = new[] { 0f, .49f, .5f, 1f },
                                    Colors = new[] {
                                    Color.FromArgb(240, 240, 240),
                                    Color.FromArgb(222, 222, 222),
                                    Color.FromArgb(210, 210, 210),
                                    Color.FromArgb(195, 195, 195)}
                                };
                                brush.InterpolationColors = blend;
                                g.FillRectangle(brush, workRect);
                            }
                            return resultImage;
                        }
                    }
                }
            }
            return sourceImg;
        }

        private Image DrawGripVertical(Image sourceImg, Rectangle rect)
        {
            if ((sourceImg != null) && (rect.Width > 0) && (rect.Height > 0))
            {
                Image resultImage = DrawThumbVertical(sourceImg, rect);
                if (resultImage != null)
                {
                    using (Graphics g = Graphics.FromImage(resultImage))
                    {
                        if ((rect.Width >= 9) && (rect.Height >= 18))
                        {
                            int width = rect.Width - 6;
                            int posX = rect.Left + 3;
                            int posY = rect.Top + ((rect.Height - 10) >> 1);

                            g.DrawLine(new Pen(Color.FromArgb(208, 208, 208)), posX, posY, posX + width - 3, posY);
                            g.DrawLine(new Pen(Color.FromArgb(208, 208, 208)), posX, posY, posX, posY + 9);
                            g.DrawLine(new Pen(Color.FromArgb(236, 236, 236)), posX + width - 3, posY + 1, posX + width - 3, posY + 9);
                            g.DrawLine(new Pen(Color.FromArgb(236, 236, 236)), posX + width - 3, posY + 9, posX + 1, posY + 9);
                            posX += 1;
                            posY += 1;
                            width -= 2;
                            g.DrawLine(new Pen(new LinearGradientBrush(new Rectangle(posX - 1, 0, width + 2, 1), Color.FromArgb(0, 0, 0), Color.FromArgb(130, 130, 130), LinearGradientMode.Horizontal)), posX, posY, posX + width - 1, posY);
                            posY++;
                            g.DrawLine(new Pen(new LinearGradientBrush(new Rectangle(posX - 1, 0, width + 2, 1), Color.FromArgb(140, 140, 140), Color.FromArgb(200, 200, 200), LinearGradientMode.Horizontal)), posX, posY, posX + width - 1, posY);
                            posY++;
                            g.DrawLine(new Pen(Color.FromArgb(220, 220, 220)), posX, posY, posX + width - 1, posY);
                            posY++;

                            g.DrawLine(new Pen(new LinearGradientBrush(new Rectangle(posX - 1, 0, width + 2, 1), Color.FromArgb(32, 32, 32), Color.FromArgb(135, 135, 135), LinearGradientMode.Horizontal)), posX, posY, posX + width - 1, posY);
                            posY++;
                            g.DrawLine(new Pen(new LinearGradientBrush(new Rectangle(posX - 1, 0, width + 2, 1), Color.FromArgb(140, 140, 140), Color.FromArgb(200, 200, 200), LinearGradientMode.Horizontal)), posX, posY, posX + width - 1, posY);
                            posY++;
                            g.DrawLine(new Pen(Color.FromArgb(220, 220, 220)), posX, posY, posX + width - 1, posY);
                            posY++;

                            g.DrawLine(new Pen(new LinearGradientBrush(new Rectangle(posX - 1, 0, width + 2, 1), Color.FromArgb(64, 64, 64), Color.FromArgb(160, 160, 160), LinearGradientMode.Horizontal)), posX, posY, posX + width - 1, posY);
                            posY++;
                            g.DrawLine(new Pen(new LinearGradientBrush(new Rectangle(posX - 1, 0, width + 2, 1), Color.FromArgb(140, 140, 140), Color.FromArgb(200, 200, 200), LinearGradientMode.Horizontal)), posX, posY, posX + width - 1, posY);
                            posY++;
                            g.DrawLine(new Pen(Color.FromArgb(220, 220, 220)), posX, posY, posX + width - 1, posY);
                        }
                    }
                }
                return resultImage;
            }
            return sourceImg;
        }

        private Image DrawGripHorizontal(Image sourceImg, Rectangle rect)
        {
            if ((sourceImg != null) && (rect.Width > 0) && (rect.Height > 0))
            {
                Image resultImage = DrawThumbHorizontal(sourceImg, rect);
                if (resultImage != null)
                {
                    using (Graphics g = Graphics.FromImage(resultImage))
                    {
                        if ((rect.Height >= 9) && (rect.Width >= 18))
                        {
                            int height = rect.Height - 6;
                            int posY = rect.Top + 3;
                            int posX = rect.Left + ((rect.Width - 10) >> 1);

                            g.DrawLine(new Pen(Color.FromArgb(208, 208, 208)), posX, posY, posX + 9, posY);
                            g.DrawLine(new Pen(Color.FromArgb(208, 208, 208)), posX, posY, posX, posY + height - 3);
                            g.DrawLine(new Pen(Color.FromArgb(236, 236, 236)), posX + 9, posY + 1, posX + 9, posY + height - 3);
                            g.DrawLine(new Pen(Color.FromArgb(236, 236, 236)), posX + 9, posY + height - 3, posX + 1, posY + height - 3);

                            posX += 1;
                            posY += 1;
                            height -= 2;
                            g.DrawLine(new Pen(new LinearGradientBrush(new Rectangle(0, posY - 1, 1, height + 2), Color.FromArgb(0, 0, 0), Color.FromArgb(130, 130, 130), LinearGradientMode.Vertical)), posX, posY, posX, posY + height - 1);
                            posX++;
                            g.DrawLine(new Pen(new LinearGradientBrush(new Rectangle(0, posY - 1, 1, height + 2), Color.FromArgb(140, 140, 140), Color.FromArgb(200, 200, 200), LinearGradientMode.Vertical)), posX, posY, posX, posY + height - 1);
                            posX++;
                            g.DrawLine(new Pen(Color.FromArgb(220, 220, 220)), posX, posY, posX, posY + height - 1);
                            posX++;

                            g.DrawLine(new Pen(new LinearGradientBrush(new Rectangle(0, posY - 1, 1, height + 2), Color.FromArgb(32, 32, 32), Color.FromArgb(135, 135, 135), LinearGradientMode.Vertical)), posX, posY, posX, posY + height - 1);
                            posX++;
                            g.DrawLine(new Pen(new LinearGradientBrush(new Rectangle(0, posY - 1, 1, height + 2), Color.FromArgb(140, 140, 140), Color.FromArgb(200, 200, 200), LinearGradientMode.Vertical)), posX, posY, posX, posY + height - 1);
                            posX++;
                            g.DrawLine(new Pen(Color.FromArgb(220, 220, 220)), posX, posY, posX, posY + height - 1);
                            posX++;

                            g.DrawLine(new Pen(new LinearGradientBrush(new Rectangle(0, posY - 1, 1, height + 2), Color.FromArgb(64, 64, 64), Color.FromArgb(160, 160, 160), LinearGradientMode.Vertical)), posX, posY, posX, posY + height - 1);
                            posX++;
                            g.DrawLine(new Pen(new LinearGradientBrush(new Rectangle(0, posY - 1, 1, height + 2), Color.FromArgb(140, 140, 140), Color.FromArgb(200, 200, 200), LinearGradientMode.Vertical)), posX, posY, posX, posY + height - 1);
                            posX++;
                            g.DrawLine(new Pen(Color.FromArgb(220, 220, 220)), posX, posY, posX, posY + height - 1);
                        }
                    }
                }
                return resultImage;
            }
            return sourceImg;
        }

        private Image DrawBackground(Rectangle rect)
        {
            if ((rect.Width > 0) && (rect.Height > 0))
                return DrawBackground(new Bitmap(rect.Width, rect.Height), rect);
            else
                return null;
        }

        private Image DrawBackground(Image sourceImg, Rectangle rect)
        {
            if ((sourceImg != null) && (rect.Width > 0) && (rect.Height > 0))
            {
                Image resultImage = new Bitmap(sourceImg);
                if (resultImage != null)
                {
                    using (Graphics g = Graphics.FromImage(resultImage))
                    {
                        g.FillRectangle(new SolidBrush(this.BackColor), this.ClientRectangle);
                    }
                    return Colorize(resultImage, NormalColor);
                }
            }
            return sourceImg;
        }

        private Image Colorize(Image sourceImg, Color newColor)
        {
            if ((sourceImg != null) && (sourceImg.Width > 0) && (sourceImg.Height > 0))
            {
                Image resultImage = new Bitmap(sourceImg.Width, sourceImg.Height);
                using (Graphics g = Graphics.FromImage(resultImage))
                {
                    using (ImageAttributes attr = new ImageAttributes())
                    {
                        float ar = ((float)(newColor.R - 200)) / 255f;
                        float ag = ((float)(newColor.G - 200)) / 255f;
                        float ab = ((float)(newColor.B - 200)) / 255f;
                        attr.SetColorMatrix(
                            new ColorMatrix(new float[][] {
                            new[] { 1f, 0, 0, 0, 0 },
                            new[] { 0, 1f, 0, 0, 0 },
                            new[] { 0, 0, 1f, 0, 0 },
                            new[] { 0, 0, 0,  1F, 0 },
                            new[] { ar, ag, ab, 0, 1F }
                            }),
                           ColorMatrixFlag.Default,
                           ColorAdjustType.Bitmap
                        );
                        g.DrawImage(sourceImg, new Rectangle(0, 0, sourceImg.Width, sourceImg.Height), 0, 0, sourceImg.Width, sourceImg.Height, GraphicsUnit.Pixel, attr);
                    }
                }
                return resultImage;
            }
            return sourceImg;
        }

        private Image Colorize2(Image sourceImg, Color newColor)
        {
            if ((sourceImg != null) && (sourceImg.Width > 0) && (sourceImg.Height > 0))
            {
                Image resultImage = new Bitmap(sourceImg.Width, sourceImg.Height);
                using (Graphics g = Graphics.FromImage(resultImage))
                {
                    using (ImageAttributes attr = new ImageAttributes())
                    {
                        float s = (newColor.R + newColor.G + newColor.B);
                        float p = s / (128 * 3);
                        float pR = p * ((float)newColor.R) / s;
                        float pG = p * ((float)newColor.G) / s;
                        float pB = p * ((float)newColor.B) / s;
                        attr.SetColorMatrix(
                            new ColorMatrix(new float[][] {
                            new[] { pR, pG, pB, 0, 0 },
                            new[] { pR, pG, pB, 0, 0 },
                            new[] { pR, pG, pB, 0, 0 },
                            new[] { 0, 0, 0,  1F, 0 },
                            new[] { 0, 0, 0, 0, 1F }
                            }),
                           ColorMatrixFlag.Default,
                           ColorAdjustType.Bitmap
                        );
                        g.DrawImage(sourceImg, new Rectangle(0, 0, sourceImg.Width, sourceImg.Height), 0, 0, sourceImg.Width, sourceImg.Height, GraphicsUnit.Pixel, attr);
                    }
                }
                return resultImage;
            }
            return sourceImg;
        }

        private Image Colorize1(Image sourceImg, Color newColor)
        {
            if ((sourceImg != null) && (sourceImg.Width > 0) && (sourceImg.Height > 0))
            {
                Image resultImage = new Bitmap(sourceImg.Width, sourceImg.Height);
                using (Graphics g = Graphics.FromImage(resultImage))
                {
                    using (ImageAttributes attr = new ImageAttributes())
                    {
                        float s = (newColor.R + newColor.G + newColor.B);
                        float pR = ((float)newColor.R) / s;
                        float pG = ((float)newColor.G) / s;
                        float pB = ((float)newColor.B) / s;
                        attr.SetColorMatrix(
                            new ColorMatrix(new float[][] {
                            new[] { pR, pG, pB, 0, 0 },
                            new[] { pR, pG, pB, 0, 0 },
                            new[] { pR, pG, pB, 0, 0 },
                            new[] { 0, 0, 0,  1F, 0 },
                            new[] { 0, 0, 0, 0, 1F }
                            }),
                           ColorMatrixFlag.Default,
                           ColorAdjustType.Bitmap
                        );
                        g.DrawImage(sourceImg, new Rectangle(0, 0, sourceImg.Width, sourceImg.Height), 0, 0, sourceImg.Width, sourceImg.Height, GraphicsUnit.Pixel, attr);
                    }
                }
                return resultImage;
            }
            return sourceImg;
        }

        private void RedrawBackground()
        {
            if ((this.Width > 0) && (this.Height > 0))
            {
                if (_bufferImage == null)
                    _bufferImage = new Bitmap(this.Width, this.Height);

                _backgroundImg = DrawBackground(this.ClientRectangle);
                if (_backgroundImg != null)
                {
                    using (Graphics g = Graphics.FromImage(_bufferImage))
                    {
                        g.DrawImage(_backgroundImg, new Point(0, 0));
                    }
                }
            }
        }

        private void RedrawUpperArrow()
        {
            if ((this.Width > 0) && (this.Height > 0))
            {
                if (_bufferImage == null)
                    _bufferImage = new Bitmap(this.Width, this.Height);

                if (Orientation == ScrollOrientation.VerticalScroll)
                {
                    _upperArrowImg = DrawArrow(_upperArrowRectangle, BlockOrientation.Up, _upperArrowState);
                }
                else
                {
                    _upperArrowImg = DrawArrow(_upperArrowRectangle, BlockOrientation.Left, _upperArrowState);
                }
                if (_upperArrowImg != null)
                {
                    using (Graphics g = Graphics.FromImage(_bufferImage))
                    {
                        g.DrawImage(_upperArrowImg, _upperArrowRectangle.Location);
                    }
                }
            }
        }

        private void RedrawLowerArrow()
        {
            if ((this.Width > 0) && (this.Height > 0))
            {
                if (_bufferImage == null)
                    _bufferImage = new Bitmap(this.Width, this.Height);

                if (Orientation == ScrollOrientation.VerticalScroll)
                {
                    _lowerArrowImg = DrawArrow(_lowerArrowRectangle, BlockOrientation.Down, _lowerArrowState);
                }
                else
                {
                    _lowerArrowImg = DrawArrow(_lowerArrowRectangle, BlockOrientation.Right, _lowerArrowState);
                }
                if (_lowerArrowImg != null)
                {
                    using (Graphics g = Graphics.FromImage(_bufferImage))
                    {
                        g.DrawImage(_lowerArrowImg, _lowerArrowRectangle.Location);
                    }
                }
            }
        }

        private void RedrawGrip()
        {
            if ((this.Width > 0) && (this.Height > 0))
            {
                if (_bufferImage == null)
                    _bufferImage = new Bitmap(this.Width, this.Height);

                _gripImg = DrawGrip(_gripRectangle, Orientation, _gripState);
                if (_gripImg != null)
                {
                    using (Graphics g = Graphics.FromImage(_bufferImage))
                    {
                        g.DrawImage(_gripImg, _gripRectangle.Location);
                    }
                }
            }
        }

        private void RedrawUpperTrack()
        {
            if ((this.Width > 0) && (this.Height > 0))
            {
                if (_bufferImage == null)
                    _bufferImage = new Bitmap(this.Width, this.Height);

                using (Graphics g = Graphics.FromImage(_bufferImage))
                {
                    if (_upperTrackState == State.Normal)
                        g.FillRectangle(new SolidBrush(TrackColor), _upperTrackRectangle);
                    else
                        g.FillRectangle(new SolidBrush(TrackPressedColor), _upperTrackRectangle);
                }
            }
        }

        private void RedrawLowerTrack()
        {
            if ((this.Width > 0) && (this.Height > 0))
            {
                if (_bufferImage == null)
                    _bufferImage = new Bitmap(this.Width, this.Height);
                using (Graphics g = Graphics.FromImage(_bufferImage))
                {
                    if (_lowerTrackState == State.Normal)
                        g.FillRectangle(new SolidBrush(TrackColor), _lowerTrackRectangle);
                    else
                        g.FillRectangle(new SolidBrush(TrackPressedColor), _lowerTrackRectangle);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (System.IO.File.Exists("c:\\BufferImage.bmp"))
                    System.IO.File.Delete("c:\\BufferImage.bmp");

                if (_bufferImage != null)
                    _bufferImage.Save("c:\\BufferImage.bmp", ImageFormat.Bmp);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }

            if (_bufferImage != null)
                e.Graphics.DrawImage(_bufferImage, new Point(0, 0));
            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            InitializeScrollBar();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            InnerMouseLeave();
        }

        public void InnerMouseLeave()
        {
            if (_upperArrowState != State.Normal)
            {
                _upperArrowState = State.Normal;
                RedrawUpperArrow();
                Refresh();
            }
            if (_lowerArrowState != State.Normal)
            {
                _lowerArrowState = State.Normal;
                RedrawLowerArrow();
                Refresh();
            }
            if (_gripState != State.Normal)
            {
                _gripState = State.Normal;
                RedrawGrip();
                Refresh();
            }
            if (_upperTrackState != State.Normal)
            {
                _upperTrackState = State.Normal;
                RedrawUpperTrack();
                Refresh();
            }
            if (_lowerTrackState != State.Normal)
            {
                _lowerTrackState = State.Normal;
                RedrawLowerTrack();
                Refresh();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                InnerMouseDown(e.X, e.Y, true);
            }
        }

        public void InnerMouseDown(int x, int y, bool startThreads)
        {
            if (_upperArrowRectangle.Contains(new Point(x, y)))
            {
                if ((_upperArrowState & State.Pressed) == 0)
                {
                    _upperArrowState |= State.Pressed;
                    RedrawUpperArrow();
                    Refresh();
                    if (startThreads)
                        StartUpperArrowTimer();
                }
            }
            else if (_lowerArrowRectangle.Contains(new Point(x, y)))
            {
                if ((_lowerArrowState & State.Pressed) == 0)
                {
                    _lowerArrowState |= State.Pressed;
                    RedrawLowerArrow();
                    Refresh();
                    if (startThreads)
                        StartLowerArrowTimer();
                }
            }
            if (_upperTrackRectangle.Contains(new Point(x, y)))
            {
                if ((_upperTrackState & State.Pressed) == 0)
                {
                    _upperTrackState |= State.Pressed;
                    RedrawUpperTrack();
                    Refresh();
                    if (startThreads)
                        StartUpperTrackTimer();
                }
            }
            if (_lowerTrackRectangle.Contains(new Point(x, y)))
            {
                if ((_lowerTrackState & State.Pressed) == 0)
                {
                    _lowerTrackState |= State.Pressed;
                    RedrawLowerTrack();
                    Refresh();
                    if (startThreads)
                        StartLowerTrackTimer();
                }
            }
            else if (_gripRectangle.Contains(new Point(x, y)))
            {
                if ((_gripState & State.Pressed) == 0)
                {
                    if (this.Orientation == ScrollOrientation.VerticalScroll)
                        _grabPosition = y - _gripRectangle.Top;
                    else
                        _grabPosition = x - _gripRectangle.Left;
                    _gripState |= State.Pressed;
                    RedrawGrip();
                    Refresh();
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                InnerMouseUp();
            }
        }

        public void InnerMouseUp()
        {
            StopTimer();
            if ((_upperArrowState & State.Pressed) != 0)
            {
                _upperArrowState &= ~State.Pressed;
                RedrawUpperArrow();
                Refresh();
            }
            if ((_lowerArrowState & State.Pressed) != 0)
            {
                _lowerArrowState &= ~State.Pressed;
                RedrawLowerArrow();
                Refresh();
            }
            if ((_upperTrackState & State.Pressed) != 0)
            {
                _upperTrackState &= ~State.Pressed;
                RedrawUpperTrack();
                Refresh();
            }
            if ((_lowerTrackState & State.Pressed) != 0)
            {
                _lowerTrackState &= ~State.Pressed;
                RedrawLowerTrack();
                Refresh();
            }
            if ((_gripState & State.Pressed) != 0)
            {
                _gripState &= ~State.Pressed;
                RedrawGrip();
                NotifyScroll(ScrollEventType.ThumbPosition);
                Refresh();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            InnerMouseMove(e.X, e.Y);
        }

        public void InnerMouseMove(int x, int y)
        {
            if ((_gripState & State.Pressed) != 0)
            {
                if (this.Orientation == ScrollOrientation.VerticalScroll)
                {
                    int gripTop = y - _grabPosition;
                    if (gripTop != _gripRectangle.Top)
                    {
                        _gripRectangle.Y = gripTop;
                        UpdateValue();
                        NotifyScroll(ScrollEventType.ThumbTrack);
                    }
                }
                else
                {
                    int gripLeft = x - _grabPosition;
                    if (gripLeft != _gripRectangle.Left)
                    {
                        _gripRectangle.X = gripLeft;
                        UpdateValue();
                        NotifyScroll(ScrollEventType.ThumbTrack);
                    }
                }
            }
            else
            {
                if (_upperArrowRectangle.Contains(new Point(x, y)))
                {
                    if ((_upperArrowState & State.Hover) == 0)
                    {
                        _upperArrowState |= State.Hover;
                        RedrawUpperArrow();
                        Refresh();
                    }
                }
                else if ((_upperArrowState & State.Hover) != 0)
                {
                    _upperArrowState &= ~State.Hover;
                    RedrawUpperArrow();
                    Refresh();
                }

                if (_lowerArrowRectangle.Contains(new Point(x, y)))
                {
                    if ((_lowerArrowState & State.Hover) == 0)
                    {
                        _lowerArrowState |= State.Hover;
                        RedrawLowerArrow();
                        Refresh();
                    }
                }
                else if ((_lowerArrowState & State.Hover) != 0)
                {
                    _lowerArrowState &= ~State.Hover;
                    RedrawLowerArrow();
                    Refresh();
                }

                if (_gripRectangle.Contains(new Point(x, y)))
                {
                    if ((_gripState & State.Hover) == 0)
                    {
                        _gripState |= State.Hover;
                        RedrawGrip();
                        Refresh();
                    }
                }
                else if ((_gripState & State.Hover) != 0)
                {
                    _gripState &= ~State.Hover;
                    RedrawGrip();
                    Refresh();
                }
            }
        }

        private void StartUpperArrowTimer()
        {
            StartInitialTimer(OnUpperArrowTick, 300);
        }

        private void StartLowerArrowTimer()
        {
            StartInitialTimer(OnLowerArrowTick, 300);
        }

        private void StartUpperTrackTimer()
        {
            StartInitialTimer(OnUpperTrackTick, 300);
        }

        private void StartLowerTrackTimer()
        {
            StartInitialTimer(OnLowerTrackTick, 300);
        }

        private delegate void InitialTimerDelegate(TimerDelegate tickDelegate, int initialDelay);
        private delegate void TimerDelegate(object sender, EventArgs e);

        private Mutex _timerSynch = new Mutex();

        private void StartInitialTimer(TimerDelegate tickDelegate, int initialDelay)
        {
            _timerSynch.WaitOne();
            if (_scrollTimer == null)
            {
                tickDelegate(null, null);
                _scrollTimer = new System.Windows.Forms.Timer();
                _scrollTimer.Interval = initialDelay;
                _scrollTimer.Tag = tickDelegate;
                _scrollTimer.Tick += new EventHandler(StartTimer);
                _scrollTimer.Start();
            }
            _timerSynch.ReleaseMutex();
        }

        private void StartTimer(object sender, EventArgs e)
        {
            _timerSynch.WaitOne();
            if (_scrollTimer != null)
            {
                _scrollTimer.Stop();
                _scrollTimer.Interval = 100;
                _scrollTimer.Tick += new EventHandler((TimerDelegate)_scrollTimer.Tag);
                _scrollTimer.Start();
            }
            _timerSynch.ReleaseMutex();
        }

        private void StopTimer()
        {
            _timerSynch.WaitOne();
            if (_scrollTimer != null)
            {
                _scrollTimer.Stop();
                _scrollTimer = null;
            }
            _timerSynch.ReleaseMutex();
        }

        void OnUpperArrowTick(object sender, EventArgs e)
        {
            _value -= _smallChange;
            UpdateGrip();
            NotifyScroll(ScrollEventType.SmallDecrement);
        }

        void OnLowerArrowTick(object sender, EventArgs e)
        {
            _value += _smallChange;
            UpdateGrip();
            NotifyScroll(ScrollEventType.SmallIncrement);
        }

        void OnUpperTrackTick(object sender, EventArgs e)
        {
            if (Orientation == ScrollOrientation.VerticalScroll)
            {
                int posY = this.PointToClient(Cursor.Position).Y;
                if (posY < _gripRectangle.Top)
                {
                    _value -= _largeChange;
                    UpdateGrip();
                    NotifyScroll(ScrollEventType.LargeDecrement);
                }
            }
            else
            {
                int posX = this.PointToClient(Cursor.Position).X;
                if (posX < _gripRectangle.Left)
                {
                    _value -= _largeChange;
                    UpdateGrip();
                    NotifyScroll(ScrollEventType.LargeDecrement);
                }
            }
        }

        void OnLowerTrackTick(object sender, EventArgs e)
        {
            if (Orientation == ScrollOrientation.VerticalScroll)
            {
                int posY = this.PointToClient(Cursor.Position).Y;
                if (posY >= _gripRectangle.Bottom)
                {
                    _value += _pageSize;
                    NotifyScroll(ScrollEventType.LargeIncrement);
                    UpdateGrip();
                }
            }
            else
            {
                int posX = this.PointToClient(Cursor.Position).X;
                if (posX >= _gripRectangle.Right)
                {
                    _value += _pageSize;
                    NotifyScroll(ScrollEventType.LargeIncrement);
                    UpdateGrip();
                }
            }
        }
    }
}
