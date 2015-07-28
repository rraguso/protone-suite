using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using OPMedia.Core.Logging;
using OPMedia.Core.Utilities;
using OPMedia.Core;

namespace OPMedia.Runtime
{
    public enum ScheduledActionType
    {
        None,
        Shutdown,
        StandBy,
        Hibernate,
        LaunchProgram
    }

    [Flags]
    public enum Weekday
    {
        None = 0x00,
        Monday = 0x01,
        Tuesday = 0x02,
        Wednesday = 0x04,
        Thursday = 0x08,
        Friday = 0x10,
        Saturday = 0x20,
        Sunday = 0x40,
        Everyday = 0x7F,
    }

    public class ProgramStartupInfo
    {
        ProcessStartInfo _psi = new ProcessStartInfo();

        public string LaunchPath
        { get { return _psi.FileName; } set { _psi.FileName = value; } }

        public string Arguments
        { get { return _psi.Arguments; } set { _psi.Arguments = value; } }

        public string WorkDir
        { 
            get 
            {
                if (string.IsNullOrEmpty(_psi.WorkingDirectory))
                    return Path.GetDirectoryName(_psi.FileName);
                else
                    return _psi.WorkingDirectory;
            } 

            set 
            {
                if (Path.GetDirectoryName(_psi.FileName) != value)
                {
                    _psi.WorkingDirectory = value;
                }
                else
                    _psi.WorkingDirectory = null;
            } 
        }

        public void ExecuteProgram(bool wait)
        {
            try
            {
                Process p = Process.Start(_psi);
                if (p != null && wait)
                {
                    p.WaitForExit();
                }
            }
            catch(Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }

        private ProgramStartupInfo()
        {
        }

        public ProgramStartupInfo(string launchPath, string args, string workDir)
        {
            if (string.IsNullOrEmpty(launchPath))
                throw new ArgumentException("Please specify a valid value for launchPath");

            this.Arguments = args;
            this.LaunchPath = launchPath;
            this.WorkDir = workDir;
        }

        public string GetDescString()
        {
            string retVal = _psi.FileName;

            if (!string.IsNullOrEmpty(_psi.Arguments))
                retVal += " " + _psi.Arguments;

            if (!string.IsNullOrEmpty(_psi.WorkingDirectory))
                retVal += " [WD=" + _psi.WorkingDirectory + "]";

            return retVal;
        }

        public string Serialize()
        {
            string[] data = new string[3];
            data[0] = _psi.FileName;
            data[1] = _psi.Arguments;
            data[2] = _psi.WorkingDirectory;
            return StringUtils.FromStringArray(data, '?');
        }

        public static ProgramStartupInfo FromString(string input)
        {
            ProgramStartupInfo psi = null;
            string[] data = StringUtils.ToStringArray(input, '?');

            if (data != null)
            {
                psi = new ProgramStartupInfo();

                if (data.Length > 0) psi._psi.FileName = data[0];
                if (data.Length > 1) psi._psi.Arguments = data[1];
                if (data.Length > 2) psi._psi.WorkingDirectory = data[2];
            }

            return psi;
        }
    }
}
