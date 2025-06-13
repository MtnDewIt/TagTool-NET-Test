using TagTool.Commands.Common;

namespace TagTool.BlamFile.MCC
{
    public class LocalizedString
    {
        public enum LocalizedStringType
        {
            Title,
            Description,
        }

        public string Neutral;

        public string ParseLocalizedString(int length, LocalizedStringType stringType)
        {
            if (Neutral.Length <= length) 
            {
                return Neutral;
            }

            new TagToolWarning($@"{stringType.ToString()} string length exceeded supported value [{Neutral.Length} > {length}]. Extra characters have been removed");

            return Neutral.Remove(length);
        }
    }
}
