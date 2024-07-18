using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Data;

namespace SFA.DAS.Rofjaa.Application.UnitTests.DataFixture;

public class RofjaaDbContextFixture
{
    protected RofjaaDataContext DbContext { get; private set; }
    
    [SetUp]
    public void BaseSetup()
    {
        var options = new DbContextOptionsBuilder<RofjaaDataContext>()
            .UseInMemoryDatabase($"SFA.DAS.Rofjaa.Database_{DateTime.UtcNow.ToFileTimeUtc()}")
            .Options;

        DbContext = new RofjaaDataContext(options);
    }

    [TearDown]
    public void TearDown() => DbContext?.Dispose();
}
