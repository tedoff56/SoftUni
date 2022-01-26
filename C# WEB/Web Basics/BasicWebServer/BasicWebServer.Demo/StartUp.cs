using System;
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
            
            
        static void Main(string[] args)
            => new HttpServer(r => r
                .MapGet("/", new TextResponse("Hello from the server"))
                .MapGet("/HTML", new HtmlResponse(htmlFormString))
                .MapPost("/HTML", new TextResponse("", StartUp.AddFormDataAction))
                .MapGet("/Redirect", new RedirectResponse("https://abv.bg/")))
                .Start();
    }
}