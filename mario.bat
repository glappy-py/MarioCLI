@echo off
title Mario CLI
@REM command for production build
@REM "%~dp0backend\bin\Debug\net5.0\backend.exe" addtodo %*
cd /d "%~dp0backend\"
dotnet run %*
@REM if %1==join (
@REM     echo executing [92mzoom bot[0m
@REM     echo [90m[0m
@REM     cd /d "G:\codes - 2\local zoom bot\zoom_bot\"
@REM     zoom_bot.exe %2
@REM     @REM exit
@REM )
@REM @REM TODO: make a command to add more commands
@REM @REM TODO: make a gitbook about mario 
@REM @REM TODO: add tutorial text for making a new mario command
@REM @REM TODO: store the commands in .txt file in an encrypted form
@REM @REM TODO: make a command "mario about" which takes the user to marioCLI's gitbook
@REM if %1==list (
@REM     cd /d "%~dp0\"
@REM     FOR /F "tokens=* delims=" %%x in (todolist.txt) DO (
@REM         echo %%x
@REM     )
@REM )
@REM if %1==todo (
@REM     @REM command for production build
@REM     @REM "%~dp0backend\bin\Debug\net5.0\backend.exe" addtodo %*
@REM     cd /d "%~dp0backend\"
@REM     dotnet run addtodo %*
@REM )
@REM if %1==done (
@REM     @REM command for production build
@REM     @REM "%~dp0backend\bin\Debug\net5.0\backend.exe" removetodo %*
@REM     cd /d "%~dp0backend\"
@REM     dotnet run removetodo %*
@REM )
@REM if %1==terminate (
@REM     echo [91mshutting down system[0m
@REM     shutdown /s /t 1
@REM )
@REM if %1==start (
@REM     echo starting [92mVScode[0m at %CD%
@REM     code .
@REM     exit
@REM )
@REM if %1==migrate (
@REM     cd /d "G:\codes - 2"
@REM )

@REM if %1==help (
@REM     cd /d "G:\codes - 2\Mario\"
@REM     FOR /F "tokens=* delims=" %%x in (help.txt) DO (echo %%x)
@REM )
@REM if %1==node (
@REM     mkdir %2
@REM     cd %2
@REM     echo //Useful libraries > "index.js"
@REM     echo. >> "index.js"
@REM     echo. >> "index.js"
@REM     echo //Functions >> "index.js"
@REM     npm init -y
@REM     echo [92mnodejs project initialized, happy coding[0m
@REM     echo [90m[0m
@REM )
@REM if %1==react (
@REM     npx create-react-app %2
@REM     cd %2
@REM     echo [92mreact project initialized, happy coding ![0m
@REM     echo [90m[0m
@REM )
@REM if %1==install (
@REM     npm install %2 %3 %4 %5 %6 %7
@REM     echo [92mnpm package installed[0m
@REM     echo [90m[0m
@REM )
@REM if %1==make (
@REM     echo > %2
@REM     echo created [92m%2[0m at %CD%
@REM     echo [90m[0m
@REM )
@REM if %1==expo (
@REM     expo init %2 --template blank
@REM     cd %2
@REM     echo [92mexpo project initiliazed, happy coding ![0m
@REM     echo [90m[0m
@REM )