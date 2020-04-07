using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotBag.AspNetCore.WebPrintService.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace HotBag.AspNetCore.WebPrintService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(@"C:\temp\HotBag\WebPrintingService\LogFile.txt")
                .CreateLogger();

            try
            {
                Log.Information("Starting up the application"); 
                CreateHostBuilder(args).Build().Run();
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "There was a problem starting the serivce");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddSingleton<TCPHelper>();
                })
                .UseSerilog();
        }
    }
}
