; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "LonKhunDoi"
#define MyAppVersion "1"
#define MyAppPublisher "Child Labour"
#define MyAppExeName "LonKhunDoi.exe"
#define MyAppAssocName MyAppName + " File"
#define MyAppAssocExt ".myp"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{E5156B1F-A80C-49BC-A48D-F3ABF9A6EDE0}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
ChangesAssociations=yes
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputBaseFilename=LonKhunDoi Setup
SetupIconFile=D:\C#Project\LonKhunDoi\LonKhunDoi\bin\Debug\assets\Icon.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "D:\C#Project\LonKhunDoi\LonKhunDoi\bin\Debug\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\C#Project\LonKhunDoi\LonKhunDoi\bin\Debug\LonKhunDoi.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\C#Project\LonKhunDoi\LonKhunDoi\bin\Debug\LonKhunDoi.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\C#Project\LonKhunDoi\LonKhunDoi\bin\Debug\PurpleWin.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\C#Project\LonKhunDoi\LonKhunDoi\bin\Debug\PurpleWin.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\C#Project\LonKhunDoi\LonKhunDoi\bin\Debug\PurpleWin.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\C#Project\LonKhunDoi\LonKhunDoi\bin\Debug\StartGame.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\C#Project\LonKhunDoi\LonKhunDoi\bin\Debug\StartGame.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\C#Project\LonKhunDoi\LonKhunDoi\bin\Debug\StartGame.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\C#Project\LonKhunDoi\LonKhunDoi\bin\Debug\YellowWin.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\C#Project\LonKhunDoi\LonKhunDoi\bin\Debug\YellowWin.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\C#Project\LonKhunDoi\LonKhunDoi\bin\Debug\YellowWin.pdb"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKA; Subkey: "Software\Classes\Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".myp"; ValueData: ""

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

