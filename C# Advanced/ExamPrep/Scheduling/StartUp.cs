using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class StartUp
    {
        static void Main()
        {
            int[] tasks = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] threads = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int taskToKill = int.Parse(Console.ReadLine());

            var tasksStack = new Stack<int>(tasks);
            var threadsQueue = new Queue<int>(threads);

            int value = 0;
            while (true)
            {
                int currentTask = tasksStack.Peek();
                int currentThread = threadsQueue.Peek();
                
                if (currentTask == taskToKill)
                {
                    value = currentThread;
                    break;
                }
                
                if (currentThread >= currentTask)
                {
                    tasksStack.Pop();
                    threadsQueue.Dequeue();
                }
                else
                {
                    threadsQueue.Dequeue();
                }
                
            }

            Console.WriteLine($"Thread with value {value} killed task {taskToKill}");
            Console.WriteLine(string.Join(' ', threadsQueue));
        }
    }
}