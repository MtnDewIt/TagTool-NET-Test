using System.Runtime.InteropServices;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.BlamFile.Game
{
    [TagStructure(Size = 0x80)]
    public class CampaignGameProgression : TagStructure 
    {
        [TagField(Length = 0x20)]
        public int[] IntegerNames;
    }

    [TagStructure(Size = 0x80)]
    public class CampaignHubProgression : TagStructure 
    {
        public CampaignArmaments CampaignHubArmaments;
        public int CampaignHubReturnToInsertionPoint;
        public bool CampaignHubProgressionValid;

        [TagField(Length = 0x3)]
        public byte[] Padding;
    }

    [TagStructure(Size = 0x78)]
    public class CampaignArmaments : TagStructure
    {
        [TagField(Length = 0x4)]
        public CampaignArmamentsPlayer[] PlayerArmaments;

        [TagStructure(Size = 0x1E)]
        public class CampaignArmamentsPlayer : TagStructure
        {
            public bool Valid;

            [TagField(Length = 0x1, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            public CampaignArmamentsWeapon PrimaryWeapon;
            public CampaignArmamentsWeapon BackpackWeapon;
            public CampaignArmamentsWeapon SecondaryWeapon;
            public byte FragGrenadeCount;
            public byte PlasmaGrenadeCount;
            public byte SpikeGreanadeCount;
            public byte FireGrenadeCount;

            [TagStructure(Size = 0x8)]
            public class CampaignArmamentsWeapon : TagStructure
            {
                public ushort DamageReportingType;
                public ushort RoundsInventory;
                public ushort RoundsLoaded;
                public ushort Battery;
            }
        }
    }

    [TagStructure(Size = 0x5C)]
    public class GameMatchmakingOptions : TagStructure
    {
        public short HopperIdentifier;
        public byte XLastIndex;
        public bool HopperRanked;
        public bool TeamGame;

        [TagField(Length = 0x1, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        [TagField(Length = 0x20, CharSet = CharSet.Unicode)]
        public string HopperName;

        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;

        public int DrawProbability;
        public float Beta;
        public float Tau;
        public int ExperienceBaseIncrement;
        public int ExperiencePenaltyDecrement;
    }

    [TagStructure(Size = 0x6C, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Size = 0x24, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x128, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
    public class GameMachineOptions : TagStructure
    {
        public int MachineValidMask;

        [TagField(Length = 0x10, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
        [TagField(Length = 0x4, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Length = 0x11, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
        public MachineIdentifier[] MachineIdentifiers;

        public bool LocalMachineExists;

        [TagField(Length = 0x1, MaxVersion = CacheVersion.Halo3ODST)]
        public byte[] Padding1;

        public MachineIdentifier LocalMachineIdentifier;

        [TagField(Length = 0x3, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
        public byte[] Padding2;
    }

    [TagStructure(Size = 0x128, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Size = 0x260, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x1640, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
    public class GamePlayerOptions : TagStructure
    {
        public bool Valid;
        public bool PlayerLeftGame;
        public short UserIndex;
        public ControllerIndex ControllerIndex;
        public MachineIdentifier MachineIdentifier;
        public PlayerIdentifier PlayerIdentifier;

        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding, MaxVersion = CacheVersion.Halo3ODST)]
        public byte[] Padding1;

        public PlayerConfiguration Configuration;

        [TagStructure(Size = 0x110, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x248, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0x1620, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
        public class PlayerConfiguration : TagStructure
        {
            public PlayerConfigurationFromClient Client;
            public PlayerConfigurationFromHost Host;
        }
    }

    [TagStructure(Size = 0x6, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x10, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
    public class MachineIdentifier : TagStructure
    {
        [TagField(Length = 0x6, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Length = 0x10, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
        public byte[] Identifier;
    }
}
