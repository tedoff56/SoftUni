using System;

namespace BasicWebServer.Server.Common
{
    public static class Guard
    {
        public static void AgainstNull(object value, string name = null)
        {
            if (value is null)
            {
                name ??= "Value";
                
                throw new InvalidOperationException($"{name} cannot be null.");
            }
        }
    }
}