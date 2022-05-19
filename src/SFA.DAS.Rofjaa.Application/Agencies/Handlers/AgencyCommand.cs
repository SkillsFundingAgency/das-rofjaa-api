using MediatR;

namespace SFA.DAS.Rofjaa.Application.Agencies.Handlers
{
    public class AgencyCommand : IRequest<Unit>
    {
        public AgencyCommand()
        {
        }
    }
}