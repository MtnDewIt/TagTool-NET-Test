using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.ConvertCache.Definitions
{
    [TagStructure(Name = "forge_globals_definition", Tag = "forg", Size = 0xE0)]
    public class DebugForgeGlobalsDefinition : TagStructure
    {
        [TagField(ValidTags = new[] { "rm  " })]
        public CachedTag InvisibleRenderMethod;
        [TagField(ValidTags = new[] { "rm  " })]
        public CachedTag DefaultRenderMethod;

        public List<ForgeGlobalsDefinition.ReForgeMaterial> ReForgeMaterials;
        public List<ForgeGlobalsDefinition.ReForgeMaterialType> ReForgeMaterialTypes;
        public List<TagReferenceBlock> ReForgeObjects;

        [TagField(ValidTags = new[] { "obje" })]
        public CachedTag PrematchCameraObject;
        [TagField(ValidTags = new[] { "obje" })]
        public CachedTag ModifierObject;
        [TagField(ValidTags = new[] { "obje" })]
        public CachedTag KillVolumeObject;
        [TagField(ValidTags = new[] { "obje" })]
        public CachedTag GarbageVolumeObject;

        public List<ForgeGlobalsDefinition.Description> Descriptions;
        public List<ForgeGlobalsDefinition.PaletteCategory> PaletteCategories;
        public List<ForgeGlobalsDefinition.PaletteItem> Palette;
        public List<ForgeGlobalsDefinition.WeatherEffect> WeatherEffects;
        public List<ForgeGlobalsDefinition.Sky> Skies;

        public CachedTag FxObject;
        public CachedTag FxLight;
    }
}
