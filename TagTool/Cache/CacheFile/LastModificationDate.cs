using System;
using TagTool.Tags;

namespace TagTool.Cache
{
    [TagStructure(Size = 0x8)]
    public class LastModificationDate
    {
        public uint Low;
        public uint High;

        public LastModificationDate()
        {
            Low = 0;
            High = 0;
        }

        public LastModificationDate(long timeStamp)
        {
            var dateTime = DateTime.FromFileTimeUtc(timeStamp);

            SetModificationDate(dateTime);
        }

        public DateTime? GetModificationDate()
        {
            var hi = (long)High;
            var lo = (long)Low;
            var ldap = (hi << 32) | lo;

            if (ldap < 0 || ldap > DateTime.MaxValue.Ticks)
                return null;

            return DateTime.FromFileTimeUtc(ldap);
        }

        public void SetModificationDate(DateTime date)
        {
            var ldap = date.ToFileTimeUtc();

            Low = (uint)(ldap & uint.MaxValue);
            High = (uint)(ldap >> 32);
        }

        public static LastModificationDate CreateFromVersion(CacheVersion version) 
        {
            var timestamp = CacheVersionDetection.GetTimestamp(version);

            if (!DateTime.TryParse(timestamp, out var dateTime))
                throw new ArgumentException("Invalid Timestamp String", timestamp);

            var modificationDate = new LastModificationDate();

            modificationDate.SetModificationDate(dateTime);

            return modificationDate;
        }

        public static string GetTimestamp(LastModificationDate modificationDate) 
        {
            return $"{modificationDate.GetModificationDate():yyyy-MM-dd HH:mm:ss.FFFFFFF}";
        }
    }
}
