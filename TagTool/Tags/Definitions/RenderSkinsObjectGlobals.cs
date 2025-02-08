using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "render_skins_object_globals", Tag = "rsod", Size = 0xC, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
    public class RenderSkinsObjectGlobals : TagStructure
    {
        public List<RenderSkinsObject> RenderSkinsObjects;

        [TagStructure(Size = 0x80)]
        public class RenderSkinsObject : TagStructure
        {
            [TagField(Length = 32)]
            public string Name;

            public RenderSkinsObjectType Types;

            public CachedTag RenderModelTagName;
            public CachedTag VehicleTagName;

            public List<LayerBitmapBlock> LayerBitmaps;
            public List<ReplaceMaterialBlock> ReplaceMaterials;
            public List<ReplaceBitmapBlock> ReplaceBitmaps;
            public List<ReplaceParametersMaterialIndiceBlock> ReplaceParametersMaterialIndices;
            public List<ReplaceParamBlock> ReplaceParams;

            public enum RenderSkinsObjectType : uint 
            {
                SkinnedObjectAssaultRifle,
                SkinnedObjectBattleRifle,
                SkinnedObjectNeedler,
                SkinnedObjectMagnumPistol,
                SkinnedObjectPlasmaPistol,
                SkinnedObjectPlasmaRifle,
                SkinnedObjectRocketLauncher,
                SkinnedObjectShotgun,
                SkinnedObjectSniperRifle,
                SkinnedObjectFlamethrower,
                SkinnedObjectFuelRodCannon,
                SkinnedObjectSMG,
                SkinnedObjectCarbine,
                SkinnedObjectEnergyBlade,
                SkinnedObjectVisor,
                SkinnedObjectWarthog,
                SkinnedObjectWarthogGauss,
                SkinnedObjectGhost,
                SkinnedObjectScorpion,
                SkinnedObjectBanshee,
                SkinnedObjectHornet,
                SkinnedObjectMongoose,
                SkinnedObjectNone,
            }

            [TagStructure(Size = 0x10)]
            public class LayerBitmapBlock : TagStructure 
            {
                public CachedTag LayerBitmap;
            }

            [TagStructure(Size = 0x20)]
            public class ReplaceMaterialBlock : TagStructure
            {
                public CachedTag BaseMaterial;
                public CachedTag NewMaterial;
            }

            [TagStructure(Size = 0x20)]
            public class ReplaceBitmapBlock : TagStructure 
            {
                public CachedTag BaseBitmap;
                public CachedTag NewBitmap;
            }

            [TagStructure(Size = 0x10)]
            public class ReplaceParametersMaterialIndiceBlock : TagStructure 
            {
                public CachedTag ReplaceParametersMaterial;
            }

            [TagStructure(Size = 0x10)]
            public class ReplaceParamBlock : TagStructure 
            {
                public ReplaceParamType Type;
                public ReplaceParamEntryPoint EntryPoint;

                public List<ReplaceParamValue> Values;

                public enum ReplaceParamType : ushort 
                {
                    None = 0,
                    AlbedoColor,
                    SpecularTint,
                    AlbedoSecondColor,
                    SpecularSecondTint,
                    AnalyticalSpecularContribution,
                    EnvironmentMapSpecularContribution,
                    SpeedU,
                    SpeedV,
                }

                public enum ReplaceParamEntryPoint : ushort 
                {
                    EntryPointDefault,
                    EntryPointAlbedo,
                    EntryPointStaticLightingDefault,
                    EntryPointStaticLightingPerPixel,
                    EntryPointStaticLightingPerVertex,
                    EntryPointStaticLightingSh,
                    EntryPointStaticLightingPrtAmbient,
                    EntryPointStaticLightingPrtLinear,
                    EntryPointStaticLightingPrtQuadratic,
                    EntryPointDynamicLighting,
                    EntryPointShadowGenerate,
                    EntryPointShadowApply,
                    EntryPointActiveCamo,
                    EntryPointLightmapDebugMode,
                    EntryPointVertexColorLighting,
                    EntryPointWaterTessellation,
                    EntryPointWaterShading,
                    EntryPointDynamicLightingCinematic,
                }

                [TagStructure(Size = 0x10)]
                public class ReplaceParamValue : TagStructure 
                {
                    public RealVector3d Vector;
                    public float VectorW;
                }
            }
        }
    }
}
