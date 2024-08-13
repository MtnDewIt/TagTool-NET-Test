using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Commands;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags
{
    public class levels_ui_mainmenu_mainmenu_h3_scenario : TagFile
    {
        public levels_ui_mainmenu_mainmenu_h3_scenario(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\ui\mainmenu\mainmenu");
            var scnr = CacheContext.Deserialize<Scenario>(Stream, tag);
            scnr.MapType = ScenarioMapType.MainMenu;
            scnr.Flags = ScenarioFlags.H3Compatibility;
            scnr.CampaignId = -1;
            scnr.MapId = 270735729;
            scnr.StructureBsps = new List<Scenario.StructureBspBlock>
            {
                new Scenario.StructureBspBlock
                {
                    StructureBsp = GetCachedTag<ScenarioStructureBsp>($@"levels\ui\mainmenu\bsp_menu"),
                    SizeClass = Scenario.StructureBspBlock.ScenarioStructureSizeEnum._512x51215Meg,
                    DefaultSkyIndex = -1,
                    InstanceFadeStartPixels = 10,
                    InstanceFadeEndPixels = 5,
                    Wind = GetCachedTag<Wind>($@"levels\ui\mainmenu\main_menu"),
                },
                new Scenario.StructureBspBlock
                {
                    StructureBsp = GetCachedTag<ScenarioStructureBsp>($@"levels\ui\mainmenu\bsp_lobbies"),
                    SizeClass = Scenario.StructureBspBlock.ScenarioStructureSizeEnum._512x51215Meg,
                    DefaultSkyIndex = -1,
                },
            };
            scnr.SkyReferences = new List<Scenario.SkyReference>
            {
                new Scenario.SkyReference
                {
                    SkyObject = GetCachedTag<Scenery>($@"levels\ui\mainmenu\sky\menu_sky"),
                    ActiveBsps = Scenario.BspShortFlags.Bsp0,
                },
            };
            scnr.ZoneSetPvs = new List<Scenario.ZoneSetPvsBlock>
            {
                new Scenario.ZoneSetPvsBlock
                {
                    StructureBspMask = Scenario.BspFlags.Bsp0 | Scenario.BspFlags.Bsp1,
                    Flags = Scenario.ZoneSetPvsBlock.ZoneSetPvsFlags.Bit3,
                    BspChecksums = new List<Scenario.ZoneSetPvsBlock.BspChecksum>
                    {
                        new Scenario.ZoneSetPvsBlock.BspChecksum
                        {
                            Checksum = 286986511,
                        },
                        new Scenario.ZoneSetPvsBlock.BspChecksum
                        {
                            Checksum = 521338881,
                        },
                    },
                    StructureBspPvs = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock>
                    {
                        new Scenario.ZoneSetPvsBlock.BspPvsBlock
                        {
                            ClusterPvs = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock>
                            {
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock
                                {
                                    ClusterPvsBitVectors = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock>
                                    {
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1,
                                                },
                                            },
                                        },
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                },
                                            },
                                        },
                                    },
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock
                                {
                                    ClusterPvsBitVectors = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock>
                                    {
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1,
                                                },
                                            },
                                        },
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                },
                                            },
                                        },
                                    },
                                },
                            },
                            ClusterPvsDoorsClosed = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock>
                            {
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock
                                {
                                    ClusterPvsBitVectors = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock>
                                    {
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1,
                                                },
                                            },
                                        },
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                },
                                            },
                                        },
                                    },
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock
                                {
                                    ClusterPvsBitVectors = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock>
                                    {
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1,
                                                },
                                            },
                                        },
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                },
                                            },
                                        },
                                    },
                                },
                            },
                            AttachedSkyIndices = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock>
                            {
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                            },
                            VisibleSkyIndices = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock>
                            {
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                            },
                            ClusterAudioBitvector = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                            {
                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                {
                                },
                            },
                            ClusterMappings = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.BspSeamClusterMapping>
                            {
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.BspSeamClusterMapping
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.BspSeamClusterMapping
                                {
                                },
                            },
                        },
                        new Scenario.ZoneSetPvsBlock.BspPvsBlock
                        {
                            ClusterPvs = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock>
                            {
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock
                                {
                                    ClusterPvsBitVectors = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock>
                                    {
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                },
                                            },
                                        },
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0,
                                                },
                                            },
                                        },
                                    },
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock
                                {
                                    ClusterPvsBitVectors = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock>
                                    {
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                },
                                            },
                                        },
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1,
                                                },
                                            },
                                        },
                                    },
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock
                                {
                                    ClusterPvsBitVectors = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock>
                                    {
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                },
                                            },
                                        },
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit2,
                                                },
                                            },
                                        },
                                    },
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock
                                {
                                    ClusterPvsBitVectors = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock>
                                    {
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                },
                                            },
                                        },
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3,
                                                },
                                            },
                                        },
                                    },
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock
                                {
                                    ClusterPvsBitVectors = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock>
                                    {
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                },
                                            },
                                        },
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit4,
                                                },
                                            },
                                        },
                                    },
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock
                                {
                                    ClusterPvsBitVectors = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock>
                                    {
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                },
                                            },
                                        },
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5,
                                                },
                                            },
                                        },
                                    },
                                },
                            },
                            ClusterPvsDoorsClosed = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock>
                            {
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock
                                {
                                    ClusterPvsBitVectors = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock>
                                    {
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                },
                                            },
                                        },
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0,
                                                },
                                            },
                                        },
                                    },
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock
                                {
                                    ClusterPvsBitVectors = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock>
                                    {
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                },
                                            },
                                        },
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1,
                                                },
                                            },
                                        },
                                    },
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock
                                {
                                    ClusterPvsBitVectors = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock>
                                    {
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                },
                                            },
                                        },
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit2,
                                                },
                                            },
                                        },
                                    },
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock
                                {
                                    ClusterPvsBitVectors = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock>
                                    {
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                },
                                            },
                                        },
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3,
                                                },
                                            },
                                        },
                                    },
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock
                                {
                                    ClusterPvsBitVectors = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock>
                                    {
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                },
                                            },
                                        },
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit4,
                                                },
                                            },
                                        },
                                    },
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock
                                {
                                    ClusterPvsBitVectors = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock>
                                    {
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                },
                                            },
                                        },
                                        new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                                        {
                                            Bits = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                                            {
                                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                                {
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5,
                                                },
                                            },
                                        },
                                    },
                                },
                            },
                            AttachedSkyIndices = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock>
                            {
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                    SkyIndex = -1,
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                    SkyIndex = -1,
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                    SkyIndex = -1,
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                    SkyIndex = -1,
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                    SkyIndex = -1,
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                    SkyIndex = -1,
                                },
                            },
                            VisibleSkyIndices = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock>
                            {
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                    SkyIndex = -1,
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                    SkyIndex = -1,
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                    SkyIndex = -1,
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                    SkyIndex = -1,
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                    SkyIndex = -1,
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                    SkyIndex = -1,
                                },
                            },
                            ClusterAudioBitvector = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                            {
                                new Scenario.ZoneSetPvsBlock.BitVectorDword
                                {
                                },
                            },
                            ClusterMappings = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.BspSeamClusterMapping>
                            {
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.BspSeamClusterMapping
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.BspSeamClusterMapping
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.BspSeamClusterMapping
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.BspSeamClusterMapping
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.BspSeamClusterMapping
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.BspSeamClusterMapping
                                {
                                },
                            },
                        },
                    },
                    PortaldeviceMapping = new List<Scenario.ZoneSetPvsBlock.PortalDeviceMappingBlock>
                    {
                        new Scenario.ZoneSetPvsBlock.PortalDeviceMappingBlock
                        {
                        },
                        new Scenario.ZoneSetPvsBlock.PortalDeviceMappingBlock
                        {
                        },
                    },
                },
            };
            scnr.ZoneSetAudibility = new List<Scenario.ZoneSetAudibilityBlock>
            {
                new Scenario.ZoneSetAudibilityBlock
                {
                    RoomCount = 8,
                    RoomDistanceBounds = new Bounds<float>(3.4028235E+38f, 0f),
                    AiDeafeningPas = new List<Scenario.ZoneSetAudibilityBlock.AiDeafeningPa>
                    {
                        new Scenario.ZoneSetAudibilityBlock.AiDeafeningPa
                        {
                            EncodedData = 268435454,
                        },
                    },
                    RoomDistances = new List<Scenario.ZoneSetAudibilityBlock.RoomDistance>
                    {
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -1,
                        },
                    },
                    GamePortalToDoorOccluderMappings = new List<Scenario.ZoneSetAudibilityBlock.GamePortalToDoorOccluderMapping>
                    {
                        new Scenario.ZoneSetAudibilityBlock.GamePortalToDoorOccluderMapping
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.GamePortalToDoorOccluderMapping
                        {
                        },
                    },
                    BspClusterToRoomBoundsMappings = new List<Scenario.ZoneSetAudibilityBlock.BspClusterToRoomBoundsMapping>
                    {
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomBoundsMapping
                        {
                            RoomIndexCount = 2,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomBoundsMapping
                        {
                            FirstRoomIndex = 2,
                            RoomIndexCount = 6,
                        },
                    },
                    BspClusterToRoomIndices = new List<Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex>
                    {
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 2,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 3,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 4,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 5,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 6,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 7,
                        },
                    },
                },
            };
            scnr.ZoneSets = new List<Scenario.ZoneSet>
            {
                new Scenario.ZoneSet
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"set_menu"),
                    Bsps = Scenario.BspFlags.Bsp0 | Scenario.BspFlags.Bsp1,
                    HintPreviousZoneSet = -1,
                },
            };
            scnr.ObjectNames = new List<Scenario.ObjectName>
            {
                new Scenario.ObjectName
                {
                    Name = $@"sky",
                    PlacementIndex = -1,
                },
                new Scenario.ObjectName
                {
                    Name = $@"cruiser1",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 2,
                },
                new Scenario.ObjectName
                {
                    Name = $@"cruiser2",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 3,
                },
                new Scenario.ObjectName
                {
                    Name = $@"cruiser3",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 4,
                },
                new Scenario.ObjectName
                {
                    Name = $@"clouds_ark",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 5,
                },
                new Scenario.ObjectName
                {
                    Name = $@"matchmaking_earth",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 7,
                },
                new Scenario.ObjectName
                {
                    Name = $@"editor_monitor",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 8,
                },
                new Scenario.ObjectName
                {
                    Name = $@"editor_warthog",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 6,
                },
                new Scenario.ObjectName
                {
                    Name = $@"earth",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 9,
                },
                new Scenario.ObjectName
                {
                    Name = $@"ark",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 10,
                },
                new Scenario.ObjectName
                {
                    Name = $@"forerunner_ship",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 11,
                },
                new Scenario.ObjectName
                {
                    Name = $@"cruiser4",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 12,
                },
                new Scenario.ObjectName
                {
                    Name = $@"banshee1",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 13,
                },
                new Scenario.ObjectName
                {
                    Name = $@"banshee2",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 14,
                },
                new Scenario.ObjectName
                {
                    Name = $@"elite_appearance",
                    PlacementIndex = 1,
                },
                new Scenario.ObjectName
                {
                    Name = $@"spartan_appearance",
                    PlacementIndex = 0,
                },
                new Scenario.ObjectName
                {
                    Name = $@"campaign_aribter",
                    PlacementIndex = 3,
                },
                new Scenario.ObjectName
                {
                    Name = $@"campaign_chief",
                    PlacementIndex = 2,
                },
                new Scenario.ObjectName
                {
                    Name = $@"custom_elite_01",
                    PlacementIndex = 5,
                },
                new Scenario.ObjectName
                {
                    Name = $@"custom_chief_01",
                    PlacementIndex = 4,
                },
                new Scenario.ObjectName
                {
                    Name = $@"appearance_ar",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 0,
                },
                new Scenario.ObjectName
                {
                    Name = $@"appearance_pr",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 1,
                },
                new Scenario.ObjectName
                {
                    Name = $@"campaign_ar",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 2,
                },
                new Scenario.ObjectName
                {
                    Name = $@"campaign_pr",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 3,
                },
                new Scenario.ObjectName
                {
                    Name = $@"custom_ar_01",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 4,
                },
                new Scenario.ObjectName
                {
                    Name = $@"custom_pr_01",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 5,
                },
                new Scenario.ObjectName
                {
                    Name = $@"custom_pr_02",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 6,
                },
                new Scenario.ObjectName
                {
                    Name = $@"custom_flag",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 7,
                },
                new Scenario.ObjectName
                {
                    Name = $@"custom_light",
                    PlacementIndex = -1,
                },
                new Scenario.ObjectName
                {
                    Name = $@"campaign_light",
                    PlacementIndex = -1,
                },
                new Scenario.ObjectName
                {
                    Name = $@"editor_light",
                    PlacementIndex = -1,
                },
                new Scenario.ObjectName
                {
                    Name = $@"storm",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Machine,
                    },
                    PlacementIndex = 0,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_phantom",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 15,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_light",
                    PlacementIndex = -1,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_odst_recon_01",
                    PlacementIndex = 6,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_odst_recon_02",
                    PlacementIndex = 7,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_automag_2",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 17,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_ssmg_1",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 18,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_ssmg_2",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 19,
                },
            };
            scnr.Scenery = new List<Scenario.SceneryInstance>
            {
                new Scenario.SceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(-45.5f, -9.9951f, -35f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(90f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(3112, 77),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 2,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(-45.5f, -19.976f, -35f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(90f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(3112, 78),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 2,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 3,
                    NameIndex = 1,
                    Position = new RealPoint3d(464.8235f, 136.6842f, -279.9998f),
                    ManualBspFlags = 3,
                    UniqueHandle = new DatumHandle(27376, 81),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    BspPolicy = Scenario.ScenarioInstance.BspPolicyValue.ManualBspIndex,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = 0,
                        ParentMarker = CacheContext.StringTable.GetOrAddString($@"ark"),
                    },
                    CanAttachToBspFlags = 3,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 3,
                    NameIndex = 2,
                    Position = new RealPoint3d(464.8235f, 136.6842f, -279.9998f),
                    ManualBspFlags = 3,
                    UniqueHandle = new DatumHandle(27380, 82),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = 0,
                        ParentMarker = CacheContext.StringTable.GetOrAddString($@"ark"),
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 1,
                    NameIndex = 3,
                    PlacementFlags = new Scenario.ObjectPlacementFlags()
                    { 
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically,
                    },
                    Position = new RealPoint3d(464.8235f, 136.6842f, -279.9998f),
                    UniqueHandle = new DatumHandle(27380, 83),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = 0,
                        ParentMarker = CacheContext.StringTable.GetOrAddString($@"ship_1"),
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 2,
                    NameIndex = 4,
                    Position = new RealPoint3d(452.4061f, 53.32013f, -279.9997f),
                    UniqueHandle = new DatumHandle(27392, 84),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = 0,
                        ParentMarker = CacheContext.StringTable.GetOrAddString($@"clouds_ark"),
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 5,
                    NameIndex = 7,
                    PlacementFlags = new Scenario.ObjectPlacementFlags()
                    { 
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically,
                    },
                    Position = new RealPoint3d(5.117751f, 12.88167f, -1.350703f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(36.05838f), Angle.FromDegrees(-11.26188f), Angle.FromDegrees(8.477079f)),
                    Scale = 1f,
                    UniqueHandle = new DatumHandle(35136, 86),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = 5,
                    Position = new RealPoint3d(-30.08521f, -55.62581f, -32.66299f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(35212, 87),
                    OriginBspIndex = 1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 2,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 6,
                    NameIndex = 6,
                    PlacementFlags = new Scenario.ObjectPlacementFlags()
                    { 
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically,
                    },
                    Position = new RealPoint3d(5.49919f, 13.35025f, -0.64973f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-29.09379f), Angle.FromDegrees(-14.37994f), Angle.FromDegrees(7.868167f)),
                    UniqueHandle = new DatumHandle(35572, 88),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = 8,
                    Position = new RealPoint3d(-109.6182f, -230.9343f, 250.3744f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(134.7043f), Angle.FromDegrees(-46.78879f), Angle.FromDegrees(-33.98746f)),
                    UniqueHandle = new DatumHandle(37648, 91),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 7,
                    NameIndex = 9,
                    Position = new RealPoint3d(464.8235f, 136.6842f, -279.9998f),
                    ManualBspFlags = 3,
                    UniqueHandle = new DatumHandle(39252, 93),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    BspPolicy = Scenario.ScenarioInstance.BspPolicyValue.ManualBspIndex,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = 0,
                        ParentMarker = CacheContext.StringTable.GetOrAddString($@"ark"),
                    },
                    CanAttachToBspFlags = 3,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 8,
                    NameIndex = 10,
                    Position = new RealPoint3d(1000f, -267.791f, -380.6325f),
                    Scale = 1.75f,
                    UniqueHandle = new DatumHandle(40940, 100),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = 0,
                        ParentMarker = CacheContext.StringTable.GetOrAddString($@"forerunner_ship"),
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 1,
                    NameIndex = 11,
                    Position = new RealPoint3d(249.5646f, 21.54015f, 180.405f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(90.27715f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(42588, 101),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 9,
                    NameIndex = 12,
                    Position = new RealPoint3d(160.7892f, 282.5293f, -249.9998f),
                    UniqueHandle = new DatumHandle(43576, 103),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 9,
                    NameIndex = 13,
                    Position = new RealPoint3d(134.8648f, 220.8092f, -249.9998f),
                    UniqueHandle = new DatumHandle(43576, 104),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 10,
                    NameIndex = 32,
                    PlacementFlags = new Scenario.ObjectPlacementFlags()
                    { 
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically,
                    },
                    Position = new RealPoint3d(0f, 0f, 10.147f),
                    UniqueHandle = new DatumHandle(0, 20),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Variant = CacheContext.StringTable.GetOrAddString($@"enemy_no_turret"),
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 11,
                    NameIndex = 36,
                    PlacementFlags = new Scenario.ObjectPlacementFlags()
                    { 
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically,
                    },
                    UniqueHandle = new DatumHandle(0, 24),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 12,
                    NameIndex = 37,
                    PlacementFlags = new Scenario.ObjectPlacementFlags()
                    { 
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically,
                    },
                    UniqueHandle = new DatumHandle(0, 25),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 12,
                    NameIndex = 38,
                    PlacementFlags = new Scenario.ObjectPlacementFlags()
                    { 
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically,
                    },
                    UniqueHandle = new DatumHandle(0, 26),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
            };
            scnr.SceneryPalette = new List<Scenario.ScenarioPaletteEntry>
            {
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\matte_appearance\matte_appearance"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\cov_cruiser_cheap\cov_cruiser_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\skies\clouds_ark\clouds_ark"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\cov_cruiser\cov_cruiser_digging"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\matchmaking_earth\matchmaking_earth"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\warthog_cheap\warthog_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\monitor_cheap\monitor_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\ark_cheap\ark_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\forerunner_ship_cheap\forerunner_ship"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\banshee_cheap\banshee_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\vehicles\phantom\hirez_cinematic_phantom"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\weapons\pistol\automag\automag"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\weapons\rifle\smg_silenced\smg_silenced"),
                },
            };
            scnr.Bipeds = new List<Scenario.BipedInstance>
            {
                new Scenario.BipedInstance
                {
                    PaletteIndex = 0,
                    NameIndex = 15,
                    PlacementFlags = new Scenario.ObjectPlacementFlags
                    {
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.CreateAtRest,
                    },
                    Position = new RealPoint3d(-45f, -10f, -34.99976f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(42040, 26),
                    OriginBspIndex = -1,
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 2,
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 6,
                    NameIndex = 14,
                    PlacementFlags = new Scenario.ObjectPlacementFlags
                    {
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.CreateAtRest,
                    },
                    Position = new RealPoint3d(-45f, -10f, -34.99976f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(42040, 27),
                    OriginBspIndex = -1,
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 2,
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 2,
                    NameIndex = 17,
                    PlacementFlags = new Scenario.ObjectPlacementFlags
                    {
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.CreateAtRest,
                    },
                    Position = new RealPoint3d(-3.065369f, -4.330749f, -1.151731f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(66.6044f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(35124, 36),
                    OriginBspIndex = -1,
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 1,
                    NameIndex = 16,
                    PlacementFlags = new Scenario.ObjectPlacementFlags
                    {
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.CreateAtRest,
                    },
                    Position = new RealPoint3d(-3.682616f, -4.602558f, -1.16243f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(52.07759f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(35124, 37),
                    OriginBspIndex = -1,
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 3,
                    NameIndex = 19,
                    PlacementFlags = new Scenario.ObjectPlacementFlags()
                    { 
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically,
                    },
                    Position = new RealPoint3d(-7.401524f, -1.076341f, -1.460741f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-37.79264f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(35128, 41),
                    OriginBspIndex = -1,
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 5,
                    NameIndex = 18,
                    PlacementFlags = new Scenario.ObjectPlacementFlags()
                    { 
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically,
                    },
                    Position = new RealPoint3d(-7.560285f, -0.6917072f, -1.520749f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-116.8475f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(35128, 38),
                    OriginBspIndex = -1,
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 4,
                    NameIndex = 34,
                    PlacementFlags = new Scenario.ObjectPlacementFlags
                    {
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.CreateAtRest,
                    },
                    Position = new RealPoint3d(-0.123f, -2.991f, 11.551f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-104.257f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(0, 22),
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Variant = CacheContext.StringTable.GetOrAddString($@"mainmenu_odst01"),
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 4,
                    NameIndex = 35,
                    PlacementFlags = new Scenario.ObjectPlacementFlags
                    {
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.CreateAtRest,
                    },
                    Position = new RealPoint3d(-1.988f, -0.989f, 11.828f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-90f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(0, 23),
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Variant = CacheContext.StringTable.GetOrAddString($@"mainmenu_odst01"),
                },
            };
            scnr.BipedPalette = new List<Scenario.ScenarioPaletteEntry>
            {
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Biped>($@"objects\characters\masterchief\mp_masterchief\mp_masterchief"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Biped>($@"objects\characters\dervish\dervish"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Biped>($@"objects\characters\masterchief\masterchief"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Biped>($@"levels\ui\mainmenu\objects\spartan_cheap\spartan_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Biped>($@"levels\ui\mainmenu\objects\odst_recon_cheap\odst_recon_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Biped>($@"levels\ui\mainmenu\objects\elite_cheap\elite_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Biped>($@"objects\characters\elite\mp_elite\mp_elite"),
                },
            };
            scnr.Weapons = new List<Scenario.WeaponInstance>
            {
                new Scenario.WeaponInstance
                {
                    NameIndex = 20,
                    Position = new RealPoint3d(-45.0263f, -10.732314f, -34.956886f),
                    UniqueHandle = new DatumHandle(27096, 6),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 2,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.WeaponInstance
                {
                    PaletteIndex = 1,
                    NameIndex = 21,
                    Position = new RealPoint3d(-44.78546f, -19.013159f, -34.61306f),
                    UniqueHandle = new DatumHandle(27096, 7),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 2,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.WeaponInstance
                {
                    NameIndex = 22,
                    PlacementFlags = new Scenario.ObjectPlacementFlags
                    {
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.StoreOrientations,
                    },
                    Position = new RealPoint3d(22.070538f, 1.816689f, -1.3384286f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(5.5847373f), Angle.FromDegrees(-11.504697f), Angle.FromDegrees(-102.32624f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 4,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 15,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(38276, 8),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.WeaponInstance
                {
                    PaletteIndex = 1,
                    NameIndex = 23,
                    PlacementFlags = new Scenario.ObjectPlacementFlags
                    {
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.StoreOrientations,
                    },
                    Position = new RealPoint3d(21.767262f, 1.8162398f, -1.2815572f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(11.831498f), Angle.FromDegrees(-13.738079f), Angle.FromDegrees(-94.58431f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 5,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 3,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 25995,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 19947,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(38276, 9),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.WeaponInstance
                {
                    NameIndex = 24,
                    PlacementFlags = new Scenario.ObjectPlacementFlags
                    {
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.StoreOrientations,
                    },
                    Position = new RealPoint3d(16.769732f, 2.359245f, -1.4936146f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-3.3159308f), Angle.FromDegrees(-24.418438f), Angle.FromDegrees(-88.92974f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 4,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 15,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(38276, 10),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.WeaponInstance
                {
                    PaletteIndex = 1,
                    NameIndex = 25,
                    PlacementFlags = new Scenario.ObjectPlacementFlags
                    {
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.StoreOrientations,
                    },
                    Position = new RealPoint3d(16.849157f, 2.9978907f, -1.4754308f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-2.5053535f), Angle.FromDegrees(-3.9313567f), Angle.FromDegrees(-93.00097f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 5,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 3,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 25995,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 19947,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(38276, 12),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.WeaponInstance
                {
                    PaletteIndex = 1,
                    NameIndex = 26,
                    PlacementFlags = new Scenario.ObjectPlacementFlags
                    {
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.StoreOrientations,
                    },
                    Position = new RealPoint3d(16.852026f, 3.4099126f, -1.4845734f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-1.5335854f), Angle.FromDegrees(-2.4621933f), Angle.FromDegrees(-90.44899f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 5,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 3,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 25995,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 19947,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(38276, 13),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.WeaponInstance
                {
                    PaletteIndex = 2,
                    NameIndex = 27,
                    PlacementFlags = new Scenario.ObjectPlacementFlags
                    {
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.CreateAtRest,
                    },
                    Position = new RealPoint3d(-6.9697638f, -0.36104357f, -1.2290297f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-24.174362f), Angle.FromDegrees(-10.390579f), Angle.FromDegrees(4.6285143f)),
                    UniqueHandle = new DatumHandle(40592, 14),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
            };
            scnr.WeaponPalette = new List<Scenario.ScenarioPaletteEntry>
            {
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\multiplayer\flag\flag"),
                },
            };
            scnr.Machines = new List<Scenario.MachineInstance>
            {
                new Scenario.MachineInstance
                {
                    NameIndex = 31,
                    Position = new RealPoint3d(500f, -49.6586f, -122.152f),
                    UniqueHandle = new DatumHandle(9144, 6),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Machine,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = 0,
                        ParentMarker = CacheContext.StringTable.GetOrAddString($@"storm"),
                    },
                    CanAttachToBspFlags = 1,
                    PowerGroup = -1,
                    PositionGroup = -1,
                },
            };
            scnr.MachinePalette = new List<Scenario.ScenarioPaletteEntry>
            {
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<DeviceMachine>($@"objects\skies\storm\storm_main_menu"),
                },
            };
            scnr.EffectScenery = new List<Scenario.EffectSceneryInstance>
            {
                new Scenario.EffectSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(25.567232f, 0.41305646f, -0.9508322f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(89.769936f), Angle.FromDegrees(-15.625842f), Angle.FromDegrees(-88.14818f)),
                    UniqueHandle = new DatumHandle(42868, 2),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.EffectScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                },
                new Scenario.EffectSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(14.468092f, -0.47144568f, -1.551068f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(90.42518f), Angle.FromDegrees(1.7714343f), Angle.FromDegrees(-91.342186f)),
                    UniqueHandle = new DatumHandle(42876, 3),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.EffectScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                },
                new Scenario.EffectSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(20.648605f, -1.4166644f, -1.018593f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(89.15839f), Angle.FromDegrees(1.7714341f), Angle.FromDegrees(-91.342186f)),
                    UniqueHandle = new DatumHandle(42876, 4),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.EffectScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                },
                new Scenario.EffectSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(9.607014f, 2.8281364f, -1.6489729f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(87.85665f), Angle.FromDegrees(11.558924f), Angle.FromDegrees(-91.48823f)),
                    UniqueHandle = new DatumHandle(42876, 5),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.EffectScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                },
            };
            scnr.EffectSceneryPalette = new List<Scenario.ScenarioPaletteEntry>
            {
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<EffectScenery>($@"levels\ui\mainmenu\fx\ground_dust\ground_dust"),
                },
            };
            scnr.LightVolumes = new List<Scenario.LightVolumeInstance>
            {
                new Scenario.LightVolumeInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(-44.84623f, -10.35312f, -34.05933f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(2.24619E-08f), Angle.FromDegrees(11.43129f), Angle.FromDegrees(-149.7608f)),
                    OriginBspIndex = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    Type2 = Scenario.LightVolumeInstance.TypeValue2.Projective,
                    X = -45.04442f,
                    Y = -9.859501f,
                    Z = -34.90612f,
                    Width = 1f,
                    HeightScale = 1f,
                    FieldOfView = Angle.FromDegrees(60f),
                    FalloffDistance = 0.4414063f,
                    CutoffDistance = 0.9999984f,
                },
                new Scenario.LightVolumeInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(-44.65631f, -20.28198f, -33.87003f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-2.370878E-08f), Angle.FromDegrees(17.19552f), Angle.FromDegrees(-153.8557f)),
                    OriginBspIndex = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    Type2 = Scenario.LightVolumeInstance.TypeValue2.Projective,
                    X = -44.95195f,
                    Y = -19.86103f,
                    Z = -34.72758f,
                    Width = 1f,
                    HeightScale = 1f,
                    FieldOfView = Angle.FromDegrees(60f),
                    FalloffDistance = 0.4414063f,
                    CutoffDistance = 0.9999979f,
                },
                new Scenario.LightVolumeInstance
                {
                    PaletteIndex = 1,
                    NameIndex = -1,
                    Position = new RealPoint3d(-45.11104f, -19.56704f, -34.76589f),
                    OriginBspIndex = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    X = -45.11104f,
                    Y = -19.56706f,
                    Z = -30.76589f,
                    Width = 1f,
                    HeightScale = 1f,
                    FalloffDistance = 0.4414063f,
                    CutoffDistance = 4f,
                },
                new Scenario.LightVolumeInstance
                {
                    PaletteIndex = 1,
                    NameIndex = -1,
                    Position = new RealPoint3d(-45.06665f, -9.585737f, -34.64215f),
                    OriginBspIndex = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    X = -45.06665f,
                    Y = -9.585737f,
                    Z = -33.44215f,
                    Width = 1f,
                    HeightScale = 1f,
                    FalloffDistance = 0.4414063f,
                    CutoffDistance = 4f,
                },
                new Scenario.LightVolumeInstance
                {
                    PaletteIndex = 2,
                    NameIndex = 28,
                    PlacementFlags = new Scenario.ObjectPlacementFlags()
                    { 
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically,
                    },
                    Position = new RealPoint3d(-6.858373f, 0.09113751f, -1.063934f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(63.09137f), Angle.FromDegrees(17.67388f), Angle.FromDegrees(92.07263f)),
                    OriginBspIndex = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    Type2 = Scenario.LightVolumeInstance.TypeValue2.Projective,
                    Flags = 1,
                    X = -7.494576f,
                    Y = -0.9573539f,
                    Z = -1.009141f,
                    Width = 1.839451f,
                    HeightScale = 1f,
                    FieldOfView = Angle.FromDegrees(75.35489f),
                    FalloffDistance = 0.6302913f,
                    CutoffDistance = 1.189611f,
                },
                new Scenario.LightVolumeInstance
                {
                    PaletteIndex = 3,
                    NameIndex = 29,
                    PlacementFlags = new Scenario.ObjectPlacementFlags()
                    { 
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically,
                    },
                    Position = new RealPoint3d(-3.634852f, -3.120619f, -0.9906012f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(7.247242f), Angle.FromDegrees(-10.34807f), Angle.FromDegrees(60.06319f)),
                    OriginBspIndex = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    Type2 = Scenario.LightVolumeInstance.TypeValue2.Projective,
                    Flags = 1,
                    X = -2.945851f,
                    Y = -6.390334f,
                    Z = 0.8923973f,
                    Width = 0.015625f,
                    HeightScale = 1f,
                    FieldOfView = Angle.FromDegrees(125.9875f),
                    FalloffDistance = 0.4414063f,
                    CutoffDistance = 3.835549f,
                },
                new Scenario.LightVolumeInstance
                {
                    PaletteIndex = 5,
                    NameIndex = 30,
                    Position = new RealPoint3d(6.8576f, 12.80801f, 0.6717849f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(3.833187f), Angle.FromDegrees(48.52651f), Angle.FromDegrees(179.0844f)),
                    OriginBspIndex = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    Type2 = Scenario.LightVolumeInstance.TypeValue2.Projective,
                    Flags = 1,
                    X = 4.706595f,
                    Y = 12.08864f,
                    Z = -0.4163572f,
                    Width = 0.015625f,
                    HeightScale = 1f,
                    FieldOfView = Angle.FromDegrees(111.5836f),
                    FalloffDistance = 0.4414063f,
                    CutoffDistance = 2.339835f,
                },
                new Scenario.LightVolumeInstance
                {
                    PaletteIndex = 6,
                    NameIndex = 33,
                    PlacementFlags = new Scenario.ObjectPlacementFlags()
                    { 
                        Flags = Scenario.ObjectPlacementFlags.ObjectLocationPlacementFlags.NotAutomatically,
                    },
                    Position = new RealPoint3d(-2.028954f, 0.04164451f, 12.14188f),
                    UniqueHandle = new DatumHandle(0, 21),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.None,
                    },
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    Type2 = Scenario.LightVolumeInstance.TypeValue2.Projective,
                    Flags = 1,
                    X = -2.028954f,
                    Y = 0.04164451f,
                    Z = 12.14188f,
                    Width = 1f,
                    HeightScale = 1f,
                },
            };
            scnr.LightVolumePalette = new List<Scenario.ScenarioPaletteEntry>
            {
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Light>($@"levels\ui\mainmenu\lights\appearance"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Light>($@"levels\ui\mainmenu\lights\appearance_fill"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Light>($@"levels\ui\mainmenu\lights\custom_games"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Light>($@"levels\ui\mainmenu\lights\campaign"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Light>($@"levels\ui\mainmenu\lights\theater"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Light>($@"levels\ui\mainmenu\lights\editor"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Light>($@"objects\vehicles\phantom\fx\running\cinematic_gravlift"),
                },
            };
            scnr.PlayerStartingProfile = new List<Scenario.PlayerStartingProfileBlock>
            {
                new Scenario.PlayerStartingProfileBlock
                {
                    Name = $@"start_assault",
                    PrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                    PrimaryRoundsLoaded = 32,
                    PrimaryRoundsTotal = 108,
                    StartingFragGrenadeCount = 2,
                },
            };
            scnr.PlayerStartingLocations = new List<Scenario.PlayerStartingLocation>
            {
                new Scenario.PlayerStartingLocation
                {
                    Position = new RealPoint3d(13.9289f, 3.14119f, -1.48594f),
                    Facing = new RealEulerAngles2d(Angle.FromDegrees(25.5837f), Angle.FromDegrees(0f)),
                },
                new Scenario.PlayerStartingLocation
                {
                    Position = new RealPoint3d(27.309156f, 23.457037f, 9.778686f),
                    Facing = new RealEulerAngles2d(Angle.FromDegrees(25.583675f), Angle.FromDegrees(0f)),
                },
                new Scenario.PlayerStartingLocation
                {
                    Position = new RealPoint3d(27.260944f, 25.121008f, 5.663933f),
                    Facing = new RealEulerAngles2d(Angle.FromDegrees(26.95836f), Angle.FromDegrees(0f)),
                },
            };
            scnr.PlayerStartingProfile = new List<Scenario.PlayerStartingProfileBlock>
            {
                new Scenario.PlayerStartingProfileBlock
                {
                    Name = $@"start_assault",
                    PrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                    PrimaryRoundsLoaded = 32,
                    PrimaryRoundsTotal = 108,
                    StartingFragGrenadeCount = 2,
                },
            };
            scnr.PlayerStartingLocations = new List<Scenario.PlayerStartingLocation>
            {
                new Scenario.PlayerStartingLocation
                {
                    Position = new RealPoint3d(13.9289f, 3.14119f, -1.48594f),
                    Facing = new RealEulerAngles2d(Angle.FromDegrees(25.5837f), Angle.FromDegrees(0f)),
                },
                new Scenario.PlayerStartingLocation
                {
                    Position = new RealPoint3d(27.309156f, 23.457037f, 9.778686f),
                    Facing = new RealEulerAngles2d(Angle.FromDegrees(25.583675f), Angle.FromDegrees(0f)),
                },
                new Scenario.PlayerStartingLocation
                {
                    Position = new RealPoint3d(27.260944f, 25.121008f, 5.663933f),
                    Facing = new RealEulerAngles2d(Angle.FromDegrees(26.95836f), Angle.FromDegrees(0f)),
                },
            };
            scnr.Decals = new List<Scenario.Decal>
            {
                new Scenario.Decal
                {
                    Rotation = new RealQuaternion(0.2873967f, 0.14006045f, -0.62745064f, 0.7099944f),
                    Position = new RealPoint3d(23.955486f, -1.8850793f, -1.078431f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    Rotation = new RealQuaternion(0.24540044f, 0.31640744f, -0.57534444f, 0.7131926f),
                    Position = new RealPoint3d(19.805977f, -2.4901903f, -1.4575313f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    Rotation = new RealQuaternion(0.28942978f, -0.14731182f, 0.76829255f, 0.5515942f),
                    Position = new RealPoint3d(22.236567f, -2.66454f, -1.1926802f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    Rotation = new RealQuaternion(-0.33891636f, 0.28081945f, 0.5236686f, 0.7294158f),
                    Position = new RealPoint3d(20.048168f, -7.282121f, -1.301463f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    Rotation = new RealQuaternion(-0.26158157f, 0.33087254f, 0.56231415f, 0.71126735f),
                    Position = new RealPoint3d(22.317474f, -8.0994215f, -1.263986f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.00675528f, -0.04946691f, 0.4645976f, 0.8841134f),
                    Position = new RealPoint3d(27.57511f, 5.1579165f, -0.80129313f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    Rotation = new RealQuaternion(-0.26158157f, 0.33087254f, 0.56231415f, 0.71126735f),
                    Position = new RealPoint3d(24.973654f, -8.6629925f, -1.3054909f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.106356226f, 0.03703624f, -0.84619415f, 0.5208379f),
                    Position = new RealPoint3d(26.575212f, 5.825367f, -0.83437574f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.03453042f, -0.11781674f, 0.60210425f, 0.78892165f),
                    Position = new RealPoint3d(23.419485f, 7.2884464f, -1.0276847f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.03366938f, 0.010126941f, -0.8511923f, 0.52367544f),
                    Position = new RealPoint3d(31.065115f, 7.7194934f, -0.4316462f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.041526478f, 0.07097155f, 0.50330716f, 0.86018634f),
                    Position = new RealPoint3d(29.926193f, 8.3846f, -0.4583235f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.04851866f, 0.027867403f, 0.46877962f, 0.8815414f),
                    Position = new RealPoint3d(28.81765f, 9.053642f, -0.5013205f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.036351755f, 0.026760248f, 0.5038113f, 0.8626335f),
                    Position = new RealPoint3d(27.68764f, 9.746147f, -0.538818f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.019386318f, -0.00016911057f, 0.5608291f, 0.8277046f),
                    Position = new RealPoint3d(26.57592f, 10.333483f, -0.5796502f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.0008421819f, -0.020005483f, -0.8333728f, 0.5523485f),
                    Position = new RealPoint3d(25.540466f, 10.745887f, -0.6164308f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.034710415f, -0.12118052f, 0.61518604f, 0.77823955f),
                    Position = new RealPoint3d(22.070158f, 7.6528306f, -1.1502542f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.046980318f, -0.011462231f, -0.78296894f, 0.6201783f),
                    Position = new RealPoint3d(24.410686f, 11.152069f, -0.67912704f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.009247544f, -0.049638975f, -0.79456073f, 0.6050813f),
                    Position = new RealPoint3d(23.169832f, 11.49438f, -0.77357465f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.073187605f, 0.013921693f, -0.8362913f, 0.5432004f),
                    Position = new RealPoint3d(25.508814f, 6.3230944f, -0.9012744f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.11462334f, 0.036804926f, -0.8260807f, 0.55054295f),
                    Position = new RealPoint3d(24.592955f, 6.769432f, -0.9558265f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    Rotation = new RealQuaternion(-0.29198417f, 0.4262246f, 0.36991528f, 0.77216613f),
                    Position = new RealPoint3d(27.41296f, -9.95449f, -0.93764365f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.045350645f, -0.030604653f, -0.7560354f, 0.6522401f),
                    Position = new RealPoint3d(20.751219f, 7.9047656f, -1.2783186f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.02273839f, -0.041347902f, -0.70251787f, 0.71009994f),
                    Position = new RealPoint3d(19.38889f, 8.004389f, -1.4117352f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.016198592f, -0.040098175f, -0.702801f, 0.71007085f),
                    Position = new RealPoint3d(18.043644f, 8.007076f, -1.5402566f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.013841647f, -0.039721802f, -0.62755406f, 0.77743584f),
                    Position = new RealPoint3d(16.725714f, 7.8406935f, -1.6454686f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.0016910722f, -0.04825266f, -0.5756974f, 0.8162361f),
                    Position = new RealPoint3d(15.460336f, 7.472858f, -1.7299752f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.0020311913f, -0.05648844f, -0.7416625f, 0.66838735f),
                    Position = new RealPoint3d(21.875952f, 11.770434f, -0.86717904f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.0040271524f, -0.05522601f, -0.73481244f, 0.6760063f),
                    Position = new RealPoint3d(20.563019f, 11.972646f, -0.97817326f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.006763041f, -0.061202146f, -0.724645f, 0.68636584f),
                    Position = new RealPoint3d(19.201836f, 12.090767f, -1.1071922f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.010265177f, -0.060659215f, -0.6835558f, 0.7273009f),
                    Position = new RealPoint3d(17.900461f, 12.067371f, -1.2227886f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.0063845646f, -0.055769097f, -0.6544897f, 0.7539843f),
                    Position = new RealPoint3d(16.556042f, 11.96894f, -1.3467162f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.00954915f, -0.040393185f, -0.53006464f, 0.8469408f),
                    Position = new RealPoint3d(14.177249f, 6.976414f, -1.785779f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.009814747f, -0.040309858f, -0.5309307f, 0.84639907f),
                    Position = new RealPoint3d(12.988467f, 6.329856f, -1.816283f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.030807663f, -0.06665486f, 0.7624761f, 0.64283603f),
                    Position = new RealPoint3d(15.194056f, 11.8607235f, -1.4664627f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.054232664f, -0.08511805f, 0.79373324f, 0.5998345f),
                    Position = new RealPoint3d(13.845495f, 11.591665f, -1.5509269f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.04777335f, -0.06275224f, 0.81417406f, 0.5752395f),
                    Position = new RealPoint3d(12.570675f, 11.163748f, -1.616632f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.0661446f, 0.037006404f, 0.83248794f, 0.54883486f),
                    Position = new RealPoint3d(11.731902f, 5.745363f, -1.822795f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.042995933f, 0.005819864f, 0.8123758f, 0.58151793f),
                    Position = new RealPoint3d(10.496983f, 5.245972f, -1.8714294f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.031423945f, -0.008291203f, 0.8081088f, 0.58813614f),
                    Position = new RealPoint3d(9.266729f, 4.8402357f, -1.9338086f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.010157206f, -0.040845126f, -0.61922675f, 0.7840834f),
                    Position = new RealPoint3d(8.01746f, 4.4778337f, -2.0047948f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.032614984f, -0.024376925f, 0.833538f, 0.5509596f),
                    Position = new RealPoint3d(11.361833f, 10.6093445f, -1.7132015f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.032484367f, -0.024550721f, 0.8305846f, 0.55540216f),
                    Position = new RealPoint3d(10.142898f, 10.032791f, -1.8152671f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.033699546f, -0.026215075f, 0.8203676f, 0.5702405f),
                    Position = new RealPoint3d(8.899034f, 9.534753f, -1.9219596f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.024346381f, -0.044115067f, 0.8087322f, 0.5860147f),
                    Position = new RealPoint3d(7.643027f, 9.061405f, -2.047941f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    Rotation = new RealQuaternion(-0.06811497f, -0.042115074f, 0.30290386f, 0.9496504f),
                    Position = new RealPoint3d(-7.0288334f, -0.3475109f, -1.4919306f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    Rotation = new RealQuaternion(-0.009711112f, -0.0052375593f, 0.70716494f, 0.7069625f),
                    Position = new RealPoint3d(16.884548f, 0.7832822f, -1.4988006f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.04207284f, -0.008606665f, 0.7608581f, 0.64749575f),
                    Position = new RealPoint3d(6.7189283f, 4.2602305f, -2.0969436f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.042072844f, -0.008606657f, 0.76085824f, 0.6474957f),
                    Position = new RealPoint3d(5.4392776f, 4.0481124f, -2.1846778f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.028996397f, 0.01648818f, 0.725385f, 0.68753475f),
                    Position = new RealPoint3d(4.2396083f, 3.9209838f, -2.2525055f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.0293535f, 0.015843714f, 0.7100225f, 0.7033886f),
                    Position = new RealPoint3d(3.117881f, 3.847685f, -2.269623f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.03446775f, 0.04949142f, 0.70529246f, 0.70634633f),
                    Position = new RealPoint3d(1.9020666f, 3.8182373f, -2.2607942f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.030569594f, 0.033829898f, 0.70617336f, 0.7065694f),
                    Position = new RealPoint3d(0.65700847f, 3.8002026f, -2.2320292f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.042719062f, -0.02453111f, -0.70907915f, 0.7034061f),
                    Position = new RealPoint3d(-0.67485034f, 3.7756321f, -2.199421f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.0571817f, -0.031884998f, -0.7243593f, 0.68630695f),
                    Position = new RealPoint3d(-1.984643f, 3.8044271f, -2.1558278f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.034915823f, -0.028264165f, -0.6180262f, 0.784873f),
                    Position = new RealPoint3d(6.3637757f, 8.671837f, -2.174161f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.0057689766f, -0.028933879f, -0.6433384f, 0.7650133f),
                    Position = new RealPoint3d(5.15411f, 8.462243f, -2.2632875f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.005349433f, -0.029014377f, -0.6543476f, 0.7556181f),
                    Position = new RealPoint3d(3.8949265f, 8.294934f, -2.3020468f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.029529035f, 0.026184058f, 0.7067807f, 0.7063311f),
                    Position = new RealPoint3d(2.592443f, 8.235989f, -2.3048048f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.0102807265f, -0.00032632102f, 0.706041f, 0.7080963f),
                    Position = new RealPoint3d(1.2642653f, 8.198959f, -2.2867665f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(0.008389542f, -0.0050179716f, 0.7065464f, 0.70759916f),
                    Position = new RealPoint3d(-0.056007825f, 8.20813f, -2.2736287f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.05711945f, 0.066490814f, 0.70424163f, 0.70452833f),
                    Position = new RealPoint3d(-1.3415133f, 8.23508f, -2.2655666f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.03391644f, 0.056000665f, 0.65987104f, 0.7485211f),
                    Position = new RealPoint3d(-3.263742f, 3.9769692f, -2.127114f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.03923174f, 0.043750156f, 0.66646177f, 0.7432198f),
                    Position = new RealPoint3d(-4.503162f, 4.1366096f, -2.126016f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    Rotation = new RealQuaternion(-0.046003368f, 0.03117442f, 0.6544256f, 0.7540816f),
                    Position = new RealPoint3d(-5.7443795f, 4.301005f, -2.1412563f),
                    Scale = 1f,
                },
            };
            scnr.DecalPalette = new List<TagReferenceBlock>
            {
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<DecalSystem>($@"levels\ui\mainmenu\decals\decal_natural_rockhack_blend"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<DecalSystem>($@"levels\ui\mainmenu\decals\decal_sand_patch"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<DecalSystem>($@"levels\shared\decals\human\damage\decal_damage_crack_dark"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<DecalSystem>($@"levels\shared\decals\human\damage\mortar_blast_small"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<DecalSystem>($@"levels\shared\decals\human\damage\scorch_sm"),
                },
            };
            scnr.AiUserHintData = new List<Scenario.UserHintBlock>
            {
                new Scenario.UserHintBlock
                {
                    Unknown8 = new List<Scenario.UserHintBlock.UnknownBlock8>
                    {
                        new Scenario.UserHintBlock.UnknownBlock8
                        {
                        },
                    },
                    Unknown9 = new List<Scenario.UserHintBlock.UnknownBlock9>
                    {
                        new Scenario.UserHintBlock.UnknownBlock9
                        {
                        },
                    },
                },
            };
            scnr.Scripts = null;
            scnr.Globals = null;
            scnr.ScriptSourceFileReferences = null;
            scnr.ScriptingData = new List<Scenario.ScriptingDatum>
            {
                new Scenario.ScriptingDatum
                {
                },
            };
            scnr.CutsceneFlags = new List<Scenario.CutsceneFlag>
            {
                new Scenario.CutsceneFlag
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"anchor_flag_x01"),
                    Position = new RealPoint3d(-471.391f, -74.6197f, 13.6494f),
                },
                new Scenario.CutsceneFlag
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"xxxanchorxxx"),
                },
            };
            scnr.CutsceneCameraPoints = new List<Scenario.CutsceneCameraPoint>
            {
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"light_anchor",
                    Position = new RealPoint3d(111.9694f, 12.57247f, -80.04536f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(8.505559f), Angle.FromDegrees(-4.878534f), Angle.FromDegrees(-0.7286655f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"campaign_in",
                    Position = new RealPoint3d(-2.783262f, -3.859817f, -0.7919874f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-115.4425f), Angle.FromDegrees(-6.147651f), Angle.FromDegrees(-10.10798f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"campaign",
                    Position = new RealPoint3d(-2.658308f, -3.940777f, -0.7919874f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-126.6335f), Angle.FromDegrees(-9.414923f), Angle.FromDegrees(-10.5665f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"campaign_path_02",
                    Position = new RealPoint3d(-2.591148f, -3.69542f, -0.7919874f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-116.4707f), Angle.FromDegrees(-5.092006f), Angle.FromDegrees(-7.577425f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"campaign_path_03",
                    Position = new RealPoint3d(-2.690809f, -3.983063f, -0.7919874f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-127.1006f), Angle.FromDegrees(-10.12939f), Angle.FromDegrees(-11.28327f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"campaign_path_04",
                    Position = new RealPoint3d(-2.478235f, -4.130247f, -0.7919874f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-150.1906f), Angle.FromDegrees(-9.65366f), Angle.FromDegrees(-4.181489f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"matchmaking_in",
                    Position = new RealPoint3d(-109.2913f, -230.1818f, 249.6066f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-96.70016f), Angle.FromDegrees(-5.832463f), Angle.FromDegrees(-40.85712f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"matchmaking",
                    Position = new RealPoint3d(-108.8834f, -230.3295f, 249.6066f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-114.6049f), Angle.FromDegrees(-19.05827f), Angle.FromDegrees(-35.48944f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"mm_path_02",
                    Position = new RealPoint3d(-108.738f, -230.4373f, 249.3507f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-117.1435f), Angle.FromDegrees(-25.78415f), Angle.FromDegrees(-40.31187f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"mm_path_03",
                    Position = new RealPoint3d(-109.3495f, -230.1522f, 249.7026f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-93.07613f), Angle.FromDegrees(-2.550249f), Angle.FromDegrees(-39.61562f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"mm_path_04",
                    Position = new RealPoint3d(-108.8306f, -230.1168f, 249.7026f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-113.9313f), Angle.FromDegrees(-13.6645f), Angle.FromDegrees(-28.02653f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"custom_in",
                    Position = new RealPoint3d(-7.260052f, -1.914379f, -1.031894f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(97.76698f), Angle.FromDegrees(5.038599f), Angle.FromDegrees(0.3009008f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"custom_games",
                    Position = new RealPoint3d(-7.631313f, -1.950026f, -1.031894f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(92.50669f), Angle.FromDegrees(5.023069f), Angle.FromDegrees(0.3404699f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"custom_path_02",
                    Position = new RealPoint3d(-6.846344f, -1.798082f, -1.031894f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(109.4133f), Angle.FromDegrees(3.636668f), Angle.FromDegrees(4.827899f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"custom_path_03",
                    Position = new RealPoint3d(-7.959418f, -1.590729f, -0.8185608f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(91.69172f), Angle.FromDegrees(5.166923f), Angle.FromDegrees(-4.460439f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"custom_path_04",
                    Position = new RealPoint3d(-8.004598f, -1.976056f, -1.031894f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(79.17783f), Angle.FromDegrees(4.966138f), Angle.FromDegrees(-0.827791f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"editor",
                    Position = new RealPoint3d(7.667727f, 13.1801f, -0.7279867f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-168.5137f), Angle.FromDegrees(6.510793f), Angle.FromDegrees(2.493183f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"editor_in",
                    Position = new RealPoint3d(7.216995f, 14.35544f, -0.7279867f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-142.0234f), Angle.FromDegrees(5.122333f), Angle.FromDegrees(5.440699f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"editor_path_02",
                    Position = new RealPoint3d(7.62511f, 12.98714f, -0.6319867f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-173.1839f), Angle.FromDegrees(6.289372f), Angle.FromDegrees(1.909284f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"editor_path_03",
                    Position = new RealPoint3d(7.482448f, 13.55463f, -0.6319866f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-157.3258f), Angle.FromDegrees(7.385588f), Angle.FromDegrees(4.313767f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"editor_path_04",
                    Position = new RealPoint3d(7.482708f, 13.54315f, -0.8133199f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-156.9684f), Angle.FromDegrees(6.993937f), Angle.FromDegrees(4.207599f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"theater_in",
                    Position = new RealPoint3d(801.6006f, 133.8912f, 150.8401f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(61.80203f), Angle.FromDegrees(17.58917f), Angle.FromDegrees(21.10417f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"theater",
                    Position = new RealPoint3d(778.9628f, 148.9992f, 150.84f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(38.44106f), Angle.FromDegrees(23.91669f), Angle.FromDegrees(12.35304f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"theater_path_02",
                    Position = new RealPoint3d(789.6351f, 155.7335f, 157.6666f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(40.4451f), Angle.FromDegrees(22.85756f), Angle.FromDegrees(12.65188f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"theater_path_03",
                    Position = new RealPoint3d(783.1628f, 143.8975f, 150.8401f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(47.91618f), Angle.FromDegrees(20.02225f), Angle.FromDegrees(14.34176f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"theater_path_04",
                    Position = new RealPoint3d(772.3842f, 158.1918f, 142.5201f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(37.1562f), Angle.FromDegrees(25.00277f), Angle.FromDegrees(12.41606f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "settings_cam",
                    Position = new RealPoint3d(-37.977f, -54.24f, -24.64976f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "survival",
                    Position = new RealPoint3d(-0.125f, -3.542f, 11.769f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(113.005f), Angle.FromDegrees(-2.619f), Angle.FromDegrees(6.142f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "survival_in",
                    Position = new RealPoint3d(-0.007f, -3.488f, 11.749f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(116.683f), Angle.FromDegrees(-4.455f), Angle.FromDegrees(8.785f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "survival_path_02",
                    Position = new RealPoint3d(-0.239f, -3.58f, 11.749f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(98.453f), Angle.FromDegrees(-1.195f), Angle.FromDegrees(7.99f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "survival_path_03",
                    Position = new RealPoint3d(-0.331f, -3.559f, 11.915f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(87.372f), Angle.FromDegrees(-0.477f), Angle.FromDegrees(-10.286f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "survival_path_04",
                    Position = new RealPoint3d(-0.237f, -3.619f, 11.686f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(97.894f), Angle.FromDegrees(-1.746f), Angle.FromDegrees(12.396f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "server_browser",
                    Position = new RealPoint3d(-108.8834f, -230.3295f, 249.6066f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-114.6049f), Angle.FromDegrees(-19.05827f), Angle.FromDegrees(-35.48944f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "server_browser_path_02",
                    Position = new RealPoint3d(-108.738f, -230.4373f, 249.3507f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-117.1435f), Angle.FromDegrees(-25.78415f), Angle.FromDegrees(-40.31187f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "server_browser_path_03",
                    Position = new RealPoint3d(-109.3495f, -230.1522f, 249.7026f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-93.07613f), Angle.FromDegrees(-2.550249f), Angle.FromDegrees(-39.61562f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "server_browser_path_04",
                    Position = new RealPoint3d(-108.8306f, -230.1168f, 249.7026f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-113.9313f), Angle.FromDegrees(-13.6645f), Angle.FromDegrees(-28.02653f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_helmet_wide",
                    Position = new RealPoint3d(-38.308f, -54.34f, -24.47776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_body_wide",
                    Position = new RealPoint3d(-38.308f, -54.369f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_leftshoulder_wide",
                    Position = new RealPoint3d(-38.208f, -54.264f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_rightshoulder_wide",
                    Position = new RealPoint3d(-38.108f, -54.34f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_helmet_wide",
                    Position = new RealPoint3d(-38.208f, -54.31f, -24.54776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_body_wide",
                    Position = new RealPoint3d(-38.308f, -54.34f, -24.62776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_leftshoulder_wide",
                    Position = new RealPoint3d(-38.208f, -54.324f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_rightshoulder_wide",
                    Position = new RealPoint3d(-38.158f, -54.424f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_helmet_standard",
                    Position = new RealPoint3d(-38.308f, -54.424f, -24.47776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_body_standard",
                    Position = new RealPoint3d(-38.208f, -54.389f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_leftshoulder_standard",
                    Position = new RealPoint3d(-38.208f, -54.324f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_rightshoulder_standard",
                    Position = new RealPoint3d(-38.108f, -54.414f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_helmet_standard",
                    Position = new RealPoint3d(-38.208f, -54.364f, -24.54776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_body_standard",
                    Position = new RealPoint3d(-38.358f, -54.444f, -24.62776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_leftshoulder_standard",
                    Position = new RealPoint3d(-38.208f, -54.414f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_rightshoulder_standard",
                    Position = new RealPoint3d(-38.158f, -54.454f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
            };
            scnr.CutsceneTitles = new List<Scenario.CutsceneTitle>
            {
                new Scenario.CutsceneTitle
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"title_1"),
                },
            };
            scnr.ScenarioResources = new List<Scenario.ScenarioResource>
            {
                new Scenario.ScenarioResource
                {
                    ScriptSource = new List<TagReferenceBlock>
                    {
                        new TagReferenceBlock
                        {
                        },
                        new TagReferenceBlock
                        {
                        },
                        new TagReferenceBlock
                        {
                        },
                    },
                    References = new List<Scenario.ScenarioResource.Reference>
                    {
                        new Scenario.ScenarioResource.Reference
                        {
                        },
                    },
                },
            };
            scnr.ScriptExpressions = null;
            scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
            {
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"the_world"),
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\main_menu\the_world\the_world"),
                    AmbienceInterpolationSpeed = 2f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"voi_ext"),
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\main_menu\voi_exterior\voi_exterior"),
                    AmbienceInterpolationSpeed = 2f,
                },
            };
            scnr.Atmosphere = new List<ScenarioStructureBsp.StructureBspAtmospherePaletteBlock>
            {
                new ScenarioStructureBsp.StructureBspAtmospherePaletteBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"foggy_morning"),
                },
                new ScenarioStructureBsp.StructureBspAtmospherePaletteBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"no_fog"),
                    AtmosphereSettingIndex = 2,
                },
            };
            scnr.ScenarioClusterData = new List<Scenario.ScenarioClusterDatum>
            {
                new Scenario.ScenarioClusterDatum
                {
                    BackgroundSoundEnvironments = new List<Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment>
                    {
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                            BackgroundSoundEnvironmentIndex = 1,
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                        },
                    },
                    Unknown = new List<Scenario.ScenarioClusterDatum.UnknownBlock>
                    {
                        new Scenario.ScenarioClusterDatum.UnknownBlock
                        {
                            Unknown = -1,
                        },
                        new Scenario.ScenarioClusterDatum.UnknownBlock
                        {
                            Unknown = -1,
                        },
                    },
                    Unknown2 = new List<Scenario.ScenarioClusterDatum.UnknownBlock2>
                    {
                        new Scenario.ScenarioClusterDatum.UnknownBlock2
                        {
                            Unknown = -1,
                        },
                        new Scenario.ScenarioClusterDatum.UnknownBlock2
                        {
                            Unknown = -1,
                        },
                    },
                    BspChecksum = 286986511,
                    ClusterCentroids = new List<Scenario.ScenarioClusterDatum.ClusterCentroid>
                    {
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(5.6437893f, 2.9798346f, -7.612221f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(3.4028235E+38f, 3.4028235E+38f, 3.4028235E+38f),
                        },
                    },
                    WeatherProperties = new List<Scenario.ScenarioClusterDatum.WeatherProperty>
                    {
                        new Scenario.ScenarioClusterDatum.WeatherProperty
                        {
                            Unknown = -1,
                        },
                        new Scenario.ScenarioClusterDatum.WeatherProperty
                        {
                            Unknown = -1,
                        },
                    },
                    Fog = new List<Scenario.ScenarioClusterDatum.FogBlock>
                    {
                        new Scenario.ScenarioClusterDatum.FogBlock
                        {
                            FogIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.FogBlock
                        {
                            FogIndex = -1,
                        },
                    },
                    CameraEffects = new List<Scenario.ScenarioClusterDatum.CameraEffect>
                    {
                        new Scenario.ScenarioClusterDatum.CameraEffect
                        {
                            CameraEffectIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.CameraEffect
                        {
                            CameraEffectIndex = -1,
                        },
                    },
                },
                new Scenario.ScenarioClusterDatum
                {
                    BackgroundSoundEnvironments = new List<Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment>
                    {
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                            BackgroundSoundEnvironmentIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                            BackgroundSoundEnvironmentIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                            BackgroundSoundEnvironmentIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                            BackgroundSoundEnvironmentIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                            BackgroundSoundEnvironmentIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                            BackgroundSoundEnvironmentIndex = -1,
                        },
                    },
                    Unknown = new List<Scenario.ScenarioClusterDatum.UnknownBlock>
                    {
                        new Scenario.ScenarioClusterDatum.UnknownBlock
                        {
                            Unknown = -1,
                        },
                        new Scenario.ScenarioClusterDatum.UnknownBlock
                        {
                            Unknown = -1,
                        },
                        new Scenario.ScenarioClusterDatum.UnknownBlock
                        {
                            Unknown = -1,
                        },
                        new Scenario.ScenarioClusterDatum.UnknownBlock
                        {
                            Unknown = -1,
                        },
                        new Scenario.ScenarioClusterDatum.UnknownBlock
                        {
                            Unknown = -1,
                        },
                        new Scenario.ScenarioClusterDatum.UnknownBlock
                        {
                            Unknown = -1,
                        },
                    },
                    Unknown2 = new List<Scenario.ScenarioClusterDatum.UnknownBlock2>
                    {
                        new Scenario.ScenarioClusterDatum.UnknownBlock2
                        {
                            Unknown = -1,
                        },
                        new Scenario.ScenarioClusterDatum.UnknownBlock2
                        {
                            Unknown = -1,
                        },
                        new Scenario.ScenarioClusterDatum.UnknownBlock2
                        {
                            Unknown = -1,
                        },
                        new Scenario.ScenarioClusterDatum.UnknownBlock2
                        {
                            Unknown = -1,
                        },
                        new Scenario.ScenarioClusterDatum.UnknownBlock2
                        {
                            Unknown = -1,
                        },
                        new Scenario.ScenarioClusterDatum.UnknownBlock2
                        {
                            Unknown = -1,
                        },
                    },
                    BspChecksum = 521338881,
                    ClusterCentroids = new List<Scenario.ScenarioClusterDatum.ClusterCentroid>
                    {
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(-38.535553f, 17f, -26.393398f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(-38.535553f, 51f, -26.393398f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(-38.535553f, 85.000015f, -26.393398f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(-38.535553f, -85f, -26.393398f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(-38.535553f, -50.999992f, -26.393398f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(-38.535553f, -17f, -26.393398f),
                        },
                    },
                    WeatherProperties = new List<Scenario.ScenarioClusterDatum.WeatherProperty>
                    {
                        new Scenario.ScenarioClusterDatum.WeatherProperty
                        {
                            Unknown = -1,
                        },
                        new Scenario.ScenarioClusterDatum.WeatherProperty
                        {
                            Unknown = -1,
                        },
                        new Scenario.ScenarioClusterDatum.WeatherProperty
                        {
                            Unknown = -1,
                        },
                        new Scenario.ScenarioClusterDatum.WeatherProperty
                        {
                            Unknown = -1,
                        },
                        new Scenario.ScenarioClusterDatum.WeatherProperty
                        {
                            Unknown = -1,
                        },
                        new Scenario.ScenarioClusterDatum.WeatherProperty
                        {
                            Unknown = -1,
                        },
                    },
                    Fog = new List<Scenario.ScenarioClusterDatum.FogBlock>
                    {
                        new Scenario.ScenarioClusterDatum.FogBlock
                        {
                            FogIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.FogBlock
                        {
                            FogIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.FogBlock
                        {
                            FogIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.FogBlock
                        {
                            FogIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.FogBlock
                        {
                            FogIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.FogBlock
                        {
                            FogIndex = -1,
                        },
                    },
                    CameraEffects = new List<Scenario.ScenarioClusterDatum.CameraEffect>
                    {
                        new Scenario.ScenarioClusterDatum.CameraEffect
                        {
                            CameraEffectIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.CameraEffect
                        {
                            CameraEffectIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.CameraEffect
                        {
                            CameraEffectIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.CameraEffect
                        {
                            CameraEffectIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.CameraEffect
                        {
                            CameraEffectIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.CameraEffect
                        {
                            CameraEffectIndex = -1,
                        },
                    },
                },
            };
            scnr.ObjectSalts = new int[32]
            {
                44, 4, 15, 1, 0, 0, 105, 7, 0, 69,
                24, 0, 0, 6, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0,
            };
            scnr.SpawnData = new List<Scenario.SpawnDatum>
            {
                new Scenario.SpawnDatum
                {
                },
            };
            scnr.Crates = new List<Scenario.CrateInstance>
            {
                new Scenario.CrateInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(22.3777f, 3.37402f, 1.82607f),
                    UniqueHandle = new DatumHandle(41252, 23),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
            };
            scnr.CratePalette = new List<Scenario.ScenarioPaletteEntry>
            {
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\020_base\dangling_wire\dangling_wire"),
                },
            };
            scnr.FlockPalette = new List<TagReferenceBlock>
            {
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Flock>($@"objects\characters\ambient_life\banshee_flock"),
                },
            };
            scnr.CreaturePalette = new List<Scenario.ScenarioPaletteEntry>
            {
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Creature>($@"objects\characters\ambient_life\lod_banshee\lod_banshee"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Creature>($@"objects\characters\ambient_life\lod_hornet\lod_hornet"),
                },
            };
            scnr.EditorFolders = null;
            scnr.SimulationDefinitionTable = null;
            scnr.DefaultCameraFx = GetCachedTag<CameraFxSettings>($@"levels\ui\mainmenu\sky\menu");
            scnr.DefaultScreenFx = GetCachedTag<AreaScreenEffect>($@"levels\ui\mainmenu\sky\ui");
            scnr.SkyParameters = GetCachedTag<SkyAtmParameters>($@"levels\ui\mainmenu\sky\menu");
            scnr.Lightmap = GetCachedTag<ScenarioLightmap>($@"fake_lightmap");
            scnr.PerformanceThrottles = GetCachedTag<PerformanceThrottles>($@"levels\ui\mainmenu\mainmenu");
            scnr.DesignerZoneSets = new List<Scenario.DesignerZoneSet>
            {
                new Scenario.DesignerZoneSet
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"empty"),
                },
            };
            scnr.ZoneDebugger = new List<Scenario.ScenarioZoneDebuggerBlock>
            {
                new Scenario.ScenarioZoneDebuggerBlock
                {
                },
            };
            scnr.CinematicLighting = new List<Scenario.CinematicLightingBlock>
            {
                new Scenario.CinematicLightingBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"lighting_ark"),
                    CinematicLight = GetCachedTag<NewCinematicLighting>($@"levels\ui\mainmenu\sky\lighting_ark"),
                },
                new Scenario.CinematicLightingBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"lighting_storm"),
                    CinematicLight = GetCachedTag<NewCinematicLighting>($@"levels\ui\mainmenu\sky\lighting_storm"),
                },
                new Scenario.CinematicLightingBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"lighting_ships"),
                    CinematicLight = GetCachedTag<NewCinematicLighting>($@"levels\ui\mainmenu\sky\lighting_ships"),
                },
                new Scenario.CinematicLightingBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"lighting_clouds"),
                    CinematicLight = GetCachedTag<NewCinematicLighting>($@"levels\ui\mainmenu\sky\lighting_clouds"),
                },
            };
            scnr.SoftSurfaces = new List<Scenario.SoftSurfaceBlock>
            {
                new Scenario.SoftSurfaceBlock
                {
                },
            };
            CacheContext.Serialize(Stream, tag, scnr);

            CompileScript(tag, $@"{Program.TagToolDirectory}\Tools\data\{tag.Name}\scripts\mainmenu_h3.hsc");
        }
    }
}
