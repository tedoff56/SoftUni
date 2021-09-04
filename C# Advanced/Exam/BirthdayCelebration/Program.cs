using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int asd = guests[0];    
            int wastedFood = 0;
            
            while (guests.Count != 0 && plates.Count != 0)
            {
                int plate = plates.Peek();
                int guestCapacity = guests.Peek();

                int value = guestCapacity - plate;

                if (value <= 0)
                {
                    wastedFood += Math.Abs(value);
                    guests.Dequeue();
                    plates.Pop();
                }
                else
                {
                    List<int> tempGuests = guests.ToList();

                    tempGuests[0] -= plate;
                    guests = new Queue<int>(tempGuests);
                    plates.Pop();
                }
            }

            if (guests.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            else
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}