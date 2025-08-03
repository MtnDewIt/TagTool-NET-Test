using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags.Definitions;
using TagTool.Tags.Definitions.Common;

namespace TagTool.Porting.Gen3
{
    public partial class PortingContextGen3
    {
        private ObjectTypeFlags ConvertObjectTypeFlags(ObjectTypeFlags flags)
        {
            switch (BlamCache.Version)
            {
                case CacheVersion.Halo2Vista:
                case CacheVersion.Halo2Xbox:
                    if (!Enum.TryParse(flags.Halo2.ToString(), out flags.Halo3ODST))
                        throw new FormatException(BlamCache.Version.ToString());
                    break;

                case CacheVersion.Halo3Retail:
                    if (!Enum.TryParse(flags.Halo3Retail.ToString(), out flags.Halo3ODST))
                        throw new FormatException(BlamCache.Version.ToString());
                    break;
            }

            return flags;
        }

        private GameObject ConvertGameObject(Stream cacheStream, Stream blamCacheStream, GameObject gameobject)
        {
            //fix AI object avoidance
            if (gameobject.Model != null)
            {
                var childmodeltag = CacheContext.TagCache.GetTag(gameobject.Model.Index);
                if (childmodeltag.DefinitionOffset > 0) //sometimes a tag that isn't ported yet can be referenced here, which causes a crash
                {
                    var childmodel = CacheContext.Deserialize<Model>(cacheStream, childmodeltag);
                    if (childmodel.CollisionModel != null)
                    {
                        var childcollisionmodel = CacheContext.Deserialize<CollisionModel>(cacheStream, childmodel.CollisionModel);
                        if (childcollisionmodel.PathfindingSpheres.Count > 0)
                        {
                            gameobject.PathfindingSpheres = new List<GameObject.PathfindingSphere>();
                            for (var i = 0; i < childcollisionmodel.PathfindingSpheres.Count; i++)
                            {
                                gameobject.PathfindingSpheres.Add(new GameObject.PathfindingSphere
                                {
                                    Node = childcollisionmodel.PathfindingSpheres[i].Node,
                                    Flags = (GameObject.PathfindingSphereFlags)childcollisionmodel.PathfindingSpheres[i].Flags,
                                    Center = childcollisionmodel.PathfindingSpheres[i].Center,
                                    Radius = childcollisionmodel.PathfindingSpheres[i].Radius
                                });
                            }
                        }

                        // fix rare instances of coll with bsp physics lacking required model reference
                        bool collFixed = false;
                        foreach (var region in childcollisionmodel.Regions)
                        {
                            foreach (var permutation in region.Permutations.Where(x => x.BspPhysics.Any()))
                            {
                                foreach (var bspphysics in permutation.BspPhysics)
                                {
                                    if (bspphysics.GeometryShape.Model == null)
                                    {
                                        bspphysics.GeometryShape.Model = childmodeltag;
                                        collFixed = true;
                                    }
                                }
                            }
                        }

                        if (collFixed)
                            CacheContext.Serialize(cacheStream, childmodel.CollisionModel, childcollisionmodel);
                    }
                }
            }

            //all gameobjects are handled within this subswitch now
            switch (gameobject)
            {
                case Weapon weapon:
                    ConvertWeapon(cacheStream, blamCacheStream, weapon);
                    break;
                case Biped biped:
                    // add bipeds filter to "target_main" (fixes needler tracking)
                    if (biped.Model != null)
                    {
                        var hlmt = CacheContext.Deserialize<Model>(cacheStream, biped.Model);

                        foreach (var target in hlmt.Targets)
                        {
                            if (target.LockOnData.TrackingType == StringId.Invalid && CacheContext.StringTable.GetString(target.MarkerName) == "target_main")
                            {
                                target.LockOnData.TrackingType = CacheContext.StringTable.GetStringId("bipeds");
                            }
                        }

                        CacheContext.Serialize(cacheStream, biped.Model, hlmt);
                    }
                    break;
            }

            if (gameobject.MultiplayerObject.Count == 0 && FlagIsSet(PortingFlags.MPobject))
            {
                gameobject.MultiplayerObject.Add(new GameObject.MultiplayerObjectBlock()
                {
                    DefaultSpawnTime = 30,
                    DefaultAbandonTime = 30
                });
            }

            return gameobject;
        }

        private object ConvertMultiplayerObject(Stream cacheStream, Stream blamCacheStream, object definition, string blamTagName, GameObject.MultiplayerObjectBlock multiplayer)
        {
            if (BlamCache.Version < CacheVersion.HaloReach)
                return multiplayer;

            multiplayer.Type = multiplayer.TypeReach.ConvertLexical<MultiplayerObjectType>();
            multiplayer.Flags = multiplayer.FlagsReach.ConvertLexical<GameObject.MultiplayerObjectBlock.MultiplayerObjectFlags>();
            multiplayer.DefaultSpawnTime = multiplayer.SpawnTimeReach;
            multiplayer.DefaultAbandonTime = multiplayer.AbandonTimeReach;
            if (multiplayer.DefaultSpawnTime == 0) multiplayer.DefaultSpawnTime = 30;
            if (multiplayer.DefaultAbandonTime == 0) multiplayer.DefaultAbandonTime = 30;
            multiplayer.BoundaryShape = multiplayer.ReachBoundaryShape;
            multiplayer.SpawnTimerType = multiplayer.SpawnTimerTypeReach.ConvertLexical<MultiplayerObjectSpawnTimerType>();
            foreach (var boundary in multiplayer.BoundaryShaders)
            {
                boundary.StandardShader = ConvertTag(cacheStream, blamCacheStream, boundary.StandardShader);
                boundary.OpaqueShader = ConvertTag(cacheStream, blamCacheStream, boundary.OpaqueShader);
            }

            return multiplayer;
        }

        private Model ConvertModel(Model hlmt)
        {
            foreach (var target in hlmt.Targets)
            {
                if (BlamCache.Version <= CacheVersion.Halo3ODST)
                {
                    if (target.LockOnData.FlagsOld.HasFlag(Model.TargetLockOnData.FlagsValueOld.LockedByHumanTracking))
                        target.LockOnData.TrackingType = CacheContext.StringTable.GetStringId("flying_vehicles");
                    else if (target.LockOnData.FlagsOld.HasFlag(Model.TargetLockOnData.FlagsValueOld.LockedByPlasmaTracking))
                        target.LockOnData.TrackingType = CacheContext.StringTable.GetStringId("bipeds");
                }
            }
            return hlmt;
        }
    }
}
