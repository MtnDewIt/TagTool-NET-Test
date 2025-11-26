using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace TagTool.Common
{
    public static class FileUtils
    {
        public static void CopyDirectory(string sourceFolder, string destinationFolder, bool overwrite = false)
        {
            ArgumentException.ThrowIfNullOrEmpty(sourceFolder, nameof(sourceFolder));
            ArgumentException.ThrowIfNullOrEmpty(sourceFolder, nameof(destinationFolder));

            if (!Directory.Exists(sourceFolder))
                throw new DirectoryNotFoundException($"Source folder not found: {sourceFolder}");

            if (!overwrite && !IsDirectoryEmpty(destinationFolder))
                throw new IOException($"Destination folder is not empty: {destinationFolder}");

            Directory.CreateDirectory(destinationFolder);

            foreach (string file in Directory.GetFiles(sourceFolder))
            {
                string destFile = Path.Combine(destinationFolder, Path.GetFileName(file));
                File.Copy(file, destFile, overwrite: true);
            }
            foreach (string subFolder in Directory.GetDirectories(sourceFolder))
            {
                string destSubFolder = Path.Combine(destinationFolder, Path.GetFileName(subFolder));
                CopyDirectory(subFolder, destSubFolder, overwrite);
            }
        }

        public static bool IsDirectoryEmpty(string path)
        {
            ArgumentException.ThrowIfNullOrEmpty(path, nameof(path));

            return !Directory.Exists(path) || !Directory.EnumerateFileSystemEntries(path).Any();
        }
    }
}
