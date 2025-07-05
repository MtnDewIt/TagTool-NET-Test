using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Ai;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.Serialization;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.Porting.Gen3
{
    partial class PortingContextGen3
    {
        private Globals ConvertGlobals(Globals matg, Stream cacheStream)
        {
            //Add aigl from H3

            if (BlamCache.Version == CacheVersion.Halo3Retail)
            {
                AiGlobals aigl = new AiGlobals
                {
                    Data = new List<AiGlobalsDatum>(),
                };
                foreach (var value in matg.AiGlobals)
                {
                    value.PathfindingSearchRanges.Infantry = 30;
                    value.PathfindingSearchRanges.Flying = 40;
                    value.PathfindingSearchRanges.Vehicle = 40;
                    value.PathfindingSearchRanges.Giant = 200;

                    //Something may need to be done about squad and formation tags

                    aigl.Data.Add(value);
                }

                CachedTag edTag = CacheContext.TagCacheGenHO.AllocateTag(CacheContext.TagCache.TagDefinitions.GetTagGroupFromTag("aigl"));
                edTag.Name = "globals\ai_globals";
                CacheContext.Serialize(cacheStream, edTag, aigl);
                matg.AiGlobalsTag = edTag;
                matg.AiGlobals = new List<AiGlobalsDatum>();
            }

            //Might require adding the GfxUiStrings block

            if (BlamCache.Version == CacheVersion.Halo3Retail)
            {
                matg.ShieldBoost = new List<Globals.ShieldBoostBlock>
                {
                    new Globals.ShieldBoostBlock
                    {
                        ShieldBoostDecay = 100,
                        ShieldBoostRechargeTime = 1,
                        ShieldBoostStunTime = 1
                    }
                };

                foreach (var metagame in matg.CampaignMetagameGlobals)
                {
                    //Medal values for H3 do not need to be modified, but if survival is introduced on an H3 port, it will require ODST or HO points

                    metagame.FirstWeaponSpree = 5;
                    metagame.SecondWeaponSpree = 10;
                    metagame.KillingSpree = 10;
                    metagame.KillingFrenzy = 20;
                    metagame.RunningRiot = 30;
                    metagame.Rampage = 40;
                    metagame.Untouchable = 50;
                    metagame.Invincible = 100;
                    metagame.DoubleKill = 2;
                    metagame.TripleKill = 3;
                    metagame.Overkill = 4;
                    metagame.Killtacular = 5;
                    metagame.Killtrocity = 6;
                    metagame.Killimanjaro = 7;
                    metagame.Killtastrophe = 8;
                    metagame.Killpocalypse = 9;
                    metagame.Killionaire = 10;
                }
            }

            return matg;
        }

        private void MergeMultiplayerEvent(Stream cacheStream, Stream blamCacheStream, MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock edEvent, MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock h3Event)
        {
            if (h3Event.EnglishSound != null)
                edEvent.EnglishSound = ConvertTag(cacheStream, blamCacheStream, h3Event.EnglishSound);

            if (h3Event.JapaneseSound != null)
                edEvent.JapaneseSound = ConvertTag(cacheStream, blamCacheStream, h3Event.JapaneseSound);

            if (h3Event.GermanSound != null)
                edEvent.GermanSound = ConvertTag(cacheStream, blamCacheStream, h3Event.GermanSound);

            if (h3Event.FrenchSound != null)
                edEvent.FrenchSound = ConvertTag(cacheStream, blamCacheStream, h3Event.FrenchSound);

            if (h3Event.SpanishSound != null)
                edEvent.SpanishSound = ConvertTag(cacheStream, blamCacheStream, h3Event.SpanishSound);

            if (h3Event.LatinAmericanSpanishSound != null)
                edEvent.LatinAmericanSpanishSound = ConvertTag(cacheStream, blamCacheStream, h3Event.LatinAmericanSpanishSound);

            if (h3Event.ItalianSound != null)
                edEvent.ItalianSound = ConvertTag(cacheStream, blamCacheStream, h3Event.ItalianSound);

            if (h3Event.KoreanSound != null)
                edEvent.KoreanSound = ConvertTag(cacheStream, blamCacheStream, h3Event.KoreanSound);

            if (h3Event.ChineseTraditionalSound != null)
                edEvent.ChineseTraditionalSound = ConvertTag(cacheStream, blamCacheStream, h3Event.ChineseTraditionalSound);

            if (h3Event.ChineseSimplifiedSound != null)
                edEvent.ChineseSimplifiedSound = ConvertTag(cacheStream, blamCacheStream, h3Event.ChineseSimplifiedSound);

            if (h3Event.PortugueseSound != null)
                edEvent.PortugueseSound = ConvertTag(cacheStream, blamCacheStream, h3Event.PortugueseSound);

            if (h3Event.PolishSound != null)
                edEvent.PolishSound = ConvertTag(cacheStream, blamCacheStream,  h3Event.PolishSound);
        }

        private void MergeMultiplayerGlobals(Stream cacheStream, Stream blamCacheStream, CachedTag edTag, CachedTag h3Tag)
        {
            var edDef = CacheContext.Deserialize<MultiplayerGlobals>(cacheStream, edTag);
            var h3Def = BlamCache.Deserialize<MultiplayerGlobals>(blamCacheStream, h3Tag);

            if (h3Def.Runtime == null || h3Def.Runtime.Count == 0)
                return;

            for (var i = 0; i < h3Def.Runtime[0].GeneralEvents.Count; i++)
            {
                var h3Event = h3Def.Runtime[0].GeneralEvents[i];

                if (h3Event.DisplayString == StringId.Invalid)
                    continue;

                var h3String = BlamCache.StringTable.GetString(h3Event.DisplayString);

                for (var j = 0; j < edDef.Runtime[0].GeneralEvents.Count; j++)
                {
                    var edEvent = edDef.Runtime[0].GeneralEvents[j];
                    var edString = CacheContext.StringTable.GetString(edEvent.DisplayString);

                    if (edString == h3String)
                        MergeMultiplayerEvent(cacheStream, blamCacheStream, edEvent, h3Event);
                }
            }

            for (var i = 0; i < h3Def.Runtime[0].FlavorEvents.Count; i++)
            {
                var h3Event = h3Def.Runtime[0].FlavorEvents[i];

                if (h3Event.DisplayString == StringId.Invalid)
                    continue;

                var h3String = BlamCache.StringTable.GetString(h3Event.DisplayString);

                for (var j = 0; j < edDef.Runtime[0].FlavorEvents.Count; j++)
                {
                    var edEvent = edDef.Runtime[0].FlavorEvents[j];
                    var edString = CacheContext.StringTable.GetString(edEvent.DisplayString);

                    if (edString == h3String)
                        MergeMultiplayerEvent(cacheStream, blamCacheStream, edEvent, h3Event);
                }
            }

            for (var i = 0; i < h3Def.Runtime[0].SlayerEvents.Count; i++)
            {
                var h3Event = h3Def.Runtime[0].SlayerEvents[i];

                if (h3Event.DisplayString == StringId.Invalid)
                    continue;

                var h3String = BlamCache.StringTable.GetString(h3Event.DisplayString);

                for (var j = 0; j < edDef.Runtime[0].SlayerEvents.Count; j++)
                {
                    var edEvent = edDef.Runtime[0].SlayerEvents[j];
                    var edString = CacheContext.StringTable.GetString(edEvent.DisplayString);

                    if (edString == h3String)
                        MergeMultiplayerEvent(cacheStream, blamCacheStream, edEvent, h3Event);
                }
            }

            for (var i = 0; i < h3Def.Runtime[0].CtfEvents.Count; i++)
            {
                var h3Event = h3Def.Runtime[0].CtfEvents[i];

                if (h3Event.DisplayString == StringId.Invalid)
                    continue;

                var h3String = BlamCache.StringTable.GetString(h3Event.DisplayString);

                for (var j = 0; j < edDef.Runtime[0].CtfEvents.Count; j++)
                {
                    var edEvent = edDef.Runtime[0].CtfEvents[j];
                    var edString = CacheContext.StringTable.GetString(edEvent.DisplayString);

                    if (edString == h3String)
                        MergeMultiplayerEvent(cacheStream, blamCacheStream, edEvent, h3Event);
                }
            }

            for (var i = 0; i < h3Def.Runtime[0].OddballEvents.Count; i++)
            {
                var h3Event = h3Def.Runtime[0].OddballEvents[i];

                if (h3Event.DisplayString == StringId.Invalid)
                    continue;

                var h3String = BlamCache.StringTable.GetString(h3Event.DisplayString);

                for (var j = 0; j < edDef.Runtime[0].OddballEvents.Count; j++)
                {
                    var edEvent = edDef.Runtime[0].OddballEvents[j];
                    var edString = CacheContext.StringTable.GetString(edEvent.DisplayString);

                    if (edString == h3String)
                        MergeMultiplayerEvent(cacheStream, blamCacheStream, edEvent, h3Event);
                }
            }

            for (var i = 0; i < h3Def.Runtime[0].KingOfTheHillEvents.Count; i++)
            {
                var h3Event = h3Def.Runtime[0].KingOfTheHillEvents[i];

                if (h3Event.DisplayString == StringId.Invalid)
                    continue;

                var h3String = BlamCache.StringTable.GetString(h3Event.DisplayString);

                for (var j = 0; j < edDef.Runtime[0].KingOfTheHillEvents.Count; j++)
                {
                    var edEvent = edDef.Runtime[0].KingOfTheHillEvents[j];
                    var edString = CacheContext.StringTable.GetString(edEvent.DisplayString);

                    if (edString == h3String)
                        MergeMultiplayerEvent(cacheStream, blamCacheStream, edEvent, h3Event);
                }
            }

            for (var i = 0; i < h3Def.Runtime[0].VipEvents.Count; i++)
            {
                var h3Event = h3Def.Runtime[0].VipEvents[i];

                if (h3Event.DisplayString == StringId.Invalid)
                    continue;

                var h3String = BlamCache.StringTable.GetString(h3Event.DisplayString);

                for (var j = 0; j < edDef.Runtime[0].VipEvents.Count; j++)
                {
                    var edEvent = edDef.Runtime[0].VipEvents[j];
                    var edString = CacheContext.StringTable.GetString(edEvent.DisplayString);

                    if (edString == h3String)
                        MergeMultiplayerEvent(cacheStream, blamCacheStream, edEvent, h3Event);
                }
            }

            for (var i = 0; i < h3Def.Runtime[0].JuggernautEvents.Count; i++)
            {
                var h3Event = h3Def.Runtime[0].JuggernautEvents[i];

                if (h3Event.DisplayString == StringId.Invalid)
                    continue;

                var h3String = BlamCache.StringTable.GetString(h3Event.DisplayString);

                for (var j = 0; j < edDef.Runtime[0].JuggernautEvents.Count; j++)
                {
                    var edEvent = edDef.Runtime[0].JuggernautEvents[j];
                    var edString = CacheContext.StringTable.GetString(edEvent.DisplayString);

                    if (edString == h3String)
                        MergeMultiplayerEvent(cacheStream, blamCacheStream, edEvent, h3Event);
                }
            }

            for (var i = 0; i < h3Def.Runtime[0].TerritoriesEvents.Count; i++)
            {
                var h3Event = h3Def.Runtime[0].TerritoriesEvents[i];

                if (h3Event.DisplayString == StringId.Invalid)
                    continue;

                var h3String = BlamCache.StringTable.GetString(h3Event.DisplayString);

                for (var j = 0; j < edDef.Runtime[0].TerritoriesEvents.Count; j++)
                {
                    var edEvent = edDef.Runtime[0].TerritoriesEvents[j];
                    var edString = CacheContext.StringTable.GetString(edEvent.DisplayString);

                    if (edString == h3String)
                        MergeMultiplayerEvent(cacheStream, blamCacheStream, edEvent, h3Event);
                }
            }

            for (var i = 0; i < h3Def.Runtime[0].AssaultEvents.Count; i++)
            {
                var h3Event = h3Def.Runtime[0].AssaultEvents[i];

                if (h3Event.DisplayString == StringId.Invalid)
                    continue;

                var h3String = BlamCache.StringTable.GetString(h3Event.DisplayString);

                for (var j = 0; j < edDef.Runtime[0].AssaultEvents.Count; j++)
                {
                    var edEvent = edDef.Runtime[0].AssaultEvents[j];
                    var edString = CacheContext.StringTable.GetString(edEvent.DisplayString);

                    if (edString == h3String)
                        MergeMultiplayerEvent(cacheStream, blamCacheStream, edEvent, h3Event);
                }
            }

            for (var i = 0; i < h3Def.Runtime[0].InfectionEvents.Count; i++)
            {
                var h3Event = h3Def.Runtime[0].InfectionEvents[i];

                if (h3Event.DisplayString == StringId.Invalid)
                    continue;

                var h3String = BlamCache.StringTable.GetString(h3Event.DisplayString);

                for (var j = 0; j < edDef.Runtime[0].InfectionEvents.Count; j++)
                {
                    var edEvent = edDef.Runtime[0].InfectionEvents[j];
                    var edString = CacheContext.StringTable.GetString(edEvent.DisplayString);

                    if (edString == h3String)
                        MergeMultiplayerEvent(cacheStream, blamCacheStream, edEvent, h3Event);
                }
            }

            CacheContext.Serialize(cacheStream, edTag, edDef);
        }

        private object ConvertGlobalMaterialTypeField(Stream cacheStream, Stream blamCacheStream, TagFieldInfo fieldinfo, object value)
        {
            // only enabled for reach, however it might be worth using for h3 and odst as a fallback
            if (BlamCache.Version < CacheVersion.HaloReach)
                return value;

            var globals = TagDefinitionCache.Deserialize<Globals>(CacheContext, cacheStream, CacheContext.TagCache.FindFirstInGroup<Globals>());
            var blamGlobals = TagDefinitionCache.Deserialize<Globals>(BlamCache, blamCacheStream, BlamCache.TagCache.FindFirstInGroup<Globals>());

            var materials = globals.Materials;
            var blamMaterials = BlamCache.Version >= CacheVersion.HaloReach ? blamGlobals.AlternateMaterials : blamGlobals.Materials;
            return ConvertInternal(value);

            object ConvertInternal(object val)
            {
                switch (val)
                {
                    case StringId stringId:
                        if (stringId != StringId.Invalid)
                            val = materials[FindMatchingMaterial(CacheContext.StringTable.GetString(stringId))].Name;
                        break;
                    case short index:
                        if (index != -1)
                        {
                            if (index < 0 || index >= blamMaterials.Count)
                            {
                                index = 0;
                                new TagToolWarning($"Global material type was out of range for '{fieldinfo.DeclaringType.FullName}.{fieldinfo.Name}', value: {index}");
                            }
                            else
                            {
                                val = FindMatchingMaterial(BlamCache.StringTable.GetString(blamMaterials[index].Name));
                            }
                        }
                        break;
                    case short[] indices:
                        for (int i = 0; i < indices.Length; i++)
                            indices[i] = (short)ConvertInternal(indices[i]);
                        break;
                    case StringId[] stringIds:
                        for (int i = 0; i < stringIds.Length; i++)
                            stringIds[i] = (StringId)ConvertInternal(stringIds[i]);
                        break;
                }
                return val;
            }

            short FindMatchingMaterial(string name)
            {
                var originalName = name;

                // we don't have wet materials
                if (name.StartsWith("wet_"))
                    name = name.Substring(4);

                // other reach fixups
                Dictionary<string, string> substitutions = new Dictionary<string, string>
                {
                    {"hard_metal_thin_hum_spartan", "hard_metal_thin_hum_masterchief"},
                    {"energy_shield_thin_hum_spartan", "energy_shield_thin_hum_masterchief"},
                    {"energy_shield_invulnerable", "energy_shield_invincible"},
                    {"energy_hologram", "energy_holo"},
                };
                if (substitutions.TryGetValue(name, out var sub))
                    name = sub;

                // search for the name in the destination materials
                var matchIndex = (short)materials.FindIndex(x => CacheContext.StringTable.GetString(x.Name) == name);
                if (matchIndex != -1)
                {
                    if (name != originalName)
                        Console.WriteLine($"Failed to find global material type '{originalName}', using '{name}'");

                    return matchIndex;
                }

                // we couldn't find it, find the index in the source materials
                var blamIndex = blamMaterials.FindIndex(x => BlamCache.StringTable.GetString(x.Name) == originalName);
                if (blamIndex == -1)
                {
                    if (!originalName.StartsWith("default"))
                        Console.WriteLine($"Failed to find global material type '{originalName}', using 'default_material'");
                    return 0;
                }

                // if it has a parent search for its name
                StringId parentName = blamMaterials[blamIndex].ParentName;
                if (parentName == StringId.Invalid)
                    return 0;

                // recurse
                matchIndex = FindMatchingMaterial(BlamCache.StringTable.GetString(parentName));

                // if we still can't find anything after walking up the hierarchy, use 'default_material'
                if (matchIndex == -1)
                    matchIndex = 0;

                name = CacheContext.StringTable.GetString(materials[matchIndex].Name);
                Console.WriteLine($"Failed to find global material type '{originalName}', using '{name}'");
                return matchIndex;
            }
        }
    }
}