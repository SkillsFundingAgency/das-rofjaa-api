using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SFA.DAS.Api.Common.Configuration;
using SFA.DAS.Configuration.AzureTableStorage;
using SFA.DAS.Rofjaa.Api.Infrastructure;
using SFA.DAS.Rofjaa.Domain.Configuration;

namespace SFA.DAS.Rofjaa.Api.AppStart;

public static class ConfigurationExtensions
{
    public static IConfiguration BuildDasConfiguration(this IConfiguration configuration)
    {
        var config = new ConfigurationBuilder()
            .AddConfiguration(configuration)
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddEnvironmentVariables();
        
        if (!configuration["EnvironmentName"].Equals("DEV", StringComparison.CurrentCultureIgnoreCase))
        {
#if DEBUG
            config
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile("appsettings.Development.json", true);
#endif

            config.AddAzureTableStorage(options =>
                {
                    options.ConfigurationKeys = configuration["ConfigNames"].Split(",");
                    options.StorageConnectionString = configuration["ConfigurationStorageConnectionString"];
                    options.EnvironmentName = configuration["EnvironmentName"];
                    options.PreFixConfigurationKeys = false;
                }
            );
        }

        return config.Build();
    }

    public static bool IsLocalOrDev(this IConfiguration configuration)
    {
        return configuration.IsDev() ||
               configuration.IsLocal();
    }
    
    public static bool IsDev(this IConfiguration configuration)
    {
        return configuration["EnvironmentName"].Equals("DEV", StringComparison.CurrentCultureIgnoreCase);
    }
    
    public static bool IsLocal(this IConfiguration configuration)
    {
        return configuration["EnvironmentName"].Equals("LOCAL", StringComparison.CurrentCultureIgnoreCase);
    }

    public static IServiceCollection AddConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions();
        services.Configure<RofjaaConfiguration>(configuration.GetSection(ConfigurationKeys.Rofjaa));
        services.AddSingleton(cfg => cfg.GetService<IOptions<RofjaaConfiguration>>().Value);
        services.Configure<AzureActiveDirectoryConfiguration>(configuration.GetSection(ConfigurationKeys.AzureAd));
        services.AddSingleton(cfg => cfg.GetService<IOptions<AzureActiveDirectoryConfiguration>>().Value);

        return services;
    }
}
