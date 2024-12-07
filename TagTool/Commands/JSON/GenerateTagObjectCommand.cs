using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.JSON.Objects;
using TagTool.JSON.Handlers;
using TagTool.Tags.Resources;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using System.Threading.Tasks;
using TagTool.Commands.Common;
using System.Diagnostics;
using System.Text.RegularExpressions;
using TagTool.Common;
using TagTool.Scripting;

namespace TagTool.Commands.JSON
{
    public class GenerateTagObjectCommand : Command
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;
        private string ExportPath = $@"tags";
        private string DataPath = $@"data";
        private string PathPrefix = null;

        private int TagCount = 0;
        private Stopwatch StopWatch = new Stopwatch();
        private List<string> ErrorLog = new List<string>();

        public GenerateTagObjectCommand(GameCache cache, GameCacheHaloOnline cacheContext) : base
        (
            false,
            "GenerateTagObject",
            "Generates a JSON tag object file based on the specified tag",

            "GenerateTagObject <Tag_Name> [PathPrefix]",
            "Generates a JSON tag object file based on the specified tag. Flags within\n" +
            "the generated JSON data may change depending on the tag's definition and type\n\n" +

            "Optionally, instead of specifying a tag to convert you can use\n" + 
            "\"all\", which will convert all tags in the current cache context."
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count > 2)
                return new TagToolError(CommandError.ArgCount);

            PathPrefix = args.Count == 2 ? args[1] : null;

            ExportPath = PathPrefix != null ? Path.Combine(PathPrefix, ExportPath) : ExportPath;
            DataPath = PathPrefix != null ? Path.Combine(PathPrefix, DataPath) : DataPath;

            ProcessInputAsync(args[0]).GetAwaiter().GetResult();

            Console.WriteLine($"{TagCount - ErrorLog.Count}/{TagCount} Tags Converted Successfully in {StopWatch.ElapsedMilliseconds.FormatMilliseconds()} with {ErrorLog.Count} {(ErrorLog.Count == 1 ? "error" : "errors")}\n");

            if (ErrorLog.Count > 0)
            {
                ParseErrorLog();
            }

            return true;
        }

        public async Task ProcessInputAsync(string input) 
        {
            var tagTable = new List<CachedTag>();

            if (Cache.TagCache.TryGetCachedTag(input, out var tag))
                tagTable.Add(tag);
            else if (input.Equals("all", StringComparison.OrdinalIgnoreCase))
                tagTable = Cache.TagCache.NonNull().ToList();
            else 
                new TagToolError(CommandError.TagInvalid);

            TagCount = tagTable.Count;

            using (var cacheStream = Cache.OpenCacheRead()) 
            {
                StopWatch.Start();

                var tasks = tagTable.Select(tag => ConvertTagAsync(tag, cacheStream));
                await Task.WhenAll(tasks);

                StopWatch.Stop();
            }
        }

        private async Task ConvertTagAsync(CachedTag tag, Stream cacheStream) 
        {
            try 
            {
                var definition = (TagStructure)Cache.Deserialize(cacheStream, tag);
                var definitionName = TagStructure.GetTagStructureInfo(Cache.TagCache.TagDefinitions.GetTagDefinitionType(tag.Group), Cache.Version, Cache.Platform).Structure.Name;

                var tagObject = new TagObject()
                {
                    TagName = tag.Name,
                    TagType = definitionName,
                    TagVersion = Cache.Version,
                    TagData = definition,
                };

                if (definition.GetType() == typeof(Bitmap)) 
                {
                    var bitm = definition as Bitmap;

                    tagObject.Bitmaps = new BitmapResources() 
                    {
                        Textures = null,
                        InterleavedTextures = null,
                    };

                    if (bitm.HardwareTextures != null && bitm.HardwareTextures.Count != 0) 
                    {
                        tagObject.Bitmaps.Textures = new List<BitmapTextureInteropResource>();

                        foreach (var texture in bitm.HardwareTextures)
                        {
                            var resource = Cache.ResourceCache.GetBitmapTextureInteropResource(texture);

                            tagObject.Bitmaps.Textures.Add(resource);
                        }
                    }

                    if (bitm.InterleavedHardwareTextures != null && bitm.InterleavedHardwareTextures.Count != 0) 
                    {
                        tagObject.Bitmaps.InterleavedTextures = new List<BitmapTextureInterleavedInteropResource>();

                        foreach (var interleavedTexture in bitm.InterleavedHardwareTextures)
                        {
                            var resource = Cache.ResourceCache.GetBitmapTextureInterleavedInteropResource(interleavedTexture);

                            tagObject.Bitmaps.InterleavedTextures.Add(resource);
                        }
                    }
                }

                if (definition.GetType() == typeof(ModelAnimationGraph))
                {
                    var jmad = definition as ModelAnimationGraph;

                    tagObject.Animations = new AnimationResources 
                    {
                        Animations = new List<ModelAnimationTagResource>(),
                    };

                    if (jmad.ResourceGroups != null && jmad.ResourceGroups.Count != 0) 
                    {
                        foreach (var resourceGroup in jmad.ResourceGroups) 
                        {
                            var resource = Cache.ResourceCache.GetModelAnimationTagResource(resourceGroup.ResourceReference);

                            tagObject.Animations.Animations.Add(resource);
                        }
                    }
                }

                if (definition.GetType() == typeof(ParticleModel))
                {
                    var pmdf = definition as ParticleModel;

                    tagObject.RenderGeometry = new RenderGeometryResources 
                    {
                        Geometry = new RenderGeometryApiResourceDefinition(),
                    };

                    if (pmdf.Geometry != null) 
                    {
                        var resource = Cache.ResourceCache.GetRenderGeometryApiResourceDefinition(pmdf.Geometry.Resource);

                        tagObject.RenderGeometry.Geometry = resource;
                    }
                }

                if (definition.GetType() == typeof(RenderModel))
                {
                    var mode = definition as RenderModel;

                    tagObject.RenderGeometry = new RenderGeometryResources
                    {
                        Geometry = new RenderGeometryApiResourceDefinition(),
                    };

                    if (mode.Geometry != null) 
                    {
                        var resource = Cache.ResourceCache.GetRenderGeometryApiResourceDefinition(mode.Geometry.Resource);

                        tagObject.RenderGeometry.Geometry = resource;
                    }
                }

                if (definition.GetType() == typeof(Scenario))
                {
                    var scnr = definition as Scenario;

                    var scriptName = tag.Name.Split(@"\").Last();

                    tagObject.BlamScriptResource = new BlamScriptResource($@"{scriptName}.hsc");

                    var scriptFileInfo = new FileInfo(Path.Combine(DataPath, $@"{tag.Name}\scripts\{scriptName}.hsc"));

                    if (!scriptFileInfo.Directory.Exists)
                    {
                        scriptFileInfo.Directory.Create();
                    }

                    using (var scriptFileStream = scriptFileInfo.Create())
                    using (var scriptWriter = new StreamWriter(scriptFileStream))
                    {
                        var decompiler = new ScriptDecompiler(Cache, scnr);
                        decompiler.DecompileScripts(scriptWriter);
                    }
                }

                if (definition.GetType() == typeof(ScenarioLightmapBspData))
                {
                    var lbsp = definition as ScenarioLightmapBspData;

                    tagObject.RenderGeometry = new RenderGeometryResources
                    {
                        Geometry = new RenderGeometryApiResourceDefinition(),
                    };

                    if (lbsp.Geometry != null) 
                    {
                        var resource = Cache.ResourceCache.GetRenderGeometryApiResourceDefinition(lbsp.Geometry.Resource);

                        tagObject.RenderGeometry.Geometry = resource;
                    }
                }

                if (definition.GetType() == typeof(ScenarioStructureBsp))
                {
                    var sbsp = definition as ScenarioStructureBsp;

                    tagObject.StructureBsp = new StructureBspResources 
                    {
                        DecoratorGeometry = null,
                        Geometry = null,
                        Collision = null,
                        Pathfinding = null,
                    };

                    if (sbsp.DecoratorGeometry != null) 
                    {
                        var resource = Cache.ResourceCache.GetRenderGeometryApiResourceDefinition(sbsp.DecoratorGeometry.Resource);

                        tagObject.StructureBsp.DecoratorGeometry = resource;
                    }

                    if (sbsp.Geometry != null)
                    {
                        var resource = Cache.ResourceCache.GetRenderGeometryApiResourceDefinition(sbsp.Geometry.Resource);

                        tagObject.StructureBsp.Geometry = resource;
                    }

                    if (sbsp.CollisionBspResource != null)
                    {
                        var resource = Cache.ResourceCache.GetStructureBspTagResources(sbsp.CollisionBspResource);

                        tagObject.StructureBsp.Collision = resource;
                    }

                    if (sbsp.PathfindingResource != null)
                    {
                        var resource = Cache.ResourceCache.GetStructureBspCacheFileTagResources(sbsp.PathfindingResource);

                        tagObject.StructureBsp.Pathfinding = resource;
                    }
                }

                if (definition.GetType() == typeof(Sound))
                {
                    var snd = definition as Sound;

                    tagObject.Sounds = new SoundResources
                    { 
                        Sound = new SoundResourceDefinition(),
                    };

                    if (snd.Resource != null) 
                    {
                        var resource = Cache.ResourceCache.GetSoundResourceDefinition(snd.Resource);

                        tagObject.Sounds.Sound = resource;
                    }
                }

                if (definition.GetType() == typeof(MultilingualUnicodeStringList))
                {
                    tagObject.TagData = null;

                    var unic = definition as MultilingualUnicodeStringList;

                    tagObject.UnicodeStrings = new UnicodeStringList 
                    {
                        Languages = new List<UnicodeStringList.UnicodeLanguage>(),
                    };

                    foreach (GameLanguage language in Enum.GetValues(typeof(GameLanguage))) 
                    {
                        tagObject.UnicodeStrings.Languages.Add(new UnicodeStringList.UnicodeLanguage 
                        {
                            Language = language,
                            UnicodeStrings = new List<UnicodeStringList.UnicodeLanguage.UnicodeStringData>(),
                        });

                        foreach (var localizedString in unic.Strings)
                        {
                            var stringIdContent = unic.GetString(localizedString, language);

                            if (stringIdContent != null) 
                            {
                                stringIdContent = LocalizedStringPrinter.EncodeNonAsciiCharacters(stringIdContent);
                            }

                            tagObject.UnicodeStrings.Languages[(int)language].UnicodeStrings.Add(new UnicodeStringList.UnicodeLanguage.UnicodeStringData 
                            {
                                StringIdName = Cache.StringTable.GetString(localizedString.StringID),
                                StringIdContent = stringIdContent,
                            });
                        }
                    }
                }

                var handler = new TagObjectHandler(Cache, CacheContext, cacheStream);

                var jsonData = handler.Serialize(tagObject);

                var fileInfo = new FileInfo(Path.Combine(ExportPath, $"{tag.Name}.{definitionName}.json"));

                if (!fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                }

                File.WriteAllText(fileInfo.FullName, jsonData);
            }
            catch (Exception e)
            {
                ErrorLog.Add($"Error converting \"{tag.Name}.{tag.Group}\" : {e.Message}");
            }
        }

        public void ParseErrorLog()
        {
            var time = DateTime.Now;
            var shortDateTime = $@"{time.ToShortDateString()}-{time.ToShortTimeString()}";

            var fileName = Regex.Replace($"hott_{shortDateTime}_tag_errors.log", @"[*\\ /:]", "_");
            var filePath = "logs";
            var fullPath = Path.Combine(Program.TagToolDirectory, filePath, fileName);

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            using (StreamWriter writer = new StreamWriter(File.Create(fullPath)))
            {
                foreach (var error in ErrorLog)
                {
                    writer.WriteLine(error);
                }
            }

            Console.WriteLine($"Check \"{fullPath}\" for details on errors");
        }
    }
}