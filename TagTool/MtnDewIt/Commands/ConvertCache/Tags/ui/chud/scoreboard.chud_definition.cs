using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_chud_scoreboard_chud_definition : TagFile
    {
        public ui_chud_scoreboard_chud_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<ChudDefinition>($@"ui\chud\scoreboard");
            var chdt = CacheContext.Deserialize<ChudDefinition>(Stream, tag);
            chdt.HudWidgets[0].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
            chdt.HudWidgets[0].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[1].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(-11f, 2.5f);
            chdt.HudWidgets[1].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.56f, 0.56f);
            chdt.HudWidgets[1].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[1].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
            chdt.HudWidgets[1].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
            chdt.HudWidgets[1].TextWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
            chdt.HudWidgets[1].TextWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
            chdt.HudWidgets[1].TextWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
            chdt.HudWidgets[1].TextWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
            chdt.HudWidgets[1].TextWidgets[7].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
            chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(-11f, 2.5f);
            chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.56f, 0.56f);
            chdt.HudWidgets[2].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[2].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
            chdt.HudWidgets[2].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
            chdt.HudWidgets[2].TextWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
            chdt.HudWidgets[2].TextWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
            chdt.HudWidgets[2].TextWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
            chdt.HudWidgets[2].TextWidgets[6].Name = CacheContext.StringTable.GetStringId("bomb_dropped");
            chdt.HudWidgets[2].TextWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
            chdt.HudWidgets[2].TextWidgets[6].InputString = CacheContext.StringTable.GetStringId("gm_assault_bomb_dropped");
            chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(-2f, 2);
            chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.58f, 0.58f);
            chdt.HudWidgets[3].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Offset = new RealPoint2d(-2f, 2);
            chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.58f, 0.58f);
            chdt.HudWidgets[3].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[4].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 0f);
            chdt.HudWidgets[4].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.88f, 1.2f);
            chdt.HudWidgets[4].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, -25f);
            chdt.HudWidgets[4].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.38f, 0.38f);
            chdt.HudWidgets[4].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.4f);
            chdt.HudWidgets[5].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.4f);
            chdt.HudWidgets[5].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.4f);
            chdt.HudWidgets[5].TextWidgets[2].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[7].PlacementData[0].Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.BottomRight;
            chdt.HudWidgets[7].PlacementData[0].Offset = new RealPoint2d(55f, -150f);
            CacheContext.Serialize(Stream, tag, chdt);
        }
    }
}
