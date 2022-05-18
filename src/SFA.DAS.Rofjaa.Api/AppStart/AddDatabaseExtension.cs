using System;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SFA.DAS.Rofjaa.Data;
using SFA.DAS.Rofjaa.Domain.Configuration;

namespace SFA.DAS.Rofjaa.Api.AppStart
{
    public static class AddDatabaseExtension
    {
        public static void AddDatabaseRegistration(this IServiceCollection services, FjaaConfiguration config, string environmentName)
        {
            if (environmentName.Equals("DEV", StringComparison.CurrentCultureIgnoreCase))
            {
                services.AddDbContext<FjaaDataContext>(options => options.UseInMemoryDatabase("SFA.DAS.Rofjaa"), ServiceLifetime.Transient);
            }
            else if (environmentName.Equals("LOCAL", StringComparison.CurrentCultureIgnoreCase))
            {
                services.AddDbContext<FjaaDataContext>(options=>options.UseSqlServer(config.ConnectionString),ServiceLifetime.Transient);
            }
            else
            {
                services.AddSingleton(new AzureServiceTokenProvider());
                services.AddDbContext<FjaaDataContext>(ServiceLifetime.Transient);    
            }
            
            services.AddTransient<IFjaaDataContext, FjaaDataContext>(provider => provider.GetService<FjaaDataContext>());
            services.AddTransient(provider => new Lazy<FjaaDataContext>(provider.GetService<FjaaDataContext>()));
            
        }
    }
}
