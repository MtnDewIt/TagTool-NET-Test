using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Commands.WeDontTalkAboutIt;

namespace TagTool.Commands
{
    public class DebugTestCommand : Command
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnlineBase CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }

        public DebugTestCommand(GameCache cache, GameCacheHaloOnlineBase cacheContext, CommandContextStack contextStack) : base
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
            CreateData(ZeusVersion.Halo3Xenon);
            CreateData(ZeusVersion.Halo3ODSTXenon);
            //CreateData(ZeusVersion.Halo3Ares);
            CreateData(ZeusVersion.Halo3Latest);
            CreateData(ZeusVersion.Halo3ODSTLatest);
            CreateData(ZeusVersion.HaloOnlineMS23);

            return true;
        }

        public static void CreateData(ZeusVersion build) 
        {
            TagDefinitionGenerator definitionGenerator = new(build);
            definitionGenerator.GenerateFiles();

            TagGroupGenerator groupGenerator = new(build);
            groupGenerator.GenerateFile();
        }
    }
}