using System;
using System.Globalization;
using TagTool.Tags;

namespace TagTool.Cache
{
    [TagStructure(Size = 0x100)]
    public class RSASignature
    {
        [TagField(Length = 256)]
        public byte[] Data;

        public bool IsInvalid()
        {
            return Array.TrueForAll(Data, b => b == 0);
        }

        public void SetSignature(string signatureString)
        {
            Data = new byte[256];

            var chunkSize = 2;

            var parsedString = signatureString.PadLeft(512, '0');

            for (int i = 0; i < 256; i++)
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
