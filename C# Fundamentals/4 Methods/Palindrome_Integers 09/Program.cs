using System;

namespace Palindrome_Integers_09
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{PalindromeIntegers("323")}");
        }
        static bool PalindromeIntegers(string number)
        {
            bool isPalidrome = false;
            string backwards = String.Empty;
            int cnt = 0;
            for (int i = 0; i < number.Length; i++)
            {
                for (int j = number.Length-1; j > 0; j--)
                {
                    if (number[i] == number[j])
                    {
                        cnt++;
                    }
                    break;
                }
            }
            if(number.Length/2 == cnt)
                isPalidrome = true;
            
            return isPalidrome;
        }
    }
}