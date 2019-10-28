using Morsley.UK.YearPlanner.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Morsley.UK.YearPlanner.Domain.Models
{
    public class Hour : IHour
    {
        public Hour(IDay day, int value)
        {
            if (day == null) throw new ArgumentOutOfRangeException(nameof(day), "Cannot be null.");
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(day), "Cannot be less than 0.");
            if (value > 23) throw new ArgumentOutOfRangeException(nameof(day), "Cannot be greater than 23.");

            Day = day;
            Value = value;
        }

        public int Value { get; }

        public IDay Day { get; }

        public IEnumerable<IMinute> Minutes { get; }
    }
}