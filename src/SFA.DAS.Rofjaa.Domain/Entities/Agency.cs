﻿using System;

namespace SFA.DAS.Rofjaa.Domain.Entities;

public class Agency
{
    public long LegalEntityId { get; set; }
    public bool IsGrantFunded { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime? EffectiveTo { get; set; }
    public string RemovalReason { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? LastUpdatedDate { get; set; }
}
