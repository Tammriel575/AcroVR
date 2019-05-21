; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyCompany "Tekphy"
#define MyAppName "AcroVR"
#define MyAppVersion "21.05.2019"
#define MyAppPublisher "Tekphy lab"
#define MyAppExeName "AcroVR.exe"

#define MySetupDir "C:\Devel\AcroVR\Installer AcroVR"
#define MySetupIcon "Tekphy.ico"

#define MyUnityBuildDir "C:\Devel\AcroVR\Build"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{303B14D3-EF85-43CE-9063-5DF31A254B17}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={pf64}\{#MyCompany}\{#MyAppName}
DefaultGroupName={#MyCompany}
DisableProgramGroupPage=yes
OutputDir={#MySetupDir}
OutputBaseFilename="Setup_{#MyAppName}_{#MyAppVersion}"
SetupIconFile="{#MySetupDir}\{#MySetupIcon}"
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "{#MyUnityBuildDir}\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#MyUnityBuildDir}\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MySetupDir}\{#MySetupIcon}"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MySetupDir}\SimulationFiles\*"; DestDir: "{app}\SimulationFiles"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\{#MySetupIcon}" 
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon; IconFilename: "{app}\{#MySetupIcon}"

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

