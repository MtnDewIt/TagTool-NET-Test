using System.Linq;
using TagTool.Tags;

namespace TagTool.Cache
{
    [TagStructure(Size = 0x20)]
    public class FileCreator
    {
        [TagField(Length = 0x20)]
        public byte[] Data;

        private static readonly byte[] FileCreatorKey = new byte[64]
        {
            0x05, 0x11, 0x6A, 0xA3, 0xCA, 0xB5, 0x07, 0xDF, 0x50, 0xE7,
            0x5B, 0x75, 0x6B, 0x4A, 0xBB, 0xF4, 0xE8, 0x54, 0x8F, 0xC6,
            0xD6, 0xCC, 0x92, 0x15, 0x97, 0xDC, 0xF5, 0xEE, 0xB9, 0x3C,
            0x01, 0x3C, 0x95, 0xCF, 0xB8, 0x58, 0x5A, 0x6F, 0x2E, 0xB9,
            0x30, 0x6D, 0x89, 0x31, 0x2F, 0x83, 0x6F, 0xF0, 0x9F, 0xE8,
            0x37, 0x78, 0xE4, 0xC7, 0xE2, 0x2B, 0x19, 0x66, 0x11, 0x06,
            0x77, 0x24, 0x74, 0x66
        };

        public static string GetCreator(byte[] author)
        {
            char[] creatorString = new char[32];

            author.CopyTo(creatorString, 0);

            for (int i = 0; i < 32; i++)
            {
                creatorString[i] ^= (char)FileCreatorKey[i];
            }

            return new string(creatorString.Where(c => c != 0).ToArray());
        }

        public static byte[] SetCreator(string author)
        {
            char[] creatorArray = new char[32];

            author.ToCharArray().CopyTo(creatorArray, 0);

            for (int i = 0; i < 32; i++)
                creatorArray[i] ^= (char)FileCreatorKey[i];

            byte[] authorBytes = new byte[32];

            for (int i = 0; i < 32; i++)
                authorBytes[i] = (byte)creatorArray[i];

            return authorBytes;
        }
    }
}
