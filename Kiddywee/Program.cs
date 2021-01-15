using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Kiddywee
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseKestrel(options =>
                    //{
                    //    options.Limits.MaxRequestBodySize = long.MaxValue;
                    //});
                    //webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                    //webBuilder.UseUrls("http://localhost:10002");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
