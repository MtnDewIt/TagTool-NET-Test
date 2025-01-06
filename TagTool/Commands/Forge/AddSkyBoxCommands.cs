using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Forge
{
    public class AddSkyBoxCommand : Command
    {
        private GameCache Cache { get; }
        private ForgeGlobalsDefinition ForgeGlobals;
        private CachedTag Scenario;
        private CachedTag BackgroundSound;
        private string SkyBoxName;
        private int AcousticPaletteIndex = 0;

        public AddSkyBoxCommand(GameCache cache) :
            base(true,

                "AddSkyBox",
                "Add a skybox from the specified scenario.",

                "AddSkyBox <name> <scenario> [acoustic palette]",

                "Add a skybox from the specified scenario."
                + "\nPalette can be either a block index or the name of the acoustic palette.")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            using (var cacheStream = Cache.OpenCacheReadWrite())
            {
                if (args.Count > 3)
                    return new TagToolError(CommandError.ArgCount);

                if (!Cache.TagCache.TryGetCachedTag($"{args[1]}.scenario", out Scenario))
                    return new TagToolError(CommandError.TagInvalid);

                SkyBoxName = args[0].ToUpper();

                ForgeGlobals = Cache.Deserialize<ForgeGlobalsDefinition>(cacheStream, Cache.TagCache.GetTag($"multiplayer\\forge_globals.forg"));

                var nameIndices = new List<int>();

                var scenarioDefintion = Cache.Deserialize<Scenario>(cacheStream, Scenario);

                if (args.Count > 2) 
                {
                    if (!int.TryParse(args[2], out AcousticPaletteIndex))
                    {
                        foreach (var palette in scenarioDefintion.AcousticsPalette)
                        {
                            if (Cache.StringTable.GetString(palette.Name).ToLower() == args[2].ToLower())
                                nameIndices.Add(scenarioDefintion.AcousticsPalette.IndexOf(palette));
                        }

                        switch (nameIndices.Count)
                        {
                            case 0:
                                return new TagToolError(CommandError.CustomError, "Palette could not be found.");
                            case 1:
                                break;
                            default:
                                return new TagToolWarning("Multiple palettes with this name were found. Palette will be the last encountered.");
                        }

                        AcousticPaletteIndex = nameIndices.Last();
                    }
                    else if (AcousticPaletteIndex >= scenarioDefintion.AcousticsPalette.Count || AcousticPaletteIndex < -1)
                        return new TagToolError(CommandError.CustomError, $"Palette index must be less than the current palette count of {scenarioDefintion.AcousticsPalette.Count}.");
                }

                BackgroundSound = scenarioDefintion.AcousticsPalette[AcousticPaletteIndex].AmbienceBackgroundSound;

                // TODO: Add system for handling multiple bsps and sky references
                ForgeGlobals.Skies.Add(new ForgeGlobalsDefinition.Sky 
                {
                    Name = SkyBoxName,
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(),
                    Orientation = new RealEulerAngles3d(),
                    Object = scenarioDefintion.SkyReferences[0].SkyObject,
                    Parameters = scenarioDefintion.SkyParameters,
                    Wind = scenarioDefintion.StructureBsps[0].Wind,
                    CameraFX = scenarioDefintion.DefaultCameraFx,
                    ScreenFX = scenarioDefintion.DefaultScreenFx,
                    GlobalLighting = scenarioDefintion.GlobalLighting,
                    BackgroundSound = BackgroundSound,
                });

                Cache.Serialize(cacheStream, Cache.TagCache.GetTag($"multiplayer\\forge_globals.forg"), ForgeGlobals);
            }

            Console.WriteLine($"\nSkyBox \"{SkyBoxName}\" for scenario \"{Scenario.Name}\" added successfully.");
            return true;
        }
    }
}
