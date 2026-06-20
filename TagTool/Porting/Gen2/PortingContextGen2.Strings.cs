using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using Gen2MultilingualUnicodeStringList = TagTool.Tags.Definitions.Gen2.MultilingualUnicodeStringList;

namespace TagTool.Porting.Gen2
{
    partial class PortingContextGen2
    {
        public TagStructure ConvertMultilingualUnicodeStringList(Stream blamCacheStream, Gen2MultilingualUnicodeStringList gen2Unic) 
        {
            MultilingualUnicodeStringList unic = new();

            ushort[] stringIndex = new ushort[12];
            ushort[] stringCount = new ushort[12];

            int srcIndex = 0;

            for (int i = 0; i < 11; i++)
            {
                stringIndex[i] = gen2Unic.OffsetCounts[srcIndex];
                stringCount[i] = gen2Unic.OffsetCounts[srcIndex + 1];

                if (i != 4 && i != 8)
                {
                    srcIndex += 2;
                }
            }

            stringIndex[11] = 0;
            stringCount[11] = 0;

            //
            // Convert LocaleTables to a Dictionary
            //

            Dictionary<int, KeyValuePair<int, List<string>>> table = new Dictionary<int, KeyValuePair<int, List<string>>>();

            BlamCache.LoadLocaleTables(blamCacheStream);

            var localeTable = BlamCache.LocaleTables;

            for (int i = 0; i < localeTable.Count; i++)
            {
                var localizedStringList = localeTable[i];
                for (int j = 0; j < localizedStringList.Count(); j++)
                {
                    var localizedString = localizedStringList[j];
                    var tempPair = table.ContainsKey(localizedString.Index) ? table[localizedString.Index] : new KeyValuePair<int, List<string>>(localizedString.StringIndex, new List<string> { "", "", "", "", "", "", "", "", "", "", "", "" });
                    tempPair.Value[i] = localizedString.String;
                    table[localizedString.Index] = tempPair;
                }
            }

            //
            // Determine the max count while ignoring the languages that have 0
            //

            List<ushort> fixedStartIndex = new List<ushort>();
            int zeroCount = 0;
            foreach (var startIndex in stringIndex)
            {
                if (startIndex > 0)
                {
                    fixedStartIndex.Add(startIndex);
                }
                else if (startIndex == 0)
                {
                    zeroCount++;
                }
            }
            int begin;

            if (zeroCount == 12)
                begin = 0;
            else
                begin = fixedStartIndex.Max();

            var count = stringCount.Max();

            string data = "";
            unic.Strings = new List<LocalizedString>();

            for (int i = begin; i < begin + count; i++)
            {
                var pair = table[i];
                var stringBlock = new LocalizedString
                {
                    StringID = ConvertStringId(new StringId((uint)pair.Key)),
                    StringIDStr = null,
                };

                var locales = pair.Value;

                int localeSrcIndex = 0;

                for (int j = 0; j < 11; j++)
                {
                    if (i < stringIndex[j] || i >= stringIndex[j] + stringCount[j]) // Index is out of bounds for this particular locale
                    {
                        stringBlock.Offsets[j] = -1;
                    }
                    else
                    {
                        if (j == 5)
                        {
                            stringBlock.Offsets[j] = stringBlock.Offsets[4];
                        }
                        else if (j == 9)
                        {
                            stringBlock.Offsets[j] = stringBlock.Offsets[8];
                        }
                        else
                        {
                            stringBlock.Offsets[j] = Encoding.UTF8.GetBytes(data).Length;
                            data = data + locales[localeSrcIndex] + '\0';
                        }
                    }

                    if (j != 4 && j != 8)
                    {
                        localeSrcIndex++;
                    }
                }

                stringBlock.Offsets[11] = -1;

                unic.Strings.Add(stringBlock);
            }

            unic.Data = Encoding.UTF8.GetBytes(data);

            unic.OffsetCounts = new ushort[24];

            return unic;
        }
    }
}
