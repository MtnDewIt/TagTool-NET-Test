﻿using System;
using System.ComponentModel;
using TagTool.Audio;

namespace TagTool.Commands.Porting
{
    public class PortingOptions
    {
        [Description("Maximum number of threads to use")]
        public int MaxThreads = Environment.ProcessorCount * 2;

        [Description("Audio codec to use for ported sounds")]
        public Compression AudioCodec = Compression.MP3;


        public static PortingOptions Current = new PortingOptions();
    }
}
