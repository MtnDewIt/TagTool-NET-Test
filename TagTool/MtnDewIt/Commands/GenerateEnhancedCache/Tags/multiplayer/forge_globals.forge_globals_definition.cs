using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Tags 
{
    public class multiplayer_forge_globals_forge_globals_definition : TagFile
    {
        public multiplayer_forge_globals_forge_globals_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<ForgeGlobalsDefinition>($@"multiplayer\forge_globals");
            var forg = CacheContext.Deserialize<ForgeGlobalsDefinition>(Stream, tag);
            forg.Palette = new List<ForgeGlobalsDefinition.PaletteItem>{};
            forg.WeatherEffects = new List<ForgeGlobalsDefinition.WeatherEffect>
            {
                new ForgeGlobalsDefinition.WeatherEffect
                {
                    Name = "None",
                    Effect = null,
                },
                new ForgeGlobalsDefinition.WeatherEffect
                {
                    Name = "Snow",
                    Effect = GetCachedTag<Effect>($@"fx\scenery_fx\weather\snow\snow_turf\snow_turf"),
                },
                new ForgeGlobalsDefinition.WeatherEffect
                {
                    Name = "Snow, Heavy",
                    Effect = GetCachedTag<Effect>($@"fx\scenery_fx\weather\snow\snow_heavy\snow_heavy"),
                },
                new ForgeGlobalsDefinition.WeatherEffect
                {
                    Name = "Rain",
                    Effect = GetCachedTag<Effect>($@"fx\scenery_fx\weather\rain\rain_angle\rain_angle"),
                },
                new ForgeGlobalsDefinition.WeatherEffect
                {
                    Name = "Flood Pollen, Light",
                    Effect = GetCachedTag<Effect>($@"fx\scenery_fx\weather\flood_pollen\flood_pollen_light\flood_pollen_light"),
                },
                new ForgeGlobalsDefinition.WeatherEffect
                {
                    Name = "Flood Pollen, Heavy",
                    Effect = GetCachedTag<Effect>($@"fx\scenery_fx\weather\flood_pollen\flood_pollen_heavy\flood_pollen_heavy"),
                },
                new ForgeGlobalsDefinition.WeatherEffect
                {
                    Name = "Falling Ash",
                    Effect = GetCachedTag<Effect>($@"fx\scenery_fx\weather\falling_ash\falling_ash"),
                },
                new ForgeGlobalsDefinition.WeatherEffect
                {
                    Name = "Slipspace Fallout",
                    Effect = GetCachedTag<Effect>($@"fx\scenery_fx\weather\slipspace_fallout\slipspace_fallout"),
                },
                new ForgeGlobalsDefinition.WeatherEffect
                {
                    Name = "Slipspace Fallout, Strong",
                    Effect = GetCachedTag<Effect>($@"fx\scenery_fx\weather\slipspace_fallout\slipspace_fallout_strong"),
                },
            };
            forg.Skies = new List<ForgeGlobalsDefinition.Sky>
            {
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Guardian",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\guardian\sky\sky"),
                    Parameters = GetCachedTag<SkyAtmParameters>($@"levels\multi\guardian\sky\guardian"),
                    Wind = GetCachedTag<Wind>($@"levels\multi\guardian\wind_guardian"),
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\guardian\guardian"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\guardian\guardian"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\gaurdian\gaurdian\gaurdian"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Valhalla",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\riverworld\sky\riverworld"),
                    Parameters = GetCachedTag<SkyAtmParameters>($@"levels\multi\riverworld\sky\riverworld"),
                    Wind = GetCachedTag<Wind>($@"levels\multi\riverworld\wind_riverworld"),
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\riverworld\riverworld"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\riverworld\riverworld"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\riverworld\halo_ext\halo_ext"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Diamondback",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\s3d_avalanche\sky\sky"),
                    Parameters = GetCachedTag<SkyAtmParameters>($@"levels\multi\s3d_avalanche\sky\s3d_avalanche"),
                    Wind = GetCachedTag<Wind>($@"levels\multi\s3d_avalanche\wind_avalanche"),
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\s3d_avalanche\s3d_avalanche"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\s3d_avalanche\s3d_avalanche"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_diamondback\amb_desert_wind\amb_desert_wind"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Edge",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\s3d_edge\sky\sky"),
                    Parameters = GetCachedTag<SkyAtmParameters>($@"levels\multi\s3d_edge\sky\s3d_edge"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\s3d_edge\s3d_edge"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\s3d_edge\s3d_edge"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_edge\amb_cave_dry\amb_cave_dry"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Reactor",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\s3d_reactor\sky\sky"),
                    Parameters = GetCachedTag<SkyAtmParameters>($@"levels\multi\s3d_reactor\sky\reactor"),
                    Wind = GetCachedTag<Wind>($@"levels\multi\s3d_reactor\wind_reactor"),
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\s3d_reactor\s3d_reactor_indoor"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\s3d_reactor\s3d_reactor"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_reactor\amb_wind_mountains\amb_wind_mountains"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Icebox",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\s3d_turf\sky\sky"),
                    Parameters = GetCachedTag<SkyAtmParameters>($@"levels\multi\s3d_turf\sky\s3d_turf"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\s3d_turf\s3d_turf"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\s3d_turf\s3d_turf"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_turf\amb_heavy_snow\amb_heavy_snow"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "The Pit",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\cyberdyne\sky\sky"),
                    Parameters = GetCachedTag<SkyAtmParameters>($@"levels\multi\cyberdyne\sky\cyberdyne"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\cyberdyne\cyberdyne"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\cyberdyne\cyberdyne"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\cyberdyne\cyberdyne_main_hallway\cyberdyne_main_hallway"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Narrows",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\chill\sky\sky"),
                    Parameters = GetCachedTag<SkyAtmParameters>($@"levels\multi\chill\sky\chill"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\chill\chill"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\chill\chill"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\chill\chill\chill"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Standoff",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\dlc\bunkerworld\sky\bunkerworld"),
                    Parameters = GetCachedTag<SkyAtmParameters>($@"levels\dlc\bunkerworld\sky\bunkerworld"),
                    Wind = GetCachedTag<Wind>($@"levels\dlc\bunkerworld\wind_bunkerworld"),
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\dlc\bunkerworld\bunkerworld"),
                    ScreenFX = null,
                    GlobalLighting = null,
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\bunkerworld\bunkerworld_ext\bunkerworld_ext"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Last Resort",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\zanzibar\sky\sky"),
                    Parameters = GetCachedTag<SkyAtmParameters>($@"levels\multi\zanzibar\sky\zanzibar"),
                    Wind = GetCachedTag<Wind>($@"levels\multi\zanzibar\wind_zanzibar"),
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\zanzibar\sky\zanzibar"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\zanzibar\zanzibar"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\zanzibar\zanzibar_courtyard\zanzibar_courtyard"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "High Ground",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\deadlock\sky\deadlock"),
                    Parameters = GetCachedTag<SkyAtmParameters>($@"levels\multi\deadlock\sky\deadlock"),
                    Wind = GetCachedTag<Wind>($@"levels\multi\deadlock\wind_deadlock"),
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\deadlock\deadlock"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\deadlock\deadlock"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\deadlock\deadlock_air\deadlock_air"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Sandtrap",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\shrine\sky\sky"),
                    Parameters = GetCachedTag<SkyAtmParameters>($@"levels\multi\shrine\sky\shrine"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\shrine\shrine"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\shrine\shrine"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\shrine\desert_wind2\desert_wind2"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Rat's Nest",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\dlc\armory\sky\armory_sky"),
                    Parameters = GetCachedTag<SkyAtmParameters>($@"levels\dlc\armory\sky\armory"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\dlc\armory\sky\armory_camera_bright"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\dlc\armory\armory"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\armory\e3_2006_looping\e3_2006_looping"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Cold Storage",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = null,
                    Parameters = GetCachedTag<SkyAtmParameters>($@"levels\dlc\chillout\sky\chillout"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\dlc\chillout\chillout"),
                    ScreenFX = GetCachedTag<AreaScreenEffect>($@"levels\dlc\chillout\sky\chillout"),
                    GlobalLighting = null,
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\chillout\chillout_interior_large\chillout_interior_large"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Construct",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\construct\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\construct\sky\construct"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\construct\construct"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\construct\construct"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\construct\construct_outside\construct_outside"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Assembly",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\dlc\descent\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\dlc\descent\sky\descent"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\dlc\descent\sky\descent"),
                    ScreenFX = GetCachedTag<AreaScreenEffect>($@"levels\dlc\descent\sky\descent"),
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\dlc\descent\sky\descent"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\descent\sentinel_big_spooky\sentinel_big_spooky"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Longshore",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\dlc\docks\sky\docks_sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\dlc\docks\sky\docks"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\dlc\docks\sky\docks_camera"),
                    ScreenFX = GetCachedTag<AreaScreenEffect>($@"levels\dlc\docks\sky\docks"),
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\dlc\docks\docks"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\docks\docks_outside\docks_outside"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Citadel",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\dlc\fortress\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\dlc\fortress\sky\fortress"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\dlc\fortress\fortress_fx"),
                    ScreenFX = GetCachedTag<AreaScreenEffect>($@"levels\dlc\fortress\fortress"),
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\dlc\fortress\fortress"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\fortress\forerunner_int\forerunner_int"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Ghost Town",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\dlc\ghosttown\sky\ghosttown"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\dlc\ghosttown\sky\ghosttown_atmosphere"),
                    Wind = GetCachedTag<Wind>($@"levels\dlc\ghosttown\wind_ghosttown"),
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\dlc\ghosttown\ghosttown"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\dlc\ghosttown\sky\ghosttown"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\ghosttown\earth_ext\earth_ext"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Isolation",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\isolation\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\isolation\sky\isolation"),
                    Wind = GetCachedTag<Wind>($@"levels\multi\isolation\wind_isolation"),
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\isolation\isolation"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\isolation\isolation"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\isolation\halo_ext\halo_ext"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Blackout",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\dlc\lockout\sky\lockout_sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\dlc\lockout\sky\lockout"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\dlc\lockout\lockout"),
                    ScreenFX = GetCachedTag<AreaScreenEffect>($@"levels\dlc\lockout\lockout"),
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\dlc\lockout\lockout"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\lockout\blackout_loops\blackout_loops"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Heretic",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\dlc\midship\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\dlc\midship\sky\midship"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\dlc\midship\midship"),
                    ScreenFX = GetCachedTag<AreaScreenEffect>($@"levels\dlc\midship\midship"),
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\dlc\midship\midship"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\midship\midship_amb\midship_amb"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Lockout",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\s3d_lockout\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\s3d_lockout\sky\s3d_lockout"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\s3d_lockout\camera_fx_set_1"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\s3d_lockout\s3d_lockout"),
                    BackgroundSound = null,
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Powerhouse",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\s3d_powerhouse\sky_settlement\sky_settlement"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\s3d_powerhouse\sky_settlement\s3d_powerhouse"),
                    Wind = GetCachedTag<Wind>($@"levels\multi\s3d_powerhouse\post_fx\wind"),
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\s3d_powerhouse\s3d_powerhouse"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\s3d_powerhouse\s3d_powerhouse"),
                    BackgroundSound = null,
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Sky Bridge",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\s3d_sky_bridgenew\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\s3d_sky_bridgenew\sky\s3d_sky_bridgenew"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\s3d_sky_bridgenew\s3d_sky_bridgenew_outdoor"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\s3d_sky_bridgenew\s3d_sky_bridgenew"),
                    BackgroundSound = null,
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Waterfall",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\s3d_waterfall\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\s3d_waterfall\sky\s3d_waterfall"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\s3d_waterfall\s3d_waterfall"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\s3d_waterfall\s3d_waterfall"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\lockout\blackout_loops\blackout_loops"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Epitaph",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\salvation\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\salvation\sky\salvation"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\salvation\salvation"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\salvation\salvation"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\salvation\forerunner_cathedral_outside\forerunner_cathedral_outside"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Sandbox",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\dlc\sandbox\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\dlc\sandbox\sky\sandbox"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\dlc\sandbox\sky\sandbox"),
                    ScreenFX = GetCachedTag<AreaScreenEffect>($@"levels\dlc\sandbox\sky\sandbox"),
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\dlc\sandbox\sandbox"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\sandbox\desert_wind2\desert_wind2"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Avalanche",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\dlc\sidewinder\sky\sky_sidewinder"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\dlc\sidewinder\sky\sidewinder_snow"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\dlc\sidewinder\sky\sidewinder"),
                    ScreenFX = GetCachedTag<AreaScreenEffect>($@"levels\dlc\sidewinder\sky\sidewinder"),
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\dlc\sidewinder\sky\sidewinder"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\sidewinder\sidewinder_ext\sidewinder_ext"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Snowbound",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\snowbound\sky\sky_snowbound"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\snowbound\sky\snowbound"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\snowbound\snowbound"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\snowbound\snowbound"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\snowbound\alpine_wind\alpine_wind"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Orbital",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\dlc\spacecamp\sky\spacecamp_sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\dlc\spacecamp\sky\spacecamp_atmosphere"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\dlc\spacecamp\sky\spacecamp_camera"),
                    ScreenFX = GetCachedTag<AreaScreenEffect>($@"levels\dlc\spacecamp\sky\spacecamp2"),
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\dlc\spacecamp\spacecamp"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\space_camp\space_camp_loops\space_camp_loops"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Foundry",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\dlc\warehouse\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\dlc\warehouse\sky\ware_atmosphere"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\dlc\warehouse\sky\warehouse"),
                    ScreenFX = GetCachedTag<AreaScreenEffect>($@"levels\dlc\warehouse\warehouse"),
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\dlc\warehouse\warehouse"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\040_voi\voi_interior\voi_interior"),
                },
            };
            CacheContext.Serialize(Stream, tag, forg);
        }
    }
}