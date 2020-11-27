using AppSystem.Argument;

namespace App.Argument
{
    class ArgOutputFile : IArgument<ArgParam>
    {
        readonly string PARAM_TYPE = "-out";

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
            if (string.IsNullOrWhiteSpace(System.IO.Path.GetFileName(param)))
            {
                obj.exitMessage = "ファイル名が含まれていません。\n拡張子付きのファイル名をパスに含めてください。\nファイル出力は行われません。";
                return false;
            }

            obj.outputFilePath = param;
            return true;
        }
    }
}
