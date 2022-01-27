using System;
using System.Linq;
using System.Threading.Tasks;

namespace Chronometer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();

            var command = Console.ReadLine();

            while (command != "exit")
            {
                switch (command)
                {
                    case "start":
                        Task.Run(() => chronometer.Start());
                        break;
                    case "stop":
                        chronometer.Stop();
                        break;
                    case "lap":
                        Console.WriteLine(chronometer.Lap());
                        break;
                    case "laps":
                        
                        if(!chronometer.Laps.Any())
                        {
                            Console.WriteLine("Laps: no laps");
                            break;
                        }

                        Console.WriteLine("Laps:");
                        
                        for (int i = 0; i < chronometer.Laps.Count; i++)
                        {
                            Console.WriteLine($"{i}. {chronometer.Laps[i]}");
                        }
                        break;
                    case "time":
                        Console.WriteLine(chronometer.GetTime);
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                }

                command = Console.ReadLine();
            }
            chronometer.Stop();


        }
    }
}