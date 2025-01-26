using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Porting
{
    public partial class PortTagCommand : Command
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

                            if (BlamCache.Platform == CachePlatform.MCC) 
                            {
                                emitter.RuntimeMGpu.Properties = emitter.RuntimeMGpu.RuntimeGpuBlocks?[0].Properties;
                                emitter.RuntimeMGpu.Functions = emitter.RuntimeMGpu.RuntimeGpuBlocks?[0].Functions;
                                emitter.RuntimeMGpu.Colors = emitter.RuntimeMGpu.RuntimeGpuBlocks?[0].Colors;
                            }
                        }
                    }

                    // hack -- for some reason these emitters are killed when using gpu
                    if (BlamCache.Version == CacheVersion.Halo3Retail)
                    {
                        switch (blamTagName) 
                        {
                            case @"fx\cinematics\070la_waypoint_arrival\01\slipspace_rupture":
                            case @"fx\cinematics\070la_waypoint_arrival\01\slipspace_rupture_carrier":
                            case @"fx\cinematics\040lb_cov_flee\08\shot_1\slipspace_rupture":
                            case @"fx\cinematics\100lb_hc_crash\shot_4\slipspace_rupture":
                                particleSystem.Emitters[0].EmitterFlags &= ~Effect.Event.ParticleSystem.Emitter.FlagsValue.IsGpu;
                                particleSystem.Emitters[0].EmitterFlags |= Effect.Event.ParticleSystem.Emitter.FlagsValue.IsCpu;
                                break;
                        }
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

                        if (BlamCache.Platform == CachePlatform.MCC) 
                        {
                            for (int i = 0; i < particleSystem.Emitters.Count; i++) 
                            {
                                if (particleSystem.Emitters[i].RuntimeMGpu.RuntimeGpuBlocks?.Count == 0) 
                                {
                                    var prt3 = CacheContext.Deserialize<Particle>(cacheStream, particleSystem.Particle);

                                    var newRuntimeData = CompileEmitterRuntimeData(particleSystem, i, prt3);

                                    particleSystem.Emitters[i].RuntimeMGpu.Properties = newRuntimeData.Properties;
                                    particleSystem.Emitters[i].RuntimeMGpu.Functions = newRuntimeData.Functions;
                                    particleSystem.Emitters[i].RuntimeMGpu.Colors = newRuntimeData.Colors;
                                }
                            }
                        }
                    }
                }
            }

            return effe;
        }

        public Effect.Event.ParticleSystem.Emitter.RuntimeMGpuData CompileEmitterRuntimeData(Effect.Event.ParticleSystem particleSystem, int emitterIndex, Particle prt3)
        {
            var emitter = particleSystem.Emitters[emitterIndex];

            Effect.Event.ParticleSystem.Emitter.RuntimeMGpuData runtimeGpu = new Effect.Event.ParticleSystem.Emitter.RuntimeMGpuData();

            runtimeGpu.Properties = new List<Effect.Event.ParticleSystem.Emitter.RuntimeMGpuData.Property>();
            runtimeGpu.Functions = new List<Effect.Event.ParticleSystem.Emitter.RuntimeMGpuData.Function>();
            runtimeGpu.Colors = new List<Effect.Event.ParticleSystem.Emitter.RuntimeMGpuData.GpuColor>();

            if (prt3 == null)
            {
                new TagToolWarning("Particle system has no particle! States will not be compiled.");
                return runtimeGpu;
            }

            var runtimePropertyRef = new KeyValuePair<ParticlePropertyScalar, List<object>>[]
            {
                // DO NOT CHANGE THE ORDER OF THESE
                new KeyValuePair<ParticlePropertyScalar, List<object>>(emitter.ParticleTint, new List<object>()),
                new KeyValuePair<ParticlePropertyScalar, List<object>>(emitter.ParticleAlpha, new List<object>()),
                new KeyValuePair<ParticlePropertyScalar, List<object>>(emitter.ParticleSize, new List<object>()),
                new KeyValuePair<ParticlePropertyScalar, List<object>>(prt3.Color, new List<object>()),
                new KeyValuePair<ParticlePropertyScalar, List<object>>(prt3.Intensity, new List<object>()),
                new KeyValuePair<ParticlePropertyScalar, List<object>>(prt3.Alpha, new List<object>()),
                new KeyValuePair<ParticlePropertyScalar, List<object>>(emitter.ParticleScale, new List<object>()),
                new KeyValuePair<ParticlePropertyScalar, List<object>>(emitter.ParticleRotation, new List<object>()),
                new KeyValuePair<ParticlePropertyScalar, List<object>>(prt3.FrameIndex, new List<object>()),
                new KeyValuePair<ParticlePropertyScalar, List<object>>(emitter.ParticleAlphaBlackPoint, new List<object>()),
                new KeyValuePair<ParticlePropertyScalar, List<object>>(prt3.AspectRatio, new List<object>()),
                new KeyValuePair<ParticlePropertyScalar, List<object>>(emitter.ParticleSelfAcceleration.Mapping, new List<object> { emitter.ParticleSelfAcceleration.StartingInterpolant, emitter.ParticleSelfAcceleration.EndingInterpolant }),
                new KeyValuePair<ParticlePropertyScalar, List<object>>(prt3.PaletteAnimation, new List<object>())
            };

            foreach (var propertyRef in runtimePropertyRef)
            {
                var property = new Effect.Event.ParticleSystem.Emitter.RuntimeMGpuData.Property();

                property.MConstantValue = propertyRef.Key.RuntimeMConstantValue;

                if (!propertyRef.Key.IsConstant())
                {
                    property.MInnardsZ.FunctionIndexGreen = (byte)runtimeGpu.Functions.Count;
                    property.MInnardsZ.ModifierIndex = propertyRef.Key.OutputModifier;
                    property.MInnardsZ.InputIndexModifier = propertyRef.Key.OutputModifierInput;
                    property.MInnardsW.InputIndexGreen = propertyRef.Key.InputVariable;

                    runtimeGpu.Functions.AddRange(PropertyFunctionGetGpuFunctions(propertyRef.Key.Function, 0));

                    if ((propertyRef.Key.Function.Data[1] & 1) == 1) // ranged
                    {
                        property.MInnardsY.FunctionIndexRed = (byte)runtimeGpu.Functions.Count;
                        property.MInnardsY.InputIndexRed = propertyRef.Key.RangeVariable;
                        runtimeGpu.Functions.AddRange(PropertyFunctionGetGpuFunctions(propertyRef.Key.Function, 1));
                    }

                    property.MInnardsY.IsConstant = 0;
                }
                else
                {
                    property.MInnardsY.IsConstant = 1;
                }

                RealRgbaColor startingInterp = new RealRgbaColor();
                RealRgbaColor endingInterp = new RealRgbaColor();

                if (propertyRef.Key.IsRealPoint2d() || propertyRef.Key.IsRealPoint3d() || propertyRef.Key.IsRealVector3d())
                {
                    if (propertyRef.Key.IsRealPoint2d())
                    {
                        startingInterp.Red = ((RealPoint2d)propertyRef.Value[0]).X;
                        startingInterp.Green = ((RealPoint2d)propertyRef.Value[0]).Y;
                        endingInterp.Red = ((RealPoint2d)propertyRef.Value[1]).X;
                        endingInterp.Green = ((RealPoint2d)propertyRef.Value[1]).Y;
                    }
                    else if (propertyRef.Key.IsRealPoint3d())
                    {
                        startingInterp.Red = ((RealPoint3d)propertyRef.Value[0]).X;
                        startingInterp.Green = ((RealPoint3d)propertyRef.Value[0]).Y;
                        startingInterp.Blue = ((RealPoint3d)propertyRef.Value[0]).Z;
                        endingInterp.Red = ((RealPoint3d)propertyRef.Value[1]).X;
                        endingInterp.Green = ((RealPoint3d)propertyRef.Value[1]).Y;
                        endingInterp.Blue = ((RealPoint3d)propertyRef.Value[1]).Z;
                    }
                    else if (propertyRef.Key.IsRealVector3d())
                    {
                        startingInterp.Red = ((RealVector3d)propertyRef.Value[0]).I;
                        startingInterp.Green = ((RealVector3d)propertyRef.Value[0]).J;
                        startingInterp.Blue = ((RealVector3d)propertyRef.Value[0]).K;
                        endingInterp.Red = ((RealVector3d)propertyRef.Value[1]).I;
                        endingInterp.Green = ((RealVector3d)propertyRef.Value[1]).J;
                        endingInterp.Blue = ((RealVector3d)propertyRef.Value[1]).K;
                    }

                    property.MInnardsW.ColorIndexLo = (byte)runtimeGpu.Colors.Count;

                    runtimeGpu.Colors.Add(new Effect.Event.ParticleSystem.Emitter.RuntimeMGpuData.GpuColor
                    {
                        Color = startingInterp
                    });

                    property.MInnardsW.ColorIndexHi = (byte)runtimeGpu.Colors.Count;

                    runtimeGpu.Colors.Add(new Effect.Event.ParticleSystem.Emitter.RuntimeMGpuData.GpuColor
                    {
                        Color = endingInterp
                    });
                }
                else if (propertyRef.Key.Function.Data[2] != 0) // is_color_function
                {
                    List<RealRgbaColor> gpuColours = PropertyFunctionGetGpuColours(propertyRef.Key.Function);

                    property.MInnardsW.ColorIndexLo = (byte)runtimeGpu.Colors.Count;

                    foreach (var colour in gpuColours)
                    {
                        runtimeGpu.Colors.Add(new Effect.Event.ParticleSystem.Emitter.RuntimeMGpuData.GpuColor
                        {
                            Color = colour
                        });
                    }

                    property.MInnardsW.ColorIndexHi = (byte)(runtimeGpu.Colors.Count - 1);
                }

                runtimeGpu.Properties.Add(property);
            }

            return runtimeGpu;
        }

        private List<Effect.Event.ParticleSystem.Emitter.RuntimeMGpuData.Function> PropertyFunctionGetGpuFunctions(TagFunction function, int multiPartIndex)
        {
            List<Effect.Event.ParticleSystem.Emitter.RuntimeMGpuData.Function> result = new List<Effect.Event.ParticleSystem.Emitter.RuntimeMGpuData.Function>();

            Effect.Event.ParticleSystem.Emitter.RuntimeMGpuData.Function gpuFunction = new Effect.Event.ParticleSystem.Emitter.RuntimeMGpuData.Function();

            gpuFunction.DomainMax = 1.0f;
            gpuFunction.FunctionType.FunctionType = (float)function.Data[0];
            gpuFunction.Flags = (float)function.Data[1];

            if (function.Data[2] != 0)
            {
                gpuFunction.RangeMin = 0.0f;
                gpuFunction.RangeMax = 1.0f;
                gpuFunction.ExclusionMin = 1.0f;
                gpuFunction.ExclusionMax = 1.0f;
            }
            else
            {
                gpuFunction.RangeMin = BitConverter.ToSingle(function.Data, 4);
                gpuFunction.RangeMax = BitConverter.ToSingle(function.Data, 8);
                gpuFunction.ExclusionMin = BitConverter.ToSingle(function.Data, 24);
                gpuFunction.ExclusionMax = BitConverter.ToSingle(function.Data, 20);

                if (gpuFunction.ExclusionMax != 1 || gpuFunction.ExclusionMax != 0)
                    gpuFunction.ExclusionMax = 0;
            }

            switch (function.Data[0])
            {
                case 1:
                    gpuFunction.Innards[0] = (float)multiPartIndex;
                    break;
                case 2:
                    gpuFunction.Innards[0] = BitConverter.ToSingle(function.Data, 12 * multiPartIndex + 0x20);
                    gpuFunction.Innards[4] = BitConverter.ToSingle(function.Data, 12 * multiPartIndex + 0x24);
                    gpuFunction.Innards[5] = BitConverter.ToSingle(function.Data, 12 * multiPartIndex + 0x28);
                    break;
                case 3:
                    gpuFunction.Innards[0] = BitConverter.ToSingle(function.Data, 12 * multiPartIndex + 0x20);
                    gpuFunction.Innards[4] = BitConverter.ToSingle(function.Data, 12 * multiPartIndex + 0x24);
                    gpuFunction.Innards[5] = BitConverter.ToSingle(function.Data, 12 * multiPartIndex + 0x28);
                    gpuFunction.Innards[6] = BitConverter.ToSingle(function.Data, 12 * multiPartIndex + 0x28);
                    gpuFunction.Innards[7] = BitConverter.ToSingle(function.Data, 12 * multiPartIndex + 0x30);
                    break;
                case 4:
                    gpuFunction.Innards[0] = BitConverter.ToSingle(function.Data, 12 * multiPartIndex + 0x20);
                    gpuFunction.Innards[1] = BitConverter.ToSingle(function.Data, 12 * multiPartIndex + 0x24);
                    break;
                case 7:
                    gpuFunction.Innards[0] = BitConverter.ToSingle(function.Data, 16 * (multiPartIndex + 2) + 0x00);
                    gpuFunction.Innards[1] = BitConverter.ToSingle(function.Data, 16 * (multiPartIndex + 2) + 0x04);
                    gpuFunction.Innards[2] = BitConverter.ToSingle(function.Data, 16 * (multiPartIndex + 2) + 0x08);
                    gpuFunction.Innards[3] = BitConverter.ToSingle(function.Data, 16 * (multiPartIndex + 2) + 0x0C);
                    break;
                case 9:
                    gpuFunction.Innards[0] = BitConverter.ToSingle(function.Data, 12 * multiPartIndex + 0x20);
                    gpuFunction.Innards[1] = BitConverter.ToSingle(function.Data, 12 * multiPartIndex + 0x24);
                    gpuFunction.Innards[1] = BitConverter.ToSingle(function.Data, 12 * multiPartIndex + 0x28);
                    break;
                case 10:
                    gpuFunction.Innards[0] = BitConverter.ToSingle(function.Data, 28 * (multiPartIndex + 2) + 0x20);
                    gpuFunction.Innards[1] = BitConverter.ToSingle(function.Data, 28 * (multiPartIndex + 2) + 0x24);
                    gpuFunction.Innards[2] = BitConverter.ToSingle(function.Data, 28 * (multiPartIndex + 2) + 0x28);
                    gpuFunction.Innards[3] = BitConverter.ToSingle(function.Data, 28 * (multiPartIndex + 2) + 0x2C);
                    gpuFunction.Innards[4] = BitConverter.ToSingle(function.Data, 28 * (multiPartIndex + 2) + 0x30);
                    gpuFunction.Innards[5] = BitConverter.ToSingle(function.Data, 28 * (multiPartIndex + 2) + 0x34);
                    gpuFunction.Innards[6] = BitConverter.ToSingle(function.Data, 28 * (multiPartIndex + 2) + 0x38);
                    break;
                case 8: // multi part
                        // get range section
                    int sectionOffset = 0x20;
                    if (multiPartIndex > 0)
                    {
                        for (int i = 0; i < multiPartIndex; i++)
                        {
                            int partTypeOffset = sectionOffset + 4;
                            int partSize = BitConverter.ToInt32(function.Data, sectionOffset);
                            int nextPartOffset = 4;
                            for (int j = 0; j < partSize; j++)
                            {
                                byte partType = function.Data[partTypeOffset];

                                if (partType == 4)
                                {
                                    nextPartOffset += 16;
                                    partTypeOffset += 16;
                                }
                                else if (partType == 7)
                                {
                                    nextPartOffset += 24;
                                    partTypeOffset += 24;
                                }
                                else if (partType == 10)
                                {
                                    nextPartOffset += 36;
                                    partTypeOffset += 36;
                                }
                            }
                            sectionOffset += nextPartOffset;
                        }
                    }

                    int multiPartCount = BitConverter.ToInt32(function.Data, sectionOffset);
                    if (multiPartCount > 0)
                    {
                        int gpuDataOffset = sectionOffset + 4;
                        MultiFunctionPartPackGpuData(function, ref gpuDataOffset, ref gpuFunction);
                        result.Add(gpuFunction);

                        for (int i = 1; i < multiPartCount; i++)
                        {
                            Effect.Event.ParticleSystem.Emitter.RuntimeMGpuData.Function tempGpu =
                                new Effect.Event.ParticleSystem.Emitter.RuntimeMGpuData.Function();

                            MultiFunctionPartPackGpuData(function, ref gpuDataOffset, ref tempGpu);
                            result.Add(tempGpu);
                        }
                    }

                    return result;
            }

            result.Add(gpuFunction);

            return result;
        }

        private void MultiFunctionPartPackGpuData(TagFunction function, ref int dataOffset, ref Effect.Event.ParticleSystem.Emitter.RuntimeMGpuData.Function gpuFunction)
        {
            int nextSectionOffset = 0;

            gpuFunction.FunctionType.FunctionType = (float)function.Data[dataOffset];
            gpuFunction.DomainMax = BitConverter.ToSingle(function.Data, dataOffset + 4);

            if (function.Data[dataOffset] == 4)
            {
                gpuFunction.Innards[0] = BitConverter.ToSingle(function.Data, dataOffset + 8);
                gpuFunction.Innards[1] = BitConverter.ToSingle(function.Data, dataOffset + 12);
                nextSectionOffset = 16;
            }
            else if (function.Data[dataOffset] == 7)
            {
                gpuFunction.Innards[0] = BitConverter.ToSingle(function.Data, dataOffset + 8);
                gpuFunction.Innards[1] = BitConverter.ToSingle(function.Data, dataOffset + 12);
                gpuFunction.Innards[2] = BitConverter.ToSingle(function.Data, dataOffset + 16);
                gpuFunction.Innards[3] = BitConverter.ToSingle(function.Data, dataOffset + 20);
                nextSectionOffset = 24;
            }
            else if (function.Data[dataOffset] == 10)
            {
                gpuFunction.Innards[0] = BitConverter.ToSingle(function.Data, dataOffset + 8);
                gpuFunction.Innards[1] = BitConverter.ToSingle(function.Data, dataOffset + 12);
                gpuFunction.Innards[2] = BitConverter.ToSingle(function.Data, dataOffset + 16);
                gpuFunction.Innards[3] = BitConverter.ToSingle(function.Data, dataOffset + 20);
                gpuFunction.Innards[4] = BitConverter.ToSingle(function.Data, dataOffset + 24);
                gpuFunction.Innards[5] = BitConverter.ToSingle(function.Data, dataOffset + 28);
                gpuFunction.Innards[6] = BitConverter.ToSingle(function.Data, dataOffset + 32);
                nextSectionOffset = 36;
            }
            else
            {
                new TagToolWarning($"Unexpected function part type {gpuFunction.FunctionType.Type} in multipart function!");
            }

            dataOffset += nextSectionOffset;
        }

        private List<RealRgbaColor> PropertyFunctionGetGpuColours(TagFunction function)
        {
            List<RealRgbaColor> result = new List<RealRgbaColor>();

            // colours are stored bgra in little endian builds
            switch (function.Data[2])
            {
                case 1:
                    result.Add(new RealRgbaColor(
                        function.Data[6] / 255.0f,
                        function.Data[5] / 255.0f,
                        function.Data[4] / 255.0f,
                        function.Data[7] / 255.0f));
                    break;
                case 2:
                    result.Add(new RealRgbaColor(
                        function.Data[6] / 255.0f,
                        function.Data[5] / 255.0f,
                        function.Data[4] / 255.0f,
                        function.Data[7] / 255.0f));
                    result.Add(new RealRgbaColor(
                        function.Data[18] / 255.0f,
                        function.Data[17] / 255.0f,
                        function.Data[16] / 255.0f,
                        function.Data[19] / 255.0f));
                    break;
                case 3:
                    result.Add(new RealRgbaColor(
                        function.Data[6] / 255.0f,
                        function.Data[5] / 255.0f,
                        function.Data[4] / 255.0f,
                        function.Data[7] / 255.0f));
                    result.Add(new RealRgbaColor(
                        function.Data[10] / 255.0f,
                        function.Data[9] / 255.0f,
                        function.Data[8] / 255.0f,
                        function.Data[11] / 255.0f));
                    result.Add(new RealRgbaColor(
                        function.Data[18] / 255.0f,
                        function.Data[17] / 255.0f,
                        function.Data[16] / 255.0f,
                        function.Data[19] / 255.0f));
                    break;
                case 4:
                    result.Add(new RealRgbaColor(
                        function.Data[6] / 255.0f,
                        function.Data[5] / 255.0f,
                        function.Data[4] / 255.0f,
                        function.Data[7] / 255.0f));
                    result.Add(new RealRgbaColor(
                        function.Data[10] / 255.0f,
                        function.Data[9] / 255.0f,
                        function.Data[8] / 255.0f,
                        function.Data[11] / 255.0f));
                    result.Add(new RealRgbaColor(
                        function.Data[14] / 255.0f,
                        function.Data[13] / 255.0f,
                        function.Data[12] / 255.0f,
                        function.Data[15] / 255.0f));
                    result.Add(new RealRgbaColor(
                        function.Data[18] / 255.0f,
                        function.Data[17] / 255.0f,
                        function.Data[16] / 255.0f,
                        function.Data[19] / 255.0f));
                    break;
                case 0: // scalar function, no colours
                    break;
            }

            return result;
        }
    }
}
