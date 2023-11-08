using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_characters_masterchief_mp_masterchief_mp_masterchief_render_model : TagFile
    {
        public objects_characters_masterchief_mp_masterchief_mp_masterchief_render_model(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<RenderModel>($@"objects\characters\masterchief\mp_masterchief\mp_masterchief");
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
                            Translation = new RealPoint3d(0.2256153f, 0.02499999f, 3.1647E-08f),
                            Rotation = new RealQuaternion(-0.4999993f, -0.5000007f, -0.499999f, -0.500001f),
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
                            NodeIndex = 6,
                            Translation = new RealPoint3d(0.01780689f, 0.009790983f, -2.3507E-08f),
                            Rotation = new RealQuaternion(-0.5001993f, -0.4998007f, -0.4998012f, -0.5001987f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"drop"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 15,
                            Translation = new RealPoint3d(0.05088969f, 0.1441084f, -0.001047887f),
                            Rotation = new RealQuaternion(-0.5495249f, -0.4449972f, -0.4449971f, -0.5495248f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"drop_left"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 15,
                            Translation = new RealPoint3d(0.04859191f, 0.1433616f, 0.06496456f),
                            Rotation = new RealQuaternion(-0.8191351f, -0.3679075f, -0.1038428f, -0.4276432f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"drop_right"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 15,
                            Translation = new RealPoint3d(0.04859189f, 0.1433616f, -0.05503542f),
                            Rotation = new RealQuaternion(-0.4276438f, -0.1038427f, -0.3679074f, -0.8191347f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"flaming_ninja"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = 2,
                            PermutationIndex = 7,
                            NodeIndex = 15,
                            Translation = new RealPoint3d(0.04645691f, -0.001428992f, -2.56131E-07f),
                            Rotation = new RealQuaternion(-0.7014564f, -0.08921872f, -0.08921821f, -0.701455f),
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
                            NodeIndex = 15,
                            Translation = new RealPoint3d(0.0333191f, 0.02236564f, 0.04090516f),
                            Rotation = new RealQuaternion(-0.5495252f, -0.4449978f, -0.4449966f, -0.5495244f),
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
                            NodeIndex = 15,
                            Translation = new RealPoint3d(0.01209911f, 0.07083707f, 0.04035656f),
                            Rotation = new RealQuaternion(8.692001E-07f, -3.852001E-07f, 0.1124112f, -0.9936619f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"fx_fire_large"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 6,
                            Translation = new RealPoint3d(0.03613762f, -0.01401526f, -4.2829E-08f),
                            Rotation = new RealQuaternion(-0.7071068f, 0.0002818518f, 0.0002811412f, -0.7071067f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"fx_fire_small"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 16,
                            Translation = new RealPoint3d(0.04492829f, 1.0014E-08f, 1.5096E-08f),
                            Rotation = new RealQuaternion(-2.35E-08f, -0.7071068f, -5.1E-09f, -0.7071068f),
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 14,
                            Translation = new RealPoint3d(0.0486424f, -1.817E-09f, 3.181E-09f),
                            Rotation = new RealQuaternion(2.05E-08f, 0.7071068f, -8.600001E-09f, -0.7071068f),
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 2,
                            Translation = new RealPoint3d(0.06909298f, 0.0234273f, 4.41E-10f),
                            Rotation = new RealQuaternion(2.74E-08f, 1.96E-08f, -0.8433914f, -0.5372997f),
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 1,
                            Translation = new RealPoint3d(0.07730807f, 0.02193797f, 3.566E-09f),
                            Rotation = new RealQuaternion(3E-09f, -1.95E-08f, -0.8433914f, -0.5372997f),
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
                            NodeIndex = 20,
                            Translation = new RealPoint3d(0.04903455f, -0.01425574f, 0.31518f),
                            Rotation = new RealQuaternion(-0.01682179f, -0.08228035f, 0.08493669f, -0.9928408f),
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
                            NodeIndex = 15,
                            Translation = new RealPoint3d(0.03952014f, 0.004048229f, -2.16344E-07f),
                            Rotation = new RealQuaternion(-0.5000001f, -0.500001f, -0.4999999f, -0.4999991f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"infection"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 6,
                            Translation = new RealPoint3d(0.1250004f, -0.03892635f, -3.04E-09f),
                            Rotation = new RealQuaternion(0.460381f, -0.5367017f, -0.536702f, 0.4603821f),
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
                            NodeIndex = 7,
                            Translation = new RealPoint3d(0.0650959f, 0.0535178f, -2.97284E-05f),
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
                            NodeIndex = 19,
                            Translation = new RealPoint3d(0.03858634f, 0.00105648f, 0.0003977104f),
                            Rotation = new RealQuaternion(-0.9935211f, 0.08508001f, -0.07361341f, -0.01607794f),
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
                            NodeIndex = 8,
                            Translation = new RealPoint3d(0.0650896f, 0.05359615f, 0.001218119f),
                            Rotation = new RealQuaternion(0.4999996f, 0.5000005f, -0.4999995f, -0.5000004f),
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
                            NodeIndex = 20,
                            Translation = new RealPoint3d(0.04653192f, 0.004329915f, -0.004439032f),
                            Rotation = new RealQuaternion(-0.01608014f, -0.07361318f, 0.08508017f, -0.993521f),
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
                            Translation = new RealPoint3d(-0.0807003f, 0.002331884f, -1.82502E-07f),
                            Rotation = new RealQuaternion(-0.7070788f, 0.00617107f, 0.006170041f, -0.707081f),
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
                            NodeIndex = 15,
                            Translation = new RealPoint3d(0.0464699f, -0.001431749f, -2.47422E-07f),
                            Rotation = new RealQuaternion(-0.5495253f, -0.4449978f, -0.4449965f, -0.5495244f),
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
                            NodeIndex = 4,
                            Translation = new RealPoint3d(0.1183028f, -0.04396264f, -0.007325392f),
                            Rotation = new RealQuaternion(0.4199603f, 0.5823396f, -0.4588009f, -0.5234653f),
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 1,
                            Translation = new RealPoint3d(0.02853655f, -0.005506811f, 0.006877084f),
                            Rotation = new RealQuaternion(0.5428495f, 0.4698938f, -0.3258288f, -0.6151015f),
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
                            NodeIndex = 5,
                            Translation = new RealPoint3d(0.1183878f, -0.04178371f, 0.0167066f),
                            Rotation = new RealQuaternion(0.5234631f, 0.458801f, -0.5823394f, -0.4199631f),
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 2,
                            Translation = new RealPoint3d(0.03023799f, -0.002421244f, 0.008280649f),
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
                            NodeIndex = 6,
                            Translation = new RealPoint3d(0.07480907f, -0.01913913f, -2.48414E-07f),
                            Rotation = new RealQuaternion(-0.4958187f, -0.5041474f, -0.5041464f, -0.4958182f),
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            Translation = new RealPoint3d(0.01451706f, 0.0002747109f, 2.11837E-07f),
                            Rotation = new RealQuaternion(-0.4999989f, -0.5000013f, -0.4999987f, -0.5000011f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"visor_reflection"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 15,
                            Translation = new RealPoint3d(0.05549071f, 0.08352325f, 7.918E-08f),
                            Rotation = new RealQuaternion(8.726E-07f, -3.777E-07f, 0.1041319f, -0.9945635f),
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
                            NodeIndex = 6,
                            Translation = new RealPoint3d(0.07424942f, -0.0798725f, -4.2322E-08f),
                            Rotation = new RealQuaternion(-7.653001E-07f, -0.7071064f, -0.7071073f, -1.798E-07f),
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
                            NodeIndex = 2,
                            Translation = new RealPoint3d(0.05742481f, 0.01492793f, 0.06013717f),
                            Rotation = new RealQuaternion(-0.9954459f, 0.0008543489f, 0.007366084f, -0.09503939f),
                        },
                    },
                },
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetStringId($@"fx_light_flares"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 15,
                            Translation = new RealPoint3d(0.03185329f, 0.0252718f, 0.04073446f),
                            Rotation = new RealQuaternion(-0.6029078f, -0.3694634f, -0.3694622f, -0.6029069f),
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 15,
                            Translation = new RealPoint3d(0.03185299f, 0.0252718f, -0.04072997f),
                            Rotation = new RealQuaternion(-0.6029078f, -0.3694634f, -0.3694622f, -0.6029069f),
                        },
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, mode);
        }
    }
}
