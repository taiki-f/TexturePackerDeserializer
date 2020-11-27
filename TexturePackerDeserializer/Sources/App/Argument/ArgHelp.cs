using System.Text;
using AppSystem.Argument;

namespace App.Argument
{
    class ArgHelp : IArgument<ArgParam>
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
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("▼使い方\n");
            stringBuilder.Append("TexturePackerDeserializer.exe -in=INPUT_PATH -format=OUTPUT_FROMATS [-out=OUTPUT_PATH][-mode=WRITE_MODE]\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("▼各種引数\n");
            stringBuilder.Append("-in     : TexturePackより出力したJSON ARRAY形式のファイルパスを指定\n");
            stringBuilder.Append("-format : 出力したい情報を特定のフォーマットで指定(フォーマット指定子は\\t \\n \\rが使用可能)\n");
            stringBuilder.Append("-out    : 出力結果をファイルに出力したい場合ファイルパスを指定\n");
            stringBuilder.Append("-mode   : -outオプション指定時に上書き(OVERRIDE) or 追記(ADD)を指定(デフォルトはOVERRIDE)\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("▼使用例1 イメージファイル名を取得する場合\n");
            stringBuilder.Append("TexturePackerDeserializer.exe -in=.\\TestJson.json -format=\"image\"\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("▼使用例2 複数の情報を取得する場合1\n");
            stringBuilder.Append("TexturePackerDeserializer.exe -in=.\\TestJson.json -format=\"image, filename, {frame.x, frame.y}\"\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("▼使用例3 複数の情報を取得する場合2\n");
            stringBuilder.Append("TexturePackerDeserializer.exe -in=.\\TestJson.json -format=\"image\\tfilename\\tframe.x\\tframe.y\"\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("▼使用例4 イメージファイル名をファイルに出力する場合\n");
            stringBuilder.Append("TexturePackerDeserializer.exe -in=.\\TestJson.json -format=\"image\" -out=.\\Output\\ImageInfo.txt\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("▼使用例5 イメージファイル名をファイルに追記で出力する場合\n");
            stringBuilder.Append("TexturePackerDeserializer.exe -in=.\\TestJson.json -format=\"image\" -out=.\\Output\\ImageInfo.txt -mode=ADD\n");
            obj.exitMessage = stringBuilder.ToString();
            obj.forceAppExit = true;
            return true;
        }
    }
}
