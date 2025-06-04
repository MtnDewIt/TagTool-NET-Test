using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TagTool.IO
{
    public class UnmanagedExtantStream : IDisposable
    {
        private IntPtr Data { get; set; }
        public ExtantStream Stream { get; set; }

        public UnmanagedExtantStream(IntPtr data, ExtantStream stream)
        {
            Data = data;
            Stream = stream;
        }

        ~UnmanagedExtantStream()
        {
            if (Data != default)
            {
                Marshal.FreeHGlobal(Data);
                Data = default;
            }
        }

        public void Dispose()
        {
            if (Data != default)
            {
                Marshal.FreeHGlobal(Data);
                Data = default;
            }

            Stream.SetDisposable(true);
            Stream.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
