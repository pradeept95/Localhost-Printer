using HotBag.AspNetCore.WebPrintService.Settings;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace HotBag.AspNetCore.WebPrintService.Service
{
    public class TCPHelper 
    {
        private readonly ILogger<TCPHelper> _logger;
        private ApplicationConfig config;
        public TCPHelper(ILogger<TCPHelper> logger)
        {
            _logger = logger;
            config = ApplicationConfig.Instance;
        }    

        public void WebPrinterTCPClient(object c)
        {
            TcpClient client = (TcpClient)c;
            Console.WriteLine("A client connected.");
            NetworkStream stream = client.GetStream();
            while (true)
            {
                if (client.Available >= 3)
                {
                    byte[] buffer = new byte[client.Available];
                    stream.Read(buffer, 0, buffer.Length);
                    string input = Encoding.UTF8.GetString(buffer);
                    if (Regex.IsMatch(input, "^GET"))
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes("HTTP/1.1 101 Switching Protocols\r\nConnection: Upgrade\r\nUpgrade: websocket\r\nSec-WebSocket-Accept: " + Convert.ToBase64String(SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(new Regex("Sec-WebSocket-Key: (.*)").Match(input).Groups[1].Value.Trim() + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"))) + "\r\n\r\n");
                        stream.Write(bytes, 0, bytes.Length);
                    }
                    bool flag = true;
                    while (flag)
                    {
                        while (true)
                        {
                            if (stream.DataAvailable)
                            {
                                byte[] buffer3 = new byte[client.Available];
                                stream.Read(buffer3, 0, buffer3.Length);
                                int num = buffer3[1] - 0x80;
                                int index = 2;
                                if (num == 0x7e)
                                {
                                    byte[] array = new byte[] { buffer3[2], buffer3[3] };
                                    if (BitConverter.IsLittleEndian)
                                    {
                                        Array.Reverse(array);
                                    }
                                    num = BitConverter.ToInt16(array, 0);
                                    index = 4;
                                }
                                byte[] bytes = new byte[num];
                                byte[] buffer5 = new byte[num];
                                byte[] buffer6 = new byte[] { buffer3[index], buffer3[index + 1], buffer3[index + 2], buffer3[index + 3] };
                                int num3 = 0;
                                while (true)
                                {
                                    if (num3 >= num)
                                    {
                                        int num4 = 0;
                                        while (true)
                                        {
                                            if (num4 >= buffer5.Length)
                                            {
                                                _logger.LogInformation(config.GetPrinterName());
                                                _logger.LogInformation(Encoding.ASCII.GetString(bytes));

                                                PrinterService.SendStringToPrinter(config.GetPrinterName(), Encoding.ASCII.GetString(bytes), "HotBag_PrintingInvoice");
                                                client.Close();
                                                flag = false;
                                                break;
                                            }
                                            bytes[num4] = (byte)(buffer5[num4] ^ buffer6[num4 % 4]);
                                            num4++;
                                        }
                                        break;
                                    }
                                    buffer5[num3] = buffer3[(num3 + index) + 4];
                                    num3++;
                                }
                                break;
                            }
                        }
                    }
                    return;
                }
            }
        }
    }

}
