using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using TagTool.Tags;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_characters_elite_mp_elite_actions_player_action_set : TagFile
    {
        public objects_characters_elite_mp_elite_actions_player_action_set(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<PlayerActionSet>($@"objects\characters\elite\mp_elite\actions");
            var pact = CacheContext.Deserialize<PlayerActionSet>(Stream, tag);
            pact.Widget = new PlayerActionSet.WidgetData
            {
                Title = "Elite Actions",
            };
            pact.Actions = new List<PlayerActionSet.Action>
            {
                new PlayerActionSet.Action
                {
                    Title = "Berserk",
                    IconName = "temp",
                    AnimationEnter = CacheContext.StringTable.GetStringId($@"berserk"),
                    Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                    OverrideCamera = new List<Unit.UnitCameraBlock>
                    {
                        new Unit.UnitCameraBlock
                        {
                            PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                            CameraTracks = new List<Unit.UnitCameraTrack>
                            {
                                new Unit.UnitCameraTrack
                                {
                                    Track = GetCachedTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera"),
                                },
                            },
                        },
                    },
                },
                new PlayerActionSet.Action
                {
                    Title = "Cheer",
                    IconName = "temp",
                    AnimationEnter = CacheContext.StringTable.GetStringId($@"cheer"),
                    Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                    OverrideCamera = new List<Unit.UnitCameraBlock>
                    {
                        new Unit.UnitCameraBlock
                        {
                            PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                            CameraTracks = new List<Unit.UnitCameraTrack>
                            {
                                new Unit.UnitCameraTrack
                                {
                                    Track = GetCachedTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera"),
                                },
                            },
                        },
                    },
                },
                new PlayerActionSet.Action
                {
                    Title = "Warn",
                    IconName = "temp",
                    AnimationEnter = CacheContext.StringTable.GetStringId($@"warn"),
                    Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                    OverrideCamera = new List<Unit.UnitCameraBlock>
                    {
                        new Unit.UnitCameraBlock
                        {
                            PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                            CameraTracks = new List<Unit.UnitCameraTrack>
                            {
                                new Unit.UnitCameraTrack
                                {
                                    Track = GetCachedTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera"),
                                },
                            },
                        },
                    },
                },
                new PlayerActionSet.Action
                {
                    Title = "Taunt",
                    IconName = "temp",
                    AnimationEnter = CacheContext.StringTable.GetStringId($@"taunt"),
                    Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                    OverrideCamera = new List<Unit.UnitCameraBlock>
                    {
                        new Unit.UnitCameraBlock
                        {
                            PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                            CameraTracks = new List<Unit.UnitCameraTrack>
                            {
                                new Unit.UnitCameraTrack
                                {
                                    Track = GetCachedTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera"),
                                },
                            },
                        },
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, pact);
        }
    }
}
