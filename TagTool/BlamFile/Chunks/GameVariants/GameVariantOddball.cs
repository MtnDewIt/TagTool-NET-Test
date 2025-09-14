using System;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks.GameVariants
{
    [TagStructure]
    public class GameVariantOddball : GameVariantBase
    {
        public OddballFlags VariantFlags;
        public short ScoreToWin;
        
        [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
        public short ScoreToWinEarly;
        
        public short CarryingPoints;
        public sbyte KillPoints;
        public sbyte BallKillPoints;
        public sbyte CarrierKillPoints;
        public byte BallCount;
        public short BallSpawnDelay;
        public short BallInactiveRespawnDelay;
        public GameVariantPlayerTraits CarrierTraits;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x2)]
        public byte[] Padding3;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x82, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Flags = TagFieldFlags.Padding, Length = 0x60, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
        public byte[] Alignment;

        [Flags]
        public enum OddballFlags : int
        {
            None = 0,
            AutoBallPickup = 1 << 0,
            BallEffectEnabled = 1 << 1,
        }

        public static GameVariantOddball Decode(BitStreamReader stream)
        {
            var variant = new GameVariantOddball();

            variant.BaseFlags = (BaseVariantFlags)stream.ReadUnsigned(1);
            variant.MiscellaneousOptions = VariantMiscellaneousOptions.Decode(stream);
            variant.RespawnOptions = VariantRespawnOptions.Decode(stream);
            variant.SocialOptions = VariantSocialOptions.Decode(stream);
            variant.MapOverrideOptions = VariantMapOverrideOptions.Decode(stream);
            variant.TeamScoringMethod = (TeamScoring)stream.ReadUnsigned(3);

            variant.VariantFlags = (OddballFlags)stream.ReadUnsigned(2);
            variant.ScoreToWin = (short)stream.ReadSignedInteger(11);
            variant.CarryingPoints = (short)stream.ReadSignedInteger(5);
            variant.KillPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.BallKillPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.CarrierKillPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.BallCount = (byte)stream.ReadUnsigned(2);
            variant.BallSpawnDelay = (short)stream.ReadUnsigned(7);
            variant.BallInactiveRespawnDelay = (short)stream.ReadUnsigned(7);
            variant.CarrierTraits = GameVariantPlayerTraits.Decode(stream);

            return variant;
        }

        public static void Encode(BitStreamWriter stream, GameVariantOddball variant)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}