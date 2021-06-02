using System.IO;
using System.Threading.Tasks;

namespace _02LineNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] file = await File.ReadAllLinesAsync("text.txt");
            
            for (int i = 0; i < file.Length; i++)
            {
                string line = file[i];

                int letters = 0;
                int punctuationMarks = 0;
                
                foreach (char symbol in line)
                {
                    if (char.IsPunctuation(symbol))
                        punctuationMarks++;

                    if(char.IsLetter(symbol))
                        letters++;
                    
                }
                file[i] = $"Line {i + 1}: {file[i]} ({letters})({punctuationMarks})";
            }

            await File.WriteAllLinesAsync("result.txt", file);

        }
    }
}