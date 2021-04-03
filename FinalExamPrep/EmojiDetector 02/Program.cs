using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Numerics;

namespace EmojiDetector_02
{
    class Program
    {
        static void Main(string[] args)
        {

            Regex regex = new Regex(@"(?<symbol>::|\*\*)(?<name>[A-Z][a-z]{2,})\1");
            Regex digitsRegex = new Regex(@"\d");
            
            string text = Console.ReadLine();

            MatchCollection emojiMatches = regex.Matches(text);
            MatchCollection digitsMatches = digitsRegex.Matches(text);
            
            BigInteger coolThresholdSum = 1;
            foreach (Match digit in digitsMatches)
            {
                coolThresholdSum *= int.Parse(digit.Value);
            }

            Console.WriteLine($"Cool threshold: {coolThresholdSum}");
            
            Console.WriteLine($"{emojiMatches.Count()} emojis found in the text. The cool ones are:");
            foreach (Match emoji in emojiMatches)
            {
                string emojiName = emoji.Groups["name"].Value;
                int symbolsSum = 0;
                for (int i = 0; i < emojiName.Length; i++)
                {
                    symbolsSum += emojiName[i];
                }

                if (symbolsSum > coolThresholdSum)
                {
                    Console.WriteLine(emoji.Groups[0]);
                }
            }

        }
    }
}