using System;

namespace Morsley.UK.YearPlanner.Domain.Helpers
{
    public static class DateHelper
    {
        public static DayOfWeek GetDayOfWeek(int year, int month, int day)
        {
            if (year < 1) throw new ArgumentOutOfRangeException(nameof(year), "Cannot be less than 1.");
            if (year > 9999) throw new ArgumentOutOfRangeException(nameof(year), "Cannot be greater than 9999.");
            if (month < 1) throw new ArgumentOutOfRangeException(nameof(month), "Cannot be less than 1.");
            if (month > 12) throw new ArgumentOutOfRangeException(nameof(month), "Cannot be greater than 12.");
            if (day < 1) throw new ArgumentOutOfRangeException(nameof(day), "Cannot be less than 1.");
            if (day > 31) throw new ArgumentOutOfRangeException(nameof(day), "Cannot be greater than 31.");
            if (day > 28)
            {
                var lastDayOfThisMonth = GetNumberOfDaysInMonth(year, month);
                if (day > lastDayOfThisMonth) throw new ArgumentOutOfRangeException(nameof(day), $"Cannot exceed {lastDayOfThisMonth} for month {month}.");
            }

            return new DateTime(year, month, day).DayOfWeek;
        }

        public static string GetDayName(int year, int month, int day)
        {
            if (year < 1) throw new ArgumentOutOfRangeException(nameof(year), "Cannot be less than 1.");
            if (year > 9999) throw new ArgumentOutOfRangeException(nameof(year), "Cannot be greater than 9999.");
            if (month < 1) throw new ArgumentOutOfRangeException(nameof(month), "Cannot be less than 1.");
            if (month > 12) throw new ArgumentOutOfRangeException(nameof(month), "Cannot be greater than 12.");
            if (day < 1) throw new ArgumentOutOfRangeException(nameof(day), "Cannot be less than 1.");
            if (day > 31) throw new ArgumentOutOfRangeException(nameof(day), "Cannot be greater than 31.");
            if (day > 28)
            {
                var lastDayOfThisMonth = GetNumberOfDaysInMonth(year, month);
                if (day > lastDayOfThisMonth) throw new ArgumentOutOfRangeException(nameof(day), $"Cannot exceed {lastDayOfThisMonth} for month {month}.");
            }

            return new DateTime(year, month, day).ToString("dddd");
        }

        public static int GetNumberOfDaysInMonth(int year, int month)
        {
            if (year < 1) throw new ArgumentOutOfRangeException(nameof(year), "Cannot be less than 1.");
            if (year > 9999) throw new ArgumentOutOfRangeException(nameof(year), "Cannot be greater than 9999.");
            if (month < 1) throw new ArgumentOutOfRangeException(nameof(month), "Cannot be less than 1.");
            if (month > 12) throw new ArgumentOutOfRangeException(nameof(month), "Cannot be greater than 12.");

            return new DateTime(year, month, 1).AddMonths(1).AddDays(-1).Day;
        }

        public static string GetMonthName(int year, int month)
        {
            if (year < 1) throw new ArgumentOutOfRangeException(nameof(year), "Cannot be less than 1.");
            if (year > 9999) throw new ArgumentOutOfRangeException(nameof(year), "Cannot be greater than 9999.");
            if (month < 1) throw new ArgumentOutOfRangeException(nameof(month), "Cannot be less than 1.");
            if (month > 12) throw new ArgumentOutOfRangeException(nameof(month), "Cannot be greater than 12.");

            return new DateTime(year, month, day: 1).ToString("MMMM");
        }
    }
}