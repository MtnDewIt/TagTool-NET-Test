using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Loader;

namespace TagTool
{
    public static class AssemblyResolver
    {
        static readonly string[] searchPaths =
        [
            AppContext.BaseDirectory,
            Path.Combine(AppContext.BaseDirectory, "Tools")
        ];

        public static void ConfigureAssemblyResolution()
        {
            AssemblyLoadContext.Default.Resolving += (ctx, name) =>
            {
                foreach (string path in searchPaths)
                {
                    try
                    {
                        string assemblyPath = Path.Combine(path, $"{name.Name}.dll");
                        if (File.Exists(assemblyPath))
                            return AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyPath);
                    }
                    catch (Exception)
                    {
                        // swallow
                    }
                }

                return null;
            };

            AssemblyLoadContext.Default.ResolvingUnmanagedDll += (assembly, dllName) =>
            {
                foreach (string path in searchPaths)
                {
                    try
                    {
                        string dllPath = Path.Combine(path, dllName);
                        if (File.Exists(dllPath))
                            return NativeLibrary.Load(dllPath);
                    }
                    catch (Exception)
                    {
                        // swallow
                    }
                }

                return nint.Zero;
            };
        }

        public static void CheckMissingDependencies()
        {
            // Provide user with warnings if there are missing assemblies
            // HaloShaderGenerator.dll:
            try
            {
                TestShaderGeneratorAssembly();
            }
            catch (Exception)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Could not load shader generator. Most shader related operations will fail");
                Console.WriteLine("Please confirm \"HaloShaderGenerator.dll\" is up to date and present in the \"Tools\" folder of your TagTool directory");
                Console.ForegroundColor = ConsoleColor.White;
            }

            static void TestShaderGeneratorAssembly()
            {
#pragma warning disable CS0219 // Variable is assigned but its value is never used
                var _ = HaloShaderGenerator.Globals.HLSLType.Float;
#pragma warning restore CS0219 // Variable is assigned but its value is never used
            }
        }
    }
}
