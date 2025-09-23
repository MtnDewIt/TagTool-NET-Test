using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using TagTool.Audio.Converter;
using TagTool.IO;
using static TagTool.Audio.Utils.AudioLib;

namespace TagTool.Audio.Utils
{
    public enum AudioQuality
    {
        Default,
        Best,
        Average,
        Low
    }

    public class AudioConverter
    {
        public record ConverterOptions
        {
            public static readonly ConverterOptions Default = new()
            {
                Quality = AudioQuality.Default,

            };

            public required AudioQuality Quality { get; init; }

            public bool UseTranscoderSampleCount { get; init; } = false;
        }

        static readonly Dictionary<AudioQuality, int> Mp3QualityMap = new()
        {
            { AudioQuality.Default, 0 }, // ~245–320 kbps
            { AudioQuality.Best,    0 }, // ~245–320 kbps
            { AudioQuality.Average, 4 }, // ~160 kbps
            { AudioQuality.Low,     6 }  // ~115 kbps
        };

        static readonly Dictionary<AudioQuality, int> VorbisQualityMap = new()
        {
            { AudioQuality.Default, 3 }, // ~224 kbps
            { AudioQuality.Best,    3 }, // ~224 kbps
            { AudioQuality.Average, 6 }, // ~128 kbps
            { AudioQuality.Low,     8 }  // ~96 kbps
        };

        public static BlamSound Convert(BlamSound blamSound, Compression targetFormat, ConverterOptions options = null)
        {
            options ??= ConverterOptions.Default;

            byte[] data = PrepareInput(blamSound);

            GCHandle dataHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            nint dataPtr = dataHandle.AddrOfPinnedObject();

            nint input_stream = al_stream_new_from_buffer(dataPtr, data.Length);
            nint output_stream = al_stream_new(0);

            try
            {
                var transcodeParams = new ALTranscodeParams();
                GetTranscodeParams(ref transcodeParams, blamSound, targetFormat, options);

                var transcodeInfo = new ALTranscodeInfo();
                int ret = al_transcode(input_stream, output_stream, ref transcodeParams, ref transcodeInfo);
                if (ret != 0)
                    return null;

                int size = al_stream_get_size(output_stream);
                nint ptr = al_stream_get_buffer(output_stream);

                byte[] result = new byte[size];
                Marshal.Copy(ptr, result, 0, size);

                uint newSampleCount = blamSound.SampleCount;
                if (newSampleCount == 0 || options.UseTranscoderSampleCount)
                {
                    newSampleCount = (uint)transcodeInfo.sample_count;
                }

                return new BlamSound(blamSound.SampleRate, blamSound.ChannelCount, newSampleCount, targetFormat, result);
            }
            finally
            {
                al_stream_delete(output_stream);
                al_stream_delete(input_stream);
                dataHandle.Free();
            }
        }

        private static ALTranscodeParams GetTranscodeParams(ref ALTranscodeParams transcodeParams, BlamSound blamSound, Compression targetFormat, ConverterOptions options)
        {
            transcodeParams.output_format = GetFormatShortName(targetFormat);
            transcodeParams.output_codec = GetOutputCodecName(targetFormat);
            transcodeParams.input_format = GetFormatShortName(blamSound.Compression);
            transcodeParams.input_codec = GetInputCodecName(blamSound.Compression);
            transcodeParams.quality = -1; // default

            switch (targetFormat)
            {
                case Compression.OGG:
                    transcodeParams.quality = VorbisQualityMap[options.Quality];
                    break;
                case Compression.MP3:
                    transcodeParams.quality = Mp3QualityMap[options.Quality];
                    break;
            }

            if (blamSound.Compression == Compression.PCM || blamSound.Compression == Compression.PCM_BigEndian)
            {
                transcodeParams.input_channels = blamSound.ChannelCount;
                transcodeParams.input_sample_rate = blamSound.SampleRate;
            }

            return transcodeParams;
        }

        private static string GetOutputCodecName(Compression format)
        {
            switch (format)
            {
                case Compression.OGG:
                    return "libvorbis";
                case Compression.PCM:
                case Compression.Tagtool_WAV:
                    return "pcm_s16le";
                case Compression.PCM_BigEndian:
                    return "pcm_s16be";
                case Compression.MP3:
                    return "libmp3lame";
                case Compression.XMA:
                    return "xma1";
                default:
                    return "";
            }
        }

        private static string GetInputCodecName(Compression format)
        {
            switch (format)
            {
                case Compression.OGG:
                    return "libvorbis";
                case Compression.PCM:
                case Compression.Tagtool_WAV:
                    return "pcm_s16le";
                case Compression.PCM_BigEndian:
                    return "pcm_s16be";
                case Compression.MP3:
                    return "mp3";
                default:
                    return "";
            }
        }

        private static string GetFormatShortName(Compression format)
        {
            switch (format)
            {
                case Compression.OGG:
                    return "ogg";
                case Compression.PCM:
                    return "s16le";
                case Compression.PCM_BigEndian:
                    return "s16be";
                case Compression.MP3:
                    return "mp3";
                case Compression.Tagtool_WAV:
                    return "wav";
                default:
                    return "";
            }
        }

        private static byte[] PrepareInput(BlamSound blamSound)
        {
            if (blamSound.Compression == Compression.XMA)
            {
                var wavFile = new XMAFile(blamSound);
                var ms = new MemoryStream();
                using var writer = new EndianWriter(ms);
                wavFile.Write(writer);
                blamSound.Data = ms.ToArray();
            }

            else if (blamSound.Compression == Compression.PCM)
            {
                var wavFile = new WAVFile(blamSound);
                var ms = new MemoryStream();
                using var writer = new EndianWriter(ms);
                wavFile.Write(writer);
                blamSound.Data = ms.ToArray();
            }
            else if (blamSound.Compression == Compression.XboxADPCM)
            {
                var wavFile = new XboxADPCM(blamSound);
                var ms = new MemoryStream();
                using var writer = new EndianWriter(ms);
                wavFile.Write(writer);
                blamSound.Data = ms.ToArray();
            }

            return blamSound.Data;
        }
    }
}
