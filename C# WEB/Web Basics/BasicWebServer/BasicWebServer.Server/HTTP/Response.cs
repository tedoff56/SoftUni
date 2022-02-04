using System;
using System.Text;

namespace BasicWebServer.Server.HTTP
{
    public class Response
    {
        
        public Response(StatusCode statusCode)
        {
            StatusCode = statusCode;
            
            Headers = new HeaderCollection();
            Cookies = new CookieCollection();
            
            Headers.Add(Header.Server, "My Web Server");
            Headers.Add(Header.Date, $"{DateTime.UtcNow:R}");
        }
        
        public StatusCode StatusCode { get; init; }

        public HeaderCollection Headers { get; }

        public CookieCollection Cookies { get; set; }

        public string Body { get; set; }

        public Action<Request, Response> PreRenderAction { get; protected set; }
        
        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode.ToString()}");

            foreach (var header in Headers)
            {
                result.AppendLine(header.ToString());
            }

            foreach (var cookie in Cookies)
            {
                result.AppendLine($"{Header.SetCookie}: {cookie}");
            }
            result.AppendLine();

            if (!string.IsNullOrWhiteSpace(this.Body))
            {
                result.AppendLine(this.Body);
            }

            return result.ToString();
        }
    }
}