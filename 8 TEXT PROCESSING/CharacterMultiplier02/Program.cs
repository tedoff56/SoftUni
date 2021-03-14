using System;

namespace CharacterMultiplier02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(CharacterMultiplier(strings));
            
            
        }

        static int CharacterMultiplier(string[] strings)
        {
            string str1 = strings[0];
            string str2 = strings[1];
            
            int totalSum = 0;
            int cycleTo = str2.Length;;
            int lastDigits = Math.Abs(str2.Length - str1.Length);
            string subString = string.Empty;
            
            if (str1.Length < str2.Length)
            {
                cycleTo = str1.Length;
                subString = str2.Substring(cycleTo, lastDigits);
            }
            else
            {
                subString = str1.Substring(cycleTo, lastDigits);
            }
            
            for (int i = 0; i < cycleTo; i++)
            {
                totalSum += str1[i] * str2[i];
            }

            foreach (var symbol in subString)
            {
                totalSum += symbol;
            }

            return totalSum;
        }
    }
}