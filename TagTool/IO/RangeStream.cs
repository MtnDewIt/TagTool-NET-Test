using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagTool.IO
{
    public class RangeStream : Stream
    {
        private readonly Stream _baseStream;
        private readonly long _start;
        private readonly long _length;
        private long _position;

        public RangeStream(Stream baseStream, long start, long length)
        {
            if (baseStream == null)
                throw new ArgumentNullException(nameof(baseStream));
            if (!baseStream.CanRead && !baseStream.CanWrite)
                throw new ArgumentException("Stream must support reading or writing", nameof(baseStream));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start), "Start position cannot be negative");
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), "Length cannot be negative");
            if (start + length > baseStream.Length && baseStream.Length > 0)
                throw new ArgumentOutOfRangeException(nameof(length), "Range exceeds stream length");

            _baseStream = baseStream;
            _start = start;
            _length = length;
            _position = 0;

            // Set the base stream to the start position
            if (baseStream.CanSeek)
                baseStream.Position = start;
        }

        public override bool CanRead => _baseStream.CanRead;
        public override bool CanSeek => _baseStream.CanSeek;
        public override bool CanWrite => _baseStream.CanWrite;
        public override long Length => _length;

        public override long Position
        {
            get => _position;
            set
            {
                if (value < 0 || value > _length)
                    throw new ArgumentOutOfRangeException(nameof(value), "Position out of range");
                _position = value;
                if (_baseStream.CanSeek)
                    _baseStream.Position = _start + value;
            }
        }

        public override void Flush()
        {
            _baseStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            if (offset + count > buffer.Length)
                throw new ArgumentException("Offset + count exceeds buffer length");

            // Limit the read to the remaining range
            long remaining = _length - _position;
            if (remaining <= 0)
                return 0;

            count = (int)Math.Min(count, remaining);
            int bytesRead = _baseStream.Read(buffer, offset, count);
            _position += bytesRead;
            return bytesRead;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            long newPosition;
            switch (origin)
            {
                case SeekOrigin.Begin:
                    newPosition = offset;
                    break;
                case SeekOrigin.Current:
                    newPosition = _position + offset;
                    break;
                case SeekOrigin.End:
                    newPosition = _length + offset;
                    break;
                default:
                    throw new ArgumentException("Invalid seek origin", nameof(origin));
            }

            if (newPosition < 0 || newPosition > _length)
                throw new ArgumentOutOfRangeException(nameof(offset), "Seek position out of range");

            _position = newPosition;
            long basePosition = _baseStream.Seek(_start + newPosition, SeekOrigin.Begin);
            return basePosition - _start;
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException("Cannot set length of a range stream");
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            if (offset + count > buffer.Length)
                throw new ArgumentException("Offset + count exceeds buffer length");

            long remaining = _length - _position;
            if (count > remaining)
                throw new IOException("Write would exceed range length");

            _baseStream.Write(buffer, offset, count);
            _position += count;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // We don't dispose the base stream since we don't own it
            }
            base.Dispose(disposing);
        }
    }
}
