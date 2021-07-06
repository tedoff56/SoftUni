namespace Telephony.Exceptions {
    
    using System;
    public class InvalidUrlException : Exception
    {
        private const string InvalidUrlMessage = "Invalid URL!";
        
        public InvalidUrlException()
        :base(InvalidUrlMessage)
        {
            
        }
    }
}