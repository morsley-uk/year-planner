using Morsley.UK.YearPlanner.Domain.Enumerations;
using System;
using System.Collections.Generic;

namespace Morsley.UK.YearPlanner.Domain.Interfaces
{
    public interface IDay
    {
        int Value { get; }

        IMonth Month { get; }

        string Name { get; }

        DayOfWeek DayOfWeek { get; }

        IEnumerable<IHour> Hours { get; }

        IList<DayMode> Modes { get; }
    }
}