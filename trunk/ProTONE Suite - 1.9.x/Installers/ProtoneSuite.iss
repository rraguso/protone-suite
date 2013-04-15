;------------------------------
; macrodefinitions
#define BINDIR "..\bin"
#define OUTDIR "..\_builds"
#define EXTDIR "..\externals"
#define VERSION GetStringFileInfo(BINDIR + "\OPMedia.Core.dll", FILE_VERSION)
#define COMPANY GetStringFileInfo(BINDIR + "\OPMedia.Core.dll", COMPANY_NAME)
#define PRODUCT GetStringFileInfo(BINDIR + "\OPMedia.Core.dll", PRODUCT_NAME)
#define REGENTRY "Software" + "\" + COMPANY + "\" + PRODUCT

#expr WriteIni(OUTDIR + "\Versions.txt", PRODUCT, "Version", VERSION)


[Setup]
;------------------------------
AppID={{9566B126-2205-4E61-8C1C-E6D4D0FC34F0}
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

PrivilegesRequired=admin
SetupIconFile=Installer.ico
SetupLogging=true
ShowLanguageDialog=yes
ShowTasksTreeLines=true
SignedUninstaller=false
SolidCompression=true
UninstallLogMode=append
UsePreviousLanguage=no
WizardImageBackColor=clBlack
WizardImageFile=..\main.bmp
WizardImageStretch=false
WizardSmallImageFile=..\main_small.bmp

[Tasks]

[Languages]
Name: en; MessagesFile: compiler:Default.isl
Name: de; MessagesFile: compiler:Languages\German.isl
Name: fr; MessagesFile: compiler:Languages\French.isl
Name: ro; MessagesFile: compiler:Languages\Romanian.isl
Name: ru; MessagesFile: compiler:Languages\Russian.isl
Name: hu; MessagesFile: compiler:Languages\Hungarian.isl

[Files]
; Add the ISSkin DLL used for skinning Inno Setup installations.
Source: ISSkinU.dll; DestDir: {app}; Flags: dontcopy

; Add the Visual Style resource contains resources used for skinning,
; you can also use Microsoft Visual Styles (*.msstyles) resources.
Source: Skins\OPMedia.cjstyles; DestDir: {tmp}; Flags: dontcopy

; NOTE: Don't use "Flags: ignoreversion" on any shared system files
Source: {#BINDIR}\ICSharpCode.SharpZipLib.dll; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\XmlRpc.dll; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\taglib-sharp.dll; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\OPMedia.Core.dll; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\OPMedia.ProTONE.exe; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\OPMedia.Utility.exe; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\OPMedia.Runtime.dll; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\OPMedia.Runtime.ProTONE.dll; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\OPMedia.ShellSupport.dll; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace; StrongAssemblyName: OPMedia.ShellSupport.dll
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
Source: {#BINDIR}\ro\OPMedia.ShellSupport.resources.dll; DestDir: {app}\ro\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\ro\OPMedia.Utility.resources.dll; DestDir: {app}\ro; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace

Source: {#BINDIR}\de\OPMedia.ProTONE.resources.dll; DestDir: {app}\de\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\de\OPMedia.UI.ProTONE.resources.dll; DestDir: {app}\de\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\de\OPMedia.UI.resources.dll; DestDir: {app}\de\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\de\OPMedia.ShellSupport.resources.dll; DestDir: {app}\de\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\de\OPMedia.Utility.resources.dll; DestDir: {app}\de; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace

Source: {#BINDIR}\fr\OPMedia.ProTONE.resources.dll; DestDir: {app}\fr\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\fr\OPMedia.UI.ProTONE.resources.dll; DestDir: {app}\fr\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\fr\OPMedia.UI.resources.dll; DestDir: {app}\fr\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\fr\OPMedia.ShellSupport.resources.dll; DestDir: {app}\fr\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\fr\OPMedia.Utility.resources.dll; DestDir: {app}\fr; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace

Source: {#BINDIR}\ru\OPMedia.ProTONE.resources.dll; DestDir: {app}\ru\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\ru\OPMedia.UI.ProTONE.resources.dll; DestDir: {app}\ru\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\ru\OPMedia.UI.resources.dll; DestDir: {app}\ru\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\ru\OPMedia.ShellSupport.resources.dll; DestDir: {app}\ru\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\ru\OPMedia.Utility.resources.dll; DestDir: {app}\ru; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace

Source: {#BINDIR}\hu\OPMedia.ProTONE.resources.dll; DestDir: {app}\hu\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\hu\OPMedia.UI.ProTONE.resources.dll; DestDir: {app}\hu\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\hu\OPMedia.UI.resources.dll; DestDir: {app}\hu\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\hu\OPMedia.ShellSupport.resources.dll; DestDir: {app}\hu\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\hu\OPMedia.Utility.resources.dll; DestDir: {app}\hu; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace

Source: {#BINDIR}\OPMedia.Addons.Builtin.dll; DestDir: {app}; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: {#BINDIR}\OPMedia.MediaLibrary.exe; DestDir: {app}; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: {#BINDIR}\OPMedia.Runtime.Addons.dll; DestDir: {app}; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary

Source: {#BINDIR}\Resources\catalog.ico; DestDir: {app}\Resources\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary

Source: {#BINDIR}\ro\OPMedia.Addons.Builtin.resources.dll; DestDir: {app}\ro\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: {#BINDIR}\ro\OPMedia.MediaLibrary.resources.dll; DestDir: {app}\ro\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: {#BINDIR}\de\OPMedia.Addons.Builtin.resources.dll; DestDir: {app}\de\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: {#BINDIR}\de\OPMedia.MediaLibrary.resources.dll; DestDir: {app}\de\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: {#BINDIR}\fr\OPMedia.Addons.Builtin.resources.dll; DestDir: {app}\fr\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: {#BINDIR}\fr\OPMedia.MediaLibrary.resources.dll; DestDir: {app}\fr\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: {#BINDIR}\ru\OPMedia.Addons.Builtin.resources.dll; DestDir: {app}\ru\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: {#BINDIR}\ru\OPMedia.MediaLibrary.resources.dll; DestDir: {app}\ru\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: {#BINDIR}\hu\OPMedia.Addons.Builtin.resources.dll; DestDir: {app}\hu\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: {#BINDIR}\hu\OPMedia.MediaLibrary.resources.dll; DestDir: {app}\hu\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary

Source: {#BINDIR}\ro\OPMedia.Runtime.Addons.resources.dll; DestDir: {app}\ro\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: {#BINDIR}\de\OPMedia.Runtime.Addons.resources.dll; DestDir: {app}\de\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: {#BINDIR}\fr\OPMedia.Runtime.Addons.resources.dll; DestDir: {app}\fr\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: {#BINDIR}\ru\OPMedia.Runtime.Addons.resources.dll; DestDir: {app}\ru\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: {#BINDIR}\hu\OPMedia.Runtime.Addons.resources.dll; DestDir: {app}\hu\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary

Source: {#BINDIR}\OPMedia.RCCManager.exe; DestDir: {app}; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\IRSerDev.dll; DestDir: {app}; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\OPMedia.RCCService.exe; DestDir: {app}; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\OPMedia.ServiceHelper.RCCService.dll; DestDir: {app}; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\RCCService.Config; DestDir: {app}; Flags: uninsremovereadonly promptifolder touch uninsrestartdelete replacesameversion restartreplace; Permissions: users-modify; Components: itemPlayer\itemRemote

Source: {#BINDIR}\Resources\ir_remote.ico; DestDir: {app}\Resources\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemRemote

Source: {#BINDIR}\ro\OPMedia.RCCManager.resources.dll; DestDir: {app}\ro\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\ro\OPMedia.ServiceHelper.RCCService.resources.dll; DestDir: {app}\ro\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\de\OPMedia.RCCManager.resources.dll; DestDir: {app}\de\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\de\OPMedia.ServiceHelper.RCCService.resources.dll; DestDir: {app}\de\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\fr\OPMedia.RCCManager.resources.dll; DestDir: {app}\fr\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\fr\OPMedia.ServiceHelper.RCCService.resources.dll; DestDir: {app}\fr\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\ru\OPMedia.RCCManager.resources.dll; DestDir: {app}\ru\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\ru\OPMedia.ServiceHelper.RCCService.resources.dll; DestDir: {app}\ru\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\hu\OPMedia.RCCManager.resources.dll; DestDir: {app}\hu\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\hu\OPMedia.ServiceHelper.RCCService.resources.dll; DestDir: {app}\hu\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemRemote

Source: isxdl.dll; DestDir: {tmp}; Flags: dontcopy
Source: ..\Externals\ffdshow\ff_kernelDeint.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: ..\Externals\ffdshow\ff_liba52.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: ..\Externals\ffdshow\ff_libdts.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: ..\Externals\ffdshow\ff_libfaad2.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: ..\Externals\ffdshow\ff_libmad.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: ..\Externals\ffdshow\ff_samplerate.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: ..\Externals\ffdshow\ff_unrar.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: ..\Externals\ffdshow\ff_wmv9.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: ..\Externals\ffdshow\ffdshow.ax; DestDir: {app}\Codecs; Flags: regserver; Components: itemCodecs\itemFFDShow
Source: ..\Externals\ffdshow\ffdshow.reg; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: ..\Externals\ffdshow\ffmpeg.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: ..\Externals\ffdshow\IntelQuickSyncDecoder.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: ..\Externals\ffdshow\libmpeg2_ff.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: ..\Externals\ffdshow\TomsMoComp_ff.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: ..\Externals\haali\avi.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\avi.x64.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\avs.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\avss.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\dsmux.exe; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\dsmux.x64.exe; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\dxr.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\dxr.x64.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\gdsmux.exe; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\gdsmux.x64.exe; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\mkunicode.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\mkunicode.x64.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\mkv2vfr.exe; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\mkv2vfr.x64.exe; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\mkx.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\mkx.x64.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\mkzlib.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\mkzlib.x64.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\mp4.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\mp4.x64.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\ogm.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\ogm.x64.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\splitter.ax; DestDir: {app}\HDSupport; Flags: regserver; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\ts.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: ..\Externals\haali\ts.x64.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"

Source: ..\bin\Templates\Catalog\Default Catalog; DestDir: {app}\Templates\Catalog; Flags: uninsrestartdelete promptifolder uninsremovereadonly touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: ..\bin\Templates\RemoteControl\ProTONEOnSerial.Config; DestDir: {app}\Templates\RemoteControl; Flags: uninsrestartdelete promptifolder uninsremovereadonly touch replacesameversion restartreplace; Components: itemPlayer\itemRemote

[Icons]
Name: {group}\{cm:UninstallProgram,ProTONE Suite}; Filename: {uninstallexe}
Name: {group}\{cm:namePlayer}; Filename: {app}\OPMedia.ProTONE.exe; WorkingDir: {app}; IconFilename: {app}\Resources\player.ico; Comment: {cm:startPlayer}
Name: {group}\{cm:nameLibrary}; Filename: {app}\OPMedia.MediaLibrary.exe; WorkingDir: {app}; IconFilename: {app}\Resources\catalog.ico; Comment: {cm:startLibrary}
Name: {group}\{cm:nameRCCManager}; Filename: {app}\OPMedia.RCCManager.exe; WorkingDir: {app}; IconFilename: {app}\Resources\ir_remote.ico; Comment: {cm:startRCCManager}
Name: {group}\{cm:nameLogViewer}; Filename: {app}\OPMedia.Utility.exe; WorkingDir: {app}; Comment: {cm:startLogViewer}; IconFilename: {app}\OPMedia.LogViewer.exe
Name: {userdesktop}\{cm:namePlayer}; Filename: {app}\OPMedia.ProTONE.exe; WorkingDir: {app}; IconFilename: {app}\Resources\player.ico; Comment: {cm:startPlayer}
Name: {userdesktop}\{cm:nameLibrary}; Filename: {app}\OPMedia.MediaLibrary.exe; WorkingDir: {app}; IconFilename: {app}\Resources\catalog.ico; Comment: {cm:startLibrary}
Name: {userappdata}\Microsoft\Internet Explorer\Quick Launch\{cm:namePlayer}; Filename: {app}\OPMedia.ProTONE.exe; WorkingDir: {app}; IconFilename: {app}\Resources\player.ico; Comment: {cm:startPlayer}
Name: {userappdata}\Microsoft\Internet Explorer\Quick Launch\{cm:nameLibrary}; Filename: {app}\OPMedia.MediaLibrary.exe; WorkingDir: {app}; IconFilename: {app}\Resources\catalog.ico; Comment: {cm:startLibrary}

[Types]
Name: default; Description: default; Flags: iscustom; Languages: en de fr ro ru hu

[Components]
Name: itemPlayer; Description: {cm:itemPlayer}; Flags: fixed checkablealone; Types: default
Name: itemPlayer\itemLibrary; Description: {cm:itemLibrary}; Flags: dontinheritcheck; Types: default
Name: itemPlayer\itemRemote; Description: {cm:itemRemote}; Flags: dontinheritcheck; Types: default
Name: itemCodecs; Description: {cm:itemCodecs}; Flags: fixed checkablealone; Types: default; Check: CodecsAreMissing
Name: itemCodecs\itemFFDShow; Description: {cm:itemFfdShow}; Flags: checkablealone; Check: FFDShowIsMissing; Types: default
Name: itemCodecs\itemHaali; Description: {cm:itemHDSupport}; Flags: checkablealone; Check: HaaliIsMissing; Types: default

[Dirs]

Name: {app}\ro; Flags: uninsalwaysuninstall
Name: {app}\de; Flags: uninsalwaysuninstall
Name: {app}\fr; Flags: uninsalwaysuninstall
Name: {app}\ru; Flags: uninsalwaysuninstall
Name: {app}\hu; Flags: uninsalwaysuninstall
Name: {app}\Resources; Flags: uninsalwaysuninstall
Name: {app}\Codecs; Flags: uninsalwaysuninstall
Name: {app}\HDSupport; Flags: uninsalwaysuninstall
Name: {app}\Templates; Components: itemPlayer\itemRemote itemPlayer\itemLibrary
Name: {app}\Templates\Catalog; Languages: ; Components: itemPlayer\itemLibrary
Name: {app}\Templates\RemoteControl; Components: itemPlayer\itemRemote

[Run]
Filename: regedit.exe; WorkingDir: {app}; StatusMsg: {cm:cfgFfdShow}; Flags: runhidden runasoriginaluser; Parameters: "/s ""{app}\ffdshow\ffdshow.reg"""; Components: itemCodecs\itemFFDShow
Filename: {dotnet40}\regasm.exe; Parameters: "/codebase ""{app}\OPMedia.ShellSupport.dll"""; WorkingDir: {app}; StatusMsg: {cm:cfgShellSupport}; Flags: runhidden runasoriginaluser; Components: itemPlayer
Filename: {dotnet40}\installutil.exe; Parameters: "-i ""{app}\OPMedia.RCCService.exe"""; WorkingDir: {app}; StatusMsg: {cm:instRccService}; Flags: runhidden runasoriginaluser; Components: itemPlayer\itemRemote
Filename: cmd.exe; Parameters: "/c ""sc start OPMedia.RCCService"""; WorkingDir: {app}; StatusMsg: {cm:startRccService}; Flags: runhidden runasoriginaluser; Components: itemPlayer\itemRemote
Filename: {sys}\netsh.exe; Parameters: "firewall add allowedprogram ""{app}\OPMedia.ProTONE.exe"" ""ProTONE Player"" ENABLE ALL"; StatusMsg: {cm:firewallPlayer}; Flags: runhidden runasoriginaluser; Components: itemPlayer
Filename: {sys}\netsh.exe; Parameters: "firewall add allowedprogram ""{app}\OPMedia.RCCService.exe"" ""OPMedia RCC Service"" ENABLE ALL"; StatusMsg: {cm:firewallRccService}; Flags: runhidden runasoriginaluser; Components: itemPlayer\itemRemote
Filename: {sys}\netsh.exe; Parameters: "firewall add allowedprogram ""{app}\OPMedia.RCCManager.exe"" ""OPMedia RCC Manager"" ENABLE ALL"; StatusMsg: {cm:firewallRccManager}; Flags: runhidden runasoriginaluser; Components: itemPlayer\itemRemote
Filename: {app}\OPMedia.MediaLibrary.exe; Parameters: ConfigAddons {language}; WorkingDir: {app}; StatusMsg: {cm:cfgMediaLibrary}; Flags: hidewizard runascurrentuser; Components: itemPlayer\itemLibrary

[UninstallRun]
Filename: {app}\OPMedia.Utility.exe; WorkingDir: {app}; Flags: SkipIfDoesntExist; Parameters: {{9566B126-2205-4E61-8C1C-E6D4D0FC34F0}; RunOnceId: _id0
Filename: cmd.exe; Parameters: "/c ""sc stop OPMedia.RCCService"""; Flags: runhidden; WorkingDir: {app}; StatusMsg: {cm:stopRCCService}; RunOnceId: _id1; Components: itemPlayer\itemRemote
Filename: cmd.exe; Parameters: "/c ""sc delete OPMedia.RCCService"""; Flags: runhidden; WorkingDir: {app}; StatusMsg: {cm:uninstRCCService}; RunOnceId: _id2; Components: itemPlayer\itemRemote
Filename: {dotnet20}\regasm.exe; Parameters: "/u ""{app}\OPMedia.ShellSupport.dll"""; WorkingDir: {app}; Flags: runhidden; StatusMsg: {cm:uninstShellSupport}; RunOnceId: _id3; Components: itemPlayer
Filename: {sys}\netsh.exe; Parameters: "firewall delete allowedprogram program=""{app}\OPMedia.ProTONE.exe"""; StatusMsg: {cm:delFirewallPlayer}; Flags: runhidden; RunOnceId: _id4; Components: itemPlayer
Filename: {sys}\netsh.exe; Parameters: "firewall delete allowedprogram program=""{app}\OPMedia.RCCService.exe"""; StatusMsg: {cm:delFirewallRccService}; Flags: runhidden; RunOnceId: _id5; Components: itemPlayer\itemRemote
Filename: {sys}\netsh.exe; Parameters: "firewall delete allowedprogram program=""{app}\OPMedia.RCCManager.exe"""; StatusMsg: {cm:delFirewallRccManager}; Flags: runhidden; RunOnceId: _id6; Components: itemPlayer\itemRemote

[Registry]
Root: HKLM; Subkey: {#REGENTRY}; ValueType: string; ValueName: InstallLanguageID; ValueData: {language}; Flags: uninsdeletevalue noerror
Root: HKLM; Subkey: {#REGENTRY}; ValueType: string; ValueName: DownloadUriBase; ValueData: http://opmedia.3x.ro/downloads/; Flags: noerror uninsdeletevalue

[UninstallDelete]
Name: {app}\InstallUtil.InstallLog; Type: files
Name: {app}\OPMedia.RCCService.InstallLog; Type: files
Name: {app}\OPMedia.RCCService.InstallState; Type: files

[CustomMessages]
#include "Include\CustomMessages.iss"

[Code]
#include "Include\SetupCode.pas"
