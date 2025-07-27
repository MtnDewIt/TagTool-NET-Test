using TagTool.Commands.Common;
using TagTool.Common.Logging;

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
            Log.Warning($@"{errorMessage} {output}");

            return Neutral.Remove(length);
        }
    }
}
