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

        public DateTime GetModificationDate()
        {
            var high = (long)High << 32;
            var ldap = high + Low;

            return DateTime.FromFileTimeUtc(ldap);
        }

        public void SetModificationDate(DateTime date)
        {
            var ldap = date.ToFileTimeUtc();

            Low = (uint)(ldap & uint.MaxValue);
            High = (uint)(ldap >> 32);
        }
    }
}
