using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagTool.Bitmaps.Utils
{
    public static class BitmapCurves
    {
        public record Curve(Func<float, float> FromLinear, Func<float, float> ToLinear);

        public static readonly Curve Xrgb = new(XrgbToLinear, LinearToXrgb);
        public static readonly Curve Srgb = new(SrgbToLinear, LinearToSrgb);
        public static readonly Curve Gamma2 = new(x => MathF.Pow(x, 2f), x => MathF.Pow(x, 1 / 2f));
        public static readonly Curve Linear = new(x => x, x => x);

        public static Curve GetCurve(BitmapImageCurve curve)
        {
            return curve switch
            {
                BitmapImageCurve.Unknown => Linear,
                BitmapImageCurve.Linear => Linear,
                BitmapImageCurve.xRGB => Xrgb,
                BitmapImageCurve.sRGB => Srgb,
                BitmapImageCurve.Gamma2 => Gamma2,
                _ => throw new NotSupportedException($"Bitmap curve '{curve}' not supported"),
            };
        }

        private static float SrgbToLinear(float x)
        {
            x = Math.Clamp(x, 0f, 1f);
            if (x <= 0.04045f)
                return x / 12.92f;
            else
                return MathF.Pow((x + 0.055f) / 1.055f, 2.4f);
        }

        private static float LinearToSrgb(float x)
        {
            x = Math.Clamp(x, 0f, 1f);
            if (x <= 0.00031308f)
                return 12.92f * x;
            else
                return 1.055f * MathF.Pow(x, 1.0f / 2.4f) - 0.055f;
        }

        private static float XrgbToLinear(float x)
        {
            float y1 = x / 4.0000391f;
            float y2 = (x - 0.12499412f) / 2.0000315f;
            float y3 = (x - 0.25000352f) / 1.0000157f;
            float y4 = (x - 0.49999216f) / 0.50000787f;
            return MathF.Max(MathF.Max(y1, y2), MathF.Max(y3, y4));
        }

        private static float LinearToXrgb(float x)
        {
            float y1 = 4.0000391f * x;
            float y2 = 2.0000315f * x + 0.12499412f;
            float y3 = 1.0000157f * x + 0.25000352f;
            float y4 = 0.50000787f * x + 0.49999216f;
            return MathF.Min(MathF.Min(y1, y2), MathF.Min(y3, y4));
        }
    }
}
