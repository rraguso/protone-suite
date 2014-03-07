; *** Inno Setup version 5.1.0+ Romanian messages (with diacrytics) ***
;
; Romanian translation:
; Perde Marius
; contact: emarius89@gmail.com
;
;
; $jrsoftware: issrc/Files/Default.isl,v 1.58 2004/04/07 20:17:13 jr Exp $

[LangOptions]
LanguageName=Românã
LanguageID=$0418
LanguageCodePage=0
; If the language you are translating to requires special font faces or
; sizes, uncomment any of the following entries and change them accordingly.
DialogFontName=
DialogFontSize=8
WelcomeFontName=Verdana
WelcomeFontSize=12
TitleFontName=Arial
TitleFontSize=29
CopyrightFontName=Arial
CopyrightFontSize=8
[Messages]

; *** Application titles
SetupAppTitle=Instalare
SetupWindowTitle=Instalare - %1
UninstallAppTitle=Dezinstalare
UninstallAppFullTitle=Dezinstalare %1

; *** Misc. common
InformationTitle=Info
ConfirmTitle=Confirmare
ErrorTitle=Eroare

; *** SetupLdr messages
SetupLdrStartupMessage=Acesta este programul de instalare al %1. Doriti sã continuati ?
LdrCannotCreateTemp=Nu pot crea fisierele temporare. Instalarea se va incheia aici
LdrCannotExecTemp=Nu pot executa fisierul din directorul temporar. Instalarea se va incheia aici

; *** Startup error messages
LastErrorMessage=%1.%n%nEroare %2: %3
SetupFileMissing=Fisierul %1 lipseste din directorul de instalare. Vã rugãm corectati problema sau obtineti o nouã copie a programului.
SetupFileCorrupt=Fisierele de instalare a programului sunt corupte. Vã rugam obtineti o altã copie a programului.
SetupFileCorruptOrWrongVer=Fisierele de instalare sunt corupte sau sunt incompatibile cu aceastã versiune a programului de instalare. Vã rugãm corectati problema sau obtineti o nouã copie a programului.
NotOnThisPlatform=Acest program nu ruleazã sub %1.
OnlyOnThisPlatform=Acest program trebuie sã ruleze sub %1.
OnlyOnTheseArchitectures=Acest program poate fi instalat doar pe versiuni de Windows proiectate pentru urmãtoarele arhitecturi de procesoare:%n%n%1
MissingWOW64APIs=Versiunea de Windows care ruleazã nu include functiile necesare programului pentru instalarea pe 64 de biti. Pentru a corecta aceastã problemã, vã rugãm sã instalati Service Pack %1.
WinVersionTooLowError=Acest program necesitã %1 versiunea %2 sau ulterioarã.
WinVersionTooHighError=Acest program nu poate fi instalat sub %1 versiunea %2 sau ulterioarã.
AdminPrivilegesRequired=Trebuie sã aveti drepturi de Administrator pentru a instala acest program.
PowerUserPrivilegesRequired=Trebuie sã aveti drepturi de Administrator sau Power User pentru a instala acest program.
SetupAppRunningError=S-a detectat cã programul %1 ruleazã.%n%nVã rugãm închideti toate instantele, apoi apãsati OK pentru a continua sau Anuleazã pentru a pãrãsi programul de instalare.
UninstallAppRunningError=S-a detectat cã programul %1 ruleazã.%n%nVã rugãm închideti toate instantele, apoi apãsati OK pentru a continua sau Anuleazã pentru a pãrãsi programul de instalare.

; *** Misc. errors
ErrorCreatingDir=Nu pot crea directorul "%1"
ErrorTooManyFilesInDir=Nu pot crea un fisier în directorul "%1" deoarece acesta contine prea multe fisiere

; *** Setup common messages
ExitSetupTitle=Instalare
ExitSetupMessage=Procesul de instalare nu s-a încheiat. Dacã pãrãsiti programul acum, aplicatia nu se va instala.%n%nPuteti rula ulterior programul de instalare pentru a finaliza procesul.%n%nParasiti instalarea ?
AboutSetupMenuItem=&Despre Setup...
AboutSetupTitle=Despre Setup
AboutSetupMessage=%1 versiunea %2%n%3%n%n%1 pe Internet:%n%4
AboutSetupNote=

; *** Buttons
TranslatorNote=Romanian translation:%nPerde Marius
ButtonBack=< &Înapoi
ButtonNext=&Continuã >
ButtonInstall=&Instaleazã
ButtonOK=OK
ButtonCancel=Anuleazã
ButtonYes=&Da
ButtonYesToAll=Da tot &timpul
ButtonNo=&Nu
ButtonNoToAll=N&u tot timpul
ButtonFinish=&Finalizare
ButtonBrowse=&Selecteazã...
ButtonWizardBrowse=&Selecteazã...
ButtonNewFolder=Creeazã un director &nou

; *** "Select Language" dialog messages
SelectLanguageTitle=Selectare limbã
SelectLanguageLabel=Selectati limba pe care doriti sã o utilizati în timpul instalãrii:

; *** Common wizard text
ClickNext=Apãsati Continuã pentru pasul urmãtor sau Anuleazã pentru a pãrãsi programul.
BeveledLabel=
BrowseDialogTitle=Selectare director
BrowseDialogLabel=Selecteazã un director din lista de mai jos, apoi apasã OK.
NewFolderName=New Folder

; *** "Welcome" wizard page
WelcomeLabel1=Bine ati venit în programul de instalare al [name].
WelcomeLabel2=Acesta va instala [name/ver] pe sistemul dumneavoastrã.%n%nEste recomandat sã închideti toate celelalte aplicatii care ruleazã în acest moment, înainte de a continua.

; *** "Password" wizard page
WizardPassword=Protectie
PasswordLabel1=Aceastã instalare este protejatã de o parola.
PasswordLabel3=Vã rugãm introduceti parola, apoi apãsati Continuã. Parola este case-sensitive.
PasswordEditLabel=&Parola:
IncorrectPassword=Parola introdusã este incorectã. Mai încercati o datã.

; *** "License Agreement" wizard page
WizardLicense=Acceptul licentei de utilizare
LicenseLabel=Vã rugãm sã cititi urmãtoarele informatii înainte de a continua.
LicenseLabel3=Vã rugãm sã cititi urmãtoarea Licentã. Este necesar sã acceptati termenii acestei licente pentru a putea continua instalarea.
LicenseAccepted=&Accept termenii licentei
LicenseNotAccepted=&Nu accept termenii licentei

; *** "Information" wizard pages
WizardInfoBefore=Informatii
InfoBeforeLabel=Vã rugãm sã cititi aceste informatii suplimentare înainte de a continua.
InfoBeforeClickLabel=Când sunteti gata sã continuati instalarea, apãsati Continuã.
WizardInfoAfter=Informatii
InfoAfterLabel=Vã rugãm sã cititi aceste informatii suplimentare înainte de a continua.
InfoAfterClickLabel=Când sunteti gata sã continuati instalarea, apãsati Continuã.

; *** "User Information" wizard page
WizardUserInfo=Informatii despre utilizator
UserInfoDesc=Vã rugãm introduceti informatiile despre utilizator.
UserInfoName=Nume &utilizator:
UserInfoOrg=&Organizatie:
UserInfoSerial=Numãr &serial:
UserInfoNameRequired=Trebuie sã introduceti numele.

; *** "Select Destination Directory" wizard page
WizardSelectDir=Selectati directorul destinatie
SelectDirDesc=Unde doriti sã instalati [name]?
SelectDirLabel3=Selectati directorul în care doriti sã instalati [name], apoi apãsati Continuã.
SelectDirBrowseLabel=Pentru a continua, apãsati Continuã. Dacã doriti sã selectati un alt director, apãsati Selecteazã.
DiskSpaceMBLabel=Acest program necesitã cel putin [mb] Mb pe disc.
ToUNCPathname=Programul nu poate fi instalat pe o cale de retea. Dacã doriti instalarea pe o cale de retea, trebuie sã mapati calea la acea unitate de retea.
InvalidPath=Trebuie introdusã calea completã, incluzând litera unitãtii.%n%nExemplu:%nC:\APP%n%nsau calea de retea de forma:%n\\server\share
InvalidDrive=Unitatea selectatã nu existã sau nu este accesibilã. Vã rugãm selectati o altã unitate.
DiskSpaceWarningTitle=Nu existã spatiu suficient pe disc
DiskSpaceWarning=Programul de instalare necesitã un spatiu minim de %1 KB, dar unitatea selectatã are disponibil doar %2 KB.%n%nDoriti sã continuati ?
DirNameTooLong=Numele directorului sau calea este prea lungã.
InvalidDirName=Numele directorului nu este valid.
BadDirName32=Numele directorului nu poate contine nici unul din urmatoarele caractere: :%n%n%1
DirExistsTitle=Director existent
DirExists=Directorul:%n%n%1%n%ndeja existã. Doriti sã instalati în acest director ?
DirDoesntExistTitle=Director inexistent
DirDoesntExist=Directorul%n%n%1%n%nnu existã. Doriti sã fie creat ?

; *** "Select Components" wizard page
WizardSelectComponents=Selectare componente
SelectComponentsDesc=Care componente ar trebui instalate ?
SelectComponentsLabel2=Selectati componentele care doriti sã fie instalate; deselectati componentele pe care nu doriti sã le instalati. Apãsati Continuã când sunteti gata sã continuati instalarea.
FullInstallation=Instalare completã
; if possible don't translate 'Compact' as 'Minimal' (I mean 'Minimal' in your language)
CompactInstallation=Instalare compactã
CustomInstallation=Instalare personalizatã
NoUninstallWarningTitle=Componenta existã
NoUninstallWarning=S-a detectat cã urmatoarele componente sunt deja instalate în sistem:%n%n%1%n%nDeselectarea acestor componente nu va duce la dezinstalarea lor din sistem.%n%nDoriti sã continuati ?
ComponentSize1=%1 KB
ComponentSize2=%1 MB
ComponentsDiskSpaceMBLabel=Selectia curentã necesitã cel putin [mb] MB.

; *** "Select Additional Tasks" wizard page
WizardSelectTasks=Optiuni suplimentare
SelectTasksDesc=Care optiuni suplimentare doriti?
SelectTasksLabel2=Selectati optiunile suplimentare dorite pentru instalarea [name], apoi apãsati Continuã.

; *** "Select Start Menu Folder" wizard page
WizardSelectProgramGroup=Selectati directorul din meniul Start
SelectStartMenuFolderDesc=Unde doriti sã adaug link-urile cãtre aplicatie?
SelectStartMenuFolderLabel3=Programul de instalare va crea link-urile cãtre program în urmãtorul director din meniul Start.
SelectStartMenuFolderBrowseLabel=Pentru a continua, apãsati Continuã. Dacã doriti sã selectati un alt director, apãsati Selecteazã.
MustEnterGroupName=Trebuie sã introduceti numele unui director.
GroupNameTooLong=Numele directorului sau calea este prea lungã.
InvalidGroupName=Numele directorului nu este valid.
BadGroupName=Numele directorului nu poate contine nici unul din urmãtoarele caractere:%n%n%1
NoProgramGroupCheck2=Nu crea &director în meniul Start

; *** "Ready to Install" wizard page
WizardReady=Gata de instalare
ReadyLabel1=Programul este în punctul de a începe instalarea [name] pe acest sistem.
ReadyLabel2a=Apãsati Instaleazã pentru a continua, sau Înapoi dacã doriti sã revedeti sau sã modificati setãrile fãcute anterior.
ReadyLabel2b=Apãsati Instaleazã pentru a continua.
ReadyMemoUserInfo=Informatii utilizator:
ReadyMemoDir=Director destinatie:
ReadyMemoType=Tipul instalãrii:
ReadyMemoComponents=Componente selectate:
ReadyMemoGroup=Director în meniu Start:
ReadyMemoTasks=Optiuni suplimentare:

; *** "Preparing to Install" wizard page
WizardPreparing=Pregãtire instalare
PreparingDesc=Programul de instalare pregãteste instalarea [name].
PreviousInstallNotCompleted=Instalarea / dezinstalarea versiunii anterioare a programului nu este completã. Trebuie sã restartati sistemul pentru a termina instalarea anterioarã.%n%nDupã restart, rulati încã o data programul de instalare al [name].
CannotContinue=Programul de instalare nu poate continua. Apãsati Anuleazã pentru a pãrãsi instalarea.

; *** "Installing" wizard page
WizardInstalling=Instalare
InstallingLabel=Vã rugãm asteptati pânã când instalarea [name] ia sfarsit.

; *** "Setup Completed" wizard page
FinishedHeadingLabel=Finalizare instalare [name]
FinishedLabelNoIcons=Programul a terminat instalarea [name].
FinishedLabel=Programul a terminat instalarea [name]. Aplicatia poate fi lansatã utilizând link-urile create.
ClickFinish=Apãsati Finalizare pentru a pãrãsi programul de instalare.
FinishedRestartLabel=Pentru a completa instalarea [name], sistemul dvs. trebuie restartat. Doriti sã restartati acum?
FinishedRestartMessage=Pentru a completa instalarea [name], sistemul dvs. trebuie restartat. %n%nDoriti sã restartati acum?
ShowReadmeCheck=Da, doresc sã citesc fisierul README
YesRadio=&Da, doresc restartarea sistemului acum
NoRadio=&Nu, voi restarta mai tarziu
; used for example as 'Run MyProg.exe'
RunEntryExec=Ruleazã %1
; used for example as 'View Readme.txt'
RunEntryShellExec=Citeste %1

; *** "Setup Needs the Next Disk" stuff
ChangeDiskTitle=Urmãtorul disc
SelectDiskLabel2=Vã rugãm introduceti Discul %1 si apãsati OK.%n%nDacã fisierele de pe acest disc se aflã într-un alt director decât cel afisat mai jos, introduceti calea corectã sau apãsati Selecteazã.
PathLabel=&Cale:
FileNotInDir2=Fisierul "%1" nu poate fi gãsit în "%2". Vã rugãm introduceti discul corect sau selectati un alt director.
SelectDirectoryLabel=Vã rugãm specificati locatia urmãtorului disc.

; *** Installation phase messages
SetupAborted=Programul de instalare nu s-a încheiat cu succes.%n%nVã rugãm corectati problema si porniti instalarea din nou.
EntryAbortRetryIgnore=Apãsati 'Retry' pentru a încerca încã o datã, 'Ignore' pentru a trece oricum de acest pas sau 'Abort' pentru a opri instalarea.

; *** Installation status messages
StatusCreateDirs=Creare directoare ...
StatusExtractFiles=Extragere fisiere ...
StatusCreateIcons=Creare link-uri ...
StatusCreateIniEntries=Creare intrãri INI ...
StatusCreateRegistryEntries=Creare intrãri în Registry ...
StatusRegisterFiles=Inregistrare fisiere ...
StatusSavingUninstall=Salvare informatii de dezinstalare ...
StatusRunProgram=Finalizare instalare ...
StatusRollback=Anulare modificãri ...

; *** Misc. errors
ErrorInternal2=Eroare internã: %1
ErrorFunctionFailedNoCode=%1 a esuat
ErrorFunctionFailed=%1 a esuat; cod %2
ErrorFunctionFailedWithMessage=%1 a esuat; cod %2.%n%3
ErrorExecutingProgram=Nu pot executa:%n%1

; *** Registry errors
ErrorRegOpenKey=Eroare la deschiderea cheii din registri:%n%1\%2
ErrorRegCreateKey=Eroare la crearea urmãtoarei chei în registri:%n%1\%2
ErrorRegWriteKey=Eroare la scrierea urmãtoarei chei în registri:%n%1\%2

; *** INI errors
ErrorIniEntry=Eroare la crearea înregistrãrilor INI în fisierul "%1".

; *** File copying errors
FileAbortRetryIgnore=Apãsati 'Retry' pentru a încerca încã o datã, 'Ignore' pentru a trece peste acest fisier (nerecomandat) sau 'Abort' pentru a opri instalarea.
FileAbortRetryIgnore2=Apãsati 'Retry' pentru a încerca încã o datã, 'Ignore' pentru a trece oricum de acest pas (nerecomandat) sau 'Abort' pentru a opri instalarea.
SourceIsCorrupted=Fisierul sursã este corupt
SourceDoesntExist=Fisierul sursã "%1" nu existã
ExistingFileReadOnly=Fisierul existent este marcat read-only.%n%nApãsati 'Retry' pentru a schimba atributele fisierului si a încerca încã o datã, 'Ignore' pentru a trece peste acest fisier sau 'Abort' pentru a opri instalarea.
ErrorReadingExistingDest=A apãrut o eroare în timp ce citeam fisierul:
FileExists=Fisierul existã.%n%nDoriti sã îl suprascrieti ?
ExistingFileNewer=Fisierul existent este mai nou decât cel care se instaleazã acum. Este recomandat sã pãstrati fisierul existent.%n%nDoriti sã pãstrati fisierul existent ?
ErrorChangingAttr=A apãrut o eroare în timp ce încercam sã modific atributele fisierului:
ErrorCreatingTemp=A apãrut o eroare în timp ce încercam sã creez un fisier în directorul destinatie:
ErrorReadingSource=A apãrut o eroare în timp ce încercam sã citesc fisierul sursã:
ErrorCopying=A apãrut o eroare în timp ce încercam sã copiez fisierul:
ErrorReplacingExistingFile=A aparut o eroare in timp ce incercam sa inlocuiesc fisierul:
ErrorRestartReplace=Eroare înlocuire la restart:
ErrorRenamingTemp=A apãrut o eroare în timp ce încercam sã redenumesc fisierul din directorul destinatie:
ErrorRegisterServer=Nu pot sã înregistrez DLL/OCX: %1
ErrorRegisterServerMissingExport=Nu pot gãsi DllRegisterServer
ErrorRegisterTypeLib=Nu pot sã înregistrez tipul de librãrie: %1

; *** Post-installation errors
ErrorOpeningReadme=A apãrut o eroare la deschiderea fisierului README.
ErrorRestartingComputer=Programul de instalare nu poate restarta sistemul. Vã rugãm sã încercati sã restartati manual sistemul.

; *** Uninstaller messages
UninstallNotFound=Fisierul "%1" nu existã. Nu pot dezinstala.
UninstallOpenError=Fisierul "%1" nu poate fi deschis. Nu pot dezinstala
UninstallUnsupportedVer=Fisierul de dezinstalare "%1" are un format necunoscut acestei versiuni de program. Nu pot dezinstala
UninstallUnknownEntry=O intrare necunoscutã (%1) a fost gãsitã în fisierul de dezinstalare
ConfirmUninstall=Doriti sã dezinstalati %1 si componentele sale aditionale?
UninstallOnlyOnWin64=Trebuie sã rulati o versiune de Windows pe 64 de biti pentru a dezinstala acest program.
OnlyAdminCanUninstall=Trebuie sã aveti drepturi de Administrator pentru a dezinstala acest program.
UninstallStatusLabel=Vã rugãm asteptati pânã când dezinstalarea %1 ia sfarsit.
UninstalledAll=%1 a fost dezinstalat cu succes.
UninstalledMost=%1 a fost dezinstalat.%n%nUnele fisiere nu au putut fi sterse. Acestea pot fi sterse manual.
UninstalledAndNeedsRestart=Pentru a termina dezinstalarea %1, sistemul trebuie restartat.%n%nDoriti sã restartati sistemul acum?
UninstallDataCorrupted=Fisierul "%1" este corupt. Nu pot dezinstala

; *** Uninstallation phase messages
ConfirmDeleteSharedFileTitle=ªtergere fisiere 'Shared' ?
ConfirmDeleteSharedFile2=Sistemul indicã faptul cã urmãtorul fisier nu mai este utilizat de nici un alt program. Doriti sã stergeti acest fisier ?%n%nDacã acest fisier este totusi utilizat de un alt program, acesta din urmã nu va mai functiona corect. Dacã nu sunteti sigur, alegeti 'Nu'. Lãsând fisierul pe sistem nu vã va afecta cu nimic.
SharedFileNameLabel=Nume fisier:
SharedFileLocationLabel=Locatie:
WizardUninstalling=Progres dezinstalare
StatusUninstalling=Dezinstalare %1...
[CustomMessages]

NameAndVersion=%1 versiunea %2
AdditionalIcons=Iconite aditionale:
CreateDesktopIcon=Creeazã o iconitã pe &desktop
CreateQuickLaunchIcon=Creeazã o iconitã &Quick Launch
ProgramOnTheWeb=%1 pe Internet
UninstallProgram=Dezinstalare %1
LaunchProgram=Lanseazã %1
AssocFileExtension=&Asociazã %1 cu extensia de fisiere %2
AssocingFileExtension=Asociere %1 cu extensia de fisiere %2 ...

