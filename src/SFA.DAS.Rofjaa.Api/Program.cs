using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;

namespace SFA.DAS.Rofjaa.Api;

[ExcludeFromCodeCoverage]
public static class Program
{
    public static void Main(string[] args)
    {
        LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(builder =>
            {
                builder.UseStartup<Startup>();
            })
            .UseNLog();
}
