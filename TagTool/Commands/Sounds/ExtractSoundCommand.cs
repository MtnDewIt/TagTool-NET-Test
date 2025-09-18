using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Audio;
using TagTool.Audio.Utils;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Commands.Porting;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Sounds
{
    public class ExtractSoundCommand : Command
    {
        private GameCache Cache { get; }
        private CachedTag Tag { get; }
        private Sound Definition { get; }
        private SoundCacheFileGestalt BlamSoundGestalt { get; set; } = null;

        public ExtractSoundCommand(GameCache cache, CachedTag tag, Sound definition) :
            base(true,

                name:
                "ExtractSound",
                
                description:
                "Extract snd! data to a file",
                
                usage:
                "ExtractSound [format] [quality: {default,best,average,low}] <Path>",
                
                examples:
                "extractsound\n" +
                "extractsound d:\\sound\n"+
                "extractsound mp3 d:\\sound\\\n" +
                "extractsound mp3 quality: low d:\\sound\\",
                helpMessage:
                "- Valid formats: " + string.Join(", ", Enum.GetNames(typeof(Compression))) + "\n" +
                "- [format] is optional\n" +
                "- [quality] is optional\n" +
                "- <Path> if not specified, files with be ripped to CURRENT_WORKING_DIRECTORY\\Sound")
        {
            Cache = cache;
            Tag = tag;
            Definition = definition;
        }

        public override object Execute(List<string> args)
        {
            string outDirectory = "";

            Compression? targetFormat = null;
            AudioQuality quality = AudioQuality.Default;

            if (args.Count > 0)
            {
                // TODO: move away from using 'Compression' in tooling
                if (Enum.TryParse(args[0], true, out Compression format))
                {
                    targetFormat = format;
                    args.RemoveAt(0);
                }
                else if (string.Equals(args[0], "wav", StringComparison.OrdinalIgnoreCase))
                {
                    targetFormat = Compression.Tagtool_WAV;
                    args.RemoveAt(0);
                }
            }

            if (args.Count > 0)
            {
                switch (args[0].ToLower())
                {
                    case "quality:":
                        if (Enum.TryParse(args[1], true, out quality))
                            args.RemoveRange(0, 2);
                        else
                            return new TagToolError(CommandError.ArgInvalid, $"Invalid quality level. Expected one of {{default,best,average,low}}");
                        break;
                }
            }

            if (args.Count == 1)
                outDirectory = args[0];
            else if (args.Count == 0)
                outDirectory = "Sounds";
            else
                return new TagToolError(CommandError.ArgCount);

            bool createDir = !Directory.Exists(outDirectory);
            if (createDir && args.Count > 0)
            {
                if (args.Count == 0)
                    Directory.CreateDirectory(outDirectory);

                Console.Write("Destination directory does not exist. Create it? [y/n] ");
                var answer = Console.ReadLine().ToLower();

                if (answer.Length == 0 || !(answer.StartsWith("y") || answer.StartsWith("n")))
                    return new TagToolError(CommandError.YesNoSyntax);

                if (!answer.StartsWith("y"))
                {
                    Console.WriteLine("Aborted.");
                    return true;
                }
            }

            if(createDir)
                Directory.CreateDirectory(outDirectory);

            var converterOptions = AudioConverter.ConverterOptions.Default with { Quality = quality };

            switch (CacheVersionDetection.GetGeneration(Cache.Version))
            {
                case CacheGeneration.Third:
                    ExportGen3Sound(outDirectory, targetFormat, converterOptions);
                    break;
                case CacheGeneration.Eldorado:
                    ExportEldoradoSound(outDirectory, targetFormat, converterOptions);
                    break;
                default:
                    throw new NotSupportedException("Cache not supported");
            }

            Console.WriteLine("Done!");
            return true;
        }

        private void ExportGen3Sound(string outDirectory, Compression? targetFormat, AudioConverter.ConverterOptions converterOptions)
        {
            if (CacheVersionDetection.GetCacheBuildType(Cache.Version) == CacheBuildType.TagsBuild)
            {
                for (int pitchRangeIndex = 0; pitchRangeIndex < Definition.PitchRanges.Count; pitchRangeIndex++)
                {
                    PitchRange range = Definition.PitchRanges[pitchRangeIndex];

                    for (int permutationIndex = 0; permutationIndex < range.Permutations.Count; permutationIndex++)
                    {
                        BlamSound blamSound = SoundExtractorGen3.ExtractSound((GameCacheGen3)Cache, null, Definition, pitchRangeIndex, permutationIndex);
                        if(targetFormat != null)
                            blamSound = AudioConverter.Convert(blamSound, targetFormat.Value);

                        ExportPermutationToFile(outDirectory, pitchRangeIndex, permutationIndex, blamSound);
                    }
                }
            }
            else
            {
                if (BlamSoundGestalt == null)
                {
                    using var stream = Cache.OpenCacheRead();
                    BlamSoundGestalt = PortingContextFactory.LoadSoundGestalt(Cache, stream);
                }

                for (int pitchRangeIndex = Definition.SoundReference.PitchRangeIndex; pitchRangeIndex < Definition.SoundReference.PitchRangeIndex + Definition.SoundReference.PitchRangeCount; pitchRangeIndex++)
                {
                    int relativePitchRangeIndex = pitchRangeIndex - Definition.SoundReference.PitchRangeIndex;
                    int permutationCount = BlamSoundGestalt.GetPermutationCount(pitchRangeIndex, Cache.Platform);

                    for (int i = 0; i < permutationCount; i++)
                    {
                        BlamSound blamSound = SoundExtractorGen3.ExtractSound((GameCacheGen3)Cache, BlamSoundGestalt, Definition, relativePitchRangeIndex, i);
                        if(targetFormat != null)
                            blamSound = AudioConverter.Convert(blamSound, targetFormat.Value, converterOptions);

                        ExportPermutationToFile(outDirectory, relativePitchRangeIndex, i, blamSound);
                    }
                }
            }
        }

        private void ExportEldoradoSound(string outDirectory, Compression? targetFormat, AudioConverter.ConverterOptions converterOptions)
        {
            for (int pitchRangeIndex = 0; pitchRangeIndex < Definition.PitchRanges.Count; pitchRangeIndex++)
            {
                PitchRange range = Definition.PitchRanges[pitchRangeIndex];

                for (int permutationIndex = 0; permutationIndex < range.Permutations.Count; permutationIndex++)
                {
                    BlamSound blamSound = SoundExtractorEldorado.ExtractSound((GameCacheEldoradoBase)Cache, Definition, pitchRangeIndex, permutationIndex);
                    if (targetFormat != null)
                        blamSound = AudioConverter.Convert(blamSound, targetFormat.Value, converterOptions);

                    ExportPermutationToFile(outDirectory, pitchRangeIndex, permutationIndex, blamSound);
                }
            }
        }

        private void ExportPermutationToFile(string outDirectory, int pitchRangeIndex, int i, BlamSound blamSound)
        {
            var filename = GetExportFileName(blamSound.Compression, pitchRangeIndex, i);
            var outPath = Path.Combine(outDirectory, filename);
            File.WriteAllBytes(outPath, blamSound.Data);
            Console.WriteLine($"{filename}: pitch range {pitchRangeIndex}, permutation {i} sample count: {blamSound.SampleCount}");
        }

        private string GetExportFileName(Compression targetFormat, int pitchRangeIndex, int permutationIndex)
        {
            string extension = AudioUtils.GetFormatFileExtension(targetFormat);
            return $"{Tag.Name.Replace('\\', '~')}%{pitchRangeIndex}_{permutationIndex}.{extension}";
        }
    }
}
