using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App;

namespace App
{
    class ArgOutputInfo : AppSystem.IArgument<ArgParam>
    {
        readonly string PARAM_TYPE = "-info";

        /// <summary>
        /// パラメータータイプを取得
        /// </summary>
        /// <returns>パラメータータイプ</returns>
        public string GetParamType()
        {
            return PARAM_TYPE;
        }

        /// <summary>
        /// 実行
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <param name="param">パラメーター</param>
        /// <returns>成否</returns>
        public bool Execute(ArgParam obj, string param)
        {
            var dataTypes = param.Split(' ');
            if (dataTypes.Length == 0)
            {
                obj.errorMessage = "解析前：出力できる情報がない [" + param + "]";
                obj.forceAppExit = true;
                return false;
            }

            StringBuilder stringBuilder = new StringBuilder();
            var meta = obj.jsonData.metaFormat.meta;
            foreach (var frame in obj.jsonData.frameFormat.frames)
            {
                // 2つ目以降は改行してから解析開始
                if (0 < stringBuilder.Length)
                {
                    stringBuilder.Append('\n');
                }

                foreach (var type in dataTypes)
                {
                    if (!AnalyzeJsonInfo(frame, meta, type, stringBuilder))
                    {
                        // 該当するパラメーターが存在しない
                    }
                }
            }

            if (stringBuilder.Length == 0)
            {
                obj.errorMessage = "解析後：出力できる情報がない [" + param + "]";
                obj.forceAppExit = true;
                return false;
            }
            else
            {
                // 結果をリストに出力する
                CreateListFile(stringBuilder.ToString());
            }

            // 情報は出力したらアプリ終了
            obj.forceAppExit = true;
            return true;
        }

        /// <summary>
        /// リストファイルを生成
        /// </summary>
        void CreateListFile(string outputString)
        {
            Console.WriteLine(outputString);
        }

        /// <summary>
        /// JSONファイルを解析し情報を格納
        /// </summary>
        /// <param name="frameData">フレーム情報</param>
        /// <param name="metaData">メタ情報</param>
        /// <param name="dataType">データの種類</param>
        /// <param name="outputInfos">情報の格納先</param>
        /// <returns></returns>
        bool AnalyzeJsonInfo(Frame frameData, Meta metaData, string dataType, StringBuilder outputInfo)
        {
            string info = GetTargetJsonInfo(frameData, metaData, dataType);

            // 該当するデータがあるので追加
            if (!String.IsNullOrWhiteSpace(info))
            {
                // 格納先に情報がある & 末尾が改行じゃない
                if (0 < outputInfo.Length && !outputInfo.ToString().EndsWith("\n"))
                {
                    // 間にタブを挟む
                    outputInfo.Append('\t');
                }
                outputInfo.Append(info);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 指定した情報をJSONデータから取得
        /// </summary>
        /// <param name="frameData">フレーム情報</param>
        /// <param name="metaData">メタ情報</param>
        /// <param name="dataType">データの種類</param>
        /// <returns></returns>
        string GetTargetJsonInfo(Frame frameData, Meta metaData, string targetType)
        {
            switch (targetType)
            {
                // 以下、フレームデータ
                case nameof(frameData.filename):
                    return frameData.filename;

                case nameof(frameData.frame):
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(frameData.frame.x);
                        stringBuilder.Append('\t');
                        stringBuilder.Append(frameData.frame.y);
                        stringBuilder.Append('\t');
                        stringBuilder.Append(frameData.frame.w);
                        stringBuilder.Append('\t');
                        stringBuilder.Append(frameData.frame.h);
                        return stringBuilder.ToString();
                    }

                case nameof(frameData.rotated):
                    return frameData.rotated ? "1" : "0";

                case nameof(frameData.trimmed):
                    return frameData.rotated ? "1" : "0";

                case nameof(frameData.spriteSourceSize):
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(frameData.spriteSourceSize.x);
                        stringBuilder.Append('\t');
                        stringBuilder.Append(frameData.spriteSourceSize.y);
                        stringBuilder.Append('\t');
                        stringBuilder.Append(frameData.spriteSourceSize.w);
                        stringBuilder.Append('\t');
                        stringBuilder.Append(frameData.spriteSourceSize.h);
                        return stringBuilder.ToString();
                    }

                case nameof(frameData.sourceSize):
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(frameData.sourceSize.w);
                        stringBuilder.Append('\t');
                        stringBuilder.Append(frameData.sourceSize.h);
                        return stringBuilder.ToString();
                    }

                case nameof(frameData.pivot):
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(frameData.pivot.x);
                        stringBuilder.Append('\t');
                        stringBuilder.Append(frameData.pivot.y);
                        return stringBuilder.ToString();
                    }

                // 以下、メタデータ
                case nameof(metaData.app):
                    return metaData.app;

                case nameof(metaData.version):
                    return metaData.version;

                case nameof(metaData.image):
                    return metaData.image;

                case nameof(metaData.format):
                    return metaData.format;

                case nameof(metaData.size):
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(metaData.size.w);
                        stringBuilder.Append('\t');
                        stringBuilder.Append(metaData.size.h);
                        return stringBuilder.ToString();
                    }

                case nameof(metaData.scale):
                    return metaData.scale;

                case nameof(metaData.smartupdate):
                    return metaData.smartupdate;
            }

            return String.Empty;
        }
    }
}
