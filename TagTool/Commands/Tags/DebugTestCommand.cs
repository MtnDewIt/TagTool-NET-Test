using System.Collections.Generic;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.JSON.Objects;
using TagTool.JSON.Handlers;
using TagTool.Tags.Definitions;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Commands.Common;
using System;
using System.IO;
using TagTool.IO;
using TagTool.BlamFile;
using Newtonsoft.Json;
using TagTool.BlamFile.MCC;
using System.Linq;

namespace TagTool.Commands.Tags
{
    class DebugTestCommand : Command
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnlineBase CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }

        public DebugTestCommand(GameCache cache, GameCacheHaloOnlineBase cacheContext, CommandContextStack contextStack) : base
        (
            false,
            "DebugTest",
            "Self Explanatory",

            "DebugTest",
            "Self Explanatory"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            ContextStack = contextStack;
        }

        public override object Execute(List<string> args)
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                var tag = CacheContext.TagCache.GetTag(args[0]);
                var scnr = CacheContext.Deserialize<Scenario>(stream, tag);

                var sLdT = CacheContext.Deserialize<ScenarioLightmap>(stream, scnr.Lightmap);
                sLdT.Airprobes = new List<Airprobe>();

                var lbsp = CacheContext.Deserialize<ScenarioLightmapBspData>(stream, sLdT.PerPixelLightmapDataReferences[0].LightmapBspData);
                lbsp.Airprobes = new List<Airprobe>();

                for (int i = 0; i < scnr.Scenery.Count; i++) 
                {
                    var sceneryPlacement = scnr.Scenery[i];

                    var hasLightProbe = false;

                    for (int j = 0; j < sLdT.SceneryLightProbes.Count; j++) 
                    {
                        var sceneryLightProbe = sLdT.SceneryLightProbes[j];

                        if (sceneryPlacement.UniqueHandle == sceneryLightProbe.ObjectId.UniqueHandle) 
                        {
                            Console.WriteLine($"Adding Lightmap Air Probe For Scenario Scenery Object {i}");
                            sLdT.Airprobes.Add(new Airprobe
                            {
                                Position = sceneryPlacement.Position,
                                Name = CacheContext.StringTable.GetOrAddString("scenery_airprobe"),
                                LightProbe = sceneryLightProbe.LightProbe,
                            });

                            hasLightProbe = true;
                        }
                    }

                    for (int k = 0; k < lbsp.SceneryLightProbes.Count; k++) 
                    {
                        var sceneryLightProbe = lbsp.SceneryLightProbes[k];

                        if (sceneryPlacement.UniqueHandle == sceneryLightProbe.ObjectId.UniqueHandle)
                        {
                            Console.WriteLine($"Adding Bsp Air Probe For Scenario Scenery Object {i}");
                            lbsp.Airprobes.Add(new Airprobe
                            {
                                Position = sceneryPlacement.Position,
                                Name = CacheContext.StringTable.GetOrAddString("scenery_airprobe"),
                                LightProbe = sceneryLightProbe.LightProbe,
                            });

                            hasLightProbe = true;
                        }
                    }

                    if (hasLightProbe) 
                    {
                        Console.WriteLine($"Resetting Handle for Scenario Scenery Object {i}");
                        sceneryPlacement.UniqueHandle = DatumHandle.None;
                    }
                }

                for (int i = 0; i < scnr.Machines.Count; i++) 
                {
                    var machinePlacement = scnr.Scenery[i];

                    var hasLightProbe = false;

                    for (int j = 0; j < sLdT.MachineLightProbes.Count; j++) 
                    {
                        var machineLightProbe = sLdT.SceneryLightProbes[j];

                        if (machinePlacement.UniqueHandle == machineLightProbe.ObjectId.UniqueHandle)
                        {
                            Console.WriteLine($"Adding Lightmap Air Probe For Scenario Machine Object {i}");
                            sLdT.Airprobes.Add(new Airprobe
                            {
                                Position = machinePlacement.Position,
                                Name = CacheContext.StringTable.GetOrAddString("machine_airprobe"),
                                LightProbe = machineLightProbe.LightProbe,
                            });

                            hasLightProbe = true;
                        }
                    }

                    for (int k = 0; k < lbsp.MachineLightProbes.Count; k++) 
                    {
                        var machineLightProbe = lbsp.SceneryLightProbes[k];

                        if (machinePlacement.UniqueHandle == machineLightProbe.ObjectId.UniqueHandle)
                        {
                            Console.WriteLine($"Adding Bsp Air Probe For Scenario Machine Object {i}");
                            lbsp.Airprobes.Add(new Airprobe
                            {
                                Position = machinePlacement.Position,
                                Name = CacheContext.StringTable.GetOrAddString("machine_airprobe"),
                                LightProbe = machineLightProbe.LightProbe,
                            });

                            hasLightProbe = true;
                        }
                    }

                    if (hasLightProbe)
                    {
                        Console.WriteLine($"Resetting Handle for Scenario Machine Object {i}");
                        machinePlacement.UniqueHandle = DatumHandle.None;
                    }
                }

                sLdT.SceneryLightProbes = null;
                sLdT.MachineLightProbes = null;
                lbsp.SceneryLightProbes = null;
                lbsp.MachineLightProbes = null;

                CacheContext.Serialize(stream, scnr.Lightmap, sLdT);
                CacheContext.Serialize(stream, sLdT.PerPixelLightmapDataReferences[0].LightmapBspData, lbsp);
                CacheContext.Serialize(stream, tag, scnr);
            }
            
            return true;
        }
    }
}
