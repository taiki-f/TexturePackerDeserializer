@echo off
title %~nx0
call TexturePackerDeserializer.exe -in="..\TexturePackerData\_json\TestProject.json" -format="image\tfilename\tframe.x\tframe.y\tframe.w\tframe.h"
call TexturePackerDeserializer.exe -in="..\TexturePackerData\_json\TestProject.json" -format="image\tfilename\tframe.x\tframe.y\tframe.w\tframe.h"
if "%1"=="" pause
