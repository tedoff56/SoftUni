using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SantasSecretHelper_04
{
    class Program
    {
        static void Main(string[] args)
        {

            int key = int.Parse(Console.ReadLine());
            
            Regex regex = new Regex(@"@(?<name>[A-Za-z]+)[^@\-!:>]*!(?<behviour>G|N)!");
            
            while (true)
            {
                StringBuilder line = new StringBuilder(Console.ReadLine());

                if (line.Equals("end"))
                {
                    break;
                }
                
                for (int i = 0; i < line.Length; i++)
                {
                    line[i] = (char)(line[i] - key) ;
                }
                
                Match match = regex.Match(line.ToString());

                if(!match.Success)
                {
                    continue;
                }

                if (match.Groups["behviour"].Value == "N")
                {
                    continue;
                }

                Console.WriteLine(match.Groups["name"]);
                
            }
        }
    }
}