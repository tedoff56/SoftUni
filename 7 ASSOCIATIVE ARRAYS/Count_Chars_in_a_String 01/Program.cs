using System;
using System.Collections.Generic;

namespace Count_Chars_in_a_String_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> symbols = new Dictionary<char, int>();

            string text = Console.ReadLine();
            for (int i = 0; i < text.Length; i++)
            {
                char currentSymbol = text[i];
                if(symbols.ContainsKey(currentSymbol))
                {
                    symbols[currentSymbol]++;
                }
                else
                {
                    symbols.Add(currentSymbol, 1);
                }
            }

            foreach (var symbol in symbols)
            {
                if(symbol.Key != ' ')
                {
                    Console.WriteLine($"{symbol.Key} -> {symbol.Value}");
                }
            }

        }
    }
}