using System.Collections.Generic;

namespace Morsley.UK.YearPlanner.Domain.Interfaces
{
    public interface IHour
    {
        int Value { get; }

        IDay Day { get; }

        IEnumerable<IMinute> Minutes { get; }
    }
}