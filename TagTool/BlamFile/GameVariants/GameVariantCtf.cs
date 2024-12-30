using System;
using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.BlamFile.GameVariants
{
    //[TagStructure(Size = 0xB0, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x90, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
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
        public byte[] Padding1 = new byte[0x6];

        //[TagField(Flags = TagFieldFlags.Padding, Length = 0x80, MaxVersion = CacheVersion.Halo3ODST)]
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
    }
}