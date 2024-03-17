using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class ui_halox_pregame_lobby_switch_lobby_lobbies_gui_datasource_definition : TagFile
    {
        public ui_halox_pregame_lobby_switch_lobby_lobbies_gui_datasource_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            TagData();
        }

        public override void TagData()
        {
            var tag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\pregame_lobby\switch_lobby\lobbies");
            var dsrc = CacheContext.Deserialize<GuiDatasourceDefinition>(Stream, tag);
            dsrc.Name = CacheContext.StringTable.GetOrAddString($@"switch_lobby");
            dsrc.Elements = new List<GuiDatasourceDefinition.DatasourceElementBlock>()
            {
                new GuiDatasourceDefinition.DatasourceElementBlock
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"name"),
                            Value = CacheContext.StringTable.GetOrAddString($@"campaign"),
                        },
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"description"),
                            Value = CacheContext.StringTable.GetOrAddString($@"campaign_help"),
                        },
                    },
                },
                new GuiDatasourceDefinition.DatasourceElementBlock
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"name"),
                            Value = CacheContext.StringTable.GetOrAddString($@"survival"),
                        },
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"description"),
                            Value = CacheContext.StringTable.GetOrAddString($@"survival_help"),
                        },
                    },
                },
                new GuiDatasourceDefinition.DatasourceElementBlock
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"name"),
                            Value = CacheContext.StringTable.GetOrAddString($@"multiplayer"),
                        },
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"description"),
                            Value = CacheContext.StringTable.GetOrAddString($@"custom_games_help"),
                        },
                    },
                },
                new GuiDatasourceDefinition.DatasourceElementBlock
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"name"),
                            Value = CacheContext.StringTable.GetOrAddString($@"mapeditor"),
                        },
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"description"),
                            Value = CacheContext.StringTable.GetOrAddString($@"editor_help"),
                        },
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, dsrc);
        }
    }
}
