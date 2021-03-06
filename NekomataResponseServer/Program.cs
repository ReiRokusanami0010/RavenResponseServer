using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NekomataResponseServer.Services;

namespace NekomataResponseServer {
    public class Program {
        public static void Main(string[] args) {
            ArgParseService.Decomposition(args);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    IConfigurationRoot configuration = new ConfigurationBuilder()
                        .AddCommandLine(args)
                        .Build();

                    string hosturl = configuration["hosturl"];

                    if (string.IsNullOrEmpty(hosturl)) {
                        hosturl = "http://0.0.0.0:5000";
                    }

                    webBuilder.UseUrls(hosturl);
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseConfiguration(configuration);
                });
    }
}