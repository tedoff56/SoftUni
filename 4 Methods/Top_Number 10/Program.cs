using System;

namespace Top_Number_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isTopNumber = false;
            
            for (int i = 0; i < number; i++)
            {
                isTopNumber = DigitsSumDivByEight(i.ToString()) && HasOddDigit(i.ToString());
                if (isTopNumber)
                {
                    Console.WriteLine(i);
                }
            }
            
        }

        static bool DigitsSumDivByEight(string num)
        {
            int sum = 0;
            
            for (int i = 0; i < num.Length; i++)
            {
                sum += num[i];
            }

            if (sum % 8 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool HasOddDigit(string num)
        {
            
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] % 2 != 0)
                {
                    return true;
                }
            }
            
            return false;
        }
        
    }
}