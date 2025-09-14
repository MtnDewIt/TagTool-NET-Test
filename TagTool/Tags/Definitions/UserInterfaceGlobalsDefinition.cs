using TagTool.Cache;
using System.Collections.Generic;
using TagTool.Common;
using static TagTool.Tags.Definitions.Gen4.UserInterfaceGlobalsDefinition;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "user_interface_globals_definition", Tag = "wgtz", Size = 0x3C, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Name = "user_interface_globals_definition", Tag = "wgtz", Size = 0x50, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado449175)]
    [TagStructure(Name = "user_interface_globals_definition", Tag = "wgtz", Size = 0x60, MinVersion = CacheVersion.Eldorado498295, MaxVersion = CacheVersion.Eldorado700123)]
    [TagStructure(Name = "user_interface_globals_definition", Tag = "wgtz", Size = 0xA4, MinVersion = CacheVersion.HaloReach)]

    public class UserInterfaceGlobalsDefinition : TagStructure
	{
        [TagField(ValidTags = new[] { "wigl" })]
        public CachedTag SharedGlobals;
        [TagField(ValidTags = new[] { "goof" })]
        public CachedTag MpVariantSettingsUi;
        [TagField(ValidTags = new[] { "unic" })]
        public CachedTag GameHopperDescriptions;

        public List<ScreenWidget> ScreenWidgets;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<CuiOverlayCameraBlock> CuiOverlayCameras;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<CuiPlayerModelCameraSettingsDefinition> PlayerModelCameraSettings;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<CuiPlayerModelControllerSettingsDefinition> PlayerModelInputSettings;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<CuiPlayerModelTransitionSettingsDefinition> PlayerModelCameraTransitionSettings;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public CachedTag PurchaseGlobals;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<CuiActiveRosterSettingsBlock> ActiveRosterSettings;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public CachedTag PgcrCategoriesDefinitions;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<CampaignStateScreenScriptBlock> CampaignStateScreenScripts;

        [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
        public CachedTag TextureRenderList;
        [TagField(MinVersion = CacheVersion.Eldorado498295, MaxVersion = CacheVersion.Eldorado700123)]
        public CachedTag SwearFilter; // TODO: Version number
        [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
        public uint UnknownHO;

        [TagStructure(Size = 0x10, MaxVersion = CacheVersion.Eldorado700123)]
        [TagStructure(Size = 0x14, MinVersion = CacheVersion.HaloReach)]
        public class ScreenWidget : TagStructure
		{
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public StringId Name;

            [TagField(ValidTags = new[] { "scn3", "cusc" })]
            public CachedTag Widget;
        }
    }
}