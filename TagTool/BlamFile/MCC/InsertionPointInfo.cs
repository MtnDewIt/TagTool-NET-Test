using System;
using TagTool.Tags;

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

            //public int GetMapIdFromGuid()
            //{
            //
            //}
        }

        public void ConvertInsertionPointInfo(BlfScenarioInsertion insertion, int index)
        {
            insertion.Visible = Valid;
            insertion.ZoneSetIndex = (short)ZoneSetIndex;

            if (ODST != null)
                if (ODST.IsFirefight)
                    insertion.Flags = BlfScenarioInsertion.BlfScenarioInsertionFlags.SurvivalBit;

            //insertion.ReturnFromMapId = ODST.GetMapIdFromGuid();

            var parsedTitle = Title.ParseLocalizedString(31, $"Insertion Point {index} Title");
            var parsedDescription = Description.ParseLocalizedString(127, $"Insertion Point {index} Description");

            for (int i = 0; i < insertion.Names.Length; i++)
                insertion.Names[i].Name = parsedTitle;

            for (int i = 0; i < insertion.Descriptions.Length; i++)
                insertion.Descriptions[i].Name = parsedDescription;
        }
    }
}