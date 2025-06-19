using System.Collections.Generic;
using TagTool.Cache;

namespace TagTool.Commands.Modding
{
    class SaveModMetadataCommand : Command
    {
        private GameCacheModPackage Cache;
        private ModPackageData Data;

        public SaveModMetadataCommand(GameCacheModPackage cache, ModPackageData data) :
            base(true,

                "SaveModMetadata",
                "Saves changes made to the current mod package metadata definition.\n",
                "SaveModMetadata",
                "Saves changes made to the current mod package metadata definition.\n\n" + 
                
                "This will only update the metadata within the current mod package context.\n" +
                "You will still need to run \"SaveModPackage\" to write the modified data to the pak")
        {
            Cache = cache;
            Data = data;
        }

        public override object Execute(List<string> args)
        {
            Cache.BaseModPackage.Header = Data.Header;
            Cache.BaseModPackage.Metadata = Data.Metadata;

            return true;
        }
    }
}
