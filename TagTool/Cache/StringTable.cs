using System;
using System.Collections.Generic;
using TagTool.Common;

namespace TagTool.Cache
{
    public abstract class StringTable : List<string>
    {
        public StringIdResolver Resolver;

        public abstract StringId AddString(string newString);

        // override if required
        public virtual string GetString(StringId id)
        {
            if (id == StringId.Invalid)
                return null;
            if (id == StringId.Empty)
                return "";

            var index = Resolver.StringIDToIndex(id);
            if (index >= 0 && index < Count)
                return this[index];
            else
                return null;
        }

        public virtual StringId GetStringId(string str)
        {
            if (str == null)
                return StringId.Invalid;

            for (int i = 0; i < Count; i++)
            {
                if (this[i] == str)
                {
                    return Resolver.IndexToStringID(i);
                }
            }
            return StringId.Invalid;
        }

        public virtual StringId GetStringId(int index)
        {
            if (index < 0 || index >= this.Count)
                return StringId.Invalid;

            return Resolver.IndexToStringID(index);
        }

        public virtual StringId GetOrAddString(string newString)
        {
            StringId stringId = GetStringId(newString);
            if (stringId != StringId.Invalid)
                return stringId;
            return AddString(newString);
        }
    }
}
