using System;

namespace Vacation_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int group = int.Parse((Console.ReadLine()));
            string type = Console.ReadLine();
            string day = Console.ReadLine();
            double totalPrice = 0.0;


            if (type.Equals("Students"))
            {
                if (day.Equals("Friday"))
                    totalPrice = 8.45 * group;
                else if (day.Equals("Saturday"))
                    totalPrice = 9.8 * group;
                else if (day.Equals("Sunday"))
                    totalPrice = 10.46 * group; 
                
                if (group >= 30)
                    totalPrice *= 0.85;
                
            }

            if (type.Equals("Business"))
            {
                if (group >= 100)
                {
                    group -= 10;
                }
                
                if (day.Equals("Friday"))
                    totalPrice = 10.9 * group;
                else if (day.Equals("Saturday"))
                    totalPrice = 15.6 * group;
                else if (day.Equals("Sunday"))
                    totalPrice = 16 * group;
                
            }

            if (type.Equals("Regular"))
            {
                if (day.Equals("Friday"))
                    totalPrice = 15 * group;
                else if (day.Equals("Saturday"))
                    totalPrice = 20 * group;
                else if (day.Equals("Sunday"))
                    totalPrice = 22.5 * group;
                
                if (group >= 10 && group <= 20)
                {
                    totalPrice *= 0.95;
                }
                
            }

            Console.WriteLine($"Total price: {totalPrice:0.00}");
            
        }
    }
}