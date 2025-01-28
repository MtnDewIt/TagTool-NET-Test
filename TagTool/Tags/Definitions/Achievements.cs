using TagTool.Cache;
using TagTool.Common;
using System;
using System.Collections.Generic;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "achievements", Tag = "achi", Size = 0xC)]
    public class Achievements : TagStructure
    {
        public List<AchievementInformationBlock> AchievementInformation;

        [TagStructure(Size = 0x18, Platform = CachePlatform.Original)]
        [TagStructure(Size = 0x10, Platform = CachePlatform.MCC)]
        public class AchievementInformationBlock : TagStructure
        {
            [TagField(Platform = CachePlatform.Original)]
            public Achievements AchievementName;

            [TagField(Platform = CachePlatform.MCC)]
            public AchievementsMCC AchievementNameMCC;

            public LevelFlags Flags;

            [TagField(Flags = Label)]
            public StringId RestrictedLevelName;

            public int MaximumProgressCount;

            [TagField(Platform = CachePlatform.Original)]
            public int ProgressionTrackingInterval;

            [TagField(Platform = CachePlatform.Original)]
            public int ChudBitmapSequenceIndex;

            public enum Achievements : int
            {
                BeatSc100,
                BeatSc110,
                BeatSc120,
                BeatSc130,
                BeatSc140,
                BeatSc150,
                BeatL200,
                BeatL300,
                BeatCampaignNormal,
                BeatCampaignHeroic,
                BeatCampaignLegendary,
                WraithKiller,
                NaughtyNaughty,
                GoodSamaritan,
                DomeInspector,
                LaserBlaster,
                BothTubes,
                ILikeFire,
                MyClothes,
                PinkAndDeadly,
                DarkTimes,
                TradingDown,
                Headcase,
                BoomHeadshot,
                EwwwSticky,
                JuniorDetective,
                Gumshoe,
                SuperSleuth,
                MetagamePointsInSc100,
                MetagamePointsInSc110,
                MetagamePointsInSc120,
                MetagamePointsInSc130a,
                MetagamePointsInSc130b,
                MetagamePointsInSc140,
                MetagamePointsInL200,
                MetagamePointsInL300,
                BeLikeMarty,
                FindAllAudioLogs,
                Find1AudioLog,
                Find3AudioLogs,
                Find15AudioLogs,
                VidmasterChallengeDejaVu,
                VidmasterChallengeEndure,
                VidmasterChallengeClassic,
                HealUp,
                Stunning,
                Tourist,
            }

            public enum AchievementsMCC : int
            {
                BeatSc100,
                BeatSc110,
                BeatSc120,
                BeatSc130,
                BeatSc140,
                BeatSc150,
                BeatL200,
                BeatL300,
                BeatCampaignNormal,
                BeatCampaignHeroic,
                BeatCampaignLegendary,
                WraithKiller,
                NaughtyNaughty,
                GoodSamaritan,
                DomeInspector,
                LaserBlaster,
                BothTubes,
                ILikeFire,
                MyClothes,
                PinkAndDeadly,
                DarkTimes,
                TradingDown,
                Headcase,
                BoomHeadshot,
                EwwwSticky,
                JuniorDetective,
                Gumshoe,
                SuperSleuth,
                MetagamePointsInSc100,
                MetagamePointsInSc110,
                MetagamePointsInSc120,
                MetagamePointsInSc130a,
                MetagamePointsInSc130b,
                MetagamePointsInSc140,
                MetagamePointsInL200,
                MetagamePointsInL300,
                BeLikeMarty,
                FindAllAudioLogs,
                Find1AudioLog,
                Find3AudioLogs,
                Find15AudioLogs,
                VidmasterChallengeDejaVu,
                VidmasterChallengeEndure,
                VidmasterChallengeClassic,
                HealUp,
                Stunning,
                Tourist,
                OneGotAway,
                MakerOfTheMadrigal,
                Vandalized,
                SaturdayMorningCartoon,
                ForYourEyesOnly,
                CatchEmNapping,
                StrongSilentType,
                BipBapBam,
                PineappleExpress,
                HarderThanItLooks,
                MoreThanHisShare,
                FowlHunt,
                Xenophilla,
                SpartanCan,
                Firefly,
                SaidTheLady,
                SitDown,
                Ghosthunter,
                OneWayRide,
                IAintDead,
                DeferenceOfDarkness,
                EyeForAnEye,
                ThoseLeftBehind,
                ShootAndScoot,
                FastAndLow,
                Shiny,
                BitsAndPieces,
                WhatAboutThoseTanks,
                HogBeatsScorpion,
                TwoPlacesSameTime,
                Xenophobia,
                KeepItClean,
                VidmasterEndureFloodRedux,
            }

            [Flags]
            public enum LevelFlags : int
            {
                None = 0,
                DisabledInCampaign = 1 << 0,
                DisabledInSurvival = 1 << 1,
                DisabledInHub = 1 << 2,
                DisabledInScreens = 1 << 3,
            }
        }
    }
}
