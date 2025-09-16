using System;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0x484)]
    public class BlfModPackageReference : BlfChunkHeader
    {
        [TagField(Length = 0x14)]
        public byte[] Hash;

        public ModPackageMetadata Metadata;

        public BlfModPackageReference()
        {
            Signature = new Tag("modp");
            Length = (int)typeof(BlfModPackageReference).GetSize() - (int)typeof(BlfChunkHeader).GetSize();
            MajorVersion = (short)BlfModPackageReferenceVersion.Current;
            MinorVersion = 0;
        }

        public BlfModPackageReference(BlfModPackageReferenceV1 v1) : this()
        {
            Hash = v1.Hash;
            Metadata = new ModPackageMetadata
            {
                Name = v1.Name,
                Author = v1.Author
            };
        }

        enum BlfModPackageReferenceVersion : short
        {
            Version1 = 1,
            Current = 2
        }

        [TagStructure(Size = 0x44)]
        public class BlfModPackageReferenceV1 : BlfChunkHeader
        {
            [TagField(Length = 0x10, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
            public string Name;

            [TagField(Length = 0x10)]
            public string Author;

            [TagField(Length = 0x14)]
            public byte[] Hash;
        }

        public static BlfModPackageReference Decode(TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            long start = dataContext.Reader.Position;
            dataContext.Reader.SeekTo(start - 0xC);

            BlfChunkHeader referenceHeader = (BlfChunkHeader)deserializer.Deserialize(dataContext, typeof(BlfChunkHeader));

            if (referenceHeader.MajorVersion == (short)BlfModPackageReferenceVersion.Version1)
            {
                var v1 = (BlfModPackageReferenceV1)deserializer.Deserialize(dataContext, typeof(BlfModPackageReferenceV1));
                return new BlfModPackageReference(v1); // Convert to the new format
            }
            else
            {
                return (BlfModPackageReference)deserializer.Deserialize(dataContext, typeof(BlfModPackageReference));
            }
        }

        public static void Encode(TagSerializer serializer, DataSerializationContext dataContext, BlfModPackageReference reference)
        {
            serializer.Serialize(dataContext, reference);
        }
    }
}
