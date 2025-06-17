using System;
using System.Collections.Generic;
using TagTool.Cache;

namespace TagTool.Common
{
    public struct RealRectangle2d : IEquatable<RealRectangle2d>, IBlamType
    {
        public float Top { get; set; }
        public float Left { get; set; }
        public float Bottom { get; set; }
        public float Right { get; set; }

        public RealRectangle2d(float top, float left, float bottom, float right)
        {
            Top = top;
            Left = left;
            Bottom = bottom;
            Right = right;
        }

        public bool Equals(RealRectangle2d other) =>
            (Top == other.Top) &&
            (Left == other.Left) &&
            (Bottom == other.Bottom) &&
            (Right == other.Right);

        public override bool Equals(object obj) =>
            obj is RealRectangle2d ?
                Equals((RealRectangle2d)obj) :
            false;

        public static bool operator ==(RealRectangle2d a, RealRectangle2d b) =>
            a.Equals(b);

        public static bool operator !=(RealRectangle2d a, RealRectangle2d b) =>
            !a.Equals(b);

        public override int GetHashCode() =>
            13 * 33 + Top.GetHashCode()
               * 33 + Left.GetHashCode()
               * 33 + Bottom.GetHashCode()
               * 33 + Right.GetHashCode();

        public override string ToString() =>
            $"{{ Top: {Top}, Left: {Left}, Bottom: {Bottom}, Right: {Right} }}";

        public bool TryParse(GameCache cache, List<string> args, out IBlamType result, out string error)
        {
            result = null;
            if (args.Count != 4)
            {
                error = $"{args.Count} arguments supplied; should be 4";
                return false;
            }
            else if (!float.TryParse(args[0], out float top))
            {
                error = $"Unable to parse \"{args[0]}\" (top) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[1], out float left))
            {
                error = $"Unable to parse \"{args[1]}\" (left) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[2], out float bottom))
            {
                error = $"Unable to parse \"{args[2]}\" (bottom) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[3], out float right))
            {
                error = $"Unable to parse \"{args[3]}\" (right) as `float`.";
                return false;
            }
            else
            {
                result = new RealRectangle2d(top, left, bottom, right);
                error = null;
                return true;
            }
        }
    }
}
