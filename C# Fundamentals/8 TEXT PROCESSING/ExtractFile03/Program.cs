using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtractFile03
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> fileLocation = Console.ReadLine()
                .Split('\\', StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> file = fileLocation.Last()
                .Split('.', StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            string fileExtension = file.Last();
            
            file.RemoveAt(file.Count - 1);
            
            string fileName = string.Join('.', file);
            
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");

        }
    }
}