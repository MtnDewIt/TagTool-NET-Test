﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TagTool.Cache.Gen3;
using TagTool.Common;
using TagTool.Extensions;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.Cache.HaloOnline
{

    [TagStructure(Size = 0x20)]
    public class TagCacheHaloOnlineHeader
    {
        public int UnusedTag;
        public uint TagTableOffset;
        public int TagCount;
        public int Unused;
        public long CreationTime;
        public int Unused2;
        public int Unused3;
    }

    public class TagCacheHaloOnline : TagCache
    {
        public List<CachedTagHaloOnline> Tags = new List<CachedTagHaloOnline>();
        public TagCacheHaloOnlineHeader Header;

        public override IEnumerable<CachedTag> TagTable { get => Tags; }
        public readonly StringTableHaloOnline StringTableReference;
        
        public TagCacheHaloOnline(CacheVersion version, Stream stream, StringTableHaloOnline stringTable, Dictionary<int, string> names = null)
        {
            Version = version;
            CachePlatform = CachePlatform.Original;
            TagDefinitions = new TagDefinitionsGen3();
            StringTableReference = stringTable;
            if (stream.Length != 0)
                Load(new EndianReader(stream), names ?? new Dictionary<int, string>());
            else
                CreateTagCache(stream);

            if (CacheVersion.Unknown == (Version = CacheVersionDetection.DetectFromTimestamp(Header.CreationTime, out var closestVersion)))
                Version = closestVersion;

            CachePlatform = CachePlatform.Original;
        }

        private void CreateTagCache(Stream stream)
        {
            TagCacheHaloOnlineHeader header = new TagCacheHaloOnlineHeader
            {
                TagTableOffset = TagStructure.GetStructureSize(typeof(TagCacheHaloOnlineHeader), Version, CachePlatform),
                CreationTime = CacheVersionDetection.GetTimestamp(Version)
            };
            stream.Position = 0;
            var writer = new EndianWriter(stream, EndianFormat.LittleEndian);
            var dataContext = new DataSerializationContext(writer);
            var serializer = new TagSerializer(Version, CachePlatform);
            serializer.Serialize(dataContext, header);
            Header = header;
            stream.Position = 0;
        }

        private void Load(EndianReader reader, Dictionary<int, string> names)
        {
            // Read file header
            reader.SeekTo(0);
            var dataContext = new DataSerializationContext(reader);
            var deserializer = new TagDeserializer(Version, CachePlatform);

            Header = deserializer.Deserialize<TagCacheHaloOnlineHeader>(dataContext);

            // Read tag offset list
            var headerOffsets = new uint[Header.TagCount];
            reader.BaseStream.Position = Header.TagTableOffset;
            for (var i = 0; i < Header.TagCount; i++)
                headerOffsets[i] = reader.ReadUInt32();

            // Read each tag
            for (var i = 0; i < Header.TagCount; i++)
            {
                if (headerOffsets[i] == 0)
                {
                    // Offset of 0 = null tag
                    Tags.Add(null);
                    continue;
                }

                string name = null;

                if (names.ContainsKey(i))
                    name = names[i];

                var tag = new CachedTagHaloOnline(i, name) { HeaderOffset = headerOffsets[i] };
                Tags.Add(tag);

                reader.BaseStream.Position = tag.HeaderOffset;
                tag.ReadHeader(reader, StringTableReference);
            }
        }

        /// <summary>
        /// Allocates a new tag at the end of the tag list without updating the file.
        /// You can give the tag data by using one of the overwrite functions.
        /// </summary>
        /// <param name="type">The tag's type information.</param>
        /// <param name="name">The name of the tag instance.</param>
        /// <returns>The allocated tag.</returns>
        public override CachedTag AllocateTag(TagGroup type, string name = null)
        {
            var tagIndex = Tags.Count;
            var tag = new CachedTagHaloOnline(tagIndex, (TagGroupGen3)type, name);
            Tags.Add(tag);
            return tag;
        }

        /// <summary>
        /// Returns a new CachedTag instance without updating the tag cache.
        /// </summary>
        public override CachedTag CreateCachedTag(int index, TagGroup group, string name = null)
        {
            return new CachedTagHaloOnline(index, (TagGroupGen3)group, name);
        }

        public override CachedTag CreateCachedTag()
        {
            return new CachedTagHaloOnline(-1, new TagGroupGen3(), null);
        }

        /// <summary>
        /// Reads a tag's raw data from the file, including its header.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="tag">The tag to read.</param>
        /// <returns>The data that was read.</returns>
        public byte[] ExtractTagRaw(Stream stream, CachedTagHaloOnline tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));
            else if (tag.HeaderOffset < 0)
                throw new ArgumentException("The tag is not in the cache file");

            var result = new byte[tag.TotalSize];

            stream.Position = tag.HeaderOffset;
            stream.ReadAll(result, 0, result.Length);

            return result;
        }

        /// <summary>
        /// Reads a tag's data from the file.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="tag">The tag to read.</param>
        /// <returns>The data that was read.</returns>
        public CachedTagData ExtractTag(Stream stream, CachedTagHaloOnline tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));
            else if (tag.HeaderOffset < 0)
                throw new ArgumentException("The tag is not in the cache file");

            // Build the description info and get the data offset
            var data = BuildTagData(stream, tag, out uint dataOffset);

            // Read the tag data
            stream.Position = tag.HeaderOffset + dataOffset;
            data.Data = new byte[tag.TotalSize - dataOffset];
            stream.ReadAll(data.Data, 0, data.Data.Length);

            // Correct pointers
            using (var dataWriter = new BinaryWriter(new MemoryStream(data.Data)))
            {
                foreach (var fixup in data.PointerFixups)
                {
                    dataWriter.BaseStream.Position = fixup.WriteOffset;
                    dataWriter.Write(tag.OffsetToPointer(fixup.TargetOffset));
                }
            }
            return data;
        }

        /// <summary>
        /// Overwrites a tag's raw data, including its header.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="tag">The tag to overwrite.</param>
        /// <param name="data">The data to overwrite the tag with.</param>
        /// <exception cref="System.ArgumentNullException">tag</exception>
        public void SetTagDataRaw(Stream stream, CachedTagHaloOnline tag, byte[] data)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));

            // Ensure the data fits
            if (tag.HeaderOffset < 0)
                tag.HeaderOffset = GetNewTagOffset(tag.Index);
            ResizeBlock(stream, tag, tag.HeaderOffset, tag.TotalSize, data.Length);
            tag.TotalSize = (uint)data.Length;

            if(data.Length > 0)
            {
                // Write the data
                stream.Position = tag.HeaderOffset;
                stream.Write(data, 0, data.Length);

                // Re-parse it
                stream.Position = tag.HeaderOffset;
                tag.ReadHeader(new BinaryReader(stream), StringTableReference);
                UpdateTagOffsets(new EndianWriter(stream, EndianFormat.LittleEndian));
            }
        }

        /// <summary>
        /// Overwrites a tag's data.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="tag">The tag to overwrite.</param>
        /// <param name="data">The data to store.</param>
        public void SetTagData(Stream stream, CachedTagHaloOnline tag, CachedTagData data)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));
            else if (data == null)
                throw new ArgumentNullException(nameof(data));
            else if ((data.Group as TagGroupGen3).IsNull())
                throw new ArgumentException("Cannot assign a tag to a null tag group");
            else if (data.Data == null)
                throw new ArgumentException("The tag data buffer is null");

            // Ensure the data fits
            var headerSize = CachedTagHaloOnline.CalculateHeaderSize(data);
            var alignedHeaderSize = (uint)((headerSize + 0xF) & ~0xF);
            if (tag.HeaderOffset < 0)
                tag.HeaderOffset = GetNewTagOffset(tag.Index);
            var alignedLength = (data.Data.Length + 0xF) & ~0xF;
            ResizeBlock(stream, tag, tag.HeaderOffset, tag.TotalSize, alignedHeaderSize + alignedLength);
            tag.TotalSize = (uint)(alignedHeaderSize + alignedLength);
            tag.Update(data, alignedHeaderSize);

            // Write in the new header and data
            stream.Position = tag.HeaderOffset;
            var writer = new EndianWriter(stream, EndianFormat.LittleEndian);
            tag.WriteHeader(writer, StringTableReference);
            StreamUtil.Fill(stream, 0, (int)(alignedHeaderSize - headerSize));
            stream.Write(data.Data, 0, data.Data.Length);
            StreamUtil.Fill(stream, 0, alignedLength - data.Data.Length);

            // Correct pointers
            foreach (var fixup in data.PointerFixups)
            {
                writer.BaseStream.Position = tag.HeaderOffset + alignedHeaderSize + fixup.WriteOffset;
                writer.Write(tag.OffsetToPointer(alignedHeaderSize + fixup.TargetOffset));
            }

            UpdateTagOffsets(writer);
        }

        /// <summary>
        /// Builds a description for a tag's data without extracting anything.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="tag">The tag to read.</param>
        /// <param name="dataOffset">On return, this will contain the offset of the tag's data relative to its header.</param>
        /// <returns>The description that was built. </returns>
        private static CachedTagData BuildTagData(Stream stream, CachedTagHaloOnline tag, out uint dataOffset)
        {
            var data = new CachedTagData
            {
                Group = (TagGroupGen3)tag.Group,
                MainStructOffset = tag.DefinitionOffset,
            };

            foreach (var dependency in tag.Dependencies)
                data.Dependencies.Add(dependency);

            // Read pointer fixups
            var reader = new BinaryReader(stream);
            foreach (var pointerOffset in tag.PointerOffsets)
            {
                reader.BaseStream.Position = tag.HeaderOffset + pointerOffset;
                data.PointerFixups.Add(new CachedTagData.PointerFixup
                {
                    WriteOffset = pointerOffset,
                    TargetOffset = tag.PointerToOffset(reader.ReadUInt32()),
                });
            }

            // Find the start of the tag's data by finding the offset of the first block which is pointed to by something
            // We CAN'T just calculate a header size here because we don't know for sure if there's padding and how big it is
            var startOffset = tag.DefinitionOffset;
            foreach (var fixup in data.PointerFixups)
                startOffset = Math.Min(startOffset, Math.Min(fixup.WriteOffset, fixup.TargetOffset));

            // Now convert all offsets into relative ones
            foreach (var fixup in data.PointerFixups)
            {
                fixup.WriteOffset -= startOffset;
                fixup.TargetOffset -= startOffset;
            }

            data.ResourcePointerOffsets.AddRange(tag.ResourcePointerOffsets.Select(offset => offset - startOffset));

            data.TagReferenceOffsets.AddRange(tag.TagReferenceOffsets.Select(offset => offset - startOffset));

            data.MainStructOffset -= startOffset;
            dataOffset = startOffset;

            return data;
        }

        /// <summary>
        /// Resizes a block of data in the file.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="tag">The tag that the block belongs to, if any.</param>
        /// <param name="startOffset">The offset where the block to resize begins at.</param>
        /// <param name="oldSize">The current size of the block to resize.</param>
        /// <param name="newSize">The new size of the block.</param>
        /// <exception cref="System.ArgumentException">Cannot resize a block to a negative size</exception>
        private void ResizeBlock(Stream stream, CachedTagHaloOnline tag, long startOffset, long oldSize, long newSize)
        {
            if (newSize < 0)
                throw new ArgumentException("Cannot resize a block to a negative size");
            else if (oldSize == newSize)
                return;

            var oldEndOffset = startOffset + oldSize;
            var sizeDelta = newSize - oldSize;

            if (stream.Length - oldEndOffset >= 0)
            {
                StreamUtil.Copy(stream, oldEndOffset, oldEndOffset + sizeDelta, stream.Length - oldEndOffset);
                FixTagOffsets(oldEndOffset, sizeDelta, tag);
            }
            else
                return;
        }

        /// <summary>
        /// Fixes tag offsets after a resize operation.
        /// </summary>
        /// <param name="startOffset">The offset where the resize operation took place.</param>
        /// <param name="sizeDelta">The amount to add to each tag offset after the start offset.</param>
        /// <param name="ignore">A tag to ignore.</param>
        private void FixTagOffsets(long startOffset, long sizeDelta, CachedTagHaloOnline ignore)
        {
            foreach (var adjustTag in Tags.Where(t => t != null && t != ignore && t.HeaderOffset >= startOffset))
                adjustTag.HeaderOffset += sizeDelta;
        }

        /// <summary>
        /// Gets the offset that a new tag should be inserted at so that the tags are stored in order by index.
        /// </summary>
        /// <param name="index">The index of the new tag.</param>
        /// <returns>The offset that the tag data should be written to.</returns>
        private long GetNewTagOffset(int index)
        {
            if (index < 0)
                throw new ArgumentException("Index cannot be negative");

            if (index >= Tags.Count - 1)
                return GetTagDataEndOffset();

            for (var i = index - 1; i >= 0; i--)
            {
                var tag = Tags[i];
                if (tag != null && tag.HeaderOffset >= 0)
                    return tag.HeaderOffset + tag.TotalSize;
            }

            return new TagStructureInfo(typeof(TagCacheHaloOnlineHeader)).TotalSize;
        }

        /// <summary>
        /// Gets the tag data end offset.
        /// </summary>
        /// <returns>The offset of the first byte past the last tag in the file.</returns>
        private uint GetTagDataEndOffset()
        {
            uint endOffset = new TagStructureInfo(typeof(TagCacheHaloOnlineHeader)).TotalSize;
            foreach (var tag in Tags)
            {
                if (tag != null)
                    endOffset = (uint)Math.Max(endOffset, tag.HeaderOffset + tag.TotalSize);
            }
            return endOffset;
        }

        /// <summary>
        /// Updates the tag offset table in the file.
        /// </summary>
        /// <param name="writer">The stream to write to.</param>
        public void UpdateTagOffsets(EndianWriter writer)
        {
            uint offsetTableOffset = GetTagDataEndOffset();
            writer.BaseStream.Position = offsetTableOffset;
            foreach (var tag in Tags)
            {
                if (tag != null && tag.HeaderOffset >= 0)
                    writer.Write((uint)tag.HeaderOffset);
                else
                    writer.Write(0);
            }
            writer.BaseStream.SetLength(writer.BaseStream.Position); // Truncate the file to end after the last offset
            UpdateFileHeader(writer, offsetTableOffset);
        }

        /// <summary>
        /// Updates the file header.
        /// </summary>
        /// <param name="writer">The stream to write to.</param>
        /// <param name="offsetTableOffset">The offset table offset.</param>
        private void UpdateFileHeader(EndianWriter writer, uint offsetTableOffset)
        {
            Header.TagTableOffset = offsetTableOffset;
            Header.TagCount = Tags.Count;
            writer.BaseStream.Position = 0;
            var dataContext = new DataSerializationContext(writer);
            var serializer = new TagSerializer(Version, CachePlatform);
            serializer.Serialize(dataContext, Header);
        }

        public HashSet<CachedTagHaloOnline> FindDependencies(CachedTagHaloOnline tag)
        {
            var result = new HashSet<CachedTagHaloOnline>();
            FindDependencies(result, tag);
            return result;
        }

        private void FindDependencies(ISet<CachedTagHaloOnline> results, CachedTagHaloOnline tag)
        {
            foreach (var index in tag.Dependencies)
            {
                if (index < 0 || index >= Tags.Count)
                    continue;
                var dependency = Tags[index];
                if (results.Contains(dependency))
                    continue;
                results.Add(dependency);
                FindDependencies(results, dependency);
            }
        }

        /// <summary>
        /// Loads tag file names from the appropriate tag_list.csv file.
        /// </summary>
        /// <param name="path">The path to the tag_list.csv file.</param>
        public static Dictionary<int, string> LoadTagNames(string path = null)
        {
            var names = new Dictionary<int, string>();

            if (File.Exists(path))
            {
                using (var tagNamesStream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    var reader = new StreamReader(tagNamesStream);

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var separatorIndex = line.IndexOf(',');
                        var indexString = line.Substring(2, separatorIndex - 2);

                        if (!int.TryParse(indexString, NumberStyles.HexNumber, null, out int tagIndex))
                            tagIndex = -1;

                        //if (tagIndex < 0 || tagIndex >= TagCache.Index.Count || TagCache.Index[tagIndex] == null)
                        //continue;

                        var nameString = line.Substring(separatorIndex + 1);

                        if (nameString.Contains(" "))
                        {
                            var lastSpaceIndex = nameString.LastIndexOf(' ');
                            nameString = nameString.Substring(lastSpaceIndex + 1, nameString.Length - lastSpaceIndex - 1);
                        }

                        names[tagIndex] = nameString;
                    }

                    reader.Close();
                }
            }

            return names;
        }

        /// <summary>
        /// Saves tag file names to the appropriate tag_list.csv file.
        /// </summary>
        /// <param name="path">The path to the tag_list.csv file.</param>
        public void SaveTagNames(string path)
        {
            var csvFile = new FileInfo(path);

            if (!csvFile.Directory.Exists)
                csvFile.Directory.Create();

            using (var csvWriter = new StreamWriter(csvFile.Create()))
            {
                foreach (var instance in Tags)
                    if (instance != null && instance.Name != null && !instance.Name.ToLower().StartsWith("0x"))
                        csvWriter.WriteLine($"0x{instance.Index:X8},{instance.Name}");
            }
        }

        // there are no tag IDs in Halo Online
        public override CachedTag GetTag(uint ID) => GetTag((int)ID);

        public override CachedTag GetTag(int index)
        {
            if (index < 0 || index >= Tags.Count)
                return null;
            return Tags[index];
        }

        public override CachedTag GetTag(string name, Tag groupTag)
        {
            foreach (var tag in Tags)
            {
                if (tag != null && groupTag == tag.Group.Tag && name == tag.Name)
                    return tag;
            }
            return null;
        }
    }

}
