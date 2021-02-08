using System;

namespace Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            VowelsCount();
        }

        static void VowelsCount()
        {
            int vowelsCnt = 0;
            string str = Console.ReadLine().ToLower();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'a' || str[i] == 'e' || str[i] == 'i' || 
                    str[i] == 'o' || str[i] == 'u')
                {
                    vowelsCnt++;
                }
            }

            Console.WriteLine(vowelsCnt);
        }
    }
}