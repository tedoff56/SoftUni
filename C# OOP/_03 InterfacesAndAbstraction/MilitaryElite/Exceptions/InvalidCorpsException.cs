using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidCorpsException : Exception
    {
        private const string INVALID_CORPS_MESSAGE = "Invalid corps";
        public InvalidCorpsException()
        :base(INVALID_CORPS_MESSAGE)
        {
            
        }
        
    }
}