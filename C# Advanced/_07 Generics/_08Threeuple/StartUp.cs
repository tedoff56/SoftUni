using System;

namespace _08Threeuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] personAddressInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = $"{personAddressInfo[0]} {personAddressInfo[1]}";
            var tuple = new MyTuple<string, string, string>(name, personAddressInfo[2], personAddressInfo[3]);
            
            if (personAddressInfo.Length == 5)
            {
                string town = $"{personAddressInfo[3]} {personAddressInfo[4]}";
                tuple = new MyTuple<string, string, string>(name, personAddressInfo[2], town);
            }
            
            Console.WriteLine(tuple);
            
            string[] personBeersInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            bool isDrunk = personBeersInfo[2] == "drunk";
            var tuple2 = new MyTuple<string, int, bool>(personBeersInfo[0], int.Parse(personBeersInfo[1]), isDrunk);

            Console.WriteLine(tuple2);
            
            string[] bankInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var tuple3 = new MyTuple<string,double, string>(bankInfo[0], Double.Parse(bankInfo[1]), bankInfo[2]);

            Console.WriteLine(tuple3);
        }
    }
}