using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.Tags.Definitions.Common;

namespace TagTool.Porting.Gen3
{
    public partial class PortingContextGen3
    {
        private GuiTextWidgetDefinition ConvertGuiTextWidget(Stream cacheStream, Stream blamCacheStream, object definition, string blamTagName, GuiTextWidgetDefinition guiTextWidget)
        {
            switch (BlamCache.Version)
            {
                case CacheVersion.Halo3Retail when BlamCache.Platform == CachePlatform.Original:
                    guiTextWidget.CustomFont = GetEquivalentValue(guiTextWidget.CustomFont, guiTextWidget.CustomFont_H3);
                    break;
                case CacheVersion.Halo3Retail when BlamCache.Platform == CachePlatform.MCC:
                    guiTextWidget.CustomFont = GetEquivalentValue(guiTextWidget.CustomFont, guiTextWidget.CustomFont_H3MCC);
                    break;
                case CacheVersion.Halo3ODST:
                    guiTextWidget.CustomFont = GetEquivalentValue(guiTextWidget.CustomFont, guiTextWidget.CustomFont_ODST);
                    break;
            }

            return guiTextWidget;
        }

        private GuiDefinition ConvertGuiDefinition(Stream cacheStream, Stream blamCacheStream, object definition, string blamTagName, GuiDefinition guidefinition)
        {
            if (FlagIsSet(PortingFlags.AutoRescaleGui))
                RescaleGUIDef(guidefinition, 1.3125f);

            return guidefinition;
        }

        private UserInterfaceSharedGlobalsDefinition ConvertUserInterfaceSharedGlobals(UserInterfaceSharedGlobalsDefinition wigl)
        {
            if (BlamCache.Version == CacheVersion.Halo3Retail)
            {
                wigl.UiWidgetBipeds = new List<UserInterfaceSharedGlobalsDefinition.UiWidgetBiped>
                {
                    new UserInterfaceSharedGlobalsDefinition.UiWidgetBiped
                    {
                        AppearanceBipedName = "chief",
                        RosterPlayer1BipedName = "elite",
                    }
                };
            }

            return wigl;
        }
    }
}
