using System;
using System.Collections.Generic;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.Cache.Resources
{
    [TagStructure(Name = "cache_file_resource_gestalt", Tag = "zone", Size = 0x17C, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado449175)]
    [TagStructure(Name = "cache_file_resource_gestalt", Tag = "zone", Size = 0x170, MinVersion = CacheVersion.Eldorado498295, MaxVersion = CacheVersion.Eldorado700123)]
    [TagStructure(Name = "cache_file_resource_gestalt", Tag = "zone", Size = 0x228, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
    [TagStructure(Name = "cache_file_resource_gestalt", Tag = "zone", Size = 0x220, Version = CacheVersion.HaloReach11883, Platform = CachePlatform.MCC)]
    [TagStructure(Name = "cache_file_resource_gestalt", Tag = "zone", Size = 0x214, MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
    public class ResourceGestalt : TagStructure
    {
        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public ScenarioType MapType;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public ScenarioFlags MapFlags;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<ResourceDefinition> ResourceDefinitions;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<InteropDefinition> InteropDefinitions;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public ResourceLayoutTable LayoutTable = new ResourceLayoutTable();

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<ResourceData> TagResources;

        [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
        public List<TagResourceData> TagResourceTable;

        [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
        public uint ResourcesSize;
        [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
        public uint ResourcesAvailable;

        public List<ZoneManifest> DesignerZoneManifests;
        public List<ZoneManifest> GlobalZoneManifests;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado449175)]
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<ZoneManifest> HsZoneManifests;

        public List<ZoneManifest> UnattachedDesignerZoneManifests;
        public List<ZoneManifest> DvdForbiddenZoneManifests;
        public List<ZoneManifest> DvdAlwaysStreamingZoneManifests;
        public List<ZoneManifest> DefaultBspZoneManifests;
        public List<ZoneManifest> StaticBspZoneManifests;
        public List<ZoneManifest> DynamicBspZoneManifests;
        public List<ZoneManifest> CinematicZoneManifests;
        public List<ZoneManifest> ZonesOnlyZoneSetManifests;
        public List<ZoneManifest> ExpectedZoneManifests;
        public List<ZoneManifest> FullyPopulatedZoneManifests;

        public List<ZoneSetZoneUsage> ZoneSetZoneUsages;

        public List<TagReferenceBlock> BspReferences;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<TagReferenceBlock> TagReferences;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<ModelVariantUsage> ModelVariantUsages;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<CharacterUsage> CharacterUsages;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public byte[] DefinitionData;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public uint MinimumCompletePageableDataSize;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public uint MinimumRequiredPageableDataSize;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public uint MinimumRequiredDvdDataSize;

        public uint GlobalPageableDataSize;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public uint OptionalControlDataSize;

        public List<ZoneResourceUsage> GlobalResourceUsage;

        public List<BspGameAttachment> BspGameAttachments;

        public List<DebugZoneManifest> ModelVariantZoneManifests;
        public List<DebugZoneManifest> CombatDialogueZoneManifests;
        public List<DebugZoneManifest> TagZoneManifests;

        public List<DebugResourceDefinition> DebugResourceDefinitions;
        public List<ResourceLayout> ResourceLayouts;
        public List<ResourceProperty> ResourceProperties;
        public List<Parentage> Parentages;

        public ResourcePredictionTable PredictionTable;

        public int CampaignId;
        public int MapId;

        [TagField(Platform = CachePlatform.MCC)]
        public int DebugCampaignId;
        [TagField(Platform = CachePlatform.MCC)]
        public int DebugMapId;

        [TagStructure(Size = 0x1C)]
        public class ResourceDefinition : TagStructure
        {
            [TagField(Length = 16)]
            public byte[] GUID;

            public int DefinitionFlags;
            public short PageableAlignmentBits;
            public short OptionalAlignmentBits;

            [TagField(Flags = TagFieldFlags.Label)]
            public StringId Name;
        }

        [TagStructure(Size = 0x14)]
        public class InteropDefinition : TagStructure
        {
            [TagField(Length = 16)]
            public byte[] GUID;

            [TagField(Flags = TagFieldFlags.Label)]
            public StringId Name;
        }

        [TagStructure(Size = 0x6C, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado155080)]
        [TagStructure(Size = 0x70, MinVersion = CacheVersion.Eldorado235640, MaxVersion = CacheVersion.Eldorado700123)]
        public class TagResourceData : TagStructure
        {
            public ResourcePage FileLocation;
            public ResourceData RuntimeData;
        }

        [TagStructure(Size = 0x5C, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado449175)]
        [TagStructure(Size = 0x60, MinVersion = CacheVersion.Eldorado498295, MaxVersion = CacheVersion.Eldorado700123)]
        [TagStructure(Size = 0x78, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0xA0, MinVersion = CacheVersion.HaloReach)]
        public class ZoneManifest : TagStructure
        {
            public TagBlockBitVector RequiredResourceBits;

            [TagField(MaxVersion = CacheVersion.Halo3ODST)]
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public TagBlockBitVector DeferredResourceBits;

            public TagBlockBitVector OptionalResourceBits;

            [TagField(MaxVersion = CacheVersion.Halo3ODST)]
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public TagBlockBitVector StreamedResourceBits;

            [TagField(MinVersion = CacheVersion.Eldorado498295, MaxVersion = CacheVersion.Eldorado700123)]
            public uint RequiredPageableSize;
            [TagField(MinVersion = CacheVersion.Eldorado498295, MaxVersion = CacheVersion.Eldorado700123)]

            public uint OptionalMemorySize;

            [TagField(MaxVersion = CacheVersion.Halo3ODST)]
            [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado449175)]
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public ZoneResourceUsage OverallUsage;

            [TagField(MaxVersion = CacheVersion.Eldorado700123)]
            public StringId Name;

            public List<ZoneResourceUsage> ResourceUsage;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public List<ZoneResourceUsage> BudgetUsage;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public List<ZoneResourceUsage> UniqueBudgetUsage;

            public TagBlockBitVector ActiveResourceOwners;
            public TagBlockBitVector TopLevelResourceOwners;

            [TagField(MaxVersion = CacheVersion.Halo3ODST)]
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public List<ZoneResourceVisitNode> AttachmentHeirarchy;

            [TagField(MinVersion = CacheVersion.Eldorado498295, MaxVersion = CacheVersion.Eldorado700123)]
            public List<ZoneResourceZonesetObjects> ZonesetObjects;

            // These could be some of the reach masks - MtnDewIt
            [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
            public uint Unknown1;
            [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
            public uint Unknown2;
            [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
            public uint Unknown3;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public uint ActiveBspMask;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public uint TouchedBspMask;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public uint DesignerZoneMask;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public uint CinematicZoneMask;

            [TagStructure(Size = 0x10)]
            public class ZoneResourceVisitNode : TagStructure
            {
                public short ParentTagIndex;

                [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
                public byte[] Padding;

                public List<ZoneResourceVistNodeLink> Children;

                [TagStructure(Size = 0x2)]
                public class ZoneResourceVistNodeLink : TagStructure
                {
                    public short ChildTagIndex;
                }
            }

            [TagStructure(Size = 0x1C, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
            public class ZoneResourceZonesetObjects : TagStructure
            {
                public CachedTag Object;

                public List<ZoneResourceObjectDependency> Dependencies;

                [TagStructure(Size = 0x2)]
                public class ZoneResourceObjectDependency : TagStructure
                {
                    public short TagResourceIndex;
                }
            }
        }

        [TagStructure(Size = 0x24)]
        public class ZoneSetZoneUsage : TagStructure
        {
            [TagField(Flags = TagFieldFlags.Label)]
            public StringId Name;

            public ScenarioZoneSetFlags Flags;

            public ZoneSetBitField RequiredBspZones;
            public ZoneSetBitField ExpectedTouchedBspZones;
            public ZoneSetBitField RequiredDesignerZones;
            public ZoneSetBitField ExpectedDesignerZones;
            public ZoneSetBitField ForbiddenDesignerZones;
            public ZoneSetBitField RequiredCinematicZones;

            public int PreviousZoneSetIndex;

            [Flags]
            public enum ScenarioZoneSetFlags : int
            {
                None = 0,
                BeginLoadingNextLevel = 1 << 0,
                DebugPurposesOnly = 1 << 1,
                InteralZoneSet = 1 << 2,
            }

            [Flags]
            public enum ZoneSetBitField : int
            {
                None = 0,
                Index0 = 1 << 0,
                Index1 = 1 << 1,
                Index2 = 1 << 2,
                Index3 = 1 << 3,
                Index4 = 1 << 4,
                Index5 = 1 << 5,
                Index6 = 1 << 6,
                Index7 = 1 << 7,
                Index8 = 1 << 8,
                Index9 = 1 << 9,
                Index10 = 1 << 10,
                Index11 = 1 << 11,
                Index12 = 1 << 12,
                Index13 = 1 << 13,
                Index14 = 1 << 14,
                Index15 = 1 << 15,
                Index16 = 1 << 16,
                Index17 = 1 << 17,
                Index18 = 1 << 18,
                Index19 = 1 << 19,
                Index20 = 1 << 20,
                Index21 = 1 << 21,
                Index22 = 1 << 22,
                Index23 = 1 << 23,
                Index24 = 1 << 24,
                Index25 = 1 << 25,
                Index26 = 1 << 26,
                Index27 = 1 << 27,
                Index28 = 1 << 28,
                Index29 = 1 << 29,
                Index30 = 1 << 30,
                Index31 = 1 << 31
            }
        }

        [TagStructure(Size = 0x14)]
        public class ModelVariantUsage : TagStructure
        {
            public short ModelIndex;

            [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            public StringId Variant;

            public List<ModelVariantUsageReference> UsedMaterials;

            [TagStructure(Size = 0x2)]
            public class ModelVariantUsageReference : TagStructure
            {
                public short TagIndex;
            }
        }

        [TagStructure(Size = 0x10)]
        public class CharacterUsage : TagStructure
        {
            public short ModelIndex;

            [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            public List<CharacterUsageReference> UsedModelVariants;

            [TagStructure(Size = 0x2)]
            public class CharacterUsageReference : TagStructure
            {
                public short ModelVariantIndex;
            }
        }

        [TagStructure(Size = 0x10, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado449175)]
        [TagStructure(Size = 0xC, MinVersion = CacheVersion.Eldorado498295, MaxVersion = CacheVersion.Eldorado700123)]
        [TagStructure(Size = 0x14, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0x18, MinVersion = CacheVersion.HaloReach)]
        public class ZoneResourceUsage : TagStructure
        {
            [TagField(Flags = TagFieldFlags.Label, MinVersion = CacheVersion.HaloReach)]
            public StringId Name;

            public uint RequiredPageableSize;
            public uint DeferredRequiredSize;
            public uint OptionalMemorySize;

            [TagField(MaxVersion = CacheVersion.Halo3ODST)]
            [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado449175)]
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public uint StreamedSize;

            [TagField(MaxVersion = CacheVersion.Halo3ODST)]
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public uint DvdMemorySize;
        }

        [TagStructure(Size = 0x24)]
        public class BspGameAttachment : TagStructure
        {
            public List<BspAttachment> Static;
            public List<BspAttachment> Persistent;
            public List<BspAttachment> Dynamic;

            [TagStructure(Size = 0x10)]
            public class BspAttachment : TagStructure
            {
                public CachedTag Attachment;
            }
        }

        [TagStructure(Size = 0x90, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0x74, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado449175)]
        [TagStructure(Size = 0x90, MinVersion = CacheVersion.Eldorado454665, MaxVersion = CacheVersion.Eldorado700123)]
        [TagStructure(Size = 0xAC, MinVersion = CacheVersion.HaloReach)]
        public class DebugZoneManifest : TagStructure
        {
            public ZoneManifest CacheZoneManifest;

            public int DiskSize;
            public int UnusedSize;
            public CachedTag OwnerTag;
        }

        [TagStructure(Size = 0xC)]
        public class DebugResourceDefinition : TagStructure
        {
            public List<ResourceCategory> Categories;

            [TagStructure(Size = 0x4)]
            public class ResourceCategory : TagStructure
            {
                public StringId Name;
            }
        }

        [TagStructure(Size = 0x24)]
        public class ResourceLayout : TagStructure
        {
            public int ImmediatelyRequiredResourceSize;
            public int DeferredRequiredResourceSize;
            public int OptionalResourceSize;
            public int UnusedResourceSize;
            public int PageableCompressedSize;
            public int OptionalCompressedSize;
            public GlobalZoneAttachmentFlags GlobalZoneAttachment;
            public ushort BspZoneAttachment;
            public int DesignerZoneAttachment;
            public int CinematicZoneAttachment;

            [Flags]
            public enum GlobalZoneAttachmentFlags : short
            {
                None = 0,
                Global = 1 << 0,
                Script = 1 << 1,
                HDDOnly = 1 << 2,
                AlwaysStreaming = 1 << 3,
                Unattached = 1 << 4,
            }
        }

        [TagStructure(Size = 0xC)]
        public class ResourceProperty : TagStructure
        {
            public List<ResourceNamedValue> NamedValues;

            [TagStructure(Size = 0x14)]
            public class ResourceNamedValue : TagStructure
            {
                public StringId Name;
                public NamedValueType Type;
                public StringId StringValue;
                public float RealValue;
                public int IntValue;

                public enum NamedValueType : int
                {
                    Unknown,
                    String,
                    Real,
                    Int,
                }
            }
        }

        [TagStructure(Size = 0x2C)]
        public class Parentage : TagStructure
        {
            public CachedTag Tag;
            public ParentageFlags Flags;
            public short ResourceOwnerIndex;

            public List<ParentageReference> Parents;
            public List<ParentageReference> Children;

            [Flags]
            public enum ParentageFlags : short
            {
                None = 0,
                LoadedByGame = 1 << 0,
                Unloaded = 1 << 1,
            }

            [TagStructure(Size = 0x4)]
            public class ParentageReference : TagStructure
            {
                public int Link;
            }
        }

        [TagStructure(Size = 0x3C)]
        public class ResourcePredictionTable : TagStructure
        {
            public List<PredictionQuantum> PredictionQuanta;
            public List<PredictionAtom> PredictionAtoms;
            public List<PredictionMoleculeAtom> PredictionMoleculeAtoms;
            public List<PredictionMolecule> PredictionMolecules;
            public List<PredictionMoleculeKey> PredictionMoleculeKeys;

            [TagStructure(Size = 0x4)]
            public class PredictionQuantum : TagStructure
            {
                public DatumHandle InternalResourceHandle;
            }

            [TagStructure(Size = 0x8)]
            public class PredictionAtom : TagStructure
            {
                public ushort IndexSalt;
                public short PredictionQuantumCount;
                public int FirstPredictionQuantumIndex;
            }

            [TagStructure(Size = 0x4)]
            public class PredictionMoleculeAtom : TagStructure
            {
                public DatumHandle PredictionAtomHandle;
            }

            [TagStructure(Size = 0x8)]
            public class PredictionMolecule : TagStructure
            {
                public short PredictionAtomCount;
                public short FirstPredictionAtomIndex;
                public short PredictionQuantumCount;
                public short FirstPredictionQuantumIndex;
            }

            [TagStructure(Size = 0x18, MaxVersion = CacheVersion.Halo3ODST)]
            [TagStructure(Size = 0xC, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
            [TagStructure(Size = 0x18, MinVersion = CacheVersion.HaloReach)]
            public class PredictionMoleculeKey : TagStructure
            {
                [TagField(MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public CachedTag Owner;

                [TagField(MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public int FirstValue;

                [TagField(MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public int SecondValue;
            
                [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
                public int IndexA;
                [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
                public int IndexB;
                [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
                public int IndexC;
            }
        }
    }
}