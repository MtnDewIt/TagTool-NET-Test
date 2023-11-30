namespace TagTool.MtnDewIt.Porting
{
    public partial class PortingContext
    {
        public int PaletteCategory;
        public string PaletteItemName;
        public bool IsForgeItem = false;

        // Does the same job as the MPobject flag in the porttag command, but instead moves the object data outside of the porting flags
        public void PortMultiplayerObject(int paletteCategory, string paletteItemName, string portingOptions, string tag) 
        {
            PaletteCategory = paletteCategory;
            PaletteItemName = paletteItemName;

            // Sets the flag to true
            IsForgeItem = true;

            PortTag(portingOptions, tag);

            // Resets the flag after the object has been ported
            IsForgeItem = false;
        }
    }
}