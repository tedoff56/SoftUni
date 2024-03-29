﻿using System.Threading.Tasks;
using BasicWebServer.Demo.Controllers;
using BasicWebServer.Server;
using BasicWebServer.Server.Controllers;

namespace BasicWebServer.Demo
{
    class StartUp
    {
        
        private const string Username = "user";

        private const string Password = "pass";
        
        public static async Task Main() 
            => await new HttpServer(r => r
                    .MapGet<HomeController>("/", req => req.Index())
                    .MapGet<HomeController>("/Redirect", req => req.Redirect())
                    .MapGet<HomeController>("/HTML", req => req.Html())
                    .MapPost<HomeController>("/HTML", req => req.HtmlFormPost())
                    .MapGet<HomeController>("/Content", req => req.Content())
                    .MapPost<HomeController>("/Content", req => req.DownloadContent())
                    .MapGet<HomeController>("/Cookies", req => req.Cookies())
                    .MapGet<HomeController>("/Session", req => req.Session())
                    .MapGet<UsersController>("/Login", req => req.LoginPage())
                    .MapPost<UsersController>("/Login", req => req.Login())
                    .MapGet<UsersController>("/Logout", req => req.Logout())
                    .MapGet<UsersController>("/UserProfile", req => req.Userdata()))
                .Start();
    }
}