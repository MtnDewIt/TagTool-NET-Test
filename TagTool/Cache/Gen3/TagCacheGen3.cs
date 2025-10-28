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

namespace TagTool.Cache.Gen3
{
    public class TagCacheGen3 : TagCache
    {
        public CacheFileTagsHeader Header;

        public List<TagGroupGen3> Groups;

        public List<CachedTagGen3> Instances;

        /// <summary>
        /// Globals tag instances in the cache file.
        /// </summary>
        public Dictionary<Tag, CachedTagGen3> GlobalInstances;

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
            return new CachedTagGen3(index, (TagGroupGen3)group, name);
        }

        public override CachedTag CreateCachedTag()
        {
            return new CachedTagGen3(-1, new TagGroupGen3(), null);
        }

        public TagCacheGen3(EndianReader reader, MapFile baseMapFile, StringTableGen3 stringTable, CachePlatform platform)
        {
            Version = baseMapFile.Version;
            CachePlatform = baseMapFile.Platform;

            TagDefinitions = new TagDefinitionsGen3();
            Groups = new List<TagGroupGen3>();
            Instances = new List<CachedTagGen3>();
            GlobalInstances = new Dictionary<Tag, CachedTagGen3>();

            var indexOffset = baseMapFile.Header.GetDebugTagNameIndexOffset();
            var dataOffset = baseMapFile.Header.GetDebugTagNameDataOffset();
            var dataSize = baseMapFile.Header.GetDebugTagNameDataSize();
            var tagsOffset = baseMapFile.Header.GetTagsOffset();

            var sectionTable = baseMapFile.Header.GetSectionTable();
            var expectedBaseAddress = baseMapFile.Header.GetExpectedBaseAddress();

            if (CachePlatform == CachePlatform.Original)
            {
                TagsKey = Version switch
                {
                    CacheVersion.HaloReachAlpha or
                    CacheVersion.HaloReachPreBeta or
                    CacheVersion.HaloReachBeta => "rs&m*l#/t%_()e;[",
                    CacheVersion.HaloReach => "LetsAllPlayNice!",
                    _ => "",
                };
            }
            else
                TagsKey = "";

            uint sectionOffset;

            uint debugTagNameIndexOffset;
            uint debugTagNameDataOffset;
            ulong tagDataSectionOffset;

            if (Version > CacheVersion.Halo3Epsilon)
            {
                sectionOffset = sectionTable.GetSectionOffset(CacheFileSectionType.TagSection);

                // means no tags
                if (sectionTable.OriginalSectionBounds[(int)CacheFileSectionType.TagSection].Size == 0)
                    return;

                debugTagNameIndexOffset = sectionTable.GetOffset(CacheFileSectionType.StringSection, indexOffset);
                debugTagNameDataOffset = sectionTable.GetOffset(CacheFileSectionType.StringSection, dataOffset);

                tagDataSectionOffset = expectedBaseAddress - sectionOffset;
            }
            else
            {
                debugTagNameIndexOffset = indexOffset;
                debugTagNameDataOffset = dataOffset;
                tagDataSectionOffset = expectedBaseAddress - tagsOffset;
            }

            var tagTableHeaderOffset = baseMapFile.Header.GetTagsHeaderWhenLoaded() - tagDataSectionOffset;

            reader.SeekTo((long)tagTableHeaderOffset);

            var dataContext = new DataSerializationContext(reader);
            var deserializer = new TagDeserializer(Version, CachePlatform);

            Header = deserializer.Deserialize<CacheFileTagsHeader>(dataContext);

            var tagGroupsOffset = Header.TagGroups.Address.Value - tagDataSectionOffset;
            var tagInstancesOffset = Header.TagInstances.Address.Value - tagDataSectionOffset;
            var globalIndicesOffset = Header.GlobalTagIndices.Address.Value - tagDataSectionOffset;


            #region Read Tag Groups

            reader.SeekTo((long)tagGroupsOffset);

            for (int i = 0; i < Header.TagGroups.Count; i++)
            {
                var group = new TagGroupGen3()
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
                var tagGroup = groupIndex == -1 ? new TagGroupGen3() : Groups[groupIndex];
                uint ID = (uint)((reader.ReadInt16() << 16) | i);

                uint offset;

                if (platform == CachePlatform.MCC)
                {
                    ulong tagAddress = reader.ReadUInt32();

                    ulong bucketOffset = 0;
                    if(Version >= CacheVersion.HaloReach)
                        bucketOffset = tagAddress >> 28 << 28;

                    offset = (uint)(((tagAddress << 2) - tagDataSectionOffset) + bucketOffset);
                }
                else
                {
                    offset = (uint)(reader.ReadUInt32() - tagDataSectionOffset);
                }

                CachedTagGen3 tag = new CachedTagGen3(groupIndex, ID, offset, i, tagGroup);
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

            StringBuffer tagNames = (TagsKey == "" || TagsKey == null)
                ? new StringBuffer(reader.ReadBytes(dataSize))
                : new StringBuffer(reader.DecryptAesSegment(dataSize, TagsKey));

            for (int i = 0; i < stringOffsets.Length; i++)
            {
                if (stringOffsets[i] == -1)
                {
                    Instances[i].Name = null;
                    continue;
                }

                Instances[i].Name = tagNames.GetString(stringOffsets[i]).Replace(' ', '_');
            }
   
            #endregion

            #region Read Global Tags

            reader.SeekTo((long)globalIndicesOffset);

            for (int i = 0; i < Header.GlobalTagIndices.Count; i++)
            {
                var tag = reader.ReadTag();
                var ID = reader.ReadUInt32();
                GlobalInstances[tag] = (CachedTagGen3)GetTag(ID);
            }

            #endregion

        }
    }

}
