using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _05DirectoryTraversal
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string path = Console.ReadLine();

            string[] files = Directory.GetFiles(path);

            Dictionary<string, List<FileInfo>> filesByExtension = new Dictionary<string, List<FileInfo>>();
            
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string fileExtension = fileInfo.Extension;

                if (!filesByExtension.ContainsKey(fileExtension))
                {
                    filesByExtension.Add(fileExtension, new List<FileInfo>());
                }

                filesByExtension[fileExtension].Add(fileInfo);
            }

            string outPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";
            foreach (var kvp in filesByExtension
                .OrderByDescending(f=>f.Value.Count)
                .ThenBy(f=>f.Key))
            {
                await File.AppendAllTextAsync(outPath, kvp.Key + Environment.NewLine);
                
                foreach (var file in kvp.Value.OrderBy(f=>Math.Ceiling((double)f.Length / 1024)))
                {
                    await File.AppendAllTextAsync(outPath, $"--{file.Name} - {Math.Ceiling((double)file.Length / 1024)}kb" + Environment.NewLine);
                }
            }
        }
    }
}