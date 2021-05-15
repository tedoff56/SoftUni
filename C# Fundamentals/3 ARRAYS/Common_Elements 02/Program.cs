using System;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Common_Elements_02
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string second = Console.ReadLine();
            string first = Console.ReadLine();
            
            string[] firstArr = first.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] secondArr = second.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            
                for (int i = 0; i < firstArr.Length; i++)
                {
                    for (int j = 0; j < secondArr.Length; j++)
                    {
                        if(firstArr[i].Equals(secondArr[j]))
                            Console.Write($"{secondArr[j]} ");
                    }
                }
        }
    }
}