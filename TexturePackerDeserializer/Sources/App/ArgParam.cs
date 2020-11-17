using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    /// <summary>
    /// 引数パラメーター
    /// </summary>
    class ArgParam
    {
        // アプリを強制終了するか
        public bool forceAppExit;
        // 終了メッセージ
        public string exitMessage;

        // ファイルパス関連
        public string filePath;
        public string fileName;

        // JSONデータ
        public JsonFormat jsonData;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ArgParam()
        {
            forceAppExit = false;
            jsonData = new JsonFormat();
        }
    }
}
