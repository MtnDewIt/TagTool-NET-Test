using System;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks.GameVariants
{
    [TagStructure]
    public class GameVariantAssault : GameVariantBase
    {
        public AssaultFlags VariantFlags;
        public AssaultRespawnSettings Respawn;
        public AssaultGametypeSettings Gametype;
        public AssaultEnemyBombWaypointSettings EnemyBombWaypoint;
        public short ScoreToWin;
        
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public short ScoreUnknown0;
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public short ScoreUnknown1;
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public short ScoreUnknown2;
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public short ScoreUnknown3;
        
        public AssaultSuddenDeathTime SuddenDeathTime;
        public short BombResetTime;
        public short BombArmingTime;
        public short BombDisarmingTime;
        public short BombFuseTime;
        public GameVariantPlayerTraits CarrierTraits;
        public GameVariantPlayerTraits ArmingTraits;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x64, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Flags = TagFieldFlags.Padding, Length = 0x3C, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public byte[] Alignment;

        [Flags]
        public enum AssaultFlags : short
        {
            None = 0,
            ResetBombOnDisarm = 1 << 0,
        }
        
        public enum AssaultRespawnSettings : short
        {
            Disabled = 0,
            OnFriendlyDetonation,
            OnEnemyDetonation,
            OnAnyDetonation,
        }
        
        public enum AssaultGametypeSettings : short
        {
            MultiBomb = 0,
            OneBomb,
            NeutralBomb,
        }
        
        public enum AssaultEnemyBombWaypointSettings : short
        {
            Never = 0,
            WhenNotCarriedByEnemy,
            WhenArmed,
            Always,
        }
        
        public enum AssaultSuddenDeathTime : short
        {
            Infinite = -1,
            Off = 0,
            Seconds_15 = 15,
            Minutes_1 = 60,
            Minutes_2 = 120,
            Minutes_5 = 300,
        }

        public static new GameVariantAssault Decode(BitStreamReader stream)
        {
            var variant = new GameVariantAssault();

            variant.BaseFlags = (BaseVariantFlags)stream.ReadUnsigned(1);
            variant.MiscellaneousOptions = VariantMiscellaneousOptions.Decode(stream);
            variant.RespawnOptions = VariantRespawnOptions.Decode(stream);
            variant.SocialOptions = VariantSocialOptions.Decode(stream);
            variant.MapOverrideOptions = VariantMapOverrideOptions.Decode(stream);
            variant.TeamScoringMethod = (TeamScoring)stream.ReadUnsigned(3);

            variant.VariantFlags = (AssaultFlags)stream.ReadUnsigned(1);
            variant.Gametype = (AssaultGametypeSettings)stream.ReadUnsigned(2);
            variant.Respawn = (AssaultRespawnSettings)stream.ReadUnsigned(3);
            variant.EnemyBombWaypoint = (AssaultEnemyBombWaypointSettings)stream.ReadUnsigned(3);
            variant.ScoreToWin = (short)stream.ReadUnsigned(6);
            variant.SuddenDeathTime = (AssaultSuddenDeathTime)stream.ReadSignedInteger(9);
            variant.BombArmingTime = (short)stream.ReadUnsigned(5);
            variant.BombDisarmingTime = (short)stream.ReadUnsigned(5);
            variant.BombFuseTime = (short)stream.ReadUnsigned(5);
            variant.BombResetTime = (short)stream.ReadUnsigned(6);
            variant.CarrierTraits = GameVariantPlayerTraits.Decode(stream);
            variant.ArmingTraits = GameVariantPlayerTraits.Decode(stream);

            return variant;
        }

        public static void Encode(BitStreamWriter stream, GameVariantAssault variant)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}