using System.IO;
using System.Threading.Tasks;

namespace _02LineNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] fileLines = await File.ReadAllLinesAsync("text.txt");
            
            for (int i = 0; i < fileLines.Length; i++)
            {
                string line = fileLines[i];

                int letters = 0;
                int punctuationMarks = 0;
                
                foreach (char symbol in line)
                {
                    if (char.IsPunctuation(symbol))
                        punctuationMarks++;

                    if(char.IsLetter(symbol))
                        letters++;
                    
                }
                fileLines[i] = $"Line {i + 1}: {fileLines[i]} ({letters})({punctuationMarks})";
            }

            await File.WriteAllLinesAsync("../../../result.txt", fileLines);

        }
    }
}