using HaloShaderGenerator.Globals;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Commands.ConvertCache.Definitions;
using TagTool.Shaders.ShaderGenerator;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.ConvertCache
{
    public class ConvertCacheCommand : Command 
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }

        public ConvertCacheCommand(GameCache cache, GameCacheHaloOnline cacheContext) : base
        (
            true,
            "ConvertCache",
            "[REDACTED]",
            "ConvertCache",
            "[REDACTED]"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override object Execute(List<string> args) 
        {
            using (Stream stream = CacheContext.OpenCacheReadWrite()) 
            {
                foreach (CachedTag tag in CacheContext.TagCache.NonNull())
                {
                    if (tag.IsInGroup("sefc"))
                        UpdateAreaScreenEffect(stream, tag);

                    if (tag.IsInGroup("forg"))
                        UpdateForgeGlobalsDefintion(stream, tag);

                    if (tag.IsInGroup("modg"))
                        UpdateModGlobalsDefinition(stream, tag);

                    if (tag.IsInGroup("pact"))
                        UpdatePlayerActionSet(stream, tag);
                }

                GenerateExplicitShader(stream, ExplicitShader.final_composite, false);
                GenerateExplicitShader(stream, ExplicitShader.final_composite_debug, false);
                GenerateExplicitShader(stream, ExplicitShader.final_composite_dof, false);
                GenerateExplicitShader(stream, ExplicitShader.final_composite_zoom, false);
            }

            return false;
        }

        public void UpdateAreaScreenEffect(Stream stream, CachedTag tag) 
        {
            AreaScreenEffect definition = CacheContext.Deserialize<AreaScreenEffect>(stream, tag);

            DebugAreaScreenEffect adapter = new DebugAreaScreenEffect 
            {
                ScreenEffects = new List<DebugAreaScreenEffect.ScreenEffectBlock>(),
            };

            for (int i = 0; i < definition.ScreenEffects.Count; i++) 
            {
                AreaScreenEffect.ScreenEffectBlock screenEffect = definition.ScreenEffects[i];

                adapter.ScreenEffects.Add(new DebugAreaScreenEffect.ScreenEffectBlock 
                {
                    Name = screenEffect.Name,
                    Flags = screenEffect.Flags,
                    HiddenFlags = screenEffect.HiddenFlags,
                    MaximumDistance = screenEffect.MaximumDistance,
                    DistanceFalloffFunction = screenEffect.DistanceFalloffFunction,
                    Lifetime = screenEffect.Lifetime,
                    TimeEvolutionFunction = screenEffect.TimeEvolutionFunction,
                    AngleFalloffFunction = screenEffect.AngleFalloffFunction,
                    ExposureBoost = screenEffect.ExposureBoost,
                    HueLeft = screenEffect.HueLeft,
                    HueRight = screenEffect.HueRight,
                    Saturation = screenEffect.Saturation,
                    Desaturation = screenEffect.Desaturation,
                    ContrastEnhance = screenEffect.ContrastEnhance,
                    GammaEnhance = screenEffect.GammaEnhance,
                    GammaReduce = screenEffect.GammaReduce,
                    ColorFilter = screenEffect.ColorFilter,
                    ColorFloor = screenEffect.ColorFloor,
                    VisionMode = screenEffect.VisionMode,
                    VisionNoise = screenEffect.VisionNoise,
                    ScreenShader = screenEffect.ScreenShader,
                });
            }

            CacheContext.Serialize(stream, tag, adapter);
        }

        public void UpdateForgeGlobalsDefintion(Stream stream, CachedTag tag) 
        {
            ForgeGlobalsDefinition definition = CacheContext.Deserialize<ForgeGlobalsDefinition>(stream, tag);

            DebugForgeGlobalsDefinition adapter = new DebugForgeGlobalsDefinition 
            {
                InvisibleRenderMethod = definition.InvisibleRenderMethod,
                DefaultRenderMethod = definition.DefaultRenderMethod,
                ReForgeMaterials = definition.ReForgeMaterials,
                ReForgeMaterialTypes = definition.ReForgeMaterialTypes,
                ReForgeObjects = definition.ReForgeObjects,
                PrematchCameraObject = definition.PrematchCameraObject,
                ModifierObject = definition.ModifierObject,
                KillVolumeObject = definition.KillVolumeObject,
                GarbageVolumeObject = definition.GarbageVolumeObject,
                Descriptions = definition.Descriptions,
                PaletteCategories = definition.PaletteCategories,
                Palette = definition.Palette,
                WeatherEffects = definition.WeatherEffects,
                Skies = definition.Skies,
                FxObject = definition.FxObject,
                FxLight = definition.FxLight,
            };

            CacheContext.Serialize(stream, tag, adapter);
        }

        public void UpdateModGlobalsDefinition(Stream stream, CachedTag tag) 
        {
            ModGlobalsDefinition definition = CacheContext.Deserialize<ModGlobalsDefinition>(stream, tag);

            DebugModGlobalsDefinition adapter = new DebugModGlobalsDefinition 
            {
                PlayerCharacterSets = new List<DebugModGlobalsDefinition.PlayerCharacterSet>(),
                PlayerCharacterCustomizations = new List<DebugModGlobalsDefinition.PlayerCharacterCustomization>(),
            };

            for (int i = 0; i < definition.PlayerCharacterSets.Count; i++) 
            {
                ModGlobalsDefinition.PlayerCharacterSet characterSet = definition.PlayerCharacterSets[i];

                adapter.PlayerCharacterSets.Add(new DebugModGlobalsDefinition.PlayerCharacterSet 
                {
                    DisplayName = characterSet.DisplayName,
                    Name = characterSet.Name,
                    RandomChance = characterSet.RandomChance,
                    Characters = characterSet.Characters,
                });
            }

            for (int i = 0; i < definition.PlayerCharacterCustomizations.Count; i++) 
            {
                ModGlobalsDefinition.PlayerCharacterCustomization customization = definition.PlayerCharacterCustomizations[i];

                adapter.PlayerCharacterCustomizations.Add(new DebugModGlobalsDefinition.PlayerCharacterCustomization());

                adapter.PlayerCharacterCustomizations[i].GlobalPlayerCharacterTypeIndex = customization.GlobalPlayerCharacterTypeIndex;
                adapter.PlayerCharacterCustomizations[i].CharacterName = customization.CharacterName;
                adapter.PlayerCharacterCustomizations[i].CharacterDescription = customization.CharacterDescription;
                adapter.PlayerCharacterCustomizations[i].HudGlobals = customization.HudGlobals;
                adapter.PlayerCharacterCustomizations[i].VisionGlobals = customization.VisionGlobals;
                adapter.PlayerCharacterCustomizations[i].ActionSet = customization.ActionSet;

                adapter.PlayerCharacterCustomizations[i].RegionCameraScripts = new List<DebugModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript>();

                for (int j = 0; j < customization.RegionCameraScripts.Count; j++) 
                {
                    ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript cameraRegion = customization.RegionCameraScripts[j];

                    adapter.PlayerCharacterCustomizations[i].RegionCameraScripts.Add(new DebugModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript 
                    {
                        RegionName = cameraRegion.RegionName,
                        ScriptNameWidescreen = cameraRegion.ScriptNameWidescreen,
                        ScriptNameStandard = cameraRegion.ScriptNameStandard,
                        BipedRotation = cameraRegion.BipedRotation,
                        RotationDuration = cameraRegion.RotationDuration,
                    });
                }

                adapter.PlayerCharacterCustomizations[i].CharacterPositionData = new DebugModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo 
                {
                    Flags = customization.CharacterPositionData.Flags,
                    BipedNameIndex = customization.CharacterPositionData.BipedNameIndex,
                    SettingsCameraIndex = customization.CharacterPositionData.SettingsCameraIndex,
                    PlatformNameIndex = customization.CharacterPositionData.PlatformNameIndex,
                    RelativeBipedPosition = customization.CharacterPositionData.RelativeBipedPosition,
                    RelativeBipedRotation = customization.CharacterPositionData.RelativeBipedRotation,
                    BipedPositionWidescreen = customization.CharacterPositionData.BipedPositionWidescreen,
                    BipedPositionStandard = customization.CharacterPositionData.BipedPositionStandard,
                    BipedRotation = customization.CharacterPositionData.BipedRotation,
                };

                adapter.PlayerCharacterCustomizations[i].CharacterColors = customization.CharacterColors;
            }

            CacheContext.Serialize(stream, tag, adapter);
        }

        public void UpdatePlayerActionSet(Stream stream, CachedTag tag) 
        {
            PlayerActionSet definition = CacheContext.Deserialize<PlayerActionSet>(stream, tag);

            DebugPlayerActionSet adapter = new DebugPlayerActionSet 
            {
                Widget = new DebugPlayerActionSet.WidgetData
                {
                    // Don't really know what to do if the definition contains more than 1 widget :/
                    Title = definition.Widget[0].Title,
                    Type = definition.Widget[0].Type,
                    Flags = definition.Widget[0].Flags,
                },
                Actions = new List<DebugPlayerActionSet.Action>(),
            };

            for (int i = 0; i < definition.Actions.Count; i++) 
            {
                PlayerActionSet.Action action = definition.Actions[i];

                adapter.Actions.Add(new DebugPlayerActionSet.Action 
                {
                    Title = action.Title,
                    IconName = action.IconName,
                    AnimationEnter = action.AnimationEnter,
                    AnimationIdle = action.AnimationIdle,
                    AnimationExit = action.AnimationExit,
                    Flags = action.Flags,
                    OverrideCamera = action.OverrideCamera,
                });
            }

            CacheContext.Serialize(stream, tag, adapter);
        }

        public void GenerateExplicitShader(Stream stream, ExplicitShader shader, bool applyFixes = false)
        {
            CachedTag pixlTag = Cache.TagCache.GetTag<PixelShader>($"rasterizer\\shaders\\{shader}") ?? Cache.TagCache.AllocateTag<PixelShader>($"rasterizer\\shaders\\{shader}");
            CachedTag vtshTag = Cache.TagCache.GetTag<VertexShader>($"rasterizer\\shaders\\{shader}") ?? Cache.TagCache.AllocateTag<VertexShader>($"rasterizer\\shaders\\{shader}");

            ShaderGeneratorNew.GenerateExplicitShader(Cache, stream, shader.ToString(), applyFixes, out PixelShader pixl, out VertexShader vtsh);

            Cache.Serialize(stream, vtshTag, vtsh);
            Cache.Serialize(stream, pixlTag, pixl);
        }
    }
}