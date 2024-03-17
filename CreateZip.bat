@echo off
mkdir Zip

xcopy BotGDX\bin\Debug\net6.0-windows\ Zip /s /e /y
xcopy BotGDX.Fps\bin\Release\ Zip /s /e /y

pause
