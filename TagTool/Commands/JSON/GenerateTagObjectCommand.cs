using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.MtnDewIt.JSON.Objects;
using TagTool.MtnDewIt.JSON.Handlers;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.JSON
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

            "GenerateTagObject <Tag_Name> [Suffix]",
            "Generates a JSON tag object file based on the specified tag. Flags within\n" +
            "the generated JSON data may change depending on the tag's definition and type"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override object Execute(List<string> args)
        {
            // Wrapping the whole thing in a using statement probably isn't the best idea
            using (var cacheStream = Cache.OpenCacheRead())
            {
                var handler = new TagObjectHandler(Cache, CacheContext, cacheStream);

                var tag = Cache.TagCache.GetTag(args[0]);
                var suffix = args.Count > 1 ? args[1] : null;

                var definition = (TagStructure)Cache.Deserialize(cacheStream, tag);
                var definitionName = TagStructure.GetTagStructureInfo(Cache.TagCache.TagDefinitions.GetTagDefinitionType(tag.Group), Cache.Version, Cache.Platform).Structure.Name;

                var fileName = suffix != null ? $"{tag.Name}_{suffix}" : tag.Name;

                var tagObject = new TagObject()
                {
                    TagName = tag.Name,
                    TagType = definitionName,
                    TagVersion = Cache.Version,
                    TagData = definition,
                };

                // When deserialising the data for these types we want to ensure that the tag exists in the cache no matter what
                if (definition.GetType() == typeof(RenderMethodDefinition))
                {
                    tagObject.Generate = true;
                }

                var jsonData = handler.Serialize(tagObject);

                var fileInfo = new FileInfo(Path.Combine(ExportPath, $"{fileName}.{definitionName}.json"));

                if (!fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                }

                File.WriteAllText(Path.Combine(ExportPath, $"{fileName}.{definitionName}.json"), jsonData);
            }

            return true;
        }
    }
}