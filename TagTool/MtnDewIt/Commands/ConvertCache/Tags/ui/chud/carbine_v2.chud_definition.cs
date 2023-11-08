using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_chud_carbine_v2_chud_definition : TagFile
    {
        public ui_chud_carbine_v2_chud_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<ChudDefinition>($@"ui\chud\carbine_v2");
            var chdt = CacheContext.Deserialize<ChudDefinition>(Stream, tag);
            //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
            //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
            //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            //chdt.HudWidgets[1].BitmapWidgets[0].Name = CacheContext.StringTable.GetStringId($@"overheat_flash");
            //chdt.HudWidgets[1].BitmapWidgets[0].StateData[0].SkinState = ChudDefinition.HudWidgetBase.StateDatum.ChudSkinState.Elite;
            //chdt.HudWidgets[1].BitmapWidgets[0].StateData[0].WindowState = ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.WideFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.NativeFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.StandardFull;
            //chdt.HudWidgets[1].BitmapWidgets[0].StateData[0].Weapon_SpecialFlags = ChudDefinition.HudWidgetBase.StateDatum.Weapon_Special.Overheated;
            //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
            //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
            //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
            //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(11f, 0f);
            //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.42f);
            //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 39;
            //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
            //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
            //chdt.HudWidgets[2].BitmapWidgets[2].BitmapSequenceIndex = 37;
            //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Origin = new RealPoint2d(10.5f, 0f);
            //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.47f, 0.42f);
            //chdt.HudWidgets[2].BitmapWidgets[3].BitmapSequenceIndex = 39;
            //chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
            //chdt.HudWidgets[2].BitmapWidgets[4].BitmapSequenceIndex = 37;
            //chdt.HudWidgets[2].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
            //chdt.HudWidgets[2].BitmapWidgets[5].BitmapSequenceIndex = 37;
            //chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
            //chdt.HudWidgets[2].BitmapWidgets[6].BitmapSequenceIndex = 37;
            chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
            chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
            chdt.HudWidgets[5].TextWidgets[0].Font = WidgetFontValue.FullscreenHudMessage;
            CacheContext.Serialize(Stream, tag, chdt);
        }
    }
}
