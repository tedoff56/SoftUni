using System;

namespace Sum_of_Chars_04
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());
            
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                char letter = Char.Parse(Console.ReadLine());
                sum += letter;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}