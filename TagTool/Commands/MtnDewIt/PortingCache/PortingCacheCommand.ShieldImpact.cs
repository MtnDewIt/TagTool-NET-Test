using TagTool.Tags.Definitions;
using TagTool.Common;
using System;

namespace TagTool.Commands.Tags 
{
    partial class PortingCacheCommand : Command 
    {
        public void GenerateShieldImpactTags() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {

                var overshield3pTag = CacheContext.TagCache.AllocateTag<ShieldImpact>($@"fx\shield_impacts\overshield_3p");
                var overshield3p = new ShieldImpact();
                CacheContext.Serialize(stream, overshield3pTag, overshield3p);

                var overshield1pTag = CacheContext.TagCache.AllocateTag<ShieldImpact>($@"fx\shield_impacts\overshield_1p");
                var overshield1p = new ShieldImpact();
                CacheContext.Serialize(stream, overshield1pTag, overshield1p);

                var globalImpactTag = CacheContext.TagCache.AllocateTag<ShieldImpact>($@"globals\global_shield_impact_settings");
                var globalImpact = new ShieldImpact();
                CacheContext.Serialize(stream, globalImpactTag, globalImpact);

                var spartan3pTag = CacheContext.TagCache.AllocateTag<ShieldImpact>($@"globals\masterchief_3p_shield_impact");
                var spartan3p = new ShieldImpact();
                CacheContext.Serialize(stream, spartan3pTag, spartan3p);

                var spartan1pTag = CacheContext.TagCache.AllocateTag<ShieldImpact>($@"globals\masterchief_fp_shield_impact");
                var spartan1p = new ShieldImpact();
                CacheContext.Serialize(stream, spartan1pTag, spartan1p);
            }
        }
        public void ShieldImpactSetup()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("shit") && tag.Name == $@"globals\global_shield_impact_settings") 
                    {
                        var shit = CacheContext.Deserialize<ShieldImpact>(stream, tag);
                        shit.Version = 4;
                        shit.ShieldIntensity = new ShieldImpact.ShieldIntensityBlock
                        {
                            RecentDamageIntensity = 0.3f,
                            CurrentDamageIntensity = 5f,
                        };
                        shit.ShieldEdge = new ShieldImpact.ShieldEdgeBlock
                        {
                            DepthFadeRange = 0.6f,
                            OuterFadeRadius = 0.05000001f,
                            CenterRadius = 0.5f,
                            InnerFadeRadius = 0.9f,
                            EdgeGlowColor = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x01, 0x34, 0x01, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x4C, 0x19, 0x00,
                                        0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                            EdgeGlowIntensity = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x01, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                        };
                        shit.Plasma = new ShieldImpact.PlasmaBlock
                        {
                            PlasmaDepthFadeRange = 0.6f,
                            PlasmaNoiseBitmap1 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_1"),
                            PlasmaNoiseBitmap2 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_2"),
                            TilingScale = 1f,
                            ScrollSpeed = 0.5f,
                            EdgeSharpness = 4f,
                            CenterSharpness = 80f,
                            PlasmaOuterFadeRadius = 0.05000001f,
                            PlasmaCenterRadius = 0.5f,
                            PlasmaInnerFadeRadius = 0.9f,
                            PlasmaCenterColor = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x01, 0x34, 0x01, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x4C, 0x19, 0x00,
                                        0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                            PlasmaCenterIntensity = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x01, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                            PlasmaEdgeColor = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_vitality"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x01, 0x34, 0x01, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x4C, 0x19, 0x00,
                                        0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                            PlasmaEdgeIntensity = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x20, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x24, 0x00,
                                        0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                        0xC3, 0xF5, 0x28, 0x3E, 0x7C, 0xF0, 0xC1, 0x40, 0x00, 0x00,
                                        0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x7F, 0x7F,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F,
                                    },
                                },
                            },
                        };
                        shit.ExtrusionOscillation = new ShieldImpact.ExtrusionOscillationBlock
                        {
                            OscillationBitmap1 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_1"),
                            OscillationBitmap2 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_2"),
                            OscillationTilingScale = 2f,
                            OscillationScrollSpeed = 0.08f,
                            ExtrusionAmount = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x8F, 0xC2, 0x75, 0x3C, 0xCD, 0xCC,
                                        0x4C, 0x3D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00,0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                            OscillationAmplitude = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0A, 0xD7,
                                        0xA3, 0x3D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x34, 0x00,
                                        0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                        0x14, 0xAE, 0x87, 0x3E, 0x00, 0x99, 0x93, 0xC1, 0xE7, 0x8D,
                                        0x46, 0x41, 0x58, 0x55, 0x55, 0x3E, 0x00, 0x00, 0x00, 0x00,
                                        0x07, 0xCF, 0x92, 0x3E, 0xFF, 0xFF, 0x7F, 0x7F, 0xE7, 0xB7,
                                        0xA7, 0x40, 0xCB, 0x0F, 0x33, 0xC1, 0x95, 0x39, 0xF7, 0x40,
                                        0x2C, 0x8F, 0x46, 0xBF,
                                    },
                                },
                            },
                        };
                        shit.HitResponse = new ShieldImpact.HitResponseBlock
                        {
                            HitTime = 2.5f,
                            HitColor = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x01, 0x34, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0xA4, 0x2A,
                                        0x15, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF3, 0x51, 0xFF, 0x00,
                                        0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                            HitIntensity = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0xCD, 0xCC, 0x4C, 0x3D, 0xCD, 0xCC,
                                        0x4C, 0x3E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0xF6, 0x9C, 0x45, 0xBF, 0xEC, 0x39,
                                        0x0B, 0x3F, 0x85, 0x31, 0x9D, 0x3F, 0x00, 0x00, 0x00, 0x00,
                                    },
                                },
                            },
                        };
                        shit.EdgeScales = new RealQuaternion(2.222222f, -2.5f, 2.222222f, -2.5f);
                        shit.EdgeOffsets = new RealQuaternion(-0.1111111f, 2.25f, -0.1111111f, 2.25f);
                        shit.PlasmaScales = new RealQuaternion(1f, 1f, -76f, 80f);
                        shit.DepthFadeParameters = new RealQuaternion(1.666667f, 1.666667f, 0f, 0f);
                        CacheContext.Serialize(stream, tag, shit);
                    }

                    if (tag.IsInGroup("shit") && tag.Name == $@"globals\masterchief_3p_shield_impact")
                    {
                        var shit = CacheContext.Deserialize<ShieldImpact>(stream, tag);
                        shit.Version = 4;
                        shit.ShieldIntensity = new ShieldImpact.ShieldIntensityBlock
                        {
                            RecentDamageIntensity = 0.15f,
                        };
                        shit.ShieldEdge = new ShieldImpact.ShieldEdgeBlock
                        {
                            DepthFadeRange = 0.25f,
                            OuterFadeRadius = 0.5f,
                            CenterRadius = 0.75f,
                            InnerFadeRadius = 1f,
                            EdgeGlowColor = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x02, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x00,
                                    0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x80, 0xE5, 0xFF,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x1C, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0xED, 0xBE, 0x6B, 0x3F, 0x9E, 0x33,
                                    0x2A, 0xC0, 0xE3, 0x43, 0x2F, 0x40, 0x00, 0x00, 0x00, 0x00,
                                    },
                                },
                            },
                            EdgeGlowIntensity = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x01, 0x34, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                    0xC0, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x1C, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00,
                                    0x40, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F,
                                    },
                                },
                            },
                        };
                        shit.Plasma = new ShieldImpact.PlasmaBlock
                        {
                            PlasmaDepthFadeRange = 0.05f,
                            PlasmaNoiseBitmap1 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_1"),
                            PlasmaNoiseBitmap2 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_2"),
                            TilingScale = 3f,
                            ScrollSpeed = 0.5f,
                            EdgeSharpness = 20f,
                            CenterSharpness = 60f,
                            PlasmaCenterRadius = 0.5f,
                            PlasmaInnerFadeRadius = 0.75f,
                            PlasmaCenterColor = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x02, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x17, 0x39,
                                    0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x34, 0x77, 0xB3, 0xFF,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x1C, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0xC4, 0x40, 0x67, 0x3F, 0xE0, 0xF9,
                                    0xC5, 0x3D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    },
                                },
                            },
                            PlasmaCenterIntensity = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x42, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00,
                                    },
                                },
                            },
                            PlasmaEdgeColor = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x02, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x17, 0x39,
                                    0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x34, 0x00,
                                    0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xAE, 0x47, 0xA1, 0x3E, 0x12, 0x25, 0x6D, 0xC0, 0x81, 0xCC,
                                    0xF7, 0xC0, 0xC5, 0x68, 0xBF, 0x40, 0x00, 0x00, 0x00, 0x00,
                                    0x07, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x80, 0x3F,
                                    },
                                },
                            },
                            PlasmaEdgeIntensity = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                    0x00, 0x4F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0x10, 0xC6, 0x62, 0xC0, 0x10, 0xC6,
                                    0x22, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F,
                                    },
                                },
                            },
                        };
                        shit.ExtrusionOscillation = new ShieldImpact.ExtrusionOscillationBlock
                        {
                            OscillationBitmap1 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_1"),
                            OscillationBitmap2 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_2"),
                            OscillationTilingScale = 2f,
                            OscillationScrollSpeed = 0.15f,
                            ExtrusionAmount = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x00, 0x00, 0xA6, 0x9B, 0xC4, 0x3A, 0x42, 0x60,
                                    0x65, 0x3B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x28, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0x10, 0x63, 0x9A, 0x3D, 0x3C, 0x67,
                                    0x59, 0x3F, 0xCF, 0x59, 0xF6, 0xBF, 0x00, 0x00, 0x80, 0x3F,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x20, 0xDC,
                                    0x2B, 0x3F,
                                    },
                                },
                            },
                            OscillationAmplitude = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x01, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00,
                                    },
                                },
                            },
                        };
                        shit.HitResponse = new ShieldImpact.HitResponseBlock
                        {
                            HitTime = 2.857143f,
                            HitColor = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x00, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0xAB, 0x62, 0xA7, 0xBF, 0x5E, 0x16,
                                        0x08, 0x40, 0x73, 0xAF, 0x39, 0x3E, 0x00, 0x00, 0x00, 0x00,
                                        0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0xFF, 0xFF,
                                        0x7F, 0x7F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F,
                                    },
                                },
                            },
                            HitIntensity = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x01, 0x34, 0x00, 0x00, 0xCD, 0xCC, 0xCC, 0x3D, 0xCD, 0xCC,
                                        0x4C, 0x3E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x2C, 0x00,
                                        0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                        0x5C, 0x8F, 0x02, 0x3F, 0x60, 0x17, 0x07, 0xC0, 0x19, 0xED,
                                        0xBF, 0x40, 0x0F, 0x0F, 0x8F, 0xC0, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    },
                                },
                            },
                        };
                        shit.EdgeScales = new RealQuaternion(3f, -4f, 2f, -4f);
                        shit.EdgeOffsets = new RealQuaternion(-2f, 4f, 0f, 10f);
                        shit.PlasmaScales = new RealQuaternion(5f, 4f, -45f, 60f);
                        shit.DepthFadeParameters = new RealQuaternion(4f, 0f, 20f, 20f);
                        CacheContext.Serialize(stream, tag, shit);
                    }

                    if (tag.IsInGroup("shit") && tag.Name == $@"globals\masterchief_fp_shield_impact")
                    {
                        var shit = CacheContext.Deserialize<ShieldImpact>(stream, tag);
                        shit.Version = 4;
                        shit.ShieldIntensity = new ShieldImpact.ShieldIntensityBlock
                        {
                            RecentDamageIntensity = 0.15f,
                        };
                        shit.ShieldEdge = new ShieldImpact.ShieldEdgeBlock
                        {
                            DepthFadeRange = 0.25f,
                            OuterFadeRadius = 0.5f,
                            CenterRadius = 0.75f,
                            InnerFadeRadius = 1f,
                            EdgeGlowColor = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x02, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x00,
                                    0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x80, 0xE5, 0xFF,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x1C, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0xED, 0xBE, 0x6B, 0x3F, 0x9E, 0x33,
                                    0x2A, 0xC0, 0xE3, 0x43, 0x2F, 0x40, 0x00, 0x00, 0x00, 0x00,
                                    },
                                },
                            },
                            EdgeGlowIntensity = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x01, 0x34, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                    0xC0, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x1C, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00,
                                    0x40, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F,
                                    },
                                },
                            },
                        };
                        shit.Plasma = new ShieldImpact.PlasmaBlock
                        {
                            PlasmaDepthFadeRange = 0.05f,
                            PlasmaNoiseBitmap1 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_1"),
                            PlasmaNoiseBitmap2 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_2"),
                            TilingScale = 3f,
                            ScrollSpeed = 0.5f,
                            EdgeSharpness = 20f,
                            CenterSharpness = 60f,
                            PlasmaCenterRadius = 0.5f,
                            PlasmaInnerFadeRadius = 0.75f,
                            PlasmaCenterColor = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x02, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x17, 0x39,
                                    0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x34, 0x77, 0xB3, 0xFF,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x1C, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0xC4, 0x40, 0x67, 0x3F, 0xE0, 0xF9,
                                    0xC5, 0x3D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    },
                                },
                            },
                            PlasmaCenterIntensity = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x42, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00,
                                    },
                                },
                            },
                            PlasmaEdgeColor = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x02, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x17, 0x39,
                                    0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x34, 0x00,
                                    0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xAE, 0x47, 0xA1, 0x3E, 0x12, 0x25, 0x6D, 0xC0, 0x81, 0xCC,
                                    0xF7, 0xC0, 0xC5, 0x68, 0xBF, 0x40, 0x00, 0x00, 0x00, 0x00,
                                    0x07, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x80, 0x3F,
                                    },
                                },
                            },
                            PlasmaEdgeIntensity = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                    0x00, 0x4F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0x10, 0xC6, 0x62, 0xC0, 0x10, 0xC6,
                                    0x22, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F,
                                    },
                                },
                            },
                        };
                        shit.ExtrusionOscillation = new ShieldImpact.ExtrusionOscillationBlock
                        {
                            OscillationBitmap1 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_1"),
                            OscillationBitmap2 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_2"),
                            OscillationTilingScale = 2f,
                            OscillationScrollSpeed = 0.15f,
                            ExtrusionAmount = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x00, 0x00, 0xA6, 0x9B, 0xC4, 0x3A, 0x42, 0x60,
                                    0x65, 0x3B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x28, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0x10, 0x63, 0x9A, 0x3D, 0x3C, 0x67,
                                    0x59, 0x3F, 0xCF, 0x59, 0xF6, 0xBF, 0x00, 0x00, 0x80, 0x3F,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x20, 0xDC,
                                    0x2B, 0x3F,
                                    },
                                },
                            },
                            OscillationAmplitude = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x01, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00,
                                    },
                                },
                            },
                        };
                        shit.HitResponse = new ShieldImpact.HitResponseBlock
                        {
                            HitTime = 2.857143f,
                            HitColor = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x00, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0xAB, 0x62, 0xA7, 0xBF, 0x5E, 0x16,
                                        0x08, 0x40, 0x73, 0xAF, 0x39, 0x3E, 0x00, 0x00, 0x00, 0x00,
                                        0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0xFF, 0xFF,
                                        0x7F, 0x7F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F,
                                    },
                                },
                            },
                            HitIntensity = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x01, 0x34, 0x00, 0x00, 0xCD, 0xCC, 0xCC, 0x3D, 0xCD, 0xCC,
                                        0x4C, 0x3E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x2C, 0x00,
                                        0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                        0x5C, 0x8F, 0x02, 0x3F, 0x60, 0x17, 0x07, 0xC0, 0x19, 0xED,
                                        0xBF, 0x40, 0x0F, 0x0F, 0x8F, 0xC0, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    },
                                },
                            },
                        };
                        shit.EdgeScales = new RealQuaternion(3f, -4f, 2f, -4f);
                        shit.EdgeOffsets = new RealQuaternion(-2f, 4f, 0f, 10f);
                        shit.PlasmaScales = new RealQuaternion(5f, 4f, -45f, 60f);
                        shit.DepthFadeParameters = new RealQuaternion(4f, 0f, 20f, 20f);
                        CacheContext.Serialize(stream, tag, shit);
                    }

                    if (tag.IsInGroup("shit") && tag.Name == $@"fx\shield_impacts\overshield_3p")
                    {
                        var shit = CacheContext.Deserialize<ShieldImpact>(stream, tag);
                        shit.Version = 4;
                        shit.ShieldIntensity = new ShieldImpact.ShieldIntensityBlock
                        {
                            RecentDamageIntensity = 0.25f,
                        };
                        shit.ShieldEdge = new ShieldImpact.ShieldEdgeBlock
                        {
                            OvershieldScale = 1f,
                            DepthFadeRange = 0.25f,
                            OuterFadeRadius = 0.5f,
                            CenterRadius = 0.75f,
                            InnerFadeRadius = 1f,
                            EdgeGlowColor = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x01, 0x34, 0x02, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x00,
                                    0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0x00,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x1C, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0xED, 0xBE, 0x6B, 0x3F, 0x9E, 0x33,
                                    0x2A, 0xC0, 0xE3, 0x43, 0x2F, 0x40, 0x00, 0x00, 0x00, 0x00,
                                    },
                                },
                            },
                            EdgeGlowIntensity = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x01, 0x34, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                    0xC0, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x1C, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00,
                                    0x40, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F,
                                    },
                                },
                            },
                        };
                        shit.Plasma = new ShieldImpact.PlasmaBlock
                        {
                            PlasmaDepthFadeRange = 0.05f,
                            PlasmaNoiseBitmap1 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_1"),
                            PlasmaNoiseBitmap2 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_2"),
                            TilingScale = 3f,
                            ScrollSpeed = 0.5f,
                            EdgeSharpness = 20f,
                            CenterSharpness = 60f,
                            PlasmaCenterRadius = 0.5f,
                            PlasmaInnerFadeRadius = 0.75f,
                            PlasmaCenterColor = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x02, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x17, 0x39,
                                    0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFE, 0xB8, 0x00,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x1C, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0xC4, 0x40, 0x67, 0x3F, 0xE0, 0xF9,
                                    0xC5, 0x3D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    },
                                },
                            },
                            PlasmaCenterIntensity = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x42, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00,
                                    },
                                },
                            },
                            PlasmaEdgeColor = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x02, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x00,
                                    0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0x00,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x34, 0x00,
                                    0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xAE, 0x47, 0xA1, 0x3E, 0x12, 0x25, 0x6D, 0xC0, 0x81, 0xCC,
                                    0xF7, 0xC0, 0xC5, 0x68, 0xBF, 0x40, 0x00, 0x00, 0x00, 0x00,
                                    0x07, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x80, 0x3F,
                                    },
                                },
                            },
                            PlasmaEdgeIntensity = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_vitality"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x01, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00,
                                    0x20, 0x41, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x28, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0x90, 0xB0, 0x20, 0xBE, 0x24, 0x2C,
                                    0xA8, 0x3F, 0x09, 0x0B, 0x0A, 0xC0, 0x00, 0x00, 0x80, 0x3F,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x7F, 0x41,
                                    0x77, 0x3F,
                                    },
                                },
                            },
                        };
                        shit.ExtrusionOscillation = new ShieldImpact.ExtrusionOscillationBlock
                        {
                            OscillationBitmap1 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_1"),
                            OscillationBitmap2 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_2"),
                            OscillationTilingScale = 2f,
                            OscillationScrollSpeed = 0.15f,
                            ExtrusionAmount = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x00, 0x00, 0x0A, 0xD7, 0xA3, 0x3B, 0x6F, 0x12,
                                    0x03, 0x3B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0x30, 0xFB, 0xBB, 0xBE, 0x98, 0xFD,
                                    0xDD, 0x3F, 0x66, 0x7F, 0x17, 0xC0, 0x00, 0x00, 0x80, 0x3F,
                                    },
                                },
                            },
                            OscillationAmplitude = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_vitality"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x01, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x00, 0x00,
                                    0x00, 0x00,
                                    },
                                },
                            },
                        };
                        shit.HitResponse = new ShieldImpact.HitResponseBlock
                        {
                            HitTime = 2.857143f,
                            HitColor = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_vitality"),
                                RangeVariable = CacheContext.StringTable.GetStringId($@"shield_vitality"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x02, 0x00, 0x70, 0x70, 0xFF, 0x00, 0xB4, 0x2A,
                                    0x28, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0x0E, 0xF8, 0x00,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x1C, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0xAB, 0x62, 0xA7, 0xBF, 0x5E, 0x16,
                                    0x08, 0x40, 0x73, 0xAF, 0x39, 0x3E, 0x00, 0x00, 0x00, 0x00,
                                    },
                                },
                            },
                            HitIntensity = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_vitality"),
                                RangeVariable = CacheContext.StringTable.GetStringId($@"shield_vitality"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x00, 0x00, 0xCD, 0xCC, 0xCC, 0x3D, 0xCD, 0xCC,
                                    0x4C, 0x3E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x2C, 0x00,
                                    0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0x5C, 0x8F, 0x02, 0x3F, 0x60, 0x17, 0x07, 0xC0, 0x19, 0xED,
                                    0xBF, 0x40, 0x0F, 0x0F, 0x8F, 0xC0, 0x00, 0x00, 0x80, 0x3F,
                                    0x04, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    },
                                },
                            },
                        };
                        shit.EdgeScales = new RealQuaternion(3f, -4f, 2f, -4f);
                        shit.EdgeOffsets = new RealQuaternion(-2f, 4f, 0f, 10f);
                        shit.PlasmaScales = new RealQuaternion(5f, 4f, -45f, 60f);
                        shit.DepthFadeParameters = new RealQuaternion(4f, 0f, 20f, 20f);
                        CacheContext.Serialize(stream, tag, shit);
                    }

                    if (tag.IsInGroup("shit") && tag.Name == $@"fx\shield_impacts\overshield_1p")
                    {
                        var shit = CacheContext.Deserialize<ShieldImpact>(stream, tag);
                        shit.Version = 4;
                        shit.ShieldIntensity = new ShieldImpact.ShieldIntensityBlock
                        {
                            RecentDamageIntensity = 0.25f,
                        };
                        shit.ShieldEdge = new ShieldImpact.ShieldEdgeBlock
                        {
                            OvershieldScale = 1f,
                            DepthFadeRange = 0.25f,
                            OuterFadeRadius = 0.5f,
                            CenterRadius = 0.75f,
                            InnerFadeRadius = 1f,
                            EdgeGlowColor = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x01, 0x34, 0x02, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x00,
                                    0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0x00,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x1C, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0xED, 0xBE, 0x6B, 0x3F, 0x9E, 0x33,
                                    0x2A, 0xC0, 0xE3, 0x43, 0x2F, 0x40, 0x00, 0x00, 0x00, 0x00,
                                    },
                                },
                            },
                            EdgeGlowIntensity = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x01, 0x34, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                    0xC0, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x1C, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00,
                                    0x40, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F,
                                    },
                                },
                            },
                        };
                        shit.Plasma = new ShieldImpact.PlasmaBlock
                        {
                            PlasmaDepthFadeRange = 0.05f,
                            PlasmaNoiseBitmap1 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_1"),
                            PlasmaNoiseBitmap2 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_2"),
                            TilingScale = 3f,
                            ScrollSpeed = 0.5f,
                            EdgeSharpness = 20f,
                            CenterSharpness = 60f,
                            PlasmaCenterRadius = 0.5f,
                            PlasmaInnerFadeRadius = 0.75f,
                            PlasmaCenterColor = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x02, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x17, 0x39,
                                    0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFE, 0xB8, 0x00,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x1C, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0xC4, 0x40, 0x67, 0x3F, 0xE0, 0xF9,
                                    0xC5, 0x3D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    },
                                },
                            },
                            PlasmaCenterIntensity = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x42, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00,
                                    },
                                },
                            },
                            PlasmaEdgeColor = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x02, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x00,
                                    0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0x00,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x34, 0x00,
                                    0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xAE, 0x47, 0xA1, 0x3E, 0x12, 0x25, 0x6D, 0xC0, 0x81, 0xCC,
                                    0xF7, 0xC0, 0xC5, 0x68, 0xBF, 0x40, 0x00, 0x00, 0x00, 0x00,
                                    0x07, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x80, 0x3F,
                                    },
                                },
                            },
                            PlasmaEdgeIntensity = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_vitality"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x01, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00,
                                    0x20, 0x41, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x28, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0x90, 0xB0, 0x20, 0xBE, 0x24, 0x2C,
                                    0xA8, 0x3F, 0x09, 0x0B, 0x0A, 0xC0, 0x00, 0x00, 0x80, 0x3F,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x7F, 0x41,
                                    0x77, 0x3F,
                                    },
                                },
                            },
                        };
                        shit.ExtrusionOscillation = new ShieldImpact.ExtrusionOscillationBlock
                        {
                            OscillationBitmap1 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_1"),
                            OscillationBitmap2 = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\test_maps\cloud_2"),
                            OscillationTilingScale = 2f,
                            OscillationScrollSpeed = 0.15f,
                            ExtrusionAmount = new ShieldImpactFunction
                            {
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x00, 0x00, 0x0A, 0xD7, 0xA3, 0x3B, 0x6F, 0x12,
                                    0x03, 0x3B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0x30, 0xFB, 0xBB, 0xBE, 0x98, 0xFD,
                                    0xDD, 0x3F, 0x66, 0x7F, 0x17, 0xC0, 0x00, 0x00, 0x80, 0x3F,
                                    },
                                },
                            },
                            OscillationAmplitude = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_vitality"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x01, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x00, 0x00,
                                    0x00, 0x00,
                                    },
                                },
                            },
                        };
                        shit.HitResponse = new ShieldImpact.HitResponseBlock
                        {
                            HitTime = 2.857143f,
                            HitColor = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_vitality"),
                                RangeVariable = CacheContext.StringTable.GetStringId($@"shield_vitality"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x02, 0x00, 0x70, 0x70, 0xFF, 0x00, 0xB4, 0x2A,
                                    0x28, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0x0E, 0xF8, 0x00,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x1C, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0xAB, 0x62, 0xA7, 0xBF, 0x5E, 0x16,
                                    0x08, 0x40, 0x73, 0xAF, 0x39, 0x3E, 0x00, 0x00, 0x00, 0x00,
                                    },
                                },
                            },
                            HitIntensity = new ShieldImpactFunction
                            {
                                InputVariable = CacheContext.StringTable.GetStringId($@"shield_vitality"),
                                RangeVariable = CacheContext.StringTable.GetStringId($@"shield_vitality"),
                                Function = new TagTool.Tags.TagFunction
                                {
                                    Data = new byte[]
                                    {
                                    0x08, 0x34, 0x00, 0x00, 0xCD, 0xCC, 0xCC, 0x3D, 0xCD, 0xCC,
                                    0x4C, 0x3E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x6F, 0x12, 0x83, 0x3A, 0x6F, 0x12, 0x03, 0x3B, 0x2C, 0x00,
                                    0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                                    0x5C, 0x8F, 0x02, 0x3F, 0x60, 0x17, 0x07, 0xC0, 0x19, 0xED,
                                    0xBF, 0x40, 0x0F, 0x0F, 0x8F, 0xC0, 0x00, 0x00, 0x80, 0x3F,
                                    0x04, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    },
                                },
                            },
                        };
                        shit.EdgeScales = new RealQuaternion(3f, -4f, 2f, -4f);
                        shit.EdgeOffsets = new RealQuaternion(-2f, 4f, 0f, 10f);
                        shit.PlasmaScales = new RealQuaternion(5f, 4f, -45f, 60f);
                        shit.DepthFadeParameters = new RealQuaternion(4f, 0f, 20f, 20f);
                        CacheContext.Serialize(stream, tag, shit);
                    }
                }
            }
        }
    }
}