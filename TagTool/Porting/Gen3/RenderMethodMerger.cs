using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Common.Logging;
using TagTool.Tags.Definitions;
using static TagTool.Tags.Definitions.RenderMethod.RenderMethodPostprocessBlock;
using RenderMethodPostprocessBlock = TagTool.Tags.Definitions.RenderMethod.RenderMethodPostprocessBlock;

namespace TagTool.Porting.Gen3
{
    /// <summary>
    /// A class to fix issues when porting the same shader from different maps
    /// </summary>
    /// <remarks>
    /// Shaders can reference bitmaps with no resource. If TagTool encounters such a bitmap during porting, a null reference will be left in its place.
    /// If the same shader is then ported from a different map, it'll also use that shader, and that can cause rendering artifacts.
    /// The goal of this class is to detect those null references, and try to replace them with the correct bitmaps.
    /// </remarks>
    public class RenderMethodMerger
    {
        private readonly PortingContext _portingContext;
        private readonly GameCache _cacheContext;
        private readonly GameCache _blamCache;

        public RenderMethodMerger(PortingContext portingContext)
        {
            _portingContext = portingContext;
            _cacheContext = portingContext.CacheContext;
            _blamCache = portingContext.BlamCache;
        }

        public void MergeRenderMethods(Stream cacheStream, Stream blamCacheStream, CachedTag edTag, CachedTag blamTag)
        {
            if (!_portingContext.Flags.HasFlag(PortingFlags.Recursive))
                return;

            var edDef = _cacheContext.Deserialize(cacheStream, edTag);
            var blamDef = _blamCache.Deserialize(blamCacheStream, blamTag);

            if (MergeDefinition(cacheStream, blamCacheStream, edDef, blamDef))
            {
                _cacheContext.Serialize(cacheStream, edTag, edDef);
                Log.Info($"Merged render methods '{edTag}'");
            }
        }

        private bool MergeDefinition(Stream cacheStream, Stream blamCacheStream, object edDef, object blamDef)
        {
            return edDef switch
            {
                DecalSystem decs => MergeCollection(cacheStream, blamCacheStream, decs.Decal, ((DecalSystem)blamDef).Decal, e => e.DecalName),
                ContrailSystem cntl => MergeCollection(cacheStream, blamCacheStream, cntl.Contrails, ((ContrailSystem)blamDef).Contrails, e => e.Name),
                LightVolumeSystem ltvl => MergeCollection(cacheStream, blamCacheStream, ltvl.LightVolumes, ((LightVolumeSystem)blamDef).LightVolumes, e => e.LightVolumeName),
                BeamSystem beam => MergeCollection(cacheStream, blamCacheStream, beam.Beams, ((BeamSystem)blamDef).Beams, e => e.Name),
                Particle prt3 => MergeRenderMethod(cacheStream, blamCacheStream, prt3.RenderMethod, ((Particle)blamDef).RenderMethod),
                RenderMethod rm => MergeRenderMethod(cacheStream, blamCacheStream, rm, (RenderMethod)blamDef),
                _ => false
            };
        }

        private bool MergeCollection<T>(Stream cacheStream, Stream blamCacheStream, IList<T> edItems, IList<T> blamItems, Func<T, StringId> getName)
        {
            static RenderMethod GetRenderMethod(T item) => item switch
            {
                DecalSystem.DecalDefinitionBlock decal => decal.RenderMethod,
                ContrailSystem.ContrailDefinitionBlock contrail => contrail.RenderMethod,
                LightVolumeSystem.LightVolumeDefinitionBlock lightVolume => lightVolume.RenderMethod,
                BeamSystem.BeamDefinitionBlock beam => beam.RenderMethod,
                _ => throw new NotImplementedException()
            };

            bool merged = false;

            foreach (var edItem in edItems)
            {
                string name = _cacheContext.StringTable.GetString(getName(edItem));
                var blamItem = blamItems.FirstOrDefault(x => _blamCache.StringTable.GetString(getName(x)) == name);

                if (blamItem != null && MergeRenderMethod(cacheStream, blamCacheStream, GetRenderMethod(edItem), GetRenderMethod(blamItem)))
                    merged = true;
            }

            return merged;
        }

        private bool MergeRenderMethod(Stream cacheStream, Stream blamCacheStream, RenderMethod edRm, RenderMethod blamRm)
        {
            static TextureConstant FindTextureConstant(GameCache cache, RenderMethodPostprocessBlock postprocess, RenderMethodTemplate template, string name)
            {
                for (int i = 0; i < postprocess.TextureConstants.Count; i++)
                {
                    if (cache.StringTable.GetString(template.TextureParameterNames[i].Name) == name)
                        return postprocess.TextureConstants[i];
                }
                return null;
            }

            var edPostprocess = edRm.ShaderProperties[0];

            // Optimization: if there are no null references we don't need to go any further
            if (!edPostprocess.TextureConstants.Any(x => x.Bitmap == null))
                return false;

            var blamPostprocess = blamRm.ShaderProperties[0];

            // Deserialize the templates for the parameter names
            var blamRmt2 = _blamCache.Deserialize<RenderMethodTemplate>(blamCacheStream, blamPostprocess.Template);
            var edRmt2 = _cacheContext.Deserialize<RenderMethodTemplate>(cacheStream, edPostprocess.Template);

            bool merged = false;

            // For each texture constant with a null bitmap reference
            for (int i = 0; i < edPostprocess.TextureConstants.Count; i++)
            {
                if (edPostprocess.TextureConstants[i].Bitmap != null)
                    continue;

                // Find the matching parameter by name
                string parameterName = _cacheContext.StringTable.GetString(edRmt2.TextureParameterNames[i].Name);
                var blamTextureConstant = FindTextureConstant(_blamCache, blamPostprocess, blamRmt2, parameterName);

                if (blamTextureConstant != null)
                {
                    // Convert the bitmap
                    edPostprocess.TextureConstants[i].Bitmap = _portingContext.ConvertTag(cacheStream, blamCacheStream, blamTextureConstant.Bitmap);
                    if (edPostprocess.TextureConstants[i].Bitmap != null)
                        merged = true;
                }
            }

            return merged;
        }
    }
}
