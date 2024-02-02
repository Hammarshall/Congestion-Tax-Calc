using System;
using System.Collections.Generic;

namespace TollFeeCalculator
{
    public class TollFreeDates
    {
        // List of specific toll-free dates
        private readonly List<DateTime> _tollFreeDates;


        // List of dates that are toll-free (e.g., public holidays, weekends) YYMMDD
        public TollFreeDates()
        {
            _tollFreeDates = new List<DateTime>
            {
                // Initialize with specific toll-free dates
                new DateTime(2024, 1, 1),
                new DateTime(2024, 3, 28),
                new DateTime(2024, 3, 29),
                // ... Add more dates here ...
            };
        }

        // Checks if a given date is toll-free
        public bool IsTollFreeDate(DateTime date) => _tollFreeDates.Contains(date.Date) || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday ||
                   date.Month == 7;
    }
}