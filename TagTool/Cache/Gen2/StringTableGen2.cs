using System;
using System.IO;
using TagTool.BlamFile;
using TagTool.Cache.Gen2.Resolvers;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.Cache.Gen2
{
    public class StringTableGen2 : StringTable
    {
        public StringTableGen2(EndianReader reader, MapFile baseMapFile) : base()
        {
            Resolver = new StringIdResolverHalo2();

            //
            // Read offsets
            //

            var stringCount = baseMapFile.Header.GetStringIdCount();
            var indexOffset = baseMapFile.Header.GetStringIdIndexOffset();
            var dataOffset = baseMapFile.Header.GetStringIdDataOffset();

            reader.SeekTo(indexOffset);

            int[] stringOffset = new int[stringCount];
            for (var i = 0; i < stringCount; i++)
            {
                stringOffset[i] = reader.ReadInt32();
                Add("");
            }

            reader.SeekTo(dataOffset);

            EndianReader newReader = new EndianReader(new MemoryStream(reader.ReadBytes(stringCount)), reader.Format);

            //
            // Read strings
            //

            for (var i = 0; i < stringOffset.Length; i++)
            {
                if (stringOffset[i] == -1)
                {
                    this[i] = "<null>";
                    continue;
                }

                newReader.SeekTo(stringOffset[i]);
                this[i] = newReader.ReadNullTerminatedString();
            }
            newReader.Close();
            newReader.Dispose();
        }


        public override StringId AddString(string newString)
        {
            throw new NotImplementedException();
        }
    }
}
