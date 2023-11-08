using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_chud_globals_chud_globals_definition : TagFile
    {
        public ui_chud_globals_chud_globals_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            TagData();
        }

        public override void TagData()
        {
            var tag = GetCachedTag<ChudGlobalsDefinition>($@"ui\chud\globals");
            var chgd = CacheContext.Deserialize<ChudGlobalsDefinition>(Stream, tag);
            chgd.HudGlobals[0].HudAttributes[0].StateMessageScale = 0.7f;
            chgd.HudGlobals[0].HudAttributes[0].MessageAnchorVerticalOffset = 0.0935f;
            chgd.HudGlobals[0].HudAttributes[0].MedalScale = 1.15f;
            chgd.HudGlobals[0].HudAttributes[0].MedalWidth = 66f;
            chgd.HudGlobals[0].HudAttributes[0].SurvivalMedalsOffset = new RealPoint2d(0f, 0.61f);
            chgd.HudGlobals[0].HudAttributes[0].MessageScale = 0.7f;
            chgd.HudGlobals[0].HudAttributes[0].MessageHeight = 30f;
            chgd.HudGlobals[0].HudAttributes[0].MessageOffset = new RealPoint2d(0f, 0.67f);
            chgd.HudGlobals[0].HudSounds[14].LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.None;
            chgd.HudGlobals[0].HudSounds[15].LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.None;
            chgd.HudGlobals[0].WaypointMaxDistanceScale = 1f;
            chgd.HudGlobals[1].HudAttributes[0].ResolutionFlags = ChudGlobalsDefinition.HudGlobal.HudAttribute.ResolutionFlagValue.WideFull | ChudGlobalsDefinition.HudGlobal.HudAttribute.ResolutionFlagValue.StandardFull;
            chgd.HudGlobals[1].HudAttributes[0].MotionSensorOrigin = new RealPoint2d(104.5f, 988f);
            chgd.HudGlobals[1].HudAttributes[0].MotionSensorRadius = 87f;
            chgd.HudGlobals[1].HudAttributes[0].StateMessageScale = 0.7f;
            chgd.HudGlobals[1].HudAttributes[0].StateLeftRightOffset_HO = new RealPoint2d(0.016f, 0.16f);
            chgd.HudGlobals[1].HudAttributes[0].MessageAnchorVerticalOffset = 0.1f;
            chgd.HudGlobals[1].HudAttributes[0].MedalScale = 1.15f;
            chgd.HudGlobals[1].HudAttributes[0].MedalWidth = 66f;
            chgd.HudGlobals[1].HudAttributes[0].SurvivalMedalsOffset = new RealPoint2d(0f, 0.61f);
            chgd.HudGlobals[1].HudAttributes[0].MultiplayerMedalsOffset = new RealPoint2d(0.64f, 2f);
            chgd.HudGlobals[1].HudAttributes[0].MessageScale = 0.7f;
            chgd.HudGlobals[1].HudAttributes[0].MessageHeight = 30f;
            chgd.HudGlobals[1].HudAttributes[0].MessageOffset = new RealPoint2d(0f, 0.67f);
            chgd.HudGlobals[1].HudAttributes[1].MessageAnchorVerticalOffset = 0.15f;
            chgd.HudGlobals[1].HudSounds = new List<ChudGlobalsDefinition.HudGlobal.HudSound>
            {
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.ShieldRecharging,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<SoundLooping>($@"sound\game_sfx\ui\shield_charge_dervish\shield_charge_dervish"),
                        },
                    },
                },
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.ShieldLow,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<SoundLooping>($@"sound\game_sfx\ui\shield_low_dervish\shield_low_dervish"),
                        },
                    },
                },
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.ShieldEmpty,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<SoundLooping>($@"sound\game_sfx\ui\shield_depleted_dervish\shield_depleted_dervish"),
                        },
                    },
                },
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.RocketLocking,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<SoundLooping>($@"sound\weapons\rocket_launcher\tracking_locking\tracking_locking"),
                        },
                    },
                },
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.RocketLocked,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<SoundLooping>($@"sound\weapons\rocket_launcher\tracking_locked\tracking_locked"),
                        },
                    },
                },
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.TrackedTarget,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<SoundLooping>($@"sound\weapons\missile_launcher\tracking_locking\tracking_locking"),
                        },
                    },
                },
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.LockedTarget,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<SoundLooping>($@"sound\weapons\missile_launcher\tracking_locked\tracking_locked"),
                        },
                    },
                },
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.StaminaRecharge,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<SoundLooping>($@"sound\game_sfx\ui\stamina_charge\stamina_charge"),
                        },
                    },
                },
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.StaminaFull,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\stamina_charged\stamina_charged"),
                        },
                    },
                },
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.StaminaWarning,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<SoundLooping>($@"sound\game_sfx\ui\stamina_depleted\stamina_depleted"),
                        },
                    },
                },
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.WinningPoints,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\points_earn\points_earn"),
                        },
                    },
                },
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.ShieldMinorDamage,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\shield_hit_small\shield_hit_small"),
                        },
                    },
                },
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.ShieldMajorDamage,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\shield_hit_med\shield_hit_med"),
                        },
                    },
                },
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.ShieldCriticalDamage,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\shield_hit_large\shield_hit_large"),
                        },
                    },
                },
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.TacticalPackageUsed,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\tactical_package_used\tactical_package_used"),
                        },
                    },
                },
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.TacticalPackageError,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\tactical_package_error\tactical_package_error"),
                        },
                    },
                },
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.None,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\tactical_package_available\tactical_package_available"),
                        },
                    },
                },
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.None,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\tactical_package_full\tactical_package_full"),
                        },
                    },
                },
                new ChudGlobalsDefinition.HudGlobal.HudSound
                {
                    LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.None,
                    Scale = 0,
                    Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                    {
                        new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                        {
                            BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                            Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\headshot_indicator\headshot_indicator"),
                        },
                    },
                },
            };
            chgd.HudGlobals[1].DirectionalArrowScale = 45f;
            chgd.HudGlobals[1].ScoreboardHud = GetCachedTag<ChudDefinition>($@"ui\chud\scoreboard_elite");
            chgd.HudGlobals[1].GrenadeAnchorOffset = 79.5f;
            chgd.HudGlobals[1].EquipmentVerticalOffsetDual = 35f;
            chgd.HudGlobals[1].WaypointMaxDistanceScale = 1f;
            chgd.HudGlobals[2].HudAttributes[0].StateMessageScale = 0.7f;
            chgd.HudGlobals[2].HudAttributes[0].MedalScale = 1.15f;
            chgd.HudGlobals[2].HudAttributes[0].MedalWidth = 66f;
            chgd.HudGlobals[2].HudAttributes[0].SurvivalMedalsOffset = new RealPoint2d(0f, 0.61f);
            chgd.HudGlobals[2].HudAttributes[0].MessageScale = 0.7f;
            chgd.HudGlobals[2].HudAttributes[0].MessageHeight = 30f;
            chgd.HudGlobals[2].HudAttributes[0].MessageOffset = new RealPoint2d(0f, 0.67f);
            chgd.HudGlobals[2].WaypointMaxDistanceScale = 1f;
            chgd.CampaignMetagame.MedalChudAnchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.BottomRight;
            chgd.CampaignMetagame.MedalSpacing = 45f;
            chgd.CampaignMetagame.MedalOffset = new RealPoint2d(-270f, -135f);
            chgd.CampaignMetagame.ScoreboardTopY = 1f;
            chgd.CampaignMetagame.ScoreboardSpacing = 33f;
            CacheContext.Serialize(Stream, tag, chgd);
        }
    }
}
