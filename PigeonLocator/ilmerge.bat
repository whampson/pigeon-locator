@echo off

set VERSION=3.0.29
set ILMERGE=..\packages\ILMerge.%VERSION%\tools\net452\ILMerge.exe

set EXENAME=PigeonLocator.exe
set EXENAME_MERGED=PigeonLocator_M.exe

set CONFIG=Debug
if /I "%1" == "release" set CONFIG=Release

echo Merging dependencies...
%ILMERGE% bin\%CONFIG%\%EXENAME% /out:bin\%CONFIG%\%EXENAME_MERGED% ^
    bin\%CONFIG%\Newtonsoft.Json.dll ^
    bin\%CONFIG%\WpfEssentials.dll ^
    bin\%CONFIG%\WpfEssentials.Win32.dll ^
    bin\%CONFIG%\GTASaveData.Core.dll ^
    bin\%CONFIG%\GTASaveData.GTA4.dll

if errorlevel 0 echo Wrote file: bin\%CONFIG%\%EXENAME_MERGED%