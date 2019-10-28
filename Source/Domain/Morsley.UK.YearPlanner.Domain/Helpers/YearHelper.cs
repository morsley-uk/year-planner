using Morsley.UK.YearPlanner.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Morsley.UK.YearPlanner.Domain.Helpers
{
    public class YearHelper
    {
        public IYear Year { get; }

        public IList<DayOfWeek> Header { get; }

        public Dictionary<int, int> LeftColumnOffsets { get; }

        public Dictionary<int, int> RightColumnOffsets { get; }

        public int NumberOfColumns { get; }

        public YearHelper(IYear year)
        {
            if (year == null) throw new ArgumentNullException(nameof(year), "Cannot be null.");

            Year = year;
            LeftColumnOffsets = DetermineLeftColumnOffsets(year);
            NumberOfColumns = DetermineNumberOfColumns(year, LeftColumnOffsets);
            RightColumnOffsets = DetermineRightColumnOffsets(year, LeftColumnOffsets, NumberOfColumns);            
            Header = DetermineHeader(year, LeftColumnOffsets, NumberOfColumns);
        }

        private IList<DayOfWeek> DetermineHeader(IYear year, IReadOnlyDictionary<int, int> leftColumnOffsets, int lengthOfHeader)
        {
            var header = new List<DayOfWeek>();

            var nextDayOfWeek = DetermineFirstDayOfWeekOfMonth(year, leftColumnOffsets);
            for (int i = 0; i < lengthOfHeader; i++)
            {
                header.Add(nextDayOfWeek);
                nextDayOfWeek = GetNextDayOfWeek(nextDayOfWeek);
            }

            return header;
        }

        private int DetermineLeftOffset(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday: return 0;
                case DayOfWeek.Tuesday: return 1;
                case DayOfWeek.Wednesday: return 2;
                case DayOfWeek.Thursday: return 3;
                case DayOfWeek.Friday: return 4;
                case DayOfWeek.Saturday: return 5;
                case DayOfWeek.Sunday: return 6;
            }
            throw new InvalidOperationException("There's no way we should ever be here!");
        }

        private Dictionary<int, int> DetermineLeftColumnOffsets(IYear year)
        {
            var offsets = new Dictionary<int, int>();

            foreach (var month in year.Months)
            {
                var day = month.Days.First(x => x.Value == 1);
                var offset = DetermineLeftOffset(day.DayOfWeek);
                offsets.Add(month.Value, offset);
            }

            return offsets;
        }

        private int DetermineNumberOfColumns(IYear year, IReadOnlyDictionary<int, int> leftColumnOffsets)
        {
            var numberOfColumns = 0;

            foreach (var month in year.Months)
            {
                var day = month.Days.OrderBy(x => x.Value).Last();
                var leftOffset = leftColumnOffsets[month.Value];
                var rightDayIncludingLeftOffset = day.Value + leftOffset;
                if (month.Value == 1)
                {
                    numberOfColumns = rightDayIncludingLeftOffset;
                }
                else
                {
                    if (rightDayIncludingLeftOffset > numberOfColumns)
                    {
                        numberOfColumns = rightDayIncludingLeftOffset;
                    }
                }
            }

            return numberOfColumns;
        }

        private Dictionary<int, int> DetermineRightColumnOffsets(IYear year, IReadOnlyDictionary<int, int> leftColumnOffsets, int mostRightDayIncludingLeftOffset)
        {
            var rightOffsets = new Dictionary<int, int>();

            foreach (var month in year.Months)
            {
                var day = month.Days.OrderBy(x => x.Value).Last();
                var leftOffset = leftColumnOffsets[month.Value];
                var rightDayIncludingLeftOffset = day.Value + leftOffset;
                var offset = mostRightDayIncludingLeftOffset - rightDayIncludingLeftOffset;
                rightOffsets.Add(month.Value, offset);
            }

            return rightOffsets;
        }

        private DayOfWeek DetermineFirstDayOfWeekOfMonth(IYear year, IReadOnlyDictionary<int, int> leftColumnOffsets)
        {            
            var leftmostOffsetMonth = leftColumnOffsets.First(x => x.Value == 0).Key;
            var firstMonthWithZeroLeftOffset = year.Months.First(x => x.Value == leftmostOffsetMonth);
            return firstMonthWithZeroLeftOffset.Days.First().DayOfWeek;
        }

        private DayOfWeek GetNextDayOfWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday: return DayOfWeek.Tuesday;
                case DayOfWeek.Tuesday: return DayOfWeek.Wednesday;
                case DayOfWeek.Wednesday: return DayOfWeek.Thursday;
                case DayOfWeek.Thursday: return DayOfWeek.Friday;
                case DayOfWeek.Friday: return DayOfWeek.Saturday;
                case DayOfWeek.Saturday: return DayOfWeek.Sunday;
                case DayOfWeek.Sunday: return DayOfWeek.Monday;
            }
            throw new InvalidOperationException("There's no way we should ever be here!");
        }

        #region Methods

        #endregion Methods
    }
}