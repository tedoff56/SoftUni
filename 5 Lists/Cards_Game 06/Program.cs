using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards_Game_06
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> handOne = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> handTwo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                if (handOne.Count == 0 || handTwo.Count == 0)
                {
                    break;
                }

                if (handOne[0] > handTwo[0])
                {
                    handOne.Add(handOne[0]);
                    handOne.Add(handTwo[0]);
                    RemoveFirstIndex(handOne,handTwo);
                }
                else if(handTwo[0] > handOne[0])
                {
                    handTwo.Add(handTwo[0]);
                    handTwo.Add(handOne[0]);
                    RemoveFirstIndex(handOne,handTwo);
                }
                else
                {
                    RemoveFirstIndex(handOne,handTwo);
                }
                
            }

            if (handOne.Count > handTwo.Count)
            {
                Console.WriteLine($"First player wins! Sum: {handOne.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {handTwo.Sum()}");
            }
        }

        static void RemoveFirstIndex(List<int> handOne, List<int> handTwo)
        {
            handOne.RemoveAt(0);
            handTwo.RemoveAt(0);
        }
    }
}