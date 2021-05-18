using System;
using System.Collections.Generic;

namespace _06SongsQueue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var songs = Console.ReadLine().Split(", ");

            var songsQueue = new Queue<string>(songs);

            while (true)
            {
                if (songsQueue.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }

                var command = Console.ReadLine();

                if (command == "Play")
                {
                    songsQueue.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    var song = command.Substring(4);

                    if (!songsQueue.Contains(song))
                        songsQueue.Enqueue(song);
                    else
                        Console.WriteLine($"{song} is already contained!");
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
            }
        }
    }
}