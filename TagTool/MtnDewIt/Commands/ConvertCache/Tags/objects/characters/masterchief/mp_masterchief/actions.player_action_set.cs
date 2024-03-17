using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Tags;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_characters_masterchief_mp_masterchief_actions_player_action_set : TagFile
    {
        public objects_characters_masterchief_mp_masterchief_actions_player_action_set(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<PlayerActionSet>($@"objects\characters\masterchief\mp_masterchief\actions");
            var pact = CacheContext.Deserialize<PlayerActionSet>(Stream, tag);
            pact.Widget = new PlayerActionSet.WidgetData
            {
                Title = "Spartan Actions",
            };
            pact.Actions = new List<PlayerActionSet.Action>
            {
                new PlayerActionSet.Action
                {
                    Title = "Dance",
                    AnimationEnter = CacheContext.StringTable.GetOrAddString($@"thunder_clap"),
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
                                    Track = GetCachedTag<CameraTrack>($@"objects\characters\masterchief\mp_masterchief\action_camera"),
                                },
                            },
                        },
                    },
                },
                new PlayerActionSet.Action
                {
                    Title = "Fresh",
                    IconName = "temp",
                    AnimationEnter = CacheContext.StringTable.GetOrAddString($@"fresh"),
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
                                    Track = GetCachedTag<CameraTrack>($@"objects\characters\masterchief\mp_masterchief\action_camera"),
                                },
                            },
                        },
                    },
                },
                new PlayerActionSet.Action
                {
                    Title = "Orange Justice",
                    IconName = "temp",
                    AnimationEnter = CacheContext.StringTable.GetOrAddString($@"orange_justice"),
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
                                    Track = GetCachedTag<CameraTrack>($@"objects\characters\masterchief\mp_masterchief\action_camera"),
                                },
                            },
                        },
                    },
                },
                new PlayerActionSet.Action
                {
                    Title = "Electro Swing",
                    IconName = "temp",
                    AnimationEnter = CacheContext.StringTable.GetOrAddString($@"electro_swing"),
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
                                    Track = GetCachedTag<CameraTrack>($@"objects\characters\masterchief\mp_masterchief\action_camera"),
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
