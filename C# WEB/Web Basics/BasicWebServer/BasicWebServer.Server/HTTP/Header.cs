using BasicWebServer.Server.Common;

namespace BasicWebServer.Server.HTTP
{
    public class Header
    {
        public Header(string name, string value)
        {
            Guard.AgainstNull(name, "Header name");
            Guard.AgainstNull(value, "Header value");
            
            this.Name = name;   
            this.Value = value;
        }
        
        public string Name { get; init; }

        public string Value { get; set; }
    }
}