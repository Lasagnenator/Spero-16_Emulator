@echo off
echo Building and copying Assembler
cd Assembler
pyinstaller --name=Assembler -y main.py
7z a .\dist\Assembler.zip .\dist\Assembler
cd ..
xcopy /y ".\Assembler\dist\Assembler.zip" ".\dist\"

echo Copying Simulator release
"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\devenv.exe" Simulator.sln /Build Release
xcopy /y ".\Simulator\bin\Release\Simulator.exe" ".\dist\"

echo Copying Code tests
7z a .\dist\CodeTests.zip ".\Code Tests"
pause

