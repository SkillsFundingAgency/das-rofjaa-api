using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SFA.DAS.Api.Common.AppStart;
using SFA.DAS.Api.Common.Configuration;
using SFA.DAS.Api.Common.Infrastructure;
using SFA.DAS.Rofjaa.Api.AppStart;
using SFA.DAS.Rofjaa.Api.Infrastructure;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;
using SFA.DAS.Rofjaa.Application.Common.DateTime;
using SFA.DAS.Rofjaa.Data;
using SFA.DAS.Rofjaa.Domain.Configuration;

namespace SFA.DAS.Rofjaa.Api;

[ExcludeFromCodeCoverage]
public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration.BuildDasConfiguration();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddConfigurationOptions(_configuration);

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        var rofjaaConfiguration = _configuration
            .GetSection(ConfigurationKeys.Rofjaa)
            .Get<RofjaaConfiguration>();

        if (!_configuration.IsLocalOrDev())
        {
            var azureAdConfiguration = _configuration
                .GetSection(ConfigurationKeys.AzureAd)
                .Get<AzureActiveDirectoryConfiguration>();

            var policies = new Dictionary<string, string> { { PolicyNames.Default, RoleNames.Default } };

            services.AddAuthentication(azureAdConfiguration, policies);
        }

        if (!_configuration.IsDev())
        {
            services.AddHealthChecks()
                .AddDbContextCheck<RofjaaDataContext>();
        }

        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(GetAgencyResult).Assembly));

        services.AddDatabaseRegistration(rofjaaConfiguration, _configuration["EnvironmentName"]);

        services.AddMvc(options =>
        {
            if (!_configuration.IsLocalOrDev())
            {
                options.Conventions.Add(new AuthorizeControllerModelConvention(new List<string> { PolicyNames.DataLoad }));
            }

            options.Conventions.Add(new ApiExplorerGroupPerVersionConvention());
        }).AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        services.AddApplicationInsightsTelemetry(_configuration["APPINSIGHTS_INSTRUMENTATIONKEY"]);

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "RofjaaApi", Version = "v1" });
            c.SwaggerDoc("operations", new OpenApiInfo { Title = "RofjaaApi operations" });
            c.OperationFilter<SwaggerVersionHeaderFilter>();
        });

        services.AddApiVersioning(opt =>
        {
            opt.ApiVersionReader = new HeaderApiVersionReader("X-Version");
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoursesAPI v1");
            c.SwaggerEndpoint("/swagger/operations/swagger.json", "Operations v1");
            c.RoutePrefix = string.Empty;
        });

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.ConfigureExceptionHandler(logger);

        app.UseAuthentication();

        if (!_configuration.IsDev())
        {
            app.UseHealthChecks();
        }

        app.UseRouting();
        app.UseEndpoints(builder =>
        {
            builder.MapControllerRoute(
                name: "default",
                pattern: "api/{controller=Agencies}/{action=Index}/{id?}");
        });
    }
}
