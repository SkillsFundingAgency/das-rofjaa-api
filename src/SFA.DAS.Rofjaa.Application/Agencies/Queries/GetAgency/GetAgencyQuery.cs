﻿using MediatR;

namespace SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency
{
    public class GetAgencyQuery : IRequest<GetAgencyResult>
    {
        public int LegalEntityId { get ; set ; }
    }
}
