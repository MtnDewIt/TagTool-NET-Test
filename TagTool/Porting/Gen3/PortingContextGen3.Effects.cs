using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;

namespace TagTool.Porting.Gen3
{
    public partial class PortingContextGen3
    {
        private Effect ConvertEffect(Stream cacheStream, Effect effe, string blamTagName)
        {
            if (BlamCache.Platform == CachePlatform.MCC)
            {
                effe.Flags = effe.FlagsMCC.ConvertLexical<EffectFlags>();
            }

            if (BlamCache.Version >= CacheVersion.HaloReach)
            {
                effe.Priority = effe.PriorityReach;
                effe.LocalLocation1 = effe.LocalLocation1Reach;
            }

            foreach (var effectEvent in effe.Events)
            {
                if (effectEvent.Parts.Any(p => p.Flags.HasFlag(EffectEventPartFlags.MakeEveryTick))
                    && BlamCache.Platform == CachePlatform.MCC)
                {
                    effectEvent.DurationBounds.Lower *= 2;
                    effectEvent.DurationBounds.Upper *= 2;
                }

                foreach (var particleSystem in effectEvent.ParticleSystems)
                {
                    if (BlamCache.Version < CacheVersion.Halo3ODST) //this value is inverted in ODST tags when compared to H3
                    {
                        particleSystem.NearRange = 1 / particleSystem.NearRange;

                        if (particleSystem.Flags.HasFlag(Effect.Event.ParticleSystem.ParticleSystemFlags.OverrideNearFade))
                            particleSystem.NearCutoff = particleSystem.NearFadeOverride;
                    }

                    if (BlamCache.Version >= CacheVersion.HaloReach)
                    {
                        Enum.TryParse(particleSystem.ReachFlags.ToString(), out particleSystem.Flags);

                        for (int i = 0; i < particleSystem.Emitters.Count; i++)
                        {
                            var emitter = particleSystem.Emitters[i];
                            // Needs to be implemented in the engine
                            if (emitter.EmissionShape == Effect.Event.ParticleSystem.Emitter.EmissionShapeValue.BoatHullSurface ||
                                emitter.EmissionShape == Effect.Event.ParticleSystem.Emitter.EmissionShapeValue.Jetwash)
                            {
                                new TagToolWarning($"Unsupported particle emitter shape '{emitter.EmissionShape}'. Using default.");
                                emitter.EmissionShape = Effect.Event.ParticleSystem.Emitter.EmissionShapeValue.Sprayer;
                            }

                            if (emitter.AxisScale.X != 1.0f || emitter.AxisScale.Y != 1.0f || emitter.AxisScale.Z != 1.0f)
                            {
                                Effects.EmitterCustomPointPlotter pecpPlotter = new Effects.EmitterCustomPointPlotter(CacheContext, cacheStream, emitter, blamTagName, i);
                                if (!pecpPlotter.ConvertEmitterToCustomPoints())
                                    new TagToolWarning($"Particle emitter \"{CacheContext.StringTable.GetString(emitter.Name)}_{i}\" will have incorrect dimensions: AxisScale {emitter.AxisScale}");
                            }

                            if (!Enum.TryParse(emitter.ParticleMovement.FlagsReach.ToString(), out emitter.ParticleMovement.Flags))
                                throw new FormatException(BlamCache.Version.ToString());
                        }
                    }

                    // hack -- for some reason these emitters are killed when using gpu
                    if (BlamCache.Version == CacheVersion.Halo3Retail &&
                        (blamTagName == @"fx\cinematics\070la_waypoint_arrival\01\slipspace_rupture" ||
                        blamTagName == @"fx\cinematics\070la_waypoint_arrival\01\slipspace_rupture_carrier" ||
                        blamTagName == @"fx\cinematics\040lb_cov_flee\08\shot_1\slipspace_rupture" ||
                        blamTagName == @"fx\cinematics\100lb_hc_crash\shot_4\slipspace_rupture"))
                    {
                        particleSystem.Emitters[0].EmitterFlags &= ~Effect.Event.ParticleSystem.Emitter.FlagsValue.IsGpu;
                        particleSystem.Emitters[0].EmitterFlags |= Effect.Event.ParticleSystem.Emitter.FlagsValue.IsCpu;
                    }
                    if (BlamCache.Version == CacheVersion.Halo3ODST)
                    {
                        switch (blamTagName)
                        {
                            case @"fx\cinematics\c200\slipspace\slipspace_rupture" when CacheContext.StringTable.GetString(effectEvent.Name) == "rupture":
                            case @"fx\cinematics\l200_out\slipspace\slipspace_rupture" when CacheContext.StringTable.GetString(effectEvent.Name) == "rupture":
                                particleSystem.Emitters[0].EmitterFlags &= ~Effect.Event.ParticleSystem.Emitter.FlagsValue.IsGpu;
                                particleSystem.Emitters[0].EmitterFlags |= Effect.Event.ParticleSystem.Emitter.FlagsValue.IsCpu;
                                break;
                        }
                    }
                    if (BlamCache.Platform == CachePlatform.MCC && BlamCache.Version >= CacheVersion.HaloReach)
                    {
                        foreach (var emitter in particleSystem.Emitters)
                        {
                            emitter.RuntimeMGpu.Properties = emitter.RuntimeMGpu.RuntimeGpuBlocks?[0].Properties;
                            emitter.RuntimeMGpu.Functions = emitter.RuntimeMGpu.RuntimeGpuBlocks?[0].Functions;
                            emitter.RuntimeMGpu.Colors = emitter.RuntimeMGpu.RuntimeGpuBlocks?[0].Colors;
                        }
                    }
                }
            }

            return effe;
        }

    }
}
