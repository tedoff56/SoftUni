using System;
using System.Collections.Generic;

namespace _05CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();

            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();
            
            foreach (char symbol in text)
            {
                if (chars.ContainsKey(symbol))
                {
                    chars[symbol]++;
                }
                else
                {
                    chars.Add(symbol, 1);
                }
            }

            foreach (var kvp in chars)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}