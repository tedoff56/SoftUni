namespace Telephony.Exceptions
{
    using System;
    public class InvalidNumberException : Exception
    {
        private const string InvalidNumberMessage = "Invalid number!";
        public InvalidNumberException()
        :base(InvalidNumberMessage)
        {
            
        }
    }
}