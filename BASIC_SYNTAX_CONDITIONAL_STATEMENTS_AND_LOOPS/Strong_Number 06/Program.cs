using System;

namespace Strong_Number_06
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            char[] nums = number.ToCharArray();
            int totalSum = 0;
            
            for (int i = 0; i < number.Length; i++)
            {
                int currentNum = nums[i] - '0';
                
                int fact = 1;
                for (int j = 1; j <= currentNum; j++)
                {
                    fact *= j;
                }
                
                totalSum += fact;
            }

            if (number == totalSum.ToString())
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");

        }
    }
}