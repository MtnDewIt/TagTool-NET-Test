using System;
using System.Collections.Generic;
using TagTool.Cache;

namespace TagTool.Common
{
    public struct Int32Point3d : IEquatable<Int32Point3d>, IBlamType
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Int32Point3d(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public bool Equals(Int32Point3d other) =>
            (X == other.X) &&
            (Y == other.Y) &&
            (Z == other.Z);

        public override bool Equals(object obj) =>
            obj is Int32Point3d ?
                Equals((Int32Point3d)obj) :
            false;

        public static bool operator ==(Int32Point3d a, Int32Point3d b) =>
            a.Equals(b);

        public static bool operator !=(Int32Point3d a, Int32Point3d b) =>
            !a.Equals(b);

        public override int GetHashCode() =>
            13 * 17 + X.GetHashCode()
               * 17 + Y.GetHashCode()
               * 17 + Z.GetHashCode();

        public override string ToString() =>
            $"{{ X: {X}, Y: {Y}, Z: {Z} }}";

        public bool TryParse(GameCache cache, List<string> args, out IBlamType result, out string error)
        {
            result = null;
            if (args.Count != 3)
            {
                error = $"{args.Count} arguments supplied; should be 3";
                return false;
            }
            else if (!int.TryParse(args[0], out int x))
            {
                error = $"Unable to parse \"{args[0]}\" (x) as `int`.";
                return false;
            }
            else if (!int.TryParse(args[1], out int y))
            {
                error = $"Unable to parse \"{args[1]}\" (y) as `int`.";
                return false;
            }
            else if (!int.TryParse(args[2], out int z))
            {
                error = $"Unable to parse \"{args[2]}\" (z) as `int`.";
                return false;
            }
            else
            {
                result = new Int32Point3d(x, y, z);
                error = null;
                return true;
            }
        }
    }
}
