using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReadFromTextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = System.IO.File
                .ReadAllText(@"C:\Users\tedof\Documents\GitHub\SoftUni\New folder\ReadFromTextFile\read.txt")
                .Replace("\n", " ").Replace("\r", " ");

            string[] champions = file.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < champions.Length; i++)
            {
                if (Regex.IsMatch(champions[i], "[0-9%]") || Regex.IsMatch(champions[i], "[A-Z][A-Z]"))
                {
                    champions[i] = " ";
                }
            }
            

            for (int i = 0; i < champions.Length; i++)
            {
                Console.WriteLine($"{champions[i]}");
            }        

        }
    }
}