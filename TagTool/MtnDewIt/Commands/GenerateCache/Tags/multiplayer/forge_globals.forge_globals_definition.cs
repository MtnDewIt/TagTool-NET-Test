using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class multiplayer_forge_globals_forge_globals_definition : TagFile
    {
        public multiplayer_forge_globals_forge_globals_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            TagData();
        }

        public override void TagData()
        {
            var tag = GetCachedTag<ForgeGlobalsDefinition>($@"multiplayer\forge_globals");
            var forg = CacheContext.Deserialize<ForgeGlobalsDefinition>(Stream, tag);
            forg.ReForgeMaterialTypes = new List<ForgeGlobalsDefinition.ReForgeMaterialType>
            {
                new ForgeGlobalsDefinition.ReForgeMaterialType
                {
                    Name = "Snow",
                    CollisionMaterialIndex = 26,
                    PhysicsMaterialIndex = 26,
                },
                new ForgeGlobalsDefinition.ReForgeMaterialType
                {
                    Name = "Rubber",
                    CollisionMaterialIndex = 37,
                    PhysicsMaterialIndex = 37,
                },
                new ForgeGlobalsDefinition.ReForgeMaterialType
                {
                    Name = "Plastic",
                    CollisionMaterialIndex = 40,
                    PhysicsMaterialIndex = 40,
                },
                new ForgeGlobalsDefinition.ReForgeMaterialType
                {
                    Name = "Dirt",
                    CollisionMaterialIndex = 48,
                    PhysicsMaterialIndex = 48,
                },
                new ForgeGlobalsDefinition.ReForgeMaterialType
                {
                    Name = "Grass",
                    CollisionMaterialIndex = 49,
                    PhysicsMaterialIndex = 49,
                },
                new ForgeGlobalsDefinition.ReForgeMaterialType
                {
                    Name = "Mud",
                    CollisionMaterialIndex = 50,
                    PhysicsMaterialIndex = 50,
                },
                new ForgeGlobalsDefinition.ReForgeMaterialType
                {
                    Name = "Sand",
                    CollisionMaterialIndex = 52,
                    PhysicsMaterialIndex = 52,
                },
                new ForgeGlobalsDefinition.ReForgeMaterialType
                {
                    Name = "Metal, Human",
                    CollisionMaterialIndex = 55,
                    PhysicsMaterialIndex = 55,
                },
                new ForgeGlobalsDefinition.ReForgeMaterialType
                {
                    Name = "Metal, Covenant",
                    CollisionMaterialIndex = 60,
                    PhysicsMaterialIndex = 60,
                },
                new ForgeGlobalsDefinition.ReForgeMaterialType
                {
                    Name = "Ice",
                    CollisionMaterialIndex = 101,
                    PhysicsMaterialIndex = 101,
                },
                new ForgeGlobalsDefinition.ReForgeMaterialType
                {
                    Name = "Stone",
                    CollisionMaterialIndex = 102,
                    PhysicsMaterialIndex = 102,
                },
                new ForgeGlobalsDefinition.ReForgeMaterialType
                {
                    Name = "Underbush",
                    CollisionMaterialIndex = 170,
                    PhysicsMaterialIndex = 170,
                },
                new ForgeGlobalsDefinition.ReForgeMaterialType
                {
                    Name = "Energy Shield",
                    CollisionMaterialIndex = 178,
                    PhysicsMaterialIndex = 178,
                },
                new ForgeGlobalsDefinition.ReForgeMaterialType
                {
                    Name = "Fence",
                    CollisionMaterialIndex = 186,
                    PhysicsMaterialIndex = 186,
                },
                new ForgeGlobalsDefinition.ReForgeMaterialType
                {
                    Name = "Water",
                    CollisionMaterialIndex = 4,
                    PhysicsMaterialIndex = 207,
                },
            };
            forg.ReForgeObjects = null;
            forg.PrematchCameraObject = null; //GetCachedTag<Scenery>($@"objects\multi\generic\mp_cinematic_camera"); // can't make :/
            forg.ModifierObject = null; //GetCachedTag<Scenery>($@"objects\eldewrito\forge\map_modifier"); // can make
            forg.KillVolumeObject = null; //GetCachedTag<Crate>($@"objects\multi\boundaries\kill_volume"); // can make
            forg.GarbageVolumeObject = null; //GetCachedTag<Crate>($@"objects\multi\boundaries\garbage_collection_volume"); // can make
            forg.Descriptions = new List<ForgeGlobalsDefinition.Description>
            {
                new ForgeGlobalsDefinition.Description
                {
                    Text = "Primitive building blocks",
                },
                new ForgeGlobalsDefinition.Description
                {
                    Text = "Width",
                },
                new ForgeGlobalsDefinition.Description
                {
                    Text = "Depth",
                },
                new ForgeGlobalsDefinition.Description
                {
                    Text = "Depth",
                },
                new ForgeGlobalsDefinition.Description
                {
                    Text = "Depth",
                },
                new ForgeGlobalsDefinition.Description
                {
                    Text = "Depth",
                },
            };
            forg.PaletteCategories = new List<ForgeGlobalsDefinition.PaletteCategory>
            {
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "PROPS",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = -1,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "BARRELS",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 0,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "NATURAL",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 0,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "COVER",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 0,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "CRATES",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 0,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "EXPLOSIVES",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 0,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "FX",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 0,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "LIGHTS",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 0,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "TECH",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 0,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "GADGETS",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 0,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "OFFICE",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 0,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "MISCELLANEOUS",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 0,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "STRUCTURE",
                    DescriptionIndex = 0,
                    ParentCategoryIndex = -1,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "BLOCKS",
                    DescriptionIndex = 1,
                    ParentCategoryIndex = 12,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "0.1'",
                    DescriptionIndex = 2,
                    ParentCategoryIndex = 13,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "0.5'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 14,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "1'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 14,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "2'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 14,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "3'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 14,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "4'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 14,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "5'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 14,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "10'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 14,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "20'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 14,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "0.5'",
                    DescriptionIndex = 3,
                    ParentCategoryIndex = 13,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "0.5'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 23,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "1'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 23,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "2'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 23,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "3'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 23,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "4'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 23,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "5'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 23,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "10'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 23,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "20'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 23,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "1'",
                    DescriptionIndex = 4,
                    ParentCategoryIndex = 13,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "1'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 32,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "2'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 32,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "3'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 32,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "4'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 32,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "5'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 32,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "10'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 32,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "20'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 32,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "TRIANGLES",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 12,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "RIGHT ANGLE",
                    DescriptionIndex = 5,
                    ParentCategoryIndex = 40,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "0.1'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 41,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "0.5'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 41,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "1'",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 41,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "EQUILATERAL",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 40,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "CYLINDERS",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 12,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "CYLINDERS (FULL)",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 46,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "CYLINDERS (HALF)",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 46,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "HEMISPHERES",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 12,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "HEMISPHERES (ROUND)",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 49,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "HEMISPHERES (LONG)",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 49,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "GAMEPLAY",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = -1,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "GAMETYPE",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 52,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "GENERAL",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 53,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "ASSAULT",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 53,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "CTF",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 53,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "INFECTION",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 53,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "JUGGERNAUT",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 53,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "KING OF THE HILL",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 53,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "ODDBALL",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 53,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "TERRITORIES",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 53
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "SLAYER",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 53,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "VIP",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 53,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "MAP TOOLS",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 52,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "EQUIPMENT",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 52,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "CLASSIC",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 65,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "ARMOR ABILITIES",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 65,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "GRENADES",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 65,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "POWERUPS",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 65,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "WEAPONS",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 52,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "ASSAULT RIFLES",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 70,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "BATTLE RIFLES",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 70,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "SMGS",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 70,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "DMRS",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 70,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "CARBINES",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 70,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "PISTOLS",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 70,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "TURRETS",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 70,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "POWER WEAPONS",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 70,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "VEHICLES",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 52,
                },
                new ForgeGlobalsDefinition.PaletteCategory
                {
                    Name = "TELEPORTERS",
                    DescriptionIndex = -1,
                    ParentCategoryIndex = 52,
                },
            };
            forg.Palette = new List<ForgeGlobalsDefinition.PaletteItem>
            {
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIP MINE (ARMED)",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 5,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\tripmine\tripmine_forge"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "GRAV LIFT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 9,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\gravlift_permanent\gravlift_permanent"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0,
                        },
                    },
                },
                //new ForgeGlobalsDefinition.PaletteItem
                //{
                //    Name = "MAP MODIFIER",
                //    Type = ForgeGlobalsDefinition.PaletteItemType.Tool,
                //    CategoryIndex = 64,
                //    DescriptionIndex = -1,
                //    MaxAllowed = 1,
                //    Object = GetCachedTag<Scenery>($@"objects\eldewrito\forge\map_modifier"),
                //    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                //    {
                //        new ForgeGlobalsDefinition.PaletteItem.Setter
                //        {
                //            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                //            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                //            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.Hidden,
                //            IntegerValue = 1,
                //            RealValue = 0,
                //        },
                //    },
                //},
                //new ForgeGlobalsDefinition.PaletteItem
                //{
                //    Name = "KILL VOLUME",
                //    Type = ForgeGlobalsDefinition.PaletteItemType.Tool,
                //    CategoryIndex = 64,
                //    DescriptionIndex = -1,
                //    MaxAllowed = 0,
                //    Object = GetCachedTag<Crate>($@"objects\multi\boundaries\kill_volume"),
                //},
                //new ForgeGlobalsDefinition.PaletteItem
                //{
                //    Name = "GARBAGE COLLECTION VOLUME",
                //    Type = ForgeGlobalsDefinition.PaletteItemType.Tool,
                //    CategoryIndex = 64,
                //    DescriptionIndex = -1,
                //    MaxAllowed = 0,
                //    Object = GetCachedTag<Crate>($@"objects\multi\boundaries\garbage_collection_volume"),
                //},
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BUBBLE SHIELD",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 66,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\bubbleshield_equipment\bubbleshield_equipment"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "DEPLOYABLE COVER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 66,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\instantcover_equipment\instantcover_equipment_mp"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "FLARE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 66,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\superflare_equipment\superflare_equipment"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "GRAV LIFT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 66,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\gravlift_equipment\gravlift_equipment"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "INVINCIBILITY",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 66,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\invincibility_equipment\invincibility_equipment"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "POWER DRAIN",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 66,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\powerdrain_equipment\powerdrain_equipment"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "RADAR JAMMER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 66,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\jammer_equipment\jammer_equipment"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "REGENERATOR",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 66,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\regenerator_equipment\regenerator_equipment"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIP MINE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 66,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\tripmine_equipment\tripmine_equipment"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "FRAG GRENADE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 68,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\weapons\grenade\frag_grenade\frag_grenade"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PLASMA GRENADE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 68,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\weapons\grenade\plasma_grenade\plasma_grenade"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "FIREBOMB GRENADE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 68,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\weapons\grenade\firebomb_grenade\firebomb_grenade"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SPIKE GRENADE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 68,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\weapons\grenade\claymore_grenade\claymore_grenade"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "ACTIVE CAMO",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 69,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\multi\powerups\powerup_blue\powerup_blue"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "OVERSHIELDS",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 69,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\multi\powerups\powerup_red\powerup_red"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CUSTOM POWERUP",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 69,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\multi\powerups\powerup_yellow\powerup_yellow"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "ASSAULT RIFLE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 71,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BATTLE RIFLE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 72,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SMG",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 73,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\smg\smg"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "COVENANT CARBINE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 75,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MAULER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 76,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MAGNUM",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 76,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PLASMA PISTOL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 76,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MACHINE GUN TURRET",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 77,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\weapons\turret\machinegun_turret\machinegun_turret"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MACHINE GUN TURRET, DETACHED",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 77,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\turret\machinegun_turret\machinegun_turret"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PLASMA CANNON",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 77,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\weapons\turret\plasma_cannon\plasma_cannon"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PLASMA CANNON, DETACHED",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 77,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\turret\plasma_cannon\plasma_cannon"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MISSILE POD",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 77,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\weapons\turret\missile_pod\missile_pod"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MISSILE POD, DETACHED",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 77,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\turret\missile_pod\missile_pod"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BEAM RIFLE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 78,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BRUTE SHOT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 78,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "ENERGY SWORD",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 78,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\melee\energy_blade\energy_blade"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "FLAMETHROWER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 78,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\turret\flamethrower\flamethrower"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "FUEL ROD GUN",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 78,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "GRAVITY HAMMER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 78,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\melee\gravity_hammer\gravity_hammer"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "NEEDLER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 78,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PLASMA RIFLE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 78,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "ROCKET LAUNCHER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 78,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\support_high\rocket_launcher\rocket_launcher"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SENTINEL BEAM",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 78,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\support_low\sentinel_gun\sentinel_gun"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SHOTGUN",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 78,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\shotgun\shotgun"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SNIPER RIFLE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 78,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\sniper_rifle\sniper_rifle"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SPARTAN LASER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 78,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\support_high\spartan_laser\spartan_laser"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SPIKER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 78,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BANSHEE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\banshee\banshee"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CHOPPER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\brute_chopper\brute_chopper"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "ELEPHANT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\levels\multi\shrine\behemoth\behemoth_forge"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "GHOST",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\ghost\ghost"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HORNET",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\hornet\hornet"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HORNET, LITE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\levels\dlc\sidewinder\hornet_lite\hornet_lite"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MONGOOSE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\mongoose\mongoose"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PROWLER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\mauler\mauler"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SCORPION",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\scorpion\scorpion"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SHADE TURRET",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\shade\shade"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "WARTHOG",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "WARTHOG, GAUSS",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_gauss"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "WARTHOG, TROOP",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_troop"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "WARTHOG, CIVILIAN",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_no_turret"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "WARTHOG, DISABLED",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_wrecked"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "WARTHOG, SNOW",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "WARTHOG, SNOW, GAUSS",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow_gauss"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "WARTHOG, SNOW, TROOP",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow_troop"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "WARTHOG, SNOW, CIVILIAN",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow_no_turret"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "WARTHOG, SNOW, DISABLED",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow_wrecked"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "WRAITH",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\wraith\wraith"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "WRAITH, ANTI-AIR",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Vehicle,
                    CategoryIndex = 79,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\wraith\wraith_anti_air"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "null",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = -1,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\levels\multi\shrine\behemoth\behemoth"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "INVISIBILITY",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 67,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\invisibility_equipment\invisibility_equipment"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "AUTOTURRET",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 67,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\autoturret_equipment\autoturret_equipment"),
                },
            };
            forg.WeatherEffects = null; // Might port later
            forg.Skies = null;
            forg.FxObject = null; //GetCachedTag<Crate>($@"objects\eldewrito\forge\fx_object"); // can't make :/
            forg.FxLight = null; //GetCachedTag<Crate>($@"objects\eldewrito\forge\light_object"); // can't make :/
        }
    }
}
