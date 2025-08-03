using System;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.Tags
{
    public static class VersionedEnum
    {
        public static object ImportValue(Type enumType, int value, CacheVersion version, CachePlatform platform)
        {
            var info = TagEnum.GetInfo(enumType, version, platform);
            if (!info.Attribute.IsVersioned)
                throw new InvalidOperationException("Cannot import to an non-versioned enum.");

            var enumerable = TagEnum.GetMemberEnumerable(info);
            var members = enumerable.VersionedMembers;

            if (value < 0 || value >= members.Count)
            {
                if (enumerable.Constants.Contains(value))
                    return value;

                throw new ArgumentOutOfRangeException(nameof(value), "Value was out of range of the enum members");
            }

            return members[value].Value;
        }

        public static int ExportValue(Type enumType, object enumValue, CacheVersion version, CachePlatform platform)
        {
            var info = TagEnum.GetInfo(enumType, version, platform);
            if (!info.Attribute.IsVersioned)
                throw new InvalidOperationException("Cannot import to an non-versioned enum.");

            var members = TagEnum.GetMemberEnumerable(info).Members;
            int actualMemberIndex = 0;
            for (int i = 0; i < members.Count; i++)
            {
                bool isConstant = (members[i].Attribute.Flags & TagEnumMemberFlags.Constant) != 0;
                if (members[i].Value.Equals(enumValue))
                {
                    if (isConstant)
                        return Convert.ToInt32(enumValue);
                    else
                        return actualMemberIndex;
                }

                if (!isConstant)
                    actualMemberIndex++;
            }

            throw new ArgumentOutOfRangeException(nameof(enumValue));
        }

        public static IFlagBits ImportFlags(Type enumType, uint value, CacheVersion version, CachePlatform platform)
        {
            var info = TagEnum.GetInfo(enumType, version, platform);
            if (!info.Attribute.IsVersioned)
                throw new InvalidOperationException("Cannot import to an non-versioned enum.");

            var flagBits = (IFlagBits)Activator.CreateInstance(typeof(FlagBits<>).MakeGenericType(enumType));

            var members = TagEnum.GetMemberEnumerable(info).Members;

            for (int i = 0; i < members.Count; i++)
            {
                uint mask = 1u << i;
                if ((value & mask) != 0)
                {
                    value &= ~mask;
                    flagBits.SetBit((Enum)members[i].Value, true);
                }
            }

            if (value != 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Value had more bits set than enum members.");

            return flagBits;
        }

        public static uint ExportFlags(Type enumType, IFlagBits flagBits, CacheVersion version, CachePlatform platform)
        {
            var info = TagEnum.GetInfo(enumType, version, platform);
            if (!info.Attribute.IsVersioned)
                throw new InvalidOperationException("Cannot import to an non-versioned enum.");
    
            var members = TagEnum.GetMemberEnumerable(info).Members;

            uint value = 0;
            for (int i = 0; i < members.Count; i++)
            {
                if (flagBits.TestBit((Enum)members[i].Value))
                    value |= 1u << i;
            }

            return value;
        }
    }
}
