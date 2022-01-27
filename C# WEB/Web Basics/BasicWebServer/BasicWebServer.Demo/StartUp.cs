using System;
using System.Threading.Tasks;
using BasicWebServer.Server;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;

namespace BasicWebServer.Demo
{
    class StartUp
    {
        private const string htmlFormString = @"
            <form action='/HTML' method='POST'>
                Name: <input type='text' name='Name'/>
                Age: <input type='number' name='Age'/>
                <input type='submit' value='Save'/>
            </form>";
            
            
        static async Task Main(string[] args)
            => await new HttpServer(r => r
                .MapGet("/", new TextResponse("Hello from the server"))
                .MapGet("/Redirect", new RedirectResponse("https://abv.bg/"))
                .MapGet("/HTML", new HtmlResponse(htmlFormString))
                .MapPost("/HTML", new TextResponse("", AddFormDataAction)))
                .Start();

        private static void AddFormDataAction(Request request, Response response)
        {
            response.Body = "";

            foreach (var (key, value) in request.Form)
            {
                response.Body += $"{key} - {value}";
                response.Body += Environment.NewLine;
            }
        }
    }
}