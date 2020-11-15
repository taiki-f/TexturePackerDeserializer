@echo off
title %~nx0
call TexturePackerDeserializer.exe -in="..\TexturePackerData\_json\TestProject.json" -info="image filename frame">_InfoList.txt
call TexturePackerDeserializer.exe -in="..\TexturePackerData\_json\TestProject.json" -info="image filename frame">>_InfoList.txt
if "%1"=="" pause
