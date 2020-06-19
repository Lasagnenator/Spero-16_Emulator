@echo off
echo Building and copying Assembler
cd Assembler
pyinstaller --name=Assembler -y main.py
7z a .\dist\Assembler.zip .\dist\Assembler
cd ..
xcopy /y ".\Assembler\dist\Assembler.zip" ".\dist\"

echo Copying Simulator release
"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\devenv.exe" Simulator.sln /Build Release
xcopy /y ".\Simulator\bin\Release\Spero.exe" ".\dist\"
xcopy /y ".\Simulator\bin\Release\Help.chm" ".\dist\"

echo Copying Code tests
7z a .\dist\CodeTests.zip ".\Code Tests"

cd .\dist\
echo Creating checksum file.
wsl sha256sum Assembler.zip > sha256sum.txt
wsl sha256sum CodeTests.zip >> sha256sum.txt
wsl sha256sum Help.chm >> sha256sum.txt
wsl sha256sum Spero.chm >> sha256sum.txt
echo Checksum file created.
pause

