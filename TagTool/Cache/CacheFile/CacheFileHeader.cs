using System;
using TagTool.Cache.Eldorado.Headers;
using TagTool.Cache.Gen1.Headers;
using TagTool.Cache.Gen2.Headers;
using TagTool.Cache.Gen3.Headers;
using TagTool.Cache.Gen4.Headers;
using TagTool.Cache.MCC.Headers;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.Cache
{
    [TagStructure]
    public abstract class CacheFileHeader : TagStructure
    {
        public virtual bool IsValid()
        {
            if (GetHeaderSignature() == "head" && GetFooterSignature() == "foot")
                return true;
            else
                return false;
        }

        public static CacheFileHeader Read(CacheVersion version, CachePlatform platform, EndianReader reader)
        {
            reader.SeekTo(0);
            var deserializer = new TagDeserializer(version, platform);
            var dataContext = new DataSerializationContext(reader);

            if (platform == CachePlatform.MCC)
            {
                return version switch
                {
                    CacheVersion.HaloCustomEdition => deserializer.Deserialize<CacheFileHeaderHalo1MCC>(dataContext),
                    CacheVersion.Halo2PC => deserializer.Deserialize<CacheFileHeaderHalo2MCC>(dataContext),
                    CacheVersion.Halo3Retail => deserializer.Deserialize<CacheFileHeaderHalo3MCC>(dataContext),
                    CacheVersion.Halo3ODST => deserializer.Deserialize<CacheFileHeaderHalo3ODSTMCC>(dataContext),
                    CacheVersion.HaloReach => deserializer.Deserialize<CacheFileHeaderHaloReachMCC>(dataContext),
                    CacheVersion.Halo4 => deserializer.Deserialize<CacheFileHeaderHalo4MCC>(dataContext),
                    CacheVersion.Halo2AMP => deserializer.Deserialize<CacheFileHeaderHalo2AMPMCC>(dataContext),
                    _ => null,
                };
            }
            else
            {
                return version switch
                {
                    CacheVersion.HaloPC => deserializer.Deserialize<CacheFileHeaderHaloPC>(dataContext),
                    CacheVersion.HaloXbox => deserializer.Deserialize<CacheFileHeaderHaloXbox>(dataContext),
                    CacheVersion.HaloCustomEdition => deserializer.Deserialize<CacheFileHeaderHaloCustomEdition>(dataContext),
                    CacheVersion.Halo2Alpha => deserializer.Deserialize<CacheFileHeaderHalo2Alpha>(dataContext),
                    CacheVersion.Halo2Beta => deserializer.Deserialize<CacheFileHeaderHalo2Beta>(dataContext),
                    CacheVersion.Halo2Xbox => deserializer.Deserialize<CacheFileHeaderHalo2Xbox>(dataContext),
                    CacheVersion.Halo2PC => deserializer.Deserialize<CacheFileHeaderHalo2Vista>(dataContext),
                    CacheVersion.Halo3Beta => deserializer.Deserialize<CacheFileHeaderHalo3Beta>(dataContext),
                    CacheVersion.Halo3Retail => deserializer.Deserialize<CacheFileHeaderHalo3>(dataContext),
                    CacheVersion.Halo3ODST => deserializer.Deserialize<CacheFileHeaderHalo3ODST>(dataContext),
                    CacheVersion.HaloReach => deserializer.Deserialize<CacheFileHeaderHaloReach>(dataContext),
                    CacheVersion.EldoradoED => deserializer.Deserialize<CacheFileHeaderEldoradoED>(dataContext),
                    CacheVersion.Eldorado106708 => deserializer.Deserialize<CacheFileHeaderEldorado106708>(dataContext),
                    CacheVersion.Eldorado155080 => deserializer.Deserialize<CacheFileHeaderEldorado155080>(dataContext),
                    CacheVersion.Eldorado235640 => deserializer.Deserialize<CacheFileHeaderEldorado235640>(dataContext),
                    CacheVersion.Eldorado301003 => deserializer.Deserialize<CacheFileHeaderEldorado301003>(dataContext),
                    CacheVersion.Eldorado327043 => deserializer.Deserialize<CacheFileHeaderEldorado327043>(dataContext),
                    CacheVersion.Eldorado372731 => deserializer.Deserialize<CacheFileHeaderEldorado372731>(dataContext),
                    CacheVersion.Eldorado416097 => deserializer.Deserialize<CacheFileHeaderEldorado416097>(dataContext),
                    CacheVersion.Eldorado430475 => deserializer.Deserialize<CacheFileHeaderEldorado430475>(dataContext),
                    CacheVersion.Eldorado454665 => deserializer.Deserialize<CacheFileHeaderEldorado454665>(dataContext),
                    CacheVersion.Eldorado449175 => deserializer.Deserialize<CacheFileHeaderEldorado449175>(dataContext),
                    CacheVersion.Eldorado498295 => deserializer.Deserialize<CacheFileHeaderEldorado498295>(dataContext),
                    CacheVersion.Eldorado530605 => deserializer.Deserialize<CacheFileHeaderEldorado530605>(dataContext),
                    CacheVersion.Eldorado532911 => deserializer.Deserialize<CacheFileHeaderEldorado532911>(dataContext),
                    CacheVersion.Eldorado554482 => deserializer.Deserialize<CacheFileHeaderEldorado554482>(dataContext),
                    CacheVersion.Eldorado571627 => deserializer.Deserialize<CacheFileHeaderEldorado571627>(dataContext),
                    CacheVersion.Eldorado604673 => deserializer.Deserialize<CacheFileHeaderEldorado604673>(dataContext),
                    CacheVersion.Eldorado700123 => deserializer.Deserialize<CacheFileHeaderEldorado700123>(dataContext),
                    CacheVersion.Halo4 => deserializer.Deserialize<CacheFileHeaderHalo4>(dataContext),
                    _ => null,
                };
            }
        }

        public static Type GetHeaderType(CacheVersion version, CachePlatform platform)
        {
            if (platform == CachePlatform.MCC)
            {
                return version switch
                {
                    CacheVersion.HaloCustomEdition => typeof(CacheFileHeaderHalo1MCC),
                    CacheVersion.Halo2PC => typeof(CacheFileHeaderHalo2MCC),
                    CacheVersion.Halo3Retail => typeof(CacheFileHeaderHalo3MCC),
                    CacheVersion.Halo3ODST => typeof(CacheFileHeaderHalo3ODSTMCC),
                    CacheVersion.HaloReach => typeof(CacheFileHeaderHaloReachMCC),
                    CacheVersion.Halo4 => typeof(CacheFileHeaderHalo4MCC),
                    CacheVersion.Halo2AMP => typeof(CacheFileHeaderHalo2AMPMCC),
                    _ => null,
                };
            }
            else
            {
                return version switch
                {
                    CacheVersion.HaloPC => typeof(CacheFileHeaderHaloPC),
                    CacheVersion.HaloXbox => typeof(CacheFileHeaderHaloXbox),
                    CacheVersion.HaloCustomEdition => typeof(CacheFileHeaderHaloCustomEdition),
                    CacheVersion.Halo2Alpha => typeof(CacheFileHeaderHalo2Alpha),
                    CacheVersion.Halo2Beta => typeof(CacheFileHeaderHalo2Beta),
                    CacheVersion.Halo2Xbox => typeof(CacheFileHeaderHalo2Xbox),
                    CacheVersion.Halo2PC => typeof(CacheFileHeaderHalo2Vista),
                    CacheVersion.Halo3Beta => typeof(CacheFileHeaderHalo3Beta),
                    CacheVersion.Halo3Retail => typeof(CacheFileHeaderHalo3),
                    CacheVersion.Halo3ODST => typeof(CacheFileHeaderHalo3ODST),
                    CacheVersion.HaloReach => typeof(CacheFileHeaderHaloReach),
                    CacheVersion.EldoradoED => typeof(CacheFileHeaderEldoradoED),
                    CacheVersion.Eldorado106708 => typeof(CacheFileHeaderEldorado106708),
                    CacheVersion.Eldorado155080 => typeof(CacheFileHeaderEldorado155080),
                    CacheVersion.Eldorado235640 => typeof(CacheFileHeaderEldorado235640),
                    CacheVersion.Eldorado301003 => typeof(CacheFileHeaderEldorado301003),
                    CacheVersion.Eldorado327043 => typeof(CacheFileHeaderEldorado327043),
                    CacheVersion.Eldorado372731 => typeof(CacheFileHeaderEldorado372731),
                    CacheVersion.Eldorado416097 => typeof(CacheFileHeaderEldorado416097),
                    CacheVersion.Eldorado430475 => typeof(CacheFileHeaderEldorado430475),
                    CacheVersion.Eldorado454665 => typeof(CacheFileHeaderEldorado454665),
                    CacheVersion.Eldorado449175 => typeof(CacheFileHeaderEldorado449175),
                    CacheVersion.Eldorado498295 => typeof(CacheFileHeaderEldorado498295),
                    CacheVersion.Eldorado530605 => typeof(CacheFileHeaderEldorado530605),
                    CacheVersion.Eldorado532911 => typeof(CacheFileHeaderEldorado532911),
                    CacheVersion.Eldorado554482 => typeof(CacheFileHeaderEldorado554482),
                    CacheVersion.Eldorado571627 => typeof(CacheFileHeaderEldorado571627),
                    CacheVersion.Eldorado604673 => typeof(CacheFileHeaderEldorado604673),
                    CacheVersion.Eldorado700123 => typeof(CacheFileHeaderEldorado700123),
                    CacheVersion.Halo4 => typeof(CacheFileHeaderHalo4),
                    _ => null,
                };
            }
        }

        public abstract Tag GetHeaderSignature();
        public abstract Tag GetFooterSignature();
        public abstract ulong GetTagsHeaderWhenLoaded();
        public abstract ulong GetExpectedBaseAddress();
        public abstract string GetName();
        public abstract string GetBuildNumber();
        public abstract string GetTagPath();
        public abstract int GetMapId();
        public abstract int GetScenarioIndex();
        public abstract CacheFileType GetScenarioType();
        public abstract CacheFileSharedType GetSharedCacheFileType();

        public abstract int GetStringIdCount();
        public abstract int GetStringIdDataCount();
        public abstract uint GetStringIdIndexOffset();
        public abstract uint GetStringIdDataOffset();
        public abstract int GetStringIdNamespaceCount();
        public abstract uint GetStringIdNamespaceOffset();

        public abstract int GetDebugTagNameCount();
        public abstract uint GetDebugTagNameDataOffset();
        public abstract int GetDebugTagNameDataSize();
        public abstract uint GetDebugTagNameIndexOffset();

        public abstract uint GetTagsOffset();
        public abstract uint GetTagsVirtualBase();

        public abstract CacheFileFlags GetFlags();
        public abstract int GetCompressedDataChunkSize();
        public abstract int GetCompressedDataOffset();
        public abstract int GetCompressedChunkTableOffset();
        public abstract int GetCompressedChunkCount();

        public abstract CacheFileSectionTable GetSectionTable();
        public abstract CacheFileSectionFileBounds GetReports();
        
        // TODO: Figure out a better way of handling this
        public virtual void SetScenarioIndex(int index) { return; }
        public virtual void SetScenarioType(CacheFileType scenarioType) { return; }
    }
}
