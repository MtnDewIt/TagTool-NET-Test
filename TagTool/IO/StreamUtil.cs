using System;
using System.Buffers;
using System.IO;
using TagTool.Extensions;

namespace TagTool.IO
{
    public static class StreamUtil
    {
        const int BufferSize = 8192;

        /// <summary>
        /// Copies data between two different streams.
        /// </summary>
        /// <param name="input">The stream to read from.</param>
        /// <param name="output">The stream to copy the read data to.</param>
        /// <param name="size">The size of the data to copy.</param>
        public static void Copy(Stream input, Stream output, long size)
        {
            if (size == 0)
                return;
            if (size < 0)
                throw new ArgumentOutOfRangeException("The size of the data to remove must be >= 0");

            byte[] buffer = ArrayPool<byte>.Shared.Rent(BufferSize);

            try
            {
                long remaining = size;
                while (remaining > 0)
                {
                    long chunkSize = Math.Min(BufferSize, remaining);
                    input.ReadExactly(buffer, 0, (int)chunkSize);
                    output.Write(buffer, 0, (int)chunkSize);
                    remaining -= chunkSize;
                }
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        /// <summary>
        /// Copies data between two locations in the same stream.
        /// The source and destination areas may overlap.
        /// </summary>
        /// <param name="stream">The stream to copy data in.</param>
        /// <param name="originalPos">The position of the block of data to copy.</param>
        /// <param name="targetPos">The position to copy the block to.</param>
        /// <param name="size">The number of bytes to copy.</param>
        public static void Copy(Stream stream, long originalPos, long targetPos, long size)
        {
            if (size == 0)
                return;
            if (size < 0)
                throw new ArgumentException("The size of the data to remove must be >= 0");

            byte[] buffer = ArrayPool<byte>.Shared.Rent(BufferSize);

            try
            {
                var remaining = size;
                while (remaining > 0)
                {
                    var read = (int)Math.Min(BufferSize, remaining);

                    if (targetPos > originalPos)
                        stream.Position = originalPos + remaining - read; // Seek backward
                    else
                        stream.Position = originalPos + size - remaining; // Seek forward

                    stream.ReadExactly(buffer, 0, read);

                    if (targetPos > originalPos)
                        stream.Position = targetPos + remaining - read; // Seek backward
                    else
                        stream.Position = targetPos + size - remaining; // Seek forward

                    stream.Write(buffer, 0, read);
                    remaining -= read;
                }
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        /// <summary>
        /// Inserts space into a stream by copying everything back by a certain number of bytes.
        /// </summary>
        /// <param name="stream">The stream to insert space into.</param>
        /// <param name="size">The size of the space to insert.</param>
        /// <param name="fill">The byte to fill the inserted space with. See <see cref="Fill" />.</param>
        public static void Insert(Stream stream, int size, byte fill)
        {
            if (size == 0)
                return;
            if (size < 0)
                throw new ArgumentException("The size of the data to insert must be >= 0");

            long startPos = stream.Position;
            if (startPos < stream.Length)
            {
                Copy(stream, startPos, startPos + size, stream.Length - startPos);
                stream.Position = startPos;
            }
            Fill(stream, fill, size);
        }

        /// <summary>
        /// Removes bytes from a stream, moving everything after the bytes to the current position and decreasing the stream length.
        /// </summary>
        /// <param name="stream">The stream to remove bytes from.</param>
        /// <param name="size">The number of bytes to remove.</param>
        /// <exception cref="System.ArgumentException">The size of the data to remove must be >= 0</exception>
        public static void Remove(Stream stream, int size)
        {
            if (size == 0)
                return;
            if (size < 0)
                throw new ArgumentException("The size of the data to remove must be >= 0");

            long startPos = stream.Position;
            if (startPos + size >= stream.Length)
            {
                stream.SetLength(startPos);
                return;
            }
            Copy(stream, startPos + size, startPos, stream.Length - startPos - size);
            stream.SetLength(stream.Length - size);
        }

        /// <summary>
        /// Fills a section of a stream with a repeating byte.
        /// </summary>
        /// <param name="stream">The stream to fill a section of.</param>
        /// <param name="b">The byte to fill the section with.</param>
        /// <param name="size">The size of the section to fill.</param>
        public static void Fill(Stream stream, byte b, int size)
        {
            if (size == 0)
                return;
            if (size < 0)
                throw new ArgumentException("The size of the data to insert must be >= 0");

            byte[] buffer = ArrayPool<byte>.Shared.Rent(BufferSize);

            try
            {
                // Fill the buffer
                buffer.AsSpan().Fill(b);

                long remaining = size;
                while (remaining > 0)
                {
                    int chunkSize = (int)Math.Min(remaining, BufferSize);
                    stream.Write(buffer, 0, chunkSize);
                    remaining -= chunkSize;
                }
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        /// <summary>
        /// Aligns the position of a stream to a power of two, padding the stream with zeroes.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="align">The power of two to align to.</param>
        public static void Align(Stream stream, int align)
        {
            long currentPos = stream.Position;
            long alignedPos = (currentPos + align - 1) & ~((long)align - 1);
            if (alignedPos > currentPos)
                Insert(stream, (int)(alignedPos - currentPos), 0);
        }
    }
}
