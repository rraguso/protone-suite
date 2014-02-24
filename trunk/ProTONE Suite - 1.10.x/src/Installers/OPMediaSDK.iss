;------------------------------
; macrodefinitions
#define BINDIR "..\bin"
#define OUTDIR "..\..\..\..\publish\1.10"
#define EXTDIR "..\..\externals"
#define VERSION GetStringFileInfo(BINDIR + "\OPMedia.Core.dll", FILE_VERSION)
#define COMPANY GetStringFileInfo(BINDIR + "\OPMedia.Core.dll", COMPANY_NAME)
#define PRODUCT "OPMedia SDK"
#define REGENTRY "Software" + "\" + COMPANY + "\" + PRODUCT

#expr WriteIni(OUTDIR + "\Versions.txt", PRODUCT, "Version", VERSION)


[Setup]
;------------------------------
AppID={{6C6BA7FE-D240-4DA0-BFD6-AF8DA8106A4F}
;------------------------------
AppVersion={#VERSION}
OutputBaseFilename={#PRODUCT} {#VERSION}
VersionInfoVersion={#VERSION}
VersionInfoTextVersion={#VERSION}
VersionInfoProductVersion={#VERSION}

AppPublisher={#COMPANY}
VersionInfoCompany={#COMPANY}
VersionInfoCopyright={#COMPANY}

AppName={#PRODUCT}
VersionInfoDescription={#PRODUCT}
VersionInfoProductName={#PRODUCT}

DefaultDirName={pf}\{#COMPANY}\{#PRODUCT}
DefaultGroupName={#COMPANY}\{#PRODUCT}

OutputDir={#OUTDIR}

;------------------------------
AllowNoIcons=true
ChangesAssociations=true
ChangesEnvironment=true
Compression=lzma
DirExistsWarning=yes
DisableFinishedPage=false
DisableReadyPage=false
DisableStartupPrompt=true
EnableDirDoesntExistWarning=true
LanguageDetectionMethod=locale

; WinXP SP3 - miniumum OS required for .NET Framework 4.0
MinVersion=0,5.01.2600sp3

SetupIconFile=Installer.ico
SetupLogging=true
ShowLanguageDialog=yes
ShowTasksTreeLines=true
SignedUninstaller=false
SolidCompression=true
UninstallLogMode=append
UsePreviousLanguage=no

[Tasks]

[Languages]
Name: en; MessagesFile: compiler:Default.isl

[Files]
; Add the ISSkin DLL used for skinning Inno Setup installations.

; Add the Visual Style resource contains resources used for skinning,
; you can also use Microsoft Visual Styles (*.msstyles) resources.

; NOTE: Don't use "Flags: ignoreversion" on any shared system files
Source: {#BINDIR}\ICSharpCode.SharpZipLib.dll; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\XmlRpc.dll; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\taglib-sharp.dll; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\OPMedia.Core.dll; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\OPMedia.Utility.exe; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\OPMedia.Runtime.dll; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\OPMedia.Runtime.ProTONE.dll; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\OPMedia.UI.dll; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\OPMedia.UI.ProTONE.dll; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\Resources\player.ico; DestDir: {app}\Resources; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\Resources\bookmark.ico; DestDir: {app}\Resources; Flags: promptifolder uninsremovereadonly replacesameversion uninsrestartdelete touch restartreplace
Source: {#BINDIR}\Resources\AudioFile.ico; DestDir: {app}\Resources; Flags: promptifolder uninsremovereadonly replacesameversion uninsrestartdelete touch restartreplace
Source: {#BINDIR}\Resources\VideoFile.ico; DestDir: {app}\Resources; Flags: promptifolder uninsremovereadonly replacesameversion uninsrestartdelete touch restartreplace
Source: {#BINDIR}\Resources\Playlist.ico; DestDir: {app}\Resources; Flags: promptifolder uninsremovereadonly replacesameversion uninsrestartdelete touch restartreplace
Source: {#BINDIR}\Resources\Subtitle.ico; DestDir: {app}\Resources\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace
Source: {#BINDIR}\ro\OPMedia.ProTONE.resources.dll; DestDir: {app}\ro\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\ro\OPMedia.UI.ProTONE.resources.dll; DestDir: {app}\ro\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\ro\OPMedia.UI.resources.dll; DestDir: {app}\ro\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\ro\OPMedia.Utility.resources.dll; DestDir: {app}\ro; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\de\OPMedia.ProTONE.resources.dll; DestDir: {app}\de\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\de\OPMedia.UI.ProTONE.resources.dll; DestDir: {app}\de\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\de\OPMedia.UI.resources.dll; DestDir: {app}\de\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\de\OPMedia.Utility.resources.dll; DestDir: {app}\de; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\fr\OPMedia.ProTONE.resources.dll; DestDir: {app}\fr\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\fr\OPMedia.UI.ProTONE.resources.dll; DestDir: {app}\fr\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\fr\OPMedia.UI.resources.dll; DestDir: {app}\fr\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\fr\OPMedia.Utility.resources.dll; DestDir: {app}\fr; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\OPMedia.Runtime.Addons.dll; DestDir: {app}; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace
Source: {#BINDIR}\Resources\catalog.ico; DestDir: {app}\Resources\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace
Source: {#BINDIR}\ro\OPMedia.Runtime.Addons.resources.dll; DestDir: {app}\ro\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace
Source: {#BINDIR}\de\OPMedia.Runtime.Addons.resources.dll; DestDir: {app}\de\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace
Source: {#BINDIR}\fr\OPMedia.Runtime.Addons.resources.dll; DestDir: {app}\fr\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace
Source: {#BINDIR}\IRSerDev.dll; DestDir: {app}; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace
Source: {#BINDIR}\IRSerDev.h; DestDir: {app}; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace
Source: {#BINDIR}\Templates\Catalog\Default Catalog; DestDir: {app}\Templates\Catalog; Flags: uninsrestartdelete promptifolder uninsremovereadonly touch replacesameversion restartreplace

[Icons]

[Types]
Name: default; Description: default; Flags: iscustom

[Components]

[Dirs]

Name: {app}\ro; Flags: uninsalwaysuninstall
Name: {app}\de; Flags: uninsalwaysuninstall
Name: {app}\fr; Flags: uninsalwaysuninstall
Name: {app}\Resources; Flags: uninsalwaysuninstall
Name: {app}\Templates
Name: {app}\Templates\Catalog

[Run]
;Filename: {app}\OPMedia.MediaLibrary.exe; Parameters: ConfigAddons {language}; WorkingDir: {app}; StatusMsg: {cm:cfgMediaLibrary}; Flags: hidewizard runascurrentuser; Components: itemPlayer\itemLibrary

[UninstallRun]

[Registry]
Root: HKLM; Subkey: {#REGENTRY}; ValueType: string; ValueName: InstallLanguageID; ValueData: {language}; Flags: uninsdeletevalue noerror createvalueifdoesntexist
Root: HKLM; Subkey: {#REGENTRY}; ValueType: string; ValueName: DownloadUriBase; ValueData: https://protone-suite.googlecode.com/svn/publish/1.10; Flags: noerror uninsdeletevalue createvalueifdoesntexist
Root: HKLM; Subkey: {#REGENTRY}; ValueType: string; ValueName: HelpUriBase; ValueData: http://protone-suite.googlecode.com/svn/wiki/ProTONE Suite - 1.10.x/; Flags: noerror uninsdeletevalue createvalueifdoesntexist
Root: HKLM; Subkey: {#REGENTRY}; ValueType: dword; ValueName: UseOnlineDocumentation; ValueData: 1; Flags: noerror uninsdeletevalue createvalueifdoesntexist
; Components: itemCodecs\itemFFDShow
