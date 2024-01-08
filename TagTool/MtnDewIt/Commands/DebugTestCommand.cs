using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands;
using TagTool.MtnDewIt.Commands.ConvertCache;

namespace TagTool.MtnDewIt.Commands
{
    class DebugTestCommand : Command
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }

        public DebugTestCommand(GameCache cache, GameCacheHaloOnline cacheContext, CommandContextStack contextStack) : base
        (
            true,
            "DebugTest",
            "Calls on specific functions from within the specified class",
            "DebugTest",
            "Calls on specific functions from within the specified class. Assumes that the specified functions are public"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            ContextStack = contextStack;
        }

        public override object Execute(List<string> args)
        {

            var newCommandContext = new ConvertCacheCommand(Cache, CacheContext, ContextStack);

            //newCommandContext.UpdateShaderData();
            //newCommandContext.PortTagData();
            //newCommandContext.UpdateTagData();
            //newCommandContext.UpdateMapFiles();

            return true;            
        }
    }
}