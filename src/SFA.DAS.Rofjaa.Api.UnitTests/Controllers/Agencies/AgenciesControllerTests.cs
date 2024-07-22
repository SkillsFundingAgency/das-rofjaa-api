using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Api.ApiResponses;
using SFA.DAS.Rofjaa.Api.Controllers;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;

namespace SFA.DAS.Rofjaa.Api.UnitTests.Controllers.Agencies;

[TestFixture]
public class AgenciesControllerTests
{
    private Fixture _fixture;
    private Mock<IMediator> _mockMediator;
    private AgenciesController _agenciesController;

    [SetUp]
    public void Setup()
    {
        _fixture = new Fixture();
        _mockMediator = new Mock<IMediator>();
        _agenciesController = new AgenciesController(_mockMediator.Object, Mock.Of<ILogger<AgenciesController>>());
    }

    [Test]
    public async Task Agency_Requested_Doesnt_Exist_NotFound_Returned()
    {
        // Arrange
        var id = _fixture.Create<long>();

        var result = new GetAgenciesResult();

        _mockMediator
            .Setup(x => x.Send(It.Is<GetAgenciesQuery>(x => x != null), It.IsAny<CancellationToken>()))
            .ReturnsAsync(result);

        // Act
        var actionResult = await _agenciesController.Get(id);
        var notFoundResult = actionResult as NotFoundResult;

        // Assert
        actionResult.Should().NotBeNull();
        notFoundResult.Should().NotBeNull();
        notFoundResult.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
    }

    [Test]
    public async Task Agencies_Outside_Current_Date_Are_Not_Returned()
    {
        // Arrange
        var expectedAgencies = _fixture.CreateMany<GetAgenciesResult.Agency>();

        var result = new GetAgenciesResult { Items = expectedAgencies.ToList() };

        foreach (var agency in result.Items)
        {
            agency.EffectiveFrom = new DateTime(2010, 01, 01);
            agency.EffectiveTo = new DateTime(2020, 01, 01);
        }

        _mockMediator
            .Setup(x => x.Send(It.Is<GetAgenciesQuery>(x => x != null), It.IsAny<CancellationToken>()))
            .ReturnsAsync(result);

        // Act
        var actionResult = await _agenciesController.GetList();
        var okObjectResult = actionResult as OkObjectResult;
        var response = okObjectResult.Value as GetAgenciesResponse;

        // Assert
        actionResult.Should().NotBeNull();
        okObjectResult.Should().NotBeNull();
        response.Should().NotBeNull();
        okObjectResult.StatusCode.Should().Be((int)HttpStatusCode.OK);

        response.Agencies.Count().Should().Be(expectedAgencies.Count());
    }

    [Test]
    public async Task Agencies_Inside_Current_Date_Are_Returned()
    {
        // Arrange
        var expectedAgencies = _fixture.CreateMany<GetAgenciesResult.Agency>();

        var result = new GetAgenciesResult { Items = expectedAgencies.ToList() };

        foreach (var agency in result.Items)
        {
            agency.EffectiveFrom = new DateTime(2020, 01, 01);
            agency.EffectiveTo = new DateTime(2030, 01, 01);
        }

        _mockMediator
            .Setup(x => x.Send(It.Is<GetAgenciesQuery>(x => x != null), It.IsAny<CancellationToken>()))
            .ReturnsAsync(result);

        // Act
        var actionResult = await _agenciesController.GetList();
        var okObjectResult = actionResult as OkObjectResult;
        var response = okObjectResult.Value as GetAgenciesResponse;

        // Assert
        actionResult.Should().NotBeNull();
        okObjectResult.Should().NotBeNull();
        response.Should().NotBeNull();
        okObjectResult.StatusCode.Should().Be((int)HttpStatusCode.OK);

        response.Agencies.Count().Should().Be(expectedAgencies.Count());
    }

    [Test]
    public async Task All_Agencies_Returned()
    {
        // Arrange
        var expectedAgencies = _fixture.CreateMany<GetAgenciesResult.Agency>();

        var result = new GetAgenciesResult { Items = expectedAgencies.ToList() };

        _mockMediator
            .Setup(x => x.Send(It.Is<GetAgenciesQuery>(x => x != null), It.IsAny<CancellationToken>()))
            .ReturnsAsync(result);

        // Act
        var actionResult = await _agenciesController.GetList();
        var okObjectResult = actionResult as OkObjectResult;
        var response = okObjectResult.Value as GetAgenciesResponse;

        // Assert
        actionResult.Should().NotBeNull();
        okObjectResult.Should().NotBeNull();
        response.Should().NotBeNull();
        okObjectResult.StatusCode.Should().Be((int)HttpStatusCode.OK);

        response.Agencies.Count().Should().Be(expectedAgencies.Count());
    }
}
