using System.IO;
using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Responses
{
    public class TextFileResponse : Response
    {
        public string FileName { get; init; }
        
        public TextFileResponse(string fileName) 
            : base(StatusCode.OK)
        {
            FileName = fileName;
            
            this.Headers.Add(Header.ContentType, ContentType.PlainText);
        }

        public override string ToString()
        {
            if (File.Exists(FileName))
            {
                this.Body = File.ReadAllTextAsync(FileName).Result;
                
                var fileBytesCount = new FileInfo(FileName).Length;
                
                this.Headers.Add(Header.ContentLength, fileBytesCount.ToString());
                this.Headers.Add(Header.ContentDisposition, $"attachment; filename=\"{FileName}\"");
            }

            return base.ToString();
        }
    }
}