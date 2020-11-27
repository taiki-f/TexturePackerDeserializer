using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppSystem.Argument;

namespace App
{
    class ArgOutputFormat : IArgument<ArgParam>
    {
        readonly string PARAM_TYPE = "-format";

        /// <summary>
        /// パラメータータイプを取得
        /// </summary>
        /// <returns>パラメータータイプ</returns>
        public string GetParamType()
        {
            return PARAM_TYPE;
        }

        // 該当の文字をエスケープ文字に変換用のテーブル
        Dictionary<string, string> xchangeFormat = new Dictionary<string, string>() {
            {"\\t", "\t"},      // タブ
            {"\\n", "\n"},      // 改行
            {"\\r", "\r"},      // キャリッジリターン
        };

        delegate void frameFuncDelegate(ref string param, Frame frame);
        static frameFuncDelegate[] xchangeFrameFuncTable = {
            ReplaceFrameDataFromFileName,
            ReplaceFrameDataFromFrame,
            ReplaceFrameDataFromRotated,
            ReplaceFrameDataFromTrimmed,
            ReplaceFrameDataFromSpriteSourceSize,
            ReplaceFrameDataFromSourceSize,
            ReplaceFrameDataFromPivot,
        };

        delegate void metaFuncDelegate(ref string param, Meta meta);
        static metaFuncDelegate[] xchangeMetaFuncTable = {
            ReplaceMetaDataFromApp,
            ReplaceMetaDataFromVersion,
            ReplaceMetaDataFromImage,
            ReplaceMetaDataFromFormat,
            ReplaceMetaDataFromSize,
            ReplaceMetaDataFromScale,
            ReplaceMetaDataFromSmartupdate,
        };

        /// <summary>
        /// 実行
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <param name="param">パラメーター</param>
        /// <returns>成否</returns>
        public bool Execute(ArgParam obj, string param)
        {
            // エスケープ文字を置換
            param = xchangeFormat.Aggregate(param, (current, xchangeFormat) => current.Replace(xchangeFormat.Key, xchangeFormat.Value));

            // 該当パラメーターをJSONから取得
            StringBuilder stringBuilder = new StringBuilder();
            var meta = obj.jsonData.metaFormat.meta;
            foreach (var frame in obj.jsonData.frameFormat.frames)
            {
                string changeParam = param;
                
                // 2つ目以降は改行してから解析開始
                if (0 < stringBuilder.Length)
                {
                    stringBuilder.Append('\n');
                }

                // フレーム情報を取得
                foreach (var func in xchangeFrameFuncTable)
                {
                    func(ref changeParam, frame);
                }
                
                // メタ情報を取得
                foreach (var func in xchangeMetaFuncTable)
                {
                    func(ref changeParam, meta);
                }

                // 結果を格納
                stringBuilder.Append(changeParam);
            }

            if (stringBuilder.Length == 0)
            {
                obj.exitMessage = "解析後：出力できる情報がない [" + param + "]";
                obj.forceAppExit = true;
                return false;
            }
            else
            {
                // 結果を出力する
                ResultPrint(obj, stringBuilder);
            }

            // 情報は出力したらアプリ終了
            obj.forceAppExit = true;
            return true;
        }

        /// <summary>
        /// 結果を出力
        /// </summary>
        void ResultPrint(ArgParam obj, StringBuilder outputString)
        {
            if (string.IsNullOrWhiteSpace(obj.outputFilePath))
            {
                // ファイルの出力情報が無いためログ出力
                Console.WriteLine(outputString);
                return;
            }

            // 連続で出力できるように改行を追加
            outputString.Append('\n');

            // ファイルへ出力
            if (!obj.OutputFile(outputString.ToString()))
            {
                Console.WriteLine("ファイル出力に失敗しました。");
            }
        }

        /// <summary>
        /// フレームデータ内のJSONデータを取得
        /// </summary>
        /// <param name="param">パラメーター</param>
        /// <param name="frame">フレーム情報</param>
        /// <param name="meta">メタ情報</param>
        static void ReplaceFrameDataFromFileName(ref string param, Frame frame)
        {
            param = param.Replace(nameof(frame.filename), frame.filename);
        }
        static void ReplaceFrameDataFromFrame(ref string param, Frame frame)
        {
            param = param
                .Replace("frame.x", frame.frame.x.ToString())
                .Replace("frame.y", frame.frame.y.ToString())
                .Replace("frame.w", frame.frame.w.ToString())
                .Replace("frame.h", frame.frame.h.ToString());
        }
        static void ReplaceFrameDataFromRotated(ref string param, Frame frame)
        {
            param = param.Replace(nameof(frame.rotated), frame.rotated ? "1" : "0");
        }
        static void ReplaceFrameDataFromTrimmed(ref string param, Frame frame)
        {
            param = param.Replace(nameof(frame.trimmed), frame.trimmed ? "1" : "0");
        }
        static void ReplaceFrameDataFromSpriteSourceSize(ref string param, Frame frame)
        {
            param = param
                .Replace("spriteSourceSize.x", frame.spriteSourceSize.x.ToString())
                .Replace("spriteSourceSize.y", frame.spriteSourceSize.y.ToString())
                .Replace("spriteSourceSize.w", frame.spriteSourceSize.w.ToString())
                .Replace("spriteSourceSize.h", frame.spriteSourceSize.h.ToString());
        }
        static void ReplaceFrameDataFromSourceSize(ref string param, Frame frame)
        {
            param = param
                .Replace("sourceSize.w", frame.sourceSize.w.ToString())
                .Replace("sourceSize.h", frame.sourceSize.h.ToString());
        }
        static void ReplaceFrameDataFromPivot(ref string param, Frame frame)
        {
            param = param
                .Replace("pivot.x", frame.pivot.x.ToString())
                .Replace("pivot.y", frame.pivot.y.ToString());
        }

        /// <summary>
        /// メタデータ内のJSONデータを取得
        /// </summary>
        /// <param name="param">パラメーター</param>
        /// <param name="frame">フレーム情報</param>
        /// <param name="meta">メタ情報</param>
        static void ReplaceMetaDataFromApp(ref string param, Meta meta)
        {
            param = param.Replace(nameof(meta.app), meta.app);
        }
        static void ReplaceMetaDataFromVersion(ref string param, Meta meta)
        {
            param = param.Replace(nameof(meta.version), meta.version);
        }
        static void ReplaceMetaDataFromImage(ref string param, Meta meta)
        {
            param = param.Replace(nameof(meta.image), meta.image);
        }
        static void ReplaceMetaDataFromFormat(ref string param, Meta meta)
        {
            param = param.Replace(nameof(meta.format), meta.format);
        }
        static void ReplaceMetaDataFromSize(ref string param, Meta meta)
        {
            param = param
                .Replace("size.w", meta.size.w.ToString())
                .Replace("size.h", meta.size.h.ToString());
        }
        static void ReplaceMetaDataFromScale(ref string param, Meta meta)
        {
            param = param.Replace(nameof(meta.scale), meta.scale);
        }
        static void ReplaceMetaDataFromSmartupdate(ref string param, Meta meta)
        {
            param = param.Replace(nameof(meta.smartupdate), meta.smartupdate);
        }
    }
}
