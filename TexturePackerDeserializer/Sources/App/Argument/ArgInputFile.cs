using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace App.Argument
{
    class ArgInputFile : AppSystem.IArgument<ArgParam>
    {
        /// <summary>
        /// パラメータータイプを取得
        /// </summary>
        /// <returns>パラメータータイプ</returns>
        public string GetParamType()
        {
            return "-in";
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
                obj.errorMessage = "ファイルが存在しない [path:" + param + "]";
                return false;
            }

            obj.filePath = param;
            obj.fileName = Path.GetFileName(param);

            try
            {
                LoadJson(obj.jsonData, obj.filePath);
            }
            catch
            {
                obj.errorMessage = "JSONデシリアライズに失敗 [path:" + obj.filePath + "]";
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
