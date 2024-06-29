using System.Collections.Generic;
using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Shaders;
using TagTool.Tags.Definitions;
using System;
using TagTool.Cache.Resources;
using TagTool.Geometry;
using TagTool.Tags;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags
{
    public class objects_eldewrito_reforge_hemisphere_2x2x05_render_model : TagFile
    {
        public objects_eldewrito_reforge_hemisphere_2x2x05_render_model(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<RenderModel>($@"objects\eldewrito\reforge\hemisphere_2x2x05");
            var mode = CacheContext.Deserialize<RenderModel>(Stream, tag);
            mode.Name = CacheContext.StringTable.GetOrAddString($@"Hemisphere_2x2x05");
            mode.Flags = RenderModel.FlagsValue.None;
            mode.Version = 0;
            mode.Checksum = 0;
            mode.Regions = new List<RenderModel.Region>
            {
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"default"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"default"),
                            MeshIndex = 0,
                            MeshCount = 1,
                            Unknown8 = 0,
                            UnknownC = 0,
                            Unknown10 = 0,
                            Unknown14 = 0,
                        },
                    },
                },
            };
            mode.Unknown18 = 0;
            mode.InstanceStartingMeshIndex = 0;
            mode.InstancePlacements = null;
            mode.NodeListChecksum = 0;
            mode.Nodes = new List<RenderModel.Node>
            {
                new RenderModel.Node
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"street_cone"),
                    ParentNode = -1,
                    FirstChildNode = -1,
                    NextSiblingNode = -1,
                    Flags = RenderModel.NodeFlags.None,
                    DefaultTranslation = new RealPoint3d(0f, 0f, 0f),
                    DefaultRotation = new RealQuaternion(0f, 0f, 0f, -1f),
                    DefaultScale = 1f,
                    InverseForward = new RealVector3d(1f, 0f, 0f),
                    InverseLeft = new RealVector3d(0f, 1f, 0f),
                    InverseUp = new RealVector3d(0f, 0f, 1f),
                    InversePosition = new RealPoint3d(0f, 0f, 0f),
                    DistanceFromParent = 0f,
                },
            };
            mode.MarkerGroups = new List<RenderModel.MarkerGroup>
            {
                new RenderModel.MarkerGroup
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"sandbox_magnet"),
                    Markers = new List<RenderModel.MarkerGroup.Marker>
                    {
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 0,
                            Flags = 0,
                            Translation = new RealPoint3d(0f, 0.891f, -0.1702f),
                            Rotation = new RealQuaternion(0f, 0f, 0f, 0f),
                            Scale = 0f,
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 0,
                            Flags = 0,
                            Translation = new RealPoint3d(0.341f, 0.8232f, -0.1702f),
                            Rotation = new RealQuaternion(0f, 0f, 0f, 0f),
                            Scale = 0f,
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 0,
                            Flags = 0,
                            Translation = new RealPoint3d(0.63f, 0.63f, -0.1702f),
                            Rotation = new RealQuaternion(0f, 0f, 0f, 0f),
                            Scale = 0f,
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 0,
                            Flags = 0,
                            Translation = new RealPoint3d(0.8232f, 0.341f, -0.1702f),
                            Rotation = new RealQuaternion(0f, 0f, 0f, 0f),
                            Scale = 0f,
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 0,
                            Flags = 0,
                            Translation = new RealPoint3d(0.891f, 0f, -0.1702f),
                            Rotation = new RealQuaternion(0f, 0f, 0f, 0f),
                            Scale = 0f,
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 0,
                            Flags = 0,
                            Translation = new RealPoint3d(0.8232f, -0.341f, -0.1702f),
                            Rotation = new RealQuaternion(0f, 0f, 0f, 0f),
                            Scale = 0f,
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 0,
                            Flags = 0,
                            Translation = new RealPoint3d(0.63f, -0.63f, -0.1702f),
                            Rotation = new RealQuaternion(0f, 0f, 0f, 0f),
                            Scale = 0f,
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 0,
                            Flags = 0,
                            Translation = new RealPoint3d(0.341f, -0.8232f, -0.1702f),
                            Rotation = new RealQuaternion(0f, 0f, 0f, 0f),
                            Scale = 0f,
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 0,
                            Flags = 0,
                            Translation = new RealPoint3d(0f, -0.891f, -0.1702f),
                            Rotation = new RealQuaternion(0f, 0f, 0f, 0f),
                            Scale = 0f,
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 0,
                            Flags = 0,
                            Translation = new RealPoint3d(-0.341f, -0.8232f, -0.1702f),
                            Rotation = new RealQuaternion(0f, 0f, 0f, 0f),
                            Scale = 0f,
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 0,
                            Flags = 0,
                            Translation = new RealPoint3d(-0.63f, -0.63f, -0.1702f),
                            Rotation = new RealQuaternion(0f, 0f, 0f, 0f),
                            Scale = 0f,
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 0,
                            Flags = 0,
                            Translation = new RealPoint3d(-0.8232f, -0.341f, -0.1702f),
                            Rotation = new RealQuaternion(0f, 0f, 0f, 0f),
                            Scale = 0f,
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 0,
                            Flags = 0,
                            Translation = new RealPoint3d(-0.891f, 0f, -0.1702f),
                            Rotation = new RealQuaternion(0f, 0f, 0f, 0f),
                            Scale = 0f,
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 0,
                            Flags = 0,
                            Translation = new RealPoint3d(-0.8232f, 0.341f, -0.1702f),
                            Rotation = new RealQuaternion(0f, 0f, 0f, 0f),
                            Scale = 0f,
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 0,
                            Flags = 0,
                            Translation = new RealPoint3d(-0.63f, 0.63f, -0.1702f),
                            Rotation = new RealQuaternion(0f, 0f, 0f, 0f),
                            Scale = 0f,
                        },
                        new RenderModel.MarkerGroup.Marker
                        {
                            RegionIndex = -1,
                            PermutationIndex = -1,
                            NodeIndex = 0,
                            Flags = 0,
                            Translation = new RealPoint3d(-0.341f, 0.8232f, -0.1702f),
                            Rotation = new RealQuaternion(0f, 0f, 0f, 0f),
                            Scale = 0f,
                        },
                    },
                },
            };
            mode.Materials = new List<RenderMaterial>
            {
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\checker"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_edge\shaders\fr_floor_flat_02"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\chill\shaders\riverworld_metal"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\riverworld\shaders\riverworld_metal"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\riverworld\shaders\forerunner\panel_generic_simple"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\ui\mainmenu\shaders\unsc_panel_04"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_edge\shaders\fr_floor_03"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\solo\100_citadel\shaders\panel_floor_ele_corner"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\solo\100_citadel\shaders\panel_mast_c"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\chill\shaders\chill_wall02bpp"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\chill\shaders\panel_plate_ext"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\riverworld\shaders\forerunner\waste_panel_wall_diagonal"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\turf_vinyl_panels_a"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\deadlock\shaders\deadlock_concrete_pillar_a"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\cyberdyne\shaders\cyberdyne_wall_concrete_sections_universal"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\zanzibar\shaders\zan_concrete_wall_e"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_edge\shaders\fr_panel_02"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\turf_concrete_01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\cyberdyne\shaders\cyberdyne_wall_concrete_a"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\cyberdyne\shaders\cyberdyne_wall_concrete_interior_a"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\shrine\shaders\stone_broken_tiling"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\deadlock\shaders\deadlock_grate_a"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<ShaderTerrain>($@"objects\eldewrito\reforge\shaders\wood"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\zanzibar\shaders\metal_floorplate_a_01r"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\chill\shaders\panel_door_trimmove"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\shrine\shaders\copper"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\salvation\shaders\sal_floor_tile"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\brick00"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\concr00"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\concr01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone00"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone02"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone05"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone06"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone19"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone20"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone21"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone26"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone27"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone29"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone30"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone33"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\dirts01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\dirts02"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\grass00"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\grass01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\grass02"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\grass04"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\grass06"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\grass07"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\grass09"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\sands00"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\sands01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\sands02"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\snows00"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\snows01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\snows02"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\snows03"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone04"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone08"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone09"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone10"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone11"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone12"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone13"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone14"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone15"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone16"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\terrain\stone17"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\guardian\shaders\guardian_metal_d"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\guardian\shaders\guardian_outside_ring_a"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\guardian\shaders\panel_wall_vert"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\guardian\shaders\guardian_railings_a"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\salvation\shaders\panel_door_trim_ext"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\levels\multi\shrine\shaders\beh_floor_metal"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\unsc_outpost_05"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_edge\shaders\fr_floor_metal_01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\guardian\shaders\guardian_wall_a"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\guardian\shaders\guardian_panel_simple"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\guardian\shaders\waste_panel_wall_inset"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\cyberdyne\shaders\cyberdyne_tower_floor"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\unsc_outpost_02"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\turf_metal_02"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\turf_rollup_01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\cyberdyne\shaders\cyberdyne_wall_metal_b"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\solo\040_voi\shaders\metals\metal_panel_garage_door"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\zanzibar\shaders\metal_floorplate_b_01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\solo\020_base\shaders\hb_metal_floor_panel_02"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\cyberdyne\shaders\cyberdyne_tower_ramp"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\dlc\bunkerworld\shaders\bunker_metal_ramp"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\solo\040_voi\shaders\concrete\concrete_d_bottomtrim"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\dlc\bunkerworld\shaders\bunker_door_frame"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\dlc\bunkerworld\shaders\bunker_plate_ext_2side"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\zanzibar\shaders\metal_floorplate_a_01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\solo\040_voi\shaders\metals\metal_steel_grey"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\unsc_panel_indus_04"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\unsc_ship_15"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\unsc_metal_diam_01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\solo\020_base\shaders\hb_metal_painted_red"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\zanzibar\shaders\zan_concrete_wall_a"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\chill\shaders\chill_metalflat"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\chill\shaders\chill_wall02pp"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\dlc\docks\shaders\concrete\concrete_floor_smooth"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\zanzibar\shaders\zan_seawallpave"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_avalanche\shaders\avalache_rock_05_objects"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<ShaderTerrain>($@"levels\multi\s3d_avalanche\shaders\av_cliff_blend_02"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<ShaderTerrain>($@"levels\multi\shrine\shaders\laminate_tiling_clean"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_reactor\shaders\reactor_rock_02"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\solo\010_jungle\shaders\foliage\tree_bark_smooth"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\guardian\shaders\guardian_mancannon_finger_a"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\guardian\shaders\guardian_centercircle_tech"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\vehicles\shade\shaders\shade_damage"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\rgb\metal"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\rgb\matte"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<ShaderHalogram>($@"objects\eldewrito\reforge\shaders\invisible"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\metal_shell_1"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_edge\shaders\fr_dish_01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_edge\shaders\fr_temple_panel_08"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_edge\shaders\fr_metal_panel_01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\unsc_garage_01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\unsc_panel_single_02"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\unsc_metal_floor_06"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\unsc_panel_07"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\unsc_ship_05"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\unsc_metal_floor_06_a"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\unsc_metal_ramp_01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\unsc_metal_02"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\unsc_panel_indus_05"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\unsc_panel_single_01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<ShaderHalogram>($@"levels\multi\s3d_turf\shaders\f_field_03_holo"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_edge\shaders\edge_serv_glow_01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_edge\shaders\edge_fr_glow_01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\material_144"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\cyberdyne\shaders\cyberdyne_roof_glass_a"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\dlc\sidewinder\shaders\side_hall_glass03"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\dlc\bunkerworld\shaders\bunker_glass_techwindow"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_avalanche\shaders\cyber_glass_front"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\material_144"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\shared\shaders\multi\mp_metal"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\turf_metal_01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\unsc_ship_02"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\turf_metal_07"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\turf_metal_01_b"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\turf_metal_01_c"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_edge\shaders\fr_floor_flat_01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_edge\shaders\fr_metal_02"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_edge\shaders\fr_panel_strip_02"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\solo\020_base\shaders\hb_concrete_wall"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\s3d_turf\shaders\unsc_panel_simple_01"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\cyberdyne\shaders\cyberdyne_grate_drain"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\cyberdyne\shaders\cyberdyne_catwalk_railings"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\deadlock\shaders\deadlock_fence_chainlink"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\dlc\bunkerworld\shaders\bunker_plate_edge"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\dlc\bunkerworld\shaders\bunker_plate_strip"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\dlc\bunkerworld\shaders\bunker_plate_wall"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<ShaderHalogram>($@"ms30\objects\eldewrito\reforge\shaders\glass"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<ShaderHalogram>($@"ms30\objects\eldewrito\reforge\shaders\glass_emissive"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\hex_shield"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\rgb\carpet"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<ShaderHalogram>($@"objects\eldewrito\reforge\shaders\rgb\vr"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\rgb\metal_siding"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\rgb\insulation"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<ShaderHalogram>($@"objects\eldewrito\reforge\shaders\rgb\frothy_liquid"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\water"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\magma"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\solo\110_hc\shaders\metals\fs_cov_purple"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\snowbound\shaders\cable_wrap"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\cov_conduit"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\cov_reactor"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\cov_tech_minimal"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\cov_floor_decorative"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\dlc\midship\shaders\midship_strip_c_purple"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\covenant_glass"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"objects\eldewrito\reforge\shaders\covenant_glass_opaque"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\dlc\lockout\shaders\metal_wall_white"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\dlc\lockout\shaders\metal_wall_white_flat"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\solo\070_waste\shaders\panel_floor_waste"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
                new RenderMaterial
                {
                    RenderMethod = GetCachedTag<Shader>($@"levels\multi\guardian\shaders\guardian_floor_a"),
                    Properties = null,
                    ImportedMaterialIndex = 0,
                    BreakableSurfaceIndex = 0,
                },
            };

            CacheContext.Serialize(Stream, tag, mode);
        }
    }
}
