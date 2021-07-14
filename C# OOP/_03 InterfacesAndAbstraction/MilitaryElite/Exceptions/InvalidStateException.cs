using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidStateException : Exception
    {
        private const string INVALID_STATE_MSG = "Invalid mission state";
        
        public InvalidStateException()
        :base(INVALID_STATE_MSG)
        {
            
        }
    }
}