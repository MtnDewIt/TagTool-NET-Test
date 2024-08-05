using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System;
using System.Linq;
using TagTool.Tags;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;

namespace TagTool.MtnDewIt.JSON.Resolvers
{
    public class TagStructureResolver : DefaultContractResolver 
    {
        public GameCache Cache;
        public GameCacheHaloOnline CacheContext;
        public TagStructureInfo StructureInfo { get; set; }

        public TagStructureResolver(TagStructureInfo structureInfo, GameCache cache, GameCacheHaloOnline cacheContext) 
        {
            Cache = cache;
            CacheContext = cacheContext;
            StructureInfo = structureInfo;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);

            return properties.Where(p => !p.PropertyName.Contains("padding", StringComparison.OrdinalIgnoreCase) && !p.PropertyName.Contains("unused", StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
