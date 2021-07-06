namespace Telephony.Models
{
    using System;
    using System.Linq;
    
    using Telephony.Contracts;
    using Telephony.Exceptions;
    
    public class Smartphone : Phone, ICall, IInternet
    {

        public override void Call(string number)
        {
            base.Call(number);
            
            Console.WriteLine($"Calling... {number}");
        }

        public void Browse(string site)
        {
            if (site.Any(c => char.IsNumber(c)))
            {
                throw new InvalidUrlException();
            }
            
            Console.WriteLine($"Browsing: {site}!");
        }
    }
}