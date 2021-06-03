using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _03WordCount
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<string> wordsToCount = new List<string>(await File.ReadAllLinesAsync("words.txt"))
                .Select(w=>w.ToLower()).ToList();
            
            List<string> textLines = new List<string>(await File.ReadAllLinesAsync("text.txt"));

            Dictionary<string, int> wordsCnt = new Dictionary<string, int>();
            
            for (int i = 0; i < textLines.Count; i++)
            {
                string[] currentLine = new string(
                            textLines[i].ToCharArray().Where(c => char.IsLetter(c) || c == '\'' || c == ' ').ToArray())
                            .ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in currentLine)
                {
                    if (!wordsToCount.Contains(word))
                    {
                        continue;
                    }

                    if (wordsCnt.ContainsKey(word))
                    {
                        wordsCnt[word]++;
                    }
                    else
                    {
                        wordsCnt.Add(word, 1);
                    }
                }
            }

            foreach (var kvp in wordsCnt.OrderByDescending(w=>w.Value))
            {
                await File.AppendAllTextAsync("../../../actualResult.txt", $"{kvp.Key} - {kvp.Value}" + Environment.NewLine);
            }

        }
    }
}