using System;
using System.Linq;
using Telephony.Exceptions;
using Telephony.Models;

namespace Telephony
{
    
    class StartUp
    {
        private static void Main()
        {
            string[] phoneNumbersToCall = Console.ReadLine().Split();
            string[] sitesToVisit = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (var number in phoneNumbersToCall)
            {
                try
                {
                    if(number.Count() == 10)
                    {
                        smartphone.Call(number);
                    }
                    else if (number.Count() == 7)
                    {
                        stationaryPhone.Call(number);
                    }
                    else
                    {
                        Console.WriteLine(new InvalidNumberException().Message);
                    }
                }
                catch (InvalidNumberException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var site in sitesToVisit)
            {
                try
                {
                    smartphone.Browse(site);
                }
                catch (InvalidUrlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
        }
    }
}