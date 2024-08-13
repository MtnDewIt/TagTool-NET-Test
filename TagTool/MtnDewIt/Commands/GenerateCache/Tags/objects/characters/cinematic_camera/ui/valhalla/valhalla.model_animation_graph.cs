using System.Collections.Generic;
using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Shaders;
using TagTool.Tags.Definitions;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags
{
    public class objects_characters_cinematic_camera_ui_valhalla_valhalla_model_animation_graph : TagFile
    {
        public objects_characters_cinematic_camera_ui_valhalla_valhalla_model_animation_graph(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<ModelAnimationGraph>($@"objects\characters\cinematic_camera\ui\valhalla\valhalla");
            var jmad = CacheContext.Deserialize<ModelAnimationGraph>(Stream, tag);
            jmad.PrivateFlags = ModelAnimationGraph.AnimationPrivateFlags.PreparedForCache | ModelAnimationGraph.AnimationPrivateFlags.ImportedWithCodecCompressors | ModelAnimationGraph.AnimationPrivateFlags.AnimationDataReordered | ModelAnimationGraph.AnimationPrivateFlags.ReadyForUse;
            jmad.AnimationCodecPack = 6;
            jmad.SkeletonNodes = new List<ModelAnimationGraph.SkeletonNode>
            {
                new ModelAnimationGraph.SkeletonNode
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"camera01"),
                    NextSiblingNodeIndex = -1,
                    FirstChildNodeIndex = -1,
                    ParentNodeIndex = -1,
                    ModelFlags = ModelAnimationGraph.SkeletonNode.SkeletonModelFlags.PrimaryModel | ModelAnimationGraph.SkeletonNode.SkeletonModelFlags.LocalRoot,
                    ZPosition = 1.57E-06f,
                },
            };
            jmad.WeaponList = new List<ModelAnimationGraph.WeaponListBlock>
            {
                new ModelAnimationGraph.WeaponListBlock
                {
                    WeaponName = CacheContext.StringTable.GetOrAddString($@"any"),
                    WeaponClass = CacheContext.StringTable.GetOrAddString($@"any"),
                },
            };
            jmad.LeftArmNodes = new uint[8];
            jmad.RightArmNodes = new uint[8]
            {
                1, 0, 0, 0, 0, 0, 0, 0,
            };
            CacheContext.Serialize(Stream, tag, jmad);

            AddAnimation(tag, $@"{Program.TagToolDirectory}\Tools\data\{tag.Name}\camera_path_main1.JMM");
        }
    }
}
