﻿using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using TagTool.Cache;
using TagTool.Common;
using TagTool.IO;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks.Megalo
{
    [TagStructure(Size = 0xC, MinVersion = CacheVersion.HaloReach)]
    public class MegaloStringTable : TagStructure
    {
        public List<string> Strings = new List<string>();

        public static MegaloStringTable Decode(BitStream bitstream)
        {
            var stringTable = new MegaloStringTable();

            int stringCount = (int)bitstream.ReadUnsigned(9);

            if (stringCount > 0) 
            {
                var offsets = new ushort[stringCount];
                for (int i = 0; i < stringCount; i++)
                {
                    if (bitstream.ReadBool())
                        offsets[i] = (ushort)bitstream.ReadUnsigned(12);
                }

                int bufferSize = (int)bitstream.ReadUnsigned(13);

                byte[] data;
                if (bitstream.ReadBool())
                {
                    int compressedSize = (int)bitstream.ReadUnsigned(13);
                    bitstream.ReadBytes(6); // skip header
                    data = bitstream.ReadBytes(compressedSize - 6);
                    data = Decompress(data);
                }
                else
                {
                    data = bitstream.ReadBytes(bufferSize);
                }

                var reader = new EndianReader(new MemoryStream(data));
                for (int i = 0; i < stringCount; i++)
                {
                    reader.SeekTo(offsets[i]);
                    stringTable.Strings.Add(reader.ReadNullTerminatedString());
                }
            }

            return stringTable;
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
    }
}
