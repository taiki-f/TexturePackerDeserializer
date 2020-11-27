@echo off
title %~nx0

rem ILMergeのパス
set ilmerge=..\packages\ILMerge.3.0.41\tools\net452\ILMerge.exe

rem インプットディレクトリ
set inputDir=..\TexturePackerDeserializer\bin\Release\

rem アウトプットディレクトリ
set outputDir=.\

rem 実行ファイル名
set outputFile=TexturePackerDeserializer.exe

echo exeとdllを結合
%ilmerge% /ndebug /targetplatform:v4 ^
        /out:%outputtDir%%outputFile% ^
        %inputDir%TexturePackerDeserializer.exe ^
        %inputDir%Microsoft.Bcl.AsyncInterfaces.dll ^
        %inputDir%System.Buffers.dll ^
        %inputDir%System.Memory.dll ^
        %inputDir%System.Numerics.Vectors.dll ^
        %inputDir%System.Runtime.CompilerServices.Unsafe.dll ^
        %inputDir%System.Text.Encodings.Web.dll ^
        %inputDir%System.Text.Json.dll ^
        %inputDir%System.Threading.Tasks.Extensions.dll ^
        %inputDir%System.ValueTuple.dll

rem if "%1"=="" pause
