using System;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace Kamino_Factory_09
{
    class Program
    {
        static void Main(string[] args)
        {
            int dnaLenght= int.Parse(Console.ReadLine());
            var dnaSequence = new int[]{};
            
            int bestSubsequenceLength = int.MinValue;
            int bestSequenceSum = int.MinValue;
            int bestSequenceIndex = int.MinValue;
            var bestDnaSequence = new int[] { };
            

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Clone them!")
                    break;
                
                dnaSequence = input.Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                
                int sequenceSum = 0;
                for (int i = 0; i < dnaSequence.Length; i++)
                {
                
                    sequenceSum += dnaSequence[i];
                
                
                }

                int sequenceIndexCnt = 0;
                int subsequenceLength = 0;
                for (int i = 0; i < dnaSequence.Length; i++)
                {
                    sequenceIndexCnt++;
                    int searchingFor = dnaSequence[i];

                    for (int j = i; j < dnaSequence.Length; j++)
                    {
                        if (searchingFor != dnaSequence[j])
                            break;
                        subsequenceLength++;
                    }

                    if (subsequenceLength > bestSubsequenceLength && sequenceSum != bestSequenceSum)
                    {
                        bestSubsequenceLength = subsequenceLength;
                        bestSequenceSum = sequenceSum;
                        bestDnaSequence = dnaSequence;
                        bestSequenceIndex = sequenceIndexCnt;

                    }
                        
                    
                }
                
                
            }

            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.\n{string.Join(" ", bestDnaSequence)}");
            
        }
    }
}