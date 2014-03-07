using System;
using System.Collections.Generic;
using System.Text;

namespace OPMedia.Core
{
    public partial class Constants
    {
        public const string SuiteName = "ProTONE Suite";

        public const string CompanyName =           "OPMedia Research";
        public const string CopyrightNotice =       "Copyright � " + CompanyName + ", 2005-2013";

        public const string PlayerUserAgent =       "ProTONE Player";
        public const string AnonymousUser =         "anonymous";

        public const string LibraryName =           "OPMedia.MediaLibrary";
        public const string PlayerName =            "OPMedia.ProTONE";
        public const string RCCManagerName =        "OPMedia.RCCManager";
        public const string MediaHostName =         "OPMedia.MediaHost";
        public const string SyncPlayerName =        "OPMedia.SyncPlayer";
        public const string RCCServiceShortName =   "OPMedia.RCCService";
        public const string ShellSupportName =      "OPMedia.ShellSupport";
        public const string UtilityName =           "OPMedia.Utility";
        public const string PersistenceServiceShortName = "OPMedia.PersistenceService";

        public const string ShellSupportBinary =    ShellSupportName + ".dll";
        public const string LibraryBinary =         LibraryName + ".exe";
        public const string PlayerBinary =          PlayerName + ".exe";
        public const string RCCManagerBinary =      RCCManagerName + ".exe";
        public const string MediaHostBinary =       MediaHostName + ".exe";
        public const string SyncPlayerBinary =      SyncPlayerName + ".exe";
        public const string RCCServiceBinary =      RCCServiceShortName + ".exe";
        public const string UtilityBinary =         UtilityName + ".exe";
        public const string PersistenceServiceBinary = PersistenceServiceShortName + ".exe";

        public const string PersistenceServiceLongName = "OPMedia Persistence Service";
        public const string PersistenceServiceDescription = "Provides long-time persistence support ProTONE Suite applications.";

        public const string RCCServiceLongName = "OPMedia Remote Control and Communication Service";
        public const string RCCServiceDescription = "Manages communication amongst ProTONE Player and external applications.";

        public const string SubtitleFileTypeDesc =  "Video Subtitle File";
        public const string CatalogFileTypeDesc =   "OPMedia Catalog File (.CTX)";
        public const string BookmarkFileTypeDesc =  "OPMedia Bookmark File (.BMK)";


        public const bool SecureRemotingChannels = false;

        public const string ShellIntegrationSuportGuid = "DA0C2154-977C-36C0-AD5B-9905BE5EB4D4";
        public const string CanonicShellIntegrationSuportGuid = "{" + ShellIntegrationSuportGuid + "}";
    }
}
