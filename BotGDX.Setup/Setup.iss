; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "BotGDX"
#define MyAppVersion GetFileVersion('..\BotGDX\bin\Release\net6.0-windows\BotGDX.exe')
#define MyAppPublisher "WBot-Soft"
#define MyAppURL "https://wbot-soft.my1.ru"
#define MyAppExeName "BotGDX.exe"
#define MyAppStartYear  "2024"
#define CurrentYear     GetDateTimeString('yyyy','','')

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{FA9C7428-D331-4A00-B3CF-D7F07D7D8661}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
VersionInfoVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
AppCopyright=� {#MyAppStartYear}-{#CurrentYear} {#MyAppPublisher}
UninstallDisplayIcon={app}\{#MyAppExeName}

AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}

DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName=WBot-Soft
DisableProgramGroupPage=yes
; The [Icons] "quicklaunchicon" entry uses {userappdata} but its [Tasks] entry has a proper IsAdminInstallMode Check.
UsedUserAreasWarning=no
LicenseFile=E:\BotGDX\BotGDX-main\LICENSE.txt
; Remove the following line to run in administrative install mode (install for all users.)
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
OutputDir=E:\BotGDX\BotGDX.Setup\Output
OutputBaseFilename=BotGDX_Setup
SetupIconFile=E:\BotGDX\BotGDX-main\BotGDX\BotGDX.ico
Compression=lzma
SolidCompression=yes


[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 6.1; Check: not IsAdminInstallMode

[Files]
Source: "E:\BotGDX\BotGDX-main\BotGDX\bin\Debug\net6.0-windows\BotGDX.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\BotGDX\BotGDX-main\BotGDX\bin\Debug\net6.0-windows\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "E:\BotGDX\BotGDX-main\BotGDX.Updater\bin\Debug\net6.0-windows\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
