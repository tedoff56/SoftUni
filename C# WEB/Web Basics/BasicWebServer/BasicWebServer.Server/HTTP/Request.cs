using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicWebServer.Server.HTTP
{
    public class Request
    {
        public Request()
        {
            Headers = new HeaderCollection();
            Cookies = new CookieCollection();
        }
        
        public Method Method { get; private set; }

        public string Url { get; set; }

        public HeaderCollection Headers { get; private set; }

        public CookieCollection Cookies { get; private set; }

        public string Body { get; private set; }

        public IReadOnlyDictionary<string, string> Form { get; private set; }
        
        public static Request Parse(string request)
        {
            var lines = request.Split(Environment.NewLine);

            var firstLine = lines.First().Split();

            var method = ParseMethod(firstLine[0]);
            
            var url = firstLine[1];
            
            var headers = ParseHeaders(lines.Skip(1));

            var cookies = ParseCookies(headers);
            
            var bodyLines = lines.Skip(headers.Count + 2).ToArray();
            var body = string.Join(Environment.NewLine, bodyLines);

            var form = ParseForm(headers, body);
            
            return new Request()
            {
                Method = method,
                Url = url,
                Headers = headers,
                Cookies = cookies,
                Body = body,
                Form = form
            };
        }

        private static CookieCollection ParseCookies(HeaderCollection headers)
        {
            var cookieCollection = new CookieCollection();

            if (headers.Contains(Header.Cookie))
            {
                var cookieHeader = headers[Header.Cookie];

                var allCookies = cookieHeader
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var cookie in allCookies)
                {
                    var cookieParts = cookie
                        .Split('=', StringSplitOptions.RemoveEmptyEntries);
                    
                    cookieCollection.Add(cookieParts[0].Trim(), cookieParts[1].Trim());
                }
            }

            return cookieCollection;
        }
        
        private static Dictionary<string, string> ParseForm(HeaderCollection headers, string body)
        {
            var formCollection = new Dictionary<string, string>();

            if (headers.Contains(Header.ContentType) && 
                headers[Header.ContentType] == ContentType.FormUrlEncoded)
            {
                var parsedResult = ParseFormData(body);

                foreach (var (name, value) in parsedResult)
                {
                    formCollection.Add(name, value);
                }
            }

            return formCollection;
        }

        private static Dictionary<string, string> ParseFormData(string bodyLines)
        {
            return HttpUtility
                .UrlDecode(bodyLines)
                .Split('&')
                .Select(p => p.Split('='))
                .Where(p => p.Length == 2)
                .ToDictionary(p => p[0], p => p[1], StringComparer.InvariantCultureIgnoreCase);
        }

        private static HeaderCollection ParseHeaders(IEnumerable<string> headerLines)
        {
            var headerCollection = new HeaderCollection();
            
            foreach (var line in headerLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }
                
                var headerInfo = line.Split(":", 2);

                if (headerInfo.Length != 2)
                {
                    throw new InvalidOperationException("Invalid header!");
                }
                
                var name = headerInfo[0];
                var value = headerInfo[1].Trim();

                headerCollection.Add(name, value);
            }

            return headerCollection;
        }

        private static Method ParseMethod(string method)
        {
            try
            {
                return Enum.Parse<Method>(method, true);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Method {method} is not supported!");
            }
        }
    }
}