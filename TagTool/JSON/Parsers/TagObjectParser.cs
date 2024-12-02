using System;
using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
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
using TagTool.Tags.Resources;
using TagTool.Commands;
using TagTool.JSON.Handlers;
using TagTool.JSON.Objects;
using System.Text;

namespace TagTool.JSON.Parsers
{
    public class TagObjectParser
    {
        private GameCache Cache;
        private GameCacheHaloOnlineBase CacheContext;
        private Stream CacheStream;
        private TagObjectHandler Handler;
        private string InputPath;

        public TagObjectParser(GameCache cache, GameCacheHaloOnlineBase cacheContext, Stream cacheStream, string inputPath)
        {
            Cache = cache;
            CacheContext = cacheContext;
            CacheStream = cacheStream;
            Handler = new TagObjectHandler(Cache, CacheContext, CacheStream);
            InputPath = inputPath;
        }

        public void ParseFile(string filePath)
        {
            var jsonData = File.ReadAllText($@"{InputPath}\tags\{filePath}.json");
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
                case MultilingualUnicodeStringList:
                    ParseUnicodeStringData(tagObject, tag);
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

            if (tagObject.Bitmaps != null) 
            {
                if (tagObject.Bitmaps.Textures != null)
                {
                    tagData.HardwareTextures = new List<TagResourceReference>();

                    for (int i = 0; i < tagObject.Bitmaps.Textures.Count; i++)
                    {
                        var texture = tagObject.Bitmaps.Textures[i];

                        var reference = Cache.ResourceCache.CreateBitmapResource(texture);

                        tagData.HardwareTextures[i] = reference;
                    }
                }

                if (tagObject.Bitmaps.InterleavedTextures != null)
                {
                    tagData.InterleavedHardwareTextures = new List<TagResourceReference>();

                    for (int i = 0; i < tagObject.Bitmaps.Textures.Count; i++)
                    {
                        var interleavedTexture = tagObject.Bitmaps.InterleavedTextures[i];

                        var reference = Cache.ResourceCache.CreateBitmapInterleavedResource(interleavedTexture);

                        tagData.InterleavedHardwareTextures[i] = reference;
                    }
                }
            }

            Cache.Serialize(CacheStream, tagInstance, tagData);
        }

        public void ParseAnimationData(TagObject tagObject, CachedTag tagInstance)
        {
            var tagDefinition = Cache.Deserialize<ModelAnimationGraph>(CacheStream, tagInstance);
            var tagData = tagObject.TagData as ModelAnimationGraph;

            if (tagObject.Animations != null)
            {
                for (int i = 0; i < tagObject.Animations.Animations.Count; i++)
                {
                    var animation = tagObject.Animations.Animations[i];

                    var reference = Cache.ResourceCache.CreateModelAnimationGraphResource(animation);

                    tagData.ResourceGroups[i].ResourceReference = reference;
                }
            }

            Cache.Serialize(CacheStream, tagInstance, tagData);
        }

        public void ParseParticleModelData(TagObject tagObject, CachedTag tagInstance)
        {
            var tagDefinition = Cache.Deserialize<ParticleModel>(CacheStream, tagInstance);
            var tagData = tagObject.TagData as ParticleModel;

            if (tagObject.RenderGeometry != null)
            {
                var geometry = tagObject.RenderGeometry.Geometry;

                var reference = Cache.ResourceCache.CreateRenderGeometryApiResource(geometry);

                tagData.Geometry.Resource = reference;
            }

            Cache.Serialize(CacheStream, tagInstance, tagData);
        }

        public void ParseRenderModelData(TagObject tagObject, CachedTag tagInstance)
        {
            var tagDefinition = Cache.Deserialize<RenderModel>(CacheStream, tagInstance);
            var tagData = tagObject.TagData as RenderModel;

            if (tagObject.RenderGeometry != null)
            {
                var geometry = tagObject.RenderGeometry.Geometry;

                var reference = Cache.ResourceCache.CreateRenderGeometryApiResource(geometry);

                tagData.Geometry.Resource = reference;
            }

            Cache.Serialize(CacheStream, tagInstance, tagData);
        }

        public void ParseScenarioData(TagObject tagObject, CachedTag tagInstance)
        {
            var tagDefinition = Cache.Deserialize<Scenario>(CacheStream, tagInstance);
            var tagData = tagObject.TagData as Scenario;

            Cache.Serialize(CacheStream, tagInstance, tagData);

            if (tagObject.BlamScriptResource != null)
            {
                CompileScript(tagInstance, $@"{InputPath}\data\{tagObject.TagName}\scripts\{tagObject.BlamScriptResource.BlamScriptFile}");
            }
        }

        public void ParseScenarioLightmapBspData(TagObject tagObject, CachedTag tagInstance)
        {
            var tagDefinition = Cache.Deserialize<ScenarioLightmapBspData>(CacheStream, tagInstance);
            var tagData = tagObject.TagData as ScenarioLightmapBspData;

            if (tagObject.RenderGeometry != null)
            {
                var geometry = tagObject.RenderGeometry.Geometry;

                var reference = Cache.ResourceCache.CreateRenderGeometryApiResource(geometry);

                tagData.Geometry.Resource = reference;
            }

            Cache.Serialize(CacheStream, tagInstance, tagData);
        }

        public void ParseScenarioStructureBspData(TagObject tagObject, CachedTag tagInstance)
        {
            var tagDefinition = Cache.Deserialize<ScenarioStructureBsp>(CacheStream, tagInstance);
            var tagData = tagObject.TagData as ScenarioStructureBsp;

            if (tagObject.StructureBsp != null)
            {
                if (tagObject.StructureBsp.DecoratorGeometry != null)
                {
                    var decoratorGeometry = tagObject.StructureBsp.DecoratorGeometry;

                    var reference = Cache.ResourceCache.CreateRenderGeometryApiResource(decoratorGeometry);

                    tagData.DecoratorGeometry.Resource = reference;
                }

                if (tagObject.StructureBsp.Geometry != null)
                {
                    var geometry = tagObject.StructureBsp.Geometry;

                    var reference = Cache.ResourceCache.CreateRenderGeometryApiResource(geometry);

                    tagData.Geometry.Resource = reference;
                }

                if (tagObject.StructureBsp.Collision != null)
                {
                    var collision = tagObject.StructureBsp.Collision;

                    var reference = Cache.ResourceCache.CreateStructureBspResource(collision);

                    tagData.CollisionBspResource = reference;
                }

                if (tagObject.StructureBsp.Pathfinding != null)
                {
                    var pathfinding = tagObject.StructureBsp.Pathfinding;

                    var reference = Cache.ResourceCache.CreateStructureBspCacheFileResource(pathfinding);

                    tagData.PathfindingResource = reference;
                }
            }

            Cache.Serialize(CacheStream, tagInstance, tagData);
        }

        public void ParseSoundData(TagObject tagObject, CachedTag tagInstance)
        {
            var tagDefinition = Cache.Deserialize<Sound>(CacheStream, tagInstance);
            var tagData = tagObject.TagData as Sound;

            if (tagObject.Sounds != null)
            {
                var sound = tagObject.Sounds.Sound;

                var reference = Cache.ResourceCache.CreateSoundResource(sound);

                tagData.Resource = reference;
            }

            Cache.Serialize(CacheStream, tagInstance, tagData);
        }

        public void ParseUnicodeStringData(TagObject tagObject, CachedTag tagInstance)
        {
            var tagDefinition = new MultilingualUnicodeStringList 
            {
                Strings = new List<LocalizedString>(),
                Data = [],
                OffsetCounts = new ushort[24],
            };

            if (tagObject.UnicodeStrings != null)
            {
                for (int i = 0; i < tagObject.UnicodeStrings.Languages[(int)GameLanguage.English].UnicodeStrings.Count; i++)
                {
                    foreach (GameLanguage language in Enum.GetValues(typeof(GameLanguage))) 
                    {
                        var unicodeString = tagObject.UnicodeStrings.Languages[(int)language].UnicodeStrings[i];

                        AddString(tagDefinition, language, unicodeString.StringIdName, unicodeString.StringIdContent);
                    }
                }
            }

            Cache.Serialize(CacheStream, tagInstance, tagDefinition);
        }

        public void AddString(MultilingualUnicodeStringList unic, GameLanguage language, string stringIdName, string stringIdContent)
        {
            var stringIdIndex = Cache.StringTable.IndexOf(stringIdName);

            if (stringIdIndex < 0)
            {
                Cache.StringTable.AddString(stringIdName);
                Cache.SaveStrings();

                stringIdIndex = Cache.StringTable.IndexOf(stringIdName);
            }

            var stringId = Cache.StringTable.GetStringId(stringIdIndex);

            var parsedContent = stringIdContent != null ? new Regex(@"\\[uU]([0-9A-F]{4})").Replace(stringIdContent, match => ((char)int.Parse(match.Value.Substring(2), NumberStyles.HexNumber)).ToString()) : null;

            var localizedStr = unic.Strings.FirstOrDefault(s => s.StringID == stringId);

            if (localizedStr == null)
            {
                localizedStr = new LocalizedString
                {
                    StringID = stringId,
                };

                unic.Strings.Add(localizedStr);
            }

            parsedContent = parsedContent != null ? DecodeNonAsciiCharacters(parsedContent) : null;

            SetLocalizedString(unic, localizedStr, language, parsedContent);
        }

        public static string DecodeNonAsciiCharacters(string value)
        {
            var specialchars = new Dictionary<string, char>
            {
                {"\\r", '\r' },
                {"\\n", '\n' },
                {"\\t", '\t' }
            };

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '\\')
                {
                    if (i + 1 < value.Length && value[i + 1] == 'u' && i + 5 < value.Length)
                    {
                        string unicodeHex = value.Substring(i + 2, 4);
                        if (int.TryParse(unicodeHex, NumberStyles.HexNumber, null, out int unicodeValue))
                        {
                            sb.Append((char)unicodeValue);
                            i += 5;
                            continue;
                        }
                    }

                    foreach (var pair in specialchars)
                    {
                        if (value.Substring(i).StartsWith(pair.Key))
                        {
                            sb.Append(pair.Value);
                            i += pair.Key.Length - 1;
                            break;
                        }
                    }
                }
                else
                {
                    sb.Append(value[i]);
                }
            }
            return sb.ToString();
        }

        public static void SetLocalizedString(MultilingualUnicodeStringList unic, LocalizedString str, GameLanguage language, string newValue) 
        {
            var offset = str.Offsets[(int)language];

            if (offset < 0 || offset >= unic.Data.Length)
                offset = unic.Data.Length;

            var endOffset = offset;

            while (endOffset < unic.Data.Length && unic.Data[endOffset] != 0)
                endOffset++;

            var oldLength = endOffset - offset;

            var bytes = (newValue != null) ? Encoding.UTF8.GetBytes(newValue) : new byte[0];

            if (bytes.Length > 0 || newValue == string.Empty && offset == unic.Data.Length)
            {
                var nullTerminated = new byte[bytes.Length + 1];
                Buffer.BlockCopy(bytes, 0, nullTerminated, 0, bytes.Length);
                bytes = nullTerminated;
            }

            unic.Data = ArrayUtil.Replace(unic.Data, offset, oldLength, bytes);

            str.Offsets[(int)language] = (bytes.Length > 0) ? offset : -1;

            var sizeDelta = bytes.Length - oldLength;

            foreach (var adjustStr in unic.Strings)
            {
                for (var i = 0; i < adjustStr.Offsets.Length; i++)
                {
                    if (adjustStr.Offsets[i] > offset)
                        adjustStr.Offsets[i] += sizeDelta;
                }
            }
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

            var importer = new AnimationImporter(CacheStream);

            if (!importer.Import(filepath.FullName))
            {
                new TagToolError(CommandError.FileIO);
            }

            if (importer.Version >= 16394)
            {
                new TagToolError(CommandError.CustomError, $@"Invalid Animation Format");
            }

            List<AnimationImporter.AnimationNode> newAnimationNodes = new List<AnimationImporter.AnimationNode>();
            foreach (var skellynode in jmad.SkeletonNodes)
            {
                string nodeName = Cache.StringTable.GetString(skellynode.Name);
                int matching_index = importer.AnimationNodes.FindIndex(x => x.Name.Equals(nodeName));
                if (matching_index == -1)
                {
                    new TagToolWarning($"No node matching '{nodeName}' found in imported file! Will proceed with blank data for missing node");
                    newAnimationNodes.Add(new AnimationImporter.AnimationNode()
                    {
                        Name = nodeName,
                        FirstChildNode = skellynode.FirstChildNodeIndex,
                        NextSiblingNode = skellynode.NextSiblingNodeIndex,
                        ParentNode = skellynode.ParentNodeIndex
                    });
                }
                else
                {
                    AnimationImporter.AnimationNode matching_node = importer.AnimationNodes[matching_index];
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
