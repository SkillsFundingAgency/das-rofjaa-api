using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Api.AcceptanceTests.Infrastructure;
using SFA.DAS.Rofjaa.Api.ApiResponses;
using TechTalk.SpecFlow;

namespace SFA.DAS.Rofjaa.Api.AcceptanceTests.Steps
{
    [Binding]
    public class RouteSteps
    {
        private readonly ScenarioContext _context;

        public RouteSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Then("all routes are returned")]
        public async Task ThenAllRoutesAreReturned()
        {
            if (!_context.TryGetValue<HttpResponseMessage>(ContextKeys.HttpResponse, out var result))
            {
                Assert.Fail($"scenario context does not contain value for key [{ContextKeys.HttpResponse}]");
            }

            var model = await HttpUtilities.ReadContent<GetRoutesListResponse>(result.Content);

            model.Routes.Should().BeEquivalentTo(DbUtilities.GetTestRoutes().ToList(), config => 
                config.Excluding(route => route.Standards));
        }
    }
}