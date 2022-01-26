using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Routing;

namespace BasicWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;
        
        private readonly RoutingTable routingTable;

        public HttpServer(
            string _ipAddress, 
            int _port, 
            Action<IRoutingTable> routingTableConfiguration )
        {
            ipAddress = IPAddress.Parse(_ipAddress);
            port = _port;
            
            serverListener = new TcpListener(ipAddress, port);
            
            routingTableConfiguration(this.routingTable = new RoutingTable());
        }

        public HttpServer(int port, Action<IRoutingTable> routingTable)
            :this("127.0.0.1", port, routingTable)
        {
            
        }

        public HttpServer(Action<IRoutingTable> routingTable)
            :this(8080, routingTable)
        {
            
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

                var request = Request.Parse(requestString);

                var response = this.routingTable.MatchRequest(request);
                
                WriteResponse(networkStream, response);

                connection.Close();
            }
        }

        public void WriteResponse(NetworkStream networkStream, Response response)
        {
            byte[] responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            networkStream.Write(responseBytes);
        }
    }
}