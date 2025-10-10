using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TagTool.BlamFile;
using TagTool.Cache.CacheFile;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.Cache.Gen4
{
    public class TagCacheGen4 : TagCache
    {
        public CacheFileTagsHeader Header;

        public List<TagGroupGen4> Groups;

        public List<CachedTagGen4> Instances;

        /// <summary>
        /// Globals tag instances in the cache file.
        /// </summary>
        public Dictionary<Tag, CachedTagGen4> GlobalInstances;

        public string TagsKey = "";

        public override IEnumerable<CachedTag> TagTable { get => Instances; }

        public override CachedTag GetTag(uint ID) => GetTag((int)(ID & 0xFFFF));

        public override CachedTag GetTag(int index)
        {
            if (index > 0 && index < Instances.Count)
                return Instances[index];
            else
                return null;
        }

        public override CachedTag GetTag(string name, Tag groupTag)
        {
            foreach (var tag in Instances)
            {
                if (tag != null && groupTag == tag.Group.Tag && name == tag.Name)
                    return tag;
            }
            return null;
        }

        public override CachedTag AllocateTag(TagGroup type, string name = null)
        {
            throw new NotImplementedException();
        }

        public override CachedTag CreateCachedTag(int index, TagGroup group, string name = null)
        {
            return new CachedTagGen4(index, (TagGroupGen4)group, name);
        }

        public override CachedTag CreateCachedTag()
        {
            return new CachedTagGen4(-1, new TagGroupGen4(), null);
        }

        public TagCacheGen4(EndianReader reader, MapFile baseMapFile, StringTableGen4 stringTable, ulong expand = 0)
        {
            CachePlatform = baseMapFile.Platform;
            Version = baseMapFile.Version;
            TagDefinitions = new TagDefinitionsGen4();
            Groups = new List<TagGroupGen4>();
            Instances = new List<CachedTagGen4>();
            GlobalInstances = new Dictionary<Tag, CachedTagGen4>();
            TagsKey = baseMapFile.Platform == CachePlatform.Original ? "LetsAllPlayNice!" : "";

            var indexOffset = baseMapFile.Header.GetDebugTagNameIndexOffset();
            var dataOffset = baseMapFile.Header.GetDebugTagNameDataOffset();
            var dataSize = baseMapFile.Header.GetDebugTagNameDataSize();
            var tagsOffset = baseMapFile.Header.GetTagsOffset();

            var sectionTable = baseMapFile.Header.GetSectionTable();
            var expectedBaseAddress = baseMapFile.Header.GetExpectedBaseAddress();

            uint sectionOffset;

            uint debugTagNameIndexOffset;
            uint debugTagNameDataOffset;
            ulong addressMask;

            if (Version > CacheVersion.Halo3Beta)
            {
                sectionOffset = sectionTable.GetSectionOffset(CacheFileSectionType.TagSection);

                // means no tags
                if (sectionTable.OriginalSectionBounds[(int)CacheFileSectionType.TagSection].Size == 0)
                    return;

                debugTagNameIndexOffset = sectionTable.GetOffset(CacheFileSectionType.StringSection, indexOffset);
                debugTagNameDataOffset = sectionTable.GetOffset(CacheFileSectionType.StringSection, dataOffset);

                addressMask = expectedBaseAddress - sectionOffset;
            }
            else
            {
                debugTagNameIndexOffset = indexOffset;
                debugTagNameDataOffset = dataOffset;
                addressMask = expectedBaseAddress - tagsOffset;
            }

            var tagTableHeaderOffset = baseMapFile.Header.GetTagsHeaderWhenLoaded() - addressMask;

            reader.SeekTo((long)tagTableHeaderOffset);

            var dataContext = new DataSerializationContext(reader);
            var deserializer = new TagDeserializer(baseMapFile.Version, CachePlatform);

            Header = deserializer.Deserialize<CacheFileTagsHeader>(dataContext);

            var tagGroupsOffset = Header.TagGroups.Address.Value - addressMask;
            var tagInstancesOffset = Header.TagInstances.Address.Value - addressMask;
            var globalIndicesOffset = Header.GlobalTagIndices.Address.Value - addressMask;

            #region Read Tag Groups

            reader.SeekTo((long)tagGroupsOffset);

            for (int i = 0; i < Header.TagGroups.Count; i++)
            {
                var group = new TagGroupGen4()
                {
                    Tag = reader.ReadTag(),
                    ParentTag = reader.ReadTag(),
                    GrandParentTag = reader.ReadTag(),
                    Name = stringTable.GetString(new StringId(reader.ReadUInt32()))
                };

                Groups.Add(group);
                if(!TagDefinitions.TagDefinitionExists(group))
                    Debug.WriteLine($"Warning: tag definition for {group.Tag} : {group.Name} does not exists!");
            }

            #endregion

            #region Read Tags Info

            reader.SeekTo((long)tagInstancesOffset);

            for (int i = 0; i < Header.TagInstances.Count; i++)
            {
                var groupIndex = reader.ReadInt16();
                var tagGroup = groupIndex == -1 ? new TagGroupGen4() : Groups[groupIndex];
                uint ID = (uint)((reader.ReadInt16() << 16) | i);

                var offset = CachePlatform == CachePlatform.MCC ?
                    (uint)((ulong)sectionTable.SectionOffsets[2] + (ulong)sectionTable.OriginalSectionBounds[2].Offset + (((ulong)reader.ReadUInt32() * 4) - (expectedBaseAddress - expand))) :
                    (uint)(reader.ReadUInt32() - addressMask);

                CachedTagGen4 tag = new CachedTagGen4(groupIndex, ID, offset, i, tagGroup);
                Instances.Add(tag);
            }

            #endregion

            #region Read Indices

            reader.SeekTo(debugTagNameIndexOffset);

            var stringOffsets = new int[Header.TagInstances.Count];

            for (int i = 0; i < Header.TagInstances.Count; i++)
                stringOffsets[i] = reader.ReadInt32();

            #endregion

            #region Read Names

            reader.SeekTo(debugTagNameDataOffset);

            using (var newReader = (TagsKey == "" || TagsKey == null) ?
                new EndianReader(new MemoryStream(reader.ReadBytes(dataSize)), EndianFormat.BigEndian) :
                new EndianReader(reader.DecryptAesSegment(dataSize, TagsKey), EndianFormat.BigEndian))
            {
                for (int i = 0; i < stringOffsets.Length; i++)
                {
                    if (stringOffsets[i] == -1)
                    {
                        Instances[i].Name = null;
                        continue;
                    }

                    newReader.SeekTo(stringOffsets[i]);
                    Instances[i].Name = newReader.ReadNullTerminatedString();
                }
            }

            #endregion

            #region Read Global Tags

            reader.SeekTo((long)globalIndicesOffset);

            for (int i = 0; i < Header.GlobalTagIndices.Count; i++)
            {
                var tag = reader.ReadTag();
                var ID = reader.ReadUInt32();
                GlobalInstances[tag] = (CachedTagGen4)GetTag(ID);
            }

            #endregion

        }
    }

}
