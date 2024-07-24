using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SFA.DAS.Rofjaa.Api.ApiResponses;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;

namespace SFA.DAS.Rofjaa.Api.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("agencies/")]
public class AgenciesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Route("{legalEntityId}")]
    public async Task<IActionResult> Get(long legalEntityId)
    {
        var result = await mediator.Send(new GetAgencyQuery { LegalEntityId = legalEntityId });

        if (result == null) return NotFound();

        var response = (GetAgencyResponse)result;

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var result = await mediator.Send(new GetAgenciesQuery());

        var response = new GetAgenciesResponse
        {
            Agencies = result.Items.Select(agency => (GetAgenciesResponse.Agency)agency)
        };

        return Ok(response);
    }
}
