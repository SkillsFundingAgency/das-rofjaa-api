using System.Collections.Generic;

namespace SFA.DAS.Rofjaa.Application.Models;

public abstract class QueryResult<T>
{
    public List<T> Items { get; set; }
}
