using System;

namespace MultiplicationSign_05
{
    class Program
    {
        static void Main(string[] args)
        {

            int negativeCnt = 0;
            
            for (int i = 0; i < 3; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number == 0)
                {
                    negativeCnt = -1;
                    break;
                }
                
                if(number < 0)
                {
                    negativeCnt++;
                }
            }

            if (negativeCnt != -1)
            {
                if (negativeCnt % 2 == 0)
                {
                    Console.WriteLine("positive");
                }
                else
                {
                    Console.WriteLine("negative");
                }
            }
            else
            {
                Console.WriteLine("zero");
            }

        }
        
    }
}