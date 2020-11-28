using System.IO;

namespace App
{
    /// <summary>
    /// 引数パラメーター
    /// </summary>
    class ArgParam
    {
        // アプリを強制終了するか
        public bool forceAppExit = false;
        // 終了メッセージ
        public string exitMessage = string.Empty;

        // ファイルパス関連
        public string inputFilePath = string.Empty;
        public string outputFilePath = string.Empty;

        // JSONデータ
        public JsonFormat jsonData = new JsonFormat();

        // 書き込みモード
        public enum eWriteMode {
            Override,               // 上書き
            Add,                    // 追記
        }
        public eWriteMode writeMode = eWriteMode.Override;

        /// <summary>
        /// ファイルへ出力
        /// </summary>
        /// <param name="outputString">出力内容</param>
        public bool OutputFile(string outputString)
        {
            switch (writeMode)
            {
                case eWriteMode.Override:           // 上書き
                    File.WriteAllText(outputFilePath, outputString);
                    return true;

                case eWriteMode.Add:                // 追記
                    File.AppendAllText(outputFilePath, outputString);
                    return true;
            }

            return false;
        }
    }
}
