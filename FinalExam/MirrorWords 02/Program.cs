using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MirrorWords_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex wordsRegex = new Regex(@"(@|#)(?<word>[A-Za-z]{3,})\1\1(?<word2>[A-Za-z]{3,})\1");

            string text = Console.ReadLine();

            MatchCollection words = wordsRegex.Matches(text);

            List<string> pairs = new List<string>();

            foreach (Match word in words)
            {
                string firstWord = word.Groups["word"].ToString();
                string secondWord = word.Groups["word2"].ToString();

                if (firstWord.Equals(Reverse(secondWord)))
                {
                    pairs.Add($"{firstWord} <=> {secondWord}");
                }
            }
            
            if (!wordsRegex.Match(text).Success)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{words.Count} word pairs found!");
            }
            
            if (pairs.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", pairs));
            }

        }
        private static string Reverse(string str)
        {
            char[] strChars = str.ToCharArray();
            
            Array.Reverse(strChars);
            
            return new string(strChars);
        }
    }
}