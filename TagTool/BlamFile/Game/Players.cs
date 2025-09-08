using System.Runtime.InteropServices;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.BlamFile.Game
{
    [TagStructure(Size = 0xC8, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Size = 0x200, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x30, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
    public class PlayerConfigurationFromClient : TagStructure
    {
        [TagField(Length = 0x10, CharSet = CharSet.Unicode)]
        public string PlayerName;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public PlayerAppearance Appearance;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public ulong PlayerXuid;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public bool IsSilverOrGoldLive;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public bool IsOnlineEnabled;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public bool IsControllerAttached;

        public sbyte UserSelectedTeamIndex;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public bool DesiresVeto;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public bool DesiresRematch;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public byte HopperAccessFlags;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public bool IsFreeLiveGoldAccount;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public bool IsUserCreatedContentAllowed;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public bool IsFriendCreatedContentAllowed;

        [TagField(MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
        public byte VoteSelectionIndex;

        [TagField(MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
        public sbyte ArmorLoadoutIndex;

        [TagField(MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
        public sbyte WeaponLoadoutIndex;

        public byte PlayerIsGriefer;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
        public CampaignProgress CampaignDifficultyCompleted;

        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public CampaignProgress CampaignSoloHighestDifficulty;

        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public CampaignProgress CampaignCoopHighestDifficulty;

        [TagField(Length = 0x3, Flags = TagFieldFlags.Padding, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline106708)]
        public byte[] Padding2;

        // TODO: Come up with a proper name for this :/
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public UnknownStruct Unknown;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public BungieNetUserFlags BungieNetUserFlags;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public GamerRegion GamerRegion;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public GamerZone GamerZone;

        public uint CheatFlags;
        public uint BanFlags;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public int RepeatedPlayCoefficient;

        [TagField(Length = 0x3, Flags = TagFieldFlags.Padding, MaxVersion = CacheVersion.Halo3ODST)]
        public byte[] Padding3;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public bool ExperienceGrowthBanned;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public QueriedPlayerStatistics QueriedPlayerStatistics;

        [TagField(Length = 0x4, Flags = TagFieldFlags.Padding, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public byte[] Padding4;
    }

    // TODO: Map Properly
    [TagStructure(Size = 0x130)]
    public class UnknownStruct : TagStructure
    {
        [TagField(Length = 0x2)]
        public Unknown1Struct[] Campaign;

        public int Unknown2;

        [TagField(Length = 0x2)]
        public Unknown3Struct[] Survival;

        public int Unknown4;

        [TagStructure(Size = 0x48)]
        public class Unknown1Struct : TagStructure
        {
            public int MapId;

            [TagField(Length = 0x20, CharSet = CharSet.Unicode)]
            public string Name;

            public int Unknown3;
        }

        [TagStructure(Size = 0x4C)]
        public class Unknown3Struct : TagStructure
        {
            public int MapId;

            public short InsertionPoint;

            [TagField(Length = 0x20, CharSet = CharSet.Unicode)]
            public string Name;

            [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            public int Unknown4;
        }
    }

    [TagStructure(Size = 0x48, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x15F0, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
    public class PlayerConfigurationFromHost : TagStructure
    {
        [TagField(MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
        public PlayerIdentifier PlayerIdentifier;

        [TagField(Length = 0x10, CharSet = CharSet.Unicode)]
        public string PlayerName;

        public int PlayerTeam;
        public int PlayerAssignedTeam;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public CalculatedPlayerGlobalStatistics GlobalStatistics;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public CalculatedPlayerHopperStatistics HopperStatistics;

        [TagField(MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
        public PlayerAppearance Appearance;

        [TagField(MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
        public PlayerConfigurationArmor Armor;

        [TagField(MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
        public PlayerConfigurationWeapon Weapon;

        [TagStructure(Size = 0x10)]
        public class CalculatedPlayerGlobalStatistics : TagStructure 
        {
            public bool Valid;

            [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
            public byte[] Padding1;

            public int Experience;
            public ExperienceRank Rank;
            public ExperienceGrade Grade;
        }

        [TagStructure(Size = 0x10)]
        public class CalculatedPlayerHopperStatistics : TagStructure
        {
            public bool Valid;

            [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
            public byte[] Padding2;

            public int Skill;
            public int SkillDisplay;
            public int SkillUpdateWeight;
        }

        [TagStructure(Size = 0x7EC)]
        public class PlayerConfigurationArmor : TagStructure 
        {
            public byte Flags;

            [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            public uint LoadoutIndex;

            [TagField(Length = 0x5)]
            public PlayerArmorConfigurationLoadout[] Loadouts;

            [TagField(Length = 0x5)]
            public PlayerConfigurationModifier[] LoadoutModifiers;
        }

        [TagStructure(Size = 0x20)]
        public class PlayerArmorConfigurationLoadout : TagStructure 
        {
            [TagField(Length = 0x5)]
            public uint[] Colors;

            [TagField(Length = 0xA)]
            public byte[] Armors;

            [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;
        }

        [TagStructure(Size = 0x774)]
        public class PlayerConfigurationWeapon : TagStructure
        {
            public bool Unknown0;

            [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            public uint LoadoutIndex;

            [TagField(Length = 0x5)]
            public PlayerWeaponConfigurationLoadout[] Loadouts;

            [TagField(Length = 0x5)]
            public PlayerConfigurationModifier[] LoadoutModifiers;
        }

        [TagStructure(Size = 0x8)]
        public class PlayerWeaponConfigurationLoadout : TagStructure 
        {
            public byte PrimaryWeaponIndex;
            public byte SecondaryWeaponIndex;
            public sbyte GrenadeIndex;

            [TagField(Length = 0x4)]
            public byte[] Consumables;

            // TODO: Validate
            [TagField(EnumType = typeof(sbyte))]
            public BungieNetUserFlags BungieNetUserFlags;
        }

        [TagStructure(Size = 0x174)]
        public class PlayerConfigurationModifier : TagStructure 
        {
            [TagField(Length = 0x5D)]
            public uint[] Modifiers;
        }
    }

    [TagStructure(Size = 0x20, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x660, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
    public class PlayerAppearance : TagStructure
    {
        public PlayerAppearanceFlags AppearanceFlags;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public PlayerChangeColor ChangeColor;

        public PlayerModelChoice PlayerModelChoice;

        [TagField(Length = 0x1, Flags = TagFieldFlags.Padding, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Length = 0x2, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
        public byte[] Padding1;

        public PlayerEmblemInfo EmblemInfo;

        [TagField(Length = 0x648, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
        public byte[] EmblemPad;

        [TagField(Length = 0x4, MaxVersion = CacheVersion.Halo3ODST)]
        public byte[] SpartanModelArea;

        [TagField(Length = 0x4, MaxVersion = CacheVersion.Halo3ODST)]
        public byte[] EliteModelArea;

        [TagField(Length = 0x4, CharSet = CharSet.Unicode, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
        [TagField(Length = 0x5, CharSet = CharSet.Unicode, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline106708)]
        public string ServiceTag;

        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
        public byte[] Padding2;

        [TagStructure(Size = 0x3)]
        public class PlayerChangeColor : TagStructure 
        {
            public PlayerColorIndex PrimaryChangeColor;
            public PlayerColorIndex SecondaryChangeColor;
            public PlayerColorIndex TertiaryChangeColor;
        }

        [TagStructure(Size = 0x8)]
        public class PlayerEmblemInfo : TagStructure 
        {
            public byte ForegroundEmblemIndex;
            public byte BackgroundEmblemIndex;
            public PlayerEmblemInfoFlags Flags;
            public PlayerColorIndex PrimaryChangeColor;
            public PlayerColorIndex SecondaryChangeColor;
            public PlayerColorIndex BackgroundChangeColor;

            [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
            public byte[] Padding2;
        }
    }

    [TagStructure(Size = 0x8)]
    public class PlayerIdentifier : TagStructure 
    {
        [TagField(Length = 0x8)]
        public byte[] Identifier;
    }

    [TagStructure(Size = 0x58)]
    public class QueriedPlayerStatistics : TagStructure
    {
        public QueriedPlayerGlobalStatistics GlobalStatistics;
        public QueriedPlayerDisplayedStatistics DisplayedStatistics;
        public QueriedPlayerHopperStatistics HopperStatistics;

        [TagStructure(Size = 0x10)]
        public class QueriedPlayerGlobalStatistics : TagStructure
        {
            public bool Valid;

            [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            public int ExperienceBase;
            public int ExperiencePenalty;
            public int HighestSkill;
        }

        [TagStructure(Size = 0x2C)]
        public class QueriedPlayerDisplayedStatistics : TagStructure
        {
            public bool StatsValid;

            [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            public int MatchmadeRankedGamesPlayed;
            public int MatchmadeRankedGamesCompleted;
            public int MatchmadeRankedGamesWon;
            public int MatchmadeUnrankedGamesPlayed;
            public int MatchmadeUnrankedGamesCompleted;
            public int HopperExperienceBase;
            public int CustomGamesCompleted;
            public int HopperExperiencePenalty;
            public int FirstPlayed;
            public int LastPlayed;
        }

        [TagStructure(Size = 0x1C)]
        public class QueriedPlayerHopperStatistics : TagStructure
        {
            public bool StatsValid;

            [TagField(Length = 0x1, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            public ushort Indentifier;
            public float Mu;
            public float Sigma;
            public int HopperSkill;
            public int GamesPlayed;
            public int GamesCompleted;
            public int GamesWon;
        }
    }
}
