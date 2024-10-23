using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Scenarios
{
    public class ConvertPlacementLightprobesCommand : Command 
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnlineBase CacheContext { get; set; }
        public Scenario Scnr { get; set; }

        public ConvertPlacementLightprobesCommand(GameCache cache, GameCacheHaloOnlineBase cacheContext, Scenario scnr) : base
        (
            false,
            "ConvertPlacementLightprobes",
            "Converts Scenario Object Lightprobes into Airprobes",

            "ConvertPlacementLightprobes",
            "Converts Scenario Object Lightprobes into Airprobes"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Scnr = scnr;
        }

        public override object Execute(List<string> args) 
        {
            var sceneryInstances = new Dictionary<int, Scenario.SceneryInstance>();
            var machineInstances = new Dictionary<int, Scenario.MachineInstance>();

            using (var stream = Cache.OpenCacheReadWrite())
            {
                var sLdT = CacheContext.Deserialize<ScenarioLightmap>(stream, Scnr.Lightmap);
                sLdT.Airprobes = new List<Airprobe>();

                for (int i = 0; i < sLdT.SceneryLightProbes.Count; i++)
                {
                    var sceneryLightProbe = sLdT.SceneryLightProbes[i];

                    sLdT.Airprobes.Add(new Airprobe
                    {
                        Name = CacheContext.StringTable.GetOrAddString($"scenery_airprobe_{i}"),
                        LightProbe = sceneryLightProbe.LightProbe,
                    });

                    for (int j = 0; j < Scnr.Scenery.Count; j++)
                    {
                        var sceneryPlacement = Scnr.Scenery[j];

                        if (sceneryLightProbe.ObjectId.UniqueHandle == sceneryPlacement.UniqueHandle)
                        {
                            sLdT.Airprobes[i].Position = sceneryPlacement.Position;

                            sceneryInstances.TryAdd(j, sceneryPlacement);
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

                        for (int k = 0; k < Scnr.Machines.Count; k++)
                        {
                            var machinePlacement = Scnr.Machines[k];

                            if (machineLightProbes.ObjectId.UniqueHandle == machinePlacement.UniqueHandle)
                            {
                                sLdT.Airprobes[sLdT.Airprobes.Count + j - 1].Position = machinePlacement.Position;

                                machineInstances.TryAdd(k, machinePlacement);
                            }
                        }
                    }
                }

                for (int i = 0; i < sLdT.PerPixelLightmapDataReferences.Count; i++)
                {
                    var lbsp = CacheContext.Deserialize<ScenarioLightmapBspData>(stream, sLdT.PerPixelLightmapDataReferences[i].LightmapBspData);
                    lbsp.Airprobes = new List<Airprobe>();

                    for (int j = 0; j < lbsp.SceneryLightProbes.Count; j++)
                    {
                        var sceneryLightProbe = lbsp.SceneryLightProbes[j];

                        lbsp.Airprobes.Add(new Airprobe
                        {
                            Name = CacheContext.StringTable.GetOrAddString($"scenery_airprobe_{j}"),
                            LightProbe = sceneryLightProbe.LightProbe,
                        });

                        for (int k = 0; k < Scnr.Scenery.Count; k++)
                        {
                            var sceneryPlacement = Scnr.Scenery[k];

                            if (sceneryLightProbe.ObjectId.UniqueHandle == sceneryPlacement.UniqueHandle)
                            {
                                lbsp.Airprobes[j].Position = sceneryPlacement.Position;

                                sceneryInstances.TryAdd(k, sceneryPlacement);
                            }
                        }
                    }

                    for (int j = 0; j < lbsp.MachineLightProbes.Count; j++)
                    {
                        var machineLightProbes = lbsp.MachineLightProbes[j];

                        for (int k = 0; k < machineLightProbes.LightProbes.Count; k++)
                        {
                            var machineLightProbe = machineLightProbes.LightProbes[k];

                            lbsp.Airprobes.Add(new Airprobe
                            {
                                Name = CacheContext.StringTable.GetOrAddString($"machine_airprobe_{j}"),
                                LightProbe = machineLightProbe.LightProbe,
                            });

                            for (int l = 0; l < Scnr.Machines.Count; l++)
                            {
                                var machinePlacement = Scnr.Machines[l];

                                if (machineLightProbes.ObjectId.UniqueHandle == machinePlacement.UniqueHandle)
                                {
                                    lbsp.Airprobes[lbsp.Airprobes.Count + k - 1].Position = machinePlacement.Position;

                                    machineInstances.TryAdd(l, machinePlacement);
                                }
                            }
                        }
                    }

                    lbsp.SceneryLightProbes = null;
                    lbsp.MachineLightProbes = null;

                    CacheContext.Serialize(stream, sLdT.PerPixelLightmapDataReferences[i].LightmapBspData, lbsp);
                }

                foreach (var placement in sceneryInstances)
                {
                    var placementIndex = placement.Key;
                    var placementInstance = placement.Value;

                    Scnr.Scenery[placementIndex].UniqueHandle = DatumHandle.None;

                    var sceneryObject = CacheContext.Deserialize<Scenery>(stream, Scnr.SceneryPalette[placementInstance.PaletteIndex].Object);
                    var sceneryModel = CacheContext.Deserialize<Model>(stream, sceneryObject.Model);

                    sceneryModel.Flags |= Model.FlagsValue.ModelUseAirprobeLighting;

                    CacheContext.Serialize(stream, sceneryObject.Model, sceneryModel);
                }

                foreach (var placement in machineInstances)
                {
                    var placementIndex = placement.Key;
                    var placementInstance = placement.Value;

                    Scnr.Machines[placementIndex].UniqueHandle = DatumHandle.None;

                    var machineObject = CacheContext.Deserialize<DeviceMachine>(stream, Scnr.MachinePalette[placementInstance.PaletteIndex].Object);
                    var machineModel = CacheContext.Deserialize<Model>(stream, machineObject.Model);

                    machineModel.Flags |= Model.FlagsValue.ModelUseAirprobeLighting;

                    CacheContext.Serialize(stream, machineObject.Model, machineModel);
                }

                sLdT.SceneryLightProbes = null;
                sLdT.MachineLightProbes = null;

                CacheContext.Serialize(stream, Scnr.Lightmap, sLdT);
            }

            return true;
        }
    }
}
