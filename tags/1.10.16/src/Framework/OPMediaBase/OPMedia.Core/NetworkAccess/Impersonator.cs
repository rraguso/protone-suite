using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using OPMedia.Core;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace OPMedia.Runtime.NetworkAccess
{
    /// <summary>
    /// Allows code to be executed under the security context of a specified user account.
    /// </summary>
    /// <remarks>    
    public class Impersonator : IDisposable
    {
        private WindowsImpersonationContext _wic;

        /// <summary>
        /// Begins impersonation with the given credentials, Logon type and Logon provider.
        /// </summary>
        ///
        public Impersonator(string userName, string domainName, string password, 
            LogonTypes logonType, LogonProvider logonProvider)
        {
            Impersonate(userName, domainName, password, logonType, logonProvider);
        }

        /// <summary>
        /// Begins impersonation with the given credentials.
        /// </summary>
        ///
        public Impersonator(string userName, string domainName, string password)
        {
            Impersonate(userName, domainName, password, LogonTypes.LOGON32_LOGON_INTERACTIVE, LogonProvider.LOGON32_PROVIDER_DEFAULT);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Impersonator"/> class.
        /// </summary>
        public Impersonator()
        {}

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            UndoImpersonation();
        }

        /// <summary>
        /// Impersonates the specified user account.
        /// </summary>
        ///
        public void Impersonate(string userName, string domainName, string password)
        {
            Impersonate(userName, domainName, password, LogonTypes.LOGON32_LOGON_INTERACTIVE, LogonProvider.LOGON32_PROVIDER_DEFAULT);
        }

        /// <summary>
        /// Impersonates the specified user account.
        /// </summary>
        ///
        public void Impersonate(string userName, string domainName, string password, LogonTypes logonType, LogonProvider logonProvider)
        {
            UndoImpersonation();

            IntPtr logonToken = IntPtr.Zero;
            IntPtr logonTokenDuplicate = IntPtr.Zero;
            try
            {
                // revert to the application pool identity, saving the identity of the current requestor
                _wic = WindowsIdentity.Impersonate(IntPtr.Zero);

                // do logon & impersonate
                if (Advapi32.LogonUser(userName,
                                domainName,
                                password,
                                (int)logonType,
                                (int)logonProvider,
                                ref logonToken))
                {
                    if (Advapi32.DuplicateToken(logonToken, (int)SecurityImpersonationLevel.SecurityImpersonation, ref logonTokenDuplicate))
                    {
                        var wi = new WindowsIdentity(logonTokenDuplicate);
                        wi.Impersonate();    // discard the returned identity context (which is the context of the application pool)
                    }
                    else
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                else
                    throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            finally
            {
                if (logonToken != IntPtr.Zero)
                    Kernel32.CloseHandle(logonToken);

                if (logonTokenDuplicate != IntPtr.Zero)
                    Kernel32.CloseHandle(logonTokenDuplicate);
            }
        }

        /// <summary>
        /// Stops impersonation.
        /// </summary>
        private void UndoImpersonation()
        {
            // restore saved requestor identity
            if (_wic != null)
                _wic.Undo();
            _wic = null;
        }
    }
}
