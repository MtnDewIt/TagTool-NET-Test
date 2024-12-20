﻿using TagTool.Cache;
using TagTool.Commands.Editing;
using TagTool.Commands.Common;
using TagTool.Commands.Definitions;
using TagTool.Commands.Files;
using TagTool.Commands.Strings;
using TagTool.Commands.Sounds;
using TagTool.Commands.Porting;
using TagTool.Commands.Modding;
using TagTool.Commands.Bitmaps;
using TagTool.Commands.PhysicsModels;
using TagTool.Commands.CollisionModels;
using TagTool.Commands.ModelAnimationGraphs;
using TagTool.Commands.Shaders;
using TagTool.Commands.GUI;
using TagTool.Commands.HUD;
using TagTool.Commands.Forge;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Scenarios;
using TagTool.Cache.Monolithic;
using TagTool.Commands.ConvertCache;
using TagTool.Commands.GenerateCache;
using TagTool.Commands.GenerateDonkeyCache;
using TagTool.Commands.JSON;

namespace TagTool.Commands.Tags
{
    public static class TagCacheContextFactory
    {
        public static CommandContext Create(CommandContextStack contextStack, GameCache cache, string contextName="tags")
        {
            var context = new CommandContext(contextStack.Context, contextName);
            Populate(contextStack, context, cache);
            return context;
        }

        public static void Populate(CommandContextStack contextStack, CommandContext context, GameCache cache, GameCache portingCache = null)
        {
            context.ScriptGlobals.Add(ExecuteCSharpCommand.GlobalCacheKey, cache);

            context.AddCommand(new TestCommand(cache));
            context.AddCommand(new DumpLogCommand());
            context.AddCommand(new RunCommands(contextStack));
            context.AddCommand(new ClearCommand());
            context.AddCommand(new ExecuteCSharpCommand(contextStack));
            context.AddCommand(new EchoCommand());
            context.AddCommand(new HelpCommand(contextStack));
            context.AddCommand(new ListVariablesCommand(contextStack));
            context.AddCommand(new SetLocaleCommand());
            context.AddCommand(new SetVariableCommand(contextStack));
            context.AddCommand(new StopwatchCommand());
            context.AddCommand(new ConvertPluginsCommand(cache));
            context.AddCommand(new ListTagsCommand(cache));
            context.AddCommand(new EditTagCommand(contextStack, cache));
            context.AddCommand(new GenerateCampaignFileCommand(cache));
            context.AddCommand(new NameTagCommand(cache));
            context.AddCommand(new ForEachCommand(contextStack, cache));
            context.AddCommand(new ListAllStringsCommand(cache));
            context.AddCommand(new StringIdCommand(cache));
            context.AddCommand(new GenerateAssemblyPluginsCommand());
            context.AddCommand(new DuplicateTagCommand(cache));
            context.AddCommand(new DeleteTagCommand(cache));
            context.AddCommand(new ListNullTagsCommand(cache));
            context.AddCommand(new ListUnnamedTagsCommand(cache));
            context.AddCommand(new ExtractAllBitmapsCommand(cache));
            context.AddCommand(new ExtractBlfImageCommand());
            context.AddCommand(new CreateBlfImageCommand());
            context.AddCommand(new DumpDisassembledShadersCommand(cache));
            context.AddCommand(new FindValueCommand(cache, null));
            context.AddCommand(new TagDependencyCommand(cache));
            context.AddCommand(new GuessTagDefCommand(cache));

            context.AddCommand(new GenerateCacheCommand(cache));
            context.AddCommand(new GenerateDonkeyCacheCommand(cache, contextStack));
            context.AddCommand(new GenerateBlfObjectCommand(cache, cache as GameCacheHaloOnline));
            context.AddCommand(new GenerateMapObjectCommand(cache, cache as GameCacheHaloOnline));
            context.AddCommand(new GenerateTagObjectCommand(cache, cache as GameCacheHaloOnline));
            context.AddCommand(new ConvertVariantCommand(cache));

            context.AddCommand(new EditBlfCommand(contextStack, cache as GameCacheHaloOnline, cache));

            // Halo Online Specific Commands
            if (cache is GameCacheHaloOnlineBase)
            {
                var hoCache = cache as GameCacheHaloOnlineBase;
                context.AddCommand(new SaveTagNamesCommand(hoCache));
                context.AddCommand(new SaveModdedTagsCommand(hoCache));
                context.AddCommand(new CreateTagCommand(hoCache));
                context.AddCommand(new ImportTagCommand(hoCache));
                context.AddCommand(new ImportLooseTagCommand(hoCache));
                context.AddCommand(new TagResourceCommand(hoCache));
                context.AddCommand(new ListUnusedTagsCommand(hoCache));
                context.AddCommand(new ListDuplicateTagsCommand(hoCache));
                context.AddCommand(new GetTagInfoCommand(hoCache));
                context.AddCommand(new GetTagAddressCommand());
                context.AddCommand(new ExtractTagCommand(hoCache));
                context.AddCommand(new ExtractAllTagsCommand(hoCache));
                context.AddCommand(new ExportTagModCommand(hoCache));
                context.AddCommand(new GenerateShaderCommand(hoCache));
                context.AddCommand(new RecompileShadersCommand(hoCache));
                context.AddCommand(new GenerateRenderMethodCommand(hoCache));
                //context.AddCommand(new GenerateRmdfCommand(hoCache));
                context.AddCommand(new GenerateBitmapCommand(hoCache));
                context.AddCommand(new SwitchObjectTypeCommand(hoCache));

				// modding commands
				context.AddCommand(new OpenModPackageCommand(contextStack, hoCache));
                context.AddCommand(new CreateCharacterType(cache));
                context.AddCommand(new GenerateCanvasCommand(hoCache));

                context.AddCommand(new ConvertMapVariantCommand(hoCache));

                context.AddCommand(new UpdateMapFilesCommand(cache));

                context.AddCommand(new RescaleGUICommand(cache));
                context.AddCommand(new RescaleHudTextCommand(cache));
                context.AddCommand(new ImportFontsCommand(hoCache));

                context.AddCommand(new GeneratePhysicsModelCommand(cache));
                context.AddCommand(new CollisionModelTestCommand(hoCache));
                context.AddCommand(new ImportCollisionGeometryCommand(hoCache));
                context.AddCommand(new Test2Command(hoCache));

                context.AddCommand(new ImportAnimationCommand(hoCache));
                context.AddCommand(new TestSerializerCommand(cache));
                context.AddCommand(new NameShaderTagsCommand(hoCache));

                context.AddCommand(new TagResourceReportCommand(hoCache));

                context.AddCommand(new ConvertCacheCommand(cache, hoCache));
                context.AddCommand(new EditMapCommand(contextStack, hoCache, cache));
                context.AddCommand(new ListMapsCommand(hoCache));
            }

            if(cache is GameCacheHaloOnline)
            {
                var hoCache = cache as GameCacheHaloOnline;
                context.AddCommand(new DebugTestCommand(cache, hoCache, contextStack));
                context.AddCommand(new UpdateShaderDataCommand(cache, hoCache));
                context.AddCommand(new UpdateTagListCommand(hoCache));
                context.AddCommand(new RebuildCacheFileCommand(hoCache));
                context.AddCommand(new CreateModPackageCommand(contextStack, hoCache));
                context.AddCommand(new UpdateModPackageCommand(contextStack, hoCache));
                context.AddCommand(new AddForgeCategoryCommand(cache as GameCacheHaloOnlineBase));
                context.AddCommand(new AddForgeItemCommand(cache as GameCacheHaloOnlineBase));
            }

            if (cache is GameCacheModPackage)
            {
                var modCache = cache as GameCacheModPackage;
                context.AddCommand(new UpdateTagListCommand(modCache));
                context.AddCommand(new SwitchTagCacheCommand(modCache));
                context.AddCommand(new ModCacheInfoCommand(modCache));
                context.AddCommand(new SaveModPackageCommand(modCache));
                context.AddCommand(new ExtractFontsCommand(modCache));
                context.AddCommand(new ExtractModFilesCommand(modCache));
                context.AddCommand(new ApplyModPackageCommand(modCache));
				context.AddCommand(new ApplyModPackageTagsCommand(modCache));
				context.AddCommand(new AddTagCacheCommand(modCache));
                context.AddCommand(new DeleteTagCacheCommand(modCache));
                context.AddCommand(new AddModFilesCommand(modCache));
                context.AddCommand(new ListModFilesCommand(modCache));
                context.AddCommand(new DeleteModFilesCommand(modCache));
                context.AddCommand(new NameTagCacheCommand(modCache));
                context.AddCommand(new UpdateDescriptionCommand(modCache));
                context.AddCommand(new SetModTypeCommand(modCache));
                context.AddCommand(new MapFileCommand(modCache));
                context.AddCommand(new AddForgeCategoryCommand(cache as GameCacheHaloOnlineBase));
                context.AddCommand(new AddForgeItemCommand(cache as GameCacheHaloOnlineBase));

                context.AddCommand(new ConvertCacheCommand(modCache, cache as GameCacheHaloOnlineBase));
                context.AddCommand(new UpdateShaderDataCommand(modCache, cache as GameCacheHaloOnlineBase));
                context.AddCommand(new EditMapCommand(contextStack, cache as GameCacheHaloOnlineBase, modCache));
                context.AddCommand(new ExitModPackageCommand(contextStack, modCache));
                context.AddCommand(new DebugTestCommand(modCache, cache as GameCacheHaloOnlineBase, contextStack));
            }

            if(cache is GameCacheMonolithic)
            {
                context.AddCommand(new ExtractTagCommand(cache));
                context.AddCommand(new ExtractAllTagsCommand(cache));
            }

            // porting related
            context.AddCommand(new UseXSDCommand());
            context.AddCommand(new UseAudioCacheCommand());
            context.AddCommand(new UseShaderCacheCommand());
            context.AddCommand(new OpenCacheFileCommand(contextStack, cache));
            context.AddCommand(new DiffTagCommand(cache, portingCache ?? cache));
            context.AddCommand(new VerifyStringsCommand(cache));
            context.AddCommand(new CheckTagCommand(portingCache ?? cache));
        }
    }
}