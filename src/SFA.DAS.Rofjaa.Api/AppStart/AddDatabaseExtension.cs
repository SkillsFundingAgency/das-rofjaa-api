using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SFA.DAS.Rofjaa.Data;
using SFA.DAS.Rofjaa.Domain.Configuration;

namespace SFA.DAS.Rofjaa.Api.AppStart;

[ExcludeFromCodeCoverage]
public static class AddDatabaseExtension
{
    public static void AddDatabaseRegistration(this IServiceCollection services, RofjaaConfiguration config, string environmentName)
    {
        if (environmentName.Equals("DEV", StringComparison.CurrentCultureIgnoreCase))
        {
            services.AddDbContext<RofjaaDataContext>(options => options.UseInMemoryDatabase("SFA.DAS.Rofjaa"), ServiceLifetime.Transient);
        }
        else if (environmentName.Equals("LOCAL", StringComparison.CurrentCultureIgnoreCase))
        {
            services.AddDbContext<RofjaaDataContext>(options=>options.UseSqlServer(config.ConnectionString),ServiceLifetime.Transient);
        }
        else
        {
            services.AddSingleton(new AzureServiceTokenProvider());
            services.AddDbContext<RofjaaDataContext>(ServiceLifetime.Transient);    
        }
            
        services.AddTransient<IRofjaaDataContext, RofjaaDataContext>(provider => provider.GetService<RofjaaDataContext>());
        services.AddTransient(provider => new Lazy<RofjaaDataContext>(provider.GetService<RofjaaDataContext>()));
    }
}
