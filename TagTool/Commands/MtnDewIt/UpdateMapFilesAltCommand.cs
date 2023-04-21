using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TagTool.Cache;

namespace TagTool.Commands.Files
{
	class UpdateMapFilesAltCommand : Command
	{

		public GameCache Cache { get; }

		private const int MapNameOffset = 0x01A4;
		private const int ScenarioPathOffset = 0x01C8;
		private const int ScenarioMapIdOffset = 0x2DEC;
		private const int ScenarioTagIndexOffset = 0x2DF0;

		private const int ContentNameOffset = 0x42D4;
		private const int ContentMapNameOffset = 0x43D4;
		private static readonly int[] ContentMapIdOffsets = new[] { 0x33CC, 0xBE60, 0xBE80 };
		// I don't know what I'm doing I hope this works
		private Dictionary<int, string> MapNamesHack;

		public UpdateMapFilesAltCommand(GameCache cache)
			: base(true,
				  "UpdateMapFilesAlt",
				  "Updates the game's .map files to contain valid scenario indices. Alternate version for certain Halo Online porting scenarios.",
				  "UpdateMapFiles <MapInfo Directory>",
				  "Updates the game's .map files to contain valid scenario indices.")
		{
			Cache = cache;
		}
		
		public override object Execute(List<string> args)
		{
			if (args.Count > 1)
				return false;

			MapNamesHack = new Dictionary<int, string>();
			var scenarioIndices = new Dictionary<int, (ScenarioMapType, int)>();
			

			using (var stream = Cache.OpenCacheRead())
			using (var reader = new BinaryReader(stream)) {
				foreach (var tag in Cache.TagCache.FindAllInGroup("scnr")) {
					long headerOffset = -1;
					if (tag != null) {
						try { headerOffset = ((TagTool.Cache.HaloOnline.CachedTagHaloOnline)tag).HeaderOffset; }
						catch (Exception e) { Console.WriteLine($"Error casting Tag to CatchedTagHaloOnline, unable to get HeaderOffset. Defaulting to -1. Error message: {e.Message}"); }
					}
					
					if (((TagTool.Cache.HaloOnline.CachedTagHaloOnline)tag).HeaderOffset == -1)
						continue;

					reader.BaseStream.Position = headerOffset + tag.DefinitionOffset;
					var mapType = reader.ReadEnum<ScenarioMapType>();

					reader.BaseStream.Position = headerOffset + tag.DefinitionOffset + 0x8;
					var mapId = reader.ReadInt32();

					scenarioIndices[mapId] = (mapType, tag.Index);
					MapNamesHack[tag.Index] = tag.Name;

				}
			}

			var mainmenuMapFile = Cache.Directory.GetFiles("mainmenu.map")[0];
			var guardianMapFile = Cache.Directory.GetFiles("guardian.map")[0];

			foreach (var entry in scenarioIndices) {

				var scenarioPath = MapNamesHack.ContainsKey(entry.Value.Item2) ? MapNamesHack[entry.Value.Item2]
					: $"0x{entry.Value:X4}";

				//var scenarioPath = Cache.TagNames.ContainsKey(entry.Value.Item2) ?
				//	Cache.TagNames[entry.Value.Item2] :
				//	$"0x{entry.Value:X4}";

				var mapName = scenarioPath.Split('\\').Last();
				var mapFile = new FileInfo(Path.Combine(Cache.Directory.FullName, $"{mapName}.map"));

				if (!mapFile.Exists)
					mapFile = ((entry.Value.Item1 == ScenarioMapType.Multiplayer) ? guardianMapFile : mainmenuMapFile).CopyTo(mapFile.FullName);

				DirectoryInfo mapInfoDir = null;

				if (args.Count == 1) {
					mapInfoDir = new DirectoryInfo(args[0]);
				}
				else {
					if (Directory.Exists("info")) {
						mapInfoDir = new DirectoryInfo("info");
					}
				}

				using (var stream = mapFile.Open(FileMode.Open, FileAccess.ReadWrite))
				using (var reader = new BinaryReader(stream))
				using (var writer = new BinaryWriter(stream)) {
					if (reader.ReadInt32() != new TagTool.Common.Tag("head").Value)
						continue;

					stream.Position = MapNameOffset;
					for (var i = 0; i < 32; i++)
						writer.Write(i < mapName.Length ? mapName[i] : '\0');

					stream.Position = ScenarioPathOffset;
					for (var i = 0; i < 256; i++)
						writer.Write(i < scenarioPath.Length ? scenarioPath[i] : '\0');

					stream.Position = ScenarioMapIdOffset;
					writer.Write(entry.Key);

					stream.Position = ScenarioTagIndexOffset;
					writer.Write(entry.Value.Item2);

					bool using_mapinfo = false;

					if (mapInfoDir != null) {
						var mapInfoFiles = mapInfoDir.GetFiles(mapName + ".mapinfo");

						if (mapInfoFiles != null && mapInfoFiles.Length > 0) {
							var mapInfoFile = mapInfoFiles[0];
							using_mapinfo = true;

							using (var infoStream = mapInfoFile.OpenRead())
							using (var infoReader = new BinaryReader(infoStream)) {
								var mapNames = new byte[12][];

								infoStream.Position = 0x44;
								for (var i = 0; i < 12; i++)
									mapNames[i] = infoReader.ReadBytes(0x40);

								stream.Position = 0x33D4;
								foreach (var mapNameUnicode in mapNames) {
									for (var c = 0; c < mapNameUnicode.Length; c += 2) {
										var temp = mapNameUnicode[c];
										mapNameUnicode[c] = mapNameUnicode[c + 1];
										mapNameUnicode[c + 1] = temp;
									}

									writer.Write(mapNameUnicode);
								}

								var mapDescriptions = new byte[12][];

								infoStream.Position = 0x344;
								for (var i = 0; i < 12; i++) {
									mapDescriptions[i] = infoReader.ReadBytes(0x100);
								}

								stream.Position = 0x36D4;
								foreach (var mapDescription in mapDescriptions) {
									for (var c = 0; c < mapDescription.Length; c += 2) {
										var temp = mapDescription[c];
										mapDescription[c] = mapDescription[c + 1];
										mapDescription[c + 1] = temp;
									}

									writer.Write(mapDescription);
								}

								stream.Position = 0xBD88;
								writer.Write(mapNames[0], 0, 32);

								var description = new string(mapDescriptions[0].Select(i => Convert.ToChar(i)).ToArray()).Replace("\0", "");

								stream.Position = 0xBDA8;
								writer.Write(description.ToArray());

								for (var i = 0; i < (0x80 - description.Length); i++)
									writer.Write('\0');
							}
						}
					}

					if (entry.Value.Item1 == ScenarioMapType.Multiplayer) {
						var contentName = scenarioPath.StartsWith("levels\\dlc\\") ?
							$"dlc_{mapName}" :
							$"m_{mapName}";

						stream.Position = ContentNameOffset;
						for (var i = 0; i < 256; i++)
							writer.Write(i < contentName.Length ? contentName[i] : '\0');

						stream.Position = ContentMapNameOffset;
						for (var i = 0; i < 256; i++)
							writer.Write(i < mapName.Length ? mapName[i] : '\0');

						foreach (var offset in ContentMapIdOffsets) {
							stream.Position = offset;
							writer.Write(entry.Key);
						}
					}

					if (using_mapinfo) {
						Console.WriteLine($"Scenario tag index for {mapFile.Name}: 0x{entry.Value.Item2:X4} (using map info)");
					}
					else {
						Console.WriteLine($"Scenario tag index for {mapFile.Name}: 0x{entry.Value.Item2:X4} (WARNING: not using map info)");
					}

				}
			}

			Console.WriteLine("Done!");

			return true;
		}

	public enum ScenarioMapType : sbyte
	{
		SinglePlayer,
		Multiplayer,
		MainMenu
	}

	}
}