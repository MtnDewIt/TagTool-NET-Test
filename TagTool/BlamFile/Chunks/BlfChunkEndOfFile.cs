using TagTool.Cache;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0x5, Align = 0x1)]
    public class BlfChunkEndOfFile : BlfChunkHeader
    {
        public int AuthenticationDataSize;
        public BlfAuthenticationType AuthenticationType;

        public enum BlfAuthenticationType : byte
        {
            None,
            CRC,
            SHA1,
            RSA
        }

        public static BlfChunkEndOfFile Decode(EndianReader reader, TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            var position = reader.Position;

            var endOfFile = (BlfChunkEndOfFile)deserializer.Deserialize(dataContext, typeof(BlfChunkEndOfFile));

            switch (endOfFile.AuthenticationType)
            {
                case BlfAuthenticationType.None:
                    break;
                case BlfAuthenticationType.CRC:
                    reader.SeekTo(position);
                    endOfFile = (BlfEndOfFileCRC)deserializer.Deserialize(dataContext, typeof(BlfEndOfFileCRC));
                    break;
                case BlfAuthenticationType.RSA:
                    reader.SeekTo(position);
                    endOfFile = (BlfEndOfFileRSA)deserializer.Deserialize(dataContext, typeof(BlfEndOfFileRSA));
                    break;
                case BlfAuthenticationType.SHA1:
                    reader.SeekTo(position);
                    endOfFile = (BlfEndOfFileSHA1)deserializer.Deserialize(dataContext, typeof(BlfEndOfFileSHA1));
                    break;
            }

            return endOfFile;
        }

        public static void Encode(TagSerializer serializer, DataSerializationContext dataContext, BlfChunkEndOfFile endOfFile)
        {
            switch (endOfFile.AuthenticationType)
            {
                case BlfAuthenticationType.None:
                    serializer.Serialize(dataContext, endOfFile);
                    break;
                case BlfAuthenticationType.CRC:
                    serializer.Serialize(dataContext, endOfFile as BlfEndOfFileCRC);
                    break;
                case BlfAuthenticationType.RSA:
                    serializer.Serialize(dataContext, endOfFile as BlfEndOfFileRSA);
                    break;
                case BlfAuthenticationType.SHA1:
                    serializer.Serialize(dataContext, endOfFile as BlfEndOfFileSHA1);
                    break;
            }
        }
    }

    [TagStructure(Size = 0x4, Align = 0x1)]
    public class BlfEndOfFileCRC : BlfChunkEndOfFile
    {
        public BlfCRCChecksum Checksum;

        [TagStructure(Size = 0x4, Align = 0x1)]
        public class BlfCRCChecksum
        {
            public uint Checksum;
        }
    }

    [TagStructure(Size = 0x100, Align = 0x1)]
    public class BlfEndOfFileSHA1 : BlfChunkEndOfFile
    {
        public BlfSHA1Hash Hash;

        [TagStructure(Size = 0x100, Align = 0x1)]
        public class BlfSHA1Hash
        {
            [TagField(Length = 0x100)]
            public byte[] Hash;
        }
    }

    [TagStructure(Size = 0x100, Align = 0x1)]
    public class BlfEndOfFileRSA : BlfChunkEndOfFile
    {
        public RSASignature RSASignature;
    }
}
