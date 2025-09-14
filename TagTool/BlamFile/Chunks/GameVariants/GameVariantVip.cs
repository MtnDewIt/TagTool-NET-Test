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

        [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
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
        [TagField(Flags = TagFieldFlags.Padding, Length = 0x28, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
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

        public static GameVariantVip Decode(BitStreamReader stream)
        {
            var variant = new GameVariantVip();

            variant.BaseFlags = (BaseVariantFlags)stream.ReadUnsigned(1);
            variant.MiscellaneousOptions = VariantMiscellaneousOptions.Decode(stream);
            variant.RespawnOptions = VariantRespawnOptions.Decode(stream);
            variant.SocialOptions = VariantSocialOptions.Decode(stream);
            variant.MapOverrideOptions = VariantMapOverrideOptions.Decode(stream);
            variant.TeamScoringMethod = (TeamScoring)stream.ReadUnsigned(3);

            variant.VariantFlags = (VipFlags)stream.ReadUnsigned(3);
            variant.ScoreToWinRound = (short)stream.ReadUnsigned(10);
            variant.KillPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.TakedownPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.KillAsVipPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.VipDeathPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.DestinationArrivalPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.SuicidePoints = (sbyte)stream.ReadSignedInteger(5);
            variant.VipSuicidePoints = (sbyte)stream.ReadSignedInteger(5);
            variant.BetrayalPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.VipSelection = (VipSelectionSettings)stream.ReadUnsigned(2);
            variant.ZoneMovement = (VipZoneMovementSettings)stream.ReadUnsigned(4);
            variant.ZoneOrder = (VipZoneOrderSettings)stream.ReadUnsigned(1);
            variant.InfluenceRadius = (short)stream.ReadUnsigned(6);
            variant.VipTeamTraits = GameVariantPlayerTraits.Decode(stream);
            variant.VipInfluenceTraits = GameVariantPlayerTraits.Decode(stream);
            variant.VipTraits = GameVariantPlayerTraits.Decode(stream);

            return variant;
        }

        public static void Encode(BitStreamWriter stream, GameVariantVip variant)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}