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
                var convertedSceneryCount = 0;
                var convertedMachineCount = 0;

                var tag = CacheContext.TagCache.GetTag(args[0]);
                var scnr = CacheContext.Deserialize<Scenario>(stream, tag);

                var sLdT = CacheContext.Deserialize<ScenarioLightmap>(stream, scnr.Lightmap);
                sLdT.Airprobes = new List<Airprobe>();

                // TODO: Maybe loop through each lbsp in a given lightmap?
                var lbsp = CacheContext.Deserialize<ScenarioLightmapBspData>(stream, sLdT.PerPixelLightmapDataReferences[0].LightmapBspData);
                lbsp.Airprobes = new List<Airprobe>();

                Console.WriteLine($"Total Scenery LightProbe Count: {sLdT.SceneryLightProbes.Count + lbsp.SceneryLightProbes.Count}");
                Console.WriteLine($"Total Machine LightProbe Count: {GetMachineLightProbeCount(sLdT, lbsp)}");

                for (int i = 0; i < scnr.Scenery.Count; i++)
                {
                    var sceneryPlacement = scnr.Scenery[i];

                    var hasLightProbe = false;

                    for (int j = 0; j < sLdT.SceneryLightProbes.Count; j++)
                    {
                        var sceneryLightProbe = sLdT.SceneryLightProbes[j];

                        if (sceneryPlacement.UniqueHandle == sceneryLightProbe.ObjectId.UniqueHandle)
                        {
                            //Console.WriteLine($"Adding Lightmap Air Probe For Scenario Scenery Object {i}");
                            sLdT.Airprobes.Add(new Airprobe
                            {
                                Position = sceneryPlacement.Position,
                                Name = CacheContext.StringTable.GetOrAddString($"scenery_airprobe_{i}"),
                                LightProbe = sceneryLightProbe.LightProbe,
                            });

                            hasLightProbe = true;
                            convertedSceneryCount++;
                        }
                    }

                    for (int k = 0; k < lbsp.SceneryLightProbes.Count; k++)
                    {
                        var sceneryLightProbe = lbsp.SceneryLightProbes[k];

                        if (sceneryPlacement.UniqueHandle == sceneryLightProbe.ObjectId.UniqueHandle)
                        {
                            //Console.WriteLine($"Adding Bsp Air Probe For Scenario Scenery Object {i}");
                            lbsp.Airprobes.Add(new Airprobe
                            {
                                Position = sceneryPlacement.Position,
                                Name = CacheContext.StringTable.GetOrAddString($"scenery_airprobe_{i}"),
                                LightProbe = sceneryLightProbe.LightProbe,
                            });

                            hasLightProbe = true;
                            convertedSceneryCount++;
                        }
                    }

                    if (hasLightProbe)
                    {
                        //Console.WriteLine($"Resetting Handle for Scenario Scenery Object {i}");
                        sceneryPlacement.UniqueHandle = DatumHandle.None;
                    }
                }

                for (int i = 0; i < scnr.Machines.Count; i++)
                {
                    var machinePlacement = scnr.Machines[i];

                    var hasLightProbe = false;

                    for (int j = 0; j < sLdT.MachineLightProbes.Count; j++)
                    {
                        var machineLightProbes = sLdT.MachineLightProbes[j];

                        if (machinePlacement.UniqueHandle == machineLightProbes.ObjectId.UniqueHandle)
                        {
                            //Console.WriteLine($"Adding Lightmap Air Probes For Scenario Machine Object {i}");

                            for (int k = 0; k < machineLightProbes.LightProbes.Count; k++)
                            {
                                var machineLightProbe = machineLightProbes.LightProbes[k];

                                sLdT.Airprobes.Add(new Airprobe
                                {
                                    Position = machinePlacement.Position,
                                    Name = CacheContext.StringTable.GetOrAddString($"machine_airprobe_{i}"),
                                    LightProbe = machineLightProbe.LightProbe,
                                });

                                convertedMachineCount++;
                            }

                            hasLightProbe = true;
                        }
                    }

                    for (int k = 0; k < lbsp.MachineLightProbes.Count; k++)
                    {
                        var machineLightProbes = lbsp.MachineLightProbes[k];

                        if (machinePlacement.UniqueHandle == machineLightProbes.ObjectId.UniqueHandle)
                        {
                            //Console.WriteLine($"Adding Bsp Air Probes For Scenario Machine Object {i}");

                            for (int l = 0; l < machineLightProbes.LightProbes.Count; l++)
                            {
                                var machineLightProbe = machineLightProbes.LightProbes[l];

                                lbsp.Airprobes.Add(new Airprobe
                                {
                                    Position = machinePlacement.Position,
                                    Name = CacheContext.StringTable.GetOrAddString($"machine_airprobe_{i}"),
                                    LightProbe = machineLightProbe.LightProbe,
                                });

                                convertedMachineCount++;
                            }

                            hasLightProbe = true;
                        }
                    }

                    if (hasLightProbe)
                    {
                        //Console.WriteLine($"Resetting Handle for Scenario Machine Object {i}");
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

                Console.WriteLine($"Converted Scenery LightProbe Count: {convertedSceneryCount}");
                Console.WriteLine($"Converted Machine LightProbe Count: {convertedMachineCount}");
            }

            return true;
        }

        public int GetMachineLightProbeCount(ScenarioLightmap sLdT, ScenarioLightmapBspData lbsp)
        {
            var totalMachineLightProbeCount = 0;

            for (var i = 0; i < sLdT.MachineLightProbes.Count; i++)
            {
                totalMachineLightProbeCount += sLdT.MachineLightProbes[i].LightProbes.Count;
            }

            for (var i = 0; i < lbsp.MachineLightProbes.Count; i++)
            {
                totalMachineLightProbeCount += lbsp.MachineLightProbes[i].LightProbes.Count;
            }

            return totalMachineLightProbeCount;
        }
    }
}
