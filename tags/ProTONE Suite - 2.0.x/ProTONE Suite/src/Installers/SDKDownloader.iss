;------------------------------
; macrodefinitions
#define BINDIR "..\bin"
#define OUTDIR "..\..\..\..\publish\current"


[Setup]
;------------------------------
AppID={{A181F52A-4B57-4E90-BEFA-8D9106C6C924}
;------------------------------
AppVersion=1
OutputBaseFilename=sdkdownloader
OutputDir={#OUTDIR}
AppName=OPMedia SDK Downloader

;------------------------------
AllowNoIcons=true
ChangesAssociations=true
ChangesEnvironment=true
Compression=lzma
DirExistsWarning=no
DisableWelcomePage=true
DisableFinishedPage=true
DisableReadyPage=true
DisableStartupPrompt=true
EnableDirDoesntExistWarning=false
LanguageDetectionMethod=none

; WinXP SP3 - miniumum OS required for .NET Framework 4.0
MinVersion=0,5.01.2600sp3

PrivilegesRequired=admin
SetupIconFile=Installer.ico
SetupLogging=false
ShowTasksTreeLines=false
SignedUninstaller=false
SolidCompression=true
UninstallLogMode=append
WizardImageBackColor=clBlack
WizardImageFile=..\main.bmp
WizardImageStretch=false
WizardSmallImageFile=..\main_small.bmp
DefaultDirName={tmp}
AllowUNCPath=false
AppendDefaultDirName=false
UsePreviousAppDir=false
CreateAppDir=false
DisableDirPage=true
Uninstallable=false
CreateUninstallRegKey=false
UpdateUninstallLogAppName=false
AlwaysShowComponentsList=false
ShowComponentSizes=false
FlatComponentsList=false
UsePreviousSetupType=false
UsePreviousTasks=false
ShowLanguageDialog=no
TerminalServicesAware=false
UsePreviousGroup=false
AppendDefaultGroupName=false

[Files]
; Add the ISSkin DLL used for skinning Inno Setup installations.
Source: ISSkin.dll; DestDir: {tmp}; Flags: dontcopy

; Add the Visual Style resource contains resources used for skinning,
; you can also use Microsoft Visual Styles (*.msstyles) resources.
Source: Skins\OPMedia.cjstyles; DestDir: {tmp}; Flags: dontcopy
Source: isxdl.dll; DestDir: {tmp}; Flags: dontcopy

[Code]
#include "Include\SDKDownloaderSetupCode.pas"
