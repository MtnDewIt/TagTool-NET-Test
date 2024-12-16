using System;
using System.Collections.Generic;
using System.Linq;
using TagTool.Commands.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.BlamFile.MCC
{
    public class InsertionPointInfo : TagStructure
    {
        public string ZoneSetName;
        public int ZoneSetIndex;
        public bool Valid;
        public LocalizedString Title;
        public LocalizedString Description;
        public ODSTInfo ODST;
        public string Thumbnail;

        public class ODSTInfo
        {
            public bool IsFirefight;
            public Guid ReturnFromMapGuid;

            public int GetMapIdFromMapGuid(Dictionary<string, Scenario> scenarioTable, Dictionary<string, CampaignMapInfo> campaignInfoList)
            {
                if (campaignInfoList != null)
                {
                    var mapId = campaignInfoList
                        .Where(mapInfo => mapInfo.Value.MapGuid == ReturnFromMapGuid)
                        .SelectMany(mapInfo => scenarioTable
                        .Where(scenario => scenario.Key.EndsWith(mapInfo.Key))
                        .Select(scenario => scenario.Value.MapId))
                        .FirstOrDefault();

                    return mapId;
                }

                new TagToolWarning("Failed to resolve ReturnFromMapId - Campaign Map Info List Was Empty");

                return 0;
            }
        }

        public void ConvertInsertionPointInfo(Dictionary<string, Scenario> scenarioTable, Dictionary<string, CampaignMapInfo> campaignInfoList, BlfScenarioInsertion insertion, int index)
        {
            insertion.Visible = Valid;
            insertion.ZoneSetIndex = (short)ZoneSetIndex;

            if (ODST != null) 
            {
                if (ODST.IsFirefight) 
                {
                    insertion.Flags = BlfScenarioInsertion.BlfScenarioInsertionFlags.SurvivalBit;
                }

                if (ODST.ReturnFromMapGuid != Guid.Empty) 
                {
                    insertion.ReturnFromMapId = ODST.GetMapIdFromMapGuid(scenarioTable, campaignInfoList);
                }
            }       

            var parsedTitle = Title.ParseLocalizedString(31, $"Insertion Point {index} Title");
            var parsedDescription = Description.ParseLocalizedString(127, $"Insertion Point {index} Description");

            for (int i = 0; i < insertion.Names.Length; i++)
                insertion.Names[i].Name = parsedTitle;

            for (int i = 0; i < insertion.Descriptions.Length; i++)
                insertion.Descriptions[i].Name = parsedDescription;
        }
    }
}