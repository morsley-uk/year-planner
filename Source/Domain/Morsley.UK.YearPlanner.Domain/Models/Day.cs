using Morsley.UK.YearPlanner.Domain.Enumerations;
using Morsley.UK.YearPlanner.Domain.Helpers;
using Morsley.UK.YearPlanner.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Morsley.UK.YearPlanner.Domain.Models
{
    public class Day : IDay
    {
        private IEnumerable<IHour> _hours;

        public Day(IMonth month, int day)
        {
            Modes = new List<DayMode>();

            if (month == null) throw new ArgumentOutOfRangeException(nameof(month), "Cannot be null.");
            if (day < 1) throw new ArgumentOutOfRangeException(nameof(day), "Cannot be less than 1.");            
            if (day > 31) throw new ArgumentOutOfRangeException(nameof(day), "Cannot be greater than 31.");
            if (day > 28)
            {
                var lastDayOfThisMonth = DateHelper.GetNumberOfDaysInMonth(month.Year.Value, month.Value);
                if (day > lastDayOfThisMonth) throw new ArgumentOutOfRangeException(nameof(day), $"Cannot exceed {lastDayOfThisMonth} for month {month.Value}.");
            }

            Month = month;
            Value = day;
        }

        public IMonth Month { get; }

        public int Value { get; }

        public DayOfWeek DayOfWeek => DateHelper.GetDayOfWeek(Month.Year.Value, Month.Value, Value);

        public string Name => DayOfWeek.ToString();
        
        public IEnumerable<IHour> Hours
        {
            get
            {
                if (_hours != null) return _hours;
                AddHours();
                return _hours;
            }
        }

        public IList<DayMode> Modes { get; }

        private void AddHours()
        {
            var hours = new List<Hour>();
            for (int i = 0; i < 24; i++)
            {
                hours.Add(new Hour(this, i));
            }
            _hours = hours;
        }
    }
}