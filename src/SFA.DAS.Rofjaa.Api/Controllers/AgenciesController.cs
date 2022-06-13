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
    [Route("agencies/")]
    public class AgenciesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AgenciesController (IMediator mediator)
        {
            _mediator = mediator;
        }
            
        [HttpGet]
        [Route("{legalEntityId}")]
        public async Task<IActionResult> Get(int legalEntityId)
        {
            var result = await _mediator.Send(new GetAgencyQuery { LegalEntityId = legalEntityId });

            if (result == null) return NotFound();

            var response = (GetAgencyResponse)result;

            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {

            var result = await _mediator.Send(new GetAgenciesQuery());

            var response = new GetAgenciesResponse
            {
                Agencies = result.Items.Select(x => (GetAgenciesResponse.Agency)x)
            };

            return Ok(response);

        }
    }
}
