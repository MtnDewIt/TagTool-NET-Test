using System.Globalization;
using System;
using TagTool.Tags;

namespace TagTool.Cache
{
    [TagStructure(Size = 0x20)]
    public class SHA256Hash : TagStructure
    {
        [TagField(Length = 32)]
        public byte[] Data;

        public bool IsInvalid()
        {
            return Array.TrueForAll(Data, b => b == 0);
        }

        public void SetHash(string hashString)
        {
            Data = new byte[32];

            var chunkSize = 2;

            var parsedString = hashString.PadLeft(64, '0');

            for (int i = 0; i < 32; i++)
            {
                int start = i * chunkSize;
                int length = Math.Min(chunkSize, parsedString.Length - start);
                Data[i] = byte.Parse(parsedString.Substring(start, length), NumberStyles.HexNumber);
            }
        }

        public override string ToString()
        {
            return Convert.ToHexString(Data);
        }
    }
}
