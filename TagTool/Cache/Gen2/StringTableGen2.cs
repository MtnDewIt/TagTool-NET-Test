using System;
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
            var dataCount = baseMapFile.Header.GetStringIdDataCount();
            var indexOffset = baseMapFile.Header.GetStringIdIndexOffset();
            var dataOffset = baseMapFile.Header.GetStringIdDataOffset();

            reader.SeekTo(indexOffset);

            int[] stringOffset = new int[stringCount];
            for (var i = 0; i < stringCount; i++)
            {
                stringOffset[i] = reader.ReadInt32();
            }


            //
            // Read strings
            //

            reader.SeekTo(dataOffset);

            var stringsBuffer = new StringBuffer(reader.ReadBytes(dataCount));

            EnsureCapacity(stringOffset.Length);
            for (var i = 0; i < stringOffset.Length; i++)
            {
                Add(stringOffset[i] == -1 ? "<null>" : stringsBuffer.GetString(stringOffset[i]));
            }
        }


        public override StringId AddString(string newString)
        {
            throw new NotImplementedException();
        }
    }
}
