using Microsoft.Extensions.DependencyInjection;
using SFA.DAS.Rofjaa.Application.Agencies.Services;
using SFA.DAS.Rofjaa.Data.Repository;
using SFA.DAS.Rofjaa.Domain.Interfaces;

namespace SFA.DAS.Rofjaa.Api.AppStart
{
    public static class AddServiceRegistrationExtension
    {
        public static void AddServiceRegistration(this IServiceCollection services)
        {
            services.AddTransient<IAgencyService, AgenciesService>();
            
            AddDatabaseRegistrations(services);
        }

        private static void AddDatabaseRegistrations(IServiceCollection services)
        {
            services.AddTransient<IAgencyRepository, AgencyRepository>();
        }
    }
}
