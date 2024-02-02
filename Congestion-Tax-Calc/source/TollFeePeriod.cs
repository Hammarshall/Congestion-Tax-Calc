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

/*
Att distinkt segmentera logiken för avgiftsperioder, förbättras systemets struktur i termer av modularitet, vilket i sin tur förenklar
underhållsprocessen.

Denna metodik stärker systemets design med låg koppling och hög kohesion, exempelvis när TollFreeDateChecker kommunicerar
med TollFreeDates utan att vara direkt kopplad till den, vilket utvidgar systemets flexibilitet och underlättar integration av nya funktioner
i linje med principerna för OCP-principen.
*/