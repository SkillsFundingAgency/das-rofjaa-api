using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using SFA.DAS.Rofjaa.Data.Repository;
using SFA.DAS.Rofjaa.Domain.Interfaces;

namespace SFA.DAS.Rofjaa.Api.AppStart
{
    [ExcludeFromCodeCoverage]
    public static class AddServiceRegistrationExtension
    {
        public static void AddServiceRegistration(this IServiceCollection services)
        {   
            AddDatabaseRegistrations(services);
        }

        private static void AddDatabaseRegistrations(IServiceCollection services)
        {
            services.AddTransient<IAgencyRepository, AgencyRepository>();
        }
    }
}
