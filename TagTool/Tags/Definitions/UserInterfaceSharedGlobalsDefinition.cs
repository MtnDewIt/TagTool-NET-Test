using TagTool.Cache;
using TagTool.Common;
using System.Collections.Generic;
using System;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "user_interface_shared_globals_definition", Tag = "wigl", Size = 0x170, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
    [TagStructure(Name = "user_interface_shared_globals_definition", Tag = "wigl", Size = 0x160, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
    [TagStructure(Name = "user_interface_shared_globals_definition", Tag = "wigl", Size = 0x3CC, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123, Platform = CachePlatform.Original)]
    [TagStructure(Name = "user_interface_shared_globals_definition", Tag = "wigl", Size = 0x3DC, Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
    [TagStructure(Name = "user_interface_shared_globals_definition", Tag = "wigl", Size = 0x164, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
    [TagStructure(Name = "user_interface_shared_globals_definition", Tag = "wigl", Size = 0x174, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
    public class UserInterfaceSharedGlobalsDefinition : TagStructure
    {
        public short IncTextUpdatePeriod; // milliseconds
        public short IncTextBlockCharacter; // ASCII code
        public float NearClipPlaneDistance; // objects closer than this are not drawn
        public float ProjectionPlaneDistance; // distance at which objects are rendered when z=0 (normal size)
        public float FarClipPlaneDistance; // objects farther than this are not drawn

        [TagField(ValidTags = new [] { "unic" })]
        public CachedTag GlobalStrings;
        [TagField(ValidTags = new [] { "unic" })]
        public CachedTag DamageReportingStrings;

        [TagField(ValidTags = new[] { "unic" }, MinVersion = CacheVersion.HaloReach)]
        public CachedTag FireTeamMemberNameStrings;
        [TagField(ValidTags = new[] { "unic" }, MinVersion = CacheVersion.HaloReach)]
        public CachedTag FireTeamMemberServiceTagStrings;

        [TagField(ValidTags = new[] { "unic" }, MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
        [TagField(ValidTags = new[] { "unic" }, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123, Platform = CachePlatform.Original)]
        public CachedTag InputStrings;

        [TagField(ValidTags = new[] { "lsnd" })]
        public CachedTag MainMenuMusic;

        public int MusicFadeTime; // milliseconds
        public RealArgbColor TextColor;
        public RealArgbColor TextShadowColor;
        public List<ColorPreset> ColorPresets;
        public List<PlayerColor> PlayerTintColors;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public short PrimaryEmblemCount;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public short SecondaryEmblemCount;

        [TagField(ValidTags = new[] { "uise" })]
        public CachedTag DefaultSounds;

        public List<GuiAlertDescription> AlertDescriptions;
        public List<Dialog> DialogDescriptions;

        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public List<GlobalDataSource> GlobalDataSources;

        public RealPoint2d WidescreenBitmapScale;
        public RealPoint2d StandardBitmapScale;
        public RealPoint2d MenuBlurFactor;

        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public List<UiWidgetBiped> UiWidgetBipeds;

        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public StringId Player0Flag;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public StringId Player1Flag;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public StringId Player2Flag;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public StringId Player3Flag;

        //Spartan in H3
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public StringId MCBipedName;

        [TagField(Length = 32, MaxVersion = CacheVersion.Eldorado700123)]
        public string McBipedName;

        [TagField(Length = 32)] public string McAiSquadName;

        public StringId McAiStartPosition;

        //Elite in H3
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public StringId EliteBipedNameReach;

        [TagField(Length = 32, MaxVersion = CacheVersion.Eldorado700123)]
        public string EliteBipedName;

        [TagField(Length = 32)] public string EliteAiSquadName;

        public StringId EliteAiStartPosition;
        
        [TagField(Length = 32, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public string UiMickeyBipedName;
        [TagField(Length = 32, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public string UiMickeyAiSquadName;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public StringId UiMickeyAiLocationName;

        [TagField(Length = 32, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public string UiRomeoBipedName;
        [TagField(Length = 32, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public string UiRomeoAiSquadName;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public StringId UiRomeoAiLocationName;

        [TagField(Length = 32, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public string UiDutchBipedName;
        [TagField(Length = 32, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public string UiDutchAiSquadName;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public StringId UiDutchAiLocationName;

        [TagField(Length = 32, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public string UiJohnsonBipedName;
        [TagField(Length = 32, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public string UiJohnsonAiSquadName;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public StringId UiJohnsonAiLocationName;

        [TagField(Length = 32, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public string UiOdst2BipedName;
        [TagField(Length = 32, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public string UiOdst2AiSquadName;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public StringId UiOdst2AiLocationName;

        [TagField(Length = 32, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public string UiOdst3BipedName;
        [TagField(Length = 32, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public string UiOdst3AiSquadName;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public StringId UiOdst3AiLocationName;

        [TagField(Length = 32, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public string UiOdst4BipedName;
        [TagField(Length = 32, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public string UiOdst4AiSquadName;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public StringId UiOdst4AiLocationName;
        
        public int NavigationScrollInterval; //milliseconds
        public int NavigationFastScrollDelay; //milliseconds
        public int NavigationFastScrollInterval; //milliseconds

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public TagFunction SpinnerTabSpeedFunction;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public int MaximumInputTimeOnGraphMs;

        public int AttractVideoDelay; // seconds

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<PCGRPerPlayerTrackedIncident> PcgrPerPlayerTrackedIncidents;

        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public TagFunction PdaWaypointScaleFunction;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public float PdaCameraVelocity; // pixels per second
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public float CameraAutoMoveDelay;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public float PlayerOffscreenMarkerTolerance; // pixels
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public float PlayerOrientationDeadZone; // area around you where the PDA doesn't auto-orient you (pixels)
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public float PdaAiClumpCullDistance; // wu

        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public CachedTag PdaScreenEffect;      
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public RealArgbColor PdaPlayedColor;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public RealArgbColor PdaUnplayedColor;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public StringId PdaPoiWaypointPrefix;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public StringId PdaPoiWaypointSuffix;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public uint PdaBriefOpenThreshold;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public float PdaTextFadetime;

        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public List<ARGBlock> ARG;

        [TagStructure(Size = 0x24)]
        public class ARGBlock : TagStructure
		{
            public StringId Name;
            public CachedTag Audio;
            public CachedTag Timing;
        }

        [TagStructure(Size = 0x14)]
        public class ColorPreset : TagStructure
		{
            public StringId Name;
            public RealArgbColor Color;
        }

        [TagStructure(Size = 0x30)]
        public class PlayerColor : TagStructure
		{
            public List<ColorListBlock> PlayerTextColor;
            public List<ColorListBlock> TeamTextColor;
            public List<ColorListBlock> PlayerUiColor;
            public List<ColorListBlock> TeamUiColor;

            [TagStructure(Size = 0x10)]
            public class ColorListBlock : TagStructure
			{
                public RealArgbColor Color;
            }
        }

        [TagStructure(Size = 0x10)]
        public class GuiAlertDescription : TagStructure
		{
            public StringId ErrorName;
            public GuiAlertFlags Flags;
            public GuiErrorCategoryEnum ErrorCategory;
            public IconValue Icon;

            [TagField(Length = 1, Flags = TagFieldFlags.Padding)]
            public byte[] Pad0;

            public StringId Title;
            public StringId Message;

            [Flags]
            public enum GuiAlertFlags : byte
            {
                AllowAutoDismissal = 1 << 0,
                ShowSpinner = 1 << 1
            }

            public enum GuiErrorCategoryEnum : sbyte
            {
                Default,
                Networking,
                StoragereadingwritingFailure,
                Controller
            }

            public enum IconValue : sbyte
            {
                None,
                Download,
                Pause,
                Upload,
                Checkbox,
            }
        }

        [TagStructure(Size = 0x28)]
        public class Dialog : TagStructure
		{
            public StringId Name;
            public GuiDialogFlags Flags;

            [TagField(Length = 2, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            public StringId Title;
            public StringId Body;
            public StringId FirstItem;
            public StringId SecondItem;
            public StringId ThirdItem;
            public StringId FourthItem;
            public StringId KeyLegend;
            public GuiDialogChoice DefaultOption;
            public GuiDialogBButtonActionEnum BButtonAction;

            [Flags]
            public enum GuiDialogFlags : ushort
            {
                Unused = 1 << 0
            }

            public enum GuiDialogChoice : short
            {
                FirstItem,
                SecondItem,
                ThirdItem,
                FourthItem
            }

            public enum GuiDialogBButtonActionEnum : short
            {
                DismissesDialog,
                ButtonIgnored,
                FirstItemActivates,
                SecondItemActivates,
                ThirdItemActivates,
                FourthItemActivates
            }
        }

        [TagStructure(Size = 0x10)]
        public class GlobalDataSource : TagStructure
		{
            [TagField(ValidTags = new[] { "dsrc" })]
            public CachedTag DataSource;
        }

        [TagStructure(Size = 0x154)]
        public class UiWidgetBiped : TagStructure
		{
            [TagField(Length = 32)] public string AppearanceBipedName;
            [TagField(Length = 32)] public string AppearanceAiSquadName;
            public StringId AppearanceAiLocationName;
            [TagField(Length = 32)] public string RosterPlayer1BipedName;
            [TagField(Length = 32)] public string RosterPlayer1AiSquadName;
            public StringId RosterPlayer1AiLocationName;
            [TagField(Length = 32)] public string RosterPlayer2BipedName;
            [TagField(Length = 32)] public string RosterPlayer2AiSquadName;
            public StringId RosterPlayer2AiLocationName;
            [TagField(Length = 32)] public string RosterPlayer3BipedName;
            [TagField(Length = 32)] public string RosterPlayer3AiSquadName;
            public StringId RosterPlayer3AiLocationName;
            [TagField(Length = 32)] public string RosterPlayer4BipedName;
            [TagField(Length = 32)] public string RosterPlayer4AiSquadName;
            public StringId RosterPlayer4AiLocationName;
        }

        [TagStructure(Size = 0x8)]
        public class PCGRPerPlayerTrackedIncident : TagStructure
        {
            public StringId IncidentName;
            public int MaximumStatCount;
        }
    }
}