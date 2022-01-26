﻿using System;
using System.Text;

namespace BasicWebServer.Server.HTTP
{
    public class Response
    {
        
        public Response(StatusCode statusCode)
        {
            StatusCode = statusCode;
            
            Headers = new HeaderCollection();
            Headers.Add(Header.Server, "My Web Server");
            Headers.Add(Header.Date, $"{DateTime.UtcNow:R}");
        }
        
        public StatusCode StatusCode { get; init; }

        public HeaderCollection Headers { get; }

        public string Body { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode.ToString()}");

            foreach (var header in Headers)
            {
                result.AppendLine(header.ToString());
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