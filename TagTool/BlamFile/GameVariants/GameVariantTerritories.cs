using System;
using TagTool.Tags;

namespace TagTool.BlamFile.GameVariants
{
    [TagStructure(Size = 0x210, Align = 0x1)]
    public class GameVariantTerritories : GameVariantBase
    {
        public TerritoriesFlags VariantFlags;
        public TerritoriesRespawnOnCaptureSettings RespawnOnCapture;
        public TerritoriesCaptureTimeSettings CaptureTime;
        public TerritoriesSuddenDeathSettings SuddenDeathTime;
        public GameVariantPlayerTraits DefenderTraits;
        public GameVariantPlayerTraits AttackerTraits;

        [Flags]
        public enum TerritoriesFlags : short
        {
            None = 0,
            OneSided = 1 << 0,
            LockAfterFirstCapture = 1 << 2,
        }

        public enum TerritoriesRespawnOnCaptureSettings : short
        {
            Disabled,
            Friendly,
            Enemy,
            All,
        }

        public enum TerritoriesCaptureTimeSettings : short
        {
            Instant = 0,
            Seconds_5 = 5,
            Seconds_10 = 10,
            Seconds_15 = 15,
            Seconds_20 = 20,
            Seconds_30 = 30,
            Seconds_45 = 45,
            Minutes_1 = 60,
            Minutes_2 = 120,
        }

        public enum TerritoriesSuddenDeathSettings : short
        {
            Indefinite = -1,
            Off = 0,
            Seconds_15 = 15,
            Seconds_30 = 30,
            Minutes_1 = 60,
            Minutes_2 = 120,
            Minutes_5 = 300,
        }
    }
}