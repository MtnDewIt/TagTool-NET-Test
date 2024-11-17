using System;
using TagTool.Tags;

namespace TagTool.BlamFile.GameVariants
{
    [TagStructure(Size = 0x228, Align = 0x1)]
    public class GameVariantAssault : GameVariantBase
    {
        public AssaultFlags VariantFlags;
        public AssaultRespawnSettings Respawn;
        public AssaultGametypeSettings Gametype;
        public AssaultEnemyBombWaypointSettings EnemyBombWaypoint;
        public short ScoreToWin;
        public short ScoreUnknown0;
        public short ScoreUnknown1;
        public short ScoreUnknown2;
        public short ScoreUnknown3;
        public AssaultSuddenDeathTime SuddenDeathTime;
        public GameVariantPlayerTraits CarrierTraits;
        public GameVariantPlayerTraits ArmingTraits;

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
    }
}