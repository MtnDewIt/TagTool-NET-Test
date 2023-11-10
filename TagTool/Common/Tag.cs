using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TagTool.Cache;
using TagTool.Cache.Gen3;
using TagTool.Tags;

namespace TagTool.Common
{
    /// <summary>
    /// Represents a magic number which looks like a string.
    /// </summary>
    public struct Tag : IComparable<Tag>, IBlamType, IEquatable<Tag>
	{
        /// <summary>
        /// The null tag representation.
        /// </summary>
        public static Tag Null { get; } = new Tag("ÿÿÿÿ");

        /// <summary>
        /// Constructs a magic number from an integer.
        /// </summary>
        /// <param name="val">The integer.</param>
        public Tag(int val)
        {
            if (val == -1)
                Value = Null.Value;
            else
                Value = val;
        }

        /// <summary>
        /// Constructs a magic number from a string.
        /// </summary>
        /// <param name="str">The string.</param>
        public Tag(string str) : this(str.AsSpan())
		{
        }

        /// <summary>
        /// Constructs a magic number from a character array.
        /// </summary>
        /// <param name="input">The character array.</param>
        public Tag(char[] input) : this(input.AsSpan())
        {
		}

		/// <summary>
		/// Constructs a magic number from a span of chars.
		/// </summary>
		/// <param name="text">The span.</param>
		public Tag(ReadOnlySpan<char> text)
		{
			//read the last 4 unicode chars, which should give us at least 4 ascii chars (if at least 4 available)
			Span<byte> sp = stackalloc byte[13];
			int read = text.Length >= 4 ? Encoding.ASCII.GetBytes(text[^4..], sp[4..]) : Encoding.ASCII.GetBytes(text, sp[4..]);
			Debug.Assert(read > 0);

			//the result is the last 4 (or less if available) ascii chars read as big endian
			Value = BinaryPrimitives.ReadInt32BigEndian(sp[read..(read + 4)]);
		}

		/// <summary>
		/// Gets the value of the magic number as an integer. 
		/// THERE BE DRAGONS HERE: Do not set this manually outside of serialization.
		/// </summary>
		public int Value { get; set; }

        public bool IsNull()
        {
            return Value == -1 || this == Null;
        }


		/// <summary>
		/// Converts the magic number into its string representation.
		/// </summary>
		/// <returns>The string that the magic number looks like.</returns>
		public override string ToString()
        {
			return PrimitiveValueCache.GetStringFor(this);
        }

		//for use only in PrimitiveValueCache
		public unsafe string ToStringUncached()
		{
			var i = 4;
			char* chars = stackalloc char[4];
			var val = Value;
			while (val > 0)
			{
				i--;
				chars[i] = (char)(val & 0xFF);
				val >>= 8;
			}
			return i == 4 ? "" : string.Create(4 - i, (nint)chars, (sp, state) =>
			{
				char* chars = (char*)state;
				new Span<char>(chars + i, 4 - i).CopyTo(sp);
			});
		}

        public static Tag Parse(GameCache cache, string name)
        {
            if (name == "****" || name == "null")
                return Null;

            if (name.Length < 4)
            {
                if (name.Length == 3)
                    name = $"{name} ";
                else if (name.Length == 2)
                    name = $"{name}  ";
            }
            var structureType = cache.TagCache.TagDefinitions.GetTagDefinitionType(name);
            if (structureType != null)
            {
                var attribute = TagStructure.GetTagStructureAttribute(structureType, cache.Version, cache.Platform);
                return new Tag(attribute.Tag);
            }
            
            if(cache.TagCache.TagDefinitions is TagDefinitionsGen3 td3)
            {
				if (td3.TryGetTagFromName(name, out var result)) return result;
            }

            return Null;
        }

        public bool TryParse(GameCache cache, List<string> args, out IBlamType result, out string error)
        {
            result = null;
            if (args.Count != 1)
            {
                error = $"{args.Count} arguments supplied; should be 1";
                return false;
            }
            else if (!cache.TagCache.TryParseGroupTag(args[0], out Tag groupTag))
            {
                error = $"Invalid tag group specifier: {args[0]}";
                return false;
            }
            else
            {
                result = groupTag;
                error = null;
                return true;
            }
        }

        public static bool TryParseGroupTag(GameCache cache, string name, out Tag result)
        {
            var structureType = cache.TagCache.TagDefinitions.GetTagDefinitionType(name);
            
            if (structureType != null)
            {
                var attribute = TagStructure.GetTagStructureAttribute(structureType, cache.Version, cache.Platform);
                result = new Tag(attribute.Tag);
                return true;
            }

            if (cache.TagCache.TagDefinitions is TagDefinitionsGen3 td3)
            {
				if (td3.TryGetTagFromName(name, out result)) return true;
            }

            result = Null;
            return name == "none" || name == "null";
        }

        public override bool Equals(object obj)
        {
            if (obj is not Tag other) return false;
            return Equals(other);
        }

		public bool Equals(Tag other) => Value == other.Value;

        public static bool operator ==(Tag a, Tag b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Tag a, Tag b)
        {
            return !(a == b);
        }

        public static bool operator ==(Tag a, string b)
        {
            return a == new Tag(b);
        }

        public static bool operator !=(Tag a, string b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public int CompareTo(Tag other)
        {
            return Value - other.Value;
        }

        public static implicit operator Tag(string tagString) => new Tag(tagString);
    }
}
