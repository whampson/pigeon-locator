@echo off
pushd %~dp0

:: set VERSION=3.0.29
set VERSION=3.0.41
set ILMERGE=..\packages\ILMerge.%VERSION%\tools\net452\ILMerge.exe

set EXENAME=PigeonLocator.exe

set CONFIG=Debug
if /I "%1" == "release" set CONFIG=Release

mkdir bin\%CONFIG%\ILMerge
set OUTFILE=bin\%CONFIG%\ILMerge\%EXENAME%

echo Merging dependencies...
%ILMERGE% bin\%CONFIG%\%EXENAME% /out:%OUTFILE% ^
    bin\%CONFIG%\Newtonsoft.Json.dll ^
    bin\%CONFIG%\WpfEssentials.dll ^
    bin\%CONFIG%\WpfEssentials.Win32.dll ^
    bin\%CONFIG%\GTASaveData.Core.dll ^
    bin\%CONFIG%\GTASaveData.IV.dll

if errorlevel 0 echo Wrote file: %OUTFILE%

popd
