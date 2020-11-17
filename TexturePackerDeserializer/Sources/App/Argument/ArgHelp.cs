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
            StringBuilder stringBuilder = new StringBuilder("使い方:TexturePackerDeserializer.exe -in=INPUT_PATH -info=OUTPUT_INFOS\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("  -in:TexturePackより出力したJSON ARRAY形式のファイルパスを指定\n");
            stringBuilder.Append("  -info:出力したい情報を列挙\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("▼例1 イメージファイル名を取得する場合\n");
            stringBuilder.Append("  TexturePackerDeserializer.exe -in=.\\TestJson.json -info=\"image\"\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("▼例2 複数の情報を取得する場合\n");
            stringBuilder.Append("  TexturePackerDeserializer.exe -in=.\\TestJson.json -info=\"image filename frame\"\n");
            obj.exitMessage = stringBuilder.ToString();
            obj.forceAppExit = true;
            return true;
        }
    }
}
