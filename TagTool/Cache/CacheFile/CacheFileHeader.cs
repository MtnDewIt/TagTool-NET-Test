using System;
using TagTool.Cache.HaloOnline.Headers;
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
                    CacheVersion.H2AMP => deserializer.Deserialize<CacheFileHeaderHalo2AMPMCC>(dataContext),
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
                    CacheVersion.Halo3PreAlpha => deserializer.Deserialize<CacheFileHeaderHalo3PreAlpha>(dataContext),
                    CacheVersion.Halo3Alpha => deserializer.Deserialize<CacheFileHeaderHalo3Alpha>(dataContext),
                    CacheVersion.Halo3Beta => deserializer.Deserialize<CacheFileHeaderHalo3Beta>(dataContext),
                    CacheVersion.Halo3March7Delta => deserializer.Deserialize<CacheFileHeaderHalo3March7Delta>(dataContext),
                    CacheVersion.Halo3March8Delta => deserializer.Deserialize<CacheFileHeaderHalo3March8Delta>(dataContext),
                    CacheVersion.Halo3March9Delta => deserializer.Deserialize<CacheFileHeaderHalo3March9Delta>(dataContext),
                    CacheVersion.Halo3Epsilon => deserializer.Deserialize<CacheFileHeaderHalo3Epsilon>(dataContext),
                    CacheVersion.Halo3DLC => deserializer.Deserialize<CacheFileHeaderHalo3DLC>(dataContext),
                    CacheVersion.Halo3Retail => deserializer.Deserialize<CacheFileHeaderHalo3>(dataContext),
                    CacheVersion.Halo3ODST => deserializer.Deserialize<CacheFileHeaderHalo3ODST>(dataContext),
                    CacheVersion.HaloReachAlpha => deserializer.Deserialize<CacheFileHeaderHaloReachAlpha>(dataContext),
                    CacheVersion.HaloReachPreBeta => deserializer.Deserialize<CacheFileHeaderHaloReachPreBeta>(dataContext),
                    CacheVersion.HaloReachBeta => deserializer.Deserialize<CacheFileHeaderHaloReachBeta>(dataContext),
                    CacheVersion.HaloReach => deserializer.Deserialize<CacheFileHeaderHaloReach>(dataContext),
                    CacheVersion.HaloOnlineED => deserializer.Deserialize<CacheFileHeaderHaloOnlineED>(dataContext),
                    CacheVersion.HaloOnline106708 => deserializer.Deserialize<CacheFileHeaderHaloOnline106708>(dataContext),
                    CacheVersion.HaloOnline155080 => deserializer.Deserialize<CacheFileHeaderHaloOnline155080>(dataContext),
                    CacheVersion.HaloOnline235640 => deserializer.Deserialize<CacheFileHeaderHaloOnline235640>(dataContext),
                    CacheVersion.HaloOnline301003 => deserializer.Deserialize<CacheFileHeaderHaloOnline301003>(dataContext),
                    CacheVersion.HaloOnline327043 => deserializer.Deserialize<CacheFileHeaderHaloOnline327043>(dataContext),
                    CacheVersion.HaloOnline372731 => deserializer.Deserialize<CacheFileHeaderHaloOnline372731>(dataContext),
                    CacheVersion.HaloOnline416097 => deserializer.Deserialize<CacheFileHeaderHaloOnline416097>(dataContext),
                    CacheVersion.HaloOnline430475 => deserializer.Deserialize<CacheFileHeaderHaloOnline430475>(dataContext),
                    CacheVersion.HaloOnline454665 => deserializer.Deserialize<CacheFileHeaderHaloOnline454665>(dataContext),
                    CacheVersion.HaloOnline449175 => deserializer.Deserialize<CacheFileHeaderHaloOnline449175>(dataContext),
                    CacheVersion.HaloOnline498295 => deserializer.Deserialize<CacheFileHeaderHaloOnline498295>(dataContext),
                    CacheVersion.HaloOnline530605 => deserializer.Deserialize<CacheFileHeaderHaloOnline530605>(dataContext),
                    CacheVersion.HaloOnline532911 => deserializer.Deserialize<CacheFileHeaderHaloOnline532911>(dataContext),
                    CacheVersion.HaloOnline554482 => deserializer.Deserialize<CacheFileHeaderHaloOnline554482>(dataContext),
                    CacheVersion.HaloOnline571627 => deserializer.Deserialize<CacheFileHeaderHaloOnline571627>(dataContext),
                    CacheVersion.HaloOnline604673 => deserializer.Deserialize<CacheFileHeaderHaloOnline604673>(dataContext),
                    CacheVersion.HaloOnline700123 => deserializer.Deserialize<CacheFileHeaderHaloOnline700123>(dataContext),
                    CacheVersion.Halo4E3 => deserializer.Deserialize<CacheFileHeaderHalo4E3>(dataContext),
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
                    CacheVersion.H2AMP => typeof(CacheFileHeaderHalo2AMPMCC),
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
                    CacheVersion.Halo3PreAlpha => typeof(CacheFileHeaderHalo3PreAlpha),
                    CacheVersion.Halo3Alpha => typeof(CacheFileHeaderHalo3Alpha),
                    CacheVersion.Halo3Beta => typeof(CacheFileHeaderHalo3Beta),
                    CacheVersion.Halo3March7Delta => typeof(CacheFileHeaderHalo3March7Delta),
                    CacheVersion.Halo3March8Delta => typeof(CacheFileHeaderHalo3March8Delta),
                    CacheVersion.Halo3March9Delta => typeof(CacheFileHeaderHalo3March9Delta),
                    CacheVersion.Halo3Epsilon => typeof(CacheFileHeaderHalo3Epsilon),
                    CacheVersion.Halo3DLC => typeof(CacheFileHeaderHalo3DLC),
                    CacheVersion.Halo3Retail => typeof(CacheFileHeaderHalo3),
                    CacheVersion.Halo3ODST => typeof(CacheFileHeaderHalo3ODST),
                    CacheVersion.HaloReachAlpha => typeof(CacheFileHeaderHaloReachAlpha),
                    CacheVersion.HaloReachPreBeta => typeof(CacheFileHeaderHaloReachPreBeta),
                    CacheVersion.HaloReachBeta => typeof(CacheFileHeaderHaloReachBeta),
                    CacheVersion.HaloReach => typeof(CacheFileHeaderHaloReach),
                    CacheVersion.HaloOnlineED => typeof(CacheFileHeaderHaloOnlineED),
                    CacheVersion.HaloOnline106708 => typeof(CacheFileHeaderHaloOnline106708),
                    CacheVersion.HaloOnline155080 => typeof(CacheFileHeaderHaloOnline155080),
                    CacheVersion.HaloOnline235640 => typeof(CacheFileHeaderHaloOnline235640),
                    CacheVersion.HaloOnline301003 => typeof(CacheFileHeaderHaloOnline301003),
                    CacheVersion.HaloOnline327043 => typeof(CacheFileHeaderHaloOnline327043),
                    CacheVersion.HaloOnline372731 => typeof(CacheFileHeaderHaloOnline372731),
                    CacheVersion.HaloOnline416097 => typeof(CacheFileHeaderHaloOnline416097),
                    CacheVersion.HaloOnline430475 => typeof(CacheFileHeaderHaloOnline430475),
                    CacheVersion.HaloOnline454665 => typeof(CacheFileHeaderHaloOnline454665),
                    CacheVersion.HaloOnline449175 => typeof(CacheFileHeaderHaloOnline449175),
                    CacheVersion.HaloOnline498295 => typeof(CacheFileHeaderHaloOnline498295),
                    CacheVersion.HaloOnline530605 => typeof(CacheFileHeaderHaloOnline530605),
                    CacheVersion.HaloOnline532911 => typeof(CacheFileHeaderHaloOnline532911),
                    CacheVersion.HaloOnline554482 => typeof(CacheFileHeaderHaloOnline554482),
                    CacheVersion.HaloOnline571627 => typeof(CacheFileHeaderHaloOnline571627),
                    CacheVersion.HaloOnline604673 => typeof(CacheFileHeaderHaloOnline604673),
                    CacheVersion.HaloOnline700123 => typeof(CacheFileHeaderHaloOnline700123),
                    CacheVersion.Halo4E3 => typeof(CacheFileHeaderHalo4E3),
                    CacheVersion.Halo4 => typeof(CacheFileHeaderHalo4),
                    _ => null,
                };
            }
        }

        public abstract Tag GetHeaderSignature();
        public abstract Tag GetFooterSignature();
        public abstract ulong GetTagsHeaderWhenLoaded();
        public abstract ulong GetExpectedBaseAddress();
        public abstract uint GetSize();
        public abstract string GetName();
        public abstract string GetBuildNumber();
        public abstract string GetTagPath();
        public abstract int GetMapId();
        public abstract int GetScenarioIndex();
        public abstract ScenarioType GetScenarioType();
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

        public abstract bool GetCompression();
        public abstract int GetCompressedDataChunkSize();
        public abstract int GetCompressedDataOffset();
        public abstract int GetCompressedChunkTableOffset();
        public abstract int GetCompressedChunkCount();

        public abstract CacheFileSectionTable GetSectionTable();
        public abstract CacheFileSectionFileBounds GetReports();
        
        // TODO: Figure out a better way of handling this
        public virtual void SetScenarioIndex(int index) { return; }
        public virtual void SetScenarioType(ScenarioType scenarioType) { return; }
    }
}
