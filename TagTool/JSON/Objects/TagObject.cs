using System;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Cache.Gen3;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Tags.Resources;

namespace TagTool.JSON.Objects
{
    public class TagObject
    {
        public string TagName { get; set; }
        public string TagType { get; set; }
        public bool Generate { get; set; }
        public CacheVersion TagVersion { get; set; }

        public BitmapResources Bitmaps { get; set; }
        public AnimationResources Animations { get; set; }
        public RenderGeometryResources RenderGeometry { get; set; }
        public StructureBspResources StructureBsp { get; set; }
        public SoundResources Sounds { get; set; }
        public UnicodeStringList UnicodeStrings { get; set; }

        public List<BitmapResource> BitmapResources { get; set; }
        public AnimationData AnimationData { get; set; }
        public BlamScriptResource BlamScriptResource { get; set; }

        private TagStructure InlineTagData { get; set; }

        // TODO: Make TagData a nullable field :/
        public TagStructure TagData
        {
            get
            {
                if (InlineTagData == null && !string.IsNullOrEmpty(TagType))
                {
                    var tagDefinitionTable = new TagDefinitionsGen3();
                    tagDefinitionTable.TryGetTagFromName(TagType, out var tagGroup);
                    var type = tagDefinitionTable.GetTagDefinitionType(tagGroup);
                    InlineTagData = (TagStructure)Activator.CreateInstance(type);
                }

                return InlineTagData;
            }
            set
            {
                InlineTagData = value;
            }
        }
    }

    public class BitmapResources
    {
        public List<BitmapTextureInteropResource> Textures { get; set; }
        public List<BitmapTextureInterleavedInteropResource> InterleavedTextures { get; set; }
    }

    public class AnimationResources
    {
        public List<ModelAnimationTagResource> Animations { get; set; }
    }

    public class RenderGeometryResources
    {
        public List<RenderGeometryApiResourceDefinition> Geometry { get; set; }
    }

    public class StructureBspResources
    {
        public List<RenderGeometryApiResourceDefinition> DecoratorGeometry { get; set; }
        public List<RenderGeometryApiResourceDefinition> Geometry { get; set; }
        public List<StructureBspTagResources> Collision { get; set; }
        public List<StructureBspCacheFileTagResources> Pathfinding { get; set; }
    }

    public class SoundResources
    {
        public List<SoundResourceDefinition> Sounds { get; set; }
    }

    public class UnicodeStringList
    {
        public List<UnicodeLanguage> Languages { get; set; }

        public class UnicodeLanguage
        {
            public GameLanguage Language { get; set; }

            public List<UnicodeStringData> UnicodeStrings { get; set; }

            public class UnicodeStringData 
            {
                public string StringIdName { get; set; }
                public string StringIdContent { get; set; }
            }
        }
    }

    public class BitmapResource
    {
        public int BitmapIndex { get; set; }
        public string DDSFile { get; set; }

        public BitmapResource(int bitmapIndex, string ddsFile)
        {
            BitmapIndex = bitmapIndex;
            DDSFile = ddsFile;
        }
    }

    public class AnimationData
    {
        public List<AnimationResource> AnimationResources { get; set; }
        public bool SortModes { get; set; }

        public class AnimationResource
        {
            public string AnimationFile { get; set; }

            public AnimationResource(string animationFile)
            {
                AnimationFile = animationFile;
            }
        };
    }

    public class BlamScriptResource
    {
        public string BlamScriptFile { get; set; }

        public BlamScriptResource(string scriptFile)
        {
            BlamScriptFile = scriptFile;
        }
    }
}
