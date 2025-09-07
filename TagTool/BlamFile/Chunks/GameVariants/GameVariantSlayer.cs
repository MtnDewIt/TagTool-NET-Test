using System;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks.GameVariants
{
    [TagStructure]
    public class GameVariantSlayer : GameVariantBase
    {
        public short ScoreToWin;
        
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public short ScoreToWinEarly;
        
        public short KillPoints;
        public sbyte AssistPoints;
        public sbyte DeathPoints;
        public sbyte SuicidePoints;
        public sbyte BetrayalPoints;
        public sbyte LeaderKilledPoints;
        public sbyte EliminationPoints;
        public sbyte AssassinationsPoints;
        public sbyte HeadshotPoints;
        public sbyte MeleePoints;
        public sbyte StickyPoints;
        public sbyte SplatterPoints;
        public sbyte KillingSpreePoints;
        public GameVariantPlayerTraits LeaderTraits;
        
        [TagField(Flags = TagFieldFlags.Padding, Length = 0x2)]
        public byte[] Padding3;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x82, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Flags = TagFieldFlags.Padding, Length = 0x60, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public byte[] Alignment;

        public static GameVariantSlayer Decode(BitStream stream)
        {
            var variant = new GameVariantSlayer();

            variant.BaseFlags = (BaseVariantFlags)stream.ReadUnsigned(1);
            variant.MiscellaneousOptions = VariantMiscellaneousOptions.Decode(stream);
            variant.RespawnOptions = VariantRespawnOptions.Decode(stream);
            variant.SocialOptions = VariantSocialOptions.Decode(stream);
            variant.MapOverrideOptions = VariantMapOverrideOptions.Decode(stream);
            variant.TeamScoringMethod = (TeamScoring)stream.ReadUnsigned(3);

            variant.ScoreToWin = (short)stream.ReadSignedInteger(10);
            variant.KillPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.AssistPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.DeathPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.SuicidePoints = (sbyte)stream.ReadSignedInteger(5);
            variant.BetrayalPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.LeaderKilledPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.EliminationPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.AssassinationsPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.HeadshotPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.MeleePoints = (sbyte)stream.ReadSignedInteger(5);
            variant.StickyPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.SplatterPoints = (sbyte)stream.ReadSignedInteger(5);
            variant.KillingSpreePoints = (sbyte)stream.ReadSignedInteger(5);
            variant.LeaderTraits = GameVariantPlayerTraits.Decode(stream);

            return variant;
        }

        public static void Encode(BitStream stream, GameVariantSlayer variant)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}