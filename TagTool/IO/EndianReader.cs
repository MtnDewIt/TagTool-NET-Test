using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using TagTool.Extensions;

namespace TagTool.IO
{
    public class EndianReader : BinaryReader
    {
        public EndianFormat Format;
        public long StreamOrigin;

        /// <summary>
        /// Creates a new instance of the EndianReader class.
        /// </summary>
        /// <param name="Stream">The Stream to read from.</param>
        /// <param name="Type">The default EndianFormat the EndianReader will use.</param>
        public EndianReader(Stream Stream, EndianFormat Type = EndianFormat.LittleEndian)
            : base(Stream, Encoding.ASCII)
        {
            Format = Type;
            StreamOrigin = 0;
        }

        /// <summary>
        /// Creates a new instance of the EndianReader class.
        /// </summary>
        /// <param name="Stream">The Stream to read from.</param>
        /// <param name="leaveOpen">Whether to leave the underlying stream open.</param>
        /// <param name="Type">The default EndianFormat the EndianReader will use.</param>
        public EndianReader(Stream Stream, bool leaveOpen, EndianFormat Type = EndianFormat.LittleEndian)
            : base(Stream, Encoding.ASCII, leaveOpen)
        {
            Format = Type;
            StreamOrigin = 0;
        }

        #region Param-less Overrides
        /// <summary>
        /// Reads a Double value in the EndianReader's default EndianFormat.
        /// </summary>
        /// <returns></returns>
        public override double ReadDouble()
        {
            return ReadDouble(Format);
        }

        /// <summary>
        /// Reads an Int16 value in the EndianReader's default EndianFormat.
        /// </summary>
        /// <returns></returns>
        public override short ReadInt16()
        {
            return ReadInt16(Format);
        }

        /// <summary>
        /// Reads an Int32 value in the EndianReader's default EndianFormat.
        /// </summary>
        /// <returns></returns>
        public override int ReadInt32()
        {
            return ReadInt32(Format);
        }

        /// <summary>
        /// Reads an Int64 value in the EndianReader's default EndianFormat.
        /// </summary>
        /// <returns></returns>
        public override long ReadInt64()
        {
            return ReadInt64(Format);
        }

        /// <summary>
        /// Reads a Single value in the EndianReader's default EndianFormat.
        /// </summary>
        /// <returns></returns>
        public override float ReadSingle()
        {
            return ReadSingle(Format);
        }

        /// <summary>
        /// Reads a UInt16 value in the EndianReader's default EndianFormat.
        /// </summary>
        /// <returns></returns>
        public override ushort ReadUInt16()
        {
            return ReadUInt16(Format);
        }

        /// <summary>
        /// Reads a UInt32 value in the EndianReader's default EndianFormat.
        /// </summary>
        /// <returns></returns>
        public override uint ReadUInt32()
        {
            return ReadUInt32(Format);
        }

        /// <summary>
        /// Reads a UInt64 value in the EndianReader's default EndianFormat.
        /// </summary>
        /// <returns></returns>
        public override ulong ReadUInt64()
        {
            return ReadUInt64(Format);
        }
        #endregion

        #region EndianFormat Overloads
        /// <summary>
        /// Reads a Double value in the specified EndianFormat.
        /// </summary>
        /// <param name="Type">The EndianFormat of the value.</param>
        /// <returns></returns>
        public double ReadDouble(EndianFormat Type)
        {
            if (Type == EndianFormat.LittleEndian)
                return base.ReadDouble();

            Span<byte> buffer = stackalloc byte[sizeof(double)];
            Read(buffer);
            return BinaryPrimitives.ReadDoubleBigEndian(buffer);
        }

        /// <summary>
        /// Reads an Int16 value in the specified EndianFormat.
        /// </summary>
        /// <param name="Type">The EndianFormat of the value.</param>
        /// <returns></returns>
        public short ReadInt16(EndianFormat Type)
        {
            if (Type == EndianFormat.LittleEndian)
                return base.ReadInt16();

            Span<byte> buffer = stackalloc byte[sizeof(short)];
            Read(buffer);
            return BinaryPrimitives.ReadInt16BigEndian(buffer);
        }

        /// <summary>
        /// Reads an Int32 value in the specified EndianFormat.
        /// </summary>
        /// <param name="Type">The EndianFormat of the value.</param>
        /// <returns></returns>
        public int ReadInt32(EndianFormat Type)
        {
            if (Type == EndianFormat.LittleEndian)
                return base.ReadInt32();

            Span<byte> buffer = stackalloc byte[sizeof(int)];
            Read(buffer);
            return BinaryPrimitives.ReadInt32BigEndian(buffer);
        }

        /// <summary>
        /// Reads an Int64 value in the specified EndianFormat.
        /// </summary>
        /// <param name="Type">The EndianFormat of the value.</param>
        /// <returns></returns>
        public long ReadInt64(EndianFormat Type)
        {
            if (Type == EndianFormat.LittleEndian)
                return base.ReadInt64();

            Span<byte> buffer = stackalloc byte[sizeof(long)];
            Read(buffer);
            return BinaryPrimitives.ReadInt64BigEndian(buffer);
        }

        /// <summary>
        /// Reads a Single value in the specified EndianFormat.
        /// </summary>
        /// <param name="Type">The EndianFormat of the value.</param>
        /// <returns></returns>
        public float ReadSingle(EndianFormat Type)
        {
            if (Type == EndianFormat.LittleEndian)
                return base.ReadSingle();

            Span<byte> buffer = stackalloc byte[sizeof(float)];
            Read(buffer);
            return BinaryPrimitives.ReadSingleBigEndian(buffer);
        }

        /// <summary>
        /// Reads a UInt16 value in the specified EndianFormat.
        /// </summary>
        /// <param name="Type">The EndianFormat of the value.</param>
        /// <returns></returns>
        public ushort ReadUInt16(EndianFormat Type)
        {
            if (Type == EndianFormat.LittleEndian)
                return base.ReadUInt16();

            Span<byte> buffer = stackalloc byte[sizeof(ushort)];
            Read(buffer);
            return BinaryPrimitives.ReadUInt16BigEndian(buffer);
        }

        /// <summary>
        /// Reads a UInt32 value in the specified EndianFormat.
        /// </summary>
        /// <param name="Type">The EndianFormat of the value.</param>
        /// <returns></returns>
        public uint ReadUInt32(EndianFormat Type)
        {
            if (Type == EndianFormat.LittleEndian)
                return base.ReadUInt32();

            Span<byte> buffer = stackalloc byte[sizeof(uint)];
            Read(buffer);
            return BinaryPrimitives.ReadUInt32BigEndian(buffer);
        }

        /// <summary>
        /// Reads a UInt64 value in the specified EndianFormat.
        /// </summary>
        /// <param name="Type">The EndianFormat of the value.</param>
        /// <returns></returns>
        public ulong ReadUInt64(EndianFormat Type)
        {
            if (Type == EndianFormat.LittleEndian)
                return base.ReadUInt64();

            Span<byte> buffer = stackalloc byte[sizeof(ulong)];
            Read(buffer);
            return BinaryPrimitives.ReadUInt64BigEndian(buffer);
        }
        #endregion

        #region Read String
        /// <summary>
        /// Reads a UTF8 string of specified length.
        /// </summary>
        /// <param name="Length">The number of characters to read into the string.</param>
        /// <param name="Trim">Weather to trim white-space from the string. Defaults to true.</param>
        /// <returns></returns>
        public string ReadString(int Length, bool Trim = true)
        {
            string str = Encoding.UTF8.GetString(ReadBytes(Length));
            int nullTermIndex = str.AsSpan().IndexOf('\0');
            return nullTermIndex < 0 ? str : str[..nullTermIndex];
        }

        /// <summary>
        /// Reads a null-terminated UTF8 string of indefinite length.
        /// </summary>
        /// <returns></returns>
        public string ReadNullTerminatedString()
        {
            var bytes = new List<byte>();
            byte b;
            while ((b = ReadByte()) != 0)
                bytes.Add(b);

            return Encoding.UTF8.GetString(CollectionsMarshal.AsSpan(bytes));
        }

        /// <summary>
        /// Reads a null-terminated UTF8 string of length up to MaxLength and advances the stream position by MaxLength bytes.
        /// </summary>
        /// <param name="MaxLength">The maximum number of characters to read.</param>
        /// <param name="charSet"></param>
        /// <returns></returns>
        public string ReadNullTerminatedString(int MaxLength, CharSet charSet = CharSet.Ansi)
        {
            int size = charSet == CharSet.Ansi ? MaxLength : MaxLength * 2;
            byte[] buffer = ArrayPool<byte>.Shared.Rent(size);
            Read(buffer, 0, size);

            string str;
            if (charSet == CharSet.Ansi)
                str = Encoding.UTF8.GetString(buffer);
            else if (charSet == CharSet.Unicode)
                if(Format == EndianFormat.LittleEndian)
                    str = Encoding.Unicode.GetString(buffer);
                else
                    str = Encoding.BigEndianUnicode.GetString(buffer);
            else
                str = "";

            ArrayPool<byte>.Shared.Return(buffer);

            var nullTermIndex = str.IndexOf('\0');
            return nullTermIndex < 0 ? str : str[..nullTermIndex];
        }
        #endregion

        /// <summary>
        /// Returns the next BigEndian UInt16 and does not advance the stream position.
        /// </summary>
        /// <returns></returns>
        public ushort PeekUInt16()
        {
            return PeekUInt16(EndianFormat.BigEndian);
        }

        /// <summary>
        /// Returns the next UInt16 and does not advance the stream position.
        /// </summary>
        /// <param name="Type">The EndianFormat of the value.</param>
        /// <returns></returns>
        public ushort PeekUInt16(EndianFormat Type)
        {
            ushort val;

            if (Type == EndianFormat.LittleEndian)
                val = base.ReadUInt16();
            else
            {
                Span<byte> buffer = stackalloc byte[sizeof(ushort)];
                BaseStream.ReadExactly(buffer);
                val = BinaryPrimitives.ReadUInt16BigEndian(buffer);
            }

            Skip(-2);
            return val;
        }

        /// <summary>
        /// Decrypts a segment of an EndianReader stream.
        /// </summary>
        /// <param name="length">The number of bytes to decrypt.</param>
        /// <param name="key">The decryption key as a string.</param>
        /// <returns>A new byte array containing the decrypted segment.</returns>
        public byte[] DecryptAesSegment(int length, string key)
        {
            if (length % 16 != 0)
                length += 16 - (length % 16);

            var data = ReadBytes(length);
            var bKey = Encoding.ASCII.GetBytes(key);
            var xor = new byte[bKey.Length];
            var iv = new byte[bKey.Length];

            for (int i = 0; i < bKey.Length; i++)
            {
                xor[i] = (byte)(bKey[i] ^ 0xFFA5);
                iv[i] = (byte)(xor[i] ^ 0x3C);
            }

            var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Key = xor;
            aes.IV = iv;
            aes.Padding = PaddingMode.Zeros;

            return aes.CreateDecryptor(aes.Key, aes.IV).TransformFinalBlock(data, 0, data.Length);
        }

        public int ReadBlock(byte[] buffer, int offset, int size)
        {
            base.BaseStream.ReadExactly(buffer, offset, size);
            return size;
        }

        public void SeekTo(long offset)
        {
            BaseStream.Seek(StreamOrigin + offset, SeekOrigin.Begin);
        }

        public void Skip(long count)
        {
            BaseStream.Seek(count, SeekOrigin.Current);
        }

        public long Position
        {
            get { return BaseStream.Position - StreamOrigin; }
        }

        public long Length
        {
            get { return BaseStream.Length - StreamOrigin; }
        }

        public bool EOF
        {
            get { return Position >= Length; }
        }
    }
}
