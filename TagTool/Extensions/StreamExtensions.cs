using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagTool.Extensions
{
    public static class StreamExtensions
    {
        public static int ReadAll(this Stream s, byte[] buffer, int offset, int count)
        {
            int receivedTotal = 0, received;
            do
            {
                received = s.Read(buffer, offset, count);
                receivedTotal += received;
                offset += received;
                count -= received;
            }
            while (count > 0 && received > 0);
            return receivedTotal;
        }
    }
}
