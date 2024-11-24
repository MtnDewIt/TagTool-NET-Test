using System;
using System.Collections.Generic;
using System.Linq;

namespace TagTool.Commands
{
	/// <summary>
	/// Helper class for parsing a RuntimeCommand, identifying its arguments (if applicable), and validating the RuntimeCommand as a whole.
	/// </summary>
	public class ParseResult
	{

		/// <summary>
		/// Conveys the validity of the parsed command.
		/// <br>If the RuntimeCommand is parsed successfully, IsValid will be true.</br>
		/// <br>If parsing fails, or required arguments cannot be resolved, IsValid will be false.</br>
		/// </summary>
		public bool IsValid { get; set; } = true;
		/// <summary>
		/// Contains any arguments that were identified within the command string. If none are found, the list will be empty (not null).</string>
		/// <br>Sometimes a command has no parameters. Sometimes no valid Parameters can be determined.</br>
		/// </summary>
		public List<string> Parameters { get; set; } = new List<string>();
		/// <summary>
		/// Response strings that will be sent to the appropriate party (usually the player that issued a command).
		/// </summary>
		public List<string> Response { get; set; } = new List<string>();


		/// <summary>
		/// Generate a <see cref="ParseResult"/> for the specified <paramref name="arguments"/>.
		/// </summary> 
		/// <param name="arguments">The args being parsed.</param>
		public static ParseResult Parse(params Arg[] arguments) {

			// Process Args
			if ((arguments?.Length ?? 0) > 0) {

				ParseResult result = new ParseResult() { IsValid = true };

				List<Arg> args = new List<Arg>(arguments);

				foreach (Arg arg in args) {

					switch (arg.ArgType) {

						case Arg.Type.Bool:

							// Split on spaces and try to interpret anything that could be a boolean
							string sub = arg.Value?.Trim() ?? string.Empty;
							if (string.IsNullOrWhiteSpace(sub)) { result.Parameters.Add(null); }
							sub = sub.ToLowerInvariant();
							if (bools.Contains(sub)) { result.Parameters.Add(bools.IndexOf(sub) % 2 == 0 ? "true" : "false"); }
							else { result.Parameters.Add(null); }
							break;

						case Arg.Type.String:
							string content = arg.Value ?? string.Empty;
							//if (!content.Contains('"') || content.Count(c => c == '"') < 2) { result.Parameters.Add(null); break; }
							if (string.IsNullOrWhiteSpace(content)) { result.Parameters.Add(null); break; }
							// Get the string between the first two quotes
							string quote = content.Trim();
							if (!string.IsNullOrWhiteSpace(quote)) { result.Parameters.Add(quote); }
							else { result.Parameters.Add(null); }
							break;

						case Arg.Type.FilePath:
							string path = arg.Value ?? string.Empty;
							if (string.IsNullOrWhiteSpace(path)) { result.Parameters.Add(null); break; }
							// Get the string between the first two quotes
							path = path?.Trim() ?? string.Empty;
							if (string.IsNullOrWhiteSpace(path)) { result.Parameters.Add(null); break; }
							// Check if the path is a valid directory or file path
							try { if (System.IO.Path.Exists(path)) { result.Parameters.Add(path); break; } } catch { }
							result.Parameters.Add(null);
							break;

						case Arg.Type.FileNameJSON:
							if (!string.IsNullOrWhiteSpace(arg.Value) && arg.Value.Contains(".json")) {
								result.Parameters.Add(arg.Value.Substring(0, arg.Value.IndexOf(".json") + 5));
							}
							else { result.Parameters.Add(null); }
							break;

						default: break;

					}

					if ((result.Parameters.Count == 0 || result.Parameters[result.Parameters.Count - 1] == null) && arg.IsRequired) {
						result.IsValid = false; result.Response.Add("Command Failed: Unable to parse " + arg.Name + " parameter.");
					}

					// Add response and return if invalid
					if (!result.IsValid) {
						switch (arg.ArgType) {
							case Arg.Type.Bool: result.Response.Add("Boolean arguments must embody the Platonic ideal of true or false."); break;
							case Arg.Type.String: result.Response.Add("String arguments must be enclosed in quotes."); break;
							case Arg.Type.FilePath: result.Response.Add("Filepaths must be enclosed in quotes and valid (exist)."); break;
							case Arg.Type.FileNameJSON: result.Response.Add("JSON file names must end in '.json'."); break;
							default: return new ParseResult { IsValid = false, Response = new List<string> { "Invalid Argument Type Encountered." } };
						}
						return result;
					}

				}

				return result;

			}

			else { return new ParseResult { IsValid = false, Response = new List<string> { "Command Failed: No arguments to parse." } }; }

		}

		private static readonly List<string> bools = new List<string>{ "1", "0", "true", "false", "yes", "no", "on", "off" };

	}

	public class Arg
	{
		public string Name { get; set; } = "";
		public bool IsRequired { get; set; } = true;
		public string Value { get; set; } = null;
		public Type ArgType { get; set; } = Arg.Type.String;
		public Arg(string Name, string Value, Type ArgType, bool Optional) {
			this.Name = Name;
			this.Value = Value;
			this.ArgType = ArgType;
			IsRequired = !Optional;
		}

		public enum Type
		{
			Bool,
			String,
			FilePath,
			FileNameJSON,
		}

	}

}
