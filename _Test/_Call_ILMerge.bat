@echo off
title %~nx0

rem ILMerge�̃p�X
set ilmerge=..\packages\ILMerge.3.0.41\tools\net452\ILMerge.exe

rem �C���v�b�g�f�B���N�g��
set inputDir=..\TexturePackerDeserializer\bin\Release\

rem �A�E�g�v�b�g�f�B���N�g��
set outputDir=.\

rem ���s�t�@�C����
set outputFile=TexturePackerDeserializer.exe

echo exe��dll������
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
