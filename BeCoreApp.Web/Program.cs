using BeCoreApp.Data.EF;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;
using System.Reflection;

namespace BeCoreApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var dbInitializer = services.GetService<DbInitializer>();
                    dbInitializer.Seed().Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseSerilog((ctx, config) => {
                       var file = Assembly.GetAssembly(typeof(Program)).Location;
                       var programPath = Path.GetDirectoryName(file);

                       Environment.SetEnvironmentVariable("BASEDIR", programPath);
                       Environment.SetEnvironmentVariable("CURRENTDATE", DateTime.Now.ToString("MM_dd_yyyy"));

                       config.ReadFrom.Configuration(ctx.Configuration);
                   })
                   .UseStartup<Startup>();
    }
}
