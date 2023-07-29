using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;

namespace TagTool.Commands.Tags
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
            "What Do You Think It Does?",
            "DebugTest",
            "What Do You Think It Does?"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            ContextStack = contextStack;
        }

        public override object Execute(List<string> args)
        {

            var newCommandContext = new BaseCacheCommand(Cache, CacheContext, ContextStack);

            newCommandContext.modifyStrings();
            newCommandContext.Globals();
            //newCommandContext.MultiplayerGlobals();
            //newCommandContext.ModGlobals();
            //newCommandContext.ForgeGlobals();
            //newCommandContext.ChudGlobals();
            //newCommandContext.RasterizerGlobalsSetup();
            //newCommandContext.SurvivalGlobalsSetup();
            //newCommandContext.UserInterfaceGlobalsSetup();
            //newCommandContext.ShieldImpactSetup();
            //newCommandContext.SoundEffectTemplateSetup();
            //newCommandContext.SquadTemplatesSetup();
            newCommandContext.applyUIPatches();
            //newCommandContext.applyHUDPatches();
            //newCommandContext.applyPlayerPatches();

            return true;            
        }
    }
}