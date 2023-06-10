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

        // Adds the input stringId to the specified string list tag
        public void AddString(MultilingualUnicodeStringList unic, string stringIdName, string stringIdContent) 
        {
            CacheContext.StringTable.AddString(stringIdName);
            CacheContext.SaveStrings();

            var stringIdIndex = Cache.StringTable.IndexOf(stringIdName);
            var stringId = Cache.StringTable.GetStringId(stringIdIndex);

            var newString = new LocalizedString 
            { 
                StringID = stringId, 
                StringIDStr = stringIdName, 
            };

            unic.Strings.Add(newString);

            unic.SetString(newString, GameLanguage.English, ParseString(stringIdContent));
        }

        // Adds new stringIds to the specified string list tags
        public void AddNewStrings()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                foreach (var tag in CacheContext.TagCache.NonNull())
                {
                    if (tag.IsInGroup("unic") && tag.Name == $@"ui\halox\start_menu\panes\settings_appearance_colors\strings")
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        AddString(unic, "cef_color_detail", "Detail Color");
                        AddString(unic, "cef_color_detail_desc", "The armor detail color preserves your individual identity in all multiplayer scenarios.");
                        AddString(unic, "cef_color_light", "Light Color");
                        AddString(unic, "cef_color_light_desc", "Like Christmas, but more subtle.");
                        AddString(unic, "cef_color_primary", "Primary Color");
                        AddString(unic, "cef_color_primary_desc", "The primary armor color will serve you in individual combat but will be overwritten in team scenarios.");
                        AddString(unic, "cef_color_secondary", "Secondary Color");
                        AddString(unic, "cef_color_secondary_desc", "The secondary armor color accents your primary color and will be overwritten in team scenarios.");
                        AddString(unic, "cef_color_visor", "Visor Color");
                        AddString(unic, "cef_color_visor_desc", "Adjust the tint of your Spartan's visor.");
                        AddString(unic, "cef_elite_color_flair", "Flair Color");
                        AddString(unic, "cef_elite_color_flair_desc", "The secondary armor color accents your primary color and will always represent you in any scenario.");
                        AddString(unic, "cef_elite_color_light", "Light Color");
                        AddString(unic, "cef_elite_color_light_desc", "Like Christmas, but more subtle.");
                        AddString(unic, "cef_elite_color_primary", "Primary Color");
                        AddString(unic, "cef_elite_color_primary_desc", "The primary armor color will serve you in individual combat but will be overwritten in team scenarios.");
                        AddString(unic, "cef_elite_color_primary_sheen", "Primary Color Sheen");
                        AddString(unic, "cef_elite_color_primary_sheen_desc", "The primary armor color sheen will always represent you in any scenario.");
                        AddString(unic, "cef_elite_color_secondary", "Secondary Color");
                        AddString(unic, "cef_elite_color_secondary_desc", "The secondary armor color accents your primary color and will always represent you in any scenario.");
                        AddString(unic, "cef_spartan_color_detail", "Detail Color");
                        AddString(unic, "cef_spartan_color_detail_desc", "The armor detail color preserves your individual identity in all multiplayer scenarios.");
                        AddString(unic, "cef_spartan_color_light", "Light Color");
                        AddString(unic, "cef_spartan_color_light_desc", "Like Christmas, but more subtle.");
                        AddString(unic, "cef_spartan_color_primary", "Primary Color");
                        AddString(unic, "cef_spartan_color_primary_desc", "The primary armor color will serve you in individual combat but will be overwritten in team scenarios.");
                        AddString(unic, "cef_spartan_color_secondary", "Secondary Color");
                        AddString(unic, "cef_spartan_color_secondary_desc", "The secondary armor color accents your primary color and will be overwritten in team scenarios.");
                        AddString(unic, "cef_spartan_color_visor", "Visor Color");
                        AddString(unic, "cef_spartan_color_visor_desc", "Adjust the tint of your Spartan's visor.");
                        CacheContext.Serialize(stream, tag, unic);
                    }
                }
            }
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