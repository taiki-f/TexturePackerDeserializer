using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace App.Argument
{
    class ArgVersion : AppSystem.IArgument<ArgParam>
    {
        readonly string PARAM_TYPE = "-version";
        readonly string VERSION = "0.0.6";

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
            stringBuilder.Append("▼バージョン : " + VERSION + "\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("▼更新履歴\n");
            stringBuilder.Append("0.0.1 : リリース\n");
            stringBuilder.Append("0.0.2 : -helpにてヘルプ情報が見えるように実装\n");
            stringBuilder.Append("0.0.3 : -infoを廃止、代わりに-formatを実装\n");
            stringBuilder.Append("0.0.4 : -versionにてバージョン番号と変更履歴が確認できるように実装\n");
            stringBuilder.Append("0.0.5 : -outにて出力先にファイルを指定できるように実装\n");
            stringBuilder.Append("0.0.6 : -modeにてoutオプションで追加 or 上書きを選べるように実装\n");
            obj.exitMessage = stringBuilder.ToString();
            obj.forceAppExit = true;
            return true;
        }
    }
}
