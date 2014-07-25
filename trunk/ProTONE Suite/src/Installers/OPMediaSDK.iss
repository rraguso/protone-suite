;------------------------------
; macrodefinitions
#define BINDIR "..\bin"
#define OUTDIR "..\..\..\..\publish\current"
#define EXTDIR "..\..\..\..\externals"
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

Source: {#BINDIR}\Themes\Themes.thm; DestDir: {app}\DLL\Themes

Source: {#BINDIR}\OPMedia.Core.dll; DestDir: {app}\DLL; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\OPMedia.Utility.exe; DestDir: {app}\DLL; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\OPMedia.Runtime.dll; DestDir: {app}\DLL; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\OPMedia.UI.dll; DestDir: {app}\DLL; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\ro\OPMedia.UI.resources.dll; DestDir: {app}\DLL\ro\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\ro\OPMedia.Utility.resources.dll; DestDir: {app}\DLL\ro; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\de\OPMedia.UI.resources.dll; DestDir: {app}\DLL\de\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\de\OPMedia.Utility.resources.dll; DestDir: {app}\DLL\de; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\fr\OPMedia.UI.resources.dll; DestDir: {app}\DLL\fr\; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\fr\OPMedia.Utility.resources.dll; DestDir: {app}\DLL\fr; Flags: replacesameversion uninsremovereadonly promptifolder uninsrestartdelete touch restartreplace
Source: {#BINDIR}\OPMedia.Runtime.Addons.dll; DestDir: {app}\DLL; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace
Source: {#BINDIR}\ro\OPMedia.Runtime.Addons.resources.dll; DestDir: {app}\DLL\ro\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace
Source: {#BINDIR}\de\OPMedia.Runtime.Addons.resources.dll; DestDir: {app}\DLL\de\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace
Source: {#BINDIR}\fr\OPMedia.Runtime.Addons.resources.dll; DestDir: {app}\DLL\fr\; Flags: uninsremovereadonly promptifolder uninsrestartdelete touch replacesameversion restartreplace

Source: {#EXTDIR}\TranslationEditor.exe; DestDir: {app}\Tools\TranslationEditor

Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddon\Navigation\AddonPanel.cs; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddon\Navigation
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddon\Navigation\AddonPanel.Designer.cs; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddon\Navigation
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddon\Navigation\AddonPanel.resx; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddon\Navigation
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddon\Navigation\SampleCfgPanel.cs; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddon\Navigation
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddon\Navigation\SampleCfgPanel.Designer.cs; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddon\Navigation
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddon\Navigation\SampleCfgPanel.resx; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddon\Navigation
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddon\Preview\AddonPanel.cs; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddon\Preview
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddon\Preview\AddonPanel.Designer.cs; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddon\Preview
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddon\Preview\AddonPanel.resx; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddon\Preview
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddon\Properties\AssemblyInfo.cs; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddon\Properties
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddon\Property\AddonPanel.cs; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddon\Property
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddon\Property\AddonPanel.Designer.cs; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddon\Property
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddon\Property\AddonPanel.resx; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddon\Property
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddon\Translations\Translation.Designer.cs; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddon\Translations
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddon\Translations\Translation.resx; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddon\Translations
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddon\SampleAddon.Builtin.csproj; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddon
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddonApplication\Properties\AssemblyInfo.cs; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddonApplication\Properties
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddonApplication\Properties\Resources.Designer.cs; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddonApplication\Properties
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddonApplication\Properties\Resources.resx; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddonApplication\Properties
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddonApplication\Translations\Translation.Designer.cs; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddonApplication\Translations
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddonApplication\Translations\Translation.resx; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddonApplication\Translations
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddonApplication\MainForm.cs; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddonApplication
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddonApplication\MainForm.Designer.cs; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddonApplication
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddonApplication\Program.cs; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddonApplication
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddonApplication\SampleAddonApplication.csproj; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddonApplication
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddonApplication.sln; DestDir: {app}\SDKSamples\SampleAddonApplication

Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddonApplication\DefaultAddons.SampleAddonApplication.config; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddonApplication
Source: ..\SDK\SDKSamples\SampleAddonApplication\SampleAddonApplication\Themes\Themes.thm; DestDir: {app}\SDKSamples\SampleAddonApplication\SampleAddonApplication\Themes

Source: {#BINDIR}\OPMedia.SkinBuilder.exe; DestDir: {app}\Tools\SkinBuilder
Source: {#BINDIR}\OPMedia.Core.dll; DestDir: {app}\Tools\SkinBuilder
Source: {#BINDIR}\OPMedia.Runtime.Addons.dll; DestDir: {app}\Tools\SkinBuilder
Source: {#BINDIR}\OPMedia.Runtime.dll; DestDir: {app}\Tools\SkinBuilder
Source: {#BINDIR}\OPMedia.UI.dll; DestDir: {app}\Tools\SkinBuilder
Source: {#BINDIR}\SkinBuilder.dll; DestDir: {app}\Tools\SkinBuilder
Source: {#BINDIR}\DefaultAddons.OPMedia.SkinBuilder.config; DestDir: {app}\Tools\SkinBuilder
Source: {#BINDIR}\Themes\Themes.thm; DestDir: {app}\Tools\SkinBuilder\Themes

[Icons]

[Types]
Name: default; Description: default; Flags: iscustom

[Components]

[Dirs]

Name: {app}\DLL\ro; Flags: uninsalwaysuninstall
Name: {app}\DLL\de; Flags: uninsalwaysuninstall
Name: {app}\DLL\fr; Flags: uninsalwaysuninstall
Name: {app}\DLL\Themes; Flags: uninsalwaysuninstall
Name: {app}\Tools
Name: {app}\Tools\SkinBuilder
Name: {app}\Tools\SkinBuilder\Themes
Name: {app}\SDKSamples

[Run]

[UninstallRun]

[Registry]
Root: HKLM; Subkey: {#REGENTRY}; ValueType: string; ValueName: InstallLanguageID; ValueData: {language}; Flags: uninsdeletevalue noerror createvalueifdoesntexist
Root: HKLM; Subkey: {#REGENTRY}; ValueType: string; ValueName: DownloadUriBase; ValueData: https://protone-suite.googlecode.com/svn/publish/1.10; Flags: noerror uninsdeletevalue createvalueifdoesntexist
Root: HKLM; Subkey: {#REGENTRY}; ValueType: string; ValueName: HelpUriBase; ValueData: http://protone-suite.googlecode.com/svn/wiki/ProTONE Suite - 1.10.x/; Flags: noerror uninsdeletevalue createvalueifdoesntexist
Root: HKLM; Subkey: {#REGENTRY}; ValueType: dword; ValueName: UseOnlineDocumentation; ValueData: 1; Flags: noerror uninsdeletevalue createvalueifdoesntexist
