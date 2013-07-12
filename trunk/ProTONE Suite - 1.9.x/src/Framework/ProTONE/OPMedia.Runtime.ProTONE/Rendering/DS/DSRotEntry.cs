using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;


namespace OPMedia.Runtime.ProTONE.Rendering.DS
{
    public class DsROTEntry : IDisposable
    {
        // Fields
        private int m_cookie;

        // Methods
        public DsROTEntry(IFilterGraph graph)
        {
            IRunningObjectTable pprot = null;
            IMoniker ppmk = null;
            try
            {
                string str;
                DsError.ThrowExceptionForHR(GetRunningObjectTable(0, out pprot));
                int id = Process.GetCurrentProcess().Id;
                IntPtr iUnknownForObject = Marshal.GetIUnknownForObject(graph);
                try
                {
                    str = iUnknownForObject.ToString("x");
                }
                catch
                {
                    str = "";
                }
                finally
                {
                    Marshal.Release(iUnknownForObject);
                }
                string item = string.Format("FilterGraph {0} pid {1}", str, id.ToString("x8"));
                DsError.ThrowExceptionForHR(CreateItemMoniker("!", item, out ppmk));
                this.m_cookie = pprot.Register(1, graph, ppmk);
            }
            finally
            {
                if (ppmk != null)
                {
                    Marshal.ReleaseComObject(ppmk);
                    ppmk = null;
                }
                if (pprot != null)
                {
                    Marshal.ReleaseComObject(pprot);
                    pprot = null;
                }
            }
        }

        [SuppressUnmanagedCodeSecurity, DllImport("ole32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int CreateItemMoniker(string delim, string item, out IMoniker ppmk);
        public void Dispose()
        {
            if (this.m_cookie != 0)
            {
                GC.SuppressFinalize(this);
                IRunningObjectTable pprot = null;
                DsError.ThrowExceptionForHR(GetRunningObjectTable(0, out pprot));
                try
                {
                    pprot.Revoke(this.m_cookie);
                    this.m_cookie = 0;
                }
                finally
                {
                    Marshal.ReleaseComObject(pprot);
                    pprot = null;
                }
            }
        }

        ~DsROTEntry()
        {
            this.Dispose();
        }

        [SuppressUnmanagedCodeSecurity, DllImport("ole32.dll", ExactSpelling = true)]
        private static extern int GetRunningObjectTable(int r, out IRunningObjectTable pprot);

        // Nested Types
        [Flags]
        private enum ROTFlags
        {
            AllowAnyClient = 2,
            RegistrationKeepsAlive = 1
        }
    }

 

}
