using System;
using System.Collections.Generic;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Cache.ModPackages;
using TagTool.Commands.Common;
using TagTool.Commands.Tags;

namespace TagTool.Commands.Modding
{
    public class CreateModPackageCommand : Command
    {
        private readonly GameCacheHaloOnline Cache;
        private CommandContextStack ContextStack { get; }

        public CreateModPackageCommand(CommandContextStack contextStack, GameCacheHaloOnline cache) :
            base(true,

                "CreateModPackage",
                "Create context for a mod package. Optionally have more than one tag cache and use unmanaged streams for 2gb + resources.",

                "CreateModPackage [# of tag caches, [large]] [testname]",

                "\t- [# of tag caches]: An integer used for when you want more than one isolated tag cache."
                + "\n\t- [large]: Used with a tag cache count to allow unmanaged streams for 2GB + resources."
                + "\n\t- [testname]: A name for a test mod package. Skips the standard dialog, used without other arguments.")
        {
            ContextStack = contextStack;
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count > 2)
                return new TagToolError(CommandError.ArgCount);

            int tagCacheCount = 1;
            bool useLargeStreams = false;
            bool useDialog = true;

            if (args.Count > 0)
            {
                if (!int.TryParse(args[0], System.Globalization.NumberStyles.Integer, null, out tagCacheCount))
                {
                    if (args.Count == 1 && !string.IsNullOrEmpty(args[0]))
                    {
                        useDialog = false;
                        tagCacheCount = 1;
                    }
                    else
                        return new TagToolError(CommandError.ArgInvalid, $"\"{args[0]}\"");
                }

                if (args.Count == 2 && args[1].ToLower() == "large")
                    useLargeStreams = true;
            }

            var builder = new ModPackageBuilder(Cache);

            if (useDialog)
            {
                builder.SetMetadata(PromptMetadata(IgnoreArgumentVariables));
                Console.WriteLine();
                builder.SetModifierFlags(PromptTypes(IgnoreArgumentVariables));
                Console.WriteLine();

                for (int i = 0; i < tagCacheCount; i++)
                {
                    string name = "default";
                    if (tagCacheCount > 1 && (args.Count == 1 && useLargeStreams))
                    {
                        Console.WriteLine($"Enter the name of tag cache {i} (32 chars max):");
                        name = Console.ReadLine().Trim();
                        name = name.Length <= 32 ? name : name.Substring(0, 32);
                    }

                    builder.AddTagCache(name);
                }

                Console.WriteLine();
            }
            else
            {
                builder.CreateTest(args[0].Split('.')[0]);
            }

            Console.WriteLine("Creating mod package...");

            ModPackage modPackage = builder.Build(useLargeStreams);

            Console.WriteLine("Done.");

            ContextStack.Push(TagCacheContextFactory.Create(
                ContextStack, 
                new GameCacheModPackage(Cache, modPackage), 
                $"{modPackage.Metadata.Name}.pak"));

            RunMetrics.Start();

            return true;
        }

        public static ModPackageMetadata PromptMetadata(bool ignoreArgumentVariables)
        {
            var metadata = new ModPackageMetadata();

            Console.WriteLine("Enter the display name of the mod package (32 chars max):");
            metadata.Name = CommandRunner.ApplyUserVars(Console.ReadLine().Trim(), ignoreArgumentVariables);

            Console.WriteLine();
            Console.WriteLine("Enter the description of the mod package (512 chars max):");
            metadata.Description = CommandRunner.ApplyUserVars(Console.ReadLine().Trim(), ignoreArgumentVariables);

            Console.WriteLine();
            Console.WriteLine("Enter the author of the mod package (32 chars max):");
            metadata.Author = CommandRunner.ApplyUserVars(Console.ReadLine().Trim(), ignoreArgumentVariables);

            Console.WriteLine();
            Console.WriteLine("Enter the version of the mod package: (major.minor)");

            try
            {
                var version = Version.Parse(CommandRunner.ApplyUserVars(Console.ReadLine(), ignoreArgumentVariables));
                metadata.VersionMajor = (short)version.Major;
                metadata.VersionMinor = (short)version.Minor;
                if (version.Major == 0 && version.Minor == 0)
                    throw new ArgumentException(nameof(version));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                new TagToolError(CommandError.CustomError, "Failed to parse version number, using default (1.0)");
                metadata.VersionMajor = 1;
                metadata.VersionMinor = 0;
            }

            return metadata;
        }

        public static ModifierFlags PromptTypes(bool ignoreArgumentVariables, ModifierFlags modifierFlags = ModifierFlags.None)
        {
            Console.WriteLine("Please enter the types of the mod package. Separated by a space [MainMenu Multiplayer Campaign Firefight Character]");
            string response = CommandRunner.ApplyUserVars(Console.ReadLine().Trim(), ignoreArgumentVariables);

            modifierFlags &= ModifierFlags.SignedBit;

            var args = response.Split(' ');
            for (int x = 0; x < args.Length; x++)
            {
                if (Enum.TryParse<ModifierFlags>(args[x].ToLower().Trim(), out var value) && args[x] != "SignedBit")
                {
                    modifierFlags |= value;
                }
                else if (string.IsNullOrWhiteSpace(args[x]))
                {
                    if (args.Count() == 1)
                    {
                        modifierFlags |= ModifierFlags.multiplayer;
                        Console.WriteLine($"Flags not provided. Multiplayer assumed.");
                    }
                }
                else
                    new TagToolWarning($"Could not parse flag \"{args[x]}\"");
            }

            return modifierFlags;
        }
    }
}
