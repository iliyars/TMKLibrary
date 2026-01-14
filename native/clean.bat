@echo off

chcp 65001 >nul

title TMK Library - Clean

echo.
echo ================================================================
echo                      PROJECT CLEANUP
echo ================================================================
echo.
echo Deleting temporary files...
echo.

if exist "obj" (
    echo  [OK] Deleting obj\
    rmdir /s /q "obj"
)

if exist "bin" (
    echo  [OK] Deleting bin\
    rmdir /s /q "bin"
)

echo.
echo [SUCCESS] Cleanup completed!
echo.
pause