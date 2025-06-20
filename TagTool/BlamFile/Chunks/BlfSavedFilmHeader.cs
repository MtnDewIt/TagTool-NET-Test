using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0x0)]
    public class BlfSavedFilmHeader : BlfChunkHeader
    {
        [TagField(Length = 0x4)]
        public byte[] Padding1;

        [TagField(Length = 0x20)]
        public string BuildNumber;

        public int ExecutableType;
        public int NetworkExecutableVersion;
        public int NetworkCompatibleVersion;
        public int MapLanguage;
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

        [TagField(Length = 0x80)]
        public byte[] SessionId;

        public GameOptions Options;

        public int RecordedTime;
        public int LengthInTicks;
        public int SnippetStartTick;

        [TagField(Length = 0x538)]
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

        public static void Encode(TagSerializer serializer, DataSerializationContext dataContext, BlfSavedFilmHeader scenario)
        {
            serializer.Serialize(dataContext, scenario);
        }
    }
}
