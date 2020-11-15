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
        // エラーメッセージ
        public string errorMessage;

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
            jsonData = new JsonFormat();
        }
    }
}
