@echo off
title Mario CLI
if %1==join (
    echo executing [92mzoom bot[0m
    echo [90m[0m
    cd /d "G:\codes - 2\local zoom bot\zoom_bot\"
    zoom_bot.exe %2
    @REM exit
)
@REM TODO: make a command to add more commands
@REM TODO: make a gitbook about mario 
@REM TODO: add tutorial text for making a new mario command
@REM TODO: store the commands in .txt file in an encrypted form
@REM TODO: make a command "mario about" which takes the user to marioCLI's gitbook
if %1==list (
    cd /d "%~dp0\"
    FOR /F "tokens=* delims=" %%x in (todolist.txt) DO (
        echo %%x
    )
)
if %1==todo (
    "%~dp0backend\bin\Debug\net5.0\backend.exe" addtodo %*
)
if %1==done (
    "%~dp0backend\bin\Debug\net5.0\backend.exe" removetodo %*
)
if %1==terminate (
    echo [91mshutting down system[0m
    shutdown /s /t 1
)
if %1==start (
    echo starting [92mVScode[0m at %CD%
    code .
    exit
)
if %1==migrate (
    cd /d "G:\codes - 2"
)

if %1==help (
    cd /d "G:\codes - 2\Mario\"
    FOR /F "tokens=* delims=" %%x in (help.txt) DO (echo %%x)
)
if %1==node (
    mkdir %2
    cd %2
    echo //Useful libraries > "index.js"
    echo. >> "index.js"
    echo. >> "index.js"
    echo //Functions >> "index.js"
    npm init -y
    echo [92mnodejs project initialized, happy coding[0m
    echo [90m[0m
)
if %1==react (
    npx create-react-app %2
    cd %2
    echo [92mreact project initialized, happy coding ![0m
    echo [90m[0m
)
if %1==install (
    npm install %2 %3 %4 %5 %6 %7
    echo [92mnpm package installed[0m
    echo [90m[0m
)
if %1==make (
    echo > %2
    echo created [92m%2[0m at %CD%
    echo [90m[0m
)
if %1==expo (
    expo init %2 --template blank
    cd %2
    echo [92mexpo project initiliazed, happy coding ![0m
    echo [90m[0m
)