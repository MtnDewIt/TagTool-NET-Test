using System;
using TagTool.BlamFile;
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

            var stringIDHeader = baseMapFile.Header.GetStringIDHeader();

            reader.SeekTo(stringIDHeader.IndicesOffset);

            int[] stringOffset = new int[stringIDHeader.Count];
            for (var i = 0; i < stringIDHeader.Count; i++)
            {
                stringOffset[i] = reader.ReadInt32();
            }


            //
            // Read strings
            //

            reader.SeekTo(stringIDHeader.BufferOffset);

            var stringsBuffer = new StringBuffer(reader.ReadBytes(stringIDHeader.BufferSize));

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
