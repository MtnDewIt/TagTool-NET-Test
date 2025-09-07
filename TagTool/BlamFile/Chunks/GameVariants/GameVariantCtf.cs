using System;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks.GameVariants
{
    [TagStructure]
    public class GameVariantCtf : GameVariantBase
    {
        public CtfFlags VariantFlags;
        public CtfHomeFlagWaypointSettings HomeFlagWaypoint;
        public CtfGametypeSettings Gametype;
        public CtfRespawnSettings Respawn;
        public CtfTouchReturnSettings TouchReturnTimeout;
        public CtfSuddenDeathTime SuddenDeathTime;
        public short ScoreToWin;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public short ScoreToWinEarly;

        public short FlagResetTime;
        public GameVariantPlayerTraits CarrierTraits;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x6)]
        public byte[] Padding3;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x82, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Flags = TagFieldFlags.Padding, Length = 0x60, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public byte[] Alignment;

        [Flags]
        public enum CtfFlags : byte
        {
            None = 0,
            FlagAtHomeToScore = 1<< 0,
        }

        public enum CtfHomeFlagWaypointSettings : byte
        {
            Never = 0,
            WhenNotCarriedByEnemy,
            AwayFromHome,
            Always,
        }

        public enum CtfGametypeSettings : byte
        {
            MultiFlag = 0,
            SingleFlag,
            NeutralFlag,
        }

        public enum CtfRespawnSettings : byte
        {
            Normal = 0,
            OnFriendlyCapture,
            OnEnemyCapture,
            OnAnyCapture,
        }

        public enum CtfTouchReturnSettings : short
        {
            Off = -1,
            Instant = 0,
            Seconds_5 = 5,
            Seconds_10 = 10,
            Seconds_15 = 15,
            Seconds_20 = 20,
            Seconds_30 = 30,
            Seconds_45 = 45,
            Minutes_1 = 60,
        }

        public enum CtfSuddenDeathTime : short
        {
            Infinite = -1,
            Off = 0,
            Seconds_15 = 15,
            Minutes_1 = 60,
            Minutes_2 = 120,
            Minutes_5 = 300,
        }

        public static GameVariantCtf Decode(BitStream stream)
        {
            var variant = new GameVariantCtf();

            variant.BaseFlags = (BaseVariantFlags)stream.ReadUnsigned(1);
            variant.MiscellaneousOptions = VariantMiscellaneousOptions.Decode(stream);
            variant.RespawnOptions = VariantRespawnOptions.Decode(stream);
            variant.SocialOptions = VariantSocialOptions.Decode(stream);
            variant.MapOverrideOptions = VariantMapOverrideOptions.Decode(stream);
            variant.TeamScoringMethod = (TeamScoring)stream.ReadUnsigned(3);

            variant.VariantFlags = (CtfFlags)stream.ReadUnsigned(1);
            variant.HomeFlagWaypoint = (CtfHomeFlagWaypointSettings)stream.ReadUnsigned(2);
            variant.Gametype = (CtfGametypeSettings)stream.ReadUnsigned(2);
            variant.Respawn = (CtfRespawnSettings)stream.ReadUnsigned(2);
            variant.ScoreToWin = (short)stream.ReadUnsigned(6);
            variant.SuddenDeathTime = (CtfSuddenDeathTime)stream.ReadSignedInteger(9);
            variant.FlagResetTime = (short)stream.ReadUnsigned(9);
            variant.TouchReturnTimeout = (CtfTouchReturnSettings)stream.ReadUnsigned(6);
            variant.CarrierTraits = GameVariantPlayerTraits.Decode(stream);

            return variant;
        }

        public static void Encode(BitStream stream, GameVariantCtf variant)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}