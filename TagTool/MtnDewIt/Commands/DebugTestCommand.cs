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
            "Calls on specific functions from within the specified class"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            ContextStack = contextStack;
        }

        public override object Execute(List<string> args)
        {

            var newCommandContext = new ConvertCacheCommand(Cache, CacheContext, ContextStack);

            //newCommandContext.modifyStrings();
            //newCommandContext.Globals();
            //newCommandContext.MultiplayerGlobals();
            //newCommandContext.ModGlobals();
            //newCommandContext.ForgeGlobals();
            //newCommandContext.ChudGlobals();
            //newCommandContext.GameVariantSettingsSetup();
            //newCommandContext.RasterizerGlobalsSetup();
            //newCommandContext.SurvivalGlobalsSetup();
            //newCommandContext.UserInterfaceGlobalsSetup();
            //newCommandContext.ShieldImpactSetup();
            //newCommandContext.SoundEffectTemplateSetup();
            //newCommandContext.SquadTemplatesSetup();
            //newCommandContext.ApplyUIPatches();
            //newCommandContext.ApplyHUDPatches();
            //newCommandContext.applyPlayerPatches();
            //newCommandContext.MainMenuDependencies();

            return true;            
        }
    }
}