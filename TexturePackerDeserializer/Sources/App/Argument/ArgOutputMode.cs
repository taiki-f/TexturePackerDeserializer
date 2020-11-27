using AppSystem.Argument;

namespace App.Argument
{
    class ArgOutputMode : IArgument<ArgParam>
    {
        readonly string PARAM_TYPE = "-mode";

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
            if ("OVERRIDE".Equals(param.ToUpper()))
            {
                // 上書きモード
                obj.writeMode = ArgParam.eWriteMode.Override;
            }
            else if ("ADD".Equals(param.ToUpper()))
            {
                // 追記モード
                obj.writeMode = ArgParam.eWriteMode.Add;
            }

            return true;
        }
    }
}
