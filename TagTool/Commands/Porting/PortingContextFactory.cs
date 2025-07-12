using System.IO;
using TagTool.Cache;
using TagTool.Cache.Monolithic;
using TagTool.Commands.Common;
using TagTool.Commands.Porting.Gen2;
using TagTool.Commands.Porting.Gen4;
using TagTool.Commands.Tags;
using TagTool.Porting;
using TagTool.Porting.Gen3;
using TagTool.Porting.HaloOnline;
using TagTool.Scripting.CSharp;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Porting
{
    static class PortingContextFactory
    {
        public static CommandContext Create(CommandContextStack contextStack, GameCache currentCache, GameCache portingCache)
        {
            var context = new CommandContext(contextStack.Context, portingCache.DisplayName + "\\tags");

            Populate(contextStack, context, currentCache, portingCache);

            // add tags command to the new cache
            TagCacheContextFactory.Populate(contextStack, context, currentCache, portingCache);

            return context;
        }

        public static SoundCacheFileGestalt LoadSoundGestalt(GameCache cache, Stream cacheStream)
        {
            CachedTag blamTag = cache.TagCache.FindFirstInGroup("ugh!");
            if (blamTag == null)
                return null;

            return cache.Deserialize<SoundCacheFileGestalt>(cacheStream, blamTag);
        }

        public static TagTool.Tags.Definitions.Gen2.SoundCacheFileGestalt LoadGen2SoundGestalt(GameCache cache, Stream cacheStream)
        {
            CachedTag blamTag = cache.TagCache.FindFirstInGroup("ugh!");
            if (blamTag == null)
                return null;

            return cache.Deserialize<TagTool.Tags.Definitions.Gen2.SoundCacheFileGestalt>(cacheStream, blamTag);
        }

        public static void Populate(CommandContextStack contextStack, CommandContext context, GameCache currentCache, GameCache portingCache)
        {
            context.ScriptGlobals.Add(nameof(ScriptEvaluationContext.PortingCache), portingCache);

            if (currentCache is GameCacheHaloOnlineBase hoCache)
            {
                if (portingCache is GameCacheGen3 || portingCache is GameCacheMonolithic)
                {
                    var portingContext = (PortingContextGen3)PortingContext.Create(hoCache, portingCache);
                    PopulatePortingCommands(context, portingCache, hoCache, portingContext);
                    context.AddCommand(new MergeAnimationGraphsCommand(hoCache, portingCache, portingContext));
                    context.AddCommand(new PortMultiplayerScenarioCommand(hoCache, portingCache, portingContext));                  
                }
                else if(portingCache is GameCacheGen4 gen4Cache)
                {
                    context.AddCommand(new PortTagGen4Command(hoCache, gen4Cache));
                }
                else if (portingCache is GameCacheGen2 gen2cache)
                {
                    var portTagCommand = new PortTagGen2Command(hoCache, gen2cache);
                    context.AddCommand(portTagCommand);
                }
                else if (portingCache is GameCacheGen1 gen1cache)
                {
                    var portTagCommand = new PortTagGen1Command(hoCache, gen1cache);
                    context.AddCommand(portTagCommand);
                }
                else if (portingCache is GameCacheHaloOnlineBase hoPortingCache)
                {
                    var portingContext = (PortingContextHO)PortingContext.Create(hoCache, portingCache);
                    PopulatePortingCommands(context, portingCache, hoCache, portingContext);
                }
            }

            context.AddCommand(new DiffTagCommand(currentCache, portingCache));          
            context.AddCommand(new NameBlamTagCommand(portingCache));
            context.AddCommand(new IgnoreBlamTagCommand(portingCache));
            context.AddCommand(new ListBlamTagsCommand(portingCache));
        }

        private static void PopulatePortingCommands(CommandContext context, GameCache portingCache, GameCacheHaloOnlineBase hoCache, PortingContext portingContext)
        {
            // Temporary method until the other contexts are implemented

            context.ScriptGlobals.Add(nameof(ScriptEvaluationContext.PortingContext), portingContext);

            context.AddCommand(new PortTagCommand(hoCache, portingCache, portingContext));
            context.AddCommand(new PortMultiplayerEventsCommand(hoCache, portingCache));
            context.AddCommand(new PortInstancedGeometryObjectCommand(hoCache, portingCache, portingContext));
            context.AddCommand(new PortClusterGeometryObjectCommand(hoCache, portingCache, portingContext));
            context.AddCommand(new DoNotReplaceGroupsCommand(portingContext));
            context.AddCommand(new SetPortingOptionCommand(portingContext));
        }
    }
}
