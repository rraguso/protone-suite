;------------------------------
; macrodefinitions
#define BINDIR "..\bin"
#define OUTDIR "..\..\..\..\publish\1.10"
#define EXTDIR "..\..\externals"
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

[Files]
; Add the ISSkin DLL used for skinning Inno Setup installations.
Source: ISSkin.dll; DestDir: {app}; Flags: dontcopy

; Add the Visual Style resource contains resources used for skinning,
; you can also use Microsoft Visual Styles (*.msstyles) resources.
Source: Skins\OPMedia.cjstyles; DestDir: {tmp}; Flags: dontcopy

; NOTE: Don't use "Flags: ignoreversion" on any shared system files
Source: {#BINDIR}\lame_enc.dll; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
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

Source: {#BINDIR}\OPMedia.PersistenceService.exe; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\Persistence.sdf; DestDir: {app}; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace onlyifdoesntexist uninsneveruninstall

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

Source: {#BINDIR}\ro\OPMedia.Runtime.Addons.resources.dll; DestDir: {app}\ro\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: {#BINDIR}\de\OPMedia.Runtime.Addons.resources.dll; DestDir: {app}\de\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: {#BINDIR}\fr\OPMedia.Runtime.Addons.resources.dll; DestDir: {app}\fr\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary

Source: {#BINDIR}\OPMedia.RCCManager.exe; DestDir: {app}; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\IRSerDev.dll; DestDir: {app}; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\OPMedia.RCCService.exe; DestDir: {app}; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\OPMedia.ServiceHelper.RCCService.dll; DestDir: {app}; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\RCCService.Config; DestDir: {app}; Flags: uninsremovereadonly promptifolder touch uninsrestartdelete replacesameversion restartreplace onlyifdoesntexist uninsneveruninstall; Permissions: users-modify; Components: itemPlayer\itemRemote; Languages: 

Source: {#BINDIR}\Resources\ir_remote.ico; DestDir: {app}\Resources\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemRemote

Source: {#BINDIR}\ro\OPMedia.RCCManager.resources.dll; DestDir: {app}\ro\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\ro\OPMedia.ServiceHelper.RCCService.resources.dll; DestDir: {app}\ro\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\de\OPMedia.RCCManager.resources.dll; DestDir: {app}\de\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\de\OPMedia.ServiceHelper.RCCService.resources.dll; DestDir: {app}\de\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\fr\OPMedia.RCCManager.resources.dll; DestDir: {app}\fr\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace; Components: itemPlayer\itemRemote
Source: {#BINDIR}\fr\OPMedia.ServiceHelper.RCCService.resources.dll; DestDir: {app}\fr\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace; Components: itemPlayer\itemRemote

Source: isxdl.dll; DestDir: {tmp}; Flags: dontcopy

Source: {#BINDIR}\Templates\Catalog\Default Catalog; DestDir: {app}\Templates\Catalog; Flags: uninsrestartdelete promptifolder uninsremovereadonly touch replacesameversion restartreplace; Components: itemPlayer\itemLibrary
Source: {#BINDIR}\Templates\RemoteControl\ProTONEOnSerial.Config; DestDir: {app}\Templates\RemoteControl; Flags: uninsrestartdelete promptifolder uninsremovereadonly touch replacesameversion restartreplace; Components: itemPlayer\itemRemote

Source: {#EXTDIR}\OPMedia.MediaLibrary.Addons.config; DestDir: {localappdata}\OPMedia.MediaLibrary; Flags: confirmoverwrite onlyifdoesntexist; Permissions: users-modify; Components: itemPlayer\itemLibrary

Source: {#EXTDIR}\SQLCE\sqlceca35.dll; DestDir: {app}
Source: {#EXTDIR}\SQLCE\sqlcecompact35.dll; DestDir: {app}
Source: {#EXTDIR}\SQLCE\sqlceer35EN.dll; DestDir: {app}
Source: {#EXTDIR}\SQLCE\sqlceme35.dll; DestDir: {app}
Source: {#EXTDIR}\SQLCE\sqlceoledb35.dll; DestDir: {app}
Source: {#EXTDIR}\SQLCE\sqlceqp35.dll; DestDir: {app}
Source: {#EXTDIR}\SQLCE\sqlcese35.dll; DestDir: {app}
Source: {#EXTDIR}\SQLCE\System.Data.SqlServerCe.dll; DestDir: {app}
Source: {#EXTDIR}\ffdshow\Boost_Software_License_1.0.txt; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\ff_kernelDeint.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\ff_liba52.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\ff_libdts.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\ff_libfaad2.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\ff_libmad.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\ff_samplerate.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\ff_unrar.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\ff_wmv9.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\ffavisynth.avsi; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\ffavisynth.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\ffdshow.ax; DestDir: {app}\Codecs; Flags: regserver; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\ffmpeg.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\ffvdub.vdf; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\FLT_ffdshow.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\gnu_license.txt; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\IntelQuickSyncDecoder.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\libmpeg2_ff.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\makeAVIS.exe; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\openIE.js; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\ffdshow\TomsMoComp_ff.dll; DestDir: {app}\Codecs; Components: itemCodecs\itemFFDShow
Source: {#EXTDIR}\haali\avi.dll; DestDir: {app}\HDSupport; Flags: regserver; Components: "  itemCodecs\itemHaali"
Source: {#EXTDIR}\haali\avs.dll; DestDir: {app}\HDSupport; Flags: regserver; Components: "  itemCodecs\itemHaali"
Source: {#EXTDIR}\haali\avss.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: {#EXTDIR}\haali\cue2xml.js; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: {#EXTDIR}\haali\dsmux.exe; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: {#EXTDIR}\haali\dxr.dll; DestDir: {app}\HDSupport; Flags: regserver; Components: "  itemCodecs\itemHaali"
Source: {#EXTDIR}\haali\gdsmux.exe; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: {#EXTDIR}\haali\mkunicode.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: {#EXTDIR}\haali\mkv2vfr.exe; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: {#EXTDIR}\haali\mkx.dll; DestDir: {app}\HDSupport; Flags: regserver; Components: "  itemCodecs\itemHaali"
Source: {#EXTDIR}\haali\mkzlib.dll; DestDir: {app}\HDSupport; Components: "  itemCodecs\itemHaali"
Source: {#EXTDIR}\haali\mp4.dll; DestDir: {app}\HDSupport; Flags: regserver; Components: "  itemCodecs\itemHaali"
Source: {#EXTDIR}\haali\ogm.dll; DestDir: {app}\HDSupport; Flags: regserver; Components: "  itemCodecs\itemHaali"
Source: {#EXTDIR}\haali\splitter.ax; DestDir: {app}\HDSupport; Flags: regserver; Components: "  itemCodecs\itemHaali"; Languages: 
Source: {#EXTDIR}\haali\ts.dll; DestDir: {app}\HDSupport; Flags: regserver; Components: "  itemCodecs\itemHaali"

[Icons]
Name: {group}\{cm:UninstallProgram,ProTONE Suite}; Filename: {uninstallexe}; Components: " "
Name: {group}\{cm:namePlayer}; Filename: {app}\OPMedia.ProTONE.exe; WorkingDir: {app}; IconFilename: {app}\Resources\player.ico; Comment: {cm:startPlayer}; Components: " "
Name: {group}\{cm:nameLibrary}; Filename: {app}\OPMedia.MediaLibrary.exe; WorkingDir: {app}; IconFilename: {app}\Resources\catalog.ico; Comment: {cm:startLibrary}; Components: itemPlayer\itemLibrary
Name: {group}\{cm:nameRCCManager}; Filename: {app}\OPMedia.RCCManager.exe; WorkingDir: {app}; IconFilename: {app}\Resources\ir_remote.ico; Comment: {cm:startRCCManager}; Components: itemPlayer\itemRemote
Name: {group}\{cm:nameLogViewer}; Filename: {app}\OPMedia.Utility.exe; WorkingDir: {app}; Comment: {cm:startLogViewer}; IconFilename: {app}\OPMedia.LogViewer.exe; Components: " "
Name: {userdesktop}\{cm:namePlayer}; Filename: {app}\OPMedia.ProTONE.exe; WorkingDir: {app}; IconFilename: {app}\Resources\player.ico; Comment: {cm:startPlayer}; Components: " "
Name: {userdesktop}\{cm:nameLibrary}; Filename: {app}\OPMedia.MediaLibrary.exe; WorkingDir: {app}; IconFilename: {app}\Resources\catalog.ico; Comment: {cm:startLibrary}; Components: itemPlayer\itemLibrary
Name: {userappdata}\Microsoft\Internet Explorer\Quick Launch\{cm:namePlayer}; Filename: {app}\OPMedia.ProTONE.exe; WorkingDir: {app}; IconFilename: {app}\Resources\player.ico; Comment: {cm:startPlayer}; Components: " "
Name: {userappdata}\Microsoft\Internet Explorer\Quick Launch\{cm:nameLibrary}; Filename: {app}\OPMedia.MediaLibrary.exe; WorkingDir: {app}; IconFilename: {app}\Resources\catalog.ico; Comment: {cm:startLibrary}; Components: itemPlayer\itemLibrary

[Types]
Name: default; Description: default; Flags: iscustom; Languages: en de fr ro

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
Name: {app}\Resources; Flags: uninsalwaysuninstall
Name: {app}\Codecs; Flags: uninsalwaysuninstall; Components: itemCodecs\itemFFDShow
Name: {app}\HDSupport; Flags: uninsalwaysuninstall; Components: "  itemCodecs\itemHaali"
Name: {app}\Templates; Components: itemPlayer\itemRemote itemPlayer\itemLibrary
Name: {app}\Templates\Catalog; Languages: ; Components: itemPlayer\itemLibrary
Name: {app}\Templates\RemoteControl; Components: itemPlayer\itemRemote

[Run]
Filename: {dotnet4032}\installutil.exe; Parameters: "-i ""{app}\OPMedia.PersistenceService.exe"""; WorkingDir: {app}; StatusMsg: {cm:instRccService}; Flags: runhidden runascurrentuser
Filename: cmd.exe; Parameters: "/c ""sc start OPMedia.PersistenceService"""; WorkingDir: {app}; StatusMsg: {cm:startRccService}; Flags: runhidden runascurrentuser
Filename: {dotnet4032}\regasm.exe; Parameters: "/codebase ""{app}\OPMedia.ShellSupport.dll"""; WorkingDir: {app}; StatusMsg: {cm:cfgShellSupport}; Flags: runhidden runascurrentuser; Components: itemPlayer
Filename: {dotnet4064}\regasm.exe; Parameters: "/codebase ""{app}\OPMedia.ShellSupport.dll"""; WorkingDir: {app}; StatusMsg: {cm:cfgShellSupport}; Flags: runhidden runascurrentuser; Components: itemPlayer; Check: IsWin64
Filename: {dotnet4032}\installutil.exe; Parameters: "-i ""{app}\OPMedia.RCCService.exe"""; WorkingDir: {app}; StatusMsg: {cm:instRccService}; Flags: runhidden runascurrentuser; Components: itemPlayer\itemRemote
Filename: cmd.exe; Parameters: "/c ""sc start OPMedia.RCCService"""; WorkingDir: {app}; StatusMsg: {cm:startRccService}; Flags: runhidden runascurrentuser; Components: itemPlayer\itemRemote
Filename: {sys}\netsh.exe; Parameters: "firewall add allowedprogram ""{app}\OPMedia.ProTONE.exe"" ""ProTONE Player"" ENABLE ALL"; StatusMsg: {cm:firewallPlayer}; Flags: runhidden runascurrentuser; Components: itemPlayer
Filename: {sys}\netsh.exe; Parameters: "firewall add allowedprogram ""{app}\OPMedia.RCCService.exe"" ""OPMedia RCC Service"" ENABLE ALL"; StatusMsg: {cm:firewallRccService}; Flags: runhidden runascurrentuser; Components: itemPlayer\itemRemote
Filename: {sys}\netsh.exe; Parameters: "firewall add allowedprogram ""{app}\OPMedia.RCCManager.exe"" ""OPMedia RCC Manager"" ENABLE ALL"; StatusMsg: {cm:firewallRccManager}; Flags: runhidden runascurrentuser; Components: itemPlayer\itemRemote
;Filename: {app}\OPMedia.MediaLibrary.exe; Parameters: ConfigAddons {language}; WorkingDir: {app}; StatusMsg: {cm:cfgMediaLibrary}; Flags: hidewizard runascurrentuser; Components: itemPlayer\itemLibrary

[UninstallRun]
Filename: {app}\OPMedia.Utility.exe; WorkingDir: {app}; Flags: SkipIfDoesntExist; Parameters: {{9566B126-2205-4E61-8C1C-E6D4D0FC34F0}; RunOnceId: _id0
Filename: cmd.exe; Parameters: "/c ""sc stop OPMedia.RCCService"""; Flags: runhidden; WorkingDir: {app}; StatusMsg: {cm:stopRCCService}; RunOnceId: _id1.1; Components: itemPlayer\itemRemote
Filename: cmd.exe; Parameters: "/c ""sc delete OPMedia.RCCService"""; Flags: runhidden; WorkingDir: {app}; StatusMsg: {cm:uninstRCCService}; RunOnceId: _id2.1; Components: itemPlayer\itemRemote
Filename: {dotnet4032}\regasm.exe; Parameters: "/u ""{app}\OPMedia.ShellSupport.dll"""; WorkingDir: {app}; Flags: runhidden; StatusMsg: {cm:uninstShellSupport}; RunOnceId: _id3; Components: itemPlayer
Filename: {dotnet4064}\regasm.exe; Parameters: "/u ""{app}\OPMedia.ShellSupport.dll"""; WorkingDir: {app}; Flags: runhidden; StatusMsg: {cm:uninstShellSupport}; RunOnceId: _id3.1; Components: itemPlayer; Check: IsWin64
Filename: {sys}\netsh.exe; Parameters: "firewall delete allowedprogram program=""{app}\OPMedia.ProTONE.exe"""; StatusMsg: {cm:delFirewallPlayer}; Flags: runhidden; RunOnceId: _id4; Components: itemPlayer
Filename: {sys}\netsh.exe; Parameters: "firewall delete allowedprogram program=""{app}\OPMedia.RCCService.exe"""; StatusMsg: {cm:delFirewallRccService}; Flags: runhidden; RunOnceId: _id5; Components: itemPlayer\itemRemote
Filename: {sys}\netsh.exe; Parameters: "firewall delete allowedprogram program=""{app}\OPMedia.RCCManager.exe"""; StatusMsg: {cm:delFirewallRccManager}; Flags: runhidden; RunOnceId: _id6; Components: itemPlayer\itemRemote
Filename: cmd.exe; Parameters: "/c ""sc stop OPMedia.PersistenceService"""; Flags: runhidden; WorkingDir: {app}; StatusMsg: {cm:stopRCCService}; RunOnceId: _id7
Filename: cmd.exe; Parameters: "/c ""sc delete OPMedia.PersistenceService"""; Flags: runhidden; WorkingDir: {app}; StatusMsg: {cm:uninstRCCService}; RunOnceId: _id8

[Registry]
Root: HKLM; Subkey: {#REGENTRY}; ValueType: string; ValueName: InstallLanguageID; ValueData: {language}; Flags: uninsdeletevalue noerror
Root: HKLM; Subkey: {#REGENTRY}; ValueType: string; ValueName: DownloadUriBase; ValueData: https://protone-suite.googlecode.com/svn/publish/1.10; Flags: noerror uninsdeletevalue
Root: HKLM; Subkey: {#REGENTRY}; ValueType: string; ValueName: HelpUriBase; ValueData: http://protone-suite.googlecode.com/svn/wiki/ProTONE Suite - 1.10.x/; Flags: noerror uninsdeletevalue
Root: HKLM; Subkey: {#REGENTRY}; ValueType: dword; ValueName: UseOnlineDocumentation; ValueData: 1; Flags: noerror uninsdeletevalue
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: noDxvaDecoder; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: cscd; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: div3; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: duck; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dx50; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: ffv1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: flv1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: fvfw; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: h261; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: h263; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: h264; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: hfyu; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: iv32; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mjpg; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mp41; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mp42; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mp43; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mp4v; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mszh; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: png1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: qtrle; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: qtrpza; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: raw_rawv; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: rt21; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: svq1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: svq3; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: theo; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: vp3; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: vp5; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: vp6; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: vp6f; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: xvid; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: zlib; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: string; ValueName: dscalerPth; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: 8bps; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: aasc; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: asv1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: cram; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: cvid; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: cyuv; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dvsd; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: fps1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: loco; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mpegAVI; ValueData: $00000005; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mpg1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mpg2; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mss1; ValueData: $0000000c; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mss2; ValueData: $0000000c; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: qpeg; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: rawv; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: rle; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: tscc; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: ulti; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: vcr1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: vixl; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: wmv1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: wmv2; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: wmv3; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: wnv1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: wvc1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: wmvp; ValueData: $0000000c; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: wvp2; ValueData: $0000000c; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: zmbv; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow; ValueType: string; ValueName: pth; ValueData: C:\Windows\system32; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: postprocH264mode; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeMethod; ValueData: $00000009; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subIsExpand; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isSubtitles; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isOSD; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: threadsnum; ValueData: $00000004; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: needOutcspsFix; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: needGlobalFix; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoLoadLogic; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dropDelayTime; ValueData: $000005dc; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadScreenSize; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: errorConcealment; ValueData: $00000003; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadSize; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: h264skipOnDelay; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadScreenSizeXmin; ValueData: $00000010; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: h264skipDelayTime; ValueData: $0000015e; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadScreenSizeXmax; ValueData: $00001000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: useQueueOnlyIn; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadScreenSizeCond; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadScreenSizeYmin; ValueData: $00000010; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: queueCount; ValueData: $0000000a; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadScreenSizeYmax; ValueData: $00001000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadSizeXmin; ValueData: $00000010; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadSizeXmax; ValueData: $00000800; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadSizeCond; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isDyInterlaced; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadSizeYmin; ValueData: $00000010; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dyInterlaced; ValueData: $00000120; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadSizeYmax; ValueData: $00000800; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: workaroundBugs2; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: idct; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: softTelecine; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: videoDelay; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isVideoDelayEnd; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: videoDelayEnd; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: errorRecognition; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: grayscale; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: multiThread; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dontQueueInWMP; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: queueVMR9YV12; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dropOnDelay; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dec_DXVA_H264; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dec_DXVA_VC1; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dec_dxva_compatibilityMode; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dec_dxva_postProcessingMode; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: bordersBrightness; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: useQueueOnlyInList; ValueData: "mpc-hc.exe;mplayerc.exe;mpc-hc64.exe;mplayerc64.exe;"; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullCropNzoom; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showCropNzoom; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderCropNzoom; ValueData: $ffffffff; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: cropTolerance; ValueData: $0000001e; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isZoom; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: magnificationX; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: cropLeft; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: cropRefreshDelay; ValueData: $00001388; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: magnificationY; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: magnificationLocked; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isCropNzoom; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: cropRight; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: cropTop; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: cropBottom; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: panscanZoom; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: panscanX; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: panscanY; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: cropStopScan; ValueData: $000186a0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: swapFields; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showDeinterlace; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderDeinterlace; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isDeinterlace; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullDeinterlace; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: deinterlaceAlways; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: deinterlaceMethod; ValueData: $00000002; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: tomocompSE; ValueData: $00000003; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: tomocompVF; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: frameRateDoublerThreshold; ValueData: $000000ff; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: frameRateDoublerSE; ValueData: $00000003; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: kernelDeintThreshold; ValueData: $0000000a; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: kernelDeintSharp; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: kernelDeintTwoway; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: kernelDeintMap; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: kernelDeintLinked; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dgbobMode; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dgbobThreshold; ValueData: $0000000c; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dgbobAP; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: yadifMode; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: yadifParity; ValueData: $ffffffff; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: dscalerDIflnm; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: dscalerDIcfg; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: logoawayVhweight; ValueData: $00000005; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: logoawaySolidcolor; ValueData: $00ffffff; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: logoawayLumaOnly; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: logoawayPointsw; ValueData: $00000007; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isLogoaway; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showLogoaway; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderLogoaway; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullLogoaway; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: logoawayX; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: logoawayY; ValueData: $0000000a; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: logoawayDx; ValueData: $00000010; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: logoawayDy; ValueData: $00000010; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: logoawayMode; ValueData: $00000002; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: logoawayBlur; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: logoawayPointnw; ValueData: $00000005; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: logoawayPointne; ValueData: $00000006; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: logoawayPointse; ValueData: $00000008; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: logoawayBordn_mode; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: logoawayBorde_mode; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: logoawayBords_mode; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: logoawayBordw_mode; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: logoawayParambitmap; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isPostproc; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showPostproc; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderPostproc; ValueData: $00000002; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullPostproc; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: halfPostproc; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: postprocMethod; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: postprocMethodNicFirst; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: ppqual; ValueData: $00000006; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoq; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: ppIsCustom; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: ppcustom; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: deblockMplayerAccurate; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: deblockStrength; ValueData: $00000100; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelFixLum; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullYrange; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: postprocNicXthresh; ValueData: $00000014; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: postprocNicYthresh; ValueData: $00000028; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: postprocSPPmode; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: lumGain; ValueData: $00000080; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: lumOffset; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: hue; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: saturation; ValueData: $00000040; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isPictProp; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: gammaCorrection; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showPictProp; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderPictProp; ValueData: $00000003; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullPictProp; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: halfPictProp; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: gammaCorrectionR; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: gammaCorrectionG; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: gammaCorrectionB; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: colorizeStrength; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: colorizeColor; ValueData: $00ffffff; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: colorizeChromaonly; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: pictProcLevelFix; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: pictProcLevelFixFull; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: scanlineEffect; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isGradFun; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showGradFun; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderGradFun; ValueData: $00000004; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: gradFunThreshold; ValueData: $00000078; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: gradFunRadius; ValueData: $00000010; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsInMax; ValueData: $000000ff; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint4x; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsOutMin; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint8x; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint4y; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint8y; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint9x; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: YmaxDelta; ValueData: $00000014; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: Ythreshold; ValueData: $0000000a; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: Ytemporal; ValueData: $00000003; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isLevels; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showLevels; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderLevels; ValueData: $00000005; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullLevels; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: halfLevels; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsMode; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsGamma; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPosterize; ValueData: $000000ff; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsInMin; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsOutMax; ValueData: $000000ff; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsOnlyLuma; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsFullY; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsInAuto; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsNumPoints; ValueData: $00000002; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint0x; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint0y; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint1x; ValueData: $000000ff; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint1y; ValueData: $000000ff; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint2x; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint2y; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint3x; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint3y; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint5x; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint5y; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint6x; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint6y; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint7x; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint7y; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsPoint9y; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: transMirror; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isOffset; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderOffset; ValueData: $00000006; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: offsetY_X; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: offsetY_Y; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: offsetU_X; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: offsetU_Y; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: offsetV_X; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: offsetV_Y; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullOffset; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showOffset; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: halfOffset; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: transfFlip; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: blurIsAvcodecTNR; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: blurIsGradual; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: tempSmoothColor; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: blurIsAvcodecBLur; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: denoise3Dchroma; ValueData: $0000012c; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: blurStrength; ValueData: $0000001e; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: tempSmooth; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullBlur; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: blurIsSmoothChroma; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: smoothStrengthChroma; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: avcodecTNR2; ValueData: $000005dc; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: gradualStrength; ValueData: $00000028; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: avcodecTNR1; ValueData: $000002bc; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: denoise3Dtime; ValueData: $00000258; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: denoise3Dhq; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isBlur; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showBlur; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderBlur; ValueData: $00000007; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: halfBlur; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: blurIsSoften; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: blurIsTempSmooth; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: blurIsSmoothLuma; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: smoothStrengthLuma; ValueData: $0000012c; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: avcodecTNR3; ValueData: $00000bb8; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: avcodecBlurRadius; ValueData: $00000003; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: avcodecBlurLuma; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: avcodecBlurChroma; ValueData: $00000096; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isDenoise3d; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: denoise3Dluma; ValueData: $00000190; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: msharpStrength; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: msharpHQ; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: unsharp_strength; ValueData: $00000028; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: xsharpen; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: xsharp_strenght; ValueData: $00000014; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: xsharp_threshold; ValueData: $00000096; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: asharpT; ValueData: $000000c8; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showSharpen; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: halfSharpen; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: mplayerSharpLuma; ValueData: $00000032; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: mplayerSharpChroma; ValueData: $00000032; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: asharpD; ValueData: $00000190; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: asharpB; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: msharpThreshold; ValueData: $0000000f; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: unsharp_threshold; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: msharpMask; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderSharpen; ValueData: $00000008; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullSharpen; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: sharpenMethod; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: asharpHQBF; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: awarpsharpBM; ValueData: $00000002; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isWarpsharp; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderWarpsharp; ValueData: $00000009; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullWarpsharp; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: warpsharpMethod; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: awarpsharpDepth; ValueData: $00000640; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: awarpsharpThresh; ValueData: $00000032; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: awarpsharpBlur; ValueData: $00000002; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: awarpsharpCM; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showWarpsharp; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: halfWarpsharp; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: warpsharpDepth; ValueData: $00000028; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: warpsharpThreshold; ValueData: $00000080; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isDScaler; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showDScaler; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderDScaler; ValueData: $0000000a; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullDScaler; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: halfDScaler; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: dscalerFltflnm; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: dscalerCfg; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: noiseLinesA; ValueData: $0000000a; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isNoise; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showNoise; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderNoise; ValueData: $0000000b; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullNoise; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: halfNoise; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: noiseMethod; ValueData: $00000002; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: uniformNoise; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: noisePattern; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: noiseAveraged; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: noiseStrength; ValueData: $0000001e; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: noiseStrengthChroma; ValueData: $0000000a; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: noiseFlickerA; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: noiseFlickerF; ValueData: $00000032; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: noiseShakeA; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: noiseShakeF; ValueData: $00000008; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: noiseLinesF; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: noiseLinesC; ValueData: $0000007f; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: noiseLinesTransparency; ValueData: $0000007f; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: noiseScratchesA; ValueData: $00000032; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: noiseScratchesF; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: noiseScratchesC; ValueData: $0000007f; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: noiseScratchesTransparency; ValueData: $0000007f; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeA1; ValueData: $00000004; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeA2; ValueData: $00000003; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeGaussParam; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeLanczosParam; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeMode; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeAccurateRounding; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeIf; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeIfXcond; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeIfXval; ValueData: $00000280; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeIfYcond; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isResize; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showResize; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderResize; ValueData: $0000000c; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullResize; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeDx; ValueData: $00000280; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeIsDy0; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeDy; ValueData: $000001e0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeMulfOf; ValueData: $00000010; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeMult1000; ValueData: $000007d0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeSARinternally; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeOutDeviceA1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeOutDeviceA2; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeIfYval; ValueData: $000001e0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeIfXYcond; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeIfPixCond; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeIfPixVal; ValueData: $0004b000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: bordersInside; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: bordersUnits; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: bordersLocked; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: bordersX; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: bordersY; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: bordersPixelsX; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: bordersPixelsY; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: bordersDivX; ValueData: $00000032; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: bordersDivY; ValueData: $00000032; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeAscpect; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: aspectRatio; ValueData: $0001547a; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeMethodChroma; ValueData: $00000009; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeMethodsLocked; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeBicubicParam; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeBicubicChromaParam; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeGaussChromaParam; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeLanczosChromaParam; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeSimpleWarpXparam; ValueData: $0000047e; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeSimpleWarpYparam; ValueData: $000003b6; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeGblurLum; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeGblurChrom; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeSharpenLum; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeSharpenChrom; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: resizeInterlaced; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isPerspective; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: perspectiveIsSrc; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showPerspective; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: halfPerspective; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderPerspective; ValueData: $0000000d; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullPerspective; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: perspectiveX1; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: perspectiveY1; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: perspectiveX2; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: perspectiveY2; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: perspectiveX3; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: perspectiveY3; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: perspectiveX4; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: perspectiveY4; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: perspectiveInterpolation; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: avisynthBufferBack; ValueData: $0000000a; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: avisynthInYUY2; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: avisynthInRGB24; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: avisynthInRGB32; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: avisynthBufferAhead; ValueData: $0000000a; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isAvisynth; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderAvisynth; ValueData: $0000000e; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: avisynthInYV12; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullAvisynth; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: avisynthApplyPulldown; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: avisynthEnableBuffering; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showAvisynth; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: avisynthFfdshowSource; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: avisynthScriptMULTI_SZ; ValueData: hex(7):68,00,65,00,78,00,28,00,37,00,29,00,3a,00,30,00,30,00,2c,00,30,00,30,00,00,00,00,00; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: avisynthScript; ValueData: hex(7):00,00
; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isVis; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showVis; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderShowMV; ValueData: $0000000f; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: visMV; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: visQuants; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: visGraph; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dctMode; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dctQuant; ValueData: $00000005; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dctMatrix0; ValueData: $13121110; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dctMatrix1; ValueData: $17161514; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isDCT; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showDCT; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderDCT; ValueData: $00000010; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullDCT; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: halfDCT; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dct0; ValueData: $000003e8; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dct1; ValueData: $000003e8; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dct2; ValueData: $000003e8; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dct3; ValueData: $000003e8; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dct4; ValueData: $000003e8; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dct5; ValueData: $000003e8; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dct6; ValueData: $000001f4; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dct7; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dctMatrix2; ValueData: $14131211; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dctMatrix3; ValueData: $18171615; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dctMatrix4; ValueData: $15141312; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dctMatrix5; ValueData: $19181716; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dctMatrix6; ValueData: $16151413; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dctMatrix7; ValueData: $1b1a1817; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dctMatrix8; ValueData: $17161514; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dctMatrix9; ValueData: $1c1b1a19; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dctMatrix10; ValueData: $18171615; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dctMatrix11; ValueData: $1e1c1b1a; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dctMatrix12; ValueData: $1a181716; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dctMatrix13; ValueData: $1f1e1c1b; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dctMatrix14; ValueData: $1b191817; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dctMatrix15; ValueData: $211f1e1c; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: bitmapStrength; ValueData: $00000080; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: bitmapMode; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: bitmapPosX; ValueData: $00000032; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: bitmapPosY; ValueData: $00000032; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderBitmap; ValueData: $00000011; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: bitmapAlign; ValueData: $00000002; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isBitmap; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showBitmap; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullBitmap; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: bitmapPosMode; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: bitmapFlnm; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subSSAOverridePlacement; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subSSAMaintainInside; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subExtendedTags; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subSSAUseMovieDimensions; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subVobsubChangePosition; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subMinDurationChar; ValueData: $0000001e; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subPGS; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subFiles; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subText; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subAlign; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subIsMinDuration; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subVobsubAAswgauss; ValueData: $000002bc; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subSplitBorder; ValueData: $00000014; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subSpeed2; ValueData: $000003e8; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderSubtitles; ValueData: $00000012; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subAutoFlnm; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subFix; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showSubtitles; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullSubtitles; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subPosX; ValueData: $00000032; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subPosY; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subExpand; ValueData: $00100009; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subDelay; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subSpeed; ValueData: $000003e8; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subStereoscopic; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subStereoscopicPar; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subDefLang; ValueData: $00004f52; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subDefLang2; ValueData: $00004e45; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subVobsub; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subVobsubAA; ValueData: $00000004; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subImgScale; ValueData: $00000100; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subLinespacing; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subMinDurationType; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subMinDurationSubtitle; ValueData: $00000bb8; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subMinDurationLine; ValueData: $000005dc; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subWordWrap; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subFixLang; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subOpacity; ValueData: $00000100; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subCC; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: subSSA; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: subFlnm; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: subFixDict; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontShadowOverride; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontOutlineWidthOverride; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontSizeOverride; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontSettingsOverride; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontColorOverride; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontCharset; ValueData: $000000ee; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontAutosize; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontAutosizeVideoWindow; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontBodyAlpha; ValueData: $00000100; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontSize; ValueData: $0000001a; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontSizeA; ValueData: $0000001f; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontWeight; ValueData: $000002bc; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontColor; ValueData: $00ccffcc; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontSplitting; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontOutlineColor; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontXscale; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontShadowColor; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontOutlineWidth; ValueData: $00000002; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontOpaqueBox; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontItalic; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontUnderline; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontSpacing; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontYscale; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontAspectAuto; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontOutlineAlpha; ValueData: $00000100; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontShadowAlpha; ValueData: $00000080; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontShadowSize; ValueData: $00000005; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontShadowMode; ValueData: $00000002; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontBlurMode; ValueData: $00000003; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontBlur; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: scaleBorderAndShadowOverride; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: fontName; ValueData: Arial; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isGrab; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderGrab; ValueData: $00000013; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fullGrab; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: grabDigits; ValueData: $00000005; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: grabFormat; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: grabMode; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: grabFrameNum; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: grabFrameNum1; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: grabFrameNum2; ValueData: $0000006e; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: grabQual; ValueData: $00000050; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showGrab; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: grabStep; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: grabPath; ValueData: c:\; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: grabPrefix; ValueData: grab; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDdurationVisible; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDisSave; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: orderOSD; ValueData: $00000014; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: showOSD; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDisAutoHide; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDsaveOnly; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDposX; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDposY; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDuserFormat; ValueData: $00000003; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: OSDformat; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: OSDsaveFlnm; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontCharset; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontSize; ValueData: $00000011; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontWeight; ValueData: $00000190; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontOutlineWidth; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontOutlineColor; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontShadowColor; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontOpaqueBox; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontColor; ValueData: $0000dc6e; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontItalic; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontUnderline; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontSpacing; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontXscale; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontYscale; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontAspectAuto; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontBodyAlpha; ValueData: $00000100; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontOutlineAlpha; ValueData: $00000100; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontShadowAlpha; ValueData: $00000080; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontShadowSize; ValueData: $00000008; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontShadowMode; ValueData: $00000003; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontBlurMode; ValueData: $00000003; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: OSDfontBlur; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: OSDfontName; ValueData: Arial; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: flip; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: hwOverlayAspect; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: setDeintInOutSample; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: hwDeintMethod; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: hwDeintFieldOrder; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: outYV12; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: outYUY2; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: outUYVY; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: outNV12; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: outRGB32; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: outDV; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: outDVnorm; ValueData: $00000002; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: highQualityRGB; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: dithering; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: cspOptionsIturBt2; ValueData: $00000003; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: cspOptionsInputLevelsMode; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: cspOptionsOutputLevelsMode; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: cspOptionsBlackCutoff; ValueData: $00000010; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: cspOptionsWhiteCutoff; ValueData: $000000eb; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: cspOptionsChromaCutoff; ValueData: $00000010; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: cspOptionsRgbInterlaceMode; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: isOverlayControl; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: overlayBrightness; ValueData: $ffffffff; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: overlayContrast; ValueData: $ffffffff; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: overlayHue; ValueData: $ffffff42; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: overlaySaturation; ValueData: $ffffffff; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: overlaySharpness; ValueData: $ffffffff; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: overlayGamma; ValueData: $ffffffff; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: overlayColorEnable; ValueData: $ffffffff; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadExtsNeedFix; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadFlnm; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadExt; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: autoloadExts; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadExe; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: autoloadExes; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadVolumeName; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: autoloadVolumeNames; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadVolumeSerial; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: autoloadVolumeSerials; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadDecoder; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: autoloadDecoders; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadDSfilter; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: autoloadDSfilters; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadFOURCC; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: autoloadFOURCCs; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadPreviousFOURCC; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: autoloadPreviousFOURCCs; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadSAR; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: autoloadSARs; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadDAR; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: autoloadDARs; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: autoloadFrameRate; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: string; ValueName: autoloadFrameRatess; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: qsEnableFullRateDI; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: qsEnableTimeStampCorrection; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: qsEnableMT; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: qsFieldOrder; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: qsEnableSwEmulation; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: qsForceFieldOrder; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: qsEnableDvdDecode; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: qsEnableDeinterlacing; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: qsForceDeinterlacing; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: qsDetailStrength; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: qsDenoiseStrength; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: sppqual; ValueData: $00000003; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: levelsForceRGB; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontHqBorder; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: fontMemory; ValueData: $00000014; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: outPrimaryCsp; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: outRGB24; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: outP016; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: outP010; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: outP210; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: outP216; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: outAYUV; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow\default; ValueType: dword; ValueName: outY416; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: fastH264; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: subTextpin; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: subTextpinSSA; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: isBlacklist; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: isWhitelist; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: cscd; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: div3; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: duck; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dx50; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: ffv1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: flv1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: fvfw; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: h261; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: h263; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: h264; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: hfyu; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: iv32; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mjpg; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mp41; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mp42; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mp43; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mp4v; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mszh; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: png1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: qtrle; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: qtrpza; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: raw_rawv; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: rt21; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: svq1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: svq3; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: theo; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: vp3; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: vp5; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: vp6; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: vp6f; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: xvid; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: zlib; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: string; ValueName: lang; ValueData: en; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: allowedCPUflags; ValueData: $00001eff; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: isCompMgr; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: 8bps; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: aasc; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: asv1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: cram; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: cvid; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: cyuv; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dvsd; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: fps1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: loco; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mpegAVI; ValueData: $00000005; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mpg1; ValueData: $00000005; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mpg2; ValueData: $00000005; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mss1; ValueData: $0000000c; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: mss2; ValueData: $0000000c; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: qpeg; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: rawv; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: rle; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: tscc; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: ulti; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: vcr1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: vixl; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: wmv1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: wmv2; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: wmv3; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: wnv1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: wvc1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: wmvp; ValueData: $0000000c; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: wvp2; ValueData: $0000000c; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: zmbv; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: multipleInstances; ValueData: $00000002; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: addToROT; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: streamsOptionsMenu; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: autoPresets; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: trayIcon; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: autoPresetFileFirst; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: trayIconExt; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: outputdebug; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: outputdebugfile; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: errorbox1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: streamsSubFilesMode; ValueData: $00000003; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: buildHistogram; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: supDVDdec; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: fastMpeg2; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: alternateUncompressed; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: string; ValueName: debugfile; ValueData: \ffdebug.log; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: string; ValueName: activePreset; ValueData: default; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: subEmbeddedPriority; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: subSearchHeuristic; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: subWatch; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: string; ValueName: subSearchExt; ValueData: "utf;idx;sub;srt;smi;rt;txt;ass;ssa;aqt;mpl;usf;sup"; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: string; ValueName: subSearchDir; ValueData: .; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: vp8; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: cavs; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: em2v; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: avrn; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: cdvc; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: iv50; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: i263; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: rv10; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: rv30; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: rv40; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: avis; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: needCodecFix; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: keyboard; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: keysAlways; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: showKeysMessages; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: keysSeek1; ValueData: $0000000f; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: keysSeek2; ValueData: $0000003c; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Activation key 1; ValueData: $00000011; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Activation key 2; ValueData: $00000012; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Second function; ValueData: $00000010; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Seek forward; ValueData: $00000027; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Seek backward; ValueData: $00000025; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Toggle OSD; ValueData: $0000004f; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Toggle visualizations; ValueData: $00000056; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Toggle crop/zoom; ValueData: $00000043; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Toggle deinterlace; ValueData: $00000044; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Toggle levels; ValueData: $0000004c; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Toggle noise; ValueData: $0000004e; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Toggle picture properties; ValueData: $00000049; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Toggle postprocessing; ValueData: $00000050; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Toggle blur; ValueData: $00000042; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Toggle resize; ValueData: $00000052; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Toggle sharpen; ValueData: $00000048; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Toggle flip; ValueData: $00000046; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Toggle avisynth; ValueData: $00000041; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Toggle warpsharp; ValueData: $00000057; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Grab frame; ValueData: $00000047; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Subtitles delay/size decrease; ValueData: $0000006d; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Subtitles delay/size increase; ValueData: $0000006b; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Subtitles position decrease; ValueData: $00000021; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Subtitles position increase; ValueData: $00000022; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Decrease video delay; ValueData: $000000bc; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Increase video delay; ValueData: $000000be; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Previous preset; ValueData: $000000db; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Next preset; ValueData: $000000dd; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Fast forward; ValueData: $00000026; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Rewind; ValueData: $00000028; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Next subtitles file; ValueData: $00000053; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Next subtitles stream; ValueData: $00000073; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: key Next audio stream; ValueData: $00000061; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: isRemote; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: remoteMessageMode; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: remoteMessageUser; ValueData: $00008012; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: remoteAcceptKeys; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: lastPage; ValueData: $0000008f; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgPosX; ValueData: $000002ac; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: lvCodecsSelected; ValueData: $00000013; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgRestorePos; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgPosY; ValueData: $00000177; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: showHints; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: lvCodecsWidth0; ValueData: $0000005a; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: lvCodecsWidth1; ValueData: $0000004c; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: lvCodecsWidth2; ValueData: $000000ca; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: lvWidth0; ValueData: $0000012c; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: lvKeysWidth0; ValueData: $000000f0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: lvKeysWidth1; ValueData: $0000005a; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgDecCurrentPage; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgCustColor0; ValueData: $00ccffcc; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgCustColor1; ValueData: $00101010; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgCustColor2; ValueData: $00202020; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgCustColor3; ValueData: $00303030; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgCustColor4; ValueData: $00404040; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgCustColor5; ValueData: $00505050; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgCustColor6; ValueData: $00606060; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgCustColor7; ValueData: $00707070; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgCustColor8; ValueData: $00808080; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgCustColor9; ValueData: $00909090; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgCustColor10; ValueData: $00a0a0a0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgCustColor11; ValueData: $00b0b0b0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgCustColor12; ValueData: $00c0c0c0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgCustColor13; ValueData: $00d0d0d0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgCustColor14; ValueData: $00e0e0e0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: dlgCustColor15; ValueData: $00ffffff; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: translateMode; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: trayIconType; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: allowDPRINTF; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow; ValueType: dword; ValueName: iv41; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerNormalizeMatrix; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volNormalize; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: ismixer; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerOut; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: passthroughAC3; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: passthroughDTS; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: decoderDRC; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: isOSD; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: autoLoadLogic; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: autoloadScreenSize; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: autoloadScreenSizeXmin; ValueData: $00000010; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: dithering; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: preferredsfs; ValueData: $0000000f; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: autoloadScreenSizeXmax; ValueData: $00001000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: autoloadScreenSizeCond; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: autoloadScreenSizeYmin; ValueData: $00000010; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: autoloadScreenSizeYmax; ValueData: $00001000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: noiseShaping; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: decoderDRCLevel; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: decoderJitterCorrection; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: decoderAudioDelay; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: orderDolbyDecoder; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: isDolbyDecoder; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: showDolbyDecoder; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: dolbyDecoderDelay; ValueData: $00000014; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: isVolume; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: showVolume; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: orderVolume; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volume; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volumeL; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volumeC; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volNormalizeResetOnSeek; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volumeR; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volumeSL; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volNormalizeRegainVolume; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volumeSR; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volumeAL; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volumeAR; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volumeLFE; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volumeLmute; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volumeCmute; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volumeRmute; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volumeSLmute; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volumeSRmute; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volumeALmute; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volumeARmute; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volumeLFEmute; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: volNormalizeMax; ValueData: $0000018e; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq5; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: isEQ; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: orderEQ; ValueData: $00000002; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq0; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq1; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq0freq; ValueData: $00000c35; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq5freq; ValueData: $000186a0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq8freq; ValueData: $000c3500; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq9freq; ValueData: $00186a00; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eqSuper; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: showEQ; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq2; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq3; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq4; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq6; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq7; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq8; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq9; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eqLowdb; ValueData: $fffffb50; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eqHighdb; ValueData: $000004b0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq1freq; ValueData: $0000186a; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq2freq; ValueData: $000030d4; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq3freq; ValueData: $000061a8; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq4freq; ValueData: $0000c350; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq6freq; ValueData: $00030d40; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: eq7freq; ValueData: $00061a80; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: isFIR; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: showFIR; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: orderFIR; ValueData: $00000003; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: firTaps; ValueData: $00000020; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: firType; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: firFreq; ValueData: $00001770; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: firWidth; ValueData: $000003e8; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: firWindow; ValueData: $00000004; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: firKaiserBeta; ValueData: $000003e8; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: convolverLevelAdjustAuto; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: isConvolver; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: showConvolver; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: orderConvolver; ValueData: $00000004; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: convolverMappingMode; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: convolverMixingStrength; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: convolverLevelAdjustDB; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: convolverFile; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: convolverFileSL; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: convolverFileL; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: convolverFileR; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: convolverFileC; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: convolverFileLFE; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: convolverFileSR; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: isAudioDenoise; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: showAudioDenoise; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: orderAudioDenoise; ValueData: $00000005; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: audioDenoiseThreshold; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: isWinamp2; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: showWinamp2; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: orderWinamp2; ValueData: $00000006; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: winamp32bit; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: winamp2filtername; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: winamp2flnm; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: allowMultichannelOnlyIn; ValueData: dsp_dfx.dll; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: isFreeverb; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: showFreeverb; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: orderFreeverb; ValueData: $00000007; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: freeverbRoomsize; ValueData: $000001f4; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: freeverbDamp; ValueData: $000000fa; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: freeverbWet; ValueData: $0000014d; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: freeverbDry; ValueData: $000002ee; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: freeverbWidth; ValueData: $000003e8; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: freeverbMode; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: isCrystality; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: showCrystality; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: orderCrystality; ValueData: $00000008; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: bext_level; ValueData: $0000001c; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: echo_level; ValueData: $0000000b; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: stereo_level; ValueData: $0000000b; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: filter_level; ValueData: $00000003; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: feedback_level; ValueData: $0000001e; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: harmonics_level; ValueData: $0000002b; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: resampleIfFreq; ValueData: $0000ac44; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: isResample; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: showResample; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: orderResample; ValueData: $00000009; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: resampleFreq; ValueData: $0000ac44; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: resampleMode; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: resampleIf; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: resampleIfCond; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: delayAL; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: delayAR; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: delayBC; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: isDelay; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: showDelay; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: orderDelay; ValueData: $0000000a; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: delayL; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: delayC; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: delayR; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: delaySL; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: delaySR; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: delayLFE; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: isLFEcrossover; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: showLFEcrossover; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: orderLFEcrossover; ValueData: $0000000b; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: LFEcrossoverFreq; ValueData: $000000b4; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: LFEcrossoverGain; ValueData: $ffffff38; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: IDFF_LFEcutLR; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: channelSwapAL; ValueData: $00000200; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: channelSwapAR; ValueData: $00000400; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: isChannelSwap; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: showChannelSwap; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: orderChannelSwap; ValueData: $0000000c; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: channelSwapL; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: channelSwapR; ValueData: $00000002; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: channelSwapC; ValueData: $00000004; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: channelSwapSL; ValueData: $00000010; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: channelSwapSR; ValueData: $00000020; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: channelSwapRear; ValueData: $00000100; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: channelSwapLFE; ValueData: $00000008; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix22; ValueData: $000186a0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix80; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix21; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix46; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix25; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix47; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix23; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix24; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix10; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix00; ValueData: $000186a0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix08; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix48; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix60; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix65; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix63; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix64; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix66; ValueData: $000186a0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix67; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix70; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix71; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix75; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix73; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix74; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix76; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix77; ValueData: $000186a0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix62; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix88; ValueData: $000186a0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix78; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix81; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix85; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix83; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix84; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix86; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix87; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix28; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix18; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix58; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix38; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix68; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: showMixer; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: orderMixer; ValueData: $0000000d; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerExpandStereo2; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerVoiceControl2; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerCustomMatrix; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix02; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix01; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix05; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix03; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix04; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix06; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix07; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix20; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix26; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix27; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix12; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix11; ValueData: $000186a0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix15; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix13; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix14; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix16; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix17; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix50; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix52; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix51; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix55; ValueData: $000186a0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix53; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix54; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix56; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix57; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix30; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix32; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix31; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix35; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix33; ValueData: $000186a0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix34; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix36; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix37; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix40; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix42; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix41; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix45; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix43; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix44; ValueData: $000186a0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix61; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix72; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerMatrix82; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerClev; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerSlev; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: mixerLFElev; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: headphone_dim; ValueData: $0000000a; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: orderOSD; ValueData: $0000000e; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: showOSD; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: OSDisAutoHide; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: OSDdurationVisible; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: OSDisSave; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: OSDsaveOnly; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: OSDformat; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: OSDsaveFlnm; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: connectTo; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: connectToOnlySpdif; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: passthroughDTSHD; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: passthroughEAC3; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: useIEC61937; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: passthroughPCMConnection; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: outsfs; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: outAC3bitrate; ValueData: $00000280; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: outAC3EncodeMode; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: passthroughTRUEHD; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: passthroughDeviceId; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: autoloadExtsNeedFix; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: autoloadFlnm; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: autoloadExt; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: autoloadExts; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: autoloadExe; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: autoloadExes; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: autoloadVolumeName; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: autoloadVolumeNames; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: autoloadVolumeSerial; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: autoloadVolumeSerials; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: autoloadDecoder; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: autoloadDecoders; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: autoloadDSfilter; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: autoloadDSfilters; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: autoloadNchannel; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: autoloadNchannels; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: dword; ValueName: autoloadFreq; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio\default; ValueType: string; ValueName: autoloadFreqs; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: isBlacklist; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: isWhitelist; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: aac; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: ac3; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: amr; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: dts; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: eac3; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: flac; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: lpcm; ValueData: $00000004; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: mace; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: truehd; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: mlp; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: mp2; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: mp3; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: qdm2; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: tta; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: vorbis; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: lastPage; ValueData: $09b000bf; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: dlgPosX; ValueData: $000002ac; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: lvCodecsSelected; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: dlgRestorePos; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: dlgPosY; ValueData: $00000177; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: showHints; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: lvCodecsWidth0; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: lvCodecsWidth1; ValueData: $00000064; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: lvCodecsWidth2; ValueData: $000000a8; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: lvWidth0; ValueData: $0000012c; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: lvKeysWidth0; ValueData: $000000f0; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: lvConvolverWidth2; ValueData: $0000012c; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: lvKeysWidth1; ValueData: $0000005a; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: lvConvolverSelected; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: dlgDecCurrentPage; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: lvConvolverWidth0; ValueData: $00000046; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: lvConvolverWidth1; ValueData: $000000c8; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: dlgVolumeDb; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: translateMode; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: multipleInstances; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: isAudioSwitcher; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: addToROT; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: streamsOptionsMenu; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: trayIcon; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: autoPresetFileFirst; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: trayIconExt; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: outputdebug; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: outputdebugfile; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: errorbox1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: streamsSubFilesMode; ValueData: $00000003; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: isCompMgr; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: autoPresets; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: showCurrentVolume; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: showCurrentFFT; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: firIsUserDisplayMaxFreq; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: firUserDisplayMaxFreq; ValueData: $0000bb80; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: alwaysextensible; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: allowOutStream; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: dtsinwav; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: string; ValueName: debugfile; ValueData: \ffdebug.log; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: string; ValueName: activePreset; ValueData: default; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: string; ValueName: winamp2dir; ValueData: ; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: wma1; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: wma2; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: iadpcm; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: msadpcm; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: otherAdpcm; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: law; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: gsm; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: truespeech; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: ra; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: imc; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: atrac3; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: cook; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: nellymoser; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: wavpack; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: qtpcm; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: avis; ValueData: $00000000; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: rawa; ValueData: $00000004; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: isSpkCfg; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: aac; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: ac3; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: amr; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: dts; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: eac3; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: flac; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: lpcm; ValueData: $00000004; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: mace; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: mlp; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: mp2; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: mp3; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: qdm2; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: tta; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: vorbis; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: gsm; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: iadpcm; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: law; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: msadpcm; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: otherAdpcm; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: rawa; ValueData: $00000004; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_audio; ValueType: dword; ValueName: truespeech; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_vfw; ValueType: dword; ValueName: ffv1; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_vfw; ValueType: dword; ValueName: fvfw; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_vfw; ValueType: dword; ValueName: h264; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_vfw; ValueType: dword; ValueName: mp41; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_vfw; ValueType: dword; ValueName: mp42; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_vfw; ValueType: dword; ValueName: mp43; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_vfw; ValueType: dword; ValueName: div3; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_vfw; ValueType: dword; ValueName: dx50; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_vfw; ValueType: dword; ValueName: xvid; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKLM; SubKey: Software\GNU\ffdshow_vfw; ValueType: dword; ValueName: mp4v; ValueData: $00000001; Components: itemCodecs\itemFFDShow
Root: HKCU; SubKey: Software\OPMedia Research\ProTONE Suite; ValueType: dword; ValueName: UseLinkedFiles; ValueData: $00000001
Root: HKCU; SubKey: Software\OPMedia Research\ProTONE Suite; ValueType: string; ValueName: LinkedFiles; ValueData: "AU;AIF;AIFF;CDA;FLAC;MID;MIDI;MP1;MP2;MP3;MPA;RAW;RMI;SND;WAV;WMA/BMK\AVI;DIVX;QT;M1V;M2V;MOD;MOV;MPG;MPEG;VOB;WM;WMV;MKV;MP4/SUB;SRT;USF;ASS;SSA;BMK"

[UninstallDelete]
Name: {app}\InstallUtil.InstallLog; Type: files
Name: {app}\OPMedia.RCCService.InstallLog; Type: files
Name: {app}\OPMedia.RCCService.InstallState; Type: files
Name: {app}\OPMedia.PersistenceService.InstallLog; Type: files
Name: {app}\OPMedia.PersistenceService.InstallState; Type: files

[CustomMessages]
#include "Include\CustomMessages.iss"

[Code]
#include "Include\SetupCode.pas"
