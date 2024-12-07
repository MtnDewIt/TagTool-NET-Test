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
        public CacheVersion TagVersion { get; set; }

        public BitmapResources Bitmaps { get; set; }
        public AnimationResources Animations { get; set; }
        public RenderGeometryResources RenderGeometry { get; set; }
        public BlamScriptResource BlamScriptResource { get; set; }
        public StructureBspResources StructureBsp { get; set; }
        public SoundResources Sounds { get; set; }
        public UnicodeStringList UnicodeStrings { get; set; }

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
        public RenderGeometryApiResourceDefinition Geometry { get; set; }
    }

    public class BlamScriptResource
    {
        public string BlamScriptFile { get; set; }

        public BlamScriptResource(string scriptFile)
        {
            BlamScriptFile = scriptFile;
        }
    }

    public class StructureBspResources
    {
        public RenderGeometryApiResourceDefinition DecoratorGeometry { get; set; }
        public RenderGeometryApiResourceDefinition Geometry { get; set; }
        public StructureBspTagResources Collision { get; set; }
        public StructureBspCacheFileTagResources Pathfinding { get; set; }
    }

    public class SoundResources
    {
        public SoundResourceDefinition Sound { get; set; }
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
}
