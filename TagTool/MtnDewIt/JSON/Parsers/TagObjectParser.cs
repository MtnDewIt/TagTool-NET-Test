using System;
using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.MtnDewIt.JSON.Handlers;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using TagTool.Bitmaps.DDS;
using TagTool.Bitmaps;
using TagTool.Common;
using TagTool.IO;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using TagTool.Scripting.Compiler;
using System.Collections.Generic;
using TagTool.Commands.Common;
using TagTool.Animations;
using TagTool.MtnDewIt.Animations;
using TagTool.Tags.Resources;
using TagTool.Commands;
using TagTool.MtnDewIt.JSON.Objects;

namespace TagTool.MtnDewIt.JSON.Parsers
{
    public class TagObjectParser 
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;
        private Stream CacheStream;
        private TagObjectHandler Handler;

        public TagObjectParser(GameCache cache, GameCacheHaloOnline cacheContext, Stream cacheStream)
        {
            Cache = cache;
            CacheContext = cacheContext;
            CacheStream = cacheStream;
            Handler = new TagObjectHandler(Cache, CacheContext, CacheStream);
        }

        public void ParseFile(string filePath) 
        {
            var jsonData = File.ReadAllText($@"{filePath}.json");
            var tagObject = Handler.Deserialize(jsonData);

            Cache.TagCache.TryGetTag($@"{tagObject.TagName}.{tagObject.TagType}", out var tag);

            if (tagObject.Generate && tag == null)
            {
                Cache.TagCache.TryParseGroupTag(tagObject.TagType, out var tagGroup);
                var type = Cache.TagCache.TagDefinitions.GetTagDefinitionType(tagGroup);
                tag = Cache.TagCache.AllocateTag(type, tagObject.TagName);
                var definition = (TagStructure)Activator.CreateInstance(type);
                CacheContext.Serialize(CacheStream, tag, definition);
                CacheContext.SaveTagNames();
            }

            switch (tagObject.TagData) 
            {
                case Bitmap:
                    ParseBitmapData(tagObject, tag);
                    break;
                case ModelAnimationGraph:
                    ParseAnimationData(tagObject, tag);
                    break;
                case MultilingualUnicodeStringList:
                    ParseUnicodeStringData(tagObject, tag);
                    break;
                case ParticleModel:
                    ParseParticleModelData(tagObject, tag);
                    break;
                case RenderModel:
                    ParseRenderModelData(tagObject, tag);
                    break;
                case Scenario:
                    ParseScenarioData(tagObject, tag);
                    break;
                case ScenarioLightmapBspData:
                    ParseScenarioLightmapBspData(tagObject, tag);
                    break;
                case ScenarioStructureBsp:
                    ParseScenarioStructureBspData(tagObject, tag);
                    break;
                case Sound:
                    ParseSoundData(tagObject, tag);
                    break;
                default:
                    Cache.Serialize(CacheStream, tag, tagObject.TagData);
                    break;
            }

            Cache.SaveStrings();
        }

        public void ParseBitmapData(TagObject tagObject, CachedTag tagInstance) 
        {
            var tagDefinition = Cache.Deserialize<Bitmap>(CacheStream, tagInstance);
            var tagData = tagObject.TagData as Bitmap;

            if (tagObject.BitmapResources != null)
            {
                foreach (var resource in tagObject.BitmapResources)
                {
                    AddBitmap(tagDefinition, resource.BitmapIndex, $@"{Program.TagToolDirectory}\Tools\JSON\data\{tagObject.TagName}\{resource.DDSFile}");
                }

                Cache.Serialize(CacheStream, tagInstance, tagDefinition);
            }
            else 
            {
                tagData.HardwareTextures = tagDefinition.HardwareTextures;
                tagData.InterleavedHardwareTextures = tagDefinition.InterleavedHardwareTextures;

                Cache.Serialize(CacheStream, tagInstance, tagData);
            }
        }

        public void ParseAnimationData(TagObject tagObject, CachedTag tagInstance) 
        {
            var tagDefinition = Cache.Deserialize<ModelAnimationGraph>(CacheStream, tagInstance);
            var tagData = tagObject.TagData as ModelAnimationGraph;

            tagData.ResourceGroups = tagDefinition.ResourceGroups;

            Cache.Serialize(CacheStream, tagInstance, tagData);

            if (tagObject.AnimationData != null) 
            {
                foreach (var resource in tagObject.AnimationData.AnimationResources)
                {
                    AddAnimation(tagInstance, $@"{Program.TagToolDirectory}\Tools\JSON\data\{tagObject.TagName}\{resource.AnimationFile}");
                }

                if (tagObject.AnimationData.SortModes)
                {
                    SortModes(tagInstance);
                }
            }
        }

        public void ParseUnicodeStringData(TagObject tagObject, CachedTag tagInstance) 
        {
            var tagDefinition = Cache.Deserialize<MultilingualUnicodeStringList>(CacheStream, tagInstance);

            if (tagObject.UnicodeStrings != null) 
            {
                foreach (var unicodeString in tagObject.UnicodeStrings)
                {
                    AddString(tagDefinition, unicodeString.StringIdName, unicodeString.StringIdContent);
                }
            }

            Cache.Serialize(CacheStream, tagInstance, tagDefinition);
        }

        public void ParseParticleModelData(TagObject tagObject, CachedTag tagInstance)
        {
            var tagDefinition = Cache.Deserialize<ParticleModel>(CacheStream, tagInstance);
            var tagData = tagObject.TagData as ParticleModel;

            tagData.Geometry = tagDefinition.Geometry;

            Cache.Serialize(CacheStream, tagInstance, tagData);
        }

        public void ParseRenderModelData(TagObject tagObject, CachedTag tagInstance)
        {
            var tagDefinition = Cache.Deserialize<RenderModel>(CacheStream, tagInstance);
            var tagData = tagObject.TagData as RenderModel;

            tagData.Geometry = tagDefinition.Geometry;

            Cache.Serialize(CacheStream, tagInstance, tagData);
        }

        public void ParseScenarioData(TagObject tagObject, CachedTag tagInstance) 
        {
            var tagDefinition = Cache.Deserialize<Scenario>(CacheStream, tagInstance);
            var tagData = tagObject.TagData as Scenario;

            tagData.ScriptStrings = tagDefinition.ScriptStrings;
            tagData.Scripts = tagDefinition.Scripts;
            tagData.Globals = tagDefinition.Globals;
            tagData.ScriptSourceFileReferences = tagDefinition.ScriptSourceFileReferences;
            tagData.ScriptExpressions = tagDefinition.ScriptExpressions;

            Cache.Serialize(CacheStream, tagInstance, tagData);

            if (tagObject.BlamScriptResource != null)
            {
                CompileScript(tagInstance, $@"{Program.TagToolDirectory}\Tools\JSON\data\{tagObject.TagName}\scripts\{tagObject.BlamScriptResource.BlamScriptFile}");
            }
        }

        public void ParseScenarioLightmapBspData(TagObject tagObject, CachedTag tagInstance)
        {
            var tagDefinition = Cache.Deserialize<ScenarioLightmapBspData>(CacheStream, tagInstance);
            var tagData = tagObject.TagData as ScenarioLightmapBspData;

            tagData.Geometry = tagDefinition.Geometry;

            Cache.Serialize(CacheStream, tagInstance, tagData);
        }

        public void ParseScenarioStructureBspData(TagObject tagObject, CachedTag tagInstance)
        {
            var tagDefinition = Cache.Deserialize<ScenarioStructureBsp>(CacheStream, tagInstance);
            var tagData = tagObject.TagData as ScenarioStructureBsp;

            tagData.DecoratorGeometry = tagDefinition.DecoratorGeometry;
            tagData.Geometry = tagDefinition.Geometry;
            tagData.CollisionBsp = tagDefinition.CollisionBsp;
            tagData.PathfindingResource = tagDefinition.PathfindingResource;

            Cache.Serialize(CacheStream, tagInstance, tagData);
        }

        public void ParseSoundData(TagObject tagObject, CachedTag tagInstance)
        {
            var tagDefinition = Cache.Deserialize<Sound>(CacheStream, tagInstance);
            var tagData = tagObject.TagData as Sound;

            tagData.Resource = tagDefinition.Resource;

            Cache.Serialize(CacheStream, tagInstance, tagData);
        }

        public void AddString(MultilingualUnicodeStringList unic, string stringIdName, string stringIdContent)
        {
            var stringIdIndex = Cache.StringTable.IndexOf(stringIdName);

            if (stringIdIndex < 0)
            {
                Cache.StringTable.AddString(stringIdName);
                Cache.SaveStrings();

                stringIdIndex = Cache.StringTable.IndexOf(stringIdName);
            }

            var stringId = Cache.StringTable.GetStringId(stringIdIndex);

            var parsedContent = new Regex(@"\\[uU]([0-9A-F]{4})").Replace(stringIdContent, match => ((char)Int32.Parse(match.Value.Substring(2), NumberStyles.HexNumber)).ToString());

            var localizedStr = unic.Strings.FirstOrDefault(s => s.StringID == stringId);

            if (localizedStr == null)
            {
                localizedStr = new LocalizedString
                {
                    StringID = stringId,
                    StringIDStr = stringIdName
                };

                unic.Strings.Add(localizedStr);
            }

            unic.SetString(localizedStr, GameLanguage.English, parsedContent);
        }

        public void AddBitmap(Bitmap bitmap, int bitmapIndex, string DDS)
        {
            bitmap.Flags = BitmapRuntimeFlags.UsingTagInteropAndTagResource;
            bitmap.Images.Add(new Bitmap.Image { Signature = new Tag("bitm") });
            bitmap.HardwareTextures.Add(new TagResourceReference());

            var imageIndex = bitmapIndex;
            BitmapImageCurve curve = BitmapImageCurve.xRGB;

            DDSFile dds = new DDSFile();

            using (var imageStream = File.OpenRead(DDS))
            using (var reader = new EndianReader(imageStream))
            {
                dds.Read(reader);
            }

            var bitmapTextureInteropDefinition = BitmapInjector.CreateBitmapResourceFromDDS(Cache, dds, curve);
            var reference = Cache.ResourceCache.CreateBitmapResource(bitmapTextureInteropDefinition);

            bitmap.HardwareTextures[imageIndex] = reference;
            bitmap.Images[imageIndex] = BitmapUtils.CreateBitmapImageFromResourceDefinition(bitmapTextureInteropDefinition.Texture.Definition.Bitmap);
        }

        public void AddAnimation(CachedTag tag, string animationFile)
        {
            var jmad = CacheContext.Deserialize<ModelAnimationGraph>(CacheStream, tag);

            var filepath = new FileInfo(animationFile);

            string file_extension = filepath.Extension;

            var AnimationType = ModelAnimationGraph.FrameType.Base;
            var isWorldRelative = false;
            var FrameInfoType = ModelAnimationTagResource.GroupMemberMovementDataType.None;

            switch (file_extension.ToUpper())
            {
                case ".JMM":
                    break;
                case ".JMW":
                    isWorldRelative = true;
                    break;
                case ".JMO":
                    AnimationType = ModelAnimationGraph.FrameType.Overlay;
                    break;
                case ".JMR":
                    AnimationType = ModelAnimationGraph.FrameType.Replacement;
                    break;
                case ".JMA":
                    FrameInfoType = ModelAnimationTagResource.GroupMemberMovementDataType.dx_dy;
                    break;
                case ".JMT":
                    FrameInfoType = ModelAnimationTagResource.GroupMemberMovementDataType.dx_dy_dyaw;
                    break;
                case ".JMZ":
                    FrameInfoType = ModelAnimationTagResource.GroupMemberMovementDataType.dx_dy_dz_dyaw;
                    break;
                default:
                    new TagToolError(CommandError.CustomError, $"Filetype {file_extension.ToUpper()} not recognized!");
                    return;
            }

            bool replacing = false;
            string file_name = Path.GetFileNameWithoutExtension(filepath.FullName).Replace(' ', ':');
            StringId animation_name = CacheContext.StringTable.GetStringId(file_name);

            int existingIndex = -1;
            if (animation_name == StringId.Invalid)
                animation_name = CacheContext.StringTable.AddString(file_name);
            else
            {
                existingIndex = jmad.Animations.FindIndex(n => n.Name == animation_name);
                if (existingIndex != -1)
                    replacing = true;
            }

            var importer = new InlineAnimationImporter(CacheStream);

            if (!importer.Import(filepath.FullName))
            {
                new TagToolError(CommandError.FileIO);
            }

            if (importer.Version >= 16394)
            {
                new TagToolError(CommandError.CustomError, $@"Invalid Animation Format");
            }

            List<InlineAnimationImporter.AnimationNode> newAnimationNodes = new List<InlineAnimationImporter.AnimationNode>();
            foreach (var skellynode in jmad.SkeletonNodes)
            {
                string nodeName = Cache.StringTable.GetString(skellynode.Name);
                int matching_index = importer.AnimationNodes.FindIndex(x => x.Name.Equals(nodeName));
                if (matching_index == -1)
                {
                    new TagToolWarning($"No node matching '{nodeName}' found in imported file! Will proceed with blank data for missing node");
                    newAnimationNodes.Add(new InlineAnimationImporter.AnimationNode()
                    {
                        Name = nodeName,
                        FirstChildNode = skellynode.FirstChildNodeIndex,
                        NextSiblingNode = skellynode.NextSiblingNodeIndex,
                        ParentNode = skellynode.ParentNodeIndex
                    });
                }
                else
                {
                    InlineAnimationImporter.AnimationNode matching_node = importer.AnimationNodes[matching_index];
                    matching_node.FirstChildNode = skellynode.FirstChildNodeIndex;
                    matching_node.NextSiblingNode = skellynode.NextSiblingNodeIndex;
                    matching_node.ParentNode = skellynode.ParentNodeIndex;
                    newAnimationNodes.Add(matching_node);
                }
            }

            importer.AnimationNodes = newAnimationNodes;

            importer.ProcessNodeFrames(CacheContext, jmad, AnimationType, FrameInfoType);

            var AnimationBlock = new ModelAnimationGraph.Animation
            {
                Name = animation_name,
                AnimationData = new ModelAnimationGraph.Animation.SharedAnimationData
                {
                    AnimationType = AnimationType,
                    FrameInfoType = (FrameInfoType)FrameInfoType,
                    BlendScreen = -1,
                    DesiredCompression = ModelAnimationGraph.Animation.CompressionValue.BestAccuracy,
                    CurrentCompression = ModelAnimationGraph.Animation.CompressionValue.BestAccuracy,
                    FrameCount = (short)importer.frameCount,
                    NodeCount = (sbyte)importer.AnimationNodes.Count,
                    NodeListChecksum = 0,
                    ImporterVersion = 5,
                    CompressorVersion = 6,
                    Heading = new RealVector3d(1, 0, 0),
                    ParentAnimation = -1,
                    NextAnimation = -1,
                    ResourceGroupIndex = (short)(jmad.ResourceGroups.Count - 1),
                    ResourceGroupMemberIndex = 0,
                }
            };

            if (isWorldRelative)
                AnimationBlock.AnimationData.InternalFlags |= ModelAnimationGraph.Animation.InternalFlagsValue.WorldRelative;

            ModelAnimationTagResource newResource = new ModelAnimationTagResource
            {
                GroupMembers = new TagBlock<ModelAnimationTagResource.GroupMember>()
            };
            newResource.GroupMembers.Add(importer.SerializeAnimationData(CacheContext));
            newResource.GroupMembers.AddressType = CacheAddressType.Definition;

            TagResourceReference resourceref = CacheContext.ResourceCache.CreateModelAnimationGraphResource(newResource);

            jmad.ResourceGroups.Add(new ModelAnimationGraph.ResourceGroup
            {
                ResourceReference = resourceref,
                MemberCount = 1
            });

            AnimationBlock.AnimationData.ResourceGroupIndex = (short)(jmad.ResourceGroups.Count - 1);
            AnimationBlock.AnimationData.ResourceGroupMemberIndex = 0;

            if (replacing)
            {
                jmad.Animations[existingIndex] = AnimationBlock;
            }
            else
            {
                jmad.Animations.Add(AnimationBlock);
                existingIndex = jmad.Animations.Count - 1;
            }

            AddModeEntries(file_name, existingIndex, jmad, AnimationType);

            CacheContext.SaveStrings();
            CacheContext.Serialize(CacheStream, tag, jmad);
        }

        public void AddModeEntries(string filename, int animationIndex, ModelAnimationGraph jmad, ModelAnimationGraph.FrameType animationType)
        {
            List<string> tokens = filename.Split(':').ToList();
            List<string> unsupportedTokens =
                new List<string> { "s_kill", "s_ping", "h_kill", "h_ping", "sync_actions", "suspension", "tread", "object", "2", "device" };
            if (tokens.Any(t => unsupportedTokens.Contains(t)))
            {
                new TagToolWarning($"Unsupported string token found in filename {filename}. Manual mode addition is required.");
                return;
            }

            //variants are all handled by the same mode entry
            if (tokens.Last().StartsWith("var"))
                tokens.RemoveAt(tokens.Count - 1);

            //fixups for specific mode tokens
            List<string> edgeCases = new List<string> { "vehicle", "first_person", "weapon" };
            if (edgeCases.Contains(tokens[0]))
                tokens[0] = "any";

            string modeString = "";
            string classString = "";
            string typeString = "";
            string actionString = "";

            switch (tokens.Count)
            {
                case 1:
                    modeString = "any";
                    classString = "any";
                    typeString = "any";
                    actionString = tokens[0];
                    break;
                case 2:
                    modeString = tokens[0];
                    classString = "any";
                    typeString = "any";
                    actionString = tokens[1];
                    break;
                case 3:
                    modeString = tokens[0];
                    classString = tokens[1];
                    typeString = "any";
                    actionString = tokens[2];
                    break;
                case 4:
                    modeString = tokens[0];
                    classString = tokens[1];
                    typeString = tokens[2];
                    actionString = tokens[3];
                    break;
            }

            int modeIndex = AddMode(modeString, jmad);
            int classIndex = AddClass(modeIndex, classString, jmad);
            int typeIndex = AddType(modeIndex, classIndex, typeString, jmad);
            AddAction(modeIndex, classIndex, typeIndex, actionString, animationIndex, jmad, animationType);
        }

        public int AddMode(string modeString, ModelAnimationGraph jmad)
        {
            StringId modeStringID = CacheContext.StringTable.GetStringId(modeString);
            int modesIndex = jmad.Modes.FindIndex(m => m.Name == modeStringID);
            if (modesIndex != -1)
                return modesIndex;
            else
            {
                jmad.Modes.Add(new ModelAnimationGraph.Mode
                {
                    Name = modeStringID,
                    WeaponClass = new List<ModelAnimationGraph.Mode.WeaponClassBlock>()
                });
                return jmad.Modes.Count - 1;
            }
        }

        public int AddClass(int modeIndex, string classString, ModelAnimationGraph jmad)
        {
            StringId classStringID = CacheContext.StringTable.GetStringId(classString);
            int classIndex = jmad.Modes[modeIndex].WeaponClass.FindIndex(m => m.Label == classStringID);
            if (classIndex != -1)
                return classIndex;
            else
            {
                jmad.Modes[modeIndex].WeaponClass.Add(new ModelAnimationGraph.Mode.WeaponClassBlock
                {
                    Label = classStringID,
                    WeaponType = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock>()
                });
                return jmad.Modes[modeIndex].WeaponClass.Count - 1;
            }
        }

        public int AddType(int modeIndex, int classIndex, string typeString, ModelAnimationGraph jmad)
        {
            StringId typeStringID = CacheContext.StringTable.GetStringId(typeString);
            int typeIndex = jmad.Modes[modeIndex].WeaponClass[classIndex].WeaponType.
                FindIndex(m => m.Label == typeStringID);
            if (typeIndex != -1)
                return typeIndex;
            else
            {
                jmad.Modes[modeIndex].WeaponClass[classIndex].WeaponType.Add(new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock
                {
                    Label = typeStringID,
                    Set = new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet
                    {
                        Actions = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry>(),
                        Overlays = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry>()
                    }
                });
                return jmad.Modes[modeIndex].WeaponClass[classIndex].WeaponType.Count - 1;
            }
        }

        public void AddAction(int modeIndex, int classIndex, int typeIndex, string actionString, int animationIndex, ModelAnimationGraph jmad, ModelAnimationGraph.FrameType animationType)
        {
            StringId actionStringID = CacheContext.StringTable.GetStringId(actionString);
            var set = jmad.Modes[modeIndex].WeaponClass[classIndex].WeaponType[typeIndex].Set;
            var newAction = new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
            {
                Label = actionStringID,
                GraphIndex = -1,
                Animation = (short)animationIndex
            };
            if (animationType == ModelAnimationGraph.FrameType.Base) //for base actions
            {
                int actionIndex = set.Actions.FindIndex(m => m.Label == actionStringID);
                if (actionIndex != -1)
                    set.Actions[actionIndex] = newAction;
                else
                    set.Actions.Add(newAction);
            }
            else //handles overlays and replacements
            {
                int actionIndex = set.Overlays.FindIndex(m => m.Label == actionStringID);
                if (actionIndex != -1)
                    set.Overlays[actionIndex] = newAction;
                else
                    set.Overlays.Add(newAction);
            }
        }

        public void SortModes(CachedTag tag)
        {
            var jmad = CacheContext.Deserialize<ModelAnimationGraph>(CacheStream, tag);

            var resolver = CacheContext.StringTable.Resolver;

            jmad.Modes = jmad.Modes.OrderBy(a => resolver.GetSet(a.Name)).ThenBy(a => resolver.GetIndex(a.Name)).ToList();

            foreach (var mode in jmad.Modes)
            {
                mode.WeaponClass = mode.WeaponClass.OrderBy(a => resolver.GetSet(a.Label)).ThenBy(a => resolver.GetIndex(a.Label)).ToList();

                foreach (var weaponClass in mode.WeaponClass)
                {
                    weaponClass.WeaponType = weaponClass.WeaponType.OrderBy(a => resolver.GetSet(a.Label)).ThenBy(a => resolver.GetIndex(a.Label)).ToList();

                    foreach (var weaponType in weaponClass.WeaponType)
                    {
                        weaponType.Set.Actions = weaponType.Set.Actions.OrderBy(a => resolver.GetSet(a.Label)).ThenBy(a => resolver.GetIndex(a.Label)).ToList();
                        weaponType.Set.Overlays = weaponType.Set.Overlays.OrderBy(a => resolver.GetSet(a.Label)).ThenBy(a => resolver.GetIndex(a.Label)).ToList();
                        weaponType.Set.DeathAndDamage = weaponType.Set.DeathAndDamage.OrderBy(a => resolver.GetSet(a.Label)).ThenBy(a => resolver.GetIndex(a.Label)).ToList();
                        weaponType.Set.Transitions = weaponType.Set.Transitions.OrderBy(a => resolver.GetSet(a.FullName)).ThenBy(a => resolver.GetIndex(a.FullName)).ToList();

                        foreach (var transition in weaponType.Set.Transitions)
                        {
                            transition.Destinations = transition.Destinations.OrderBy(a => resolver.GetSet(a.FullName)).ThenBy(a => resolver.GetIndex(a.FullName)).ToList();
                        }
                    }
                }
            }

            CacheContext.Serialize(CacheStream, tag, jmad);
        }

        public void CompileScript(CachedTag tag, string scriptFile)
        {
            var scriptData = new FileInfo(scriptFile);

            var scnr = CacheContext.Deserialize<Scenario>(CacheStream, tag);

            ScriptCompiler scriptCompiler = new ScriptCompiler(Cache, scnr);

            scriptCompiler.CompileFile(scriptData);

            CacheContext.Serialize(CacheStream, tag, scnr);
        }
    }
}
