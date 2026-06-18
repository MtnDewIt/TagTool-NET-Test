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

        public bool IsInvalid() 
        {
            return Low == 0 && High == 0;
        }

        public long GetTimestamp()
        {
            var hi = (long)High;
            var lo = (long)Low;
            var ldap = (hi << 32) | lo;

            return ldap;
        }

        public DateTime? GetModificationDate()
        {
            var ldap = GetTimestamp();

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

        public void SetModificationDate(long timestamp)
        {
            Low = (uint)(timestamp & uint.MaxValue);
            High = (uint)(timestamp >> 32);
        }

        public static LastModificationDate CreateFromVersion(CacheVersion version) 
        {
            var timestamp = CacheVersionDetection.GetTimestamp(version);

            if (timestamp == -1)
                throw new ArgumentException("Invalid Timestamp", $"{timestamp}");

            var modificationDate = new LastModificationDate();

            modificationDate.SetModificationDate(timestamp);

            return modificationDate;
        }

        public override string ToString()
        {
            var modificationDate = GetModificationDate();
            return modificationDate.HasValue ? modificationDate.Value.ToString("yyyy-MM-dd HH:mm:ss.FFFFFFF") : "Invalid Timestamp";
        }
    }
}
