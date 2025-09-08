using System.Collections.Generic;
using System.IO;
using TagTool.Cache;

namespace TagTool.Common
{
    public struct RealMatrix4x4 : IBlamType
    {
        public float m11 { get; set; }
        public float m12 { get; set; }
        public float m13 { get; set; }
        public float m14 { get; set; }
        public float m21 { get; set; }
        public float m22 { get; set; }
        public float m23 { get; set; }
        public float m24 { get; set; }
        public float m31 { get; set; }
        public float m32 { get; set; }
        public float m33 { get; set; }
        public float m34 { get; set; }
        public float m41 { get; set; }
        public float m42 { get; set; }
        public float m43 { get; set; }
        public float m44 { get; set; }

        public bool IsIdentity =>
            (m11 == 1.0f && m12 == 0.0f && m13 == 0.0f && m14 == 0.0f &&
             m21 == 0.0f && m22 == 1.0f && m23 == 0.0f && m24 == 0.0f &&
             m31 == 0.0f && m32 == 0.0f && m33 == 1.0f && m34 == 0.0f &&
             m41 == 0.0f && m42 == 0.0f && m43 == 0.0f && m44 == 1.0f);

        public static RealMatrix4x4 Identity =>
            new RealMatrix4x4(
                1.0f, 0.0f, 0.0f, 0.0f,
                0.0f, 1.0f, 0.0f, 0.0f,
                0.0f, 0.0f, 1.0f, 0.0f,
                0.0f, 0.0f, 0.0f, 1.0f);

        public bool Equals(RealMatrix4x4 M) =>
            (m11 == M.m11 &&
             m12 == M.m12 &&
             m13 == M.m13 &&
             m14 == M.m14 &&
             m21 == M.m21 &&
             m22 == M.m22 &&
             m23 == M.m23 &&
             m24 == M.m24 &&
             m31 == M.m31 &&
             m32 == M.m32 &&
             m33 == M.m33 &&
             m34 == M.m34 &&
             m41 == M.m41 && 
             m42 == M.m42 &&
             m43 == M.m43 && 
             m44 == M.m44);

        public RealMatrix4x4(
            float M11, float M12, float M13, float M14,
            float M21, float M22, float M23, float M24,
            float M31, float M32, float M33, float M34,
            float M41, float M42, float M43, float M44)
        {
            m11 = M11; m12 = M12; m13 = M13; m14 = M14;
            m21 = M21; m22 = M22; m23 = M23; m24 = M24;
            m31 = M31; m32 = M32; m33 = M33; m34 = M34;
            m41 = M41; m42 = M42; m43 = M43; m44 = M44;
        }

        public static RealMatrix4x4 Read(BinaryReader reader) =>
            new RealMatrix4x4(
                reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(),
                reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(),
                reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(),
                reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

        public override string ToString() => $"{{ " +
            $"{m11}, {m12}, {m13}, {m14}|" +
            $"{m21}, {m22}, {m23}, {m24}|" +
            $"{m31}, {m32}, {m33}, {m34}|" + 
            $"{m41}, {m42}, {m43}, {m44}";

        public bool TryParse(GameCache cache, List<string> args, out IBlamType result, out string error)
        {
            result = null;

            if (args.Count != 12)
            {
                error = $"{args.Count} arguments supplied; should be 12";
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
            else if (!float.TryParse(args[3], out float M14)) 
            {
                error = $"Unable to parse \"{args[3]}\" (M14) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[4], out float M21))
            {
                error = $"Unable to parse \"{args[4]}\" (M21) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[5], out float M22))
            {
                error = $"Unable to parse \"{args[5]}\" (M22) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[6], out float M23))
            {
                error = $"Unable to parse \"{args[6]}\" (M23) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[7], out float M24))
            {
                error = $"Unable to parse \"{args[7]}\" (M24) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[8], out float M31))
            {
                error = $"Unable to parse \"{args[8]}\" (M31) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[9], out float M32))
            {
                error = $"Unable to parse \"{args[9]}\" (M32) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[10], out float M33))
            {
                error = $"Unable to parse \"{args[10]}\" (M33) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[11], out float M34))
            {
                error = $"Unable to parse \"{args[11]}\" (M34) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[12], out float M41))
            {
                error = $"Unable to parse \"{args[12]}\" (M41) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[13], out float M42))
            {
                error = $"Unable to parse \"{args[13]}\" (M42) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[14], out float M43))
            {
                error = $"Unable to parse \"{args[14]}\" (M43) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[15], out float M44))
            {
                error = $"Unable to parse \"{args[15]}\" (M44) as `float`.";
                return false;
            }
            else
            {
                result = new RealMatrix4x4(
                    M11, M12, M13, M14,
                    M21, M22, M23, M24,
                    M31, M32, M33, M34,
                    M41, M42, M43, M44);

                error = null;
                return true;
            }
        }
    }
}
