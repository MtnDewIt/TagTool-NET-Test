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

                // TODO: Maybe loop through each lbsp in a given lightmap?
                var lbsp = CacheContext.Deserialize<ScenarioLightmapBspData>(stream, sLdT.PerPixelLightmapDataReferences[0].LightmapBspData);
                lbsp.Airprobes = new List<Airprobe>();
                
                for (int i = 0; i < sLdT.SceneryLightProbes.Count; i++)
                {
                    var sceneryLightProbe = sLdT.SceneryLightProbes[i];

                    sLdT.Airprobes.Add(new Airprobe
                    {
                        Name = CacheContext.StringTable.GetOrAddString($"scenery_airprobe_{i}"),
                        LightProbe = sceneryLightProbe.LightProbe,
                    });

                    for (int j = 0; j < scnr.Scenery.Count; j++)
                    {
                        var sceneryPlacement = scnr.Scenery[j];

                        if (sceneryLightProbe.ObjectId.UniqueHandle == sceneryPlacement.UniqueHandle)
                        {
                            sLdT.Airprobes[i].Position = sceneryPlacement.Position;
                            sceneryPlacement.UniqueHandle = DatumHandle.None;

                            var sceneryObject = CacheContext.Deserialize<Scenery>(stream, scnr.SceneryPalette[sceneryPlacement.PaletteIndex].Object);
                            var sceneryModel = CacheContext.Deserialize<Model>(stream, sceneryObject.Model);

                            sceneryModel.Flags |= Model.FlagsValue.ModelUseAirprobeLighting;

                            CacheContext.Serialize(stream, sceneryObject.Model, sceneryModel);
                        }
                    }
                }
    
                for (int i = 0; i < lbsp.SceneryLightProbes.Count; i++)
                {
                    var sceneryLightProbe = lbsp.SceneryLightProbes[i];

                    lbsp.Airprobes.Add(new Airprobe
                    {
                        Name = CacheContext.StringTable.GetOrAddString($"scenery_airprobe_{i}"),
                        LightProbe = sceneryLightProbe.LightProbe,
                    });

                    for (int j = 0; j < scnr.Scenery.Count; j++)
                    {
                        var sceneryPlacement = scnr.Scenery[j];

                        if (sceneryLightProbe.ObjectId.UniqueHandle == sceneryPlacement.UniqueHandle)
                        {
                            lbsp.Airprobes[i].Position = sceneryPlacement.Position;
                            sceneryPlacement.UniqueHandle = DatumHandle.None;

                            var sceneryObject = CacheContext.Deserialize<Scenery>(stream, scnr.SceneryPalette[sceneryPlacement.PaletteIndex].Object);
                            var sceneryModel = CacheContext.Deserialize<Model>(stream, sceneryObject.Model);

                            sceneryModel.Flags |= Model.FlagsValue.ModelUseAirprobeLighting;

                            CacheContext.Serialize(stream, sceneryObject.Model, sceneryModel);
                        }
                    }
                }
    
                for (int i = 0; i < sLdT.MachineLightProbes.Count; i++)
                {
                    var machineLightProbes = sLdT.MachineLightProbes[i];

                    for (int j = 0; j < machineLightProbes.LightProbes.Count; j++)
                    {
                        var machineLightProbe = machineLightProbes.LightProbes[j];

                        sLdT.Airprobes.Add(new Airprobe
                        {
                            Name = CacheContext.StringTable.GetOrAddString($"machine_airprobe_{i}"),
                            LightProbe = machineLightProbe.LightProbe,
                        });

                        for (int k = 0; k < scnr.Machines.Count; k++)
                        {
                            var machinePlacement = scnr.Machines[k];

                            if (machineLightProbes.ObjectId.UniqueHandle == machinePlacement.UniqueHandle)
                            {
                                sLdT.Airprobes[sLdT.Airprobes.Count + j - 1].Position = machinePlacement.Position;
                                machinePlacement.UniqueHandle = DatumHandle.None;

                                var machineObject = CacheContext.Deserialize<DeviceMachine>(stream, scnr.MachinePalette[machinePlacement.PaletteIndex].Object);
                                var machineModel = CacheContext.Deserialize<Model>(stream, machineObject.Model);

                                machineModel.Flags |= Model.FlagsValue.ModelUseAirprobeLighting;

                                CacheContext.Serialize(stream, machineObject.Model, machineModel);
                            }
                        }
                    }
                }
    
                for (int i = 0; i < lbsp.MachineLightProbes.Count; i++)
                {
                    var machineLightProbes = lbsp.MachineLightProbes[i];

                    for (int j = 0; j < machineLightProbes.LightProbes.Count; j++)
                    {
                        var machineLightProbe = machineLightProbes.LightProbes[j];

                        lbsp.Airprobes.Add(new Airprobe
                        {
                            Name = CacheContext.StringTable.GetOrAddString($"machine_airprobe_{i}"),
                            LightProbe = machineLightProbe.LightProbe,
                        });

                        for (int k = 0; k < scnr.Machines.Count; k++)
                        {
                            var machinePlacement = scnr.Machines[k];

                            if (machineLightProbes.ObjectId.UniqueHandle == machinePlacement.UniqueHandle)
                            {
                                lbsp.Airprobes[lbsp.Airprobes.Count + j - 1].Position = machinePlacement.Position;
                                machinePlacement.UniqueHandle = DatumHandle.None;

                                var machineObject = CacheContext.Deserialize<DeviceMachine>(stream, scnr.MachinePalette[machinePlacement.PaletteIndex].Object);
                                var machineModel = CacheContext.Deserialize<Model>(stream, machineObject.Model);

                                machineModel.Flags |= Model.FlagsValue.ModelUseAirprobeLighting;

                                CacheContext.Serialize(stream, machineObject.Model, machineModel);
                            }
                        }
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
