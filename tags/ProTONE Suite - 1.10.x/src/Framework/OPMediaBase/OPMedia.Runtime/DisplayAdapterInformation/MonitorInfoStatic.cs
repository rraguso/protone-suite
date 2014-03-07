using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using OPMedia.Runtime.ApplicationSettings;

namespace OPMedia.Runtime.DisplayAdapterInformation
{
    public partial class MonitorInfo
    {
        private static Dictionary<string, MonitorInfo> _allMonitors;

        public static MonitorInfo PrimaryMonitor
        {
            get
            {
                if (_allMonitors != null && _allMonitors.Count > 0)
                {
                    foreach (MonitorInfo mi in _allMonitors.Values)
                    {
                        if (mi.IsPrimary)
                            return mi;
                    }

                    return _allMonitors.Values.First();
                }

                return null;
            }
        }

        public static List<MonitorInfo> AllMonitors
        {
            get
            {
                return new List<MonitorInfo>(_allMonitors.Values);
            }
        }

        public static MonitorInfo ActualMonitor
        {
            get
            {
                MonitorInfo mi = GetMonitorInfo(AppSettings.PreferredMonitorName);
                if (mi == null)
                {
                    // Preferred device not found, use fallback device
                    mi = GetMonitorInfo(AppSettings.FallbackMonitorName);
                }

                if (mi == null)
                {
                    // Fallback device not found as well, use primary device
                    mi = PrimaryMonitor;
                }

                return mi;
            }
        }

        public static MonitorInfo GetMonitorInfo(string name)
        {
            if (_allMonitors.ContainsKey(name))
            {
                return _allMonitors[name];
            }

            return null;
        }

        static MonitorInfo()
        {
            RefreshMonitorInfo();
            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);
        }

        private static void RefreshMonitorInfo()
        {
            _allMonitors = new Dictionary<string, MonitorInfo>();
            foreach (Screen scr in Screen.AllScreens)
            {
                MonitorInfo mi = new MonitorInfo(scr);
                _allMonitors.Add(mi.Name, mi);
            }
        }

        static void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            RefreshMonitorInfo();
        }
    }


}
