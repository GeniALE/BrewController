using System;
using BrewController.OpcUA;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BrewController;

public static class Program
{
    public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

        if (Environment.GetEnvironmentVariable("BREW_DISABLE_OPCUA") is null)
            builder.ConfigureServices(services =>
            {
                services.AddHostedService<BrewListener>();
            });

        return builder;
    }
}