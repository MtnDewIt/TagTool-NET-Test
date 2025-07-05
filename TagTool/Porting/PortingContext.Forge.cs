using System;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.Gen3;
using TagTool.Tags.Definitions;

namespace TagTool.Porting
{
    public partial class PortingContext
    {
        private void TestForgePaletteCompatible(Stream cacheStream, CachedTag blamTag, string[] argParameters)
        {
            argParameters ??= [];

            if (!blamTag.IsInGroup("obje") || !CacheContext.TagCache.TryGetCachedTag(blamTag.ToString(), out CachedTag edTag))
                return;

            var definition = CacheContext.Deserialize(cacheStream, edTag);
            if (definition is GameObject obj)
            {
                if (obj.MultiplayerObject.Count == 0)
                {
                    obj.MultiplayerObject.Add(new GameObject.MultiplayerObjectBlock()
                    {
                        DefaultSpawnTime = 30,
                        DefaultAbandonTime = 30
                    });
                    CacheContext.Serialize(cacheStream, edTag, definition);
                }

                if (argParameters.Count() > 0)
                {
                    if (!int.TryParse(argParameters[0], out int paletteIndex) && argParameters[0] == "*")
                        paletteIndex = -1;

                    var objTagName = $"{edTag.Name}.{(edTag.Group as TagGroupGen3).Name}";

                    var paletteItemName = edTag.Name.Split('.').First().Split('\\').Last();
                    if (argParameters.Count() > 1)
                        paletteItemName = argParameters[1].Replace('_', ' ');

                    DeferredActions.Add(() =>
                    {
                        AddForgePaletteItem(cacheStream, objTagName, paletteIndex, paletteItemName);
                    });
                }
            }
        }

        private void AddForgePaletteItem(Stream cacheStream, string gameObjectName, int paletteCategory, string paletteItemName)
        {
            if (CacheContext.TagCache.TryGetCachedTag(@"multiplayer\forge_globals.forge_globals_definition", out CachedTag forge_globals))
            {
                if (CacheContext.TagCache.TryGetCachedTag(gameObjectName, out CachedTag objectTag))
                {
                    var forg = CacheContext.Deserialize<ForgeGlobalsDefinition>(cacheStream, forge_globals);

                    if (paletteCategory == -1)
                        paletteCategory = (short)(forg.PaletteCategories.Count() - 1);

                    var itemType = ForgeGlobalsDefinition.PaletteItemType.Prop;
                    switch (objectTag.Group.ToString())
                    {
                        case "weapon":
                            itemType = ForgeGlobalsDefinition.PaletteItemType.Weapon;
                            break;
                        case "equipment":
                            itemType = ForgeGlobalsDefinition.PaletteItemType.Equipment;
                            break;
                        case "vehicle":
                            itemType = ForgeGlobalsDefinition.PaletteItemType.Vehicle;
                            break;
                        case "effect_scenery":
                        case "sound_scenery":
                            itemType = ForgeGlobalsDefinition.PaletteItemType.Effects;
                            break;
                    }

                    forg.Palette.Add(new ForgeGlobalsDefinition.PaletteItem()
                    {
                        Name = paletteItemName,
                        Type = itemType,
                        CategoryIndex = (short)paletteCategory,
                        DescriptionIndex = -1,
                        MaxAllowed = 0,
                        Object = objectTag
                    });

                    CacheContext.Serialize(cacheStream, forge_globals, forg);
                }
            }
        }
    }
}
