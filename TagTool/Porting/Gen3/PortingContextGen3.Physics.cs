using TagTool.Havok;
using TagTool.IO;
using TagTool.Tags.Definitions;
using System;
using System.IO;
using TagTool.Serialization;
using TagTool.Cache;
using System.Collections.Generic;
using TagTool.Commands.Common;

namespace TagTool.Porting.Gen3
{
    partial class PortingContextGen3
    {
        private PhysicsModel ConvertPhysicsModel(CachedTag instance, PhysicsModel phmo)
        {
            phmo.MoppData = HavokConverter.ConvertHkpMoppData(BlamCache.Version, CacheContext.Version, BlamCache.Platform, CacheContext.Platform, phmo.MoppData);

            //fix for ODST phantoms getting stuck on environment
            if (instance.Name == @"objects\vehicles\phantom\phantom" && BlamCache.Version == CacheVersion.Halo3ODST)
            {
                phmo.RigidBodies[0].Flags |= PhysicsModel.RigidBody.RigidBodyFlags.DoesNotInteractWithEnvironment;
                phmo.RigidBodies[1].Flags |= PhysicsModel.RigidBody.RigidBodyFlags.DoesNotInteractWithEnvironment;
            }

            if (BlamCache.Version >= CacheVersion.HaloReach)
            {
                foreach (var rigidbody in phmo.RigidBodies)
                {
                    string ReachValue = rigidbody.MotionType_Reach.ToString();
                    rigidbody.MotionType = (PhysicsModel.RigidBody.MotionTypeValue)Enum.Parse(typeof(PhysicsModel.RigidBody.MotionTypeValue), ReachValue);
                    rigidbody.ShapeType = rigidbody.ShapeType_Reach;
                    rigidbody.ShapeIndex = rigidbody.ShapeIndex_Reach;
                    rigidbody.Mass = rigidbody.Mass_Reach;
                }

                phmo.Mopps = new List<CMoppBvTreeShape>();
                foreach(var reachmopp in phmo.ReachMopps)
                {
                    phmo.Mopps.Add(new CMoppBvTreeShape
                    {
                        ReferencedObject = new HkpReferencedObject(),
                        Child = new HkpSingleShapeContainer
                        {
                            Shape = new HavokShapeReference
                            {
                                Type = (BlamShapeType)reachmopp.ChildshapePointer.ShapeType,
                                Index = reachmopp.ChildshapePointer.Shape
                            }
                        },
                        Scale = reachmopp.Scale,
                    });
                }
            }
            return phmo;
        }

        private BipedPhysicsFlags ConvertBipedPhysicsFlags(BipedPhysicsFlags flags)
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

        private PhysicsModel.PhantomTypeFlags ConvertPhantomTypeFlags(string tagName, PhysicsModel.PhantomTypeFlags flags)
        {
            switch (BlamCache.Version)
            {
                case CacheVersion.Halo2Vista:
                case CacheVersion.Halo2Xbox:
                    if (flags.Halo2.ToString().Contains("Unknown"))
                    {
                        new TagToolWarning($"Disabling unknown phantom type flags ({flags.Halo2.ToString()})");
                        Console.WriteLine($"         in tag \"{tagName}.physics_model\"");

                        foreach (var flag in Enum.GetValues(typeof(PhysicsModel.PhantomTypeFlags.Halo2Bits)))
                            if (flag.ToString().StartsWith("Unknown") && flags.Halo2.HasFlag((PhysicsModel.PhantomTypeFlags.Halo2Bits)flag))
                                flags.Halo2 &= ~(PhysicsModel.PhantomTypeFlags.Halo2Bits)flag;
                    }
                    if (!Enum.TryParse(flags.Halo2.ToString(), out flags.Halo3ODST))
                        throw new FormatException(BlamCache.Version.ToString());
                    break;

                case CacheVersion.Halo3Retail:
                    if (flags.Halo3Retail.ToString().Contains("Unknown"))
                    {
                        new TagToolWarning($"Found unknown phantom type flags ({flags.Halo3Retail.ToString()})");
                        Console.WriteLine($"         in tag \"{tagName}.physics_model\"");
                        /*
                        foreach (var flag in Enum.GetValues(typeof(PhysicsModel.PhantomTypeFlags.Halo3RetailBits)))
                            if (flag.ToString().StartsWith("Unknown") && flags.Halo3Retail.HasFlag((PhysicsModel.PhantomTypeFlags.Halo3RetailBits)flag))
                                flags.Halo3Retail &= ~(PhysicsModel.PhantomTypeFlags.Halo3RetailBits)flag;
                        */
                    }
                    if (!Enum.TryParse(flags.Halo3Retail.ToString(), out flags.Halo3ODST))
                        throw new FormatException(BlamCache.Version.ToString());
                    break;
                case CacheVersion.HaloReach:
                    {
                        flags.HaloReach &= ~PhysicsModel.PhantomTypeFlags.HaloReachBits.IgnoresGarbage;
                        flags.HaloReach &= ~PhysicsModel.PhantomTypeFlags.HaloReachBits.IgnoresGroundedBipeds;

                        if (!Enum.TryParse(flags.HaloReach.ToString(), out flags.Halo3ODST))
                            throw new FormatException(BlamCache.Version.ToString());
                    }
                    break;
            }

            return flags;
        }
    }
}