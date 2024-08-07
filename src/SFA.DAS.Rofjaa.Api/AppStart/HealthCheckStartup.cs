﻿using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using SFA.DAS.Api.Common.Infrastructure;

namespace SFA.DAS.Rofjaa.Api.AppStart;

public static class HealthCheckStartup
{
    [ExcludeFromCodeCoverage]
    public static IApplicationBuilder UseHealthChecks(this IApplicationBuilder app)
    {
        app.UseHealthChecks("/health", new HealthCheckOptions
        {
            ResponseWriter = HealthCheckResponseWriter.WriteJsonResponse
        });
            
        app.UseHealthChecks("/ping", new HealthCheckOptions
        {
            Predicate = _ => false,
            ResponseWriter = (context, _) => 
            {
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync("");
            }
        });

        return app;
    }
}
