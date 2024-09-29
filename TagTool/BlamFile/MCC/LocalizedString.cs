using TagTool.Commands.Common;

namespace TagTool.BlamFile.MCC
{
    public class LocalizedString
    {
        public string Neutral;

        public string ParseLocalizedString(int length, string errorMessage)
        {
            if (Neutral.Length <= length) 
            {
                return Neutral;
            }

            var output = $@"string length exceeded supported value [{Neutral.Length} > {length}]. Extra characters have been removed";
            new TagToolWarning($@"{errorMessage} {output}");

            return Neutral.Remove(length);
        }
    }
}
