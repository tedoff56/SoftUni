﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BasicWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;

        public HttpServer(string _ipAddress, int _port)
        {
            ipAddress = IPAddress.Parse(_ipAddress);
            port = _port;

            serverListener = new TcpListener(ipAddress, port);
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            int bufferLength = 1024;
            byte[] buffer = new byte[bufferLength];

            int totalBytes = 0;
            
            var requestBuilder = new StringBuilder();

            do
            {
                var bytesRead = networkStream.Read(buffer, 0, bufferLength);

                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large");
                }
                
                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            } 
            while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }

        public void Start()
        {
            serverListener.Start();
            
            Console.WriteLine($"Server started on port {port}");
            Console.WriteLine("Listening for requests...");
            
            while (true)
            {
                var connection = serverListener.AcceptTcpClient();

                var networkStream = connection.GetStream();

                var requestString = ReadRequest(networkStream);
                Console.WriteLine(requestString);
                
                WriteResponse(networkStream, "My first http server");

                connection.Close();
            }
        }

        public void WriteResponse(NetworkStream networkStream, string content)
        {
            int contentLength = Encoding.UTF8.GetByteCount(content);
            
            string response = $@"HTTP/1.1 200 OK
Content-Type: text/plain; charset: UTF-8
Content-Length: {contentLength}

{content}";
            
            byte[] responseBytes = Encoding.UTF8.GetBytes(response);

            networkStream.Write(responseBytes);
        }
    }
}