using System;
using System.Runtime.InteropServices;

namespace TagTool.Audio.Utils
{
    public static class AudioLib
    {
        private const string DllName = @"AudioLib.dll";

        [StructLayout(LayoutKind.Sequential)]
        public struct ALTranscodeParams
        {
            public string input_format;
            public string input_codec;
            public int input_channels;
            public int input_sample_rate;
            public string output_format;
            public string output_codec;
            public int output_channels;
            public int output_sample_rate;
            public int quality;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ALTranscodeInfo
        {
            public long sample_count; // returned sample count
            public int channels;
            public int sample_rate;
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int al_transcode(nint input_stream, nint output_stream, ref ALTranscodeParams transcode_params, ref ALTranscodeInfo info);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint al_stream_new(nint capacity);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint al_stream_new_from_buffer(nint data, int size);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void al_stream_delete(nint stream);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int al_stream_set_size(nint stream, int size);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint al_stream_get_buffer(nint stream);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int al_stream_get_size(nint stream);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int al_stream_read(nint stream, byte[] buffer, int size);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int al_stream_write(nint stream, byte[] data, int size);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int al_stream_seek(nint stream, int offset, int whence);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int al_stream_tell(nint stream);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int al_rebuild_ogg_vorbis(uint hash, int channels, int sample_count, int sample_rate, byte[] data, int data_size, nint output_stream);
    }
}
