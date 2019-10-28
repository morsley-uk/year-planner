using System.Collections.Generic;

namespace Morsley.UK.YearPlanner.Domain.Interfaces
{
    public interface IMonth
    {
        int Value { get; }

        string Name { get; }

        IYear Year { get; }

        IEnumerable<IDay> Days { get; }
    }
}