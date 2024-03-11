using System.Collections;
using System.Linq;
using System.Runtime.InteropServices;
using TagTool.Common;
using TagTool.Tags;

namespace System.IO
{
    public static class BinaryReaderExtensions
    {
        public static float ReadSingle(this BinaryReader reader, TagFieldCompression compression)
        {
            switch (compression)
            {
                case TagFieldCompression.Int8:
                    return (float)reader.ReadSByte() / sbyte.MaxValue;

                case TagFieldCompression.Int16:
                    return (float)reader.ReadInt16() / short.MaxValue;

                default:
                    return reader.ReadSingle();
            }
        }

        public static Half ReadHalf(this BinaryReader reader) =>
            BitConverter.UInt16BitsToHalf(reader.ReadUInt16());

        public static Point2d ReadPoint2d(this BinaryReader reader) =>
            new Point2d(reader.ReadInt16(), reader.ReadInt16());

        public static Rectangle2d ReadRectangle2d(this BinaryReader reader) =>
            new Rectangle2d(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());

        public static ArgbColor ReadRgbaColor(this BinaryReader reader) =>
            new ArgbColor(reader.ReadByte(), reader.ReadByte(), reader.ReadByte(), reader.ReadByte());

        public static ArgbColor ReadArgbColor(this BinaryReader reader) =>
            new ArgbColor(reader.ReadByte(), reader.ReadByte(), reader.ReadByte(), reader.ReadByte());

        public static Angle ReadAngleRadians(this BinaryReader reader) =>
            Angle.FromRadians(reader.ReadSingle());

        public static Angle ReadAngleDegrees(this BinaryReader reader) =>
            Angle.FromDegrees(reader.ReadSingle());

        public static RealPoint2d ReadRealPoint2d(this BinaryReader reader) =>
            new RealPoint2d(reader.ReadSingle(), reader.ReadSingle());

        public static RealPoint3d ReadRealPoint3d(this BinaryReader reader) =>
            new RealPoint3d(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

        public static RealVector2d ReadRealVector2d(this BinaryReader reader) =>
            new RealVector2d(reader.ReadSingle(), reader.ReadSingle());

        public static RealVector3d ReadRealVector3d(this BinaryReader reader) =>
            new RealVector3d(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

        public static RealQuaternion ReadRealQuaternion(this BinaryReader reader) =>
            new RealQuaternion(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

        public static RealEulerAngles2d ReadRealEulerAngles2d(this BinaryReader reader) =>
            new RealEulerAngles2d(reader.ReadAngleRadians(), reader.ReadAngleRadians());

        public static RealEulerAngles3d ReadRealEulerAngles3d(this BinaryReader reader) =>
            new RealEulerAngles3d(reader.ReadAngleRadians(), reader.ReadAngleRadians(), reader.ReadAngleRadians());

        public static RealPlane2d ReadRealPlane2d(this BinaryReader reader) =>
            new RealPlane2d(reader.ReadRealVector2d(), reader.ReadSingle());

        public static RealPlane3d ReadRealPlane3d(this BinaryReader reader) =>
            new RealPlane3d(reader.ReadRealVector3d(), reader.ReadSingle());

        public static RealRgbColor ReadRealRgbColor(this BinaryReader reader) =>
            new RealRgbColor(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

        public static RealArgbColor ReadRealArgbColor(this BinaryReader reader) =>
            new RealArgbColor(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

        public static Tag ReadTag(this BinaryReader reader) =>
            new Tag(reader.ReadInt32());

        public static StringId ReadStringId(this BinaryReader reader) =>
            new StringId(reader.ReadUInt32());

        public static DatumHandle ReadDatumIndex(this BinaryReader reader) =>
            new DatumHandle(reader.ReadUInt32());
    }
}
