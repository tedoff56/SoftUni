using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            List<int> sets = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();

                if (hat > scarf)
                {
                    sets.Add(hats.Pop() + scarfs.Dequeue());
                }
                else if (scarf > hat)
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();
                
                    int tempHat = hats.Pop() + 1;

                    List<int> tempHats = new List<int>(hats.Reverse());
                    tempHats.Add(tempHat);
                
                    hats = new Stack<int>(tempHats);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(' ', sets));

        }
    }
}