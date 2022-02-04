using System.Collections;
using System.Collections.Generic;

namespace BasicWebServer.Server.HTTP
{
    public class CookieCollection : IEnumerable<Cookie>
    {
        private readonly Dictionary<string, Cookie> cookies;

        public CookieCollection() 
            => cookies = new Dictionary<string, Cookie>();
        
        private string this[string name]
            => cookies[name].Value;
        
        private void Add(string name, string value) 
            => cookies[name] = new Cookie(name, value);

        private bool Contains(string name)
            => cookies.ContainsKey(name);
        
        public IEnumerator<Cookie> GetEnumerator() 
            => cookies.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() 
            => GetEnumerator();
    }
}