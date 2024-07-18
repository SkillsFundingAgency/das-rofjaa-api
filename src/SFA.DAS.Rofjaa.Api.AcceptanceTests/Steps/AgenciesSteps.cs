using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Api.AcceptanceTests.Infrastructure;
using SFA.DAS.Rofjaa.Api.ApiResponses;
using TechTalk.SpecFlow;

namespace SFA.DAS.Rofjaa.Api.AcceptanceTests.Steps;

[Binding]
public class AgencySteps
{
    private readonly ScenarioContext _context;

    public AgencySteps(ScenarioContext context)
    {
        _context = context;
    }

    [Then("all agencies are returned")]
    public async Task ThenAllAgenciesReturned()
    {
        if (!_context.TryGetValue<HttpResponseMessage>(ContextKeys.HttpResponse, out var result))
        {
            Assert.Fail($"scenario context does not contain value for key [{ContextKeys.HttpResponse}]");
        }

        var model = await HttpUtilities.ReadContent<GetAgenciesResponse>(result.Content);
        var expected = DbUtilities.GetAgencies();

        expected.Should().BeEquivalentTo(model.Agencies);
    }

    [Then("the agency with id equal to 1 is returned")]
    public async Task ThenAgencyIsReturned()
    {
        if (!_context.TryGetValue<HttpResponseMessage>(ContextKeys.HttpResponse, out var result))
        {
            Assert.Fail($"scenario context does not contain value for key [{ContextKeys.HttpResponse}]");
        }

        var model = await HttpUtilities.ReadContent<GetAgencyResponse>(result.Content);
        var expected = DbUtilities.GetAgency(1);

        expected.Should().BeEquivalentTo(model);
    }
}
