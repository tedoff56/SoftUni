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

            foreach (char digit in num)
            {
                sum += digit;
            }

            if (sum % 8 == 0)
            {
                return true;
            }
            
            return false;
        }

        static bool HasOddDigit(string num)
        {

            foreach (char digit in num)
            {
                if (digit % 2 != 0)
                {
                    return true;
                }
            }
            
            return false;
        }
        
    }
}