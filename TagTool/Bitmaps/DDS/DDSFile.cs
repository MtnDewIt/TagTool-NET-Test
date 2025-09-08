using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagTool.IO;

namespace TagTool.Bitmaps.DDS
{
    public class DDSFile
    {
        public DDSHeader Header;
        public byte[] BitmapData;

        public DDSFile()
        {
            Header = new DDSHeader();
        }

        public DDSFile(DDSHeader header, byte[] data)
        {
            Header = header;
            BitmapData = data;
        }

        public DDSFile(BaseBitmap bitmap)
        {
            Header = new DDSHeader(bitmap);
            BitmapData = bitmap.Data;
        }

        public void Write(EndianWriter writer)
        {
            Header.Write(writer);
            writer.WriteBlock(BitmapData);
        }

        public void Write(string filename)
        {
            using (var writer = new EndianWriter(File.Create(filename)))
                Write(writer);
        }

        public bool Read(EndianReader reader)
        {
            Header.Read(reader);
            var dataSize = (int)(reader.BaseStream.Length - reader.BaseStream.Position);
            BitmapData = new byte[dataSize];
            reader.ReadBlock(BitmapData, 0, dataSize);
            return true;
        }

        public bool Read(string filename)
        {
            using (var reader = new EndianReader(File.OpenRead(filename)))
                return Read(reader);
        }

        public static DDSFile LoadFromFile(string filename)
        {
            var dds = new DDSFile();
            return dds.Read(filename) ? dds : null;
        }
    }
}
