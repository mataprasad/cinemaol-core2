using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CinemaOL.Core
{
    public class Program
    {
        private static string ASPNETCORE_URLS=string.Empty;
        public static void Main(string[] args)
        {
            ASPNETCORE_URLS=Environment.GetEnvironmentVariable("ASPNETCORE_URLS");
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)            
                .UseStartup<Startup>()
                .UseUrls(ASPNETCORE_URLS)
                .Build();
    }
}
