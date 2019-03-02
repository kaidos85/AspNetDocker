using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;

namespace AspCoreDocker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LogInit();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(c => c.ClearProviders())
                .UseSerilog();

        static void LogInit()
        {
            string appLoc = Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(appLoc);
            var date = DateTime.Now.ToString("MMMM");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File($"{path}\\logs\\{date}\\.log", 
                                rollingInterval: RollingInterval.Day)
                                .CreateLogger();
        }
    }
}
