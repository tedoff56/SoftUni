namespace Telephony.Models
{
    using System;
    
    using Telephony.Contracts;
    
    public class StationaryPhone : Phone, ICall
    {
        public override void Call(string number)
        {
            base.Call(number);
            
            Console.WriteLine($"Dialing... {number}");
        }
        
    }
}