using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags;
using System.IO;
using System.Text.RegularExpressions;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.Linq;
using System;
using System.Globalization;

namespace TagTool.Commands.MtnDewIt 
{
    public abstract class TagFile 
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }

        public Stream Stream { get; set; }

        public TagFile(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) 
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
        }

        public CachedTag GetCachedTag<T>(string tagName) where T : TagStructure
        {
            var tagAttribute = TagStructure.GetTagStructureAttribute(typeof(T), CacheContext.Version, CacheContext.Platform);
            var typeName = tagAttribute.Tag;

            if (CacheContext.TagCache.TryGetTag<T>(tagName, out var result))
            {
                return result;
            }
            else
            {
                new TagToolWarning($@"Could not find tag: '{tagName}.{typeName}'. Assigning null tag instead");
                return null;
            }
        }

        public void AddString(MultilingualUnicodeStringList unic, string stringIdName, string stringIdContent)
        {
            var stringIdIndex = Cache.StringTable.IndexOf(stringIdName);

            if (stringIdIndex < 0)
            {
                Cache.StringTable.AddString(stringIdName);
                Cache.SaveStrings();

                stringIdIndex = Cache.StringTable.IndexOf(stringIdName);
            }
            var stringId = Cache.StringTable.GetStringId(stringIdIndex);

            var parsedContent = new Regex(@"\\[uU]([0-9A-F]{4})").Replace(stringIdContent, match => ((char)Int32.Parse(match.Value.Substring(2), NumberStyles.HexNumber)).ToString());

            var localizedStr = unic.Strings.FirstOrDefault(s => s.StringID == stringId);

            if (localizedStr == null)
            {
                localizedStr = new LocalizedString
                {
                    StringID = stringId,
                    StringIDStr = stringIdName
                };

                unic.Strings.Add(localizedStr);
            }

            unic.SetString(localizedStr, GameLanguage.English, parsedContent);
        }

        public abstract void TagData();
    }
}