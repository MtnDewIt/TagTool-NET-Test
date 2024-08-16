using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands;
using TagTool.MtnDewIt.JSON;
using TagTool.MtnDewIt.JSON.Handlers;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Commands 
{
    public class GenerateTagObjectCommand : Command
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;
        private string ExportPath = $@"tags";

        public GenerateTagObjectCommand(GameCache cache, GameCacheHaloOnline cacheContext) : base
        (
            false,
            "GenerateTagObject",
            "Generates a JSON tag object file based on the specified tag",

            "GenerateTagObject <Tag_Name>",
            "Generates a JSON tag object file based on the specified tag. Flags within\n" + 
            "the generated JSON data may change depending on the tag's definition and type"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override object Execute(List<string> args)
        {
            var handler = new TagObjectHandler(Cache, CacheContext);

            // Wrapping the whole thing in a using statement probably isn't the best idea
            using (var stream = Cache.OpenCacheRead()) 
            {
                var tag = Cache.TagCache.GetTag(args[0]);
                var definition = (TagStructure)Cache.Deserialize(stream, tag);

                var tagObject = new TagObject()
                {
                    TagName = tag.Name,
                    TagType = definition.GetType().Name,
                    TagVersion = Cache.Version,
                    TagData = definition,
                };

                // When deserialising the data for these types we want to ensure that the tag exists in the cache no matter what
                if (definition.GetType() == typeof(RenderMethodDefinition) || definition.GetType() == typeof(RenderMethodOption))
                {
                    tagObject.Generate = true;
                }
                
                var jsonData = handler.Serialize(tagObject);

                var fileInfo = new FileInfo(Path.Combine(ExportPath, $"{tag.Name}.json"));

                if (!fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                }

                File.WriteAllText(Path.Combine(ExportPath, $"{tag.Name}.{TagStructure.GetTagStructureInfo(Cache.TagCache.TagDefinitions.GetTagDefinitionType(tag.Group), Cache.Version, Cache.Platform).Structure.Name}.json"), jsonData);
            }

            return true;
        }
    }
}