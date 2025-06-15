using System;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks.GameVariants
{
    [TagStructure]
    public class GameVariantVip : GameVariantBase
    {
        public short ScoreToWinRound;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public short ScoreToWinEarly;

        public VipFlags VariantFlags;
        public sbyte KillPoints;
        public sbyte TakedownPoints;
        public sbyte KillAsVipPoints;
        public sbyte VipDeathPoints;
        public sbyte DestinationArrivalPoints;
        public sbyte SuicidePoints;
        public sbyte BetrayalPoints;
        public sbyte VipSuicidePoints;
        public VipSelectionSettings VipSelection;
        public VipZoneMovementSettings ZoneMovement;
        public VipZoneOrderSettings ZoneOrder;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x1)]
        public byte[] Padding3;

        public short InfluenceRadius;
        public GameVariantPlayerTraits VipTeamTraits;
        public GameVariantPlayerTraits VipInfluenceTraits;
        public GameVariantPlayerTraits VipTraits;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x4A, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Flags = TagFieldFlags.Padding, Length = 0x28, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public byte[] Alignment;

        [Flags]
        public enum VipFlags : short
        {
            None = 0,
            SingleVip = 1 << 0,
            DestinationZonesEnabled = 1 << 1,
            EndRoundOnVipDeath = 1 << 2,
        }

        public enum VipSelectionSettings : byte
        {
            Random = 0,
            NextRespawn,
            NextKill,
            Unchanged,
        }

        public enum VipZoneMovementSettings : byte
        {
            Off,
            Seconds_10,
            Seconds_15,
            Seconds_30,
            Minutes_1,
            Minutes_2,
            Minutes_3,
            Minutes_4,
            Minutes_5,
            OnArrival,
            OnSwitch,
        }

        public enum VipZoneOrderSettings : byte
        {
            Random,
            Sequence,
        }

        public static GameVariantVip Decode(BitStream stream)
        {
            var variant = new GameVariantVip();

            // TODO: Implement

            return variant;
        }

        public static void Encode(BitStream stream, GameVariantVip variant)
        {
            // TODO: Implement
        }
    }
}