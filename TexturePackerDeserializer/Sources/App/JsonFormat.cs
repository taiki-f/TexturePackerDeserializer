using System.Text.Json;

namespace App
{
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
