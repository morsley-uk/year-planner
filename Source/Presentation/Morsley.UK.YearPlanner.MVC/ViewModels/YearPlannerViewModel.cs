using Morsley.UK.YearPlanner.Domain.Enumerations;
using Morsley.UK.YearPlanner.Domain.Helpers;
using Morsley.UK.YearPlanner.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Morsley.UK.YearPlanner.MVC.ViewModels
{
    public class YearPlannerViewModel
    {
        public YearPlannerViewModel(IYear year)
        {
            Year = year;
            var yearHelper = new YearHelper(year);
            LeftOffsets = yearHelper.LeftColumnOffsets;
            RightOffsets = yearHelper.RightColumnOffsets;
            Header = yearHelper.Header;
        }

        public IYear Year { get; }

        public IList<DayOfWeek> Header { get; }

        public Dictionary<int, int> LeftOffsets { get; }

        public Dictionary<int, int> RightOffsets { get; }

        public DateTime Today
        {
            set
            {
                if (value.Year != Year.Value) return;
                var month = Year.Months.Single(x => x.Value == value.Month);
                var day = month.Days.Single(x => x.Value == value.Day);
                day.Modes.Add(DayMode.Today);
            }
        }
    }
}