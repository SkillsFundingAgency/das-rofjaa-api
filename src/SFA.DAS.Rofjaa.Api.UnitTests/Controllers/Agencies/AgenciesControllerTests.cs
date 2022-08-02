using AutoFixture;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Api.ApiResponses;
using SFA.DAS.Rofjaa.Api.Controllers;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SFA.DAS.Rofjaa.Api.UnitTests.Controllers
{
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
            _agenciesController = new AgenciesController(_mockMediator.Object);
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
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(notFoundResult.StatusCode, (int)HttpStatusCode.NotFound);
        }

        [Test]
        public async Task Agencies_Outside_Current_Date_Are_Not_Returned()
        {
            // Arrange
            var expectedAgencies = _fixture.CreateMany<GetAgenciesResult.Agency>();

            var result = new GetAgenciesResult()
            {
                Items = expectedAgencies.ToList()
            };

            foreach(var a in result.Items)
            {
                a.EffectiveFrom = new System.DateTime(2010, 01, 01);
                a.EffectiveTo = new System.DateTime(2020, 01, 01);
            }

            _mockMediator
                .Setup(x => x.Send(It.Is<GetAgenciesQuery>(x => x != null), It.IsAny<CancellationToken>()))
                .ReturnsAsync(result);

            // Act
            var actionResult = await _agenciesController.GetList();
            var okObjectResult = actionResult as OkObjectResult;
            var response = okObjectResult.Value as GetAgenciesResponse;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(okObjectResult);
            Assert.IsNotNull(response);
            Assert.AreEqual(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            Assert.AreEqual(expectedAgencies.Count(), response.Agencies.Count());
        }

        [Test]
        public async Task Agencies_Inside_Current_Date_Are_Returned()
        {
            // Arrange
            var expectedAgencies = _fixture.CreateMany<GetAgenciesResult.Agency>();

            var result = new GetAgenciesResult()
            {
                Items = expectedAgencies.ToList()
            };

            foreach(var a in result.Items)
            {
                a.EffectiveFrom = new System.DateTime(2020,01,01);
                a.EffectiveTo = new System.DateTime(2030,01,01);
            }

            _mockMediator
                .Setup(x => x.Send(It.Is<GetAgenciesQuery>(x => x != null), It.IsAny<CancellationToken>()))
                .ReturnsAsync(result);

            // Act
            var actionResult = await _agenciesController.GetList();
            var okObjectResult = actionResult as OkObjectResult;
            var response = okObjectResult.Value as GetAgenciesResponse;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(okObjectResult);
            Assert.IsNotNull(response);
            Assert.AreEqual(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            Assert.AreEqual(expectedAgencies.Count(), response.Agencies.Count());
        }

        [Test]
        public async Task All_Agencies_Returned()
        {
            // Arrange
            var expectedAgencies = _fixture.CreateMany<GetAgenciesResult.Agency>();

            var result = new GetAgenciesResult()
            {
                Items = expectedAgencies.ToList()
            };

            _mockMediator
                .Setup(x => x.Send(It.Is<GetAgenciesQuery>(x => x != null), It.IsAny<CancellationToken>()))
                .ReturnsAsync(result);

            // Act
            var actionResult = await _agenciesController.GetList();
            var okObjectResult = actionResult as OkObjectResult;
            var response = okObjectResult.Value as GetAgenciesResponse;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(okObjectResult);
            Assert.IsNotNull(response);
            Assert.AreEqual(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            Assert.AreEqual(expectedAgencies.Count(), response.Agencies.Count());
        }
    }
}