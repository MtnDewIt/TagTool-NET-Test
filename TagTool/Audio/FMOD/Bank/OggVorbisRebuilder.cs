using System.Linq;
using System.Runtime.InteropServices;
using static TagTool.Audio.Utils.AudioLib;

namespace TagTool.Audio.FMOD.Bank
{
    class OggVorbisRebuilder
    {
        public static byte[] Rebuild(FSBSubSound sound, byte[] data)
        {
            var vorbisData = (VorbisChunkData)sound.Chunks.Single((chunk) => chunk.ChunkType == ChunkType.VORBISDATA).ChunkData;

            nint result_stream = al_stream_new(0);

            try
            {
                int ret = al_rebuild_ogg_vorbis(vorbisData.SetupHash, sound.Channels, (int)sound.SampleCount, sound.Frequency, data, data.Length, result_stream);
                if (ret != 0)
                    return null;

                nint ptr = al_stream_get_buffer(result_stream);
                int size = al_stream_get_size(result_stream);

                byte[] result = new byte[size];
                Marshal.Copy(ptr, result, 0, size);
                return result;
            }
            finally
            {
                al_stream_delete(result_stream);
            }
        }
    }
}
