using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Web;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Demo.Controllers
{
    public class HomeController : Controller
    {
        private const string HtmlFormString = @"
            <form action='/HTML' method='POST'>
                Name: <input type='text' name='Name'/>
                Age: <input type='number' name='Age'/>
                <input type='submit' value='Save'/>
            </form>";
        
        private const string DownloadForm = @"
            <form action='/Content' method='POST'>
               <input type='submit' value ='Download Sites Content' /> 
            </form>";
        
        private const string FileName = "text.txt";
        

        public HomeController(Request request) 
            : base(request)
        {
            
        }

        public Response Index() => Text("Hello from the server!");
        
        public Response Redirect() => Redirect("https://abv.bg/");
        
        public Response Html() => Html(HtmlFormString);

        public Response HtmlFormPost()
        {
            string formData = "";

            foreach (var (key, value) in this.Request.Form)
            {
                formData += $"{key} - {value}";
                formData += Environment.NewLine;
            }

            return Text(formData);
        }

        public Response Content() => Html(DownloadForm);

        public Response DownloadContent()
        {
            DownloadSitesAsTextFile(FileName, new[] { "https://abv.bg/", "https://softuni.bg/" })
                .Wait();

            return File(FileName);
        }

        public Response Cookies()
        {
            
            if (this.Request.Cookies
                .Any(c => c.Name != Server.HTTP.Session.SessionCookieName))
            {
                var cookieText = new StringBuilder();

                cookieText.AppendLine("<h1>Cookies</h1>");
                foreach (var cookie in this.Request.Cookies)
                {
                    cookieText
                        .AppendLine($"{HttpUtility.HtmlEncode(cookie.Name)}={HttpUtility.HtmlEncode(cookie.Value)}");
                }

                return Html(cookieText.ToString());
            }

            var cookies = new CookieCollection();
            
            cookies.Add("MyCookie", "Value");
            cookies.Add("MyCookie2", "Value2");

            return Html("<h1>Cookies set!</h1>", cookies);
        }

        public Response Session()
        {
            var sessionExists = this.Request.Session.ContainsKey(Server.HTTP.Session.SessionCurrentDateKey);

            if (sessionExists)
            {
                var currentDate = this.Request.Session[Server.HTTP.Session.SessionCurrentDateKey];

                return Text($"Stored date {currentDate}");
            }
            
            return Text("Current date stored!");
        }
        
        private static async Task DownloadSitesAsTextFile(string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownloadWebSiteContent(url));
            }

            var responses = await Task.WhenAll(downloads);

            var responsesString = string.Join(Environment.NewLine + new String('-', 100), responses);

            await System.IO.File.WriteAllTextAsync(fileName, responsesString);
        }

        private static async Task<string> DownloadWebSiteContent(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                var html = await response.Content.ReadAsStringAsync();

                return html.Substring(0, 2000);
            }
        }
        
    }
}