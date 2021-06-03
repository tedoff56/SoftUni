using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01EvenLines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using StreamReader reader = new StreamReader("text.txt");
                
            int cnt = 0;
            while (!reader.EndOfStream)
            {
                cnt++;

                StringBuilder line = new StringBuilder(await reader.ReadLineAsync());

                if (cnt % 2 == 0)
                {
                    continue;
                }

                char[] symbols = {'-', ',', '.', '!', '?'};

                foreach (var symbol in line.ToString())
                {
                    if (symbols.Contains(symbol))
                    {
                        line.Replace(symbol, '@');
                    }
                }

                string[] result = line.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Array.Reverse(result);

                Console.WriteLine(string.Join(' ', result));

            }
        }
    }
}