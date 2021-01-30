using System;
using System.Runtime.CompilerServices;

namespace Common_Elements_02
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string second = Console.ReadLine();
            string first = Console.ReadLine();
            
            string[] firstArr = first.Split();
            string[] secondArr = second.Split();
            
            
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