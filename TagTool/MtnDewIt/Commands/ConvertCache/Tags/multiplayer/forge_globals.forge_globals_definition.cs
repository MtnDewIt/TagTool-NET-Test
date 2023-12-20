using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;
using System;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
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
            forg.ReForgeObjects = new List<TagReferenceBlock> 
            {
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_2x2x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_2x2x01"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_1x2x01"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_1x2x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_1x2x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_5x5x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_5x5x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_5x5x025"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_2x5x025"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_2x5x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_2x5x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_10x10x5"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_10x10x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_10x10x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_5x10x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_5x10x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_5x10x5"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_20x20x10"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_20x20x5"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_20x20x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_10x20x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_10x20x5"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_10x20x10"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_2x2x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\glass_01x1x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\glass_01x10x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\glass_01x10x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\glass_01x2x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\glass_01x10x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_2x2x01"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_05x05x01"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_1x1x01"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_1x1x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_2x2x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_5x5x01"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_2x2x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_1x1x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_05x05x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_2x2x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_1x1x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_05x05x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_2x2x4"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_1x1x4"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_05x05x4"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_10x10x4"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_10x10x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_10x10x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_10x10x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_10x10x01"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_5x5x4"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_5x5x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_5x5x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_5x5x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_05x05x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_2x01x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_1x01x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_3x01x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x10x066"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x4x046"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x3x06"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x2x073"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x1x087"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x5x033"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x05x043"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\glass_01x05x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_1x3x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_1x4x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_1x10x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_2x10x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_3x10x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_3x1x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_3x3x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_3x4x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_2x1x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_2x3x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_2x4x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_1x1x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x05x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x2x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x3x3"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x4x4"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x5x5"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x1x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x1x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x5x5"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x4x4"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x3x3"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x2x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x10x10"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x10x10"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x05x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x3x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x3x3"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x4x3"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x4x4"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x5x5"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x5x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x5x3"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x5x4"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x2x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x5x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x3x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x4x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x1x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x10x10"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x10x5"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x10x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x10x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x10x3"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x10x4"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x4x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x20x20"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x20x20"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x4x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x05x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x1x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x10x4"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x10x3"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x10x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x10x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x10x5"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x10x10"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x1x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x4x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x3x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x5x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x2x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x5x4"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x5x3"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x5x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x5x5"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x4x4"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x4x3"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x3x3"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x3x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x2x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x2x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x4x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x4"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x3"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x5"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x10"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x1x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x4x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x3x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x5x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x2x1"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x5x4"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x5x3"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x5x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x5x5"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x4x4"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x4x3"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x3x3"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x3x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x2x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x2x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x1x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x4x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x3x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x5x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x05x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x20x20"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x10x10"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x5x5"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x4x4"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x3x3"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x2x2"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x05x05"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x1x1"),
                },
            };
            forg.PrematchCameraObject = GetCachedTag<Scenery>($@"objects\multi\generic\mp_cinematic_camera");
            forg.ModifierObject = GetCachedTag<Scenery>($@"objects\eldewrito\forge\map_modifier");
            forg.KillVolumeObject = GetCachedTag<Crate>($@"objects\multi\boundaries\kill_volume");
            forg.GarbageVolumeObject = GetCachedTag<Crate>($@"objects\multi\boundaries\garbage_collection_volume");
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
                    Name = "BARREL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 1,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\h_barrel_rusty\h_barrel_rusty"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BARREL, SMALL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 1,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\h_barrel_rusty_small\h_barrel_rusty_small"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "DRUM, 12 GAL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 1,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\drum_12gal\drum_12gal"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "DRUM, 55 GAL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 1,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\bunkerworld\drum_55gal_bunker\drum_55gal_bunker"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BUSH, A",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 2,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\030_outskirts\foliage\bushlow\bushlow"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BUSH, B",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 2,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\030_outskirts\foliage\bushc\bushc"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BUSH, SMALL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 2,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\030_outskirts\foliage\small_bush\small_bush"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "ICICLE, 10 INCH",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 2,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\icicle_10_inch\icicle_10_inch"),
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
                    Name = "ICICLE, 18 INCH",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 2,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\icicle_18_inch\icicle_18_inch"),
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
                    Name = "ICICLE, 24 INCH",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 2,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\icicle_24_inch\icicle_24_inch"),
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
                    Name = "ICICLE, 6 INCH",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 2,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\icicle_06_inch\icicle_06_inch"),
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
                    Name = "PALM BUSH, LARGE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 2,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\zanzibar\foliage\plant_bush_large_palm\plant_bush_large_palm"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PALM BUSH, MEDIUM",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 2,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\010_jungle\foliage\plant_bush_med_palm\plant_bush_med_palm"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PALM TREE, SMALL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 2,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\010_jungle\foliage\plant_tree_palm\plant_tree_palm"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.Hidden,
                            IntegerValue = 0,
                            RealValue = 0,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PINE TREE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 2,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\100_citadel\foliage\plant_tree_pine\plant_tree_pine"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.Hidden,
                            IntegerValue = 0,
                            RealValue = 0,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PINE TREE, LARGE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 2,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\100_citadel\foliage\plant_pine_tree_large\plant_pine_tree_large"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.Hidden,
                            IntegerValue = 0,
                            RealValue = 0,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "AWNING",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 3,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\zanzibar\awning_def\awning_def"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BARRICADE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 3,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\barricade_large\barricade_large"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BARRICADE, SMALL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 3,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\barricade_small\barricade_small"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BARRIER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 3,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\jersey_barrier\jersey_barrier"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BARRIER, SHORT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 3,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\jersey_barrier_short\jersey_barrier_short"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BATTLE SHIELD",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 3,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\zanzibar\battle_shield\battle_shield"),
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
                    Name = "DUMPSTER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 3,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_turf\turf_dumpster\turf_dumpster"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "ROADBLOCK",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 3,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\sawhorse\sawhorse"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "ROADBLOCK, LIGHT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 3,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\sawhorse\sawhorse_light"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SANDBAGS",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 3,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\sandbag_wall\sandbag_wall"),
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
                    Name = "SANDBAGS, 45? CORNER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 3,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\bunkerworld\sandbag_wall_45corner_bunker\sandbag_wall_45corner_bunker"),
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
                    Name = "SANDBAGS, 90? CORNER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 3,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\sandbag_wall_90corner\sandbag_wall_90corner"),
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
                    Name = "SANDBAGS, ENDCAP",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 3,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\sandbag_wall_endcap\sandbag_wall_endcap"),
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
                    Name = "SANDBAGS, TURRET",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 3,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\sandbag_wall_turret\sandbag_wall_turret"),
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
                    Name = "SANDBAG, SINGLE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 3,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\sandbag_detail2\sandbag_detail2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SANDBAG, TWO",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 3,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\sandbag_detail1\sandbag_detail1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "AMMO CASE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\box_metal_small\box_metal_small"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "AMMO CRATE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\h_ammo_crate_lg\h_ammo_crate_lg"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "AMMO CRATE, SMALL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\h_ammo_crate_sm\h_ammo_crate_sm"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CABINET",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_turf\turf_cabinet\turf_cabinet"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CONTAINER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\crate_tech_semi_short_closed\crate_tech_semi_short_closed"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CONTAINER, OPEN",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\crate_tech_semi_short\crate_tech_semi_short"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CRATE, INDUSTRIAL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\crate_tech_giant\crate_tech_giant"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CRATE, MULTI",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"ms30\objects\gear\human\industrial\crate_multi_single\crate_multi_single"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CRATE, MULTI, DESTRUCTIBLE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\crate_multi\crate_multi"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CRATE, SINGLE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\crate_packing\crate_packing"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CRATE, SINGLE, LARGE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\crate_packing_giant\crate_packing_giant_mp"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "DOUBLE BOX, OPEN",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\dlc_wh_crate_large_open\dlc_wh_crate_large_open"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "EQUIPMENT CASE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\case_ap_turret\case_ap_turret"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "EQUIPMENT CASE, LID",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\case_ap_turret_lid\case_ap_turret_lid"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "EQUIPMENT CASE, OPEN",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\case_ap_turret_open\case_ap_turret_open"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "EQUIPMENT CASE, SMALL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\case\case"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "FENCE BOX",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\fencebox\fencebox"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MEDICAL CRATE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\medical\medical_crate\medical_crate"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "METAL CRATE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_turf\turf_crate_large\turf_crate_large"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "METAL CRATE, SMALL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_turf\crate_heavy_tech\crate_heavy_tech"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SUPPLY CASE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 4,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\covenant\military\crate_space\crate_space"),
                },
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
                    Name = "PLASMA BATTERY",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 5,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\covenant\military\battery\battery"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "FUSION COIL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 5,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\fusion_coil\fusion_coil"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "POWER CORE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 5,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\forerunner\power_core_for\power_core_for"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PROPANE BURNER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 5,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\propane_burner\propane_burner"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PROPANE TANK",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 5,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\propane_tank\propane_tank"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "JUICY",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = 6,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\forge\fx_object"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Saturation,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 1f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Desaturation,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Hue,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_ColorFilterR,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 1f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_ColorFilterG,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.92f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_ColorFilterB,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.83f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_LightIntensity,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_GammaDecrease,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_GammaIncrease,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Range,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 10f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0f,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "NOVA",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = 6,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\forge\fx_object"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Saturation,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.3f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Hue,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_ColorFilterR,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.03f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_ColorFilterG,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.03f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_ColorFilterB,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.03f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Desaturation,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_LightIntensity,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 1f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_GammaDecrease,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_GammaIncrease,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Range,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 10f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0f,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SEPIATONE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = 6,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\forge\fx_object"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Saturation,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.3f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Desaturation,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 1f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Hue,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.027f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_ColorFilterR,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.55f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_ColorFilterG,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.27f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_ColorFilterB,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.15f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_LightIntensity,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_GammaDecrease,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.25f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_GammaIncrease,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Range,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 10f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0f,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "FILM",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = 6,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\forge\fx_object"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Saturation,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Desaturation,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 1f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Hue,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_ColorFilterR,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.784f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_ColorFilterG,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.784f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_ColorFilterB,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.784f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_LightIntensity,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_GammaDecrease,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_GammaIncrease,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Range,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 10f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0f,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "GLOOMY",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = 6,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\forge\fx_object"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Saturation,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Desaturation,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.4f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Hue,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_ColorFilterR,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.784f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_ColorFilterG,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.784f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_ColorFilterB,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.784f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_LightIntensity,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.6f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_GammaDecrease,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 1f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_GammaIncrease,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.07f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Fx_Range,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 10f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0f,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "YELLOW",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Light,
                    CategoryIndex = 7,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\forge\light_object"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorR,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorG,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorB,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_Intensity,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_Radius,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0f,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "ORANGE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Light,
                    CategoryIndex = 7,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\forge\light_object"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorR,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorG,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.25f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorB,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_Intensity,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_Radius,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0f,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PINK",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Light,
                    CategoryIndex = 7,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\forge\light_object"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorR,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorG,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorB,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.25f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_Intensity,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_Radius,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0f,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "RED",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Light,
                    CategoryIndex = 7,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\forge\light_object"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorR,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorG,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorB,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_Intensity,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_Radius,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0f,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PURPLE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Light,
                    CategoryIndex = 7,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\forge\light_object"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorR,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorG,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorB,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_Intensity,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 50f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_Radius,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0f,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLUE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Light,
                    CategoryIndex = 7,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\forge\light_object"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorR,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorG,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorB,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_Intensity,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_Radius,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0f,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "GREEN",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Light,
                    CategoryIndex = 7,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\forge\light_object"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorR,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorG,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_ColorB,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_Intensity,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 0.5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.Light_Radius,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Real,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 0,
                            RealValue = 5f,
                        },
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.None,
                            IntegerValue = 1,
                            RealValue = 0f,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "COMPUTER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 8,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\020_base\computer_briefcase\computer_briefcase"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "COMPUTER, SMALL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 8,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\020_base\computer_briefcase_small\computer_briefcase_small"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "FLOODLIGHTS",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 8,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\generator_light\generator_flood_no_lights"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "FORKLIFT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 8,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\vehicles\civilian\forklift\forklift"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "GENERATOR",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 8,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\generator_heavy_grill\generator_heavy_grill"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "GENERATOR, INDUSTRIAL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 8,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\generator_heavy_kettle\generator_heavy_kettle"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "GENERATOR, SMALL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 8,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\generator\generator"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "INDUSTRIAL CART",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 8,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\040_voi\cart_electric\cart_electric"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MONITOR, MEDIUM",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 8,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\cyberdyne\cyber_monitor_med\cyber_monitor"),
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
                    Name = "MONITOR, SMALL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 8,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\levels\solo\020_base\monitor_sm\monitor_sm"),
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
                    Name = "RADIO SET",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 8,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\hu_mil_radio_big\hu_mil_radio_big"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "RADIO SET, SMALL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 8,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\hu_mil_radio_small\hu_mil_radio_small"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SOCCER BALL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 9,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\levels\dlc\shared\soccer_ball\soccer_ball"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "WEAPON HOLDER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 9,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\covenant\military\cov_sword_holder\cov_sword_holder"),
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
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "LIFT, GOLD",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 9,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\guardian\holy_light_guardian\holy_light_guardian_forge"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MAN CANNON",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 9,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\man_cannon_forge\man_cannon_forge"),
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
                    Name = "SHIELD DOOR",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 9,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\small_shield_door\small_shield_door"),
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
                    Name = "SHIELD DOOR 2",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 9,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\snowbound\airlock_field\airlock_field"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SHIELD DOOR, LARGE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 9,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\large_shield_door\large_shield_door"),
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
                    Name = "SHIELD DOOR, GOLD",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 9,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\salvation\large_field\large_field"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CHAIR",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 10,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\residential\office_chair\office_chair"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "COMPUTER MONITOR",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 10,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\residential\office_monitor\office_monitor"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "FILING CABINET",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 10,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\residential\office_file_tall\office_file_tall"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "FILING CABINET, SMALL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 10,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\residential\office_file_short\office_file_short"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "KEYBOARD",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 10,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\residential\office_keyboard\office_keyboard"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "KITCHEN SINK",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 10,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\levels\solo\020_base\sink\sink"),
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
                    Name = "STAND",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 10,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\residential\office_stand\office_stand"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TABLE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 10,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\residential\office_table\office_table"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TELEPHONE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 10,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\comm_phonebox\comm_phonebox"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TELEPHONE, WALL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 10,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\residential\telephone_wall_box\telephone_wall_box"),
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
                    Name = "BACKPACK",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\hu_mil_rucksack\rucksack"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BEACON",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\shrine\marinebeacon\marinebeacon"),
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
                    Name = "BLITZ CAN",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\blitzcan\blitzcan"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BRIDGE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\bridge\bridge"),
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
                    Name = "CAMPING STOOL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\camping_stool_mp\camping_stool_mp"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CHAIN LINK GATE, LEFT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\deadlock\deadlock_chainlinkgate\deadlock_chainlinkgate"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CROWBAR",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\crowbar\crowbar"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "DROP BRIDGE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\zanzibar\main_crane\main_crane"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.Hidden,
                            IntegerValue = 0,
                            RealValue = 0,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "DROP POD, CLOSED",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\resupply_capsule_unfired\resupply_capsule_unfired"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "DROP POD, DEPLOYED",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\resupply_capsule_fired\resupply_capsule_fired"),
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
                    Name = "DROP POD, PANEL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\resupply_capsule_panel\resupply_capsule_panel"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "FLOOR HATCH",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\deadlock\wall_hatch\wall_hatch"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "GARBAGE CAN",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\garbage_can\garbage_can"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "LOCKER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\residential\h_locker_closed_mp\h_locker_closed_mp"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "LOUDSPEAKER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\cyberdyne\cyber_speaker\cyber_speaker"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MEDICAL CABINET",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\medical\cabinet\cabinet"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MEDICAL CART",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\medical\crashcart\crashcart"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MEDICAL TRAY",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\medical\medical_tray\medical_tray"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MISSILE, BODY",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\missle_body\missle_body"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MISSILE, STACK",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\missle_stand\missle_stand"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MISSILE, WARHEAD",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\missle_cap\missle_cap"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MONGOOSE PLATFORM",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\scenery\human\military\mongoose_drop_palette\mongoose_drop_palette"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PALLET",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\pallet\pallet"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PALLET, LARGE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\pallet_large\pallet_large"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PHANTOM DESTROYED, BACK, LARGE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\phantom\phantom_damaged\garbage\phd_backpiece_lg_top\phd_backpiece_lg_top"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PHANTOM DESTROYED, BACK, MEDIUM",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\phantom\phantom_damaged\garbage\phd_backpiece_md\phd_backpiece_md"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PHANTOM DESTROYED, BACK, SMALL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\phantom\phantom_damaged\garbage\phd_backpiece_sm\phd_backpiece_sm"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PHANTOM DESTROYED, BOTTOM",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\phantom\phantom_damaged\garbage\phd_bottompiece\phd_bottompiece"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PHANTOM DESTROYED, FLAT, RIGHT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\phantom\phantom_damaged\garbage\phd_flatpiece_r\phd_flatpiece_r"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PHANTOM DESTROYED, SIDE, LEFT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\phantom\phantom_damaged\garbage\phd_sidepiece_l\phd_sidepiece_l"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PHANTOM DESTROYED, SIDE, RIGHT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\phantom\phantom_damaged\garbage\phd_sidepiece_r\phd_sidepiece_r"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "RADIO ANTENNAE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\antennae_mast\antennae_mast"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "STREET CONE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\street_cone\street_cone"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SWINGING DOOR",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_turf\turf_swinging_door\turf_swinging_door"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SWINGING LAMP",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\zanzibar\hinge_light\hinge_light"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TOOLBOX",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\toolbox_large\toolbox_large"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TOOLBOX, SMALL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\toolbox_small\toolbox_small"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRASH CAN",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_turf\turf_trash_can\turf_trash_can"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "WARTHOG PLATFORM",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\scenery\human\military\warthog_drop_palette\warthog_drop_palette"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "WARTHOG TIRE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\vehicles\warthog\garbage\tire\tire"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "WEAPON SHELF",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\levels\solo\020_base\armory_shelf\armory_shelf"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "WIRE SPOOL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\dlc_wh_wire_spool_large\dlc_wh_wire_spool_large"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 0.5 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 15,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x05x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 1 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 16,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x1x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 1 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 16,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x1x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 2 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 17,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x2x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 2 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 17,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x2x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 2 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 17,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x2x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 3 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 18,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x3x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 3 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 18,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x3x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 3 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 18,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x3x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 3 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 18,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x3x3"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 4 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 19,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x4x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 4 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 19,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x4x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 4 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 19,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x4x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 4 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 19,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x4x3"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 4 x 4]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 19,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x4x4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 5 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 20,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x5x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 5 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 20,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x5x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 5 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 20,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x5x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 5 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 20,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x5x3"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 5 x 4]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 20,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x5x4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 5 x 5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 20,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x5x5"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 10 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 21,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 10 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 21,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 10 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 21,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 10 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 21,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x3"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 10 x 4]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 21,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 10 x 5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 21,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x5"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 10 x 10]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 21,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x10"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.1 x 20 x 20]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 22,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x20x20"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 0.5 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 24,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x05x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 1 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 25,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x1x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 1 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 25,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x1x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 2 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 26,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x2x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 2 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 26,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x2x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 3 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 27,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x3x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 3 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 27,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x3x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 3 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 27,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x3x3"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 4 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 28,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x4x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 4 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 28,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x4x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 4 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 28,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x4x3"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 4 x 4]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 28,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x4x4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 5 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 29,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x5x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 5 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 29,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x5x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 5 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 29,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x5x3"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 5 x 4]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 29,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x5x4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 5 x 5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 29,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x5x5"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 10 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 30,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x10x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 10 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 30,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x10x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 10 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 30,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x10x3"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 10 x 4]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 30,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x10x4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 10 x 5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 30,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x10x5"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 10 x 10]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 30,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x10x10"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [0.5 x 20 x 20]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 31,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x20x20"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 1 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 33,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x1x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 2 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 34,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x2x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 2 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 34,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x2x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 3 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 35,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x3x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 3 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 35,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x3x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 3 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 35,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x3x3"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 4 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 36,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x4x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 4 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 36,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x4x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 4 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 36,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x4x3"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 4 x 4]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 36,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x4x4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 5 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 37,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x5x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 5 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 37,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x5x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 5 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 37,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x5x3"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 5 x 4]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 37,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x5x4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 5 x 5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 37,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x5x5"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 10 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 38,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x10x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 10 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 38,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x10x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 10 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 38,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x10x3"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 10 x 4]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 38,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x10x4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 10 x 5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 38,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x10x5"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 10 x 10]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 38,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x10x10"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BLOCK [1 x 20 x 20]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 39,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x20x20"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [0.1 x 0.5 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 42,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x05x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [0.1 x 1 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 42,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x1x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [0.1 x 2 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 42,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x2x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [0.1 x 3 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 42,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x3x3"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [0.1 x 4 x 4]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 42,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x4x4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [0.1 x 5 x 5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 42,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x5x5"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [0.1 x 10 x 10]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 42,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x10x10"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [0.5 x 0.5 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 43,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x05x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [0.5 x 1 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 43,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x1x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [0.5 x 2 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 43,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x2x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [0.5 x 3 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 43,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x3x3"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [0.5 x 4 x 4]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 43,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x4x4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [0.5 x 5 x 5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 43,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x5x5"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [0.5 x 10 x 10]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 43,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x10x10"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [1 x 0.5 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 44,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x05x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [1 x 1 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 44,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x1x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [1 x 2 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 44,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x2x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [1 x 3 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 44,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x3x3"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [1 x 4 x 4]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 44,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x4x4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [1 x 5 x 5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 44,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x5x5"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE [1 x 10 x 10]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 44,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x10x10"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE (EQUAL) [0.1 x 0.5 x 0]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 45,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x05x043"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE (EQUAL) [0.1 x 1 x 0.8]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 45,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x1x087"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE (EQUAL) [0.1 x 2 x 1.7]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 45,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x2x073"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE (EQUAL) [0.1 x 3 x 2.6]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 45,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x3x06"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE (EQUAL) [0.1 x 4 x 3.4]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 45,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x4x046"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TRIANGLE (EQUAL) [0.1 x 5 x 4.3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 45,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x5x033"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [0.5 x 0.5 x 0.1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_05x05x01"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [0.5 x 0.5 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_05x05x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [0.5 x 0.5 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_05x05x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [0.5 x 0.5 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_05x05x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [0.5 x 0.5 x 4]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_05x05x4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [1 x 1 x 0.1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_1x1x01"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [1 x 1 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_1x1x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [1 x 1 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_1x1x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [1 x 1 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_1x1x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [1 x 1 x 4]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_1x1x4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [2 x 2 x 0.1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_2x2x01"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [2 x 2 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_2x2x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [2 x 2 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_2x2x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [2 x 2 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_2x2x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [2 x 2 x 4]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_2x2x4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [5 x 5 x 0.1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_5x5x01"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [5 x 5 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_5x5x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [5 x 5 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_5x5x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [5 x 5 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_5x5x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [5 x 5 x 4]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_5x5x4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [10 x 10 x 0.1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_10x10x01"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [10 x 10 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_10x10x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [10 x 10 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_10x10x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [10 x 10 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_10x10x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER [10 x 10 x 4]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 47,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_10x10x4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER (HALF) [0.5 x 0.1 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 48,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_1x01x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER (HALF) [0.5 x 0.1 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 48,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_2x01x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER (HALF) [0.5 x 0.1 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 48,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_3x01x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER (HALF) [0.5 x 1 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 48,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_1x1x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER (HALF) [0.5 x 1 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 48,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_2x1x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER (HALF) [0.5 x 1 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 48,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_3x1x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER (HALF) [0.5 x 3 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 48,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_1x3x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER (HALF) [0.5 x 3 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 48,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_2x3x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER (HALF) [0.5 x 3 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 48,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_3x3x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER (HALF) [0.5 x 4 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 48,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_1x4x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER (HALF) [0.5 x 4 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 48,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_2x4x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER (HALF) [0.5 x 4 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 48,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_3x4x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER (HALF) [0.5 x 10 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 48,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_1x10x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER (HALF) [0.5 x 10 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 48,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_2x10x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CYLINDER (HALF) [0.5 x 10 x 3]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 48,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_3x10x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [2 x 2 x 0.1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 50,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_2x2x01"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [2 x 2 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 50,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_2x2x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [2 x 2 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 50,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_2x2x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [5 x 5 x 0.25]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 50,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_5x5x025"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [5 x 5 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 50,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_5x5x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [5 x 5 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 50,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_5x5x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [10 x 10 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 50,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_10x10x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [10 x 10 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 50,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_10x10x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [10 x 10 x 5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 50,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_10x10x5"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [20 x 20 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 50,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_20x20x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [20 x 20 x 5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 50,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_20x20x5"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [20 x 20 x 10]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 50,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_20x20x10"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [1 x 2 x 0.1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 51,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_1x2x01"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [1 x 2 x 0.5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 51,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_1x2x05"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [1 x 2 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 51,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_1x2x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [2 x 5 x 0.25]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 51,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_2x5x025"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [2 x 5 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 51,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_2x5x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [2 x 5 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 51,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_2x5x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [5 x 10 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 51,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_5x10x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [5 x 10 x 2]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 51,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_5x10x2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [5 x 10 x 5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 51,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_5x10x5"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [10 x 20 x 1]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 51,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_10x20x1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [10 x 20 x 5]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 51,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_10x20x5"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HEMISPHERE [10 x 20 x 10]",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Structure,
                    CategoryIndex = 51,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_10x20x10"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "RESPAWN POINT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = 54,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_point"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BOMB PLANT POINT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Assault,
                    CategoryIndex = 55,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\assault\assault_bomb_goal_area"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BOMB SPAWN POINT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Assault,
                    CategoryIndex = 55,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\assault\assault_bomb_spawn_point"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "STARTING POINT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Assault,
                    CategoryIndex = 55,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\assault\assault_initial_spawn_point"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "RESPAWN AREA",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Assault,
                    CategoryIndex = 55,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\assault\assault_respawn_zone"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "RESPAWN, FLAG HOME",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = 56,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_flag_at_home_respawn_zone"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "RESPAWN, FLAG AWAY",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = 56,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_flag_away_respawn_zone"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "FLAG RETURN POINT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = 56,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\ctf\ctf_flag_return_area"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "FLAG SPAWN POINT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = 56,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\ctf\ctf_flag_spawn_point"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "STARTING POINT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = 56,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_initial_spawn_point"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "RESPAWN AREA",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = 56,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_respawn_zone"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "STARTING POINT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Infection,
                    CategoryIndex = 57,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\infection\infection_initial_spawn_point"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "RESPAWN AREA",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Infection,
                    CategoryIndex = 57,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\infection\infection_respawn_zone"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SAFE HAVEN",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Infection,
                    CategoryIndex = 57,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\infection\infection_haven_static"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "GO TO POINT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Juggernaut,
                    CategoryIndex = 58,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\juggernaut\juggernaut_destination_static"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HILL MARKER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.KingOfTheHill,
                    CategoryIndex = 59,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\koth\koth_hill_static"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "STARTING POINT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.KingOfTheHill,
                    CategoryIndex = 59,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\koth\koth_initial_spawn_point"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "RESPAWN AREA",
                    Type = ForgeGlobalsDefinition.PaletteItemType.KingOfTheHill,
                    CategoryIndex = 59,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\koth\koth_respawn_zone"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BALL SPAWN POINT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = 60,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\oddball\oddball_ball_spawn_point"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "STARTING POINT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = 60,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\oddball\oddball_initial_spawn_point"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "RESPAWN AREA",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = 60,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\oddball\oddball_respawn_zone"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "STARTING POINT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Territories,
                    CategoryIndex = 61,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\territories\territories_initial_spawn_point"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "RESPAWN AREA",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Territories,
                    CategoryIndex = 61,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\territories\territories_respawn_zone"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "TERRITORY MARKER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Territories,
                    CategoryIndex = 61,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\territories\territory_static"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "STARTING POINT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Slayer,
                    CategoryIndex = 62,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\slayer\slayer_initial_spawn_point"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "RESPAWN AREA",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Slayer,
                    CategoryIndex = 62,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\slayer\slayer_respawn_zone"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "GO TO POINT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.VIP,
                    CategoryIndex = 63,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\vip\vip_destination_static"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "STARTING POINT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.VIP,
                    CategoryIndex = 63,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\vip\vip_initial_spawn_point"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "RESPAWN AREA",
                    Type = ForgeGlobalsDefinition.PaletteItemType.VIP,
                    CategoryIndex = 63,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\vip\vip_respawn_zone"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MAP MODIFIER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Tool,
                    CategoryIndex = 64,
                    DescriptionIndex = -1,
                    MaxAllowed = 1,
                    Object = GetCachedTag<Scenery>($@"objects\eldewrito\forge\map_modifier"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.Hidden,
                            IntegerValue = 1,
                            RealValue = 0,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "PREMATCH CAMERA",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Tool,
                    CategoryIndex = 64,
                    DescriptionIndex = -1,
                    MaxAllowed = 1,
                    Object = GetCachedTag<Scenery>($@"objects\multi\generic\mp_cinematic_camera"),
                    Setters = new List<ForgeGlobalsDefinition.PaletteItem.Setter>
                    {
                        new ForgeGlobalsDefinition.PaletteItem.Setter
                        {
                            Target = ForgeGlobalsDefinition.PaletteItem.SetterTarget.General_Physics,
                            Type = ForgeGlobalsDefinition.PaletteItem.SetterType.Integer,
                            Flags = ForgeGlobalsDefinition.PaletteItem.SetterFlags.Hidden,
                            IntegerValue = 1,
                            RealValue = 0,
                        },
                    },
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "KILL VOLUME",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Tool,
                    CategoryIndex = 64,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\boundaries\kill_volume"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "GARBAGE COLLECTION VOLUME",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Tool,
                    CategoryIndex = 64,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\boundaries\garbage_collection_volume"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "CHAIN LINK GATE, RIGHT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 11,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\deadlock\deadlock_chainlinkgate_ii\deadlock_chainlinkgate_ii"),
                },
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
                    Name = "CONCUSSIVE BLAST",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 67,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\concussiveblast_equipment\concussiveblast_equipment"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "HOLOGRAM",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 67,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\hologram_equipment\hologram_equipment"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "LIGHTNING STRIKE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 67,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\lightningstrike_equipment\lightningstrike_equipment"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "REFLECTIVE SHIELD",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 67,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\reactive_armor_equipment\reactive_armor_equipment"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "VEHICLE CAMO",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 67,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\invisibility_vehicle_equipment\invisibility_vehicle_equipment"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "VISION",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 67,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\equipment\vision_equipment\vision_equipment"),
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
                    Name = "AMMO CRATE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 69,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\powerups\ammo_packs\ammo_large\ammo_large"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "AMMO CRATE, SMALL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Equipment,
                    CategoryIndex = 69,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Equipment>($@"objects\powerups\ammo_packs\ammo_small\ammo_small"),
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
                    Name = "ASSAULT RIFLE, ACCURACY",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 71,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle_v5\assault_rifle_v5"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "ASSAULT RIFLE, DAMAGE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 71,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle_v2\assault_rifle_v2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "ASSAULT RIFLE, POWER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 71,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle_v6\assault_rifle_v6"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "ASSAULT RIFLE, RATE OF FIRE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 71,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle_v3\assault_rifle_v3"),
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
                    Name = "BATTLE RIFLE, ACCURACY",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 72,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v2\battle_rifle_v2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BATTLE RIFLE, AMMO",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 72,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v3\battle_rifle_v3"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BATTLE RIFLE, DAMAGE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 72,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v4\battle_rifle_v4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BATTLE RIFLE, POWER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 72,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v6\battle_rifle_v6"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BATTLE RIFLE, RANGE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 72,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v5\battle_rifle_v5"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "BATTLE RIFLE, RATE OF FIRE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 72,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v1\battle_rifle_v1"),
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
                    Name = "SMG, ACCURACY",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 73,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\smg\smg_v2\smg_v2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SMG, DAMAGE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 73,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\smg\smg_v4\smg_v4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SMG, POWER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 73,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\smg\smg_v6\smg_v6"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "SMG, RATE OF FIRE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 73,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\smg\smg_v1\smg_v1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "DMR",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 74,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\dmr\dmr"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "DMR, ACCURACY",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 74,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\dmr\dmr_v2\dmr_v2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "DMR, AMMO",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 74,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\dmr\dmr_v1\dmr_v1"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "DMR, DAMAGE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 74,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\dmr\dmr_v4\dmr_v4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "DMR, POWER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 74,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\dmr\dmr_v6\dmr_v6"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "DMR, RATE OF FIRE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 74,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\dmr\dmr_v3\dmr_v3"),
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
                    Name = "COVENANT CARBINE, ACCURACY",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 75,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v5\covenant_carbine_v5"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "COVENANT CARBINE, AMMO",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 75,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v2\covenant_carbine_v2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "COVENANT CARBINE, DAMAGE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 75,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v4\covenant_carbine_v4"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "COVENANT CARBINE, POWER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 75,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v6\covenant_carbine_v6"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "COVENANT CARBINE, RANGE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 75,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v3\covenant_carbine_v3"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "COVENANT CARBINE, RATE OF FIRE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 75,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v1\covenant_carbine_v1"),
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
                    Name = "MAULER, POWER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 76,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator_v3\excavator_v3"),
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
                    Name = "MAGNUM, DAMAGE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 76,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum_v2\magnum_v2"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "MAGNUM, POWER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 76,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum_v3\magnum_v3"),
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
                    Name = "PLASMA PISTOL, POWER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 76,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol_v3\plasma_pistol_v3"),
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
                    Name = "PLASMA RIFLE, POWER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Weapon,
                    CategoryIndex = 78,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle_v6\plasma_rifle_v6"),
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
                    Name = "TWO-WAY",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Teleporter,
                    CategoryIndex = 80,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_2way\teleporter_2way"),
                },  
                new ForgeGlobalsDefinition.PaletteItem
                {   
                    Name = "RECEIVER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Teleporter,
                    CategoryIndex = 80,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_reciever\teleporter_reciever"),
                },  
                new ForgeGlobalsDefinition.PaletteItem
                {   
                    Name = "SENDER",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Teleporter,
                    CategoryIndex = 80,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_sender\teleporter_sender"),
                },  
                new ForgeGlobalsDefinition.PaletteItem
                {   
                    Name = "SENDER, VEHICLE ONLY",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Teleporter,
                    CategoryIndex = 80,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_sender\teleporter_sender_vehicle_only"),
                },  
                new ForgeGlobalsDefinition.PaletteItem
                {   
                    Name = "RECEIVER, VEHICLE ONLY",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Teleporter,
                    CategoryIndex = 80,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_receiver\teleporter_receiver_vehicle_only"),
                },  
                new ForgeGlobalsDefinition.PaletteItem
                {   
                    Name = "TWO-WAY, VEHICLE ONLY",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Teleporter,
                    CategoryIndex = 80,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_2way\teleporter_2way_vehicle_only"),
                },  
                new ForgeGlobalsDefinition.PaletteItem
                {   
                    Name = "SENDER, VEHICLE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Teleporter,
                    CategoryIndex = 80,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_sender\teleporter_sender_vehicle"),
                },  
                new ForgeGlobalsDefinition.PaletteItem
                {   
                    Name = "RECEIVER, VEHICLE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Teleporter,
                    CategoryIndex = 80,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_receiver\teleporter_receiver_vehicle"),
                },  
                new ForgeGlobalsDefinition.PaletteItem
                {   
                    Name = "TWO-WAY, VEHICLE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Teleporter,
                    CategoryIndex = 80,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_2way\teleporter_2way_vehicle"),
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
                    Name = "null",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = -1,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Vehicle>($@"objects\levels\multi\shrine\shrine_defender\shrine_defender"),
                },  
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "null",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = -1,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\box_l\box_l"),
                },  
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "null",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = -1,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\box_m\box_m"),
                },  
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "null",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = -1,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\box_xl\box_xl"),
                },  
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "null",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = -1,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\box_xxl\box_xxl"),
                },  
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "null",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = -1,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\box_xxxl\box_xxxl"),
                },  
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "null",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = -1,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_l\wall_l"),
                },  
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "null",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = -1,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_m\wall_m"),
                },  
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "null",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = -1,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_xl\wall_xl"),
                },  
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "null",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = -1,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_xxl\wall_xxl"),
                },  
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "null",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = -1,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_xxxl\wall_xxxl"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {   
                    Name = "KILL BALL",
                    Type = ForgeGlobalsDefinition.PaletteItemType.Prop,
                    CategoryIndex = 9,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\damage_sphere\damage_sphere"),
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
                    Name = "STARTING POINT",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = 54,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\spawning\initial_spawn_point"),
                },
                new ForgeGlobalsDefinition.PaletteItem
                {
                    Name = "RESPAWN ZONE",
                    Type = ForgeGlobalsDefinition.PaletteItemType.None,
                    CategoryIndex = 54,
                    DescriptionIndex = -1,
                    MaxAllowed = 0,
                    Object = GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_zone"),
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
            forg.WeatherEffects = new List<ForgeGlobalsDefinition.WeatherEffect>
            {
                new ForgeGlobalsDefinition.WeatherEffect
                {
                    Name = "None",
                    Effect = null,
                },
                new ForgeGlobalsDefinition.WeatherEffect
                {
                    Name = "Snow, Heavy",
                    Effect = GetCachedTag<Effect>($@"fx\scenery_fx\weather\snow\snow_turf\snow_turf"),
                },
                new ForgeGlobalsDefinition.WeatherEffect
                {
                    Name = "Snow, Light",
                    Effect = GetCachedTag<Effect>($@"fx\scenery_fx\weather\snow\snow_heavy\snow_heavy"),
                },
                new ForgeGlobalsDefinition.WeatherEffect
                {
                    Name = "Rain",
                    Effect = GetCachedTag<Effect>($@"fx\scenery_fx\weather\rain\rain_angle\rain_angle"),
                },
                new ForgeGlobalsDefinition.WeatherEffect
                {
                    Name = "Flood Pollen, Light",
                    Effect = GetCachedTag<Effect>($@"fx\scenery_fx\weather\flood_pollen\flood_pollen_light\flood_pollen_light"),
                },
                new ForgeGlobalsDefinition.WeatherEffect
                {
                    Name = "Flood Pollen, Heavy",
                    Effect = GetCachedTag<Effect>($@"fx\scenery_fx\weather\flood_pollen\flood_pollen_heavy\flood_pollen_heavy"),
                },
                new ForgeGlobalsDefinition.WeatherEffect
                {
                    Name = "Falling Ash",
                    Effect = GetCachedTag<Effect>($@"fx\scenery_fx\weather\falling_ash\falling_ash"),
                },
                new ForgeGlobalsDefinition.WeatherEffect
                {
                    Name = "Slipspace Fallout",
                    Effect = GetCachedTag<Effect>($@"fx\scenery_fx\weather\slipspace_fallout\slipspace_fallout"),
                },
                new ForgeGlobalsDefinition.WeatherEffect
                {
                    Name = "Slipspace Fallout, Strong",
                    Effect = GetCachedTag<Effect>($@"fx\scenery_fx\weather\slipspace_fallout\slipspace_fallout_strong"),
                },
            };
            forg.Skies = new List<ForgeGlobalsDefinition.Sky>
            {
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Guardian",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\guardian\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\guardian\sky\guardian"),
                    Wind = GetCachedTag<Wind>($@"levels\multi\guardian\wind_guardian"),
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\guardian\guardian"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\guardian\guardian"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\gaurdian\gaurdian\gaurdian"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Valhalla",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\riverworld\sky\riverworld"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\riverworld\sky\riverworld"),
                    Wind = GetCachedTag<Wind>($@"levels\multi\riverworld\wind_riverworld"),
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\riverworld\riverworld"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\riverworld\riverworld"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\riverworld\halo_ext\halo_ext"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Diamondback",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\s3d_avalanche\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\s3d_avalanche\sky\s3d_avalanche"),
                    Wind = GetCachedTag<Wind>($@"levels\multi\s3d_avalanche\wind_avalanche"),
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\s3d_avalanche\s3d_avalanche"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\s3d_avalanche\s3d_avalanche"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_diamondback\amb_desert_wind\amb_desert_wind"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Edge",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\s3d_edge\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\s3d_edge\sky\s3d_edge"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\s3d_edge\s3d_edge"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\s3d_edge\s3d_edge"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_edge\amb_cave_dry\amb_cave_dry"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Reactor",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\s3d_reactor\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\s3d_reactor\sky\reactor"),
                    Wind = GetCachedTag<Wind>($@"levels\multi\s3d_reactor\wind_reactor"),
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\s3d_reactor\s3d_reactor_indoor"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\s3d_reactor\s3d_reactor"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_reactor\amb_wind_mountains\amb_wind_mountains"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Icebox",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\s3d_turf\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\s3d_turf\sky\s3d_turf"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\s3d_turf\s3d_turf"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\s3d_turf\s3d_turf"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_turf\amb_heavy_snow\amb_heavy_snow"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "The Pit",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\cyberdyne\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\cyberdyne\sky\cyberdyne"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\cyberdyne\cyberdyne"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\cyberdyne\cyberdyne"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\cyberdyne\cyberdyne_main_hallway\cyberdyne_main_hallway"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Narrows",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\chill\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\chill\sky\chill"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\chill\chill"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\chill\chill"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\chill\chill\chill"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Standoff",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\dlc\bunkerworld\sky\bunkerworld"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\dlc\bunkerworld\sky\bunkerworld"),
                    Wind = GetCachedTag<Wind>($@"levels\dlc\bunkerworld\wind_bunkerworld"),
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\dlc\bunkerworld\bunkerworld"),
                    ScreenFX = null,
                    GlobalLighting = null,
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\bunkerworld\bunkerworld_ext\bunkerworld_ext"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Last Resort",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\zanzibar\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\zanzibar\sky\zanzibar"),
                    Wind = GetCachedTag<Wind>($@"levels\multi\zanzibar\wind_zanzibar"),
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\zanzibar\sky\zanzibar"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\zanzibar\zanzibar"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\zanzibar\zanzibar_courtyard\zanzibar_courtyard"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "High Ground",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\deadlock\sky\deadlock"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\deadlock\sky\deadlock"),
                    Wind = GetCachedTag<Wind>($@"levels\multi\deadlock\wind_deadlock"),
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\deadlock\deadlock"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\deadlock\deadlock"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\deadlock\deadlock_air\deadlock_air"),
                },
                new ForgeGlobalsDefinition.Sky()
                {
                    Name = "Sandtrap",
                    Flags = ForgeGlobalsDefinition.SkyFlags.None,
                    Translation = new RealPoint3d(0f, 0f, 0f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Object = GetCachedTag<Scenery>($@"levels\multi\shrine\sky\sky"),
                    Parameters  = GetCachedTag<SkyAtmParameters>($@"levels\multi\shrine\sky\shrine"),
                    Wind = null,
                    CameraFX = GetCachedTag<CameraFxSettings>($@"levels\multi\shrine\shrine"),
                    ScreenFX = null,
                    GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\shrine\shrine"),
                    BackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\shrine\desert_wind2\desert_wind2"),
                },
            };
            forg.FxObject = GetCachedTag<Crate>($@"objects\eldewrito\forge\fx_object");
            forg.FxLight = GetCachedTag<Crate>($@"objects\eldewrito\forge\light_object");
            CacheContext.Serialize(Stream, tag, forg);
        }
    }
}
