using Morsley.UK.YearPlanner.Domain.Helpers;
using Morsley.UK.YearPlanner.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Morsley.UK.YearPlanner.Domain.Models
{
    public class Month : IMonth
    {
        public Month(IYear year, int value)
        {
            if (year is null) throw new ArgumentNullException(nameof(year) ,"Cannot be null.");
            if (value < 1) throw new ArgumentOutOfRangeException(nameof(value), "Cannot be less than 1.");
            if (value > 12) throw new ArgumentOutOfRangeException(nameof(value), "Cannot be greater than 12.");

            Year = year;
            Value = value;            
        }

        public IYear Year { get; }

        public int Value { get; }

        private string _name;

        public string Name
        {
            get
            {
                if (!(_name is null)) return _name;
                _name = DateHelper.GetMonthName(Year.Value, Value);
                return _name;
            }
        }

        private IEnumerable<IDay> _days;

        public IEnumerable<IDay> Days
        {
            get
            {
                if (!(_days is null)) return _days;
                AddDays(Year.Value, Value);
                return _days;
            }
        }

        private void AddDays(int year, int month)
        {
            var days = new List<IDay>();
            for (int i = 1; i <= DateHelper.GetNumberOfDaysInMonth(year, month); i++)
            {                
                days.Add(new Day(this, i));
            }
            _days = days;
        }
    }
}