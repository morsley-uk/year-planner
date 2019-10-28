using Morsley.UK.YearPlanner.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Morsley.UK.YearPlanner.Domain.Models
{
    public class Year : IYear
    {
        public Year(int value)
        {
            if (value < 1) throw new ArgumentOutOfRangeException(nameof(value), "Cannot be less than 1.");
            if (value > 9999) throw new ArgumentOutOfRangeException(nameof(value), "Cannot be greater than 9999.");

            Value = value;
        }

        public int Value { get; }

        private IEnumerable<IMonth> _months;

        public IEnumerable<IMonth> Months
        {
            get
            {
                if (_months != null) return _months;
                PopulateMonths();
                return _months;
            }
        }

        private void PopulateMonths()
        {
            var months = new List<IMonth>();
            for (var i = 1; i <= 12; i++)
            {
                var month = new Month(this, i);
                months.Add(month);
            }
            _months = months;
        }
    }
}