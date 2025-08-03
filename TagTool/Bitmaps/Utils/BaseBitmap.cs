using TagTool.Tags.Definitions;

namespace TagTool.Bitmaps
{
    public class BaseBitmap
    {
        public int Width;
        public int Height;
        public int Depth;
        public int MipMapCount;
        public BitmapFormat Format;
        public BitmapType Type;
        public BitmapImageCurve Curve;
        public BitmapFlags Flags;
        public byte[] Data;

        public BaseBitmap() { }

        public BaseBitmap(Bitmap.Image image, byte[] data = null)
        {
            Data = data;
            Height = image.Height;
            Width = image.Width;
            Depth = image.Depth;
            MipMapCount = image.MipmapCount + 1;
            Type = image.Type;
            Flags = image.Flags;
            Curve = image.Curve;
            UpdateFormat(image.Format);
        }

        public void UpdateFormat(BitmapFormat format)
        {
            Format = format;
            if (BitmapUtils.IsCompressedFormat(format))
                Flags |= BitmapFlags.Compressed;
            else
                Flags &= ~BitmapFlags.Compressed;
        }
    }
}
