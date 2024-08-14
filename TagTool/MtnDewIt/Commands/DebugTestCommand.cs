using System.Collections.Generic;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Commands;
using TagTool.MtnDewIt.JSON;
using TagTool.MtnDewIt.JSON.Handlers;
using TagTool.Tags.Definitions;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Commands.Common;
using System;
using System.IO;
using TagTool.IO;
using TagTool.MtnDewIt.BlamFiles;

namespace TagTool.MtnDewIt.Commands
{
    class DebugTestCommand : Command
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }

        public DebugTestCommand(GameCache cache, GameCacheHaloOnline cacheContext, CommandContextStack contextStack) : base
        (
            false,
            "DebugTest",
            "Self Explanatory",
            
            "DebugTest",
            "Self Explanatory"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            ContextStack = contextStack;
        }

        public override object Execute(List<string> args)
        {
            var modg = new ModGlobalsDefinition()
            {
                Version = 1,
                PlayerCharacterSets = new List<ModGlobalsDefinition.PlayerCharacterSet>()
                {
                    new ModGlobalsDefinition.PlayerCharacterSet()
                    {
                        DisplayName = "General",
                        Name = CacheContext.StringTable.GetOrAddString($@"default_test"),
                        RandomChance = 0.1f,
                        Characters = new List<ModGlobalsDefinition.PlayerCharacterSet.PlayerCharacter>()
                        {
                            new ModGlobalsDefinition.PlayerCharacterSet.PlayerCharacter()
                            {
                                DisplayName = $@"Spartan",
                                Name = CacheContext.StringTable.GetOrAddString($@"masterchief_test"),
                                RandomChance = 0.1f,
                            },
                            new ModGlobalsDefinition.PlayerCharacterSet.PlayerCharacter()
                            {
                                DisplayName = $@"Elite",
                                Name = CacheContext.StringTable.GetOrAddString($@"dervish_test"),
                                RandomChance = 0.1f,
                            },
                        },
                    },
                },
                PlayerCharacterCustomizations = new List<ModGlobalsDefinition.PlayerCharacterCustomization>()
                {
                    new ModGlobalsDefinition.PlayerCharacterCustomization()
                    {
                        GlobalPlayerCharacterTypeIndex = 0,
                        CharacterName = CacheContext.StringTable.GetOrAddString($@"model_spartan"),
                        CharacterDescription = CacheContext.StringTable.GetOrAddString($@"model_spartan_description"),
                        HudGlobals = GetCachedTag<ChudGlobalsDefinition>($@"ui\chud\globals"),
                        VisionGlobals = GetCachedTag<VisionMode>($@"globals\default_vision_mode"),
                        ActionSet = GetCachedTag<PlayerActionSet>($@"objects\characters\masterchief\mp_masterchief\actions"),
                        RegionCameraScripts = new List<ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript>
                        {
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                            {
                                RegionName = "helmet",
                                ScriptNameWidescreen = "helmet_camera_wide",
                                ScriptNameStandard = "helmet_camera_standard",
                                BipedRotation = 50f,
                                RotationDuration = 0.5f,
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                            {
                                RegionName = "body",
                                ScriptNameWidescreen = "body_camera_wide",
                                ScriptNameStandard = "body_camera_standard",
                                BipedRotation = 60f,
                                RotationDuration = 0.5f,
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                            {
                                RegionName = "leftshoulder",
                                ScriptNameWidescreen = "leftshoulder_camera_wide",
                                ScriptNameStandard = "leftshoulder_camera_standard",
                                BipedRotation = 40f,
                                RotationDuration = 0.5f,
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                            {
                                RegionName = "rightshoulder",
                                ScriptNameWidescreen = "rightshoulder_camera_wide",
                                ScriptNameStandard = "rightshoulder_camera_standard",
                                BipedRotation = 100f,
                                RotationDuration = 0.5f,
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                            {
                                RegionName = "emblem",
                                ScriptNameWidescreen = "rightshoulder_camera_wide",
                                ScriptNameStandard = "rightshoulder_camera_standard",
                                BipedRotation = 100f,
                                RotationDuration = 0.5f,
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                            {
                                RegionName = "exit",
                                ScriptNameWidescreen = "exit_subcamera",
                                ScriptNameStandard = "exit_subcamera",
                                RotationDuration = 0.5f,
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                            {
                                RegionName = "colorsTertiary",
                                ScriptNameWidescreen = "helmet_camera_wide",
                                ScriptNameStandard = "helmet_camera_standard",
                                BipedRotation = 50f,
                                RotationDuration = 0.5f,
                            },
                        },
                        CharacterPositionData = new ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo()
                        {
                            Flags = ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo.FlagsValue.PlaceBipedRelativeToCamera | ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo.FlagsValue.RotateInCustomization,
                            BipedNameIndex = 1,
                            SettingsCameraIndex = 15,
                            PlatformNameIndex = 0,
                            RelativeBipedPosition = new RealVector3d(0f, 0f, 0f),
                        },
                        CharacterColors = new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors()
                        {
                            ValidColorFlags = ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.PrimaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.SecondaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.TertiaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.QuaternaryColor,
                            TeamOverrideFlags = ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.PrimaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.QuaternaryColor,
                            Colors = new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock[5]
                            {
                                new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"cef_color_primary"),
                                    Description = CacheContext.StringTable.GetOrAddString($@"cef_color_primary_desc"),
                                    Default = new ArgbColor(0, 84, 110, 38),
                                },
                                new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"cef_color_secondary"),
                                    Description = CacheContext.StringTable.GetOrAddString($@"cef_color_secondary_desc"),
                                    Default = new ArgbColor(0, 84, 110, 38),
                                },
                                new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"cef_color_visor"),
                                    Description = CacheContext.StringTable.GetOrAddString($@"cef_color_visor_desc"),
                                    Default = new ArgbColor(0, 255, 127, 0),
                                },
                                new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"cef_color_light"),
                                    Description = CacheContext.StringTable.GetOrAddString($@"cef_color_light_desc"),
                                    Default = new ArgbColor(0, 150, 133, 255),
                                },
                                new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                {
                
                                },
                            },
                        },
                    },
                    new ModGlobalsDefinition.PlayerCharacterCustomization()
                    {
                        GlobalPlayerCharacterTypeIndex = 1,
                        CharacterName = CacheContext.StringTable.GetOrAddString($@"model_elite"),
                        CharacterDescription = CacheContext.StringTable.GetOrAddString($@"model_elite_description"),
                        HudGlobals = GetCachedTag<ChudGlobalsDefinition>($@"objects\characters\elite\mp_elite\chud\globals_test"),
                        VisionGlobals = GetCachedTag<VisionMode>($@"objects\characters\elite\mp_elite\vision_mode_test"),
                        ActionSet = GetCachedTag<PlayerActionSet>($@"objects\characters\elite\mp_elite\actions"),
                        RegionCameraScripts = new List<ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript>
                        {
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                            {
                                RegionName = "helmet",
                                ScriptNameWidescreen = "helmet_camera_wide",
                                ScriptNameStandard = "helmet_camera_standard",
                                BipedRotation = 50f,
                                RotationDuration = 0.5f,
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                            {
                                RegionName = "body",
                                ScriptNameWidescreen = "body_camera_wide",
                                ScriptNameStandard = "body_camera_standard",
                                BipedRotation = 70f,
                                RotationDuration = 0.5f,
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                            {
                                RegionName = "leftshoulder",
                                ScriptNameWidescreen = "leftshoulder_camera_wide",
                                ScriptNameStandard = "leftshoulder_camera_standard",
                                BipedRotation = 0f,
                                RotationDuration = 0.5f,
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                            {
                                RegionName = "rightshoulder",
                                ScriptNameWidescreen = "rightshoulder_camera_wide",
                                ScriptNameStandard = "rightshoulder_camera_standard",
                                BipedRotation = 70f,
                                RotationDuration = 0.5f,
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                            {
                                RegionName = "emblem",
                                ScriptNameWidescreen = "rightshoulder_camera_wide",
                                ScriptNameStandard = "rightshoulder_camera_standard",
                                BipedRotation = 70f,
                                RotationDuration = 0.5f,
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                            {
                                RegionName = "exit",
                                ScriptNameWidescreen = "exit_subcamera",
                                ScriptNameStandard = "exit_subcamera",
                                RotationDuration = 0.5f,
                            },
                        },
                        CharacterPositionData = new ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo()
                        {
                            Flags = ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo.FlagsValue.PlaceBipedRelativeToCamera | ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo.FlagsValue.RotateInCustomization,
                            BipedNameIndex = 26,
                            SettingsCameraIndex = 15,
                            PlatformNameIndex = 0,
                            RelativeBipedPosition = new RealVector3d(0.3f, 0.04f, 0f),
                            RelativeBipedRotation = -10f,
                        },
                        CharacterColors = new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors()
                        {
                            ValidColorFlags = ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.PrimaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.SecondaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.TertiaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.QuaternaryColor,
                            TeamOverrideFlags = ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.PrimaryColor,
                            Colors = new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock[5]
                            {
                                new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"cef_color_primary"),
                                    Description = CacheContext.StringTable.GetOrAddString($@"cef_color_primary_desc"),
                                    Default = new ArgbColor(0, 11, 33, 86),
                                },
                                new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"cef_color_secondary"),
                                    Description = CacheContext.StringTable.GetOrAddString($@"cef_color_secondary_desc"),
                                    Default = new ArgbColor(0, 29, 16, 82),
                                },
                                new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"cef_color_detail"),
                                    Description = CacheContext.StringTable.GetOrAddString($@"cef_color_detail_desc"),
                                    Default = new ArgbColor(0, 255, 255, 255),
                                },
                                new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"cef_color_light"),
                                    Description = CacheContext.StringTable.GetOrAddString($@"cef_color_light_desc"),
                                    Default = new ArgbColor(0, 27, 255, 104),
                                },
                                new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                {
                
                                },
                            },
                        },
                    },
                },
            };
            
            var tagObject = new TagObject() 
            {
                TagName = $@"json_data\multiplayer\mod_globals",
                TagType = $@"ModGlobalsDefinition",
                TagVersion = Cache.Version,
                TagData = modg,
            };

            using (var cacheStream = Cache.OpenCacheReadWrite())
            {
                // Create a new instance of the JSON handler
                var tagHandler = new TagObjectHandler(Cache, CacheContext);

                // Easy Serializer Breakpoint
                Console.WriteLine($@"Serializing Tag JSON Data...");
    
                // Serialize the tag object into a JSON string
                var tagJson = tagHandler.Serialize(tagObject);

                // Write the JSON string to a file
                File.WriteAllText("json_serializer_tag_test.json", tagJson);
    
                // Easy Deserializer Breakpoint
                Console.WriteLine($@"Deserializing Tag JSON Data...");

                // Deserialize the data from the JSON file
                var parsedTagObject = tagHandler.Deserialize(File.ReadAllText("json_serializer_tag_test.json"));

                // We assume that the tag we want to modify is already in the cache
                GenerateTag<ModGlobalsDefinition>(cacheStream, $@"{parsedTagObject.TagName}");

                // Get the specified tag using the tag name and the tag structure name
                var modgTag = CacheContext.TagCache.GetTag($@"{parsedTagObject.TagName}.{parsedTagObject.TagData.GetTagStructureInfo(Cache.Version, Cache.Platform).Structure.Name}");

                // Serialize using the data from the JSON file
                Cache.Serialize(cacheStream, modgTag, parsedTagObject.TagData);

                // Serialize strings to the string list
                Cache.SaveStrings();
            }



            var mapData = GetMapData($@"{CacheContext.Directory.FullName}\guardian.map");

            var mapObject = new MapObject() 
            {
                MapName = $@"guardian_test",
                MapVersion = mapData.Version,
                CacheFileHeaderData = mapData.Header,
                BlfData = mapData.MapFileBlf,
            };

            using (var cacheStream = Cache.OpenCacheReadWrite())
            {
                // Create a new instance of the JSON handler
                var mapHandler = new MapObjectHandler(Cache, CacheContext);
    
                // Easy Serializer Breakpoint
                Console.WriteLine($@"Serializing Map JSON Data...");
    
                // Serialize the tag object into a JSON string
                var mapJson = mapHandler.Serialize(mapObject);
    
                // Write the JSON string to a file
                File.WriteAllText("json_serializer_map_test.json", mapJson);
    
                // Easy Deserializer Breakpoint
                Console.WriteLine($@"Deserializing Map JSON Data...");
    
                // Deserialize the data from the JSON file
                var parsedMapObject = mapHandler.Deserialize(File.ReadAllText("json_serializer_map_test.json"));
    
                // Creates a new file info for the map file based on the map name
                var mapFile = new FileInfo($@"{CacheContext.Directory.FullName}\{parsedMapObject.MapName}.map");
    
                // Creates a new file, opens a stream to said file and writes the deserialized data to the map file
                using (var fileStream = mapFile.Create())
                using (var writer = new EndianWriter(fileStream))
                {
                    var data = new MapFileData() 
                    {
                        Version = parsedMapObject.MapVersion,
                        Header = parsedMapObject.CacheFileHeaderData,
                        MapFileBlf = parsedMapObject.BlfData,
                    };
    
                    data.WriteData(writer);
                }
            }

            return true;
        }

        public CachedTag GetCachedTag<T>(string tagName) where T : TagStructure
        {
            var tagAttribute = TagStructure.GetTagStructureAttribute(typeof(T), CacheContext.Version, CacheContext.Platform);
            var typeName = tagAttribute.Tag;

            if (CacheContext.TagCache.TryGetTag<T>(tagName, out var result))
            {
                return result;
            }
            else
            {
                new TagToolWarning($@"Could not find tag: '{tagName}.{typeName}'. Assigning null tag instead");
                return null;
            }
        }

        public void GenerateTag<T>(Stream stream, string tagName) where T : TagStructure
        {
            var tag = Cache.TagCache.AllocateTag<T>(tagName);
            var definition = Activator.CreateInstance<T>();
            Cache.Serialize(stream, tag, definition);
        }

        public MapFileData GetMapData(string input) 
        {
            var file = new FileInfo(input);

            var mapFileData = new MapFileData();

            using (var stream = file.OpenRead()) 
            {
                var reader = new EndianReader(stream);

                mapFileData.ReadData(reader);
            }

            return mapFileData;
        }
    }
}
