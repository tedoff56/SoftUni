using System;

namespace WorldTour_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string stopsString = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Travel")
                {
                    Console.WriteLine($"Ready for world tour! Planned stops: {stopsString}");
                    break;
                }

                string[] tokens = line.Split(":", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "Add Stop")
                {
                    int index = int.Parse(tokens[1]);
                    string str = tokens[2];
                    
                    if (IsIndexValid(index, stopsString))
                    {
                        stopsString = stopsString.Insert(index, str);
                    }

                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    
                    if(startIndex == 0 && endIndex == stopsString.Length - 1)
                    {
                        continue;;
                    }
                    
                    if (IsIndexValid(startIndex, stopsString) && IsIndexValid(endIndex, stopsString))
                    {
                        int count = endIndex - startIndex + 1;
                        stopsString = stopsString.Remove(startIndex, count);
                    }

                    
                }
                else if (command == "Switch")
                {
                    string oldString = tokens[1];
                    string newString = tokens[2];
                    
                    if (stopsString.Contains(oldString) && oldString != newString)
                    {
                        stopsString = stopsString.Replace(oldString, newString);
                    }
                    
                }
                Console.WriteLine(stopsString);
                
            }
            
        }
        private static bool IsIndexValid(int index, string str)
        {
            return index >= 0 && index < str.Length;
        }
    }
}