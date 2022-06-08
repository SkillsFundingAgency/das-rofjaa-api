using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Data;

namespace SFA.DAS.Rofjaa.Application.UnitTests.DataFixture
{
    public class RofjaaDbContextFixture
    {
        [SetUp]
        public void BaseSetup()
        {
            var options = new DbContextOptionsBuilder<RofjaaDataContext>()
                .UseInMemoryDatabase($"SFA.DAS.Rofjaa.Database_{DateTime.UtcNow.ToFileTimeUtc()}")
                .Options;

            DbContext = new RofjaaDataContext(options);
        }

        public RofjaaDataContext DbContext { get; private set; }
    }
}
