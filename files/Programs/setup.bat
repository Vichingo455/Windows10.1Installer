@echo off
title Windows 10.1 Installation Script by: Vichingo455
cmdow @ /hid
echo Setup Script by: Vichingo455 in progress...
echo DO NOT CLOSE THIS WINDOW!
echo.
echo Installing ExplorerPatcher...
start /min /wait ExplorerPatcher.exe
regedit /s ep_patch.reg
echo Enabling square corners...
start /min /wait square_corners.exe
echo Installing Themes...
start Nature.deskthemepack
timeout 3 > nul
start Flowers.deskthemepack
timeout 3 > nul
start Windows.deskthemepack
echo Final tweaks...
regedit /s tweak.reg
exit