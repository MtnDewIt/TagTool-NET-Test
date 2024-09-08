using System.Collections.Generic;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Commands;
using TagTool.MtnDewIt.JSON.Objects;
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
            var test = new TestDefinition 
            {
                TestBlockField = new List<TestDefinition.TestBlockDefinition> 
                {
                    new TestDefinition.TestBlockDefinition
                    {
                        Byte = 1,
                        SByte = 1,
                        UShort = 2,
                        Short = 2,
                        UInt = 4,
                        Int = 4,
                        ULong = 8,
                        Long = 8,
                        Float = 4,

                        //Enum = TestDefinition.TestEnumDefinition.Test1,
                        //Flags = TestDefinition.TestFlagsDefinition.Test1 | TestDefinition.TestFlagsDefinition.Test2 | TestDefinition.TestFlagsDefinition.Test3,

                        Angle = Angle.FromDegrees(69.420f),
                        ArgbColor = new ArgbColor(1, 2, 3, 4),
                        CachedTagInstance = Cache.TagCache.GetTag<CacheFileGlobalTags>($@"global_tags"),
                        CacheAddress = new CacheAddress(CacheAddressType.Memory, 69420),
                        DatumIndex = new DatumHandle(42069, 42069),
                        PageableResource = null,
                        Point2d = new Point2d(420, 420),
                        RealArgbColor = new RealArgbColor(1.420f, 2.420f, 3.420f, 4.420f),
                        RealBoundingBox = new RealBoundingBox(new Bounds<float>(1f, 2f), new Bounds<float>(3f, 4f), new Bounds<float>(5f, 6f)),
                        RealEulerAngles2d = new RealEulerAngles2d(Angle.FromDegrees(69.420f), Angle.FromDegrees(69.420f)),
                        RealEulerAngles3d = new RealEulerAngles3d(Angle.FromDegrees(69.420f), Angle.FromDegrees(69.420f), Angle.FromDegrees(69.420f)),
                        RealMatrix4x3 = new RealMatrix4x3(1.1f, 1.2f, 1.3f, 2.1f, 2.2f, 2.3f, 3.1f, 3.2f, 3.3f, 4.1f, 4.2f, 4.3f),
                        RealPlane2d = new RealPlane2d(new RealVector2d(1.420f, 2.420f), 3.420f),
                        RealPlane3d = new RealPlane3d(new RealVector3d(1.420f, 2.420f, 3.420f), 4.420f),
                        RealPoint2d = new RealPoint2d(1.420f, 2.420f),
                        RealPoint3d = new RealPoint3d(1.420f, 2.420f, 3.420f),
                        RealQuaternion = new RealQuaternion(1.420f, 2.420f, 3.420f, 4.420f),
                        RealRgbColor = new RealRgbColor(1.420f, 2.420f, 3.420f),
                        RealVector2d = new RealVector2d(1.420f, 2.420f),
                        RealVector3d = new RealVector3d(1.420f, 2.420f, 3.420f),
                        Rectangle2d = new Rectangle2d(420, -420, 420, -420),
                        StringId = Cache.StringTable.GetStringId($@"masterchief"),
                        Tag = new Tag("lgma"),

                        BoundsAngle = new Bounds<Angle>(Angle.FromDegrees(420.69f), Angle.FromDegrees(69.420f)),
                        BoundsByte = new Bounds<byte>(0, 1),
                        BoundsSByte = new Bounds<sbyte>(-1, 1),
                        BoundsUShort = new Bounds<ushort>(0, 420),
                        BoundsShort = new Bounds<short>(-420, 420),
                        BoundsUInt = new Bounds<uint>(0, 69420),
                        BoundsInt = new Bounds<int>(-69420, 69420),
                        BoundsULong = new Bounds<ulong>(0, 69420),
                        BoundsLong = new Bounds<long>(-69420, 69420),
                        BoundsFloat = new Bounds<float>(0.0f, 69420.420f),
                    },
                    new TestDefinition.TestBlockDefinition
                    {
                        Byte = 1,
                        SByte = 1,
                        UShort = 2,
                        Short = 2,
                        UInt = 4,
                        Int = 4,
                        ULong = 8,
                        Long = 8,
                        Float = 4,

                        //Enum = TestDefinition.TestEnumDefinition.Test1,
                        //Flags = TestDefinition.TestFlagsDefinition.Test1 | TestDefinition.TestFlagsDefinition.Test2 | TestDefinition.TestFlagsDefinition.Test3,

                        Angle = Angle.FromDegrees(69.420f),
                        ArgbColor = new ArgbColor(1, 2, 3, 4),
                        CachedTagInstance = Cache.TagCache.GetTag<CacheFileGlobalTags>($@"global_tags"),
                        CacheAddress = new CacheAddress(CacheAddressType.Memory, 69420),
                        DatumIndex = new DatumHandle(42069, 42069),
                        PageableResource = null,
                        Point2d = new Point2d(420, 420),
                        RealArgbColor = new RealArgbColor(1.420f, 2.420f, 3.420f, 4.420f),
                        RealBoundingBox = new RealBoundingBox(new Bounds<float>(1f, 2f), new Bounds<float>(3f, 4f), new Bounds<float>(5f, 6f)),
                        RealEulerAngles2d = new RealEulerAngles2d(Angle.FromDegrees(69.420f), Angle.FromDegrees(69.420f)),
                        RealEulerAngles3d = new RealEulerAngles3d(Angle.FromDegrees(69.420f), Angle.FromDegrees(69.420f), Angle.FromDegrees(69.420f)),
                        RealMatrix4x3 = new RealMatrix4x3(1.1f, 1.2f, 1.3f, 2.1f, 2.2f, 2.3f, 3.1f, 3.2f, 3.3f, 4.1f, 4.2f, 4.3f),
                        RealPlane2d = new RealPlane2d(new RealVector2d(1.420f, 2.420f), 3.420f),
                        RealPlane3d = new RealPlane3d(new RealVector3d(1.420f, 2.420f, 3.420f), 4.420f),
                        RealPoint2d = new RealPoint2d(1.420f, 2.420f),
                        RealPoint3d = new RealPoint3d(1.420f, 2.420f, 3.420f),
                        RealQuaternion = new RealQuaternion(1.420f, 2.420f, 3.420f, 4.420f),
                        RealRgbColor = new RealRgbColor(1.420f, 2.420f, 3.420f),
                        RealVector2d = new RealVector2d(1.420f, 2.420f),
                        RealVector3d = new RealVector3d(1.420f, 2.420f, 3.420f),
                        Rectangle2d = new Rectangle2d(420, -420, 420, -420),
                        StringId = Cache.StringTable.GetStringId($@"masterchief"),
                        Tag = new Tag("lgma"),

                        BoundsAngle = new Bounds<Angle>(Angle.FromDegrees(420.69f), Angle.FromDegrees(69.420f)),
                        BoundsByte = new Bounds<Byte>(0, 1),
                        BoundsSByte = new Bounds<SByte>(-1, 1),
                        BoundsUShort = new Bounds<ushort>(0, 420),
                        BoundsShort = new Bounds<short>(-420, 420),
                        BoundsUInt = new Bounds<uint>(0, 69420),
                        BoundsInt = new Bounds<int>(-69420, 69420),
                        BoundsULong = new Bounds<ulong>(0, 69420),
                        BoundsLong = new Bounds<long>(-69420, 69420),
                        BoundsFloat = new Bounds<float>(0.0f, 69420.420f),
                    },
                }
            };
            
            var tagObject = new TagObject() 
            {
                TagName = $@"json_data\json_test_tag",
                TagType = $@"test_blah",
                TagVersion = Cache.Version,
                TagData = test,
            };

            using (var cacheStream = Cache.OpenCacheReadWrite())
            {
                // Create a new instance of the JSON handler
                var tagHandler = new TagObjectHandler(Cache, CacheContext, cacheStream);

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
                GenerateTag<TestDefinition>(cacheStream, $@"{parsedTagObject.TagName}");

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
                        CachePlatform = CachePlatform.Original,
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
            CacheContext.SaveTagNames();
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
