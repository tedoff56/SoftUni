using System;
using System.Collections.Generic;
using System.Linq;

namespace _08BalancedParentheses
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var line = Console.ReadLine();

            var openBrackets = new Stack<char>();

            bool isValid = true;
            foreach (var bracket in line)
                if (bracket == '{' || bracket == '[' || bracket == '(')
                {
                    openBrackets.Push(bracket);
                }
                else if (!openBrackets.Any())
                {
                    isValid = false;
                    break;
                }
                else
                {
                    bool firstIsValid = bracket == '}' && openBrackets.Pop() == '{';
                    bool secondIsValid = bracket == ']' && openBrackets.Pop() == '[';
                    bool thirdIsValid = bracket == ')' && openBrackets.Pop() == '(';

                    if (!firstIsValid && !secondIsValid && !thirdIsValid)
                    {
                        isValid = false;
                        break;
                    }
                }

            Console.WriteLine(isValid ? "YES" : "NO");
        }
    }
}