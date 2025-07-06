using System.Runtime.InteropServices;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.BlamFile.Game
{
    [TagStructure(Size = 0xC8)]
    public class PlayerConfigurationFromClient : TagStructure
    {
        [TagField(Length = 0x10, CharSet = CharSet.Unicode)]
        public string PlayerName;

        public PlayerAppearance Appearance;

        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        public ulong PlayerXuid;
        public bool IsSilverOrGoldLive;
        public bool IsOnlineEnabled;
        public bool IsControllerAttached;
        public sbyte UserSelectedTeamIndex;
        public bool DesiresVeto;
        public bool DesiresRematch;
        public byte HopperAccessFlags;
        public bool IsFreeLiveGoldAccount;
        public bool IsUserCreatedContentAllowed;
        public bool IsFriendCreatedContentAllowed;
        public byte IsGriefer;
        public CampaignProgress CampaignDifficultyCompleted;
        public BungieNetUserFlags BungieNetUserFlags;
        public GamerRegion GamerRegion;
        public GamerZone GamerZone;
        public uint CheatFlags;
        public uint BanFlags;
        public int RepeatedPlayCoefficient;

        [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;

        public bool ExperienceGrowthBanned;
        public QueriedPlayerStatistics QueriedPlayerStatistics;
    }

    [TagStructure(Size = 0x48)]
    public class PlayerConfigurationFromHost : TagStructure
    {
        [TagField(Length = 0x10, CharSet = CharSet.Unicode)]
        public string PlayerName;

        public int PlayerTeam;
        public int PlayerAssignedTeam;

        public CalculatedPlayerGlobalStatistics GlobalStatistics;
        public CalculatedPlayerHopperStatistics HopperStatistics;

        [TagStructure(Size = 0x10)]
        public class CalculatedPlayerGlobalStatistics : TagStructure 
        {
            [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
            public byte[] Padding1;

            public bool Valid;
            public int Experience;
            public ExperienceRank Rank;
            public ExperienceGrade Grade;
        }

        [TagStructure(Size = 0x10)]
        public class CalculatedPlayerHopperStatistics : TagStructure
        {
            [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
            public byte[] Padding2;

            public bool Valid;
            public int Skill;
            public int SkillDisplay;
            public int SkillUpdateWeight;
        }
    }

    [TagStructure(Size = 0x1E)]
    public class PlayerAppearance : TagStructure
    {
        public PlayerAppearanceFlags AppearanceFlags;
        public PlayerChangeColor ChangeColor;
        public PlayerModelChoice PlayerModelChoice;

        [TagField(Length = 0x1, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        public PlayerEmblemInfo EmblemInfo;

        [TagField(Length = 0x4)]
        public byte[] SpartanModelArea;

        [TagField(Length = 0x4)]
        public byte[] EliteModelArea;

        [TagField(Length = 0x4, CharSet = CharSet.Unicode)]
        public string ServiceTag;

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
