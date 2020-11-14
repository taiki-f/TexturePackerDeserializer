using System;
using System.IO;
using System.Text.Json;

namespace TexturePackerDeserializer
{
    class Pos
    {
        public int x { get; set; }
        public int y { get; set; }
    }
    class Size
    {
        public int w { get; set; }
        public int h { get; set; }
    }
    class Rect
    {
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }
    }

    /// <summary>
    /// フレームデータ
    /// </summary>
    class Frame
    {
        public string filename { get; set; }
        public Rect frame { get; set; }
        public bool rotated { get; set; }
        public bool trimmed { get; set; }
        public Rect spriteSourceSize { get; set; }
        public Size sourceSize { get; set; }
        public Pos pivot { get; set; }
    }
    class FrameFormat
    {
        public Frame[] frames { get; set; }
    }

    /// <summary>
    /// メタデータ
    /// </summary>
    class Meta
    {
        public string app { get; set; }
        public string version { get; set; }
        public string image { get; set; }
        public string format { get; set; }
        public Size size { get; set; }
        public string scale { get; set; }
        public string smartupdate { get; set; }
    }
    class MetaFormat
    {
        public Meta meta { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string filePath = args[0];

            try
            {
                // JSONを読み込む
                var textString = File.ReadAllText(filePath);
                var metaFormat = JsonSerializer.Deserialize<MetaFormat>(textString);
                var frameFormat = JsonSerializer.Deserialize<FrameFormat>(textString);

                Console.WriteLine(metaFormat.meta.app);
                foreach (var frame in frameFormat.frames)
                {
                    Console.WriteLine(frame.filename);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }
    }
}
