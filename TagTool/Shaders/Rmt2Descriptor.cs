using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagTool.Shaders
{
    public struct Rmt2Descriptor
    {
        public DescriptorFlags Flags;
        public string Type;
        public byte[] Options;

        [Flags]
        public enum DescriptorFlags
        {
            None = 0,
            Ms30 = (1 << 0)
        }

        public Rmt2Descriptor(string type, ReadOnlySpan<byte> options)
        {
            Type = type;
            Options = [.. options];
            Flags = DescriptorFlags.None;
        }

        public readonly bool IsMs30 => Flags.HasFlag(DescriptorFlags.Ms30);

        public readonly string GetRmdfName() => $"{(IsMs30 ? "ms30\\" : "")}shaders\\{Type}";

        public readonly string GetRmt2Name() => $@"{(IsMs30 ? "ms30\\" : "")}shaders\{Type}_templates\_{string.Join('_', Options)}";

        public static Rmt2Descriptor Parse(ReadOnlySpan<char> name)
        {
            if (!TryParse(name, out Rmt2Descriptor desc))
                throw new FormatException($"Invalid rmt2 name '{name}'");

            return desc;
        }

        public static bool TryParse(ReadOnlySpan<char> name, out Rmt2Descriptor descriptor)
        {
            descriptor = default;

            Span<Range> p = stackalloc Range[4];
            int n = name.Split(p, '\\');

            // Handle "ms30\\" prefix
            if (n > 0 && name[p[0]].Equals("ms30", StringComparison.Ordinal))
            {
                descriptor.Flags |= DescriptorFlags.Ms30;
                p = p[1..];
                --n;
            }

            // Must start with "shaders\\"
            if (n < 3 || !name[p[0]].Equals("shaders", StringComparison.Ordinal))
                return false;

            // Strip "_templates"
            descriptor.Type = name[p[1]][..^10].ToString();

            if (!TryParseOptions(name[p[2]], out descriptor.Options))
                return false;

            return true;
        }

        private static bool TryParseOptions(ReadOnlySpan<char> str, out byte[] options)
        {
            const int MaxCategories = 16;
            options = null;

            Span<Range> p = stackalloc Range[MaxCategories];
            int n = str.Split(p, '_', StringSplitOptions.RemoveEmptyEntries);
            if (n == 0)
                return false;

            options = new byte[n];
            for (int i = 0; i < n; i++)
            {
                if (!byte.TryParse(str[p[i]], out options[i]))
                    return false;
            }

            return true;
        }

        public HaloShaderGenerator.Generator.IShaderGenerator GetGenerator(bool applyFixes = false)
        {
            if (!IsMs30)
            {
                switch (Type)
                {
                    case "beam": return new HaloShaderGenerator.Beam.BeamGenerator(Options, applyFixes);
                    case "black": return new HaloShaderGenerator.Black.ShaderBlackGenerator();
                    case "contrail": return new HaloShaderGenerator.Contrail.ContrailGenerator(Options, applyFixes);
                    case "cortana": return new HaloShaderGenerator.Cortana.CortanaGenerator(Options, applyFixes);
                    case "custom": return new HaloShaderGenerator.Custom.CustomGenerator(Options, applyFixes);
                    case "decal": return new HaloShaderGenerator.Decal.DecalGenerator(Options, applyFixes);
                    case "foliage": return new HaloShaderGenerator.Foliage.FoliageGenerator(Options, applyFixes);
                    //case "glass":           return new HaloShaderGenerator.Glass.GlassGenerator(Options, applyFixes);
                    case "halogram": return new HaloShaderGenerator.Halogram.HalogramGenerator(Options, applyFixes);
                    case "light_volume": return new HaloShaderGenerator.LightVolume.LightVolumeGenerator(Options, applyFixes);
                    case "particle": return new HaloShaderGenerator.Particle.ParticleGenerator(Options, applyFixes);
                    case "screen": return new HaloShaderGenerator.Screen.ScreenGenerator(Options, applyFixes);
                    case "shader": return new HaloShaderGenerator.Shader.ShaderGenerator(Options, applyFixes);
                    case "terrain": return new HaloShaderGenerator.Terrain.TerrainGenerator(Options, applyFixes);
                    case "water": return new HaloShaderGenerator.Water.WaterGenerator(Options, applyFixes);
                    case "zonly": return new HaloShaderGenerator.ZOnly.ZOnlyGenerator(Options, applyFixes);
                }

                Console.WriteLine($"\"{Type}\" shader generation is currently unsupported.");
                return null;
            }

            Console.WriteLine("Invalid descriptor.");
            return null;
        }

        public readonly override string ToString() => GetRmt2Name();
    }
}
