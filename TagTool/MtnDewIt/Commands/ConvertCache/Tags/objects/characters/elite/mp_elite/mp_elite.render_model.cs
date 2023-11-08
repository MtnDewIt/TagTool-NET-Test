using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_characters_elite_mp_elite_mp_elite_render_model : TagFile
    {
        public objects_characters_elite_mp_elite_mp_elite_render_model(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<RenderModel>($@"objects\characters\elite\mp_elite\mp_elite");
            var mode = CacheContext.Deserialize<RenderModel>(Stream, tag);
            mode.MarkerGroups = new List<RenderModel.MarkerGroup>
            {
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"autoaim_melee"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            Translation = new RealPoint3d(0.1799752f, 0.01038557f, 9.7043E-08f),
                            Rotation = new RealQuaternion(-0.4999992f, -0.5000003f, -0.4999991f, -0.5000013f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"body"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(0.03574277f, -0.007496504f, -3.4553E-08f),
                            Rotation = new RealQuaternion(-0.5215242f, -0.4775066f, -0.4775071f, -0.5215237f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"fp_body_cam"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 4,
                            Translation = new RealPoint3d(0.1974106f, 0.03221082f, 0.04035645f),
                            Rotation = new RealQuaternion(-0.5215237f, -0.4775071f, -0.4775068f, -0.521524f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"hammer_detonation"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 38,
                            Translation = new RealPoint3d(0.04903453f, -0.01425571f, 0.31518f),
                            Rotation = new RealQuaternion(-0.01682179f, -0.08228037f, 0.08493669f, -0.9928408f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"head"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 19,
                            Translation = new RealPoint3d(0.02065074f, 0.04270457f, -1.9281E-07f),
                            Rotation = new RealQuaternion(-0.6743803f, -0.2126316f, -0.2126309f, -0.6743791f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"infection_back"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(0.1031279f, -0.06536943f, 0.05846697f),
                            Rotation = new RealQuaternion(-0.696095f, 0.3177367f, -0.5142785f, 0.3873147f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"infection_front"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(0.05538742f, 0.05927382f, 0.02797265f),
                            Rotation = new RealQuaternion(-0.5418564f, -0.4543036f, -0.4543041f, -0.541856f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"left_foot"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 13,
                            Translation = new RealPoint3d(0.1162547f, 0.05098096f, 0.001612802f),
                            Rotation = new RealQuaternion(0.4999996f, 0.5000005f, -0.4999995f, -0.5000004f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"left_hand"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 21,
                            Translation = new RealPoint3d(0.06256428f, 0.01001831f, -0.002007456f),
                            Rotation = new RealQuaternion(-0.9960304f, -0.08898152f, -0.001657302f, 0.001715935f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"left_hand_elite"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 21,
                            Translation = new RealPoint3d(0.06251547f, 0.01000951f, -0.002007639f),
                            Rotation = new RealQuaternion(-0.9960304f, -0.08898152f, -0.001657302f, 0.001715935f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"melee"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 38,
                            Translation = new RealPoint3d(-0.2086015f, 0.05588131f, 0.0008496161f),
                            Rotation = new RealQuaternion(-0.2791958f, 0.03222927f, 0.1281927f, -0.951093f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"right_foot"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 14,
                            Translation = new RealPoint3d(0.1162547f, 0.05098068f, -0.001177573f),
                            Rotation = new RealQuaternion(0.4999995f, 0.5000006f, -0.4999995f, -0.5000004f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"right_hand"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 38,
                            Translation = new RealPoint3d(0.05852192f, 0.009384068f, 0.003518221f),
                            Rotation = new RealQuaternion(0.001851678f, -0.00150143f, -0.001833381f, -0.9999955f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"right_hand_elite"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 38,
                            Translation = new RealPoint3d(0.05852192f, 0.009384068f, 0.003518221f),
                            Rotation = new RealQuaternion(0.001851678f, -0.00150143f, -0.001833381f, -0.9999955f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"shield_recharge"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            Translation = new RealPoint3d(-0.09023538f, 0.009551163f, -1.41033E-07f),
                            Rotation = new RealQuaternion(-0.7071056f, 8.308E-07f, 1.596E-07f, -0.707108f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"target_head"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 19,
                            Translation = new RealPoint3d(0.01701837f, 0.01884919f, -4.07824E-07f),
                            Rotation = new RealQuaternion(-0.6743802f, -0.2126316f, -0.2126309f, -0.6743791f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"target_leg_l"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 5,
                            Translation = new RealPoint3d(0.1262321f, 0.02450612f, 0.005931422f),
                            Rotation = new RealQuaternion(0.4199602f, 0.5823395f, -0.4588009f, -0.5234652f),
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 1,
                            Translation = new RealPoint3d(0.02853655f, -0.005506793f, 0.006877085f),
                            Rotation = new RealQuaternion(0.5428495f, 0.4698938f, -0.3258288f, -0.6151016f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"target_leg_r"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 6,
                            Translation = new RealPoint3d(0.1263171f, 0.02668504f, 0.00344985f),
                            Rotation = new RealQuaternion(0.5234631f, 0.458801f, -0.5823394f, -0.419963f),
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 3,
                            Translation = new RealPoint3d(0.03023802f, -0.002421259f, 0.008280637f),
                            Rotation = new RealQuaternion(0.6150993f, 0.3258293f, -0.4698931f, -0.5428523f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"target_main"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(0.1283156f, -0.007224265f, -4.5666E-08f),
                            Rotation = new RealQuaternion(-0.5215242f, -0.4775065f, -0.4775071f, -0.5215238f),
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            Translation = new RealPoint3d(0.004739819f, 0.008236676f, -5.2052E-08f),
                            Rotation = new RealQuaternion(-0.4999993f, -0.5000002f, -0.4999992f, -0.5000014f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_l_arm01"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 15,
                            Translation = new RealPoint3d(0.02690487f, -0.02371224f, -0.01066976f),
                            Rotation = new RealQuaternion(-0.6377019f, 0.0462249f, -0.08799204f, -0.7638436f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_l_arm02"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 15,
                            Translation = new RealPoint3d(0.06833898f, 0.04643075f, -0.0007777766f),
                            Rotation = new RealQuaternion(0.703701f, -0.2662126f, -0.2044371f, -0.6262119f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_l_arm03"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 15,
                            Translation = new RealPoint3d(0.1107497f, -0.01633057f, 0.02171804f),
                            Rotation = new RealQuaternion(-0.3548906f, -0.06070545f, 0.2570218f, -0.8968319f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_l_thigh01"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 1,
                            Translation = new RealPoint3d(0.01962783f, 0.01549957f, -0.0320834f),
                            Rotation = new RealQuaternion(-0.940122f, 0.1744003f, 0.1106316f, 0.2711384f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_l_thigh02"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 4,
                            Translation = new RealPoint3d(-0.05706913f, -0.04478194f, 0.0491551f),
                            Rotation = new RealQuaternion(0.02752986f, -0.2919843f, -0.9560007f, -0.007069346f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_neck01"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 11,
                            Translation = new RealPoint3d(0.0304031f, -0.01852239f, -0.0263923f),
                            Rotation = new RealQuaternion(-0.7801918f, 0.5694979f, -0.2012519f, -0.1626976f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_neck02"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 11,
                            Translation = new RealPoint3d(0.01437855f, -0.03735514f, 0.01858724f),
                            Rotation = new RealQuaternion(-0.5786288f, 0.1161039f, -0.4026208f, -0.6997179f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_r_arm01"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 17,
                            Translation = new RealPoint3d(-0.01156176f, -0.02033655f, 0.004039865f),
                            Rotation = new RealQuaternion(-0.7067726f, 0.2379951f, -0.6652032f, 0.03654424f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_r_arm02"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 17,
                            Translation = new RealPoint3d(-0.01481211f, 0.02051404f, 0.005928042f),
                            Rotation = new RealQuaternion(0.6084152f, 0.4271791f, -0.02982261f, -0.6681763f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_r_arm03"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(0.04056877f, -0.03876587f, -0.1121205f),
                            Rotation = new RealQuaternion(-0.01175296f, 0.6494383f, -0.7576989f, 0.06312039f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_r_arm04"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 17,
                            Translation = new RealPoint3d(0.0765755f, -0.02796047f, -0.01276978f),
                            Rotation = new RealQuaternion(-0.9326941f, 0.01988128f, -0.2514276f, 0.2578191f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_r_arm05"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 17,
                            Translation = new RealPoint3d(0.0793365f, 0.04458105f, -0.01441297f),
                            Rotation = new RealQuaternion(-0.04670968f, 0.08736467f, -0.005214368f, -0.9950671f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_r_arm06"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 17,
                            Translation = new RealPoint3d(0.1210528f, 0.008050691f, -0.02251989f),
                            Rotation = new RealQuaternion(0.3826088f, -0.00126087f, -0.1092994f, -0.9174218f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_r_thigh01"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 1,
                            Translation = new RealPoint3d(-0.0163238f, 0.001268711f, 0.1159575f),
                            Rotation = new RealQuaternion(-0.06471356f, 0.6105553f, 0.250048f, -0.7486724f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_r_thigh02"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 4,
                            Translation = new RealPoint3d(-0.05697641f, -0.04479004f, -0.05662575f),
                            Rotation = new RealQuaternion(-0.3871388f, 0.3298104f, -0.8428503f, 0.1759316f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_r_thigh03"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 4,
                            Translation = new RealPoint3d(-0.05465327f, -0.01847751f, -0.07354491f),
                            Rotation = new RealQuaternion(0.4553881f, -0.8691748f, 0.1794832f, -0.07030415f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_back01"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(0.1357917f, -0.05742816f, -0.05739209f),
                            Rotation = new RealQuaternion(0.08567107f, -0.8234234f, 0.441122f, -0.3464765f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_back02"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(0.1187678f, -0.0749002f, 0.05937659f),
                            Rotation = new RealQuaternion(-0.2935609f, 0.5472244f, -0.7804837f, -0.07220077f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_back03"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(0.04307916f, -0.09597619f, 0.04374966f),
                            Rotation = new RealQuaternion(-0.5293249f, 0.4768791f, -0.4258696f, -0.5577065f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_back04"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 4,
                            Translation = new RealPoint3d(0.07787018f, -0.1042351f, 0.004674229f),
                            Rotation = new RealQuaternion(0.1064251f, -0.6730598f, 0.6576449f, 0.321197f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_back05"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(0.0728678f, -0.1158325f, -0.005598636f),
                            Rotation = new RealQuaternion(-0.04149873f, -0.7289374f, 0.654032f, -0.1979147f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_back06"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(-0.02042438f, -0.08158603f, -0.001679986f),
                            Rotation = new RealQuaternion(-0.155919f, -0.7523875f, 0.6365291f, -0.06658117f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_back07"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 4,
                            Translation = new RealPoint3d(0.01417869f, -0.06811558f, 0.02913354f),
                            Rotation = new RealQuaternion(-0.1547724f, -0.2853118f, -0.9437906f, -0.0624662f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_back08"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(0.01990321f, -0.07601078f, 0.06768318f),
                            Rotation = new RealQuaternion(0.1648929f, 0.6120907f, -0.6866899f, -0.3558263f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_back09"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 4,
                            Translation = new RealPoint3d(0.02663497f, -0.07514262f, -0.02470897f),
                            Rotation = new RealQuaternion(-0.5251009f, -0.7160732f, 0.4573574f, -0.04829649f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_front01"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(0.05011288f, 0.08248291f, -0.001432333f),
                            Rotation = new RealQuaternion(0.7435758f, 0.05047482f, 0.1591866f, -0.647462f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_front02"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(0.0275171f, 0.07999691f, -0.004159951f),
                            Rotation = new RealQuaternion(-0.2608015f, -0.6730676f, -0.5929909f, 0.3568256f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_front03"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(-0.02561804f, 0.06192196f, -0.01568683f),
                            Rotation = new RealQuaternion(0.2130293f, -0.7644876f, -0.5944196f, -0.1297793f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_front04"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(-0.0236889f, 0.06175156f, 0.02502768f),
                            Rotation = new RealQuaternion(-0.01012471f, -0.7217582f, -0.6801273f, 0.128022f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"weapon_back"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(0.08590946f, -0.1335677f, -1.41056E-07f),
                            Rotation = new RealQuaternion(-0.03112468f, -0.7064212f, -0.7064217f, -0.03112472f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"weapon_equip"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            Translation = new RealPoint3d(0.04339714f, -0.04264744f, -0.060889f),
                            Rotation = new RealQuaternion(-0.6718104f, 0.2042295f, 0.6270984f, -0.3372071f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"weapon_grenade_frag"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(0.06213973f, 0.05512109f, 0.05804935f),
                            Rotation = new RealQuaternion(-0.3297831f, -0.3652966f, -0.8174217f, -0.2993715f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"weapon_grenade_plasma"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(0.04718842f, 0.06805268f, 0.03158877f),
                            Rotation = new RealQuaternion(-0.2177138f, -0.6190065f, -0.7322162f, -0.1824587f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"weapon_thigh"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 3,
                            Translation = new RealPoint3d(0.1116038f, 0.02611289f, 0.05950713f),
                            Rotation = new RealQuaternion(-0.9942661f, -0.01218014f, 0.01586942f, -0.1050465f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"flashlight"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 19,
                            Translation = new RealPoint3d(-0.05970598f, -0.01428081f, 0.08475997f),
                            Rotation = new RealQuaternion(-0.6743807f, -0.2126319f, -0.2126303f, -0.6743788f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"fx_light_flare"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 7,
                            Translation = new RealPoint3d(0.1422199f, 0.01072503f, 0.08512984f),
                            Rotation = new RealQuaternion(-0.5215244f, -0.477507f, -0.4775064f, -0.5215238f),
                        },
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, mode);
        }
    }
}
