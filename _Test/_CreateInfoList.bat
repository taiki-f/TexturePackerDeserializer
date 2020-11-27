@echo off
title %~nx0
call TexturePackerDeserializer.exe -in="..\TexturePackerData\_json\TestProject.json" -format="image\tfilename\tframe.x\tframe.y\tframe.w\tframe.h" -out=_InfoList.txt
call TexturePackerDeserializer.exe -in="..\TexturePackerData\_json\TestProject.json" -format="image\tfilename\tframe.x\tframe.y\tframe.w\tframe.h" -out=_InfoList.txt -mode=ADD
if "%1"=="" pause
