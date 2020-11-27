namespace AppSystem.Argument
{
    /// <summary>
    /// 引数インターフェイス
    /// </summary>
    interface IArgument<T>
    {
        /// <summary>
        /// パラメータータイプを取得
        /// </summary>
        /// <returns>パラメータータイプ</returns>
        string GetParamType();

        /// <summary>
        /// 実行
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <param name="param">パラメーター</param>
        /// <returns>成否</returns>
        bool Execute(T obj, string param);
    }
}
