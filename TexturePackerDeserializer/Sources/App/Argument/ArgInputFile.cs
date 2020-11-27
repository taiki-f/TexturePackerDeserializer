using System.IO;
using AppSystem.Argument;

namespace App.Argument
{
    class ArgInputFile : IArgument<ArgParam>
    {
        readonly string PARAM_TYPE = "-in";

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
            if (!File.Exists(param))
            {
                obj.exitMessage = "ファイルが存在しない [path:" + param + "]";
                obj.forceAppExit = true;
                return false;
            }

            obj.inputFilePath = param;

            try
            {
                LoadJson(obj.jsonData, obj.inputFilePath);
            }
            catch
            {
                obj.exitMessage = "JSONデシリアライズに失敗 [path:" + obj.inputFilePath + "]";
                obj.forceAppExit = true;
                return false;
            }

            return true;
        }

        /// <summary>
        /// JSONの読み込み
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        void LoadJson(JsonFormat data, string filePath)
        {
            try
            {
                var textString = File.ReadAllText(filePath);
                data.Deserialize(textString);
            }
            catch
            {
                throw;
            }
        }
    }
}
