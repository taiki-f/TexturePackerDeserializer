using AppSystem;

namespace App
{
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
}
