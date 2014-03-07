//--------------------------------------------------------------------------------
// Various constants required to detect isntallation of various features

//--------------------------------------------------------------------------------
// External functions

// Importing LoadSkin API from ISSkin.DLL
procedure LoadSkin(lpszPath: String; lpszIniFileName: String);
external 'LoadSkin@files:ISSkin.dll stdcall';

// Importing UnloadSkin API from ISSkin.DLL
procedure UnloadSkin();
external 'UnloadSkin@files:ISSkin.dll stdcall';

// Importing ShowWindow Windows API from User32.DLL
function ShowWindow(hWnd: Integer; uType: Integer): Integer;
external 'ShowWindow@user32.dll stdcall';

function isxdl_Download(hWnd: Integer; URL, Filename: String): Integer;
external 'isxdl_Download@files:isxdl.dll stdcall';

procedure isxdl_AddFile(URL, Filename: String);
external 'isxdl_AddFile@files:isxdl.dll stdcall';

procedure isxdl_AddFileSize(URL, Filename: String; Size: Cardinal);
external 'isxdl_AddFileSize@files:isxdl.dll stdcall';

function isxdl_DownloadFiles(hWnd: Integer): Integer;
external 'isxdl_DownloadFiles@files:isxdl.dll stdcall';

procedure isxdl_ClearFiles;
external 'isxdl_ClearFiles@files:isxdl.dll stdcall';

function isxdl_IsConnected: Integer;
external 'isxdl_IsConnected@files:isxdl.dll stdcall';

function isxdl_SetOption(Option, Value: String): Integer;
external 'isxdl_SetOption@files:isxdl.dll stdcall';

function isxdl_GetFileName(URL: String): String;
external 'isxdl_GetFileName@files:isxdl.dll stdcall';

//--------------------------------------------------------------------------------
procedure DecodeVersion( verstr: String; var verint: array of Integer );
var
  i,p: Integer; s: string;
begin
  // initialize array
  verint := [0,0,0,0];
  i := 0;
  while ( (Length(verstr) > 0) and (i < 4) ) do
  begin
   p := pos('.', verstr);
   if p > 0 then
   begin
      if p = 1 then s:= '0' else s:= Copy( verstr, 1, p - 1 );
     verint[i] := StrToInt(s);
     i := i + 1;
     verstr := Copy( verstr, p+1, Length(verstr));
   end
   else
   begin
     verint[i] := StrToInt( verstr );
     verstr := '';
   end;
  end;

end;

//--------------------------------------------------------------------------------
// This function compares version string
// return -1 if ver1 < ver2
// return  0 if ver1 = ver2
// return  1 if ver1 > ver2
function CompareVersion( ver1, ver2: String ) : Integer;
var
  verint1, verint2: array of Integer;
  i: integer;
begin

  SetArrayLength( verint1, 4 );
  DecodeVersion( ver1, verint1 );

  SetArrayLength( verint2, 4 );
  DecodeVersion( ver2, verint2 );

  Result := 0; i := 0;
  while ( (Result = 0) and ( i < 4 ) ) do
  begin
   if verint1[i] > verint2[i] then
     Result := 1
   else
      if verint1[i] < verint2[i] then
       Result := -1
     else
       Result := 0;

   i := i + 1;
  end;

end;

//--------------------------------------------------------------------------------
function DownloadFile(sLabel, sDesc, sUrl, sDest : string ) : Integer;
begin
   isxdl_SetOption('label', sLabel);
   isxdl_SetOption('description', sDesc);
   isxdl_AddFile(sUrl, sDest);
   result := isxdl_DownloadFiles(StrToInt(ExpandConstant('{wizardhwnd}')));
end;

//--------------------------------------------------------------------------------
// Setup initialisation
function InitializeSetup: Boolean;
var
   res : integer;
   s : string;
begin
   //ExtractTemporaryFile('OPMedia.cjstyles');
   //LoadSkin(ExpandConstant('{tmp}\OPMedia.cjstyles'), 'NormalBlack.ini');
   
   res := DownloadFile('Checking latest version ...', 'Please wait while retrieving last version to download ...', 
      'http://protone-suite.googlecode.com/svn/publish/current/Versions.txt',
      ExpandConstant('{tmp}\versions.txt'));   
      
   if (res = 1) then
   begin
   
    s := GetIniString('OPMedia SDK', 'Version', '0', ExpandConstant('{tmp}\versions.txt'));
    
    res := DownloadFile('Downloading OPMedia SDK ...', 'Please wait for the OPMedia SDK download to finish ...', 
          'http://protone-suite.googlecode.com/svn/publish/current/OPMedia SDK ' + s + '.exe',
           ExpandConstant('{tmp}') + 'OPMedia SDK '  + s + '.exe');
           
    if (res = 1) then
    begin
        result := Exec(ExpandConstant('{tmp}') + 'OPMedia SDK '  + s + '.exe', '', '', SW_SHOW, ewNoWait, res);;
    end;
    
   end;
   
   result := false;
   
end;

//--------------------------------------------------------------------------------
//procedure DeinitializeSetup();
//var
//   s : string;
//   rc : integer;
//begin
   // Hide Window before unloading skin so user does not get
   // a glimse of an unskinned window before it is closed.
//   ShowWindow(StrToInt(ExpandConstant('{wizardhwnd}')), 0);
//   UnloadSkin();
//end;
