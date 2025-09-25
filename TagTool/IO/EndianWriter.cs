using System;
using System.Buffers.Binary;
using System.IO;
using System.Linq;
using System.Text;

namespace TagTool.IO
{
    public class EndianWriter : BinaryWriter
    {
        public EndianFormat Format { get; set; }
        
        public EndianWriter(Stream stream, EndianFormat format = EndianFormat.LittleEndian)
            : base(stream)
        {
            Format = format;
        }

        public EndianWriter(Stream stream, bool leaveOpen, EndianFormat format = EndianFormat.LittleEndian)
            : base(stream, Encoding.ASCII, leaveOpen)
        {
            Format = format;
        }

        public override void Write(short value) =>
            Write(value, Format);

        public override void Write(int value) =>
            Write(value, Format);

        public override void Write(long value) =>
            Write(value, Format);

        public override void Write(ushort value) =>
            Write(value, Format);

        public override void Write(uint value) =>
            Write(value, Format);

        public override void Write(ulong value) =>
            Write(value, Format);

        public override void Write(float value) =>
            Write(value, Format);

        public override void Write(double value) =>
            Write(value, Format);

        public void Write(short value, EndianFormat format)
        {
            Span<byte> buffer = stackalloc byte[sizeof(short)];
            if(format == EndianFormat.LittleEndian)
                BinaryPrimitives.WriteInt16LittleEndian(buffer, value);
            else
                BinaryPrimitives.WriteInt16BigEndian(buffer, value);
            Write(buffer);
        }

        public void Write(int value, EndianFormat format)
        {
            Span<byte> buffer = stackalloc byte[sizeof(int)];
            if (format == EndianFormat.LittleEndian)
                BinaryPrimitives.WriteInt32LittleEndian(buffer, value);
            else
                BinaryPrimitives.WriteInt32BigEndian(buffer, value);
            Write(buffer);
        }

        public void Write(long value, EndianFormat format)
        {
            Span<byte> buffer = stackalloc byte[sizeof(long)];
            if (format == EndianFormat.LittleEndian)
                BinaryPrimitives.WriteInt64LittleEndian(buffer, value);
            else
                BinaryPrimitives.WriteInt64BigEndian(buffer, value);
            Write(buffer);
        }

        public void Write(ushort value, EndianFormat format)
        {
            Span<byte> buffer = stackalloc byte[sizeof(ushort)];
            if (format == EndianFormat.LittleEndian)
                BinaryPrimitives.WriteUInt16LittleEndian(buffer, value);
            else
                BinaryPrimitives.WriteUInt16BigEndian(buffer, value);
            Write(buffer);
        }

        public void Write(uint value, EndianFormat format)
        {
            Span<byte> buffer = stackalloc byte[sizeof(uint)];
            if (format == EndianFormat.LittleEndian)
                BinaryPrimitives.WriteUInt32LittleEndian(buffer, value);
            else
                BinaryPrimitives.WriteUInt32BigEndian(buffer, value);
            Write(buffer);
        }

        public void Write(ulong value, EndianFormat format)
        {
            Span<byte> buffer = stackalloc byte[sizeof(ulong)];
            if (format == EndianFormat.LittleEndian)
                BinaryPrimitives.WriteUInt64LittleEndian(buffer, value);
            else
                BinaryPrimitives.WriteUInt64BigEndian(buffer, value);
            Write(buffer);
        }

        public void Write(float value, EndianFormat format)
        {
            Span<byte> buffer = stackalloc byte[sizeof(float)];
            if (format == EndianFormat.LittleEndian)
                BinaryPrimitives.WriteSingleLittleEndian(buffer, value);
            else
                BinaryPrimitives.WriteSingleBigEndian(buffer, value);
            Write(buffer);
        }

        public void Write(double value, EndianFormat format)
        {
            Span<byte> buffer = stackalloc byte[sizeof(double)];
            if (format == EndianFormat.LittleEndian)
                BinaryPrimitives.WriteDoubleLittleEndian(buffer, value);
            else
                BinaryPrimitives.WriteDoubleBigEndian(buffer, value);
            Write(buffer);
        }

        public void WriteBlock(byte[] data) =>
            Write(data, 0, data.Length);

        public void WriteBlock(byte[] data, int offset, int length) =>
            Write(data, offset, length);
    }
}
