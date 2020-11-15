using System;
using System.IO;
using System.Text.Json;
using TexturePacker;

namespace App
{
    /// <summary>
    /// メインクラス
    /// </summary>
    class TexturePackerDeserializer
    {
        static void Main(string[] args)
        {
            // ファイルパス
            string filePath = args[0];

            try
            {
                // JSONを読み込む
                var textString = File.ReadAllText(filePath);
                var json = new JsonFormat();
                json.Deserialize(textString);

                // メタデータの確認
                Console.WriteLine(json.metaFormat.meta.app);

                // フレームデータの確認
                foreach (var frame in json.frameFormat.frames)
                {
                    Console.WriteLine(frame.filename);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return;
            }
        }
    }

    /// <summary>
    /// JSONフォーマット
    /// </summary>
    class JsonFormat
    {
        // フレームフォーマット
        public FrameFormat frameFormat { get; private set; }

        // メタフォーマット
        public MetaFormat metaFormat { get; private set; }

        /// <summary>
        /// デシリアライズ
        /// </summary>
        /// <param name="jsonText">JSONテキスト</param>
        public void Deserialize(string jsonText)
        {
            try
            {
                frameFormat = JsonSerializer.Deserialize<FrameFormat>(jsonText);
                metaFormat = JsonSerializer.Deserialize<MetaFormat>(jsonText);
            }
            catch
            {
                throw;
            }
        }
    }
}
