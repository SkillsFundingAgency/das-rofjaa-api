using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SFA.DAS.Rofjaa.Api.ApiResponses;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;

namespace SFA.DAS.Rofjaa.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/agencies/[controller]/")]
    public class AgenciesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AgenciesController (IMediator mediator)
        {
            _mediator = mediator;
        }
            
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int legalEntityID)
        {
            var result = await _mediator.Send(new GetAgencyQuery {AgencyId = legalEntityID });

            if (result.Agency == null) return NotFound();

            var response = (GetAgencyResponse)result.Agency;

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var queryResult = await _mediator.Send(new GetAgenciesQuery());

            var response = new GetAgenciesResponse
            {
                Agencies = queryResult.Agency.Select(agency => (GetAgencyResponse)agency),
            };

            return Ok(response);
        }
    }
}
