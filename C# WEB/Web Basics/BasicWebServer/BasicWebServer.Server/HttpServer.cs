using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
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

        private static void AddSession(Request request, Response response)
        {
            var sessionExists = request.Session.ContainsKey(Session.SessionCurrentDateKey);

            if (!sessionExists)
            {
                request.Session[Session.SessionCurrentDateKey] = DateTime.Now.ToString();
                response.Cookies.Add(Session.SessionCookieName, request.Session.Id);
            }
        }
        
        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            int bufferLength = 1024;
            byte[] buffer = new byte[bufferLength];

            int totalBytes = 0;
            
            var requestBuilder = new StringBuilder();

            do
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);

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

        public async Task Start()
        {
            serverListener.Start();
            
            Console.WriteLine($"Server started on port {port}");
            Console.WriteLine("Listening for requests...");
            
            while (true)
            {
                var connection = await serverListener.AcceptTcpClientAsync();

                _ = Task.Run(async () =>
                {
                    var networkStream = connection.GetStream();

                    var requestString = await ReadRequest(networkStream);
                    Console.WriteLine(requestString);

                    var request = Request.Parse(requestString);

                    var response = this.routingTable.MatchRequest(request);

                    AddSession(request, response);
                    
                    await WriteResponse(networkStream, response);

                    connection.Close();
                });

            }
        }

        public async Task WriteResponse(NetworkStream networkStream, Response response)
        {
            byte[] responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            await networkStream.WriteAsync(responseBytes);
        }
    }
}