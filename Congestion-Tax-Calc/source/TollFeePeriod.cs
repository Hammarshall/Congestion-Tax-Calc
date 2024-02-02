using System;

namespace TollFeeCalculator
{
    public class TollFeePeriod
    {
        public TimeSpan Start { get; set; } // Starttiden för avgiftsperioden.
        public TimeSpan End { get; set; }   // Sluttiden för avgiftsperioden.
        public int Fee { get; set; }        // Avgiften som tillämpas under denna period.

        public TollFeePeriod(TimeSpan start, TimeSpan end, int fee)
        {
            // Konstruktor skapar ny avgiftsperiod.
            Start = start;
            End = end;
            Fee = fee;
        }
    }
}