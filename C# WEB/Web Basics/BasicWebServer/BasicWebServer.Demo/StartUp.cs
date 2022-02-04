﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BasicWebServer.Server;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;

namespace BasicWebServer.Demo
{
    class StartUp
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

        public static async Task Main()
        {

            await DownloadSitesAsTextFile(FileName,
                new string[] { "https://abv.bg/", "https://softuni.bg/" });
            
            var server = new HttpServer(r => r
                    .MapGet("/", new TextResponse("Hello from the server"))
                    .MapGet("/Redirect", new RedirectResponse("https://abv.bg/"))
                    .MapGet("/HTML", new HtmlResponse(HtmlFormString))
                    .MapPost("/HTML", new TextResponse("", AddFormDataAction))
                    .MapGet("/Content", new HtmlResponse(DownloadForm))
                    .MapPost("/Content", new TextFileResponse(FileName))
                    .MapGet("/Cookies", new HtmlResponse("", AddCookiesAction)))
                .Start();

            Console.ReadLine();
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

            await File.WriteAllTextAsync(fileName, responsesString);
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

        private static void AddCookiesAction(Request request, Response response)
        {
            var bodyText = "";

            var requestHasCookies = request.Cookies.Any();
            
            if (requestHasCookies)
            {
                var cookieText = new StringBuilder();

                cookieText.AppendLine("<h1>Cookies</h1>");
                foreach (var cookie in request.Cookies)
                {
                    cookieText
                        .AppendLine($"{HttpUtility.HtmlEncode(cookie.Name)}={HttpUtility.HtmlEncode(cookie.Value)}");
                }

                bodyText = cookieText.ToString();
            }
            else
            {
                response.Cookies.Add("MyCookie", "Value");
                response.Cookies.Add("MyCookie2", "Value2");
                bodyText = "Cookies set!";
            }

            response.Body = bodyText;
        }

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