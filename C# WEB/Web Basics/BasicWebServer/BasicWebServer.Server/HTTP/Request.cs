using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicWebServer.Server.HTTP
{
    public class Request
    {
        public Request()
        {
            Headers = new HeaderCollection();
        }
        
        public Method Method { get; private set; }

        public string Url { get; set; }

        public HeaderCollection Headers { get; private set; }

        public string Body { get; private set; }

        public static Request Parse(string request)
        {
            var lines = request.Split(Environment.NewLine);

            var firstLine = lines.First().Split();

            var method = ParseMethod(firstLine[0]);
            
            var url = firstLine[1];
            
            var headers = ParseHeaders(lines.Skip(1));
            
            var bodyLines = lines.Skip(headers.Count + 2).ToArray();
            var body = string.Join(Environment.NewLine, bodyLines);

            return new Request()
            {
                Method = method,
                Url = url,
                Headers = headers,
                Body = body
            };
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