using System.Collections.Generic;
using System.IO;
using TagTool.Cache;

namespace TagTool.Common
{
    public struct RealMatrix3x3 : IBlamType
    {
        public float m11 { get; set; }
        public float m12 { get; set; }
        public float m13 { get; set; }
        public float m21 { get; set; }
        public float m22 { get; set; }
        public float m23 { get; set; }
        public float m31 { get; set; }
        public float m32 { get; set; }
        public float m33 { get; set; }

        public bool IsIdentity =>
            (m11 == 1.0f && m12 == 0.0f && m13 == 0.0f &&
             m21 == 0.0f && m22 == 1.0f && m23 == 0.0f &&
             m31 == 0.0f && m32 == 0.0f && m33 == 1.0f);

        public static RealMatrix3x3 Identity =>
            new RealMatrix3x3(
                1.0f, 0.0f, 0.0f,
                0.0f, 1.0f, 0.0f,
                0.0f, 0.0f, 1.0f);

        public bool Equals(RealMatrix3x3 M) =>
            (m11 == M.m11 &&
             m12 == M.m12 &&
             m13 == M.m13 &&
             m21 == M.m21 &&
             m22 == M.m22 &&
             m23 == M.m23 &&
             m31 == M.m31 &&
             m32 == M.m32 &&
             m33 == M.m33 );

        public RealMatrix3x3(
            float M11, float M12, float M13,
            float M21, float M22, float M23,
            float M31, float M32, float M33)
        {
            m11 = M11; m12 = M12; m13 = M13;
            m21 = M21; m22 = M22; m23 = M23;
            m31 = M31; m32 = M32; m33 = M33;
        }

        public static RealMatrix3x3 operator *(RealMatrix3x3 matrix1, RealMatrix3x3 matrix2)
        {
            if (matrix1.IsIdentity) return matrix2;
            if (matrix2.IsIdentity) return matrix1;

            return new RealMatrix3x3(
                matrix1.m11 * matrix2.m11 + matrix1.m12 * matrix2.m21 +
                matrix1.m13 * matrix2.m31,
                matrix1.m11 * matrix2.m12 + matrix1.m12 * matrix2.m22 +
                matrix1.m13 * matrix2.m32,
                matrix1.m11 * matrix2.m13 + matrix1.m12 * matrix2.m23 +
                matrix1.m13 * matrix2.m33,
                matrix1.m21 * matrix2.m11 + matrix1.m22 * matrix2.m21 +
                matrix1.m23 * matrix2.m31,
                matrix1.m21 * matrix2.m12 + matrix1.m22 * matrix2.m22 +
                matrix1.m23 * matrix2.m32,
                matrix1.m21 * matrix2.m13 + matrix1.m22 * matrix2.m23 +
                matrix1.m23 * matrix2.m33,
                matrix1.m31 * matrix2.m11 + matrix1.m32 * matrix2.m21 +
                matrix1.m33 * matrix2.m31,
                matrix1.m31 * matrix2.m12 + matrix1.m32 * matrix2.m22 +
                matrix1.m33 * matrix2.m32,
                matrix1.m31 * matrix2.m13 + matrix1.m32 * matrix2.m23 +
                matrix1.m33 * matrix2.m33);
        }

        public static RealVector3d operator *(RealMatrix3x3 matrix, RealVector3d vector)
        {
            if (matrix.IsIdentity) return vector;

            return new RealVector3d(
                matrix.m11 * vector.I + matrix.m12 * vector.J + matrix.m13 * vector.K,
                matrix.m21 * vector.I + matrix.m22 * vector.J + matrix.m23 * vector.K,
                matrix.m31 * vector.I + matrix.m32 * vector.J + matrix.m33 * vector.K);
        }

        public static RealPoint3d operator *(RealMatrix3x3 matrix, RealPoint3d point)
        {
            if (matrix.IsIdentity) return point;

            return new RealPoint3d(
                matrix.m11 * point.X + matrix.m12 * point.Y + matrix.m13 * point.Z,
                matrix.m21 * point.X + matrix.m22 * point.Y + matrix.m23 * point.Z,
                matrix.m31 * point.X + matrix.m32 * point.Y + matrix.m33 * point.Z);
        }

        public static RealMatrix3x3 Read(BinaryReader reader) =>
            new RealMatrix3x3(
                reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(),
                reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(),
                reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

        public override string ToString() => $"{{ " +
            $"{m11}, {m12}, {m13} |" +
            $"{m21}, {m22}, {m23} |" +
            $"{m31}, {m32}, {m33} }}";

        public bool TryParse(GameCache cache, List<string> args, out IBlamType result, out string error)
        {
            result = null;

            if (args.Count != 9)
            {
                error = $"{args.Count} arguments supplied; should be 9";
                return false;
            }
            else if (!float.TryParse(args[0], out float M11))
            {
                error = $"Unable to parse \"{args[0]}\" (M11) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[1], out float M12))
            {
                error = $"Unable to parse \"{args[1]}\" (M12) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[2], out float M13))
            {
                error = $"Unable to parse \"{args[2]}\" (M13) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[3], out float M21))
            {
                error = $"Unable to parse \"{args[3]}\" (M21) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[4], out float M22))
            {
                error = $"Unable to parse \"{args[4]}\" (M22) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[5], out float M23))
            {
                error = $"Unable to parse \"{args[5]}\" (M23) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[6], out float M31))
            {
                error = $"Unable to parse \"{args[6]}\" (M31) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[7], out float M32))
            {
                error = $"Unable to parse \"{args[7]}\" (M32) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[8], out float M33))
            {
                error = $"Unable to parse \"{args[8]}\" (M33) as `float`.";
                return false;
            }
            else
            {
                result = new RealMatrix3x3(
                    M11, M12, M13,
                    M21, M22, M23,
                    M31, M32, M33);

                error = null;
                return true;
            }
        }
    }
}
