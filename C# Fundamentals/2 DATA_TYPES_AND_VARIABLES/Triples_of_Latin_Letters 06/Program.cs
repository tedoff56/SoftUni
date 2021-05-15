using System;

namespace Triples_of_Latin_Letters_06
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                char firstChar = (char) ('a' + i);
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        
                        firstChar = (char) ('a' + i);
                        char secondChar = (char) ('a' + j);
                        char thirdChar = (char) ('a' + k);
                        Console.Write($"{firstChar}{secondChar}{thirdChar}");
                        Console.WriteLine("");

                    }  
                }
            }

        }
    }
}