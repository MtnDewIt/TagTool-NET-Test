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

        public static GameVariantAssault Decode(BitStream stream)
        {
            var variant = new GameVariantAssault();

            // TODO: Implement

            return variant;
        }

        public static void Encode(BitStream stream, GameVariantAssault variant)
        {
            // TODO: Implement
        }
    }
}