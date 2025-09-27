﻿using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Common;
using TagTool.IO;
using TagTool.BlamFile;
using TagTool.Tags.Definitions;

namespace TagTool.Cache.Gen3
{
    public class LocalesTableGen3
    {
        public static List<LocaleTable> CreateLocalesTable(EndianReader reader, MapFile baseMapFile, Globals matg)
        {
            
            List<LocaleTable> localesTable = new List<LocaleTable>();
            string localesKey = "";

            if (baseMapFile.Platform == CachePlatform.Original) 
            {
                localesKey = baseMapFile.Version switch 
                {
                    CacheVersion.HaloReachAlpha or
                    CacheVersion.HaloReachPreBeta or
                    CacheVersion.HaloReachBeta => "rs&m*l#/t%_()e;[",
                    CacheVersion.HaloReach => "BungieHaloReach!",
                    _ => ""
                };
            }
            var sectionTable = baseMapFile.Header.GetSectionTable();

            if (sectionTable.Sections[(int)CacheFileSectionType.LocalizationSection].Size == 0)
                return new List<LocaleTable>();

            foreach (var language in Enum.GetValues(typeof(GameLanguage)))
            {
                LocaleTable table = new LocaleTable();
                var languageIndex = (int)language;

                var localeBlock = matg.LanguagePacks[languageIndex];

                if (baseMapFile.Platform == CachePlatform.MCC)
                    localeBlock = matg.LanguagePacksMCC[languageIndex];

                if (localeBlock.StringCount == 0)
                    continue;


                var stringCount = localeBlock.StringCount;
                var tableSize = localeBlock.LocaleTableSize;
                var offsetsTableOffset = sectionTable.GetOffset(CacheFileSectionType.LocalizationSection, localeBlock.LocaleIndexTableAddress);
                var tableOffset = sectionTable.GetOffset(CacheFileSectionType.LocalizationSection, localeBlock.LocaleDataIndexAddress);

                reader.SeekTo(offsetsTableOffset);
                var stringOffsets = new int[stringCount];

                for (var i = 0; i < stringCount; i++)
                {
                    table.Add(new CacheLocalizedString(reader.ReadInt32(), "", i));
                    stringOffsets[i] = reader.ReadInt32();
                }

                reader.SeekTo(tableOffset);

                EndianReader newReader = null;

                if (localesKey == "")
                    newReader = new EndianReader(new MemoryStream(reader.ReadBytes(tableSize)), EndianFormat.BigEndian);
                else
                    newReader = new EndianReader(reader.DecryptAesSegment(tableSize, localesKey));

                for (var i = 0; i < stringOffsets.Length; i++)
                {
                    if (stringOffsets[i] == -1)
                    {
                        table[i].String = "<null>";
                        continue;
                    }
                    newReader.SeekTo(stringOffsets[i]);
                    table[i].String = newReader.ReadNullTerminatedString();
                }

                newReader.Close();
                newReader.Dispose();

                localesTable.Add(table);
            }

            return localesTable;
        }
    }

}
