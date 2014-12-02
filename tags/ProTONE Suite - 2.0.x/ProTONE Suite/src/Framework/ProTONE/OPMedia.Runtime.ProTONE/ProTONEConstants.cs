using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPMedia.Runtime.ProTONE
{
    public static class ProTONEConstants
    {
        public const string LibraryName = "OPMedia.MediaLibrary";
        public const string PlayerName = "OPMedia.ProTONE";

        public const string PlayerUserAgent = "ProTONE Player";
        public const string AnonymousUser = "anonymous";

        public const string RCCManagerName = "OPMedia.RCCManager";
        public const string RCCServiceShortName = "OPMedia.RCCService";
        public const string ShellSupportName = "OPMedia.ShellSupport";

        public const string ShellSupportBinary = ShellSupportName + ".dll";
        public const string LibraryBinary = LibraryName + ".exe";
        public const string PlayerBinary = PlayerName + ".exe";
        public const string RCCManagerBinary = RCCManagerName + ".exe";
        public const string RCCServiceBinary = RCCServiceShortName + ".exe";
        public const string RCCServiceLongName = "OPMedia Remote Control and Communication Service";
        public const string RCCServiceDescription = "Manages communication amongst ProTONE Player and external applications.";

        public const string SubtitleFileTypeDesc = "Video Subtitle File";
        public const string CatalogFileTypeDesc = "OPMedia Catalog File (.CTX)";
        public const string BookmarkFileTypeDesc = "OPMedia Bookmark File (.BMK)";


        public const string ShellIntegrationSuportGuid = "DA0C2154-977C-36C0-AD5B-9905BE5EB4D4";
        public const string CanonicShellIntegrationSuportGuid = "{" + ShellIntegrationSuportGuid + "}";
    }
}
