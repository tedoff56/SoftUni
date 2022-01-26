using System.Collections;
using System.Collections.Generic;

namespace BasicWebServer.Server.HTTP
{
    public class HeaderCollection : IEnumerable<Header>
    {
        private readonly Dictionary<string, Header> headers;

        public HeaderCollection()
        {
            headers = new Dictionary<string, Header>();
        }

        public int Count => headers.Count;

        public void Add(string name, string value)
            => this.headers[name] = new Header(name, value);

        public bool Contains(string name)
            => headers.ContainsKey(name);

        public string this[string name] 
            => this.headers[name].Value;

        public IEnumerator<Header> GetEnumerator()
        {
            foreach (var header in headers.Values)
            {
                yield return header;
            }
        }
        

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}