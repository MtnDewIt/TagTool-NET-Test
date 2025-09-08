using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using TagTool.Cache;
using TagTool.Common;
using TagTool.IO;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks.Megalo
{
    [TagStructure(Size = 0x1208, MinVersion = CacheVersion.HaloReach)]
    public class SingleLanguageStringTable : TagStructure
    {
        public SingleLanguageStringBuffer StringBuffer;

        [TagField(Length = 256, MinVersion = CacheVersion.HaloReach)]
        public ushort[] StringIndices;

        public int StringCount;

        [TagStructure(Size = 0x1004, MinVersion = CacheVersion.HaloReach)]
        public class SingleLanguageStringBuffer : TagStructure 
        {
            [TagField(Length = 4096, MinVersion = CacheVersion.HaloReach)]
            public byte[] Buffer;

            public int Size;
        }

        public static SingleLanguageStringTable Decode(BitStreamReader bitstream)
        {
            var stringTable = new SingleLanguageStringTable();

            stringTable.StringCount = (int)bitstream.ReadUnsigned(9);

            if (stringTable.StringCount > 0) 
            {
                stringTable.StringIndices = new ushort[stringTable.StringCount];

                for (int i = 0; i < stringTable.StringCount; i++)
                {
                    if (bitstream.ReadBool())
                        stringTable.StringIndices[i] = (ushort)bitstream.ReadUnsigned(12);
                }

                stringTable.StringBuffer = new SingleLanguageStringBuffer();

                stringTable.StringBuffer.Size = (int)bitstream.ReadUnsigned(13);

                if (bitstream.ReadBool())
                {
                    int compressedSize = (int)bitstream.ReadUnsigned(13);
                    bitstream.ReadBytes(6); // skip header
                    stringTable.StringBuffer.Buffer = bitstream.ReadBytes(compressedSize - 6);
                    stringTable.StringBuffer.Buffer = Decompress(stringTable.StringBuffer.Buffer);
                }
                else
                {
                    stringTable.StringBuffer.Buffer = bitstream.ReadBytes(stringTable.StringBuffer.Size);
                }
            }

            return stringTable;
        }

        public static void Encode(BitStreamWriter stream, SingleLanguageStringTable stringTable) 
        {
            // TODO: Implement
        }

        public static byte[] Decompress(byte[] compressed)
        {
            using (var stream = new DeflateStream(new MemoryStream(compressed), CompressionMode.Decompress))
            {
                var outStream = new MemoryStream();
                stream.CopyTo(outStream);
                return outStream.ToArray();
            }
        }

        public static List<string> GetStrings(SingleLanguageStringTable stringTable) 
        {
            var strings = new List<string>();

            var reader = new EndianReader(new MemoryStream(stringTable.StringBuffer.Buffer));

            for (int i = 0; i < stringTable.StringCount; i++)
            {
                reader.SeekTo(stringTable.StringIndices[i]);
                strings.Add(reader.ReadNullTerminatedString());
            }

            return strings;
        }
    }
}
