using System.Runtime.InteropServices;
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

    [TagStructure(Size = 0x6C)]
    public class GameMachineOptions : TagStructure
    {
        public int MachineValidMask;

        [TagField(Length = 0x10)]
        public MachineIdentifier[] MachineIdentifiers;

        public bool LocalMachineExists;

        [TagField(Length = 0x1)]
        public byte[] Padding1;

        public MachineIdentifier LocalMachineIdentifier;
    }

    [TagStructure(Size = 0x128)]
    public class GamePlayerOptions : TagStructure
    {
        public bool Valid;
        public bool LeftGame;
        public short UserIndex;
        public ControllerIndex ControllerIndex;
        public MachineIdentifier MachineIdentifier;
        public PlayerIdentifier PlayerIdentifier;

        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        public PlayerConfiguration Configuration;

        [TagStructure(Size = 0x110)]
        public class PlayerConfiguration : TagStructure
        {
            public PlayerConfigurationFromClient Client;
            public PlayerConfigurationFromHost Host;
        }
    }

    [TagStructure(Size = 0x6)]
    public class MachineIdentifier : TagStructure
    {
        [TagField(Length = 0x6)]
        public byte[] Identifier;
    }
}
