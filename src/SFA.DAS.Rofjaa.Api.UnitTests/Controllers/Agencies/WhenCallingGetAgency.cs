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
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.Rofjaa.Api.UnitTests.Controllers.Agency
{
    public class WhenCallingGetAgency
    {
        [Test, MoqAutoData]
        public async Task Then_Gets_Agency_From_Mediator(
            int agencyId,
            GetAgencyResult queryResult,
            [Frozen] Mock<IMediator> mockMediator,
            [Greedy] AgenciesController controller)
        {
            mockMediator
                .Setup(mediator => mediator.Send(
                    It.Is<GetAgencyQuery>(c=>c.LegalIdentityId.Equals(agencyId)), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(queryResult);

            var controllerResult = await controller.Get(agencyId) as ObjectResult;

            var model = controllerResult.Value as GetAgencyResponse;
            controllerResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
            model.Should().BeEquivalentTo(queryResult.Agency);
        }

        [Test, MoqAutoData]
        public async Task And_No_Result_Then_Returns_Not_Found(
            int agencyId,
            GetAgencyResult queryResult,
            [Frozen] Mock<IMediator> mockMediator,
            [Greedy] AgenciesController controller)
        {
            queryResult.Agency = null;
            mockMediator
                .Setup(mediator => mediator.Send(
                    It.IsAny<GetAgencyQuery>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(queryResult);

            var controllerResult = await controller.Get(agencyId) as StatusCodeResult;

            controllerResult.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }
    }
}
