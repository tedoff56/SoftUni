namespace Telephony.Models
{
    using System.Linq;
    
    using Telephony.Exceptions;
    
    public abstract class Phone
    {
        public virtual void Call(string number)
        {
            if (!number.All(n => char.IsDigit(n)))
            {
                throw new InvalidNumberException();
            }
            
        }
    }
}