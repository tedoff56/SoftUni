using System;
using System.Collections;
using System.Linq;

namespace Equal_Sums_06
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            
            bool isEqual = false;
            int index = 0;
            
            for (int i = 0; i < numbers.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                
                if(i != 0)
                {
                    for (int leftNums = i-1; leftNums >= 0; leftNums--)
                    {
                        leftSum += numbers[leftNums];
                    }
                }
                
                for (int rightNums = i+1; rightNums < numbers.Length; rightNums++)
                {
                    rightSum += numbers[rightNums];
                }
                
                
                if (leftSum == rightSum)
                {
                    isEqual = true;
                    index = i;
                    break;
                }
                leftSum = 0;
                rightSum = 0;
            }
            
            if (isEqual == true)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}