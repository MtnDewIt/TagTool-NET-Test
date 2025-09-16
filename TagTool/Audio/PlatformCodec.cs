using TagTool.Cache;
using TagTool.Tags;


namespace TagTool.Audio
{
    [TagStructure(Size = 0x4, Gen = CacheGeneration.Eldorado)]
    [TagStructure(Size = 0x4, Gen = CacheGeneration.Third, BuildType = CacheBuildType.TagsBuild)]
    [TagStructure(Size = 0x3, Gen = CacheGeneration.Third, BuildType = CacheBuildType.ReleaseBuild)]
    public class PlatformCodec : TagStructure
	{
        [TagField(Gen = CacheGeneration.Eldorado)]
        public byte Unknown1;

        /// <summary>
        /// Should be 0 in most cases. Seems to be used to determine streaming or loading.
        /// </summary>
        [TagField(Gen = CacheGeneration.Eldorado)]
        public byte LoadMode;

        [TagField(Gen = CacheGeneration.Third, BuildType = CacheBuildType.ReleaseBuild)]
        public SampleRate SampleRate;

        public EncodingValue Encoding;

        public Compression Compression;

        [TagField(Length = 2, Flags = TagFieldFlags.Padding, Gen = CacheGeneration.Third, BuildType = CacheBuildType.TagsBuild)]
        public byte[] Padding1;
    }
}