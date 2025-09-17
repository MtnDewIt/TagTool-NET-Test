using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Audio;
using TagTool.Audio.Utils;
using TagTool.Cache;
using TagTool.Cache.Gen2;
using TagTool.Commands.Common;
using TagTool.Commands.Sounds;
using TagTool.Common;
using TagTool.Common.Logging;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using Gen2LoopingSound = TagTool.Tags.Definitions.Gen2.SoundLooping;
using Gen2Sound = TagTool.Tags.Definitions.Gen2.Sound;
using Gen2SoundCacheFileGestalt = TagTool.Tags.Definitions.Gen2.SoundCacheFileGestalt;
using Gen2SoundEnvironment = TagTool.Tags.Definitions.Gen2.SoundEnvironment;

namespace TagTool.Porting.Gen2
{
    partial class PortingContextGen2
    {
        private Gen2SoundCacheFileGestalt SoundGestalt { get; set; } = null;
        private Gen2SoundCacheFileGestalt SharedSoundGestalt { get; set; } = null;

        private void LoadGen2SoundGestalt(GameCache cache, Stream stream)
        {
            if(SoundGestalt == null)
            {
                CachedTag blamTag = cache.TagCache.FindFirstInGroup("ugh!");
                if (blamTag != null)
                    SoundGestalt = cache.Deserialize<Gen2SoundCacheFileGestalt>(stream, blamTag);
            }
            
            if(cache.Version == CacheVersion.Halo2PC && (cache as GameCacheGen2).VistaSharedTagCache != null && SharedSoundGestalt == null)
            {
                CachedTag blamTag = (cache as GameCacheGen2).VistaSharedTagCache.TagCache.FindFirstInGroup("ugh!");
                if (blamTag != null)
                    SharedSoundGestalt = cache.Deserialize<Gen2SoundCacheFileGestalt>(stream, blamTag);
            }

        }
        public SoundEnvironment ConvertSoundEnvironment(Gen2SoundEnvironment gen2envi)
        {
            SoundEnvironment newEnvi = new SoundEnvironment();
            AutoConverter.TranslateTagStructure(gen2envi, newEnvi);
            return newEnvi;
        }

        public SoundLooping ConvertLoopingSound(CachedTagGen2 gen2Tag, Gen2LoopingSound gen2loop, Stream cacheStream)
        {
            SoundLooping newLoop = new SoundLooping();
            AutoConverter.TranslateTagStructure(gen2loop, newLoop);
            CachedTag sound = null;
            if (newLoop.Tracks.Count > 0)
            {
                 sound = newLoop.Tracks[0].Loop;
            }
            else if(newLoop.DetailSounds.Count > 0)
            {
                sound = newLoop.DetailSounds[0].Sound;
            }

            if(sound != null)
            {
                Sound soundDef = CacheContext.Deserialize<Sound>(cacheStream, sound);
                newLoop.SoundClass = (SoundLooping.SoundClassValue)soundDef.SoundClass.HaloOnline;
            }
            else
            {
                Log.Error($"Looping sound {gen2Tag.Name} unable to determine sound class from child sound! Returning null!");
                return null;
            }
            
            return newLoop;
        }

        public Sound ConvertSound(CachedTagGen2 gen2Tag, Gen2Sound gen2Sound, Stream gen2Stream, string gen2Name)
        {
            Sound sound = new Sound();

            LoadGen2SoundGestalt(BlamCache, gen2Stream);
            Gen2SoundCacheFileGestalt ugh;

            if (BlamCache.Version == CacheVersion.Halo2PC && gen2Tag.IsShared)
                ugh = SharedSoundGestalt;
            else
                ugh = SoundGestalt;

            var targetFormat = Compression.MP3;
            var originalSampleRate = gen2Sound.SampleRate.GetSampleRateHz();
            var originalCompression = gen2Sound.Compression;
            var originalChannelCount = Encoding.GetChannelCount(gen2Sound.Encoding);

            Scale scale = ugh.Scales[gen2Sound.ScaleIndex];
            Promotion promotion = gen2Sound.PromotionIndex != -1 ? ugh.Promotions[gen2Sound.PromotionIndex] : new Promotion();
            List<CustomPlayback> customPlayback = gen2Sound.CustomPlaybackIndex != -1 ? new List<CustomPlayback> { ugh.CustomPlaybacks[gen2Sound.CustomPlaybackIndex] } : new List<CustomPlayback>();

            ExtraInfo extraInfo = gen2Sound.ExtraInfoIndex != -1 ? ugh.ExtraInfos[gen2Sound.ExtraInfoIndex] : null;
            PlaybackParameter playbackParameters = (ugh.Playbacks[gen2Sound.PlaybackParamaterIndex]).DeepClone();

            //
            // convert playbackParameters to gen3 format
            //

            playbackParameters.DistanceParameters = new SoundDistanceParameters();
            if (playbackParameters.MininumDistance != 0)
            {
                playbackParameters.DistanceParameters.MinimumDistance = playbackParameters.MininumDistance;
                playbackParameters.FieldDisableFlags |= PlaybackParameter.FieldDisableFlagsValue.DistanceA;
            }

            if (playbackParameters.MaximumDistance != 0)
            {
                playbackParameters.DistanceParameters.MaximumDistance = playbackParameters.MaximumDistance;
                playbackParameters.FieldDisableFlags |= PlaybackParameter.FieldDisableFlagsValue.DistanceB;
            }

            sound.Playback = playbackParameters;

            //
            // Initialize other blocks
            //

            sound.Scale = scale;
            sound.Promotion = promotion;
            sound.CustomPlaybacks = customPlayback;

            //
            // Gen3 / HO specifics
            //

            sound.ImportType = ImportType.SingleLayer;
            sound.Unknown12 = 0;
            sound.Promotion.LongestPermutationDuration = (uint)gen2Sound.MaximumPlayTime;

            //
            // convert sound flags
            //

            if (gen2Sound.Flags.HasFlag(Gen2Sound.Gen2SoundFlags.AlwaysSpatialize))
                sound.Flags |= Sound.FlagsValue.AlwaysSpatialize;

            if (gen2Sound.Flags.HasFlag(Gen2Sound.Gen2SoundFlags.NeverObstruct))
                sound.Flags |= Sound.FlagsValue.NeverObstruct;

            if (gen2Sound.Flags.HasFlag(Gen2Sound.Gen2SoundFlags.LinkCountToOwnerUnit))
                sound.Flags |= Sound.FlagsValue.LinkCountToOwnerUnit ;

            if (gen2Sound.Flags.HasFlag(Gen2Sound.Gen2SoundFlags.PitchRangeIsLanguage))
                sound.Flags |= Sound.FlagsValue.PitchRangeIsLanguage;

            if (gen2Sound.Flags.HasFlag(Gen2Sound.Gen2SoundFlags.DonTUseSoundClassSpeakerFlag))
                sound.Flags |= Sound.FlagsValue.DontUseSoundClassSpeakerFlag;

            if (gen2Sound.Flags.HasFlag(Gen2Sound.Gen2SoundFlags.DonTUseLipsyncData))
                sound.Flags |= Sound.FlagsValue.DontUseLipsyncData;

            //
            // Convert tags and strings from ugh references (ugh is not ported)
            //

            // TODO customplayback, etc

            //
            // convert audio data
            //

            var soundDataAggregate = new byte[0].AsEnumerable();

            sound.PitchRanges = new List<PitchRange>(gen2Sound.PitchRangeCount);

            uint totalSampleCount = 0;
            int currentSoundDataOffset = 0;

            for (int pitchRangeIndex = gen2Sound.PitchRangeIndex; pitchRangeIndex < gen2Sound.PitchRangeIndex + gen2Sound.PitchRangeCount; pitchRangeIndex++)
            {
                totalSampleCount += ugh.GetSamplesPerPitchRange(pitchRangeIndex);

                //
                // Convert Blam pitch range to ElDorado format
                //

                var gen2PitchRange = ugh.PitchRanges[pitchRangeIndex];
                PitchRange pitchRange = new PitchRange();


                pitchRange.ImportName = ConvertStringId(ugh.ImportNames[gen2PitchRange.Name].Name);
                pitchRange.PitchRangeParameters = ugh.PitchRangeParameters[gen2PitchRange.Parameters];
                pitchRange.RuntimePermutationFlags = -1;
                pitchRange.RuntimeDiscardedPermutationIndex = -1;
                pitchRange.PermutationCount = (byte)ugh.GetPermutationCount(pitchRangeIndex);
                pitchRange.RuntimeLastPermutationIndex = -1;

                // Add pitch range to ED sound
                sound.PitchRanges.Add(pitchRange);
                var newPitchRangeIndex = pitchRangeIndex - gen2Sound.PitchRangeIndex;
                sound.PitchRanges[newPitchRangeIndex].Permutations = new List<Permutation>();

                //
                // Convert Blam permutations to ElDorado format
                //

                var useCache = Options.AudioCache != null || UseAudioCacheCommand.AudioCacheDirectory != null;
                var soundCachePath = Options.AudioCache ?? UseAudioCacheCommand.AudioCacheDirectory?.FullName ?? "";

                var permutationCount = ugh.GetPermutationCount(pitchRangeIndex);
                var relativePitchRangeIndex = pitchRangeIndex - gen2Sound.PitchRangeIndex;

                for (int i = 0; i < permutationCount; i++)
                {
                    var permutationIndex = pitchRange.FirstPermutationIndex + i;

                    var gen2Permutation = ugh.GetPermutation(permutationIndex);
                    var permutation = new Permutation();

                    permutation.ImportName = ConvertStringId(ugh.ImportNames[gen2Permutation.Name].Name);
                    permutation.SkipFraction = gen2Permutation.EncodedSkipFraction / 32767.0f;
                    permutation.Gain = gen2Permutation.EncodedGain * 127.0f;  // need proper sbyte decoding
                    permutation.PermutationChunks = new List<PermutationChunk>();
                    permutation.PermutationNumber = (uint)i;
                    permutation.IsNotFirstPermutation = (uint)(i == 0 ? 0 : 1);

                    BlamSound blamSound = SoundExtractorGen2.ExtractSound((GameCacheGen2)BlamCache, ugh, gen2Sound, relativePitchRangeIndex, i);
                    blamSound = AudioConverter.Convert(blamSound, targetFormat);

                    permutation.SampleCount = blamSound.SampleCount;

                    byte[] permutationData = blamSound.Data;
                    if (targetFormat == Compression.PCM)
                    {
                        // FMOD requires that we add 16 bytes of padding on either side
                        permutationData = AudioUtils.Pad(permutationData, 16);
                    }

                    var newChunk = new PermutationChunk(currentSoundDataOffset, permutationData.Length, 0, 0);
                    permutation.PermutationChunks.Add(newChunk);
                    currentSoundDataOffset += permutationData.Length;
                    pitchRange.Permutations.Add(permutation);

                    soundDataAggregate = soundDataAggregate.Concat(permutationData);
                }
            }

            sound.Promotion.TotalSampleSize = totalSampleCount;


            //
            // create resource
            //

            var data = soundDataAggregate.ToArray();
            var resourceDefinition = AudioUtils.CreateSoundResourceDefinition(data);
            var resourceReference = CacheContext.ResourceCache.CreateSoundResource(resourceDefinition);
            sound.Resource = resourceReference;

            //
            // generate platform codec struct
            //

            // assume all sounds get converted to mp3, 44100 Hz
            sound.PlatformCodec = new PlatformCodec
            {
                Unknown1 = 0,
                LoadMode = 0,
                Compression = targetFormat,
                Encoding = originalChannelCount == 2 ? EncodingValue.Stereo : EncodingValue.Mono,
                SampleRate = new SampleRate { value = SampleRate.SampleRateValue._44khz },
            };

            //
            // Convert ExtraInfo block
            //

            sound.ExtraInfo = new List<ExtraInfo> { extraInfo };


            return sound;
        }
    }
}
