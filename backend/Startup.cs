using System;
using BrewController.OpcUA;
using BrewController.Schema;
using BrewController.Utilities;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

namespace BrewController
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            var mongodbConnectionString = Environment.GetEnvironmentVariable("BREW_DB_URI") ?? "mongodb://root:pass@localhost";

            services
                .AddCors()
                .AddSingleton<BrewClient>()
                .AddInMemorySubscriptions();

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>();

            // setup the database

            var mongoConnectionUrl = new MongoUrl(mongodbConnectionString);
            var mongoClientSettings = MongoClientSettings.FromUrl(mongoConnectionUrl);

            services.AddSingleton(_ =>
            {
                var client = new MongoClient(mongoClientSettings);
                var database = client.GetDatabase("brewdb");
                return database;
            });

            if (Environment.GetEnvironmentVariable("BREW_DISABLE_OPCUA") is null)
                services.AddSingleton<BrewLogger>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app
                    .UseCors(builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            }

            app
                .UseRouting()
                .UseWebSockets()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL()
                        .WithOptions(new GraphQLServerOptions
                            {
                                Tool =
                                {
                                    Enable = env.IsDevelopment(),
                                    DisableTelemetry = true,
                                },
                            });
                });

            if (!env.IsProduction())
                return;

            var appDir = Environment.GetEnvironmentVariable("BREW_APP_DIRECTORY");

            if (appDir == null)
                throw new Exception("Missing BREW_APP_DIRECTORY environment variable");

            app
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapFallbackToFile("/index.html", new StaticFileOptions
                    {
                        FileProvider = new PhysicalFileProvider(appDir),
                        RequestPath = "",
                    });
                });
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(appDir),
                RequestPath = "",
            });
        }
    }
}
