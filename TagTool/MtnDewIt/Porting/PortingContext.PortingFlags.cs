using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Porting
{
	public partial class PortingContext
	{
		private PortingFlags Flags { get; set; }

		[Flags]
		public enum PortingFlags
		{
			// Replace tags of the same name when porting.
			Replace = 1 << 0,

			// Recursively port all tag references available.
			Recursive = 1 << 1,

			// Create a new tag after the last index.
			New = 1 << 2,

			// Port a tag using nulled tag indices where available.
			UseNull = 1 << 3,

			// Include 'Sound' (snd!) tags.
			Audio = 1 << 4,

			// Include elite 'Biped' (bipd) tags.
			Elites = 1 << 5,

			// Include 'Scenario.SandboxObject' tag-blocks.
			ForgePalette = 1 << 6,

			// Include 'Scenario.Squad' tag-blocks.
			Squads = 1 << 7,

			// Include 'Scripting.Script' tag-blocks.
			Scripts = 1 << 8,

			// Port udlg tags and associated audio for bipeds.
			Dialogue = 1 << 9,

			// Attempt to match shaders to existing tags.
			MatchShaders = 1 << 10,

			// Only use templates that have the exact same render method options.
			PefectShaderMatchOnly = 1 << 11,

			// Keep cache in memory during porting.
			Memory = 1 << 12,

			// Allow using existing tags from Ms30.
			Ms30 = 1 << 13,

			// Allow writing output to the console.
			Print = 1 << 14,

            // Merges new data if tags exist.
            Merge = 1 << 15,

            // Use a regular expression to determine target tags.
            Regex = 1 << 16,

			// Attempt to generate shaders.
			GenerateShaders = 1 << 17,

            // Add a multiplayerobject block for spawnable tag types.
            MPobject = 1 << 18,

			// Multipurpose Reach flag used for specific tweaks.
			ReachMisc = 1 << 19,

			// Auto rescale gui during porting.
			AutoRescaleGui = 1 << 20,

			// Default porting flags
			Default = Print | Recursive | Merge | Scripts | Squads | ForgePalette | Elites | Audio | Dialogue | MatchShaders | GenerateShaders
		}

		// True if ALL of the supplied flags are set, false if any aren't
		public bool FlagsAllSet(PortingFlags flags) => (Flags & flags) == flags;
		
		// True if the flag is set (this is 100% the same as FlagAnySet)
		public bool FlagIsSet(PortingFlags flag) => (Flags & flag) != 0;

		// True if ANY of the supplied flags are set, false if none are
		public bool FlagsAnySet(PortingFlags flags) => (Flags & flags) != 0;

		// Sets flags explicitly
		public PortingFlags SetFlags(PortingFlags flags) => Flags |= flags;

		// Removes flags explicitly
		public PortingFlags RemoveFlags(PortingFlags flags) => Flags &= ~flags;

		// Toggles flags on or off
		public PortingFlags ToggleFlags(PortingFlags flags) => Flags ^= flags;

		// Parses porting options from an input string
		// TODO: Figure out a better way of handling this internally instead of splitting strings :/
		private void ParsePortingOptions(string portingOptions)
		{
			Flags = PortingFlags.Default;

			var flagNames = Enum.GetNames(typeof(PortingFlags)).Select(name => name.ToLower());
			var flagValues = Enum.GetValues(typeof(PortingFlags)) as PortingFlags[];

			var args = portingOptions.Split(' ');

			for (var a = 0; a < args.Count(); a++)
			{
                var arg = args[a].ToLower();

                // Support legacy arguments
                arg = arg.Replace("single", $"!{nameof(PortingFlags.Recursive)}");
				arg = arg.Replace("noshaders", $"!{nameof(PortingFlags.MatchShaders)}");
				arg = arg.Replace("silent", $"!{nameof(PortingFlags.Print)}");
				arg = arg.ToLower(); // do this again incase the argument was replaced

				// Use '!' or 'No' to negate an argument.
				var toggleOn = !(arg.StartsWith("!") || arg.StartsWith("no"));

				if (!toggleOn && arg.StartsWith("!"))
				{
					arg = arg.Remove(0, 1);
				}

				else if (!toggleOn && arg.StartsWith("no")) 
				{
                    arg = arg.Remove(0, 2);
                }

				// Add/remove flags based on if they appeared as arguments, 
				// and whether they were negated with '!' or 'No'
				for (var i = 0; i < flagNames.Count(); i++) 
				{
					if (arg == flagNames.ElementAt(i)) 
					{
						if (toggleOn)
						{
							SetFlags(flagValues[i]);
						}

						else 
						{
                            RemoveFlags(flagValues[i]);
                        }
                    }
                }
			}
		}
	}
}
