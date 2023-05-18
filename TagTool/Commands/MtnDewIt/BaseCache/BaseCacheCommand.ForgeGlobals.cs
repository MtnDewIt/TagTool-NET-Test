using TagTool.Tags.Definitions;

namespace TagTool.Commands.Tags 
{
    partial class BaseCacheCommand : Command 
    {
        public void ForgeGlobals()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                foreach (var tag in CacheContext.TagCache.NonNull())
                {
                    if (tag.IsInGroup("forg") && tag.Name == $@"multiplayer\forge_globals")
                    {
                        var forg = CacheContext.Deserialize<ForgeGlobalsDefinition>(stream, tag);

                        CacheContext.Serialize(stream, tag, forg);
                    }
                }
            }
        }
    }
}