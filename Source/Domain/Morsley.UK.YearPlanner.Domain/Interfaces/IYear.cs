using System.Collections.Generic;

namespace Morsley.UK.YearPlanner.Domain.Interfaces
{
    public interface IYear
    {
        int Value { get; }

        IEnumerable<IMonth> Months { get; }
    }
}