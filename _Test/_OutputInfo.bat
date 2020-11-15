@echo off
title %~nx0
call TexturePackerDeserializer.exe -in="..\TexturePackerData\_json\TestProject.json" -info="image filename frame"
call TexturePackerDeserializer.exe -in="..\TexturePackerData\_json\TestProject.json" -info="image filename frame"
if "%1"=="" pause
