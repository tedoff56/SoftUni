using System;

namespace Vending_Machine_07
{
    class Program
    {
        static void Main(string[] args)
        {

            var coin = "";
            double coinSum = 0.0;

            var product = "";
            
            while (true)
            {
                coin = Console.ReadLine();
                if (coin == "Start")
                    break;
                
                if (coin == "0.1" || coin == "0.2" || coin == "0.5" || coin == "1" || coin == "2")
                    coinSum += Double.Parse(coin);
                else
                    Console.WriteLine($"Cannot accept {coin}");


            }
            
            while (true)
            {
                double productPrice = 0.0;
                    
                product = Console.ReadLine();
                if (product == "End")
                    break;

                if (product == "Nuts")
                    productPrice = 2.0;
                else if (product == "Water")
                    productPrice = 0.7;
                else if (product == "Crisps")
                    productPrice = 1.5;
                else if (product == "Soda")
                    productPrice = 0.8;
                else if (product == "Coke")
                    productPrice = 1.0;
                else
                {
                    Console.WriteLine("Invalid product");
                    continue;
                }
                
                
                if (coinSum - productPrice >= 0)
                {
                    coinSum -= productPrice;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else
                {
                    Console.WriteLine($"Sorry, not enough money");
                }
            }

            Console.WriteLine($"Change: {coinSum:0.00}");
        }
    }
}