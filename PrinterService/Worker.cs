using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using HotBag.AspNetCore.WebPrintService.Service;
using HotBag.AspNetCore.WebPrintService.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HotBag.AspNetCore.WebPrintService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
         
        private TcpListener listener;
        private ApplicationConfig config;

        public TCPHelper _helper { set; get; }
        public IConfiguration _configuration { get; }

        public Worker(ILogger<Worker> logger, TCPHelper helper, IConfiguration configuration)
        {
            _logger = logger;
            _helper = helper;
            _configuration = configuration;
            config = ApplicationConfig.Instance;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("The service has been started...");

            //setup printer name

            string printerNameLocation = _configuration.GetSection("PrinterConfig:PrinterSetupLocation").Value;
            config.SetTCPIpAddress(_configuration.GetSection("TCP:IPAddress").Value);
            config.SetTCPPort(_configuration.GetSection("TCP:Port").Value); 

            _logger.LogInformation($"Printer name configuring form Location : ");
            _logger.LogInformation($"{printerNameLocation}\\Printer.dat");
             
            if (System.IO.File.Exists(Path.Combine(printerNameLocation, "Printer.dat")))
            {
                string printerName = System.IO.File.ReadAllText(Path.Combine(printerNameLocation, "Printer.dat"));
                config.SetPrinterName(printerName);
            }
            else
            {
                _logger.LogError($"NO Configuration found in location: ");
                _logger.LogError($"{printerNameLocation}\\Printer.dat");
                //throw new Exception("Printer not found");
            }

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        { 
            _logger.LogInformation("The service has been stopped..."); 
            listener.Stop(); 

            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            listener = new TcpListener(IPAddress.Parse(config.TcpIpAddress), config.TcpPort);
            listener.Start();
            _logger.LogInformation($"Server has started on {config.TcpIpAddress}:{config.TcpPort}");
            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                TcpClient state = await listener.AcceptTcpClientAsync(); 
                ThreadPool.QueueUserWorkItem(new WaitCallback(_helper.WebPrinterTCPClient), state);
            }
        }

    }
}
