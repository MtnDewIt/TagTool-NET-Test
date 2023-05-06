using TagTool.Tags.Definitions;

namespace TagTool.Commands.Tags 
{
    partial class PortingCacheCommand : Command 
    {
        public void SurvivalGlobals()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                foreach (var tag in CacheContext.TagCache.NonNull())
                {
                    if (tag.IsInGroup("smdt") && tag.Name == $@"multiplayer\survival_mode_globals")
                    {
                        var smdt = CacheContext.Deserialize<SurvivalModeGlobals>(stream, tag);

                        CacheContext.Serialize(destStream, tag, smdt);
                    }
                }
            }
        }
    }
}