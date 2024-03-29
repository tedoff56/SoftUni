﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BasicWebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 8080;
            
            var serverListener = new TcpListener(ipAddress, port);
            serverListener.Start();
            
            Console.WriteLine($"Server started on port {port}");
            Console.WriteLine("Listening for requests...");
            
            while (true)
            {
                var connection = serverListener.AcceptTcpClient();

                var networkStream = connection.GetStream();

                string content = "My first http server";
                int contentLength = Encoding.UTF8.GetByteCount(content);

                string response = $@"HTTP/1.1 200 OK
Content-Type: text/plain; charset: UTF-8
Content-Length: {contentLength}

{content}";
                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            
                networkStream.Write(responseBytes);
            
                connection.Close();
            }

            Console.ReadLine();
        }
    }
}