using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.NUnit3;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Api.ApiResponses;
using SFA.DAS.Rofjaa.Api.Controllers;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.Rofjaa.Api.UnitTests.Controllers.Agencies
{
    public class WhenCallingGetAgencies
    {
        [Test, MoqAutoData]
        public async Task Then_Gets_Agencies_List_From_Mediator(
            GetAgencyResult queryResult,
            [Frozen] Mock<IMediator> mockMediator,
            [Greedy] AgenciesController controller)
        {
            mockMediator
                .Setup(mediator => mediator.Send(
                    It.IsAny<GetAgenciesQuery>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(queryResult);

            var controllerResult = await controller.GetList() as ObjectResult;

            var model = controllerResult.Value as GetAgenciesResponse;
            controllerResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
            model.Agencies.Should().BeEquivalentTo(queryResult.Agency);
            
        }
    }
}
