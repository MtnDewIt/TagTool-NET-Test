namespace TagTool.MtnDewIt.Porting
{
    public partial class PortingContext
    {
        public string[] ObjectParameters = new string[]{};

        // Does the same job as the MPobject flag in the porttag command, but instead moves the object data outside of the porting flags
        public void PortMultiplayerObject(string paletteCategory, string paletteItemName, string portingOptions, string tag) 
        {
            if (!portingOptions.Contains("MPobject")) 
            {
                portingOptions = portingOptions + " MPobject";
            }

            string[] inputParameters = { paletteCategory, paletteItemName };

            ObjectParameters = inputParameters;

            PortTag(portingOptions, tag);
        }
    }
}