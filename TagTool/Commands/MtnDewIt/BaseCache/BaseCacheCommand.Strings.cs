using System.Text.RegularExpressions;
using System;
using TagTool.Tags.Definitions;
using System.Linq;
using System.Globalization;
using TagTool.Common;

namespace TagTool.Commands.Tags
{
    partial class BaseCacheCommand : Command
    {
        // Converts a given string into a localized string which can then be input into a string list tag
        LocalizedString ConvertString(string input, MultilingualUnicodeStringList unic)
        {
            var stringIdStr = input;
            var stringIdIndex = Cache.StringTable.IndexOf(stringIdStr);
            var stringId = Cache.StringTable.GetStringId(stringIdIndex);
            var localizedStr = unic.Strings.FirstOrDefault(s => s.StringID == stringId);
            return localizedStr;
        }

        // Parses the specified string for conversion into a localized string
        String ParseString(string input)
        {
            var parsedString = new Regex(@"\\[uU]([0-9A-F]{4})").Replace(input, match => ((char)Int32.Parse(match.Value.Substring(2), NumberStyles.HexNumber)).ToString());
            return parsedString;
        }

        // Replaces the specified strings with the specified input values
        public void modifyStrings() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    // Will update once the main menu UI is functional
                }
            }
        }
    }
}