using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ReplaceRepeatingChars06
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder(Console.ReadLine());
            StringBuilder result = new StringBuilder();

            char lastChar = ' ';
            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];
                if (currentChar != lastChar)
                {
                    result.Append(currentChar);
                    lastChar = currentChar;
                }
            }
            
            Console.WriteLine(result);
        }
    }
}