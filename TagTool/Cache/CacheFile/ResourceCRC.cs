using System.Globalization;
using System;
using TagTool.Tags;

namespace TagTool.Cache
{
    [TagStructure(Size = 0x4)]
    public class ResourceCRC
    {
        [TagField(Length = 4)]
        public byte[] Data;

        public bool IsInvalid()
        {
            return Array.TrueForAll(Data, b => b == 0);
        }

        public void SetCRC(string crcString)
        {
            Data = new byte[4];

            var chunkSize = 2;

            var parsedString = crcString.PadLeft(8, '0');

            for (int i = 0; i < 4; i++)
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
