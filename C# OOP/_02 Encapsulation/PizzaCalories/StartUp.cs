using System;

namespace PizzaCalories
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Pizza pizza = new Pizza();

            string line = Console.ReadLine();
            while (line != "END")
            {
                string[] tokens = line.Split();

                switch (tokens[0])
                {
                    case "Pizza":
                        try
                        {
                            pizza = new Pizza(tokens[1]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            return;
                        }
                        break;
                    
                    case "Dough":
                        try
                        {
                            pizza.Dough = new Dough(tokens[1], tokens[2], double.Parse(tokens[3]));;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            return;
                        }
                        break;
                    
                    case "Topping":
                        try
                        {
                            pizza.AddTopping(new Topping(tokens[1], double.Parse(tokens[2])));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            return;
                        }
                        break;
                }
                
                line = Console.ReadLine();
            }

            Console.WriteLine(pizza);
        }
    }
}