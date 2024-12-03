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

                        tagData.HardwareTextures.Add(reference);
                    }
                }

                if (tagObject.Bitmaps.InterleavedTextures != null)
                {
                    tagData.InterleavedHardwareTextures = new List<TagResourceReference>();

                    for (int i = 0; i < tagObject.Bitmaps.Textures.Count; i++)
                    {
                        var interleavedTexture = tagObject.Bitmaps.InterleavedTextures[i];

                        var reference = Cache.ResourceCache.CreateBitmapInterleavedResource(interleavedTexture);

                        tagData.InterleavedHardwareTextures.Add(reference);
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
