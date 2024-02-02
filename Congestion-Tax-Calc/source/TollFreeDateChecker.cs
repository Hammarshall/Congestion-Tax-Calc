using System;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TollFeeCalculator;

namespace TollFeeCalculator
{
    public class TollFreeDateChecker
    {
        private readonly TollFreeDates _tollFreeDates;

        // List of toll-free dates (public holidays, weekends)
        public TollFreeDateChecker(TollFreeDates tollFreeDates)
        {
            _tollFreeDates = tollFreeDates;
        }

        // Check specific date is toll-free (either in the toll-free dates list or on weekends)
        public bool IsTollFreeDate(DateTime date)
        {
            // Implementera kontroll av helgdagar, dagar före helgdagar, lördagar och juli månad
            return _tollFreeDates.IsTollFreeDate(date) ||
           date.DayOfWeek == DayOfWeek.Saturday ||
           date.DayOfWeek == DayOfWeek.Sunday ||
           date.Month == 7;
        }
    }
}