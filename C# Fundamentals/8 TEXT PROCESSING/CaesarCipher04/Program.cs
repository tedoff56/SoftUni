using System;
using System.Text;

namespace CaesarCipher04
{
    class Program
    {
        static void Main(string[] args)
        {

            StringBuilder text = new StringBuilder(Console.ReadLine());

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];
                char cryptedChar = (char)(currentChar + 3);
                
                text[i] = cryptedChar;
            }

            Console.WriteLine(text);
        }
    }
}