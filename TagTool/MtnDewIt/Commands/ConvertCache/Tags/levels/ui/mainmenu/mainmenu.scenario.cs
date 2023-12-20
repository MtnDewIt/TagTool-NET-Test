using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Commands;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class levels_ui_mainmenu_mainmenu_scenario : TagFile
    {
        public levels_ui_mainmenu_mainmenu_scenario(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            scnr.MapId = 270735729;
            scnr.StructureBsps = new List<Scenario.StructureBspBlock>
            {
                new Scenario.StructureBspBlock
                {
                    StructureBsp = GetCachedTag<ScenarioStructureBsp>($@"levels\multi\riverworld\riverworld"),
                    Design = GetCachedTag<StructureDesign>($@"levels\multi\riverworld\riverworld_design"),
                    Flags = 32,
                    DefaultSkyIndex = -1,
                    Cubemap = GetCachedTag<Bitmap>($@"levels\multi\riverworld\riverworld_riverworld_cubemaps"),
                    Wind = GetCachedTag<Wind>($@"levels\multi\riverworld\wind_riverworld"),
                },
            };
            scnr.SkyReferences = new List<Scenario.SkyReference>
            {
                new Scenario.SkyReference
                {
                    SkyObject = GetCachedTag<Scenery>($@"levels\multi\riverworld\sky\riverworld"),
                    NameIndex = -1,
                    ActiveBsps = Scenario.BspShortFlags.Bsp0,
                },
            };
            scnr.ZoneSetPvs = new List<Scenario.ZoneSetPvsBlock>
            {
                new Scenario.ZoneSetPvsBlock
                {
                    StructureBspMask = Scenario.BspFlags.Bsp0,
                    Version = 9,
                    BspChecksums = new List<Scenario.ZoneSetPvsBlock.BspChecksum>
                    {
                        new Scenario.ZoneSetPvsBlock.BspChecksum
                        {
                            Checksum = 370213143,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit2 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit2 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit4 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit11 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit12 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit4 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit2 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit4 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit2 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit4 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit11,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit12,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit2 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit4 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit2 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit2 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit4 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit11 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit12 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit4 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit2 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit4 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit2 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit4 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit11,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit12,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit2 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit4 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit5 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit10 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit13 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit14 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit15 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit19 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit21 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit22 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit25,
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
                                                    Bits = Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit0 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit1 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit3 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit6 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit7 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit8 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit9 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit16 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit17 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit18 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit20 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit23 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit24 | Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits.Bit26,
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
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                                new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                                {
                                },
                            },
                            MutipleSkiesVisibleBitvector = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>
                            {
                                new Scenario.ZoneSetPvsBlock.BitVectorDword
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
                    },
                },
            };
            scnr.ZoneSetAudibility = new List<Scenario.ZoneSetAudibilityBlock>
            {
                new Scenario.ZoneSetAudibilityBlock
                {
                    RoomCount = 27,
                    RoomDistanceBounds = new Bounds<float>(0.001777803f, 103.1195f),
                    AiDeafeningPas = new List<Scenario.ZoneSetAudibilityBlock.AiDeafeningPa>
                    {
                        new Scenario.ZoneSetAudibilityBlock.AiDeafeningPa
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.AiDeafeningPa
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.AiDeafeningPa
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.AiDeafeningPa
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.AiDeafeningPa
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.AiDeafeningPa
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.AiDeafeningPa
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.AiDeafeningPa
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.AiDeafeningPa
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.AiDeafeningPa
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.AiDeafeningPa
                        {
                        },
                    },
                    RoomDistances = new List<Scenario.ZoneSetAudibilityBlock.RoomDistance>
                    {
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 107,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 107,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -86,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 49,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 55,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 62,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 53,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 55,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 56,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 56,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -105,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 99,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 105,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 59,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 54,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 87,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 117,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 99,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -97,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 9,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 10,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -101,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 86,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 102,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 102,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -91,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 11,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 16,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 52,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 46,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 56,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 51,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 51,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -102,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 102,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 98,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 28,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 46,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 99,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 112,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 4,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 102,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -94,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 2,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -99,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 5,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 73,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -119,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -117,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 69,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 57,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 48,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 48,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 79,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 51,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 6,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -124,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 72,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 21,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 46,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 21,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 82,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 82,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 31,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 77,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -79,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 5,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 9,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 9,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 7,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 9,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 7,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 7,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 73,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -119,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -117,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 69,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 58,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 48,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 48,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 79,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 51,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 6,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -124,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 72,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 21,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 46,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 21,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 82,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 82,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 31,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 77,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -79,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -48,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -44,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -122,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -128,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 57,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 116,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 116,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 45,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 59,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 53,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -51,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 68,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 87,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 86,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 14,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 34,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -105,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 101,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 30,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -11,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 63,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 32,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 104,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 97,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 97,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -53,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -105,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -115,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 12,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 60,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -106,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -101,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 53,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -105,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -47,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 50,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -53,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 43,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 62,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 21,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 109,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 103,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 103,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -48,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -98,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -112,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 61,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -100,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -97,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 59,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -100,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -42,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 56,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -48,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 36,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 40,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 54,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 54,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -110,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 106,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 73,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 56,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 117,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 87,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 52,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 88,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -106,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 7,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 7,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -114,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 97,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 38,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 56,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 56,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -98,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 111,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 61,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 15,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 118,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 76,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 46,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 76,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -115,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -115,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 13,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 8,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 8,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 52,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 103,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 26,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 5,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 58,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 52,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 52,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -107,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 107,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 58,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 50,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 97,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 30,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 64,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 62,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 17,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 55,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 113,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 47,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 107,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -113,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 107,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 58,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 50,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 97,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 30,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 64,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 62,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 17,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 55,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 113,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 47,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 107,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -113,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 11,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 62,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -53,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 75,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 39,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 32,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 55,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -102,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 103,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 12,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -7,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 46,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -101,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 49,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 46,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 3,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 16,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 102,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 51,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 28,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -59,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -119,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 71,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 46,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 63,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 87,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 36,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 57,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -74,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 54,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -103,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -104,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 58,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -106,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -48,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 50,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -54,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 40,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 72,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 16,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 46,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 16,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 77,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 72,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 96,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 70,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 25,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 45,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 97,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 50,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 55,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -72,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 46,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 21,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 101,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 50,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 15,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -59,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 62,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 1,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 60,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 97,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 101,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 50,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -59,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -97,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 108,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -2,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -103,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 102,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = 96,
                        },
                        new Scenario.ZoneSetAudibilityBlock.RoomDistance
                        {
                            EncodedData = -8,
                        },
                    },
                    GamePortalToDoorOccluderMappings = new List<Scenario.ZoneSetAudibilityBlock.GamePortalToDoorOccluderMapping>
                    {
                        new Scenario.ZoneSetAudibilityBlock.GamePortalToDoorOccluderMapping
                        {
                        },
                    },
                    BspClusterToRoomBoundsMappings = new List<Scenario.ZoneSetAudibilityBlock.BspClusterToRoomBoundsMapping>
                    {
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomBoundsMapping
                        {
                            RoomIndexCount = 27,
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
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 8,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 9,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 10,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 11,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 12,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 13,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 14,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 15,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 16,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 17,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 18,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 19,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 20,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 21,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 22,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 23,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 24,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 25,
                        },
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex
                        {
                            RoomIndex = 26,
                        },
                    },
                },
            };
            scnr.ZoneSets = new List<Scenario.ZoneSet>
            {
                new Scenario.ZoneSet
                {
                    Name = CacheContext.StringTable.GetStringId($@"levels\multi\riverworld\riverworld"),
                    Bsps = Scenario.BspFlags.Bsp0,
                    HintPreviousZoneSet = -1,
                },
            };
            scnr.ObjectNames = new List<Scenario.ObjectName>
            {
                new Scenario.ObjectName
                {
                    Name = "char_platform",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 7,
                },
                new Scenario.ObjectName
                {
                    Name = "spartan_appearance",
                },
                new Scenario.ObjectName
                {
                    Name = "campaign_chief",
                    PlacementIndex = 1,
                },
                new Scenario.ObjectName
                {
                    Name = "campaign_aribter",
                    PlacementIndex = 2,
                },
                new Scenario.ObjectName
                {
                    Name = "campaign_ar",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                },
                new Scenario.ObjectName
                {
                    Name = "campaign_pr",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 1,
                },
                new Scenario.ObjectName
                {
                    Name = "campaign_light",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = (GameObjectTypeHalo3ODST)255,
                    },
                    PlacementIndex = -1,
                },
                new Scenario.ObjectName
                {
                    Name = "appearance_ar",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 2,
                },
                new Scenario.ObjectName
                {
                    Name = "custom_chief_01",
                    PlacementIndex = 3,
                },
                new Scenario.ObjectName
                {
                    Name = "custom_chief_02",
                    PlacementIndex = 4,
                },
                new Scenario.ObjectName
                {
                    Name = "custom_ar_01",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 3,
                },
                new Scenario.ObjectName
                {
                    Name = "custom_sg_01",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 4,
                },
                new Scenario.ObjectName
                {
                    Name = "custom_flag",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 5,
                },
                new Scenario.ObjectName
                {
                    Name = "custom_light",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = (GameObjectTypeHalo3ODST)255,
                    },
                    PlacementIndex = -1,
                },
                new Scenario.ObjectName
                {
                    Name = "editor_monitor",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 8,
                },
                new Scenario.ObjectName
                {
                    Name = "editor_warthog",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 9,
                },
                new Scenario.ObjectName
                {
                    Name = "editor_light",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = (GameObjectTypeHalo3ODST)255,
                    },
                    PlacementIndex = -1,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_phantom",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 10,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_light",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = (GameObjectTypeHalo3ODST)255,
                    },
                    PlacementIndex = -1,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_odst_recon_01",
                    PlacementIndex = 5,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_odst_recon_02",
                    PlacementIndex = 6,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_automag_2",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 11,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_ssmg_1",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 12,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_ssmg_2",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 13,
                },
                new Scenario.ObjectName
                {
                    Name = "server_browser_earth",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 14,
                },
                new Scenario.ObjectName
                {
                    Name = "server_browser_black",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    PlacementIndex = 102,
                },
                new Scenario.ObjectName
                {
                    Name = "elite_appearance",
                    PlacementIndex = 7,
                },
                new Scenario.ObjectName
                {
                    Name = "appearance_pr",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 6,
                },
            };
            scnr.Scenery = new List<Scenario.SceneryInstance>
            {
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 12,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6f, -57.5948f, 6.362535f),
                    UniqueHandle = new DatumHandle(6832, 220),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6f, -147.0875f, 7.344046f),
                    UniqueHandle = new DatumHandle(6832, 221),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                    PaletteIndex = 13,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.55968f, -142.3525f, 2.75f),
                    UniqueHandle = new DatumHandle(6832, 222),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                    PaletteIndex = 21,
                    NameIndex = -1,
                    Position = new RealPoint3d(77.9584f, -143.7763f, 2.75f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(45f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(6836, 223),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                    PaletteIndex = 21,
                    NameIndex = -1,
                    Position = new RealPoint3d(78.01319f, -60.69084f, 1.8f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(135f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(6836, 225),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                    PaletteIndex = 13,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.59317f, -62.13622f, 1.8f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(6836, 226),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                    PaletteIndex = 22,
                    NameIndex = -1,
                    Position = new RealPoint3d(100.223f, -147.906f, 0.6631185f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-42.73426f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(6840, 227),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                    PaletteIndex = 1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(74.108f, -101.926f, -20f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(0, 3),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                    PaletteIndex = 26,
                    NameIndex = 14,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(55.12044f, -98.26942f, 3.532973f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-28.29517f), Angle.FromDegrees(-14.60906f), Angle.FromDegrees(5.956088f)),
                    UniqueHandle = new DatumHandle(0, 17),
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
                    PaletteIndex = 27,
                    NameIndex = 15,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(54.739f, -98.738f, 2.832f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(36.857f), Angle.FromDegrees(-11.491f), Angle.FromDegrees(6.565f)),
                    UniqueHandle = new DatumHandle(0, 18),
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
                    PaletteIndex = 28,
                    NameIndex = 17,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
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
                    Variant = CacheContext.StringTable.GetStringId($@"enemy_no_turret"),
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
                    PaletteIndex = 29,
                    NameIndex = 21,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
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
                    PaletteIndex = 30,
                    NameIndex = 22,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
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
                    PaletteIndex = 30,
                    NameIndex = 23,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
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
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 31,
                    NameIndex = 24,
                    Position = new RealPoint3d(1.6942f, -100.1158f, 324.0898f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(134.7043f), Angle.FromDegrees(-46.78879f), Angle.FromDegrees(-33.98746f)),
                    UniqueHandle = new DatumHandle(0, 27),
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
                    Object = GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_point"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\menu_platform\menu_platform"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\oddball\oddball_initial_spawn_point"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\slayer\slayer_respawn_zone"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_flag_away_respawn_zone"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_flag_at_home_respawn_zone"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_respawn_zone"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_initial_spawn_point"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\koth\koth_initial_spawn_point"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\territories\territories_respawn_zone"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\resupply_capsule_fired\resupply_capsule_fired"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\territories\territories_initial_spawn_point"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\multi\riverworld\fx\tower_pulse\tower_pulse"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\multi\riverworld\fx\man_cannon\man_cannon"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\assault\assault_initial_spawn_point"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\assault\assault_respawn_zone"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\resupply_capsule_ground_scar\ground_scar"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\vip\vip_initial_spawn_point"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\vip\vip_respawn_zone"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\scenery\human\military\warthog_drop_palette\warthog_drop_palette"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\scenery\human\military\mongoose_drop_palette\mongoose_drop_palette"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\multi\riverworld\fx\man_cannon\mini_man_cannon"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\multi\riverworld\fx\waterfall\waterfall_base"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\multi\riverworld\fx\waterfall\waterfall_top"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\multi\riverworld\fx\waterfall\waterfall_mid"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_point_invisible"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\monitor_cheap\monitor_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\warthog_cheap\warthog_cheap"),
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
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\matchmaking_earth\matchmaking_earth"),
                },
            };
            scnr.Bipeds = new List<Scenario.BipedInstance>
            {
                new Scenario.BipedInstance
                {
                    NameIndex = 1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(74.108f, -101.926f, 11.65f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(120f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Scale = 1.1f,
                    UniqueHandle = new DatumHandle(0, 4),
                    OriginBspIndex = -1,
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 2,
                    NameIndex = 2,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(88.52471f, -92.73032f, 3.0033f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-155.3412f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(0, 5),
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
                    NameIndex = 3,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(89.14196f, -93.00212f, 2.9926f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-169.868f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(0, 6),
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
                    NameIndex = 8,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(80.835f, -153.812f, 1.979f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-91.98899f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(0, 11),
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Variant = CacheContext.StringTable.GetStringId($@"menu_spartan2"),
                    ActiveChangeColors = Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Primary | Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Secondary | Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Tertiary | Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Quaternary,
                    PrimaryColor = new ArgbColor(255, 41, 41, 41),
                    SecondaryColor = new ArgbColor(255, 211, 68, 68),
                    TertiaryColor = new ArgbColor(255, 255, 148, 0),
                    QuaternaryColor = new ArgbColor(255, 255, 255, 255),
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 3,
                    NameIndex = 9,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(80.893f, -153.553f, 1.979f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-163.1319f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(0, 12),
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Variant = CacheContext.StringTable.GetStringId($@"menu_spartan1"),
                    ActiveChangeColors = Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Primary | Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Secondary | Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Tertiary | Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Quaternary,
                    PrimaryColor = new ArgbColor(255, 86, 86, 86),
                    SecondaryColor = new ArgbColor(255, 41, 49, 92),
                    TertiaryColor = new ArgbColor(255, 255, 148, 0),
                    QuaternaryColor = new ArgbColor(255, 255, 255, 255),
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 4,
                    NameIndex = 19,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
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
                    Variant = CacheContext.StringTable.GetStringId($@"mainmenu_odst01"),
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 4,
                    NameIndex = 20,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
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
                    Variant = CacheContext.StringTable.GetStringId($@"mainmenu_odst01"),
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 5,
                    NameIndex = 26,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(74.108f, -101.926f, 11.65f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(120f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Scale = 1.1f,
                    OriginBspIndex = -1,
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
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
                    Object = GetCachedTag<Biped>($@"objects\characters\elite\mp_elite\mp_elite"),
                },
            };
            scnr.Weapons = new List<Scenario.WeaponInstance>
            {
                new Scenario.WeaponInstance
                {
                    NameIndex = 4,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    UniqueHandle = new DatumHandle(0, 7),
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
                    NameIndex = 5,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    UniqueHandle = new DatumHandle(0, 8),
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
                    NameIndex = 7,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    UniqueHandle = new DatumHandle(0, 10),
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
                    NameIndex = 10,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    UniqueHandle = new DatumHandle(0, 13),
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
                    PaletteIndex = 3,
                    NameIndex = 11,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    UniqueHandle = new DatumHandle(0, 14),
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
                    NameIndex = 12,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(81.397f, -153.856f, 2.210711f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-81.45872f), Angle.FromDegrees(-10.39058f), Angle.FromDegrees(4.628513f)),
                    UniqueHandle = new DatumHandle(0, 15),
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
                    NameIndex = 27,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
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
                            NameIndex = 0,
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
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\shotgun\shotgun"),
                },
            };
            scnr.SoundScenery = new List<Scenario.SoundSceneryInstance>
            {
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 1,
                    NameIndex = -1,
                    Position = new RealPoint3d(101.714f, -148.964f, 19.6479f),
                    UniqueHandle = new DatumHandle(8672, 38),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(50f, 120f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 2,
                    NameIndex = -1,
                    Position = new RealPoint3d(102.8339f, -149.8346f, 6.977479f),
                    UniqueHandle = new DatumHandle(8676, 39),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(15f, 50f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 5,
                    NameIndex = -1,
                    Position = new RealPoint3d(100.1857f, -146.8586f, 4.012937f),
                    UniqueHandle = new DatumHandle(8904, 139),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 20f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    Position = new RealPoint3d(88.92775f, -42.82571f, -0.0930737f),
                    UniqueHandle = new DatumHandle(8692, 73),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 10f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    Position = new RealPoint3d(84.00211f, -42.58171f, 0.1544246f),
                    UniqueHandle = new DatumHandle(8692, 74),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 10f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    Position = new RealPoint3d(79.01346f, -42.64763f, 0.07958441f),
                    UniqueHandle = new DatumHandle(8692, 75),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 10f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    Position = new RealPoint3d(74.20196f, -43.12214f, -0.08507097f),
                    UniqueHandle = new DatumHandle(8692, 76),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 10f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    Position = new RealPoint3d(69.10872f, -44.01847f, -0.5705139f),
                    UniqueHandle = new DatumHandle(8692, 77),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 10f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    Position = new RealPoint3d(62.67234f, -43.64732f, -0.5622486f),
                    UniqueHandle = new DatumHandle(8692, 78),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(4f, 9f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(99.60492f, -146.31f, 1.295357f),
                    UniqueHandle = new DatumHandle(8976, 183),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(96.0359f, -141.8127f, 0.5555733f),
                    UniqueHandle = new DatumHandle(8976, 184),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(91.46082f, -138.7812f, 0.494749f),
                    UniqueHandle = new DatumHandle(8976, 185),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(86.75145f, -137.2434f, 0.4947491f),
                    UniqueHandle = new DatumHandle(8976, 188),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(85.5658f, -136.6505f, 0.4947491f),
                    UniqueHandle = new DatumHandle(8976, 189),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(80.52418f, -136.7979f, 0.5550147f),
                    UniqueHandle = new DatumHandle(8976, 190),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(75.68055f, -135.8943f, 0.5548428f),
                    UniqueHandle = new DatumHandle(8976, 191),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(71.14467f, -134.0638f, 0.5546785f),
                    UniqueHandle = new DatumHandle(8976, 192),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(65.68829f, -131.8185f, 0.5547419f),
                    UniqueHandle = new DatumHandle(8976, 193),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(61.2037f, -128.007f, 0.4947491f),
                    UniqueHandle = new DatumHandle(8976, 194),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(57.45536f, -123.6239f, 3.411993f),
                    UniqueHandle = new DatumHandle(8976, 195),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(57.18699f, -118.6934f, 0.4692936f),
                    UniqueHandle = new DatumHandle(8976, 196),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(59.84005f, -114.1016f, 0.4947491f),
                    UniqueHandle = new DatumHandle(8976, 197),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(63.30855f, -109.38f, 0.4947491f),
                    UniqueHandle = new DatumHandle(8976, 198),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(67.50628f, -105.0464f, 0.5547439f),
                    UniqueHandle = new DatumHandle(8976, 199),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(70.49306f, -100.1009f, 0.5547864f),
                    UniqueHandle = new DatumHandle(8976, 200),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(75.43427f, -96.76081f, 0.5546998f),
                    UniqueHandle = new DatumHandle(8976, 201),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(80.29081f, -93.68417f, 0.5548585f),
                    UniqueHandle = new DatumHandle(8976, 202),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(83.23647f, -88.75957f, 0.5549442f),
                    UniqueHandle = new DatumHandle(8976, 203),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(84.49871f, -82.85481f, 0.5699285f),
                    UniqueHandle = new DatumHandle(8976, 204),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(85.87384f, -77.28013f, 0.4947491f),
                    UniqueHandle = new DatumHandle(8976, 205),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(84.80053f, -71.7559f, -0.6242142f),
                    UniqueHandle = new DatumHandle(8976, 206),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(78.88576f, -69.61681f, -0.2936997f),
                    UniqueHandle = new DatumHandle(8976, 207),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 10f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(75.78659f, -65.64868f, -0.6242142f),
                    UniqueHandle = new DatumHandle(8976, 208),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 10f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(72.41733f, -62.19507f, -0.6241519f),
                    UniqueHandle = new DatumHandle(8976, 209),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 10f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(70.29737f, -57.27953f, -0.6239845f),
                    UniqueHandle = new DatumHandle(8976, 210),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 10f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(68.94999f, -52.7841f, -0.6239064f),
                    UniqueHandle = new DatumHandle(8976, 211),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(67.92961f, -47.12537f, -0.623894f),
                    UniqueHandle = new DatumHandle(8976, 212),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(64.75996f, -43.8155f, -0.5832177f),
                    UniqueHandle = new DatumHandle(8976, 213),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 6,
                    NameIndex = -1,
                    Position = new RealPoint3d(102.9027f, -93.72679f, 9.652821f),
                    UniqueHandle = new DatumHandle(9044, 214),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(40f, 50f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 7,
                    NameIndex = -1,
                    Position = new RealPoint3d(79.02052f, 20.24934f, 0.7990031f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(-2.695954f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(9048, 215),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(67f, 77f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 8,
                    NameIndex = -1,
                    Position = new RealPoint3d(97.47926f, -86.31039f, 3.583489f),
                    UniqueHandle = new DatumHandle(13328, 216),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 9,
                    NameIndex = -1,
                    Position = new RealPoint3d(97.26492f, -86.26742f, 3.518993f),
                    UniqueHandle = new DatumHandle(13328, 217),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 8,
                    NameIndex = -1,
                    Position = new RealPoint3d(94.3306f, -117.8064f, 3.777714f),
                    UniqueHandle = new DatumHandle(13328, 218),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 9,
                    NameIndex = -1,
                    Position = new RealPoint3d(94.24744f, -117.9948f, 3.770833f),
                    UniqueHandle = new DatumHandle(13328, 219),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(54.17979f, -124.5231f, 0.4694085f),
                    UniqueHandle = new DatumHandle(60292, 220),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(62.10279f, -132.7092f, 0.5492993f),
                    UniqueHandle = new DatumHandle(60296, 221),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(60.37963f, -109.5692f, 0.596431f),
                    UniqueHandle = new DatumHandle(60296, 222),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 4,
                    NameIndex = -1,
                    Position = new RealPoint3d(65.1866f, -104.0021f, 0.5581134f),
                    UniqueHandle = new DatumHandle(60296, 223),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(69.11552f, -99.20686f, 0.703201f),
                    UniqueHandle = new DatumHandle(60296, 224),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(73.334f, -94.76583f, 0.7570813f),
                    UniqueHandle = new DatumHandle(60296, 225),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(78.32545f, -93.42019f, 0.6995664f),
                    UniqueHandle = new DatumHandle(60296, 226),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(81.71619f, -88.51965f, 1.946583f),
                    UniqueHandle = new DatumHandle(60296, 227),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(83.08843f, -83.25829f, 0.6259066f),
                    UniqueHandle = new DatumHandle(60296, 228),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(84.5685f, -77.75083f, 0.5759848f),
                    UniqueHandle = new DatumHandle(60296, 229),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(84.45121f, -72.7034f, -0.3179543f),
                    UniqueHandle = new DatumHandle(60296, 230),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(81.29051f, -70.27055f, -0.4456807f),
                    UniqueHandle = new DatumHandle(60296, 231),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(74.13795f, -66.93324f, -0.3310789f),
                    UniqueHandle = new DatumHandle(60296, 232),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(69.77605f, -60.08054f, -0.5282046f),
                    UniqueHandle = new DatumHandle(60296, 233),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(66.66835f, -51.90548f, -0.6236368f),
                    UniqueHandle = new DatumHandle(60296, 234),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(70.88756f, -43.45189f, -0.5158818f),
                    UniqueHandle = new DatumHandle(60296, 235),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(64.73491f, -47.40338f, -0.5644776f),
                    UniqueHandle = new DatumHandle(60296, 236),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(6f, 12f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    Position = new RealPoint3d(86.57638f, -35.91214f, -1.49436f),
                    UniqueHandle = new DatumHandle(60328, 237),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 10f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    Position = new RealPoint3d(80.04093f, -36.14871f, -1.381031f),
                    UniqueHandle = new DatumHandle(60328, 238),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 10f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    Position = new RealPoint3d(75.67045f, -35.52757f, -1.627902f),
                    UniqueHandle = new DatumHandle(60328, 239),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 10f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    Position = new RealPoint3d(69.83766f, -36.2365f, -1.565338f),
                    UniqueHandle = new DatumHandle(60328, 240),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 10f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    Position = new RealPoint3d(64.32837f, -37.00475f, -1.705049f),
                    UniqueHandle = new DatumHandle(60328, 241),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 10f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    Position = new RealPoint3d(61.21355f, -37.96205f, -1.701562f),
                    UniqueHandle = new DatumHandle(60328, 242),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(5f, 10f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 10,
                    NameIndex = -1,
                    Position = new RealPoint3d(86.4371f, -74.50612f, -0.1788607f),
                    UniqueHandle = new DatumHandle(2792, 245),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(3f, 8f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 10,
                    NameIndex = -1,
                    Position = new RealPoint3d(86.41711f, -70.78158f, -0.6242143f),
                    UniqueHandle = new DatumHandle(2792, 246),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(3f, 8f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 10,
                    NameIndex = -1,
                    Position = new RealPoint3d(83.74684f, -69.52308f, -0.6242141f),
                    UniqueHandle = new DatumHandle(2792, 247),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(3f, 8f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    Position = new RealPoint3d(61.34048f, -122.0068f, 0.4947631f),
                    UniqueHandle = new DatumHandle(2800, 248),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(3f, 8f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    Position = new RealPoint3d(54.91737f, -122.9353f, 0.4775199f),
                    UniqueHandle = new DatumHandle(2800, 249),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(3f, 8f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 11,
                    NameIndex = -1,
                    Position = new RealPoint3d(100.9337f, -147.106f, 3.888864f),
                    UniqueHandle = new DatumHandle(6920, 250),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(3f, 10f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 11,
                    NameIndex = -1,
                    Position = new RealPoint3d(101.9172f, -150.0711f, 7.458726f),
                    UniqueHandle = new DatumHandle(7796, 252),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(3f, 8f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 11,
                    NameIndex = -1,
                    Position = new RealPoint3d(101.7006f, -150.5735f, 11.82001f),
                    UniqueHandle = new DatumHandle(7796, 253),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(3f, 8f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 11,
                    NameIndex = -1,
                    Position = new RealPoint3d(101.7663f, -150.521f, 16.27793f),
                    UniqueHandle = new DatumHandle(7796, 254),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(3f, 8f),
                },
                new Scenario.SoundSceneryInstance
                {
                    PaletteIndex = 11,
                    NameIndex = -1,
                    Position = new RealPoint3d(101.8679f, -149.9876f, 20.49209f),
                    UniqueHandle = new DatumHandle(7796, 255),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.SoundScenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    OverrideDistance = new Bounds<float>(3f, 8f),
                },
            };
            scnr.SoundSceneryPalette = new List<Scenario.ScenarioPaletteEntry>
            {
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<SoundScenery>($@"sound\levels\riverworld\sound_scenery\water_creek\water_creek"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<SoundScenery>($@"sound\levels\riverworld\sound_scenery\waterfall_far\waterfall_far"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<SoundScenery>($@"sound\levels\riverworld\sound_scenery\riverworld_waterfall_close\riverworld_waterfall_close"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<SoundScenery>($@"sound\levels\riverworld\sound_scenery\water_against_surface\water_against_surface"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<SoundScenery>($@"sound\levels\riverworld\sound_scenery\water_brook\water_brook"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<SoundScenery>($@"sound\levels\riverworld\sound_scenery\waterfall_close_churning\waterfall_close_churning"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<SoundScenery>($@"sound\levels\riverworld\sound_scenery\backward_eagle\backward_eagle"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<SoundScenery>($@"sound\levels\riverworld\sound_scenery\open_breeze\open_breeze"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<SoundScenery>($@"sound\materials\gear\generator_flood\generator_flood"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<SoundScenery>($@"sound\materials\gear\flood_lamp\flood_lamp"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<SoundScenery>($@"sound\levels\riverworld\sound_scenery\riverworld_rapids\riverworld_rapids"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<SoundScenery>($@"sound\levels\riverworld\sound_scenery\inside_waterfall\inside_waterfall"),
                },
            };
            scnr.LightVolumes = new List<Scenario.LightVolumeInstance>
            {
                new Scenario.LightVolumeInstance
                {
                    NameIndex = 6,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(87.95523f, -91.52019f, 3.164429f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(7.247242f), Angle.FromDegrees(-10.34807f), Angle.FromDegrees(60.06319f)),
                    UniqueHandle = new DatumHandle(0, 9),
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
                    X = 88.64423f,
                    Y = -94.7899f,
                    Z = 5.047427f,
                    Width = 0.015625f,
                    HeightScale = 1f,
                    FieldOfView = Angle.FromDegrees(125.9875f),
                    FalloffDistance = 0.4414063f,
                    CutoffDistance = 3.835549f,
                },
                new Scenario.LightVolumeInstance
                {
                    PaletteIndex = 1,
                    NameIndex = 13,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(81.37815f, -152.6445f, 2.375807f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(63.09137f), Angle.FromDegrees(17.67388f), Angle.FromDegrees(92.07263f)),
                    UniqueHandle = new DatumHandle(0, 16),
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
                    X = 80.88482f,
                    Y = -153.6694f,
                    Z = 2.4306f,
                    Width = 1.839451f,
                    HeightScale = 1f,
                    FieldOfView = Angle.FromDegrees(75.35489f),
                    FalloffDistance = 0.6302913f,
                    CutoffDistance = 1.189611f,
                },
                new Scenario.LightVolumeInstance
                {
                    PaletteIndex = 2,
                    NameIndex = 16,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(56.47885f, -98.81166f, 4.854488f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(4.631807f), Angle.FromDegrees(48.29739f), Angle.FromDegrees(177.1723f)),
                    UniqueHandle = new DatumHandle(0, 19),
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
                    X = 54.32784f,
                    Y = -99.53103f,
                    Z = 3.766346f,
                    Width = 0.015625f,
                    HeightScale = 1f,
                    FieldOfView = Angle.FromDegrees(111.5836f),
                    FalloffDistance = 0.4414063f,
                    CutoffDistance = 2.339835f,
                },
                new Scenario.LightVolumeInstance
                {
                    PaletteIndex = 3,
                    NameIndex = 18,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
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
                    Object = GetCachedTag<Light>($@"levels\ui\mainmenu\lights\campaign"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Light>($@"levels\ui\mainmenu\lights\custom_games"),
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
            scnr.TriggerVolumes = new List<Scenario.TriggerVolume>
            {
                new Scenario.TriggerVolume
                {
                    Name = CacheContext.StringTable.GetStringId($@"kill_happy_place"),
                    ObjectName = -1,
                    Forward = new RealVector3d(1f, 0f, 0f),
                    Up = new RealVector3d(0f, 0f, 1f),
                    Position = new RealPoint3d(-21.9695f, -52.0107f, -10.4079f),
                    Extents = new RealPoint3d(145.663f, 94.9555f, 5.56568f),
                    SectorPoints = new List<Scenario.TriggerVolume.SectorPoint>
                    {
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(-22.4695f, -52.5107f, -10.4079f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(-21.4695f, -52.5107f, -10.4079f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(-21.4695f, -51.5107f, -10.4079f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(-22.4695f, -51.5107f, -10.4079f),
                        },
                    },
                    C = 86.98453f,
                    KillVolume = -1,
                    EditorFolderIndex = -1,
                },
                new Scenario.TriggerVolume
                {
                    Name = CacheContext.StringTable.GetStringId($@"reset_zone"),
                    ObjectName = -1,
                    Forward = new RealVector3d(1f, 0f, 0f),
                    Up = new RealVector3d(0f, 0f, 1f),
                    Position = new RealPoint3d(-2.458626f, -51.08569f, -10.14443f),
                    Extents = new RealPoint3d(123.5976f, 95.69077f, 1f),
                    SectorPoints = new List<Scenario.TriggerVolume.SectorPoint>
                    {
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(-2.958626f, -51.58569f, -10.14443f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(-1.958626f, -51.58569f, -10.14443f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(-1.958626f, -50.58569f, -10.14443f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(-2.958626f, -50.58569f, -10.14443f),
                        },
                    },
                    C = 78.15705f,
                    KillVolume = -1,
                    EditorFolderIndex = -1,
                },
                new Scenario.TriggerVolume
                {
                    Name = CacheContext.StringTable.GetStringId($@"butterfly1"),
                    ObjectName = -1,
                    Forward = new RealVector3d(1f, 0f, 0f),
                    Up = new RealVector3d(0f, 0f, 1f),
                    Position = new RealPoint3d(74.11411f, -82.45804f, 2.461368f),
                    Extents = new RealPoint3d(1f, 1f, 0.6490998f),
                    SectorPoints = new List<Scenario.TriggerVolume.SectorPoint>
                    {
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(73.61411f, -82.95804f, 2.461368f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(74.61411f, -82.95804f, 2.461368f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(74.61411f, -81.95804f, 2.461368f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(73.61411f, -81.95804f, 2.461368f),
                        },
                    },
                    C = 0.7780312f,
                    KillVolume = -1,
                    EditorFolderIndex = -1,
                },
                new Scenario.TriggerVolume
                {
                    Name = CacheContext.StringTable.GetStringId($@"butterfly3"),
                    ObjectName = -1,
                    Forward = new RealVector3d(1f, 0f, 0f),
                    Up = new RealVector3d(0f, 0f, 1f),
                    Position = new RealPoint3d(87.78909f, -103.0991f, 4.803778f),
                    Extents = new RealPoint3d(1f, 1f, 0.581801f),
                    SectorPoints = new List<Scenario.TriggerVolume.SectorPoint>
                    {
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(87.28909f, -103.5991f, 4.803778f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(88.28909f, -103.5991f, 4.803778f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(88.28909f, -102.5991f, 4.803778f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(87.28909f, -102.5991f, 4.803778f),
                        },
                    },
                    C = 0.7646065f,
                    KillVolume = -1,
                    EditorFolderIndex = -1,
                },
                new Scenario.TriggerVolume
                {
                    Name = CacheContext.StringTable.GetStringId($@"butterfly4"),
                    ObjectName = -1,
                    Forward = new RealVector3d(1f, 0f, 0f),
                    Up = new RealVector3d(0f, 0f, 1f),
                    Position = new RealPoint3d(80.21787f, -131.7394f, 3.10355f),
                    Extents = new RealPoint3d(1f, 1f, 0.5047709f),
                    SectorPoints = new List<Scenario.TriggerVolume.SectorPoint>
                    {
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(79.71787f, -132.2394f, 3.10355f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(80.71787f, -132.2394f, 3.10355f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(80.71787f, -131.2394f, 3.10355f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(79.71787f, -131.2394f, 3.10355f),
                        },
                    },
                    C = 0.7507985f,
                    KillVolume = -1,
                    EditorFolderIndex = -1,
                },
                new Scenario.TriggerVolume
                {
                    Name = CacheContext.StringTable.GetStringId($@"butterfly5"),
                    ObjectName = -1,
                    Forward = new RealVector3d(1f, 0f, 0f),
                    Up = new RealVector3d(0f, 0f, 1f),
                    Position = new RealPoint3d(69.50253f, -126.0912f, 2.520827f),
                    Extents = new RealPoint3d(1f, 1f, 0.3573295f),
                    SectorPoints = new List<Scenario.TriggerVolume.SectorPoint>
                    {
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(69.00253f, -126.5912f, 2.520827f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(70.00253f, -126.5912f, 2.520827f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(70.00253f, -125.5912f, 2.520827f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(69.00253f, -125.5912f, 2.520827f),
                        },
                    },
                    C = 0.7293292f,
                    KillVolume = -1,
                    EditorFolderIndex = -1,
                },
                new Scenario.TriggerVolume
                {
                    Name = CacheContext.StringTable.GetStringId($@"butterfly6"),
                    ObjectName = -1,
                    Forward = new RealVector3d(1f, 0f, 0f),
                    Up = new RealVector3d(0f, 0f, 1f),
                    Position = new RealPoint3d(69.42175f, -138.6351f, 1.984781f),
                    Extents = new RealPoint3d(1f, 1f, 0.4536614f),
                    SectorPoints = new List<Scenario.TriggerVolume.SectorPoint>
                    {
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(68.92175f, -139.1351f, 1.984781f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(69.92175f, -139.1351f, 1.984781f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(69.92175f, -138.1351f, 1.984781f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(68.92175f, -138.1351f, 1.984781f),
                        },
                    },
                    C = 0.7425982f,
                    KillVolume = -1,
                    EditorFolderIndex = -1,
                },
                new Scenario.TriggerVolume
                {
                    Name = CacheContext.StringTable.GetStringId($@"fish1"),
                    ObjectName = -1,
                    Forward = new RealVector3d(1f, 0f, 0f),
                    Up = new RealVector3d(0f, 0f, 1f),
                    Position = new RealPoint3d(70.32044f, -42.51495f, -0.6063091f),
                    Extents = new RealPoint3d(9.894438f, 2.832109f, 0.09635192f),
                    SectorPoints = new List<Scenario.TriggerVolume.SectorPoint>
                    {
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(69.82044f, -43.01495f, -0.6063091f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(70.82044f, -43.01495f, -0.6063091f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(70.82044f, -42.01495f, -0.6063091f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(69.82044f, -42.01495f, -0.6063091f),
                        },
                    },
                    C = 5.146116f,
                    KillVolume = -1,
                    EditorFolderIndex = -1,
                },
                new Scenario.TriggerVolume
                {
                    Name = CacheContext.StringTable.GetStringId($@"safe_zone"),
                    ObjectName = -1,
                    Forward = new RealVector3d(1f, 0f, 0f),
                    Up = new RealVector3d(0f, 0f, 1f),
                    Position = new RealPoint3d(38.05488f, -167.7887f, -1.937608f),
                    Extents = new RealPoint3d(68.26272f, 135.9187f, 28.11643f),
                    SectorPoints = new List<Scenario.TriggerVolume.SectorPoint>
                    {
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(37.55488f, -168.2887f, -1.937608f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(38.55488f, -168.2887f, -1.937608f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(38.55488f, -167.2887f, -1.937608f),
                        },
                        new Scenario.TriggerVolume.SectorPoint
                        {
                            Position = new RealPoint3d(37.55488f, -167.2887f, -1.937608f),
                        },
                    },
                    C = 77.33731f,
                    KillVolume = -1,
                    EditorFolderIndex = -1,
                },
            };
            scnr.Decals = new List<Scenario.Decal>
            {
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.3088756f, -0.7408364f, -0.2295281f, 0.5505219f),
                    Position = new RealPoint3d(81.40858f, -131.6638f, 2.997832f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.5100694f, -0.4914713f, -0.5083234f, 0.4897886f),
                    Position = new RealPoint3d(94.50142f, -90.43533f, 2.892195f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.09744459f, 0.1118871f, -0.7457532f, 0.6494906f),
                    Position = new RealPoint3d(57.48366f, -61.4628f, 3.772614f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.06963911f, 0.01594444f, 0.03777948f, 0.9967291f),
                    Position = new RealPoint3d(60.26809f, -65.19424f, 3.028377f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.2782233f, 0.2084563f, 0.2782307f, 0.8953912f),
                    Position = new RealPoint3d(71.14133f, -67.1224f, 1.567849f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.1568411f, 0.07751787f, 0.4128523f, 0.8938371f),
                    Position = new RealPoint3d(58.61062f, -59.19446f, 3.798348f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.06569915f, 0.009311311f, 0.1006994f, 0.9927017f),
                    Position = new RealPoint3d(59.81669f, -63.6609f, 3.205229f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.009739769f, -0.1155903f, 0.9697667f, 0.2147009f),
                    Position = new RealPoint3d(59.856f, -66.19807f, 2.804741f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.01626741f, 0.02428979f, 0.1360812f, 0.9902663f),
                    Position = new RealPoint3d(59.45385f, -61.97139f, 3.242819f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 5,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.5000381f, -0.3970295f, -0.6774865f, 0.3651595f),
                    Position = new RealPoint3d(72.54888f, -80.07672f, 3.835697f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.367743f, 0.586596f, -0.6938356f, 0.198148f),
                    Position = new RealPoint3d(65.2564f, -55.31247f, 0.1375576f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.4521071f, 0.4968194f, -0.4776695f, 0.5662168f),
                    Position = new RealPoint3d(57.41049f, -60.16518f, 3.988863f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.1071917f, 0.168119f, 0.1882039f, 0.9616783f),
                    Position = new RealPoint3d(59.02961f, -60.43009f, 3.378931f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.2819058f, 0.2846658f, 0.6510288f, 0.6447139f),
                    Position = new RealPoint3d(53.03804f, -134.0087f, 20.25928f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.3304707f, 0.2277343f, -0.5029051f, 0.7655147f),
                    Position = new RealPoint3d(58.65825f, -128.149f, 10.73363f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.4186646f, 0.5501264f, -0.5749819f, 0.4375805f),
                    Position = new RealPoint3d(58.90503f, -131.7104f, 11.15071f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.5378227f, 0.1907409f, -0.4063576f, 0.7136092f),
                    Position = new RealPoint3d(53.43893f, -111.9109f, 7.663546f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.5479725f, 0.09434588f, -0.5919964f, 0.5834084f),
                    Position = new RealPoint3d(59.82035f, -152.2642f, 15.72744f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.7726637f, 0.1452507f, -0.2623673f, 0.5595145f),
                    Position = new RealPoint3d(59.86924f, -152.0366f, 22.50921f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.7511351f, 0.2606367f, -0.489525f, 0.3580921f),
                    Position = new RealPoint3d(49.94565f, -113.9594f, 10.97057f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.6862405f, 0.3241844f, -0.278128f, 0.5887472f),
                    Position = new RealPoint3d(51.25474f, -119.508f, 12.54174f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.07580496f, 0.2155513f, -0.9663342f, 0.1182773f),
                    Position = new RealPoint3d(73.76091f, -103.246f, 5.790244f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.1935789f, -0.1390617f, 0.8757148f, 0.4198961f),
                    Position = new RealPoint3d(90.93404f, -102.7564f, 4.753903f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.1643736f, 0.4514954f, 0.7644029f, 0.4299087f),
                    Position = new RealPoint3d(51.65057f, -108.8597f, 7.392409f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.03050356f, 0.3948437f, 0.602929f, 0.6925638f),
                    Position = new RealPoint3d(49.79412f, -115.2829f, 15.96386f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.6352135f, 0.176654f, -0.5627503f, 0.4986074f),
                    Position = new RealPoint3d(48.87526f, -112.393f, 13.93429f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 5,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.5360292f, -0.4561503f, -0.575187f, 0.4168448f),
                    Position = new RealPoint3d(57.19141f, -149.2758f, 10.64648f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.1958259f, 0.02033426f, -0.737435f, 0.6460868f),
                    Position = new RealPoint3d(57.99005f, -145.5367f, 20.37164f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.2158816f, 0.5513003f, 0.6497248f, 0.4767817f),
                    Position = new RealPoint3d(54.90345f, -114.5114f, 8.437094f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.4036468f, 0.1252175f, -0.06806193f, 0.9037463f),
                    Position = new RealPoint3d(68.23815f, -159.4917f, 22.70791f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.6260277f, 0.04880034f, -0.06048489f, 0.7759184f),
                    Position = new RealPoint3d(96.47643f, -160.008f, 20.4165f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.2710184f, 0.5510631f, 0.5641528f, 0.5519149f),
                    Position = new RealPoint3d(47.92206f, -108.9256f, 11.9275f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.6575372f, 0.2430229f, -0.2471757f, 0.6688842f),
                    Position = new RealPoint3d(89.06689f, -161.2624f, 20.00839f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.01793182f, -0.6384707f, -0.7676486f, 0.05243304f),
                    Position = new RealPoint3d(84.83489f, -160.6058f, 19.96896f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.2417424f, -0.09079728f, 0.1466538f, 0.954887f),
                    Position = new RealPoint3d(81.07875f, -160.2315f, 20.52861f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.3662697f, 0.09239979f, 0.2290031f, 0.8971434f),
                    Position = new RealPoint3d(77.75152f, -161.7881f, 20.54082f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.3860696f, 0.6606113f, 0.6194988f, 0.1753965f),
                    Position = new RealPoint3d(74.64334f, -160.8411f, 21.70998f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.2526115f, -0.1047221f, 0.6256403f, 0.7306127f),
                    Position = new RealPoint3d(62.16853f, -118.008f, 10.10375f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.2074201f, -0.05285159f, -0.7435946f, 0.6334435f),
                    Position = new RealPoint3d(49.43737f, -110.3871f, 8.696042f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.1232772f, 0.6475501f, 0.723003f, 0.2067564f),
                    Position = new RealPoint3d(98.25305f, -165.0207f, 29.36814f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.1691241f, 0.5549709f, 0.6748865f, 0.4559964f),
                    Position = new RealPoint3d(50.24484f, -118.8027f, 17.22652f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 5,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.0586569f, 0.6694078f, -0.737749f, 0.06464536f),
                    Position = new RealPoint3d(79.97639f, -110.3503f, 5.139854f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 5,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.3887172f, -0.4196551f, -0.4593739f, 0.6795324f),
                    Position = new RealPoint3d(78.96406f, -109.4261f, 4.782152f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.2349424f, 0.4579188f, -0.7628419f, 0.3913879f),
                    Position = new RealPoint3d(55.77942f, -121.0256f, 9.456711f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.3051438f, 0.1582411f, -0.1001643f, 0.9337098f),
                    Position = new RealPoint3d(49.07438f, -107.7501f, 7.442359f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.159895f, -0.03374315f, -0.5722293f, 0.803647f),
                    Position = new RealPoint3d(61.72005f, -154.987f, 23.47145f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.1584528f, 0.1685733f, 0.07891744f, 0.9696638f),
                    Position = new RealPoint3d(61.06958f, -79.71645f, 16.63528f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.180163f, -0.05727554f, -0.5944955f, 0.7815599f),
                    Position = new RealPoint3d(76.11235f, -100.6299f, 5.451276f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.3259356f, 0.4502973f, 0.5893944f, 0.5861848f),
                    Position = new RealPoint3d(63.02164f, -77.14422f, 15.78646f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.3711284f, 0.3840448f, 0.7291872f, 0.4278543f),
                    Position = new RealPoint3d(62.69308f, -73.9884f, 16.67489f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.1580312f, 0.1958317f, -0.005307307f, 0.9678057f),
                    Position = new RealPoint3d(49.82016f, -78.82528f, 18.05792f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.05607978f, 0.09400085f, 0.942917f, 0.3145258f),
                    Position = new RealPoint3d(74.0909f, -101.8447f, 6.04237f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.08343202f, 0.05770887f, -0.7493435f, 0.6543648f),
                    Position = new RealPoint3d(56.10336f, -60.24374f, 17.60324f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.2244167f, -0.08295013f, -0.4472586f, 0.8618098f),
                    Position = new RealPoint3d(55.92827f, -67.45492f, 17.45127f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.08677798f, 0.1802652f, 0.8484031f, 0.490088f),
                    Position = new RealPoint3d(75.14069f, -100.9392f, 5.712139f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.03572591f, 0.09906066f, -0.3373716f, 0.935463f),
                    Position = new RealPoint3d(91.78743f, -102.0033f, 4.709596f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.06007763f, 0.2110001f, 0.7899176f, 0.5726256f),
                    Position = new RealPoint3d(77.20928f, -100.4021f, 5.192815f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.3233125f, 0.3290795f, -0.4676052f, 0.7540034f),
                    Position = new RealPoint3d(61.42997f, -71.33234f, 17.60388f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.08762327f, -0.05309901f, 0.8507232f, 0.5155314f),
                    Position = new RealPoint3d(79.0357f, -100.9939f, 5.42273f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.2022247f, 0.4371784f, -0.8644007f, 0.1441927f),
                    Position = new RealPoint3d(67.40089f, -83.07915f, 7.727777f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.2627647f, 0.1803022f, 0.610039f, 0.7254642f),
                    Position = new RealPoint3d(55.73917f, -63.61853f, 17.18376f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.08399331f, 0.1912719f, 0.8314272f, 0.5148681f),
                    Position = new RealPoint3d(78.39301f, -100.04f, 4.906557f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.433713f, 0.03335758f, -0.08894089f, 0.89603f),
                    Position = new RealPoint3d(57.11046f, -80.03529f, 17.41428f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.0305926f, 0.002225595f, -0.07252354f, 0.9968949f),
                    Position = new RealPoint3d(58.98486f, -69.34258f, 18.16501f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.158622f, -0.03730903f, -0.2258989f, 0.9604253f),
                    Position = new RealPoint3d(53.01839f, -78.94576f, 17.60519f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.2867993f, 0.09746929f, -0.9076015f, 0.2906981f),
                    Position = new RealPoint3d(68.85674f, -81.95777f, 7.050124f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.1444235f, 0.1068012f, -0.7064273f, 0.6846136f),
                    Position = new RealPoint3d(53.23399f, -129.4586f, 19.9636f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.7243842f, 0.2645978f, -0.4564783f, 0.4437152f),
                    Position = new RealPoint3d(56.75974f, -138.655f, 18.58696f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.6951683f, 0.1801497f, -0.2872717f, 0.6338471f),
                    Position = new RealPoint3d(48.87532f, -108.5324f, 8.045336f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.2685951f, 0.04177799f, -0.6236405f, 0.7329283f),
                    Position = new RealPoint3d(53.98791f, -126.7717f, 14.11778f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 5,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.3502492f, -0.8244956f, -0.2360951f, 0.3765522f),
                    Position = new RealPoint3d(65.34162f, -116.4578f, 6.354395f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.07073479f, -0.0679435f, 0.7650466f, 0.6364622f),
                    Position = new RealPoint3d(62.13837f, -121.4098f, 10.67392f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.09563791f, -0.7452905f, -0.1916545f, 0.6313984f),
                    Position = new RealPoint3d(62.43113f, -122.1666f, 6.906088f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.04249694f, -0.3411525f, -0.3719715f, 0.8622332f),
                    Position = new RealPoint3d(60.80367f, -118.9909f, 6.443466f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.5310147f, 0.230679f, -0.5713336f, 0.5817118f),
                    Position = new RealPoint3d(57.9057f, -148.9727f, 21.38932f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.5569654f, 0.157238f, -0.540611f, 0.610578f),
                    Position = new RealPoint3d(60.61536f, -134.7596f, 12.25565f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.3614497f, 0.1232062f, -0.5414021f, 0.7490381f),
                    Position = new RealPoint3d(56.24725f, -117.5662f, 8.873736f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.3612314f, -0.08765698f, -0.02155443f, 0.9280967f),
                    Position = new RealPoint3d(92.02966f, -164.1309f, 28.36083f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.6423821f, 0.3970486f, -0.4774732f, 0.4491291f),
                    Position = new RealPoint3d(57.75753f, -142.2217f, 19.6771f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.01379138f, 0.3495353f, -0.9174969f, 0.1892992f),
                    Position = new RealPoint3d(74.09759f, -104.0522f, 4.936139f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.1598001f, 0.227817f, -0.4436211f, 0.8519176f),
                    Position = new RealPoint3d(89.98874f, -103.4469f, 4.73792f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.2413338f, 0.05478304f, -0.5769053f, 0.7784198f),
                    Position = new RealPoint3d(52.80744f, -123.0865f, 13.12223f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.1891834f, 0.4409087f, 0.6646429f, 0.5727645f),
                    Position = new RealPoint3d(52.07815f, -122.0365f, 18.28252f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.4401605f, 0.1909179f, -0.5701432f, 0.6668928f),
                    Position = new RealPoint3d(52.98508f, -125.3194f, 19.2582f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.4663822f, 0.5953532f, 0.5150341f, 0.4034626f),
                    Position = new RealPoint3d(61.62156f, -137.7829f, 12.90551f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.4264944f, -0.2441429f, 0.2808981f, 0.8243744f),
                    Position = new RealPoint3d(92.78905f, -160.8074f, 20.01309f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.01798722f, 0.3755046f, 0.9266425f, 0.002525394f),
                    Position = new RealPoint3d(71.47359f, -159.6865f, 22.12662f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.3661869f, -0.1174675f, 0.236636f, 0.8922511f),
                    Position = new RealPoint3d(85.03307f, -167.2609f, 27.65204f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.3371909f, -0.1650071f, 0.2583436f, 0.8901312f),
                    Position = new RealPoint3d(88.34529f, -164.9135f, 27.81711f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 5,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.3929546f, -0.441872f, -0.7086502f, 0.3849034f),
                    Position = new RealPoint3d(59.80511f, -149.5774f, 5.838358f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.159895f, -0.03374315f, -0.5722293f, 0.803647f),
                    Position = new RealPoint3d(62.70861f, -157.8277f, 23.3757f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 5,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.5108268f, -0.6009954f, -0.4779582f, 0.3865445f),
                    Position = new RealPoint3d(58.8975f, -149.8881f, 7.585545f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 5,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.06438278f, 0.04593547f, 0.5787408f, 0.8116674f),
                    Position = new RealPoint3d(81.29334f, -109.1028f, 5.06829f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.7138094f, 0.02262709f, -0.02605156f, 0.6994894f),
                    Position = new RealPoint3d(64.41881f, -159.0691f, 22.97875f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 5,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.2742566f, -0.8381748f, -0.2183993f, 0.4177895f),
                    Position = new RealPoint3d(57.90843f, -149.4552f, 9.167639f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.2997827f, 0.4758272f, 0.6107667f, 0.5573893f),
                    Position = new RealPoint3d(57.3111f, -123.9233f, 10.14919f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.05085022f, 0.2670262f, 0.7536281f, 0.5984616f),
                    Position = new RealPoint3d(55.11987f, -130.5112f, 15.09073f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.008136325f, 0.3840999f, 0.5217029f, 0.7617265f),
                    Position = new RealPoint3d(55.53184f, -134.041f, 16.6412f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.2627193f, 0.3756891f, 0.5674901f, 0.6839527f),
                    Position = new RealPoint3d(62.27257f, -141.1609f, 12.92147f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 4,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.6744268f, -0.182585f, 0.08220626f, 0.7106711f),
                    Position = new RealPoint3d(95.30444f, -165.1817f, 28.85361f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.009314579f, 0.05621992f, 0.9928069f, 0.1052953f),
                    Position = new RealPoint3d(94.4053f, -69.31262f, 2.059201f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.003962002f, -0.7201592f, 0.06866027f, 0.6903918f),
                    Position = new RealPoint3d(98.56435f, -76.77972f, 3.141881f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.1117586f, -0.08017279f, -0.9847122f, 0.1068832f),
                    Position = new RealPoint3d(92.57233f, -74.6038f, 2.385267f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.06198403f, -0.665455f, 0.08717825f, 0.7387337f),
                    Position = new RealPoint3d(99.03311f, -65.82471f, 2.262429f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.01691888f, -0.5726303f, 0.1749939f, 0.8007405f),
                    Position = new RealPoint3d(99.7026f, -67.10416f, 2.494199f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.1237881f, -0.05995154f, -0.9520868f, 0.273154f),
                    Position = new RealPoint3d(91.92931f, -73.14285f, 2.244884f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.03146787f, -0.08669155f, -0.9917272f, 0.08928312f),
                    Position = new RealPoint3d(94.62869f, -66.33283f, 1.610861f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.1424697f, -0.6368616f, -0.1577072f, 0.741106f),
                    Position = new RealPoint3d(98.91936f, -75.25241f, 3.119937f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.1644831f, -0.335425f, -0.3426218f, 0.862001f),
                    Position = new RealPoint3d(77.0457f, -109.2591f, 3.442596f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.08133772f, -0.1082725f, 0.8223596f, 0.5526174f),
                    Position = new RealPoint3d(88.9271f, -103.9066f, 4.613681f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.07679287f, 0.04193131f, -0.7937658f, 0.6018975f),
                    Position = new RealPoint3d(81.47814f, -107.2189f, 4.619741f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.7007855f, -0.113874f, -0.6951231f, 0.1128554f),
                    Position = new RealPoint3d(69.52528f, -139.9141f, 1.999071f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.4653008f, -0.4091089f, -0.3756594f, 0.6892062f),
                    Position = new RealPoint3d(71.00604f, -137.9818f, 1.82525f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.2370446f, -0.6476437f, 0.1926694f, 0.6980301f),
                    Position = new RealPoint3d(65.48866f, -147.3854f, 2.111334f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.5639965f, -0.278634f, 0.6969367f, 0.3443115f),
                    Position = new RealPoint3d(66.55696f, -147.5094f, 1.991015f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.4633745f, 0.3132045f, -0.4642192f, 0.6867952f),
                    Position = new RealPoint3d(64.35957f, -146.8496f, 2.258721f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.3248543f, 0.1450044f, -0.8167405f, 0.4542888f),
                    Position = new RealPoint3d(64.16377f, -148.9359f, 2.828879f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.1066446f, 0.07395204f, -0.3996479f, 0.9074357f),
                    Position = new RealPoint3d(60.97855f, -146.053f, 3.402168f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.0339999f, 0.01916319f, -0.9921269f, 0.1190002f),
                    Position = new RealPoint3d(60.70413f, -147.173f, 3.480088f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.6475982f, -0.3351841f, 0.5485747f, 0.4090649f),
                    Position = new RealPoint3d(66.94882f, -150.0963f, 2.105715f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.08310614f, -0.6318517f, 0.09014513f, 0.7653304f),
                    Position = new RealPoint3d(65.96905f, -149.2213f, 2.144248f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.685663f, -0.1479483f, -0.6966792f, 0.1503851f),
                    Position = new RealPoint3d(67.32489f, -148.9344f, 2.018306f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.10281f, 0.07349625f, -0.886568f, 0.4450009f),
                    Position = new RealPoint3d(62.65037f, -149.001f, 3.415308f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.02211897f, 0.0007968378f, 0.08798109f, 0.9958763f),
                    Position = new RealPoint3d(62.16571f, -147.981f, 3.427704f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.003656866f, 0.002874885f, 0.2480526f, 0.9687354f),
                    Position = new RealPoint3d(61.71766f, -146.398f, 3.389826f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.5072973f, 0.00803352f, 0.8556719f, 0.1020318f),
                    Position = new RealPoint3d(65.2274f, -144.9802f, 2.024678f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.2178946f, -0.5512888f, -0.3977309f, 0.7002947f),
                    Position = new RealPoint3d(68.00347f, -138.4366f, 1.750436f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.4792876f, -0.3249177f, -0.6748447f, 0.4574893f),
                    Position = new RealPoint3d(64.88336f, -143.9331f, 2.047124f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.2293147f, -0.5593497f, -0.0003385013f, 0.7965818f),
                    Position = new RealPoint3d(69.16956f, -136.05f, 1.258161f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.5028508f, -0.2543698f, 0.6202942f, 0.5455934f),
                    Position = new RealPoint3d(70.77663f, -137.4568f, 1.731739f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.6370828f, 0.05974747f, 0.7449309f, 0.1887688f),
                    Position = new RealPoint3d(71.80492f, -136.7256f, 1.272242f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.6006457f, -0.2036795f, -0.6593981f, 0.4036504f),
                    Position = new RealPoint3d(66.173f, -146.7811f, 1.974797f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.2128491f, -0.5190668f, 0.2640882f, 0.7845524f),
                    Position = new RealPoint3d(70.80022f, -139.302f, 1.927104f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.564088f, -0.3691814f, -0.6694153f, 0.3120787f),
                    Position = new RealPoint3d(69.16426f, -138.6129f, 2.028182f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.4823493f, -0.4167244f, -0.5830484f, 0.5037206f),
                    Position = new RealPoint3d(66.40316f, -148.2561f, 2.056533f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.2094129f, -0.5183011f, 0.4609597f, 0.6892216f),
                    Position = new RealPoint3d(68.2924f, -140.4684f, 1.903878f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.5865483f, -0.1419633f, 0.7100639f, 0.36279f),
                    Position = new RealPoint3d(72.00753f, -139.3684f, 1.624456f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.6684718f, 0.01477544f, 0.7415038f, 0.05567188f),
                    Position = new RealPoint3d(72.15874f, -138.2027f, 1.500003f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.2287057f, -0.4469718f, 0.5186554f, 0.6920307f),
                    Position = new RealPoint3d(69.49317f, -137.1206f, 1.775635f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.02920225f, -0.6427533f, 0.1292218f, 0.7545311f),
                    Position = new RealPoint3d(67.50159f, -139.4035f, 1.770429f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.3473238f, -0.7031074f, -0.391667f, 0.4812518f),
                    Position = new RealPoint3d(99.42321f, -97.1481f, 2.700797f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.2146958f, -0.3837796f, 0.575043f, 0.6898873f),
                    Position = new RealPoint3d(93.01928f, -90.83072f, 2.582994f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.231974f, -0.3557055f, 0.6218329f, 0.6580164f),
                    Position = new RealPoint3d(94.2686f, -91.06247f, 2.69877f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.3473238f, -0.7031074f, -0.391667f, 0.4812518f),
                    Position = new RealPoint3d(99.25867f, -97.26614f, 2.682082f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 11,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.009561553f, 0.03604225f, 0.2562392f, 0.9658939f),
                    Position = new RealPoint3d(94.43098f, -146.4183f, 1.015401f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 11,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.05177921f, -0.03446533f, -0.3699403f, 0.926971f),
                    Position = new RealPoint3d(92.49009f, -144.2139f, 0.970699f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 11,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.08863268f, -0.001819715f, -0.9960627f, 0.0001619232f),
                    Position = new RealPoint3d(94.69621f, -144.8515f, 0.9109049f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 11,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.02425364f, -0.02272983f, -0.9906763f, 0.1321195f),
                    Position = new RealPoint3d(91.9004f, -147.3297f, 1.171245f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 11,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.01970511f, 0.003665863f, -0.6959451f, 0.7178153f),
                    Position = new RealPoint3d(92.25574f, -145.7935f, 1.101383f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.0365673f, -0.2222627f, 0.1581683f, 0.9613766f),
                    Position = new RealPoint3d(92.09503f, -130.9368f, 2.455303f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 11,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.0261552f, -0.01758735f, -0.9907546f, 0.1319539f),
                    Position = new RealPoint3d(92.04263f, -148.2222f, 1.21041f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.0148451f, 0.03057829f, 0.9932324f, 0.1110582f),
                    Position = new RealPoint3d(94.41484f, -132.6743f, 4.152791f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.02443137f, 0.07447615f, 0.9946953f, 0.06661437f),
                    Position = new RealPoint3d(94.15314f, -134.0374f, 4.259016f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.0153508f, -0.005722635f, -0.4341565f, 0.9006885f),
                    Position = new RealPoint3d(97.88974f, -135.8907f, 4.314073f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.1762402f, 0.07832589f, -0.5143707f, 0.8355998f),
                    Position = new RealPoint3d(96.78565f, -136.7484f, 4.353363f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 11,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.01930421f, 0.02874027f, 0.03053403f, 0.9989339f),
                    Position = new RealPoint3d(94.91836f, -150.596f, 1.159351f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 11,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.01788536f, 0.009046743f, -0.4666205f, 0.8842304f),
                    Position = new RealPoint3d(93.63743f, -146.9081f, 1.082045f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 11,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.02644348f, 0.01893201f, -0.2505264f, 0.9675634f),
                    Position = new RealPoint3d(93.9791f, -148.3123f, 1.122203f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 11,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.02207477f, 0.01149289f, -0.4665698f, 0.8841342f),
                    Position = new RealPoint3d(92.54633f, -149.9741f, 1.24804f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 11,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.0639982f, 0.02680777f, -0.3854257f, 0.9201265f),
                    Position = new RealPoint3d(95.84917f, -147.8957f, 0.9522315f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.18472f, -0.01436392f, -0.1822085f, 0.9656461f),
                    Position = new RealPoint3d(94.88063f, -135.8977f, 0.7031317f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.007326464f, -0.002295291f, 0.9542376f, 0.2989509f),
                    Position = new RealPoint3d(69.11836f, -115.0621f, 2.134843f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.6640231f, -0.395001f, 0.3728988f, 0.5138035f),
                    Position = new RealPoint3d(54.5234f, -111.9971f, 2.514591f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.09028f, 0.02778975f, 0.8059781f, 0.5843601f),
                    Position = new RealPoint3d(58.53088f, -106.8433f, 1.971378f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.01753903f, 0.02740817f, 0.9994399f, 0.007812379f),
                    Position = new RealPoint3d(71.53432f, -105.0776f, 3.824556f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.4059249f, 0.2347759f, 0.2156258f, 0.8565108f),
                    Position = new RealPoint3d(72.15976f, -107.8738f, 2.296826f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.6820332f, -0.1910904f, -0.6449612f, 0.2869498f),
                    Position = new RealPoint3d(54.78038f, -110.8088f, 2.42012f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.03190436f, -0.06857505f, -0.1132489f, 0.9906837f),
                    Position = new RealPoint3d(58.6023f, -102.5203f, 2.359699f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 5,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.5081803f, -0.5496105f, -0.6294019f, 0.2086487f),
                    Position = new RealPoint3d(66.90836f, -117.4134f, 3.071507f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.008222038f, 0.02863382f, 0.9951763f, 0.09347049f),
                    Position = new RealPoint3d(71.80251f, -103.4206f, 3.742434f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.08431429f, 0.2331757f, -0.9110429f, 0.3294252f),
                    Position = new RealPoint3d(72.01194f, -106.3846f, 3.50651f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.02648674f, 0.1612204f, -0.3629427f, 0.9173762f),
                    Position = new RealPoint3d(61.68584f, -106.9971f, 1.419534f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 5,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.3502492f, -0.8244956f, -0.2360951f, 0.3765522f),
                    Position = new RealPoint3d(66.39545f, -117.1716f, 4.790516f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.3864445f, -0.3293172f, -0.4585063f, 0.7293717f),
                    Position = new RealPoint3d(53.8728f, -110.3911f, 2.776384f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.01521914f, 0.3677747f, -0.9192512f, 0.139597f),
                    Position = new RealPoint3d(72.74876f, -107.2693f, 2.872312f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.040523f, 0.00780827f, -0.7370566f, 0.6745699f),
                    Position = new RealPoint3d(59.69486f, -106.9007f, 2.013793f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.03461774f, -0.06529746f, 0.07459303f, 0.9944716f),
                    Position = new RealPoint3d(58.50029f, -104.1947f, 2.242189f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.001984935f, -0.5257008f, 0.04442554f, 0.8495064f),
                    Position = new RealPoint3d(53.48138f, -111.3828f, 3.057673f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.2448038f, 0.1244541f, -0.4357576f, 0.857145f),
                    Position = new RealPoint3d(51.6951f, -109.7219f, 3.596028f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.01909744f, 0.10558f, 0.9451899f, 0.3083896f),
                    Position = new RealPoint3d(72.69125f, -100.8988f, 3.500545f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.04010073f, -0.1617358f, -0.6760728f, 0.7177459f),
                    Position = new RealPoint3d(60.76481f, -101.5445f, 2.891741f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.142979f, 0.06325389f, 0.7499512f, 0.6427512f),
                    Position = new RealPoint3d(62.23034f, -101.4011f, 3.075819f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.09689439f, 0.6508724f, 0.2921391f, 0.6939967f),
                    Position = new RealPoint3d(66.25954f, -98.98962f, 2.106879f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.00519487f, -0.8422529f, -0.2552669f, 0.4747862f),
                    Position = new RealPoint3d(66.12133f, -112.2584f, 1.922398f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.05216043f, 0.01528555f, -0.6813202f, 0.7299647f),
                    Position = new RealPoint3d(65.22858f, -101.2212f, 2.965594f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.04453876f, 0.0648362f, 0.02574828f, 0.9965689f),
                    Position = new RealPoint3d(65.02526f, -100.4856f, 2.99949f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.007518239f, -0.1532871f, -0.5757464f, 0.8030956f),
                    Position = new RealPoint3d(59.47498f, -101.6299f, 2.636373f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 9,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.07775766f, -0.06645986f, -0.9596474f, 0.2619424f),
                    Position = new RealPoint3d(50.42311f, -106.9371f, 3.447406f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 8,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.1002005f, 0.02056761f, -0.3824765f, 0.9182857f),
                    Position = new RealPoint3d(50.43188f, -106.9148f, 3.442537f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 12,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.6188094f, 0.044916f, -0.7826448f, 0.05024535f),
                    Position = new RealPoint3d(49.34266f, -88.05399f, 3.421568f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.03173904f, -0.008520983f, 0.9979881f, 0.05422393f),
                    Position = new RealPoint3d(69.6114f, -113.8322f, 2.133795f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 11,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.06424461f, -0.01479756f, 0.03457653f, 0.9972252f),
                    Position = new RealPoint3d(90.7523f, -145.4993f, 1.079995f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 1,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.5459507f, -0.1333153f, -0.826641f, 0.02880231f),
                    Position = new RealPoint3d(79.9036f, -130.725f, 3.053133f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 11,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.0166672f, 0.03043423f, 0.9793279f, 0.1992806f),
                    Position = new RealPoint3d(90.7513f, -146.4549f, 1.174931f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.00448635f, -0.1189054f, 0.02506795f, 0.9925789f),
                    Position = new RealPoint3d(80.11355f, -74.37682f, 2.421263f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 12,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.1339342f, -0.2446368f, 0.1949435f, 0.9403253f),
                    Position = new RealPoint3d(80.46696f, -75.80056f, 2.213f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 5,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.516351f, 0.1919562f, -0.004344824f, 0.8345751f),
                    Position = new RealPoint3d(90.8063f, -72.80003f, 2.545537f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.01517955f, 0.1531424f, 0.8687955f, 0.47065f),
                    Position = new RealPoint3d(78.60116f, -97.41161f, 2.065693f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.1170226f, -0.1183593f, -0.9833979f, 0.07228716f),
                    Position = new RealPoint3d(79.43393f, -96.21684f, 0.7502428f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.03325512f, 0.1261291f, 0.8342217f, 0.5357797f),
                    Position = new RealPoint3d(77.33645f, -98.0635f, 2.357715f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.1306677f, 0.1024406f, 0.9618338f, 0.2175034f),
                    Position = new RealPoint3d(83.51705f, -92.10202f, 2.332377f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.06243329f, -0.01507476f, -0.9939433f, 0.08917075f),
                    Position = new RealPoint3d(83.67268f, -95.88175f, 3.058268f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.06877923f, -0.05117397f, -0.9957225f, 0.03445708f),
                    Position = new RealPoint3d(83.14676f, -93.6257f, 2.533007f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.04809333f, -0.1343663f, -0.4679917f, 0.8721334f),
                    Position = new RealPoint3d(73.4345f, -83.94313f, 2.559039f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.1338648f, -0.3362193f, -0.8224148f, 0.4389429f),
                    Position = new RealPoint3d(90.64037f, -100.5526f, 4.21112f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.01186414f, -0.02918183f, -0.3227048f, 0.9459753f),
                    Position = new RealPoint3d(79.77283f, -90.20043f, 1.852907f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.3109f, -0.5677666f, 0.3660882f, 0.6685519f),
                    Position = new RealPoint3d(83.17831f, -94.79202f, 2.06852f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.00217518f, -0.007350233f, -0.2277901f, 0.9736801f),
                    Position = new RealPoint3d(82.01911f, -87.91293f, 1.912134f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.2046945f, -0.08191574f, -0.3623964f, 0.905571f),
                    Position = new RealPoint3d(78.81428f, -91.25012f, 1.514696f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.06123576f, 0.1495805f, 0.8715873f, 0.4628298f),
                    Position = new RealPoint3d(79.74542f, -96.73664f, 1.746542f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.00642789f, -0.004176072f, -0.9982533f, 0.0585788f),
                    Position = new RealPoint3d(81.58815f, -88.04517f, 1.907394f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 8,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.1168014f, 0.02594367f, 0.9493717f, 0.2904785f),
                    Position = new RealPoint3d(76.78657f, -81.34441f, 2.101445f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.0434659f, 0.1197303f, 0.8344622f, 0.5361424f),
                    Position = new RealPoint3d(75.78741f, -98.73463f, 2.654973f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.03178187f, 0.1083401f, 0.9005548f, 0.4198256f),
                    Position = new RealPoint3d(73.67458f, -99.76196f, 3.184784f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.4250692f, 0.2821734f, 0.6243453f, 0.5915128f),
                    Position = new RealPoint3d(83.93176f, -94.60867f, 2.795077f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.1548685f, 0.2500389f, 0.8203657f, 0.4904044f),
                    Position = new RealPoint3d(79.85093f, -99.37483f, 4.513435f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.05807867f, -0.04955383f, -0.5087743f, 0.857508f),
                    Position = new RealPoint3d(74.60075f, -83.58038f, 2.552407f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.0434659f, 0.1197303f, 0.8344622f, 0.5361424f),
                    Position = new RealPoint3d(74.61598f, -99.12776f, 2.923036f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.1469557f, 0.04225257f, 0.9044095f, 0.3983243f),
                    Position = new RealPoint3d(85.10376f, -89.77671f, 2.163718f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.1993494f, 0.07876702f, 0.3756495f, 0.9016336f),
                    Position = new RealPoint3d(91.47647f, -101.0695f, 4.602992f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.1406295f, 0.06034158f, 0.9455084f, 0.2873954f),
                    Position = new RealPoint3d(84.27922f, -90.83993f, 2.179845f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.1303442f, -0.004984809f, -0.3412165f, 0.9308904f),
                    Position = new RealPoint3d(76.27328f, -98.94706f, 2.670481f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.06280094f, 0.2379867f, 0.8298439f, 0.5007768f),
                    Position = new RealPoint3d(81.33457f, -98.77988f, 3.996441f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 9,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.02762228f, 0.1164158f, -0.3041141f, 0.9450921f),
                    Position = new RealPoint3d(76.78015f, -81.33337f, 2.10297f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.1970267f, -0.04442827f, 0.7866579f, 0.583417f),
                    Position = new RealPoint3d(86.49337f, -88.99398f, 2.246085f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.1977341f, 0.1142434f, 0.1657761f, 0.9593582f),
                    Position = new RealPoint3d(82.39587f, -85.30569f, 1.476494f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 3,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(0.02780441f, 0.03671638f, -0.3310344f, 0.942494f),
                    Position = new RealPoint3d(81.30315f, -89.23971f, 1.895658f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.09470973f, -0.06276188f, -0.02178851f, 0.9932856f),
                    Position = new RealPoint3d(82.57278f, -86.61324f, 1.825566f),
                    Scale = 1f,
                },
                new Scenario.Decal
                {
                    DecalPaletteIndex = 2,
                    EditingBoundToBsp = 255,
                    Rotation = new RealQuaternion(-0.01851514f, 0.1442231f, 0.9473217f, 0.2853746f),
                    Position = new RealPoint3d(83.79302f, -94.89103f, 2.898211f),
                    Scale = 1f,
                },
            };
            scnr.DecalPalette = new List<TagReferenceBlock>
            {
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<DecalSystem>($@"levels\shared\decals\multi\riverworld\riverworld_granite_decal"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<DecalSystem>($@"levels\shared\decals\multi\riverworld\riverworld_grass_decal"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<DecalSystem>($@"levels\shared\decals\multi\riverworld\riverworld_ground_decal"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<DecalSystem>($@"levels\shared\decals\multi\riverworld\riverworld_rockblend_decal"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<DecalSystem>($@"levels\shared\decals\multi\riverworld\riverworld_granite_big_decal"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<DecalSystem>($@"levels\shared\decals\multi\riverworld\riverworld_granite_crack_decal"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<DecalSystem>($@"levels\shared\decals\human\damage\mortar_blast_small"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<DecalSystem>($@"levels\shared\decals\human\damage\scorch_sm"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<DecalSystem>($@"levels\shared\decals\human\damage\scorch_tiny"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<DecalSystem>($@"levels\shared\decals\multi\riverworld\weaponpod_blastmark"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<DecalSystem>($@"levels\shared\decals\nature\mud\mud_splat"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<DecalSystem>($@"levels\shared\decals\nature\algae\algae"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<DecalSystem>($@"levels\shared\decals\human\military\datedecal"),
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
            scnr.ScriptSourceFileReferences = new List<TagReferenceBlock>
            {
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<ModelAnimationGraph>($@"objects\characters\cinematic_camera\ui\valhalla\valhalla"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<SoundLooping>($@"sound\vehicles\phantom\phantom_engine_right\phantom_engine_right"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<SoundLooping>($@"sound\vehicles\phantom\phantom_hover_right\phantom_hover_right"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<SoundLooping>($@"sound\vehicles\phantom\phantom_engine_lod\phantom_engine_lod"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<SoundLooping>($@"sound\levels\main_menu\the_world\the_world"),
                },
            };
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
                    Name = CacheContext.StringTable.GetStringId($@"xxxanchorxxx"),
                    Position = new RealPoint3d(82.4f, -143.35f, 4.1f),
                    Facing = new RealEulerAngles2d(Angle.FromDegrees(0.2f), Angle.FromDegrees(0f)),
                    EditorFolderIndex = -1,
                },
            };
            scnr.CutsceneCameraPoints = new List<Scenario.CutsceneCameraPoint>
            {
                new Scenario.CutsceneCameraPoint
                {
                    Name = "campaign_in",
                    Position = new RealPoint3d(88.0001f, -92.89202f, 3.363f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(22.1844f), Angle.FromDegrees(10.87839f), Angle.FromDegrees(4.494625f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "campaign",
                    Position = new RealPoint3d(87.96129f, -92.74828f, 3.363f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(10.6944f), Angle.FromDegrees(13.82072f), Angle.FromDegrees(2.662841f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "campaign_path_02",
                    Position = new RealPoint3d(87.74733f, -92.88589f, 3.363f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(21.3344f), Angle.FromDegrees(8.425151f), Angle.FromDegrees(3.316434f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "campaign_path_03",
                    Position = new RealPoint3d(88.01371f, -92.73856f, 3.363f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(10.1044f), Angle.FromDegrees(14.84068f), Angle.FromDegrees(2.706487f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "campaign_path_04",
                    Position = new RealPoint3d(87.854f, -92.487f, 3.363f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-12.3856f), Angle.FromDegrees(10.20415f), Angle.FromDegrees(2.265426f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "custom_in",
                    Position = new RealPoint3d(80.27019f, -154.412f, 2.433f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(51.79529f), Angle.FromDegrees(3.20953f), Angle.FromDegrees(0.3009008f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "custom_games",
                    Position = new RealPoint3d(80.116f, -154.238f, 2.433f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(46.535f), Angle.FromDegrees(3.194f), Angle.FromDegrees(0.3404699f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "custom_path_02",
                    Position = new RealPoint3d(80.485f, -154.526f, 2.353f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(75.957f), Angle.FromDegrees(10.557f), Angle.FromDegrees(4.827899f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "custom_path_03",
                    Position = new RealPoint3d(79.988f, -153.812f, 2.461f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(21.335f), Angle.FromDegrees(5.93f), Angle.FromDegrees(-4.460439f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "custom_path_04",
                    Position = new RealPoint3d(79.967f, -153.195f, 2.576f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-13.867f), Angle.FromDegrees(-4.908f), Angle.FromDegrees(-0.827791f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "editor",
                    Position = new RealPoint3d(57.28f, -98.474f, 3.535f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-163.306f), Angle.FromDegrees(7.142f), Angle.FromDegrees(2.135f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "editor_in",
                    Position = new RealPoint3d(56.82927f, -97.29866f, 3.535f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-136.8157f), Angle.FromDegrees(5.75354f), Angle.FromDegrees(5.082516f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "editor_path_02",
                    Position = new RealPoint3d(57.23738f, -98.66696f, 3.581f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-167.9762f), Angle.FromDegrees(6.920579f), Angle.FromDegrees(1.551101f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "editor_path_03",
                    Position = new RealPoint3d(57.09472f, -98.09947f, 3.581f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-152.1181f), Angle.FromDegrees(8.016795f), Angle.FromDegrees(3.955584f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "editor_path_04",
                    Position = new RealPoint3d(57.09498f, -98.11095f, 3.499667f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-151.7607f), Angle.FromDegrees(7.625144f), Angle.FromDegrees(3.849416f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "settings_cam",
                    Position = new RealPoint3d(81.131f, -146.166f, 1.3f),
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
                    Position = new RealPoint3d(2.429f, -99.511f, 323.322f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-114.6049f), Angle.FromDegrees(-19.05827f), Angle.FromDegrees(-35.48944f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "server_browser_path_02",
                    Position = new RealPoint3d(2.5744f, -99.6188f, 323.0661f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-117.1435f), Angle.FromDegrees(-25.78415f), Angle.FromDegrees(-40.31187f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "server_browser_path_03",
                    Position = new RealPoint3d(1.9629f, -99.3337f, 323.418f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-93.07613f), Angle.FromDegrees(-2.550249f), Angle.FromDegrees(-39.61562f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "server_browser_path_04",
                    Position = new RealPoint3d(2.4818f, -99.2983f, 323.418f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-113.9313f), Angle.FromDegrees(-13.6645f), Angle.FromDegrees(-28.02653f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_helmet_wide",
                    Position = new RealPoint3d(80.8f, -146.266f, 1.472f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_body_wide",
                    Position = new RealPoint3d(80.8f, -146.295f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_leftshoulder_wide",
                    Position = new RealPoint3d(80.9f, -146.19f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_rightshoulder_wide",
                    Position = new RealPoint3d(81f, -146.266f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_helmet_wide",
                    Position = new RealPoint3d(80.9f, -146.236f, 1.402f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_body_wide",
                    Position = new RealPoint3d(80.8f, -146.266f, 1.322f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_leftshoulder_wide",
                    Position = new RealPoint3d(80.9f, -146.25f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_rightshoulder_wide",
                    Position = new RealPoint3d(80.95f, -146.35f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_helmet_standard",
                    Position = new RealPoint3d(80.8f, -146.35f, 1.472f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_body_standard",
                    Position = new RealPoint3d(80.9f, -146.315f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_leftshoulder_standard",
                    Position = new RealPoint3d(80.9f, -146.25f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_rightshoulder_standard",
                    Position = new RealPoint3d(81f, -146.34f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_helmet_standard",
                    Position = new RealPoint3d(80.9f, -146.29f, 1.402f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_body_standard",
                    Position = new RealPoint3d(80.75f, -146.37f, 1.322f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_leftshoulder_standard",
                    Position = new RealPoint3d(80.9f, -146.34f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_rightshoulder_standard",
                    Position = new RealPoint3d(80.95f, -146.38f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
            };
            scnr.ScenarioResources = new List<Scenario.ScenarioResource>
            {
                new Scenario.ScenarioResource
                {
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
                    Name = CacheContext.StringTable.GetStringId($@"halo_exterior"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                    ReverbCutoffDistance = 1f,
                    ReverbInterpolationSpeed = 0.25f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\riverworld\halo_ext\halo_ext"),
                    AmbienceCutoffDistance = 1f,
                    AmbienceInterpolationSpeed = 0.5f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"interior"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\stone_room"),
                    ReverbCutoffDistance = 1f,
                    ReverbInterpolationSpeed = 0.25f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\riverworld\riverworld_interior\riverworld_interior"),
                    AmbienceCutoffDistance = 1f,
                    AmbienceInterpolationSpeed = 0.5f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"interior_tunnel"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\jay_stone_room"),
                    ReverbCutoffDistance = 1f,
                    ReverbInterpolationSpeed = 0.25f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\riverworld\riverworld_interior\riverworld_interior"),
                    AmbienceCutoffDistance = 1f,
                    AmbienceInterpolationSpeed = 0.5f,
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
                            BackgroundSoundEnvironmentIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                            BackgroundSoundEnvironmentIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                            BackgroundSoundEnvironmentIndex = 1,
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                            BackgroundSoundEnvironmentIndex = 1,
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                            BackgroundSoundEnvironmentIndex = 1,
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                            BackgroundSoundEnvironmentIndex = 2,
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                            BackgroundSoundEnvironmentIndex = 2,
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                            BackgroundSoundEnvironmentIndex = 1,
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                            BackgroundSoundEnvironmentIndex = 1,
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                            BackgroundSoundEnvironmentIndex = -1,
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                        },
                        new Scenario.ScenarioClusterDatum.BackgroundSoundEnvironment
                        {
                            BackgroundSoundEnvironmentIndex = 1,
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
                    BspChecksum = 270403843,
                    ClusterCentroids = new List<Scenario.ScenarioClusterDatum.ClusterCentroid>
                    {
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(3.402823E+38f, 3.402823E+38f, 3.402823E+38f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(3.402823E+38f, 3.402823E+38f, 3.402823E+38f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(82.84087f, -96.46999f, 40.79322f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(65.2701f, -61.65044f, 1.980395f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(66.849f, -80.18284f, 3.711214f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(100.3106f, -147.311f, 2.651293f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(96.94389f, -140.1779f, 2.645175f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(85.23431f, -58.90442f, 0.7385194f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(81.60001f, -145.585f, 1.36969f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(77.96514f, -58.89861f, 0.7385134f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(96.26842f, -64.25711f, 2.479578f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(96.02724f, -84.18967f, 3.78875f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(93.20638f, -119.0272f, 4.000105f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(77.96567f, -145.494f, 1.633218f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(82.455f, -91.63342f, 2.674819f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(82.45215f, -112.0428f, 3.373944f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(82.47041f, -141.6037f, 2.676378f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(97.45629f, -98.68887f, 3.580498f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(58.30901f, -126.9668f, 2.625137f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(66.49993f, -139.8856f, 2.658127f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(81.59998f, -58.80921f, 0.4749884f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(74.46475f, -10.79367f, -0.8697488f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(83.42303f, -61.79715f, 2.080521f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(3.402823E+38f, 3.402823E+38f, 3.402823E+38f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(60.9361f, -101.58f, 2.650201f),
                        },
                        new Scenario.ScenarioClusterDatum.ClusterCentroid
                        {
                            Centroid = new RealPoint3d(85.23483f, -145.494f, 1.633221f),
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
                2, 13, 62, 90, 0, 0, 270, 272, 3, 0,
                256, 192, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0,
            };
            scnr.SpawnData = new List<Scenario.SpawnDatum>
            {
                new Scenario.SpawnDatum
                {
                    GameObjectResetHeight = -4f,
                },
            };
            scnr.Crates = new List<Scenario.CrateInstance>
            {
                new Scenario.CrateInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(81.5977f, -141.485f, 2.75009f),
                    UniqueHandle = new DatumHandle(33344, 0),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6012f, -62.8223f, 1.79816f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(33344, 1),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 2,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.9019f, -104.075f, 4.83276f),
                    UniqueHandle = new DatumHandle(22752, 26),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Neutral,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 4f,
                        BoundaryPositiveHeight = 1.5f,
                        BoundaryNegativeHeight = 2f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    Position = new RealPoint3d(83.6514f, -102.729f, 4.92305f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(50.649f), Angle.FromDegrees(2.4522E-08f), Angle.FromDegrees(3.10183f)),
                    UniqueHandle = new DatumHandle(29908, 30),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        SpawnOrder = -1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 7,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(55.2181f, -93.367f, 3.39098f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(0.00315627f), Angle.FromDegrees(0.152158f), Angle.FromDegrees(-0.143134f)),
                    UniqueHandle = new DatumHandle(55836, 40),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 8,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(55.2781f, -94.43f, 3.37838f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-0.161738f), Angle.FromDegrees(1.45908f), Angle.FromDegrees(3.96555f)),
                    UniqueHandle = new DatumHandle(55836, 42),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 9,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(54.8503f, -93.4026f, 3.39398f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(118.878f), Angle.FromDegrees(-1.42381f), Angle.FromDegrees(-0.0332819f)),
                    UniqueHandle = new DatumHandle(55836, 43),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 6,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(55.1228f, -94.1875f, 3.68882f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-1.4065f), Angle.FromDegrees(-0.310194f), Angle.FromDegrees(-89.9454f)),
                    UniqueHandle = new DatumHandle(55836, 47),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 2,
                    NameIndex = -1,
                    Position = new RealPoint3d(58.495f, -99.4875f, 2.28512f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0.892326f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(61288, 48),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 4f,
                        BoundaryPositiveHeight = 1.5f,
                        BoundaryNegativeHeight = 2f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 2,
                    NameIndex = -1,
                    Position = new RealPoint3d(97.3108f, -104.583f, 3.4546f),
                    UniqueHandle = new DatumHandle(61288, 49),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 4f,
                        BoundaryPositiveHeight = 1.5f,
                        BoundaryNegativeHeight = 2f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    Position = new RealPoint3d(62.3146f, -104.132f, 4.03979f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-151.69f), Angle.FromDegrees(1.82319f), Angle.FromDegrees(-1.25808f)),
                    UniqueHandle = new DatumHandle(63656, 50),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        SpawnOrder = -1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(97.58749f, -102.2085f, 3.353781f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-96.31224f), Angle.FromDegrees(6.914569f), Angle.FromDegrees(-2.89644f)),
                    UniqueHandle = new DatumHandle(63656, 51),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        SpawnOrder = -1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 10,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(80.7472f, -142.03f, 4.2433f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(90.0081f), Angle.FromDegrees(0.0697498f), Angle.FromDegrees(90f)),
                    UniqueHandle = new DatumHandle(1432, 52),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 9,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(80.8345f, -142.667f, 4.10471f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(177.329f), Angle.FromDegrees(-0.230709f), Angle.FromDegrees(-0.397928f)),
                    UniqueHandle = new DatumHandle(1432, 53),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 10,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(82.3423f, -61.9768f, 3.3484f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(89.959f), Angle.FromDegrees(-0.0162934f), Angle.FromDegrees(89.9557f)),
                    UniqueHandle = new DatumHandle(1432, 54),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 11,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(83.2876f, -62.0242f, 2.45998f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-0.0009941329f), Angle.FromDegrees(-0.0248938f), Angle.FromDegrees(0.00130895f)),
                    UniqueHandle = new DatumHandle(1432, 55),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 5,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 11,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(83.287f, -62.1586f, 2.46016f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-0.0193956f), Angle.FromDegrees(0.341322f), Angle.FromDegrees(-0.12768f)),
                    UniqueHandle = new DatumHandle(1432, 56),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 5,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 11,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(95.3214f, -93.6129f, 2.54849f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(2.58068f), Angle.FromDegrees(-38.1643f), Angle.FromDegrees(86.2996f)),
                    UniqueHandle = new DatumHandle(1436, 61),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 5,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 11,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(96.7029f, -98.2882f, 2.90641f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-41.4827f), Angle.FromDegrees(-55.271f), Angle.FromDegrees(85.0975f)),
                    UniqueHandle = new DatumHandle(1436, 62),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 5,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(97.415f, -104.005f, 3.43122f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(5.08809f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(1440, 64),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Asymmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 4f,
                        BoundaryPositiveHeight = 2f,
                        BoundaryNegativeHeight = 0.5f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(66.8165f, -127.02f, 1.49332f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-79.73471f), Angle.FromDegrees(12.25162f), Angle.FromDegrees(9.74352f)),
                    UniqueHandle = new DatumHandle(1440, 65),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Asymmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 4f,
                        BoundaryPositiveHeight = 2f,
                        BoundaryNegativeHeight = 0.5f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(95.9943f, -83.4863f, 3.22161f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(10.8234f), Angle.FromDegrees(2.09226f), Angle.FromDegrees(-1.16793f)),
                    UniqueHandle = new DatumHandle(1440, 66),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Asymmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 3,
                        Shape = MultiplayerObjectBoundaryShape.Cylinder,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 3.3f,
                        BoundaryPositiveHeight = 1.8f,
                        BoundaryNegativeHeight = 0.5f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(63.515f, -83.6171f, 2.2964f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(136.977f), Angle.FromDegrees(-1.84222f), Angle.FromDegrees(10.4759f)),
                    UniqueHandle = new DatumHandle(1440, 67),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Asymmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 3.5f,
                        BoundaryPositiveHeight = 2f,
                        BoundaryNegativeHeight = 0.5f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6071f, -57.9788f, 1.47689f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(1440, 68),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Asymmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 4,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 3f,
                        BoundaryPositiveHeight = 2f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 16,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(51.18001f, -107.3762f, 3.464443f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(5.650116f), Angle.FromDegrees(74.38197f), Angle.FromDegrees(1.959057f)),
                    UniqueHandle = new DatumHandle(1512, 71),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        QuotaMaximum = 3,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 16,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(95.0155f, -97.5372f, 2.92663f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(95.9787f), Angle.FromDegrees(79.8178f), Angle.FromDegrees(94.5635f)),
                    UniqueHandle = new DatumHandle(1512, 72),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        QuotaMaximum = 3,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 16,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(100.013f, -101.708f, 3.83229f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-61.2035f), Angle.FromDegrees(37.4607f), Angle.FromDegrees(101.167f)),
                    UniqueHandle = new DatumHandle(1512, 73),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        QuotaMaximum = 3,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 11,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(102.312f, -104.858f, 3.82136f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(164.523f), Angle.FromDegrees(-65.4259f), Angle.FromDegrees(81.706f)),
                    UniqueHandle = new DatumHandle(1512, 74),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 5,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 18,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6071f, -57.9788f, 1.52532f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(4156, 78),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 19,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6071f, -57.9788f, 1.47689f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(4156, 79),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 18,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.63f, -146.506f, 2.43179f),
                    UniqueHandle = new DatumHandle(4156, 80),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 19,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.63f, -146.506f, 2.38217f),
                    UniqueHandle = new DatumHandle(4156, 81),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 21,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6093f, -61.0276f, 2.10034f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-45f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(6884, 84),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 20,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.5551f, -58.3443f, -0.0497548f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(6884, 85),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 21,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6111f, -143.387f, 2.99493f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(45f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(6884, 86),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 20,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.5931f, -146.064f, 0.844945f),
                    UniqueHandle = new DatumHandle(6884, 87),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 8,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(92.2137f, -91.8829f, 2.57696f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-0.298925f), Angle.FromDegrees(1.62492f), Angle.FromDegrees(-12.1614f)),
                    UniqueHandle = new DatumHandle(8972, 91),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 22,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6071f, -57.9788f, 1.47689f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(10964, 95),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Asymmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 22,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.63f, -146.506f, 2.38217f),
                    UniqueHandle = new DatumHandle(10964, 93),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Asymmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 22,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(95.9026f, -100.872f, 3.21009f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-96.1524f), Angle.FromDegrees(10.226f), Angle.FromDegrees(-2.07378E-07f)),
                    UniqueHandle = new DatumHandle(25408, 107),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Asymmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 22,
                    NameIndex = -1,
                    Position = new RealPoint3d(57.0105f, -98.4585f, 2.43212f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(53.8965f), Angle.FromDegrees(-10.512f), Angle.FromDegrees(7.579f)),
                    UniqueHandle = new DatumHandle(25408, 108),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Asymmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 3,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 17,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(84.4004f, -153.901f, 1.54089f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-7.70968f), Angle.FromDegrees(-72.0696f), Angle.FromDegrees(99.942f)),
                    UniqueHandle = new DatumHandle(11636, 97),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        QuotaMaximum = 3,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 17,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(84.4789f, -154.151f, 1.48953f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(14.4356f), Angle.FromDegrees(-2.42724f), Angle.FromDegrees(0.829414f)),
                    UniqueHandle = new DatumHandle(11636, 98),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        QuotaMaximum = 3,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 12,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(76.6112f, -51.3018f, 0.525322f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(99.4492f), Angle.FromDegrees(45.475f), Angle.FromDegrees(89.3162f)),
                    UniqueHandle = new DatumHandle(11636, 99),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        QuotaMaximum = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 17,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(76.293f, -51.6978f, 0.397189f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(131.484f), Angle.FromDegrees(7.26191f), Angle.FromDegrees(-6.87392f)),
                    UniqueHandle = new DatumHandle(11636, 100),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        QuotaMaximum = 3,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 21,
                    NameIndex = -1,
                    Position = new RealPoint3d(83.6342f, -102.709f, 4.92467f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(45f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(20404, 101),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Neutral,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 23,
                    NameIndex = -1,
                    Position = new RealPoint3d(77.6742f, -101.999f, 5.3752f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(41.1875f), Angle.FromDegrees(-7.399169f), Angle.FromDegrees(4.48083f)),
                    UniqueHandle = new DatumHandle(20404, 102),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Neutral,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 23,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6071f, -57.9788f, 1.47689f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(20404, 103),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 23,
                    NameIndex = -1,
                    Position = new RealPoint3d(57.0105f, -98.4585f, 2.43212f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(53.8965f), Angle.FromDegrees(-10.512f), Angle.FromDegrees(7.579f)),
                    UniqueHandle = new DatumHandle(20404, 104),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 23,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.63f, -146.506f, 2.38217f),
                    UniqueHandle = new DatumHandle(20404, 105),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 3,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 23,
                    NameIndex = -1,
                    Position = new RealPoint3d(97.58749f, -102.2085f, 3.353781f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-96.31224f), Angle.FromDegrees(6.914569f), Angle.FromDegrees(-2.89644f)),
                    UniqueHandle = new DatumHandle(20408, 106),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 4,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 22,
                    NameIndex = -1,
                    Position = new RealPoint3d(57.0105f, -98.4585f, 2.43212f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(53.8965f), Angle.FromDegrees(-10.512f), Angle.FromDegrees(7.579f)),
                    UniqueHandle = new DatumHandle(25408, 109),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Symmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 22,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(95.9026f, -100.872f, 3.21009f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-96.1524f), Angle.FromDegrees(10.226f), Angle.FromDegrees(-2.07378E-07f)),
                    UniqueHandle = new DatumHandle(25408, 110),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Symmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 22,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.63f, -146.506f, 2.38217f),
                    UniqueHandle = new DatumHandle(25408, 111),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Symmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 22,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6071f, -57.9788f, 1.47689f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(25408, 112),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Symmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 3,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(70.7251f, -127.831f, 2.87516f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(4.446648f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(25788, 113),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Symmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 3f,
                        BoundaryPositiveHeight = 2f,
                        BoundaryNegativeHeight = 2f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(93.3272f, -118.508f, 3.44034f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(5.08809f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(25788, 114),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Symmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        Shape = MultiplayerObjectBoundaryShape.Cylinder,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 3f,
                        BoundaryPositiveHeight = 2f,
                        BoundaryNegativeHeight = 0.5f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(83.61036f, -102.9507f, 4.906605f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(5.56306f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(25788, 115),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Symmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 4f,
                        BoundaryPositiveHeight = 2f,
                        BoundaryNegativeHeight = 1f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(95.9943f, -83.4863f, 3.22161f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(10.8234f), Angle.FromDegrees(2.09226f), Angle.FromDegrees(-1.16793f)),
                    UniqueHandle = new DatumHandle(25788, 116),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Symmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        Shape = MultiplayerObjectBoundaryShape.Cylinder,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 3.3f,
                        BoundaryPositiveHeight = 1.8f,
                        BoundaryNegativeHeight = 0.5f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(75.20548f, -80.30006f, 2.33234f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(-7.496149f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(25788, 117),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Symmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 3f,
                        BoundaryPositiveHeight = 2f,
                        BoundaryNegativeHeight = 0.5f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 1,
                    NameIndex = -1,
                    Position = new RealPoint3d(77.5905f, -143.266f, 2.63948f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(45f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(53816, 119),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 1,
                    NameIndex = -1,
                    Position = new RealPoint3d(77.5784f, -61.1388f, 1.84828f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(135f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(53816, 120),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(85.6133f, -121.082f, 2.98847f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(2.99796f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 252,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
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
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 74,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 44,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 7,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 4,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1163,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15321,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6386,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28227,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 156,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5403,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3566,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13100,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29328,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 798,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -70,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17334,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5552,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -14988,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22753,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 799,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -133,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 360,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3670,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2783,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 11983,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30147,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 820,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56568, 127),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(72.4726f, -77.9601f, 3.01574f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(164.65f), Angle.FromDegrees(-4.44972f), Angle.FromDegrees(0f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 254,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
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
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1156,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1166,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23238,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23042,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 60,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 62,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 35,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 42,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 9,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1084,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15456,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5890,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28265,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 157,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -293,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6615,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3565,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28990,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 796,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -72,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17567,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5239,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -15221,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22492,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 798,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -135,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 359,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3686,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 11763,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30233,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 822,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56568, 131),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(71.2153f, -74.4041f, 3.21789f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-86.7571f), Angle.FromDegrees(-0.415209f), Angle.FromDegrees(-3.52906f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 254,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
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
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1185,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1192,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23220,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23057,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 82,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 52,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 49,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 35,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 8,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 417,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15289,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6022,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28345,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 157,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -293,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6991,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3386,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13225,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28955,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 796,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -72,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17407,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5335,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -15241,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22581,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 798,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -135,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 359,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3561,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2886,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 11803,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30221,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 821,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 124,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56568, 132),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 25,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(71.6165f, -78.0496f, 3.24951f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-33.7462f), Angle.FromDegrees(-5.29115f), Angle.FromDegrees(-7.71016f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 252,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
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
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 75,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 44,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 7,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 4,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1195,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15317,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6392,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28227,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 156,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5427,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3560,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13099,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29324,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 798,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -70,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17332,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5551,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -14988,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22754,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 799,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -133,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 360,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3669,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2785,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 11988,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30145,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 820,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56572, 133),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(74.6567f, -83.129f, 2.49623f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(6.72464f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 252,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
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
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 74,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 44,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 7,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 4,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1161,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15321,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6385,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28227,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 156,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5401,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3567,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13100,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29328,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 798,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -70,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17334,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5550,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -14988,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22754,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 799,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -133,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 360,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3670,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2784,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 11988,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30144,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 820,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56572, 134),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(87.0449f, -106.241f, 4.01366f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(164.65f), Angle.FromDegrees(1.30201f), Angle.FromDegrees(0f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 254,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
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
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1185,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1182,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23119,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23159,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 78,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -9,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 47,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1528,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15292,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6466,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28207,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 156,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5092,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3554,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13037,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29413,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 798,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -69,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17265,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5642,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -14918,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22829,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 799,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -133,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 360,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3663,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2790,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 12050,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30120,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 820,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56572, 135),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(88.5995f, -114.545f, 2.69899f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-171.057f), Angle.FromDegrees(1.18676f), Angle.FromDegrees(0.535613f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 254,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
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
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1185,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1182,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23119,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23159,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 78,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -9,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 46,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 4,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1527,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15283,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6465,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28212,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 156,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5077,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3556,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13032,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29417,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 798,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -69,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17264,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5642,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -14915,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22831,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 799,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -133,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 360,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3660,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2793,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 12047,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30121,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 820,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56572, 137),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(93.7792f, -128.393f, 3.48919f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(78.572f), Angle.FromDegrees(0.0890814f), Angle.FromDegrees(-1.29896f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 254,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
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
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1186,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1183,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23118,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23159,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 78,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -9,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 46,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1529,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15291,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6467,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28207,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 156,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5087,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3555,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13036,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29414,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 798,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -69,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17265,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5642,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -14918,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22828,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 799,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -133,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 360,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3663,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2791,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 12050,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30120,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 820,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56572, 139),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(90.2448f, -128.221f, 2.67069f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(164.65f), Angle.FromDegrees(-2.09624f), Angle.FromDegrees(0f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 254,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
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
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1168,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1172,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23189,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23090,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 68,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 40,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 4,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -98,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15398,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6158,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28259,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 156,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5916,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3580,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13194,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29184,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 797,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -71,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17440,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5406,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -15102,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22631,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 799,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -134,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 359,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3677,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2776,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 11885,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30185,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 821,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56572, 140),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(74.4966f, -86.7925f, 2.12612f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(164.65f), Angle.FromDegrees(-2.09624f), Angle.FromDegrees(-6.26744f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 254,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
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
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1077,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1078,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23158,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23131,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -8,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 11,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -7,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 10,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -4,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 98,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 16006,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6201,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 27910,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 878,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 157,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -296,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3760,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 4209,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13176,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29465,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 796,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -256,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -70,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17834,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5375,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -14735,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22573,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 801,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -133,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 358,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5493,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2201,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 11981,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29918,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 821,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56572, 144),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(88.3602f, -99.9714f, 3.63971f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(176.914f), Angle.FromDegrees(-7.41199f), Angle.FromDegrees(-15.8917f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 254,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
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
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -955,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 953,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23117,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23183,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -110,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -16,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 4,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -68,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -15,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 514,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 16685,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6202,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 27505,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 875,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 157,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -297,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 2709,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 4709,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13092,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29542,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 795,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -72,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -18933,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5201,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -14226,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22039,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 804,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -129,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 357,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 7131,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1482,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 12019,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29599,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 821,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56572, 145),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 26,
                    NameIndex = -1,
                    Position = new RealPoint3d(55.473f, -93.9713f, 3.97739f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(106.149f), Angle.FromDegrees(1.42243f), Angle.FromDegrees(0.0354396f)),
                    UniqueHandle = new DatumHandle(57868, 146),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        QuotaMaximum = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 27,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(55.7763f, -93.7475f, 3.51947f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(12.2654f), Angle.FromDegrees(1.35789f), Angle.FromDegrees(-2.20627f)),
                    UniqueHandle = new DatumHandle(57868, 147),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        QuotaMaximum = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 25,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(91.5979f, -130.075f, 2.4999f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-56.7772f), Angle.FromDegrees(6.34539f), Angle.FromDegrees(10.6483f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 254,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
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
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1185,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1182,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23119,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23159,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 79,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -9,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 47,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1529,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6463,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28207,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 156,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5172,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3532,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13034,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29403,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 798,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -69,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17263,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5644,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -14918,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22830,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 799,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -133,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 360,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3662,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2790,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 12043,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30123,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 820,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(61608, 150),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 29,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6033f, -148.224f, 9.43382f),
                    UniqueHandle = new DatumHandle(4432, 156),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 29,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6054f, -148.246f, 11.4267f),
                    UniqueHandle = new DatumHandle(4436, 157),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 29,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6068f, -148.246f, 13.4394f),
                    UniqueHandle = new DatumHandle(4436, 158),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 29,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.599f, -56.1892f, 8.31408f),
                    UniqueHandle = new DatumHandle(4436, 159),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 29,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.5976f, -56.2105f, 10.3039f),
                    UniqueHandle = new DatumHandle(4436, 160),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 29,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.59657f, -56.20533f, 12.35192f),
                    UniqueHandle = new DatumHandle(4436, 161),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 33,
                    NameIndex = -1,
                    Position = new RealPoint3d(72.13075f, -7.151678f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 172),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 33,
                    NameIndex = -1,
                    Position = new RealPoint3d(72.10191f, -7.930175f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 173),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 34,
                    NameIndex = -1,
                    Position = new RealPoint3d(71.47431f, -7.118358f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 174),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 34,
                    NameIndex = -1,
                    Position = new RealPoint3d(71.48746f, -7.902164f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 175),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 35,
                    NameIndex = -1,
                    Position = new RealPoint3d(70.91357f, -7.03483f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 176),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 35,
                    NameIndex = -1,
                    Position = new RealPoint3d(70.92479f, -7.886478f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 177),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 36,
                    NameIndex = -1,
                    Position = new RealPoint3d(70.36563f, -7.144942f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 178),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 36,
                    NameIndex = -1,
                    Position = new RealPoint3d(70.35686f, -7.839686f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 179),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 37,
                    NameIndex = -1,
                    Position = new RealPoint3d(69.77449f, -7.128363f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 180),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 37,
                    NameIndex = -1,
                    Position = new RealPoint3d(69.80562f, -7.815611f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 181),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 38,
                    NameIndex = -1,
                    Position = new RealPoint3d(69.17648f, -7.101247f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 182),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 38,
                    NameIndex = -1,
                    Position = new RealPoint3d(69.17175f, -7.832245f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 183),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 39,
                    NameIndex = -1,
                    Position = new RealPoint3d(68.54926f, -7.124963f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 184),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 39,
                    NameIndex = -1,
                    Position = new RealPoint3d(68.55874f, -7.756835f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 185),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 40,
                    NameIndex = -1,
                    Position = new RealPoint3d(67.96917f, -7.030532f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 186),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 40,
                    NameIndex = -1,
                    Position = new RealPoint3d(68.01935f, -7.707038f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 187),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 41,
                    NameIndex = -1,
                    Position = new RealPoint3d(67.41357f, -7.055074f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 188),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 41,
                    NameIndex = -1,
                    Position = new RealPoint3d(67.37775f, -7.718326f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 189),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 42,
                    NameIndex = -1,
                    Position = new RealPoint3d(66.82541f, -7.047056f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 190),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 42,
                    NameIndex = -1,
                    Position = new RealPoint3d(66.88258f, -7.681393f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 191),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
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
                new Scenario.CrateInstance
                {
                    PaletteIndex = 43,
                    NameIndex = 25,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(3.068f, -102.909f, 328.322f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-135.244f), Angle.FromDegrees(-18.04f), Angle.FromDegrees(-18.975f)),
                    UniqueHandle = new DatumHandle(0, 28),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = 0,
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
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\riverworld\man_cannon_river\man_cannon_river"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\riverworld\man_cannon_river_short\man_cannon_river_short"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\covenant\military\crate_space\crate_space"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\case_ap_turret\case_ap_turret"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\antennae_mast\antennae_mast"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\generator\generator"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\fusion_coil\fusion_coil"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\drum_12gal\drum_12gal"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\bunkerworld\drum_55gal_bunker\drum_55gal_bunker"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\crate_packing_lid\crate_packing_lid"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\resupply_capsule_unfired\resupply_capsule_unfired"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\resupply_capsule_panel\resupply_capsule_panel"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\blitzcan\blitzcan"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\100_citadel\foliage\plant_tree_pine\plant_tree_pine"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\100_citadel\foliage\plant_tree_pine\plant_tree_pine"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\hu_mil_radio_small\hu_mil_radio_small"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\camping_stool_mp\camping_stool_mp"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\100_citadel\foliage\plant_pine_tree_large\plant_pine_tree_large"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\physics\nutblocker_1x1x2\nutblocker_1x1x2"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_sender\teleporter_sender"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_reciever\teleporter_reciever"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_2way\teleporter_2way"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\box_l\box_l"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\box_m\box_m"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\box_xl\box_xl"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\box_xxl\box_xxl"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\box_xxxl\box_xxxl"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_l\wall_l"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_m\wall_m"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_xl\wall_xl"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_xxl\wall_xxl"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_xxxl\wall_xxxl"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x20x20_black_mainmenu"),
                },
            };
            scnr.FlockPalette = new List<TagReferenceBlock>
            {
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Flock>($@"objects\characters\ambient_life\butterfly"),
                },
                new TagReferenceBlock
                {
                    Instance = GetCachedTag<Flock>($@"objects\characters\ambient_life\school_of_fish"),
                },
            };
            scnr.Flocks = new List<Scenario.Flock>
            {
                new Scenario.Flock
                {
                    Name = CacheContext.StringTable.GetStringId($@"flocks_0"),
                    BoundingTriggerVolume = 2,
                    Sources = new List<Scenario.Flock.Source>
                    {
                        new Scenario.Flock.Source
                        {
                            Position = new RealPoint3d(74.5816f, -81.9802f, 2.62561f),
                            Unknown3 = 24,
                        },
                    },
                    ProductionFrequencyBounds = new Bounds<float>(1f, 3f),
                    ScaleBounds = new Bounds<float>(0.3f, 0.5f),
                    BoidCountBounds = new Bounds<short>(1, 3),
                    EnemyFlockIndex = -1,
                },
                new Scenario.Flock
                {
                    Name = CacheContext.StringTable.GetStringId($@"flocks_2"),
                    BoundingTriggerVolume = 3,
                    Sources = new List<Scenario.Flock.Source>
                    {
                        new Scenario.Flock.Source
                        {
                            Position = new RealPoint3d(88.24947f, -102.7769f, 5.045903f),
                            Unknown3 = 3,
                        },
                    },
                    ProductionFrequencyBounds = new Bounds<float>(1f, 3f),
                    ScaleBounds = new Bounds<float>(0.3f, 0.5f),
                    CreaturePaletteIndex = 1,
                    BoidCountBounds = new Bounds<short>(1, 3),
                    EnemyFlockIndex = -1,
                },
                new Scenario.Flock
                {
                    Name = CacheContext.StringTable.GetStringId($@"flocks_3"),
                    BoundingTriggerVolume = 4,
                    Sources = new List<Scenario.Flock.Source>
                    {
                        new Scenario.Flock.Source
                        {
                            Position = new RealPoint3d(80.59695f, -131.2931f, 3.198282f),
                            Unknown3 = 21,
                        },
                    },
                    ProductionFrequencyBounds = new Bounds<float>(1f, 3f),
                    ScaleBounds = new Bounds<float>(0.3f, 0.5f),
                    CreaturePaletteIndex = 2,
                    BoidCountBounds = new Bounds<short>(1, 3),
                    EnemyFlockIndex = -1,
                },
                new Scenario.Flock
                {
                    Name = CacheContext.StringTable.GetStringId($@"flocks_4"),
                    BoundingTriggerVolume = 5,
                    Sources = new List<Scenario.Flock.Source>
                    {
                        new Scenario.Flock.Source
                        {
                            Position = new RealPoint3d(70.05345f, -125.7628f, 2.642699f),
                            Unknown3 = 14,
                        },
                    },
                    ProductionFrequencyBounds = new Bounds<float>(1f, 3f),
                    ScaleBounds = new Bounds<float>(0.3f, 0.5f),
                    CreaturePaletteIndex = 1,
                    BoidCountBounds = new Bounds<short>(1, 3),
                    EnemyFlockIndex = -1,
                },
                new Scenario.Flock
                {
                    Name = CacheContext.StringTable.GetStringId($@"flocks_5"),
                    BoundingTriggerVolume = 6,
                    Sources = new List<Scenario.Flock.Source>
                    {
                        new Scenario.Flock.Source
                        {
                            Position = new RealPoint3d(69.98444f, -138.1781f, 2.144473f),
                            Unknown3 = 14,
                        },
                    },
                    ProductionFrequencyBounds = new Bounds<float>(1f, 3f),
                    ScaleBounds = new Bounds<float>(0.3f, 0.5f),
                    BoidCountBounds = new Bounds<short>(1, 3),
                    EnemyFlockIndex = -1,
                },
                new Scenario.Flock
                {
                    Name = CacheContext.StringTable.GetStringId($@"flocks_6"),
                    FlockPaletteIndex = 1,
                    BoundingTriggerVolume = 7,
                    Flags = Scenario.Flock.FlockFlags.HardBoundariesOnVolume,
                    Sources = new List<Scenario.Flock.Source>
                    {
                        new Scenario.Flock.Source
                        {
                            Position = new RealPoint3d(70.3503f, -40.21881f, -0.4763723f),
                            Unknown3 = 26,
                        },
                    },
                    ProductionFrequencyBounds = new Bounds<float>(1f, 50f),
                    ScaleBounds = new Bounds<float>(1f, 1f),
                    CreaturePaletteIndex = 3,
                    BoidCountBounds = new Bounds<short>(1, 50),
                    EnemyFlockIndex = -1,
                },
            };
            scnr.CreaturePalette = new List<Scenario.ScenarioPaletteEntry>
            {
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Creature>($@"objects\characters\ambient_life\butterfly_b\butterfly_b"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Creature>($@"objects\characters\ambient_life\butterfly_c\butterfly_c"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Creature>($@"objects\characters\ambient_life\butterfly_d\butterfly_d"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Creature>($@"objects\characters\ambient_life\fish_elephantnose\fish_elephantnose"),
                },
            };
            scnr.EditorFolders = null;
            scnr.TerritoryLocationNameStrings = GetCachedTag<MultilingualUnicodeStringList>($@"levels\multi\riverworld\location_names");
            scnr.DefaultCameraFx = GetCachedTag<CameraFxSettings>($@"levels\multi\riverworld\riverworld");
            scnr.DefaultScreenFx = GetCachedTag<AreaScreenEffect>($@"levels\ui\mainmenu\sky\ui");
            scnr.SkyParameters = GetCachedTag<SkyAtmParameters>($@"levels\multi\riverworld\sky\riverworld");
            scnr.GlobalLighting = GetCachedTag<ChocolateMountainNew>($@"levels\multi\riverworld\riverworld");
            scnr.Lightmap = GetCachedTag<ScenarioLightmap>($@"levels\multi\riverworld\riverworld_faux_lightmap");
            scnr.PerformanceThrottles = GetCachedTag<PerformanceThrottles>($@"levels\multi\riverworld\riverworld");
            scnr.ZoneDebugger = new List<Scenario.ScenarioZoneDebuggerBlock>
            {
                new Scenario.ScenarioZoneDebuggerBlock
                {
                },
            };
            scnr.SoftSurfaces = new List<Scenario.SoftSurfaceBlock>
            {
                new Scenario.SoftSurfaceBlock
                {
                },
            };
            scnr.Cubemaps = new List<Scenario.ScenarioCubemapBlock>
            {
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(80.19458f, -51.38171f, 1.824643f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(81.71145f, -59.5614f, 2.560666f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(81.64847f, -58.27871f, 0.4820546f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(84.97848f, -60.12692f, 0.5681884f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(78.42068f, -60.22985f, 0.6963562f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(91.50751f, -57.87242f, 1.639455f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(89.909f, -65.05421f, 1.46482f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(72.84368f, -66.26369f, 1.034049f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(66.67052f, -60.08491f, 1.833611f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(77.24481f, -76.36968f, 3.091276f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(71.06926f, -76.25665f, 4.241061f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(92.5886f, -72.37463f, 3.187249f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(85.25848f, -75.36571f, 4.230526f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(95.85832f, -84.93658f, 4.013674f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(88.64452f, -86.58798f, 2.770069f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(84.89268f, -82.53936f, 2.028811f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(82.19319f, -90.42306f, 1.686346f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(78.78374f, -80.30921f, 2.927868f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(72.2747f, -83.72393f, 3.684051f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(76.77083f, -87.4715f, 2.890861f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(98.09371f, -99.44921f, 3.589631f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(93.72466f, -97.03368f, 3.694042f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(96.44839f, -103.2815f, 4.184314f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(84.74885f, -102.2248f, 5.825804f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(77.70767f, -95.46682f, 1.880123f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(68.78527f, -102.4058f, 1.689129f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(72.84061f, -101.3604f, 4.288534f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(75.90286f, -102.2227f, 6.482164f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(56.97542f, -96.79195f, 3.744645f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(59.87835f, -115.0964f, 2.769306f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(92.63599f, -107.7481f, 4.401352f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(86.70174f, -111.1492f, 4.306562f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(93.22816f, -118.7683f, 4.069979f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(92.9252f, -120.7023f, 3.999263f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(89.19994f, -125.7544f, 4.276506f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(94.03622f, -140.37f, 3.105697f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(80.41667f, -132.9065f, 4.399556f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(59.74866f, -127.701f, 2.198936f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(74.84837f, -117.8732f, 3.741452f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(78.83826f, -123.5672f, 3.716349f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(74.95103f, -129.4096f, 2.906229f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(68.63022f, -146.805f, 3.407478f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(85.86871f, -156.6746f, 3.471827f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(81.50268f, -144.9884f, 3.526986f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(81.47287f, -151.392f, 2.591429f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(78.07981f, -148.8058f, 2.994562f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(85.06729f, -147.7641f, 3.01857f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(81.63562f, -145.9615f, 1.527623f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(85.45378f, -146.7975f, 1.356559f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(84.74953f, -144.0842f, 1.558575f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(77.5742f, -146.9595f, 1.508532f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(78.56918f, -144.0688f, 1.430023f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(76.4024f, -136.0615f, 2.252129f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(77.83821f, -38.45194f, 16.23702f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
                new Scenario.ScenarioCubemapBlock
                {
                    CubemapPosition = new RealPoint3d(74.84098f, -37.37106f, 5.300495f),
                    CubemapResolution = Scenario.ScenarioCubemapBlock.CubemapResolutionEnum._128,
                },
            };
            CacheContext.Serialize(Stream, tag, scnr);

            CompileScript(tag, $@"{Program.TagToolDirectory}\Tools\BaseCache\Scripts\mainmenu.hsc");
        }
    }
}
