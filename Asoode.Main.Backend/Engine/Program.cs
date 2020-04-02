﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Net;
using Asoode.Main.Backend.Engine;
using Asoode.Main.Core.Contracts.General;

// ReSharper disable once CheckNamespace
namespace Asoode.Main.Backend
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var configuration = scope.ServiceProvider.GetService<IConfiguration>();
                    var serverInfo = scope.ServiceProvider.GetService<IServerInfo>();
                    serverInfo.RootPath = configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
                    serverInfo.ContentRootPath = Path.Combine(serverInfo.RootPath, "wwwroot");
                    serverInfo.FilesRootPath = Path.Combine(serverInfo.ContentRootPath, "storage");
                    serverInfo.I18nRootPath = Path.Combine(serverInfo.RootPath, "I18n");
                    serverInfo.EmailsRootPath = Path.Combine(serverInfo.RootPath, "templates/email");
                    serverInfo.SmsRootPath = Path.Combine(serverInfo.RootPath, "templates/sms");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            host.Run();
        }

        private static IHost BuildWebHost(string[] args)
        {
            var config = new ConfigurationBuilder().AddCommandLine(args).Build();
            var ip = config.GetValue<string>("ip") ?? "0.0.0.0";
            var httpPort = config.GetValue<int?>("port") ?? 5000;
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((hostingContext, cfg) =>
                        {
                            cfg.AddJsonFile("appSetting.json", false, false);
                        })
                        .UseKestrel(options =>
                        {
                            options.Limits.MaxRequestBodySize = 1048576000; //1024MB
                            options.Listen(IPAddress.Parse(ip), httpPort);
                        })
                        .UseStartup<Startup>();
                }).Build();
        }
    }
}