using System;
using System.Linq;

namespace _03Stack
{
    class StartUp
    {
        static void Main()
        {
            MyStack<int> myStack = new MyStack<int>();
            
            string command = Console.ReadLine();
            while (command != "END")
            {
                if (command.Contains("Push"))
                {
                    int[] tokens = command
                        .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1).Select(int.Parse).ToArray();
                    
                    myStack.Push(tokens);
                }
                else if (command == "Pop")
                {
                    myStack.Pop();
                }
                
                command = Console.ReadLine();
            }

            foreach (int element in myStack)
            {
                Console.WriteLine(element);
            }
            
            foreach (int element in myStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}