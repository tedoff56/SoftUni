using System;
using System.Linq;

namespace Max__Sequence_of_Equal_Elements_07
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int longestSequence = int.MinValue;
            int longestSequenceNum = 0;

            for (int i = 0; i < numbers.Length; i++)

            {
                int sequenceCnt = 0;
                int searchingFor = numbers[i];
                
                for (int j = i; j < numbers.Length; j++)
                {
                    if (searchingFor != numbers[j])
                    {
                        break;
                    }

                    sequenceCnt++;
                }

                if (sequenceCnt > longestSequence)
                {
                    longestSequence = sequenceCnt;
                    longestSequenceNum = searchingFor;
                }
            }

            for (int i = 0; i < longestSequence; i++)
            {
                Console.Write($"{longestSequenceNum} ");
            }
        }
    }
}