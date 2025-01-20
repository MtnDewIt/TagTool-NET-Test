using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Commands.Common;
using TagTool.IO;
using TagTool.Scripting;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using TagTool.Cache.HaloOnline;
using TagTool.BlamFile;
using TagTool.Cache.Resources;

namespace TagTool.Commands.Modding
{
	class ApplyModPackageTagsCommand : Command
	{
		private GameCacheHaloOnlineBase BaseCache { get; }

		private GameCacheModPackage ModCache { get; }

		private Dictionary<int, int> TagMapping;

		private Stream CacheStream;

		private Dictionary<string, CachedTag> CacheTagsByName;

		private Dictionary<StringId, StringId> StringIdMapping;

		private HashSet<string> BlacklistedTags;
		private HashSet<string> ForceAppliedTags;
		private HashSet<string> ForceBlacklistedTags;
		private HashSet<string> AppliedTags;
		private Dictionary<string, List<string>> DependencyRules;

		public ApplyModPackageTagsCommand(GameCacheModPackage modCache) :
			base(false,

				"ApplyModPackageTags",
				"Apply current mod package to the base cache, optionally excluding tags / tag groups. \n",

				"ApplyModPackageTags [Tag cache index (default=0)]",

				"Apply current mod package to the base cache, optionally excluding tags / tag groups. \n") {
			BaseCache = modCache.BaseCacheReference;
			ModCache = modCache;
			BlacklistedTags = new HashSet<string>();
			ForceAppliedTags = new HashSet<string>();
			ForceBlacklistedTags = new HashSet<string>();
			AppliedTags = new HashSet<string>();
			InitializeDependencyRules();
		}

		private void InitializeDependencyRules()
		{
		    DependencyRules = new Dictionary<string, List<string>>
		    {
		        { ".bitmap", new List<string> { ".shader" } },
		        { ".shader", new List<string> { ".render_model" } },
		        { ".render_model", new List<string> { ".model" } }
		    };
		}

		public override object Execute(List<string> args)
		{			
			int tagCacheIndex = -1;

			if (args.Count > 1)
				return new TagToolError(CommandError.ArgCount);

			if (args.Count == 0)
				tagCacheIndex = 0;
			else if (!int.TryParse(args[0], System.Globalization.NumberStyles.Integer, null, out tagCacheIndex))
				return new TagToolError(CommandError.ArgInvalid, $"\"{args[0]}\"");

			if (tagCacheIndex != ModCache.GetCurrentTagCacheIndex()) {
				if (!ModCache.SetActiveTagCache(tagCacheIndex)) {
					return new TagToolError(CommandError.CustomMessage, "Failed to apply mod package to base cache, no changes applied");
				}
			}

			Console.WriteLine("Blacklisting Tags:\n");

			Console.WriteLine("1. You can blacklist a specific tag by entering its name -> vehicles/warthog");
			Console.WriteLine("Examples:\tweapons/rocket_launcher\t\tcharacters/masterchief\n");

			Console.WriteLine("2. You can blacklist an entire group by using the group name followed by a '/' -> vehicles/");
			Console.WriteLine("Examples:\tvehicles/\t\tweapons/\t\tcharacters/\n");

			Console.WriteLine("3. You can include a tag from a blacklisted group by prepending a '+' -> +vehicles/warthog");
			Console.WriteLine("Examples:\t+weapons/rocket_launcher\t\t+characters/masterchief\n");

			Console.WriteLine("Please enter the list of blacklisted tags or keywords - one per line. Type 'Done' when finished.");

			string line = string.Empty;
			while (( line = Console.ReadLine() ) != "Done") {
				if (!string.IsNullOrWhiteSpace(line)) {
					line = line.Trim();
					if (line.StartsWith("+-") || line.StartsWith("-+")){
					    AppliedTags.Add(line.Substring(2));
					}
					else if (line.StartsWith("+")){
					    ForceAppliedTags.Add(line.Substring(1));
					}
					else if (line.StartsWith("-")){
					    ForceBlacklistedTags.Add(line.Substring(1));
					}
					else {
						BlacklistedTags.Add(line);
					}
				}
			}

			TagMapping = new Dictionary<int, int>();

			StringIdMapping = new Dictionary<StringId, StringId>();

			// build dictionary of names to tag instance for faster lookups
			CacheTagsByName = BaseCache.TagCache.TagTable
				.Where(tag => tag != null)
				.GroupBy(tag => $"{tag.Name}.{tag.Group}")
				.Select(tags => tags.Last())
				.ToDictionary(tag => $"{tag.Name}.{tag.Group}", tag => tag);


			// shut down base cache stream from mod cache and reopen once applying is complete
			using (CacheStream = BaseCache.OpenCacheReadWrite()) {

				for (int i = 0; i < ModCache.TagCache.Count; i++) {
					var modTag = ModCache.TagCache.GetTag(i);

					if (modTag != null) {
						if (!TagMapping.ContainsKey(modTag.Index))
							ConvertCachedTagInstance(ModCache.BaseModPackage, modTag, false);
					}
				}

				// fixup map files
				foreach (var mapFile in ModCache.BaseModPackage.MapFileStreams) {
					if (BaseCache is GameCacheModPackage) {
						var reader = new EndianReader(mapFile);

						MapFile map = new MapFile();
						map.Read(reader);
						var header = (CacheFileHeaderGenHaloOnline)map.Header;
						var modIndex = header.ScenarioTagIndex;
						TagMapping.TryGetValue(modIndex, out int newScnrIndex);
						header.ScenarioTagIndex = newScnrIndex;

						var modPackCache = BaseCache as GameCacheModPackage;
						modPackCache.AddMapFile(mapFile, header.MapId);
					}
					else {
						using (var reader = new EndianReader(mapFile)) {
							MapFile map = new MapFile();
							map.Read(reader);
							var header = (CacheFileHeaderGenHaloOnline)map.Header;
							var modIndex = header.ScenarioTagIndex;
							TagMapping.TryGetValue(modIndex, out int newScnrIndex);
							header.ScenarioTagIndex = newScnrIndex;
							var mapName = header.Name;

							var mapPath = $"{BaseCache.Directory.FullName}\\{mapName}.map";
							var file = new FileInfo(mapPath);
							var fileStream = file.OpenWrite();
							using (var writer = new EndianWriter(fileStream, map.EndianFormat)) {
								map.Write(writer);
							}
						}
					}
				}

				// apply .campaign file
				if (ModCache.BaseModPackage.CampaignFileStream != null && ModCache.BaseModPackage.CampaignFileStream.Length > 0) {

					if (BaseCache is GameCacheModPackage) {
						var BaseCacheContext = BaseCache as GameCacheModPackage;
						BaseCacheContext.SetCampaignFile(ModCache.BaseModPackage.CampaignFileStream);
					}
					else {
						var campaignFilepath = $"{BaseCache.Directory.FullName}\\halo3.campaign";
						var campaignFile = new FileInfo(campaignFilepath);
						using (var campaignFileStream = campaignFile.OpenWrite()) {
							ModCache.BaseModPackage.CampaignFileStream.CopyTo(campaignFileStream);
						}
					}
				}

				// apply fonts
				if (ModCache.BaseModPackage.FontPackage != null && ModCache.BaseModPackage.FontPackage.Length > 0) {
					using (var stream = ModCache.BaseModPackage.FontPackage) {
						BaseCache.SaveFonts(stream);
					}
				}

				// apply mod files
				if (ModCache.BaseModPackage.Files != null && ModCache.BaseModPackage.Files.Count > 0) {

					if (BaseCache is GameCacheHaloOnline) {
						Console.WriteLine("Mod Files exist in package. Overwrite in BaseCache? (y/n)");
						string response = Console.ReadLine();
						if (response.ToLower().StartsWith("y")) {
							Console.WriteLine("Please enter the directory for the Mod Files:");
							string directoryPath = Console.ReadLine();

							var directory = new DirectoryInfo(directoryPath);
							if (!directory.Exists) {
								Console.WriteLine("Directory not found.");
								return new TagToolError(CommandError.DirectoryNotFound);
							}

							Console.WriteLine("Writing Mod Files to Directory");
							foreach (var file in ModCache.BaseModPackage.Files) {
								Console.WriteLine("Writing: {0}", file.Key);
								try {
									var directoryName = Path.GetDirectoryName(file.Key);
									if (!string.IsNullOrEmpty(directoryName)) { directory.CreateSubdirectory(directoryName); }
								}
								catch (Exception ex) {
									Console.WriteLine($"Failed to create directory for '{file.Key}': {ex}");
									return new TagToolError(CommandError.FileIO);
								}
								BaseCache.AddModFile(Path.Combine(directory.FullName, file.Key), file.Value);
							}

						}
						else { Console.WriteLine("Skipping Mod Files"); }
					}
					else{
						foreach (var file in ModCache.BaseModPackage.Files) {
							Console.WriteLine("Copying: {0}", file.Key);
							BaseCache.AddModFile(file.Key, file.Value);
						}
					}
				}


				BaseCache.SaveTagNames();
				BaseCache.SaveStrings();
			}

			return true;
		}

		private CachedTag ConvertCachedTagInstance(ModPackage modPack, CachedTag modTag, bool isTagReference = true) {

			string fullTagName = string.Join('.', modTag.Name, modTag.Group);

			// Check if the tag should be applied (i.e., has a "+" in the blacklist list)
			bool forceApply = ForceAppliedTags.Contains(fullTagName) || ForceAppliedTags.Any(fullTagName.Contains);
			bool forceBlacklist = ForceBlacklistedTags.Contains(fullTagName) || ForceBlacklistedTags.Any(fullTagName.Contains);
			bool applyTag = AppliedTags.Contains(fullTagName) || AppliedTags.Any(fullTagName.Contains);

			if (forceApply && !applyTag)
			{
			    Console.WriteLine($"Included Tag: {fullTagName}");
				
			    var dependencies = GetTagDependencies(modTag);
			    foreach (var dependency in dependencies)
			    {
			        if (!ForceAppliedTags.Contains(dependency))
			        {
			            ForceAppliedTags.Add(dependency);
			            Console.WriteLine($"Including dependency: {dependency}");
			        }
			    }
			}
			else if (applyTag)
			{
			    Console.WriteLine($"Applied Tag: {fullTagName}");

			    var dependencies = GetTagDependencies(modTag);
			    foreach (var dependency in dependencies)
			    {
			        if (!BlacklistedTags.Contains(dependency))
			        {
			            BlacklistedTags.Add(dependency);
			            Console.WriteLine($"Blacklisting dependency: {dependency}");
			        }
			    }
			}
			else if (forceBlacklist || BlacklistedTags.Contains(fullTagName) || BlacklistedTags.Any(fullTagName.Contains)) {
				Console.WriteLine($"Blacklisted: {fullTagName}");

				// Check if the tag exists in the base cache
				if (CacheTagsByName.TryGetValue(fullTagName, out CachedTag baseTag)) {
					// If tag exists in base cache, just return the reference to it (keep the reference intact)
					TagMapping[modTag.Index] = baseTag.Index;
					return baseTag;
				}

				// If tag doesn't exist in the base cache, just return null (don't process)
				return null;
			}

			// If tag exists in the base cache and is not blacklisted, we preserve the reference
			if (TagMapping.ContainsKey(modTag.Index))
				return BaseCache.TagCache.GetTag(TagMapping[modTag.Index]);   // get the matching tag in the destination package

			// Proceed with normal tag conversion if it's not blacklisted or applied

			// Determine if tag requires conversion
			if (( (CachedTagHaloOnline)modTag ).IsEmpty()) {
				//modtag references a base tag, figure out which one is it and add it to the mapping
				CachedTag cacheTag;
				if (CacheTagsByName.TryGetValue($"{modTag.Name}.{modTag.Group}", out cacheTag)) {
					TagMapping[modTag.Index] = cacheTag.Index;
					return cacheTag;
				}

				// Failed to find tag in base cache
				Console.Error.WriteLine($"Failed to find {fullTagName} in the base cache, returning null tag reference.");

				// check if anything actually depends on this tag
				if (!isTagReference)
					return null;

				throw new Exception("Failed to find tag when applying.");
			}
			else {
				Console.WriteLine($"Converting {fullTagName}...");
				CachedTag newTag;
				if (!CacheTagsByName.TryGetValue($"{fullTagName}", out newTag)) {
					newTag = BaseCache.TagCache.AllocateTag(modTag.Group);
					newTag.Name = modTag.Name;
				}

				TagMapping.Add(modTag.Index, newTag.Index);
				var definitionType = BaseCache.TagCache.TagDefinitions.GetTagDefinitionType(modTag.Group);

				var tagDefinition = ModCache.Deserialize(ModCache.OpenCacheRead(CacheStream), modTag);
				tagDefinition = ConvertData(modPack, tagDefinition);

				if (definitionType == typeof(ForgeGlobalsDefinition)) {
					tagDefinition = ConvertForgeGlobals((ForgeGlobalsDefinition)tagDefinition);
				}
				else if (definitionType == typeof(Scenario)) {
					tagDefinition = ConvertScenario(modPack, (Scenario)tagDefinition);
				}
				BaseCache.Serialize(CacheStream, newTag, tagDefinition);

				foreach (var resourcePointer in ( (CachedTagHaloOnline)modTag ).ResourcePointerOffsets) {
					var newTagHo = newTag as CachedTagHaloOnline;
					newTagHo.AddResourceOffset(resourcePointer);
				}
				return newTag;
			}
		}

		private IEnumerable<string> GetTagDependencies(CachedTag tag)
		{
		    var dependencies = new HashSet<string>();
		    var tagDefinition = ModCache.Deserialize(ModCache.OpenCacheRead(CacheStream), tag);
		    CollectDependencies(tagDefinition, dependencies);
		    return dependencies;
		}

		private void CollectDependencies(object tagData, HashSet<string> dependencies)
		{
		    switch (tagData)
		    {
		        case TagStructure structure:
		            foreach (var field in TagStructure.GetTagFieldEnumerable(structure.GetType(), BaseCache.Version, BaseCache.Platform))
		            {
		                var value = field.GetValue(structure);
		                CollectDependencies(value, dependencies);
		            }
		            break;
		        case CachedTag tag:
		            dependencies.Add($"{tag.Name}.{tag.Group}");
		            ApplyDependencyRules(tag, dependencies);
		            break;
		        case IList collection:
		            foreach (var item in collection)
		            {
		                CollectDependencies(item, dependencies);
		            }
		            break;
		    }
		}

		private void ApplyDependencyRules(CachedTag tag, HashSet<string> dependencies)
		{
		    string fullTagName = $"{tag.Name}.{tag.Group}";
		    foreach (var rule in DependencyRules)
		    {
		        if (fullTagName.EndsWith(rule.Key))
		        {
		            foreach (var dependencyExtension in rule.Value)
		            {
		                var dependentTagName = $"{tag.Name}.{dependencyExtension}";
		                if (CacheTagsByName.TryGetValue(dependentTagName, out CachedTag dependentTag))
		                {
		                    dependencies.Add(dependentTagName);
		                    CollectDependencies(dependentTag, dependencies);
		                }
		            }
		        }
		    }
		}

		private object ConvertData(ModPackage modPack, object data) {
			switch (data) {
				case StringId _:
					return ConvertStringId(modPack, (StringId)data);

				case null:
				case string _:
				case ValueType _:
					return data;
				case PageableResource resource:
					return ConvertPageableResource(modPack, resource);
				case TagStructure structure:
					return ConvertStructure(modPack, structure);
				case IList collection:
					return ConvertCollection(modPack, collection);
				case CachedTag tag:
					return ConvertCachedTagInstance(modPack, tag);

			}
			return data;
		}

		private StringId ConvertStringId(ModPackage modPack, StringId stringId) {
			if (StringIdMapping.ContainsKey(stringId))
				return StringIdMapping[stringId];
			else {
				StringId cacheStringId;
				var modString = modPack.StringTable.GetString(stringId);
				var cacheStringTest = BaseCache.StringTable.GetString(stringId);

				if (cacheStringTest != null && modString == cacheStringTest)            // check if base cache contains the exact same id with matching strings
					cacheStringId = stringId;
				else if (BaseCache.StringTable.Contains(modString))                // try to find the string among all stringids
					cacheStringId = BaseCache.StringTable.GetStringId(modString);
				else                                                                    // add new stringid
					cacheStringId = BaseCache.StringTable.AddString(modString);

				StringIdMapping[stringId] = cacheStringId;
				return cacheStringId;
			}
		}

		private PageableResource ConvertPageableResource(ModPackage modPack, PageableResource resource) {
			if (resource.Page.Index == -1)
				return resource;

			var resourceStream = new MemoryStream();
			var resourceCache = ModCache.ResourceCaches.GetResourceCache(ResourceLocation.Mods);
			resourceCache.Decompress(modPack.ResourcesStream, resource.Page.Index, resource.Page.CompressedBlockSize, resourceStream);
			resourceStream.Position = 0;
			resource.ChangeLocation(ResourceLocation.ResourcesB);
			resource.Page.OldFlags &= ~OldRawPageFlags.InMods;
			BaseCache.ResourceCaches.AddResource(resource, resourceStream);

			return resource;
		}

		private IList ConvertCollection(ModPackage modPack, IList collection) {
			if (collection is null || collection.Count == 0)
				return collection;

			for (var i = 0; i < collection.Count; i++) {
				var oldValue = collection[i];
				var newValue = ConvertData(modPack, oldValue);
				collection[i] = newValue;
			}

			return collection;
		}

		private T ConvertStructure<T>(ModPackage modPack, T data) where T : TagStructure {
			foreach (var tagFieldInfo in TagStructure.GetTagFieldEnumerable(data.GetType(), BaseCache.Version, BaseCache.Platform)) {
				var oldValue = tagFieldInfo.GetValue(data);

				if (oldValue is null)
					continue;

				var newValue = ConvertData(modPack, oldValue);
				tagFieldInfo.SetValue(data, newValue);
			}

			return data;
		}

		private ForgeGlobalsDefinition ConvertForgeGlobals(ForgeGlobalsDefinition forg) {
			var currentForgTag = BaseCache.TagCache.GetTag<ForgeGlobalsDefinition>("multiplayer\\forge_globals");
			var currentForg = (ForgeGlobalsDefinition)BaseCache.Deserialize(CacheStream, currentForgTag);

			// hardcoded base indices:
			int[] baseBlockCounts = new int[] { 0, 20, 173, 6, 83, 498, 9, 12 };

			for (int i = baseBlockCounts[0]; i < forg.ReForgeMaterialTypes.Count; i++)
				currentForg.ReForgeMaterialTypes.Add(forg.ReForgeMaterialTypes[i]);

			for (int i = baseBlockCounts[1]; i < forg.ReForgeMaterialTypes.Count; i++)
				currentForg.ReForgeMaterialTypes.Add(forg.ReForgeMaterialTypes[i]);

			for (int i = baseBlockCounts[2]; i < forg.ReForgeObjects.Count; i++)
				currentForg.ReForgeObjects.Add(forg.ReForgeObjects[i]);

			for (int i = baseBlockCounts[3]; i < forg.Descriptions.Count; i++)
				currentForg.Descriptions.Add(forg.Descriptions[i]);

			for (int i = baseBlockCounts[4]; i < forg.PaletteCategories.Count; i++)
				currentForg.PaletteCategories.Add(forg.PaletteCategories[i]);

			for (int i = baseBlockCounts[5]; i < forg.Palette.Count; i++)
				currentForg.Palette.Add(forg.Palette[i]);

			for (int i = baseBlockCounts[6]; i < forg.WeatherEffects.Count; i++)
				currentForg.WeatherEffects.Add(forg.WeatherEffects[i]);

			for (int i = baseBlockCounts[7]; i < forg.Skies.Count; i++)
				currentForg.Skies.Add(forg.Skies[i]);

			// move over the rest of the definition
			currentForg.InvisibleRenderMethod = forg.InvisibleRenderMethod;
			currentForg.DefaultRenderMethod = forg.DefaultRenderMethod;
			currentForg.PrematchCameraObject = forg.PrematchCameraObject;
			currentForg.PostmatchObject = forg.PostmatchObject;
			currentForg.ModifierObject = forg.ModifierObject;
			currentForg.KillVolumeObject = forg.KillVolumeObject;
			currentForg.GarbageVolumeObject = forg.GarbageVolumeObject;
			currentForg.FxObject = forg.FxObject;
			currentForg.FxLight = forg.FxLight;

			return currentForg;
		}

		private Scenario ConvertScenario(ModPackage modPack, Scenario scnr) {
			foreach (var expr in scnr.ScriptExpressions)
				ConvertScriptExpression(modPack, expr);

			return scnr;
		}

		public void ConvertScriptExpression(ModPackage modPack, HsSyntaxNode expr) {
			ConvertScriptExpressionData(modPack, expr);
		}

		public void ConvertScriptExpressionData(ModPackage modPack, HsSyntaxNode expr) {
			if (expr.Flags == HsSyntaxNodeFlags.Expression) {
				switch (expr.ValueType.HaloOnline) {
					case HsType.HaloOnlineValue.Sound:
					case HsType.HaloOnlineValue.Effect:
					case HsType.HaloOnlineValue.Damage:
					case HsType.HaloOnlineValue.LoopingSound:
					case HsType.HaloOnlineValue.AnimationGraph:
					case HsType.HaloOnlineValue.DamageEffect:
					case HsType.HaloOnlineValue.ObjectDefinition:
					case HsType.HaloOnlineValue.Bitmap:
					case HsType.HaloOnlineValue.Shader:
					case HsType.HaloOnlineValue.RenderModel:
					case HsType.HaloOnlineValue.StructureDefinition:
					case HsType.HaloOnlineValue.LightmapDefinition:
					case HsType.HaloOnlineValue.CinematicDefinition:
					case HsType.HaloOnlineValue.CinematicSceneDefinition:
					case HsType.HaloOnlineValue.BinkDefinition:
					case HsType.HaloOnlineValue.AnyTag:
					case HsType.HaloOnlineValue.AnyTagNotResolving:
						ConvertScriptTagReferenceExpressionData(modPack, expr);
						return;

					case HsType.HaloOnlineValue.AiLine when BitConverter.ToInt32(expr.Data, 0) != -1:
					case HsType.HaloOnlineValue.StringId:
						ConvertScriptStringIdExpressionData(modPack, expr);
						return;
					default:
						break;
				}
			}
		}

		public void ConvertScriptTagReferenceExpressionData(ModPackage modPack, HsSyntaxNode expr) {
			var tagIndex = BitConverter.ToInt32(expr.Data.ToArray(), 0);

			if (tagIndex == -1)
				return;

			if (tagIndex < 0 || tagIndex >= ModCache.TagCacheGenHO.Tags.Count)
			{
			    Console.Error.WriteLine($"Invalid tag index {tagIndex}");
			    return;
			}

			var tag = ConvertCachedTagInstance(modPack, ModCache.TagCacheGenHO.Tags[tagIndex]);

			if (tag == null)
			{
			    Console.Error.WriteLine($"Failed to convert tag reference for index {tagIndex}");
			    return;
			}

			expr.Data = BitConverter.GetBytes(tag.Index).ToArray();
		}

		public void ConvertScriptStringIdExpressionData(ModPackage modPack, HsSyntaxNode expr) {
			StringId modStringId = new StringId(BitConverter.ToUInt32(expr.Data.ToArray(), 0));

			// if string is invalid, don't convert
			if (modPack.StringTable.GetString(modStringId) == null)
				return;

			var edStringId = ConvertStringId(modPack, modStringId);
			expr.Data = BitConverter.GetBytes(edStringId.Value).ToArray();
		}
	}
}
