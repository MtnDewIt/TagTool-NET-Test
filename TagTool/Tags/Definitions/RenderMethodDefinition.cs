using TagTool.Cache;
using TagTool.Common;
using TagTool.Shaders;
using System.Collections.Generic;
using System;
using System.IO;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "render_method_definition", Size = 0x5C, Tag = "rmdf", MaxVersion = CacheVersion.Eldorado700123)]
    [TagStructure(Name = "render_method_definition", Size = 0x15C, Tag = "rmdf", MinVersion = CacheVersion.HaloReach)]
    public class RenderMethodDefinition : TagStructure
	{
        public CachedTag GlobalOptions;
        public List<CategoryBlock> Categories;
        public List<EntryPointBlock> EntryPoints;
        public List<VertexBlock> VertexTypes;
        public CachedTag GlobalPixelShader;
        public CachedTag GlobalVertexShader;
        public RenderMethodDefinitionFlags Flags;
        public uint Version;
        [TagField(Length = 256, MinVersion = CacheVersion.HaloReach)]
        public string Location;

        [TagStructure(Size = 0x18)]
        public class CategoryBlock : TagStructure
        {
            [TagField(Flags = TagFieldFlags.Label)]
            public StringId Name;
            public List<ShaderOption> ShaderOptions;
            public StringId VertexFunction;
            public StringId PixelFunction;

            [TagStructure(Size = 0x1C)]
            public class ShaderOption : TagStructure
            {
                [TagField(Flags = TagFieldFlags.Label)]
                public StringId Name;
                public CachedTag Option;
                public StringId VertexFunction;
                public StringId PixelFunction;
            }
        }

        [TagStructure(Size = 0x10)]
        public class EntryPointBlock : TagStructure
        {
            [TagField(MaxVersion = CacheVersion.Eldorado235640, Platform = CachePlatform.Original)]
            [TagField(MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
            public EntryPoint_32 EntryPoint;
            [TagField(MinVersion = CacheVersion.Eldorado301003, MaxVersion = CacheVersion.Eldorado700123, Platform = CachePlatform.Original)]
            public EntryPointMs30_32 EntryPointHO;
            [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
            public EntryPointMCC_32 EntryPointMCC;
            [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
            public EntryPointReach_32 EntryPointReach;
            [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
            public EntryPointReachMCC_32 EntryPointReachMCC;

            public List<PassBlock> Passes;

            [TagStructure(Size = 0x10, MaxVersion = CacheVersion.Eldorado700123)]
            [TagStructure(Size = 0x1C, MinVersion = CacheVersion.HaloReach)]
            public class PassBlock : TagStructure
            {
                public PassFlags Flags;
                [TagField(Flags = TagFieldFlags.Padding, Length = 0x2)]
                public byte[] Padding;
                public List<CategoryDependency> CategoryDependencies;
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public List<CategoryDependency> SharedVSCategoryDependencies;

                [Flags]
                public enum PassFlags : ushort
                {
                    None,
                    HasSharedPixelShader
                }

                [TagStructure(Size = 0x2)]
                public class CategoryDependency : TagStructure
				{
                    public ushort Category;
                }
            }
        }

        [TagStructure(Size = 0x10, MaxVersion = CacheVersion.Eldorado700123)]
        [TagStructure(Size = 0x4, MinVersion = CacheVersion.HaloReach)]
        public class VertexBlock : TagStructure
        {
            [TagField(Flags = TagFieldFlags.Label, MaxVersion = CacheVersion.Eldorado700123)]
            public VertexTypeValue VertexType;
            [TagField(Flags = TagFieldFlags.Label, MinVersion = CacheVersion.HaloReach)]
            public VertexTypeValueReach VertexTypeReach;
            [TagField(Flags = TagFieldFlags.Padding, Length = 0x2)]
            public byte[] Padding;
            [TagField(MaxVersion = CacheVersion.Eldorado700123)]
            public List<EntryPointDependency> Dependencies;

            public enum VertexTypeValue : ushort
            {
                World,
                Rigid,
                Skinned,
                ParticleModel,
                FlatWorld,
                FlatRigid,
                FlatSkinned,
                Screen,
                Debug,
                Transparent,
                Particle,
                Contrail,
                LightVolume,
                SimpleChud,
                FancyChud,
                Decorator,
                TinyPosition,
                PatchyFog,
                Water,
                Ripple,
                Implicit,
                Beam,
                DualQuat
            }

            public enum VertexTypeValueReach : ushort 
            {
                World,
                Rigid,
                Skinned,
                ParticleModel,
                FlatWorld,
                FlatRigid,
                FlatSkinned,
                Screen,
                Debug,
                Transparent,
                Particle,
                Contrail,
                LightVolume,
                SimpleChud,
                FancyChud,
                Decorator,
                TinyPosition,
                PatchyFog,
                Water,
                Ripple,
                Implicit,
                Beam,
                WorldTessellated,
                RigidTessellated,
                SkinnedTessellated,
                ShaderCache,
                StructureInstanceImposter,
                ObjectImposter,
                RigidCompressed,
                SkinnedCompressed,
                LightVolumePrecompiled,
                Bink
            }

            [TagStructure(Size = 0x10)]
            public class EntryPointDependency : TagStructure
            {
                [TagField(MaxVersion = CacheVersion.Eldorado235640, Platform = CachePlatform.Original)]
                [TagField(MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
                public EntryPoint_32 EntryPoint;
                [TagField(MinVersion = CacheVersion.Eldorado301003, MaxVersion = CacheVersion.Eldorado700123, Platform = CachePlatform.Original)]
                public EntryPointMs30_32 EntryPointHO;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
                public EntryPointMCC_32 EntryPointMCC;
                [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
                public EntryPointReach_32 EntryPointReach;
                [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
                public EntryPointReachMCC_32 EntryPointReachMCC;

                public List<CategoryDependency> CategoryDependencies;

                [TagStructure(Size = 0x2)]
                public class CategoryDependency : TagStructure
                {
                    public ushort Category;
                }
            }
        }

        [Flags]
        public enum RenderMethodDefinitionFlags : uint
        {
            None,
            UseAutomaticMacros
        }

        public bool ContainsCategory(GameCache cache, string categoryName)
        {
            foreach (var category in Categories)
            {
                if (cache.StringTable.GetString(category.Name) == categoryName)
                    return true;
            }
            return false;
        }

        public string GetCategoryOption(GameCache cache, string categoryName, byte[] options)
        {
            for (int i = 0; i < Categories.Count; i++)
            {
                if (cache.StringTable.GetString(Categories[i].Name) == categoryName)
                    return cache.StringTable.GetString(Categories[i].ShaderOptions[options[i]].Name);
            }
            return "INVALID_CATEGORY";
        }

        public int GetCategoryOptionIndex(GameCache cache, string categoryName, string optionName)
        {
            for (int i = 0; i < Categories.Count; i++)
            {
                if (cache.StringTable.GetString(Categories[i].Name) == categoryName)
                {
                    for (int j = 0; j < Categories[i].ShaderOptions.Count; j++)
                    {
                        if (cache.StringTable.GetString(Categories[i].ShaderOptions[j].Name) == optionName)
                            return j;
                    }
                    break;
                }
            }
            return -1;
        }
    }
}