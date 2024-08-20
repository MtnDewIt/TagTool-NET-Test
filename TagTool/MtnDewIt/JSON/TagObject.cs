using System;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.MtnDewIt.JSON
{
    public class TagObject 
    {
        public string TagName { get; set; }
        public string TagType { get; set; }
        public bool Generate {get; set;}
        public CacheVersion TagVersion { get; set; }

        public List<UnicodeStringData> UnicodeStrings { get; set; }
        public List<BitmapResource> BitmapResources { get; set; }
        public AnimationData AnimationData { get; set; }
        public BlamScriptResource BlamScriptResource { get; set; }

        private TagStructure InlineTagData { get; set; }
        public TagStructure TagData 
        {
            get 
            {
                if (InlineTagData == null && !string.IsNullOrEmpty(TagType)) 
                {
                    // TODO: Figure out how to pull definition from existing tag table
                    // May need to change the type in this case from the definition type, to the definition long form name
                    // We assume that the all the tag definitions are in the same namespace
                    var type = Type.GetType($@"TagTool.Tags.Definitions.{TagType}");
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

    public class UnicodeStringData 
    {
        public string StringIdName { get; set; }
        public string StringIdContent { get; set; }

        public UnicodeStringData(string stringIdName, string stringIdContent) 
        {
            StringIdName = stringIdName;
            StringIdContent = stringIdContent;
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

        public AnimationData(bool sortModes) 
        {
            SortModes = sortModes;
        }

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
