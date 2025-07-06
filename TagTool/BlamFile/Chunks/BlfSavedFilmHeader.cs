using System.IO;
using TagTool.BlamFile.Game;
using TagTool.Cache;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0xFE60, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0xFC74, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
    [TagStructure(Size = 0x1F00C, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x1F514, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
    [TagStructure(Size = 0x2DFF4, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x2D4D4, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC)]
    public class BlfSavedFilmHeader : BlfChunkHeader
    {
        [TagField(Length = 0xFC74, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
        [TagField(Length = 0x1F00C, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        [TagField(Length = 0x1F514, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        [TagField(Length = 0x2DFF4, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        [TagField(Length = 0x2D4D4, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC)]
        public byte[] UnknownData;

        [TagField(Length = 0xFE60, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public SavedFilmHeader Header;

        [TagStructure(Size = 0xFE60, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public class SavedFilmHeader : TagStructure 
        {
            [TagField(Length = 0x4)]
            public byte[] Padding1;

            [TagField(Length = 0x20)]
            public string BuildNumber;

            public ExecutableType ExecutableType;
            public int NetworkExecutableVersion;
            public int NetworkCompatibleVersion;
            public GameLanguage MapLanguage;
            public int MapMinorVersion;
            public bool MapMinorVersionIsTracked;

            [TagField(Length = 0xB)]
            public byte[] Padding2;

            public int MapSignatureSize;

            [TagField(Length = 0x3C)]
            public byte[] MapSignatureBytes;

            public bool IsHostFilm;
            public bool ContainsGamestate;
            public bool IsSnippet;

            [TagField(Length = 0x5)]
            public byte[] Padding3;

            [TagField(Length = 0x80, CharSet = CharSet.Ansi)]
            public string SessionId;

            public GameOptions Options;

            public int RecordedTime;
            public int LengthInTicks;
            public int SnippetStartTick;

            [TagField(Length = 0x538)]
            public byte[] PaddingToAlignForUtilityDrive;
        }

        public static BlfSavedFilmHeader Decode(EndianReader reader, TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            if (CacheVersionDetection.IsBetween(deserializer.Version, CacheVersion.Halo3Retail, CacheVersion.Halo3ODST) && deserializer.CachePlatform == CachePlatform.Original)
            {
                var savedFilmHeader = new BlfSavedFilmHeader();

                savedFilmHeader.Signature = reader.ReadTag();
                savedFilmHeader.Length = reader.ReadInt32();
                savedFilmHeader.MajorVersion = reader.ReadInt16();
                savedFilmHeader.MinorVersion = reader.ReadInt16();

                savedFilmHeader.Header = new SavedFilmHeader
                {
                    Padding1 = reader.ReadBytes(0x4),
                    BuildNumber = reader.ReadString(0x20),
                    ExecutableType = (ExecutableType)reader.ReadInt32(),
                    NetworkExecutableVersion = reader.ReadInt32(),
                    NetworkCompatibleVersion = reader.ReadInt32(),
                    MapLanguage = (GameLanguage)reader.ReadInt32(),
                    MapMinorVersion = reader.ReadInt32(),
                    MapMinorVersionIsTracked = reader.ReadBoolean(),
                    Padding2 = reader.ReadBytes(0xB),
                    MapSignatureSize = reader.ReadInt32(),
                    MapSignatureBytes = reader.ReadBytes(0x3C),
                    IsHostFilm = reader.ReadBoolean(),
                    ContainsGamestate = reader.ReadBoolean(),
                    IsSnippet = reader.ReadBoolean(),
                    Padding3 = reader.ReadBytes(0x5),
                    SessionId = reader.ReadString(0x80),
                    Options = GameOptions.Decode(reader, deserializer, dataContext),
                    RecordedTime = reader.ReadInt32(),
                    LengthInTicks = reader.ReadInt32(),
                    SnippetStartTick = reader.ReadInt32(),
                    PaddingToAlignForUtilityDrive = reader.ReadBytes(0x538)
                };

                return savedFilmHeader;
            }
            else 
            {
                return deserializer.Deserialize<BlfSavedFilmHeader>(dataContext);
            }
        }

        public static void Encode(TagSerializer serializer, DataSerializationContext dataContext, BlfSavedFilmHeader savedFilmHeader)
        {
            if (CacheVersionDetection.IsBetween(serializer.Version, CacheVersion.Halo3Retail, CacheVersion.Halo3ODST) && serializer.CachePlatform == CachePlatform.Original) 
            {
                GameOptions.Encode(savedFilmHeader.Header.Options);
            }

            serializer.Serialize(dataContext, savedFilmHeader);
        }
    }
}
