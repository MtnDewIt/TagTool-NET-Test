using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using TagTool.Tags.Definitions.Common;

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

        private Particle ConvertParticle(Particle particle)
        {
            if (BlamCache.Version == CacheVersion.Halo3Retail) // Shift all flags above 5 by 1.
            {
                int flagsH3 = (int)particle.FlagsH3;
                particle.Flags = (Particle.FlagsValue)((flagsH3 & 0x1F) + ((int)(flagsH3 & 0xFFFFFFE0) << 1));
                //particle.Flags &= ~Particle.FlagsValue.DiesInWater; // h3 particles in odst seem to have this flag unset - does it behave differently?
            }
            else if (BlamCache.Version >= CacheVersion.HaloReach) // Shift all flags above 11 by 2
            {
                int flagsReach = (int)particle.AppearanceFlagsReach;
                particle.AppearanceFlags = (Particle.AppearanceFlagsValue)((flagsReach & 0xFF) + ((flagsReach & 0x3F000) >> 2));
            }
            // temp prevent odst prt3 using cheap shader as we dont have the entry point shader
            if (particle.Flags.HasFlag(Particle.FlagsValue.UseCheapShader))
                particle.Flags &= ~Particle.FlagsValue.UseCheapShader;

            return particle;
        }

        private static CortanaEffectDefinition ConvertCortanaEffectDefinition(CortanaEffectDefinition crte)
        {
            foreach (var gravemindblock in crte.Gravemind)
            {
                foreach (var vignetteblock in gravemindblock.Vignette)
                {
                    foreach (var dynamicvaluesblock in vignetteblock.DynamicValues)
                    {
                        foreach (var framesblock in dynamicvaluesblock.Frames)
                        {
                            // scale (since this is chud)
                            framesblock.Dynamicvalue1 *= 1.5f;
                            framesblock.Dynamicvalue2 *= 1.5f;
                        }
                    }
                }
            }
            return crte;
        }

        private AreaScreenEffect ConvertAreaScreenEffect(AreaScreenEffect sefc)
        {
            if (BlamCache.Version < CacheVersion.Halo3ODST)
            {
                sefc.GlobalHiddenFlags = AreaScreenEffect.HiddenFlagBits.UpdateThread | AreaScreenEffect.HiddenFlagBits.RenderThread;

                foreach (var screenEffect in sefc.ScreenEffects)
                    screenEffect.HiddenFlags = AreaScreenEffect.HiddenFlagBits.UpdateThread | AreaScreenEffect.HiddenFlagBits.RenderThread;
            }
            foreach (var screenEffect in sefc.ScreenEffects)
            {
                //convert flags
                if (BlamCache.Version == CacheVersion.Halo3Retail)
                    Enum.TryParse(screenEffect.Flags_H3.ToString(), out screenEffect.Flags_ODST);
                else if (BlamCache.Version >= CacheVersion.HaloOnline106708 && BlamCache.Version <= CacheVersion.HaloOnline700123)
                    Enum.TryParse(screenEffect.Flags.ToString(), out screenEffect.Flags_ODST);

                if (CacheContext.StringTable.GetString(screenEffect.InputVariable) == "saved_film_vision_mode_intensity")
                    screenEffect.Flags_ODST |= AreaScreenEffect.ScreenEffectBlock.SefcFlagBits_ODST.DebugDisable; // prevents spawning and rendering

                if (screenEffect.ObjectFalloff.Data.Length == 0)
                    screenEffect.ObjectFalloff = TagFunction.DefaultConstant;
            }
            return sefc;
        }

        private RuntimeGpuData ConvertRuntimeGpuData(RuntimeGpuData runMGpu)
        {
            if (BlamCache.Platform == CachePlatform.MCC && BlamCache.Version >= CacheVersion.Halo3ODST)
            {
                if (runMGpu.RuntimeGpuBlocks?.Count > 0)
                {
                    runMGpu.Properties = runMGpu.RuntimeGpuBlocks[0].Properties;
                    runMGpu.Functions = runMGpu.RuntimeGpuBlocks[0].Functions;
                    runMGpu.Colors = runMGpu.RuntimeGpuBlocks[0].Colors;
                }
            }
            return runMGpu;
        }
    }
}
