using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TagTool.Cache.Eldorado.Resolvers;
using TagTool.Common;
using TagTool.Common.Logging;
using TagTool.IO;

namespace TagTool.Cache.Eldorado
{
    public class StringTableEldorado : StringTable
    {
        private object _cacheLock = new object();

        public StringTableEldorado(CacheVersion version)
        {
            Resolver = null;

            if (CacheVersionDetection.Compare(version, CacheVersion.Eldorado700123) >= 0)
                Resolver = new StringIdResolverMS30();
            else if (CacheVersionDetection.Compare(version, CacheVersion.Eldorado498295) >= 0)
                Resolver = new StringIdResolverMS28();
            else
                Resolver = new StringIdResolverMS23();
        }

        public StringTableEldorado(CacheVersion version, Stream stream) : this(version)
        {
            if ( stream != null && stream.Length != 0)
                Load(stream);
            else
                CreateFromStrings();
        }

        public override StringId AddString(string newString)
        {
            var strIndex = Count;
            Add(newString);
            return GetStringId(strIndex);
        }

        /// <summary>
        /// AddString() but blocks other threads
        /// </summary>
        public StringId AddStringBlocking(string newString)
        {
            lock (_cacheLock) // block while adding to main id list
            {
                return AddString(newString);
            }
        }

        public void Save(Stream stream)
        {
            var writer = new EndianWriter(stream, EndianFormat.LittleEndian);

            // Write the string count and then skip over the offset table, because it will be filled in last
            writer.Write(Count);
            writer.BaseStream.Position += 4 + Count * 4; // 4 byte data size + 4 bytes per string offset

            // Write string data and keep track of offsets
            var stringOffsets = new int[Count];
            var dataOffset = (int)writer.BaseStream.Position;
            var currentOffset = 0;
            for (var i = 0; i < Count; i++)
            {
                var str = this[i];
                if (str == null)
                {
                    // Null string - set offset to -1
                    stringOffsets[i] = -1;
                    continue;
                }

                // Write the string as null-terminated ASCII
                stringOffsets[i] = currentOffset;
                var data = Encoding.ASCII.GetBytes(str);
                writer.Write(data, 0, data.Length);
                writer.Write((byte)0);
                currentOffset += data.Length + 1;
            }

            // Now go back and write the string offsets
            writer.BaseStream.Position = 0x4;
            writer.Write(currentOffset); // Data size
            foreach (var offset in stringOffsets)
                writer.Write(offset);
            writer.BaseStream.SetLength(dataOffset + currentOffset);
        }

        private void Load(Stream stream)
        {
            var reader = new EndianReader(stream, EndianFormat.LittleEndian);

            // Read the header
            var stringCount = reader.ReadInt32();  // int32 string count
            var dataSize = reader.ReadInt32();     // int32 string data size

            // Read the string offsets into a list of (index, offset) pairs, and then sort by offset
            // This lets us know the length of each string without scanning for a null terminator
            var stringOffsets = new List<Tuple<int, int>>(stringCount);
            for (var i = 0; i < stringCount; i++)
            {
                var offset = reader.ReadInt32();
                if (offset >= 0 && offset < dataSize)
                    stringOffsets.Add(Tuple.Create(i, offset));
            }
            stringOffsets.Sort((x, y) => x.Item2 - y.Item2);

            // Seek to each offset and read each string
            var dataOffset = reader.BaseStream.Position;
            var strings = new string[stringCount];
            for (var i = 0; i < stringOffsets.Count; i++)
            {
                var index = stringOffsets[i].Item1;
                var offset = stringOffsets[i].Item2;
                var nextOffset = (i < stringOffsets.Count - 1) ? stringOffsets[i + 1].Item2 : dataSize;
                var length = Math.Max(0, nextOffset - offset - 1); // Subtract 1 for null terminator
                reader.BaseStream.Position = dataOffset + offset;
                strings[index] = Encoding.ASCII.GetString(reader.ReadBytes(length));
            }
            Clear();
            AddRange(strings.ToList());
        }

        /// <summary>
        /// Creates a string table exactly like the ms23 one up to the last hardcoded stringid in the engine. Do not modify this.
        /// </summary>
        private void CreateFromStrings()
        {
            Clear();
            Add("");

            string filePath = Path.Combine(DirectoryPaths.Data, "string_ids\\string_ids_ms23.txt");
            if (!File.Exists(filePath))
            {
                Log.Warning($"Could not find \"{filePath}\"");
                return;
            }

            foreach (string str in File.ReadAllLines(filePath))
            {
                string[] parts = str.Split('\"');
                if (parts.Length == 3)
                    Add(parts[1]);
            }
        }

        private string TrimStringID(string str)
        {
            return str.Remove(0, "string_id_".Length);
        }
    }
}
