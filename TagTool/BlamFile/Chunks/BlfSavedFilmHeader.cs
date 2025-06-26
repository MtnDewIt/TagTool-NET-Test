using TagTool.Cache;
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
        [TagField(Length = 0x1F00C, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        [TagField(Length = 0x1F514, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        [TagField(Length = 0x2DFF4, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        [TagField(Length = 0x2D4D4, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC)]
        public byte[] UnknownData;

        [TagField(Length = 0x4, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public byte[] Padding1;
        
        [TagField(Length = 0x20, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public string BuildNumber;
        
        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public int ExecutableType;
        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public int NetworkExecutableVersion;
        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public int NetworkCompatibleVersion;
        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public int MapLanguage;
        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public int MapMinorVersion;
        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public bool MapMinorVersionIsTracked;
        
        [TagField(Length = 0xB, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public byte[] Padding2;
        
        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public int MapSignatureSize;
        
        [TagField(Length = 0x3C, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public byte[] MapSignatureBytes;
        
        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public bool IsHostFilm;
        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public bool ContainsGamestate;
        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public bool IsSnippet;
        
        [TagField(Length = 0x5, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public byte[] Padding3;
        
        [TagField(Length = 0x80, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public byte[] SessionId;
        
        [TagField(Length = 0xF810, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public byte[] Options;

        //[TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        //public GameOptions Options;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public int RecordedTime;
        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public int LengthInTicks;
        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public int SnippetStartTick;
        
        [TagField(Length = 0x538, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public byte[] PaddingToAlignForUtilityDrive;

        [TagStructure(Size = 0xF810)]
        public class GameOptions : TagStructure
        {
            [TagStructure(Size = 0x78)]
            public class CampaignArmaments : TagStructure
            {
                [TagStructure(Size = 0x1E)]
                public class CampaignArmamentsPlayer : TagStructure
                {
                    [TagStructure(Size = 0x8)]
                    public class CampaignArmamentsWeapon : TagStructure
                    {

                    }
                }
            }

            [TagStructure(Size = 0x5C)]
            public class GameMatchmakingOptions : TagStructure
            {

            }

            [TagStructure(Size = 0x6C)]
            public class GameMachineOptions : TagStructure
            {

            }

            [TagStructure(Size = 0x128)]
            public class GamePlayerOptions : TagStructure
            {
                [TagStructure(Size = 0x110)]
                public class PlayerConfiguration : TagStructure
                {
                    [TagStructure(Size = 0xC8)]
                    public class PlayerConfigurationFromClient : TagStructure
                    {
                        [TagStructure(Size = 0x1E)]
                        public class PlayerAppearance : TagStructure
                        {

                        }

                        [TagStructure(Size = 0x58)]
                        public class QueriedPlayerStatistics : TagStructure
                        {
                            [TagStructure(Size = 0x10)]
                            public class QueriedPlayerGlobalStatistics : TagStructure
                            {

                            }

                            [TagStructure(Size = 0x2C)]
                            public class QueriedPlayerDisplayedStatistics : TagStructure
                            {

                            }

                            [TagStructure(Size = 0x1C)]
                            public class QueriedPlayerHopperStatistics : TagStructure
                            {

                            }
                        }
                    }

                    [TagStructure(Size = 0x48)]
                    public class PlayerConfigurationFromHost : TagStructure
                    {

                    }
                }
            }

            [TagStructure(Size = 0x6)]
            public class MachineIdentifier : TagStructure
            {

            }
        }

        public static BlfSavedFilmHeader Decode(TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            return deserializer.Deserialize<BlfSavedFilmHeader>(dataContext);
        }

        public static void Encode(TagSerializer serializer, DataSerializationContext dataContext, BlfSavedFilmHeader savedFilmHeader)
        {
            serializer.Serialize(dataContext, savedFilmHeader);
        }
    }
}
