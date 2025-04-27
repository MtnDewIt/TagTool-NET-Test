using System;
using System.Globalization;
using TagTool.Tags;

namespace TagTool.Cache
{
    [TagStructure(Size = 0x14)]
    public class NetworkRequestHash
    {
        [TagField(Length = 20)]
        public byte[] Data;

        public string GetHash()
        {
            return BitConverter.ToString(Data).Replace("-", "");
        }

        public void SetHash(string hashString)
        {
            Data = new byte[20];

            var chunkSize = 2;

            var parsedString = hashString.PadLeft(40, '0');

            for (int i = 0; i < 20; i++)
            {
                int start = i * chunkSize;
                int length = Math.Min(chunkSize, parsedString.Length - start);
                Data[i] = byte.Parse(parsedString.Substring(start, length), NumberStyles.HexNumber);
            }
        }
    }
}
