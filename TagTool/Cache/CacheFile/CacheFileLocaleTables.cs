using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Common;
using TagTool.IO;
using Globals = TagTool.Tags.Definitions.Globals;
using Gen2Globals = TagTool.Tags.Definitions.Gen2.Globals;

namespace TagTool.Cache.CacheFile
{
    public static class CacheFileLocaleTables
    {
        public static List<LocaleTable> Load(EndianReader reader, CacheFileSectionTable sectionTable, string localesKey, Globals.LanguagePack[] languagePacks)
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

        public static List<LocaleTable> Load(EndianReader reader, Gen2Globals.LanguagePack[] languagePacks)
        {
            List<LocaleTable> localesTable = new List<LocaleTable>();
            foreach (var language in Enum.GetValues<Gen2Globals.LanguageValue>())
            {
                LocaleTable table = new LocaleTable();

                var localeBlock = languagePacks[(int)language];
                if (localeBlock.StringCount == 0)
                    continue;

                uint indexTableAddress = localeBlock.LocaleIndexTableAddress & 0x7FFFFFFF;

                reader.SeekTo(indexTableAddress);

                var stringIds = new uint[localeBlock.StringCount];
                var dataOffsets = new uint[localeBlock.StringCount];

                for (int i = 0; i < localeBlock.StringCount; i++)
                {
                    stringIds[i] = reader.ReadUInt32();
                    dataOffsets[i] = reader.ReadUInt32();
                }

                uint dataIndexAddress = localeBlock.LocaleDataIndexAddress & 0x7FFFFFFF;

                reader.SeekTo(dataIndexAddress);

                var blob = new StringBuffer(reader.ReadBytes(localeBlock.LocaleTableSize));

                for (int i = 0; i < localeBlock.StringCount; i++)
                {
                    string str = dataOffsets[i] == 0xFFFFFFFF  ? "<null>"
                        : blob.GetString((int)dataOffsets[i]);
                    table.Add(new CacheLocalizedString((int)stringIds[i], str, i));
                }

                localesTable.Add(table);
            }

            return localesTable;
        }
    }
}
