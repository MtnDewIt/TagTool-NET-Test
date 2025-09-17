using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TagTool.Audio.Converter;
using TagTool.IO;

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
                Quality = AudioQuality.Default
            };

            public required AudioQuality Quality { get; init; }
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
            { AudioQuality.Default, 7 }, // ~224 kbps
            { AudioQuality.Best,    7 }, // ~224 kbps
            { AudioQuality.Average, 4 }, // ~128 kbps
            { AudioQuality.Low,     2 }  // ~96 kbps
        };

        public static BlamSound Convert(BlamSound blamSound, Compression targetFormat, ConverterOptions options = null)
        {
            options ??= ConverterOptions.Default;

            if (blamSound.Compression == targetFormat)
                return blamSound;

            string tempDir = Path.Combine(DirectoryPaths.Base, "temp");

            // Ensure the temp directory exists
            Directory.CreateDirectory(tempDir);

            // We use a guid for the filename as this may be called concurrently
            string guid = Guid.NewGuid().ToString();
            string inFilePath = Path.Combine(tempDir, $"{guid}.{AudioUtils.GetFormatFileExtension(blamSound.Compression)}");
            string outFilePath = Path.Combine(tempDir, $"{guid}.{AudioUtils.GetFormatFileExtension(targetFormat)}");

            try
            {
                // Write input file
                WriteToFile(inFilePath, blamSound);

                // Build the ffmpeg arguments
                string args = BuildFFmpegArguments(blamSound, targetFormat, inFilePath, outFilePath, options);

                // Run ffmpeg
                int exitCode = RunTool(Path.Combine(DirectoryPaths.Tools, "ffmpeg.exe"), args);
                if (exitCode != 0)
                    return null;

                // Read the output file
                byte[] data = File.ReadAllBytes(outFilePath);
                blamSound.UpdateFormat(targetFormat, data);

                return blamSound;
            }
            finally
            {
                // Delete the intermediate files
                try { if (File.Exists(inFilePath)) File.Delete(inFilePath); } catch { }
                try { if (File.Exists(outFilePath)) File.Delete(outFilePath); } catch { }
            }
        }

        static string BuildFFmpegArguments(BlamSound blamSound, Compression targetFormat, string inFilePath, string outFilePath, ConverterOptions options)
        {
            string args = $"-y";

            if (blamSound.Compression == Compression.PCM)
                args += $" -f s16le -ar {blamSound.SampleRate} -ac {blamSound.ChannelCount}";

            args += $" -i \"{inFilePath}\"";

            switch (targetFormat)
            {
                case Compression.PCM:
                    args += $" -f s16le -c:a pcm_s16le -ar {blamSound.SampleRate} -ac {blamSound.ChannelCount}";
                    break;
                case Compression.MP3:
                    args += $" -f mp3 -c:a libmp3lame -q:a {Mp3QualityMap[options.Quality]}";
                    break;
                case Compression.OGG:
                    args += $" -f ogg -c:a libvorbis -q:a {VorbisQualityMap[options.Quality]}";
                    break;
            }

            args += $" \"{outFilePath}\"";

            return args;
        }

        static void WriteToFile(string filePath, BlamSound blamSound)
        {
            switch (blamSound.Compression)
            {
                case Compression.XMA:
                    {
                        var xmaFile = new XMAFile(blamSound);
                        using var writer = new EndianWriter(File.Create(filePath));
                        xmaFile.Write(writer);
                    }
                    break;
                case Compression.IMAADPCM:
                    {
                        var adpcmFile = new IMAADPCM(blamSound);
                        using var writer = new EndianWriter(File.Create(filePath));
                        adpcmFile.Write(writer);
                    }
                    break;
                case Compression.XboxADPCM:
                    {
                        var adpcmFile = new XboxADPCM(blamSound);
                        using var writer = new EndianWriter(File.Create(filePath));
                        adpcmFile.Write(writer);
                    }
                    break;
                default:
                    {
                        File.WriteAllBytes(filePath, blamSound.Data);
                        break;
                    }
            }
        }

        static int RunTool(string filePath, string args)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = filePath,
                    Arguments = args,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                }
            };

            process.Start();
            process.WaitForExit();

            string output = process.StandardError.ReadToEnd();
            return process.ExitCode;
        }
    }
}
