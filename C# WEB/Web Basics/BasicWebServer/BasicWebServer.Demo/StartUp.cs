using System;
using BasicWebServer.Server;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;

namespace BasicWebServer.Demo
{
    class Program
    {
        static void Main(string[] args)
            => new HttpServer(r => r
                .MapGet("/", new TextResponse("Hello from the server"))
                .MapGet("/HTML", new HtmlResponse("<h1>HTML Response</h1>"))
                .MapGet("/Redirect", new RedirectResponse("https://abv.bg/")))
                .Start();
    }
}