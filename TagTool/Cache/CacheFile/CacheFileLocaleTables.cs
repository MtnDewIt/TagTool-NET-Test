using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Common;
using TagTool.IO;
using static TagTool.Tags.Definitions.Globals;

namespace TagTool.Cache.CacheFile
{
    public static class CacheFileLocaleTables
    {
        public static List<LocaleTable> Load(EndianReader reader, CacheFileSectionTable sectionTable, string localesKey, LanguagePack[] languagePacks)
        {
            List<LocaleTable> localesTable = new List<LocaleTable>();
            foreach (var language in Enum.GetValues<GameLanguage>())
            {
                LocaleTable table = new LocaleTable();

                var localeBlock = languagePacks[(int)language];
                if (localeBlock.StringCount == 0)
                    continue;

                int stringCount = localeBlock.StringCount;
                int tableSize = localeBlock.LocaleTableSize;
                uint offsetsTableOffset = sectionTable.GetOffset(CacheFileSectionType.LocalizationSection, localeBlock.LocaleIndexTableAddress);
                uint tableOffset = sectionTable.GetOffset(CacheFileSectionType.LocalizationSection, localeBlock.LocaleDataIndexAddress);

                reader.SeekTo(offsetsTableOffset);
                var stringOffsets = new int[stringCount];

                for (int i = 0; i < stringCount; i++)
                {
                    table.Add(new CacheLocalizedString(reader.ReadInt32(), "", i));
                    stringOffsets[i] = reader.ReadInt32();
                }

                reader.SeekTo(tableOffset);

                StringBuffer strings = localesKey == ""
                    ? new StringBuffer(reader.ReadBytes(tableSize))
                    : new StringBuffer(reader.DecryptAesSegment(tableSize, localesKey));

                for (int i = 0; i < stringOffsets.Length; i++)
                {
                    table[i].String = stringOffsets[i] == -1 ? "<null>" : strings.GetString(stringOffsets[i]);
                }

                localesTable.Add(table);
            }

            return localesTable;
        }
    }
}
