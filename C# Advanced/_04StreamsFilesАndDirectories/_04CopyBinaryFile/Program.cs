using System;
using System.IO;
using System.Threading.Tasks;

namespace _04CopyBinaryFile
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const int BUFFER_SIZE = 4096;
            using (FileStream reader = new FileStream("copyMe.png", FileMode.Open))
            using (FileStream writer = new FileStream("../../../copy.png", FileMode.Create))

            while (reader.CanRead)
            {
                byte[] buffer = new byte[BUFFER_SIZE];
                int readBytes = await reader.ReadAsync(buffer, 0, buffer.Length);
                
                if (readBytes == 0)
                {
                    break;
                }
                
                await writer.WriteAsync(buffer, 0, readBytes);
            }


        }
    }
}