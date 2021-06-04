using System;
using System.IO.Compression;

namespace _06ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string startPath = @"../../../zipFolder";
            string zipPath = @"../../../zipFile.zip";
            string extractPath = @"../../../extract";

            ZipFile.CreateFromDirectory(startPath, zipPath);
            
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}