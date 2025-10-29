﻿using TagTool.Cache;
using TagTool.Common;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TagTool.Audio;
using System.Linq;
using TagTool.Audio.Converter;
using TagTool.IO;
using TagTool.Common.Logging;

namespace TagTool.Commands.Sounds
{
    public class ImportSoundCommand : Command
    {
        private GameCache Cache { get; }
        private CachedTag Tag { get; }
        private Sound Definition { get; }

        public ImportSoundCommand(GameCache cache, CachedTag tag, Sound definition) :
            base(true,

                "ImportSound",
                "Import one (or many) sound files into the current snd! tag. Overwrites existing sound data. See documentation for formatting and options.",

                "ImportSound [raw] <path>",
                "Import one or more audio files into the current snd! tag. Overwrites existing sound data.\n" +
                "If <path> is a directory, each valid audio file inside will be imported as a permutation.\n"+
                "Use raw to import a new sound resource without touching tag data. See documentation for formatting and options.")
        {
            Cache = cache;
            Tag = tag;
            Definition = definition;
        }

        int pitchRangeCount = 1;
        int permutationCount = 1;
        int argCount;
        string path;
        string[] supportedTypes = { ".mp3", ".fsb", ".wav" };

        public override object Execute(List<string> args)
        {
            argCount = args.Count;

            switch (argCount)
            {
                case 0:{
                    // old implementation (still supported)
                    pitchRangeCount = GetPitchRangeCountUser();
                    Definition.SampleRate.value = GetSoundSampleRateUser();
                    Definition.PlatformCodec.Compression = GetSoundCompressionUser();
                    Definition.PlatformCodec.Encoding = GetSoundEncodingUser();

                    ImportCustom();
                    return true;
                }
                case 1:{
                    path = args[0].Trim('"');
                    ImportCustom();
                    Definition.Playback.GainBase = 0;
                    return true;
                }
                case 2:{
                    if (args[0].ToLower() == "raw")
                        ImportSoundResource(File.ReadAllBytes(args[1]));
                    else
                    {
                        pitchRangeCount = Convert.ToInt32(args[0]);
                        path = args[1].Trim('"');
                        ImportCustom();
                    }
                    return true;
                }
                default:
                    return new TagToolError(CommandError.ArgCount);
            }
        }

        private object ImportSoundResource(byte[] data)
        {
            Console.WriteLine("Creating new sound resource...");

            var resourceDefinition = AudioUtils.CreateSoundResourceDefinition(data);
            var resourceReference = Cache.ResourceCache.CreateSoundResource(resourceDefinition);
            Definition.Resource = resourceReference;

            Console.WriteLine("Done!");

            return true;
        }

        private object ImportCustom()
        {
            var soundDataAggregate = new byte[0].AsEnumerable();
            int currentFileOffset = 0;
            int totalSampleCount = 0;
            int maxPermutationSampleCount = 0;

            if (pitchRangeCount <= 0)
                Log.Warning("Pitch range count cannot be less than 1! Proceeding with SingleLayer import.");
            if (pitchRangeCount <= 1)
                Definition.ImportType = ImportType.SingleLayer;
            else
                Definition.ImportType = ImportType.MultiLayer;

            //
            // For each pitch range, get all the permutations and append sound data.
            //
            Definition.PitchRanges = new List<PitchRange>();

            for (int u = 0; u < pitchRangeCount; u++)
            {
                List<FileInfo> fileList = new List<FileInfo>();

                if (argCount == 0)
                    permutationCount = GetPermutationCountUser();
                else
                {
                    if (Directory.Exists(path))
                    {
                        foreach (var file in Directory.GetFiles(path))
                        {
                            var perm_file = new FileInfo(file);
                            if (supportedTypes.Contains(perm_file.Extension.ToLower()))
                                fileList.Add(perm_file);
                        }
                        permutationCount = fileList.Count();
                        if (fileList.Count() == 0)
                            return new TagToolError(CommandError.CustomError, $"\"{path}\" contains no valid files! Only .mp3, .wav, and .fsb are accepted.");
                    }
                    else if (File.Exists(path))
                    {
                        if (supportedTypes.Contains(Path.GetExtension(path).ToLower()))
                            fileList.Add(new FileInfo(path));
                        else
                            return new TagToolError(CommandError.CustomError, $"\"{path}\" is not a valid file! Only .mp3, .wav, and .fsb are accepted.");
                    }
                    else
                        return new TagToolError(CommandError.CustomError, $"File or directory could not be found: \"{path}\"");
                }

                if (permutationCount <= 0)
                    return false;

                var pitchRange = new PitchRange
                {
                    ImportName = new StringId(5221),   //|default|
                    XsyncFlags = -1,
                    RuntimeDiscardedPermutationIndex = -1,
                    RuntimeLastPermutationIndex = -1,
                    RuntimeUsablePermutationCount = (sbyte)permutationCount,
                    PitchRangeParameters = new PitchRangeParameter()
                };
                pitchRange.PitchRangeParameters.PlaybackBendBounds = new Bounds<short>(-32768, 32767);

                pitchRange.Permutations = new List<Permutation>();

                //
                // Permutation section
                //

                for (int i = 0; i < permutationCount; i++)
                {
                    string soundFile = "";
                    int sampleCount = -1;
                    int bitRate = 0;

                    if (argCount == 0) {
                        soundFile = GetPermutationFileUser(i);
                        if (soundFile == null)
                            return false;
                        sampleCount = GetPermutationSampleCountUser(i);
                    }
                    else {
                        soundFile = fileList[i].FullName;
                    }

                    var permutationData = File.ReadAllBytes(soundFile);

                    if (argCount != 0)
                    {
                        byte[] header = new byte[48];
                        BitArray bits = new BitArray(header);
                        string BoolToBinary(bool bit) => bit == false ? "0" : "1";

                        switch (fileList[i].Extension.ToLower())
                        {
                            case ".mp3":
                                {
                                    Definition.PlatformCodec.Compression = Compression.MP3;

                                    // sample rate and version

                                    var frameSync = Array.IndexOf(permutationData, (byte)255);
                                    Array.Copy(permutationData, frameSync, header, 0, 32);
                                    bits = new BitArray(header);

                                    if (bits[18] == false && bits[19] == false && bits[11] == true && bits[12] == true) // 44100Hz, MPEG1
                                    {
                                        Definition.SampleRate.value = SampleRate.SampleRateValue._44khz;
                                    }
                                    else if (bits[18] == false && bits[19] == true && bits[11] == true && bits[12] == true) // 32000Hz, MPEG1
                                    {
                                        Definition.SampleRate.value = SampleRate.SampleRateValue._32khz;
                                    }
                                    else if (bits[18] == false && bits[19] == false && bits[11] == false && bits[12] == true) // 22050Hz, MPEG2
                                    {
                                        Definition.SampleRate.value = SampleRate.SampleRateValue._22khz;
                                    }
                                    else
                                        return new TagToolError(CommandError.CustomError, $"Sample rate not supported! Use 44100, 32000, or 22050Hz mp3s.");

                                    // channel configuration

                                    if (bits[30] == true && bits[31] == true)
                                        Definition.PlatformCodec.Encoding = EncodingValue.Mono;
                                    else if (bits[30] == true && bits[31] == false)
                                        Definition.PlatformCodec.Encoding = EncodingValue.Stereo;
                                    else if (bits[30] == false && bits[31] == false)
                                        Definition.PlatformCodec.Encoding = EncodingValue.Stereo;
                                    else
                                        return new TagToolError(CommandError.CustomError, $"Dual-channel mono is not supported.");

                                    // parse bitrate

                                    string bitrateNibble = BoolToBinary(bits[23]) + BoolToBinary(bits[22]) + BoolToBinary(bits[21]) + BoolToBinary(bits[20]);
                                    var bitrateLookup = new Dictionary<string, int>();

                                    if (Definition.SampleRate.value == SampleRate.SampleRateValue._44khz || Definition.SampleRate.value == SampleRate.SampleRateValue._32khz)
                                        bitrateLookup = new Dictionary<string, int>(){  // MPEG1 Layer 3 bitrates
                                            { "0001", 32 }, { "0010", 40 }, { "0011", 48 }, { "0100", 56 }, { "0101", 64 }, { "0110", 80 }, { "0111", 96 },
                                            { "1000", 112 }, { "1001", 128 }, { "1010", 160 }, { "1011", 192 }, { "1100", 224 }, { "1101", 256 }, { "1110", 320 }
                                        };
                                    else
                                        bitrateLookup = new Dictionary<string, int>(){   // MPEG2 Layer 3 bitrates
                                            { "0001", 8 }, { "0010", 16 }, { "0011", 24 }, { "0100", 32 }, { "0101", 40 }, { "0110", 48 }, { "0111", 56 },
                                            { "1000", 64 }, { "1001", 80 }, { "1010", 96 }, { "1011", 112 }, { "1100", 128 }, { "1101", 144 }, { "1110", 160 }
                                        };
                                   
                                    if (bitrateLookup.ContainsKey(bitrateNibble))
                                    {
                                        bitrateLookup.TryGetValue(bitrateNibble, out bitRate);
                                    }
                                    else
                                        return new TagToolError(CommandError.CustomError, $"This mp3 bitrate is invalid or not supported.");

                                    // estimate sample count (this gets close but isn't exact which is likely gonna be a problem. but we'll see what happens)
                                    var c = ((permutationData.Count() * 8) / (float)(bitRate * 1000)) * Definition.SampleRate.GetSampleRateHz();
                                    sampleCount = (int)c;

                                    break;
                                }
                            case ".fsb":
                                Definition.PlatformCodec.Compression = Compression.FSB4;
                                Array.Copy(permutationData, header, 32);
                                break;
                            case ".wav":
                                Definition.PlatformCodec.Compression = Compression.PCM;
                                using(var reader = new EndianReader(new MemoryStream(permutationData)))
                                {
                                    var wavFile = new WAVFile(reader);
                                    Definition.SampleRate.value = GetSoundSampleRate(wavFile.FMT.SampleRate);
                                    Definition.PlatformCodec.Encoding = GetSoundEncoding(wavFile.FMT.Channels);
                                    sampleCount = wavFile.Data.Data.Length / wavFile.FMT.BlockAlign;
                                    bitRate = (int)(wavFile.FMT.SampleRate * wavFile.FMT.BlockAlign / 1000.0f);
                                    permutationData = wavFile.Data.Data;
                                }
                                break;
                        }
                    }

                    if (Definition.PlatformCodec.Compression == Compression.PCM)
                    {
                        if (argCount == 0)
                        {
                            using (var reader = new EndianReader(new MemoryStream(permutationData)))
                            {
                                var wavFile = new WAVFile(reader);
                                if (wavFile.RIFF.Size > 0)
                                    permutationData = wavFile.Data.Data;
                            }
                        }

                        // fmod wants 0x10 bytes of padding at the start and end
                        var data = new byte[permutationData.Length + 0x20];
                        Array.Copy(permutationData, 0, data, 0x10, permutationData.Length);
                    }

                    var perm = new Permutation
                    {
                        ImportName = StringId.Empty,
                        SampleCount = (uint)sampleCount
                    };

                    perm.RawInfoIndex = (short)i;

                    if (i != 0)
                        perm.Flags = 1;

                    perm.PermutationChunks = new List<PermutationChunk>();

                    var chunk = new PermutationChunk(currentFileOffset, permutationData.Length);
                    perm.PermutationChunks.Add(chunk);
                    currentFileOffset += permutationData.Length;
                    totalSampleCount += sampleCount;

                    if (maxPermutationSampleCount < sampleCount)
                        maxPermutationSampleCount = sampleCount;

                    soundDataAggregate = soundDataAggregate.Concat(permutationData);

                    pitchRange.Permutations.Add(perm);

					if (argCount == 1)
					{
						Console.WriteLine($"Permutation {i}: \"{fileList[i].Name}\", {bitRate}kb/s at {Definition.SampleRate.GetSampleRateHz()}Hz for ~{sampleCount} samples");
					}
                }

                Definition.PitchRanges.Add(pitchRange);
            }

            Definition.MaximumPlayTime = (int)(1000 * (double)maxPermutationSampleCount / (Definition.SampleRate.GetSampleRateHz()));
            Definition.TotalSampleCount = (uint)totalSampleCount;


            // remove extra info for now

            Definition.ExtraInfo = new List<ExtraInfo>();

            ImportSoundResource(soundDataAggregate.ToArray());

            return true;
        }

        private static int GetPermutationCountUser()
        {
            return GetIntFromUser("Enter the desired number of permutations (default is 1): ");
        }

        private static string GetPermutationFileUser(int index)
        {
            return GetFileFromUser($"Enter the file path to permutation {index}: ");
        }

        private static int GetPermutationSampleCountUser(int index)
        {
            int sampleCount = GetIntFromUser($"Enter the number of samples in permutation {index}: ");
            if (sampleCount > 0)
                return sampleCount;
            else
                return -1;
        }

        private static EncodingValue GetSoundEncodingUser()
        {
            int channelCount = GetIntFromUser($"Enter the number of channels in the sound (1, 2, 4, 6): ");
            switch (channelCount)
            {
                case 1:
                    return EncodingValue.Mono;
                case 2:
                    return EncodingValue.Stereo;
                case 4:
                    return EncodingValue.Surround;
                case 6:
                    return EncodingValue._51Surround;
                default:
                    Log.Warning("Invalid channel count, using stereo.");
                    return EncodingValue.Stereo;
            }
        }

        private static EncodingValue GetSoundEncoding(int channelCount)
        {
            switch (channelCount)
            {
                case 1:
                    return EncodingValue.Mono;
                case 2:
                    return EncodingValue.Stereo;
                case 4:
                    return EncodingValue.Surround;
                case 6:
                    return EncodingValue._51Surround;
                default:
                    Log.Warning("Invalid channel count, using stereo.");
                    return EncodingValue.Stereo;
            }
        }

        private static SampleRate.SampleRateValue GetSoundSampleRateUser()
        {
            int sampleRate = GetIntFromUser($"Enter the sample rate of the sound: (0: 22050 Hz, 1: 44100 Hz, 2: 32000 Hz): ");
            switch (sampleRate)
            {
                case 0:
                    return SampleRate.SampleRateValue._22khz;
                case 1:
                    return SampleRate.SampleRateValue._44khz;
                case 2:
                    return SampleRate.SampleRateValue._32khz;
                default:
                    Log.Warning($"Invalid sample rate, using 44100 Hz");
                    return SampleRate.SampleRateValue._44khz;
            }
        }

        private static SampleRate.SampleRateValue GetSoundSampleRate(int sampleRate)
        {
            switch (sampleRate)
            {
                case 22050:
                    return SampleRate.SampleRateValue._22khz;
                case 44000:
                    return SampleRate.SampleRateValue._44khz;
                case 32000:
                    return SampleRate.SampleRateValue._32khz;
                default:
                    Log.Warning("Invalid sample rate, using 44100 Hz");
                    return SampleRate.SampleRateValue._44khz;
            }
        }

        private static Compression GetSoundCompressionUser()
        {
            int compressionIndex = GetIntFromUser($"Enter the compression format of the sound: (0: PCM, 1: MP3, 2: FSB): ");
            switch (compressionIndex)
            {
                case 0:
                    return Compression.PCM;
                case 1:
                    return Compression.MP3;
                case 2:
                    return Compression.FSB4;
                default:
                    Log.Error("Invalid compression identifier. Import aborted.");
                    return 0;
            }
        }

        private static int GetPitchRangeCountUser()
        {
            return GetIntFromUser("Enter the desired number of pitch ranges (default is 1): ");
        }

        private static string GetFileFromUser(string message)
        {
            string userInput;
            try
            {
                Console.Write(message);
                userInput = Console.ReadLine().Trim('"');
                if (!File.Exists(userInput))
                {
                    Log.Error($"Invalid file \"{userInput}\". Import aborted.");
                    return null;
                }
                return userInput;
            }
            catch (Exception e)
            {
                Log.Error($"Invalid input: {e.Message}");
            }
            return null;
        }

        private static int GetIntFromUser(string message)
        {
            string userInput;
            int result;
            try
            {
                Console.Write(message);
                userInput = Console.ReadLine();
                result = Convert.ToInt32(userInput);
                return result;
            }
            catch (Exception e)
            {
                Log.Error($"Invalid input: {e.Message}");
            }
            return -1;
        }
    }
}
