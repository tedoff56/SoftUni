﻿using System.Linq;
using System.Text;
using BasicWebServer.Server.Common;

namespace BasicWebServer.Server.HTTP
{
    public class ContentResponse : Response
    {
        public ContentResponse(string content, string contentType) 
            : base(StatusCode.OK)
        {
            Guard.AgainstNull(content);
            Guard.AgainstNull(contentType);
            
            this.Headers.Add(Header.ContentType, contentType);

            this.Body = content;
        }

        public override string ToString()
        {
            if (this.Body != null)
            {
                int contentLength = Encoding.UTF8.GetByteCount(this.Body);
                
                this.Headers.Add(Header.ContentLength, contentLength.ToString());
            }

            return base.ToString();
        }
    }
}