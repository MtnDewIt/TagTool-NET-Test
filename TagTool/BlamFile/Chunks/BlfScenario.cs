using System;
using System.Runtime.InteropServices;
using TagTool.Cache;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0x4D44, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Size = 0x98B4, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Size = 0xCC8C, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach)]
    [TagStructure(Size = 0x11DCC, MinVersion = CacheVersion.Halo4)]
    public class BlfScenario : BlfChunkHeader
    {
        public int MapId;
        public BlfScenarioFlags MapFlags;

        [TagField(Length = 0xC, MaxVersion = CacheVersion.HaloReach)]
        [TagField(Length = 0x11, MinVersion = CacheVersion.Halo4)]
        public NameUnicode32[] Names;

        [TagField(Length = 0xC, MaxVersion = CacheVersion.HaloReach)]
        [TagField(Length = 0x11, MinVersion = CacheVersion.Halo4)]
        public NameUnicode128[] Descriptions;

        [TagField(Length = 0x100)]
        public string ImageFileBase;

        [TagField(Length = 0x100)]
        public string ScenarioPath;

        public int PresenceContextId;
        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public int SortOrder;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public byte MinimumDesiredPlayers;
        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public byte MaximumDesiredPlayers;

        public GameEngineTeams GameEngineTeamCounts;

        public bool AllowSavedFilms;

        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding, MaxVersion = CacheVersion.HaloOnline700123)]
        public byte[] Padding1;

        [TagField(Length = 0x4, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;

        [TagField(Length = 64, MinVersion = CacheVersion.HaloReach)]
        public uint[] MultiplayerObjects; // bit vector

        [TagField(Length = 0x4, MaxVersion = CacheVersion.Halo3Retail)]
        [TagField(Length = 0x9, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagField(Length = 0xC, MinVersion = CacheVersion.HaloReach)]
        public BlfScenarioInsertion[] Insertions;

        [TagField(Length = 0x10, MinVersion = CacheVersion.HaloReach)]
        public string DefaultAuthor;

        [Flags]
        public enum BlfScenarioFlags : uint
        {
            None = 0,
            Bit1 = 1 << 0,
            Bit2 = 1 << 1,
            Visible = 1 << 2,
            GeneratesFilm = 1 << 3,
            IsMainmenu = 1 << 4,
            IsCampaign = 1 << 5,
            IsMultiplayer = 1 << 6,
            IsDlc = 1 << 7,
            TestBit = 1 << 8,
            TempBit = 1 << 9,
            IsFirefight = 1 << 10,
            IsCinematic = 1 << 11,
            IsForgeOnly = 1 << 12,
        }

        [TagStructure(Size = 0x40)]
        public class NameUnicode32 : TagStructure
        {
            [TagField(CharSet = CharSet.Unicode, Length = 0x20)]
            public string Name;
        }

        [TagStructure(Size = 0x100)]
        public class NameUnicode128 : TagStructure
        {
            [TagField(CharSet = CharSet.Unicode, Length = 0x80)]
            public string Name;
        }

        [TagStructure(Size = 0xB)]
        public class GameEngineTeams : TagStructure
        {
            public byte NoGametypeTeamCount;
            public byte CtfTeamCount;
            public byte SlayerTeamCount;
            public byte OddballTeamCount;
            public byte KingTeamCount;
            public byte SandboxTeamCount;
            public byte VipTeamCount;
            public byte JuggernautTeamCount;
            public byte TerritoriesTeamCount;
            public byte AssaultTeamCount;
            public byte InfectionTeamCount;
        }

        [TagStructure(Size = 0xF08, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0xF10, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0xF88, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach)]
        [TagStructure(Size = 0x15C8, MinVersion = CacheVersion.Halo4)]
        public class BlfScenarioInsertion : TagStructure
        {
            public bool Visible;
            public BlfScenarioInsertionFlags Flags;

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public short ZoneSetIndex;

            [TagField(Length = 0x2, MinVersion = CacheVersion.HaloReach)]
            public byte[] Padding1;

            [TagField(Length = 128, MinVersion = CacheVersion.HaloReach)]
            public string ZoneSetName;

            [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
            public int ReturnFromMapId;
            [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
            public int SurvivalPresenceContextId;

            [TagField(Length = 0x4, Flags = TagFieldFlags.Padding)]
            public byte[] Padding2;

            [TagField(Length = 0xC, MaxVersion = CacheVersion.HaloReach)]
            [TagField(Length = 0x11, MinVersion = CacheVersion.Halo4)]
            public NameUnicode32[] Names;

            [TagField(Length = 0xC, MaxVersion = CacheVersion.HaloReach)]
            [TagField(Length = 0x11, MinVersion = CacheVersion.Halo4)]
            public NameUnicode128[] Descriptions;

            [Flags]
            public enum BlfScenarioInsertionFlags : byte
            {
                None = 0,
                SurvivalBit = 1 << 0,
                SurvivalAlwaysUnlockedBit = 1 << 1,
                Bit2 = 1 << 2,
                ReturnFromMapBit = 1 << 3,
            }
        }

        public static BlfScenario Decode(TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            return (BlfScenario)deserializer.Deserialize(dataContext, typeof(BlfScenario));
        }

        public static void Encode(TagSerializer serializer, DataSerializationContext dataContext, BlfScenario scenario)
        {
            serializer.Serialize(dataContext, scenario);
        }
    }
}
