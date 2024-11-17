using System;
using TagTool.Tags;

namespace TagTool.BlamFile.GameVariants
{
    [TagStructure(Size = 0x200, Align = 0x1)]
    public class GameVariantCtf : GameVariantBase
    {
        public CtfFlags VariantFlags;
        public CtfHomeFlagWaypointSettings HomeFlagWaypoint;
        public CtfGametypeSettings Gametype;
        public CtfRespawnSettings Respawn;
        public CtfTouchReturnSettings TouchReturnTimeout;
        public CtfSuddenDeathTime SuddenDeathTime;
        public short ScoreToWin;
        public short ScoreUnknown;
        public short FlagResetTime;
        public GameVariantPlayerTraits CarrierTraits;

        [TagField(Flags = TagFieldFlags.Padding, Length = 6)]
        public byte[] Padding1 = new byte[6];

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
    }
}