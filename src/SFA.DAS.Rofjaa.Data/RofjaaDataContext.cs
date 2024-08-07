﻿using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SFA.DAS.Rofjaa.Domain.Configuration;
using SFA.DAS.Rofjaa.Domain.Entities;

namespace SFA.DAS.Rofjaa.Data;

public interface IRofjaaDataContext
{
    DbSet<Agency> Agency { get; set; }
    
    int SaveChanges();
}

[ExcludeFromCodeCoverage]
public class RofjaaDataContext : DbContext, IRofjaaDataContext
{
    private const string AzureResource = "https://database.windows.net/";

    public DbSet<Agency> Agency { get; set; }

    private readonly RofjaaConfiguration _configuration;
    private readonly AzureServiceTokenProvider _azureServiceTokenProvider;
     
    public RofjaaDataContext()
    {
    }

    public RofjaaDataContext(DbContextOptions options) : base(options)
    {
    }
        
    public RofjaaDataContext(IOptions<RofjaaConfiguration> config, DbContextOptions options, AzureServiceTokenProvider azureServiceTokenProvider) :base(options)
    {
        _configuration = config.Value;
        _azureServiceTokenProvider = azureServiceTokenProvider;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
            
        if (_configuration == null || _azureServiceTokenProvider == null)
        {
            return;
        }
            
        var connection = new SqlConnection
        {
            ConnectionString = _configuration.ConnectionString,
            AccessToken = _azureServiceTokenProvider.GetAccessTokenAsync(AzureResource).Result,
        };
            
        optionsBuilder.UseSqlServer(connection,options=>
            options.EnableRetryOnFailure(
                5,
                TimeSpan.FromSeconds(20),
                null
            ));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configuration.Agency());
        base.OnModelCreating(modelBuilder);
    }
}
