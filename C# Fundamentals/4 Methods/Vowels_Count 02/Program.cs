using System;

namespace Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine().ToLower();
            
            PrintVowelsInString(str);

        }

        static void PrintVowelsInString(string str)
        {
            int vowelsCnt = 0;
            foreach (char letter in str)
            {
                if (letter == 'a' || letter == 'e' || letter == 'i' || 
                    letter == 'o' || letter == 'u')
                    {
                        vowelsCnt++;
                    }
            }
            Console.WriteLine(vowelsCnt);
        }
    }
}