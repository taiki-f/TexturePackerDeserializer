using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace App.Argument
{
    class ArgHelp : AppSystem.IArgument<ArgParam>
    {
        readonly string PARAM_TYPE = "-help";

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
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("▼使い方\n");
            stringBuilder.Append("TexturePackerDeserializer.exe -in=INPUT_PATH -format=OUTPUT_FROMATS\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("▼各種引数\n");
            stringBuilder.Append("-in     : TexturePackより出力したJSON ARRAY形式のファイルパスを指定\n");
            stringBuilder.Append("-format : 出力したい情報を特定のフォーマットで指定\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("▼使用例1 イメージファイル名を取得する場合\n");
            stringBuilder.Append("TexturePackerDeserializer.exe -in=.\\TestJson.json -format=\"image\"\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("▼使用例2 複数の情報を取得する場合1\n");
            stringBuilder.Append("TexturePackerDeserializer.exe -in=.\\TestJson.json -format=\"image, filename, {frame.x, frame.y}\"\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("▼使用例3 複数の情報を取得する場合2\n");
            stringBuilder.Append("TexturePackerDeserializer.exe -in=.\\TestJson.json -format=\"image\\tfilename\\tframe.x\\tframe.y\"\n");
            obj.exitMessage = stringBuilder.ToString();
            obj.forceAppExit = true;
            return true;
        }
    }
}
