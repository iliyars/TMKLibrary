@echo off
chcp 65001 >nul
setlocal enabledelayedexpansion

REM =============================================================================
REM  TMK Library Builder
REM  Compile WDMTMKv2.dll from source code
REM =============================================================================

title TMK Library Builder

REM Colors (if supported)
set "RESET=[0m"
set "GREEN=[92m"
set "YELLOW=[93m"
set "BLUE=[94m"
set "RED=[91m"
set "CYAN=[96m"
set "BOLD=[1m"

cls
echo.
echo ═══════════════════════════════════════════════════════════════════════
echo                       TMK LIBRARY BUILDER
echo ═══════════════════════════════════════════════════════════════════════
echo.
echo  Project:  WDMTMKv2 Native Library
echo  Version:  1.0.0
echo  Author:   Based on ELCUS WDMTMKv2 API v4.08
echo.
echo ═══════════════════════════════════════════════════════════════════════
echo.

REM =============================================================================
REM  Compiler check
REM =============================================================================

echo [1/6] 🔍 Checking MinGW...
echo.

where g++ >nul 2>&1
if errorlevel 1 (
    echo ❌ ERROR: g++ not found in PATH!
    echo.
    echo 📦 Please install MinGW-w64:
    echo    • MSYS2: https://www.msys2.org/
    echo    • Chocolatey: choco install mingw
    echo.
    pause
    exit /b 1
)

for /f "delims=" %%i in ('g++ --version ^| findstr /C:"g++"') do (
    echo ✅ Compiler found: %%i
)
echo.

REM =============================================================================
REM  Create directory structure
REM =============================================================================

echo [2/6] 📁 Creating directory structure...
echo.

if not exist "bin" mkdir "bin"
if not exist "bin\x64" mkdir "bin\x64"
if not exist "bin\x86" mkdir "bin\x86"
if not exist "obj" mkdir "obj"
if not exist "obj\x64" mkdir "obj\x64"
if not exist "obj\x86" mkdir "obj\x86"

echo    ✓ bin\x64
echo    ✓ bin\x86
echo    ✓ obj\x64
echo    ✓ obj\x86
echo.

REM =============================================================================
REM  Check source files
REM =============================================================================

echo [3/6] 📄 Checking source files...
echo.

if not exist "src\WDMTMKv2.h" (
    echo ❌ File not found: src\WDMTMKv2.h
    pause
    exit /b 1
)
echo    ✓ WDMTMKv2.h

if not exist "src\WDMTMKv2.cpp" (
    echo ❌ File not found: src\WDMTMKv2.cpp
    pause
    exit /b 1
)
echo    ✓ WDMTMKv2.cpp
echo.

REM =============================================================================
REM  Compile x64 version
REM =============================================================================

echo [4/6] ⚙️  Compiling x64 version...
echo.

echo    Compiling WDMTMKv2.cpp...
g++ -c ^
    -O2 ^
    -DBUILD_MY_DLL ^
    -DNDEBUG ^
    -D_WINDOWS ^
    -std=c++11 ^
    -Wno-write-strings ^
    -Wno-strict-aliasing ^
    -o obj\x64\WDMTMKv2.o ^
    src\WDMTMKv2.cpp

if errorlevel 1 (
    echo.
    echo ❌ x64 compilation error!
    pause
    exit /b 1
)

echo    Linking WDMTMKv2.dll...
g++ -shared ^
    -o bin\x64\WDMTMKv2.dll ^
    -Wl,--out-implib,bin\x64\WDMTMKv2.a ^
    obj\x64\WDMTMKv2.o ^
    -lkernel32

if errorlevel 1 (
    echo.
    echo ❌ x64 linking error!
    pause
    exit /b 1
)

echo.
echo    ✅ Success: bin\x64\WDMTMKv2.dll
echo.

REM =============================================================================
REM  Compile x86 version (optional)
REM =============================================================================

echo [5/6] ⚙️  Compiling x86 version...
echo.

where i686-w64-mingw32-g++ >nul 2>&1
if errorlevel 1 (
    echo    ⚠️  32-bit compiler not found, skipping x86
    echo       To build x86 install: pacman -S mingw-w64-i686-gcc
    goto skip_x86
)

echo    Compiling WDMTMKv2.cpp...
i686-w64-mingw32-g++ -c ^
    -O2 ^
    -DBUILD_MY_DLL ^
    -DNDEBUG ^
    -D_WINDOWS ^
    -std=c++11 ^
    -Wno-write-strings ^
    -Wno-strict-aliasing ^
    -o obj\x86\WDMTMKv2.o ^
    src\WDMTMKv2.cpp

if errorlevel 1 (
    echo    ⚠️  x86 compilation error, skipping
    goto skip_x86
)

echo    Linking WDMTMKv2.dll...
i686-w64-mingw32-g++ -shared ^
    -o bin\x86\WDMTMKv2.dll ^
    -Wl,--out-implib,bin\x86\WDMTMKv2.a ^
    obj\x86\WDMTMKv2.o ^
    -lkernel32

if errorlevel 1 (
    echo    ⚠️  x86 linking error, skipping
    goto skip_x86
)

echo.
echo    ✅ Success: bin\x86\WDMTMKv2.dll
echo.

:skip_x86

REM =============================================================================
REM  Check result
REM =============================================================================

echo [6/6] 🔍 Checking exports...
echo.

if exist "bin\x64\WDMTMKv2.dll" (
    echo    Checking exports in x64 DLL...
    objdump -p bin\x64\WDMTMKv2.dll | findstr /C:"[Ordinal/Name Pointer] Table" >nul
    if not errorlevel 1 (
        echo    ✓ Exports found
        echo.
        echo    First 10 exported functions:
        objdump -p bin\x64\WDMTMKv2.dll | findstr "TmkOpen TmkClose tmkconfig tmkselect bcstart bcstop rtreset rtdefaddress mtstart"
    )
)

echo.

REM =============================================================================
REM  Final information
REM =============================================================================

cls
echo.
echo ═══════════════════════════════════════════════════════════════════════
echo                    ✅ BUILD COMPLETED SUCCESSFULLY!
echo ═══════════════════════════════════════════════════════════════════════
echo.

if exist "bin\x64\WDMTMKv2.dll" (
    for %%A in ("bin\x64\WDMTMKv2.dll") do (
        echo  📦 x64 DLL:  %%~zA bytes
    )
    echo     Path:     %CD%\bin\x64\WDMTMKv2.dll
    echo.
)

if exist "bin\x86\WDMTMKv2.dll" (
    for %%A in ("bin\x86\WDMTMKv2.dll") do (
        echo  📦 x86 DLL:  %%~zA bytes
    )
    echo     Path:     %CD%\bin\x86\WDMTMKv2.dll
    echo.
)

echo ───────────────────────────────────────────────────────────────────────
echo  Next steps:
echo ───────────────────────────────────────────────────────────────────────
echo.
echo  1️⃣  Copy DLL to C# project:
echo     copy bin\x64\WDMTMKv2.dll ..\src\TMKLibrary\runtimes\win-x64\native\
echo.
echo  2️⃣  Build C# library:
echo     cd ..\
echo     dotnet build TMKLibrary.sln
echo.
echo  3️⃣  Run examples:
echo     dotnet run --project samples\BasicExample\BasicExample.csproj
echo.
echo ═══════════════════════════════════════════════════════════════════════
echo.

pause