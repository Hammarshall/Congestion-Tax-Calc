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

/*
Koden är särskilt utformad för att effektivt administrera en uppsättning av avgiftsfria dagar, inklusive rörliga helgdagar som ändras år från år.
Klassen erbjuder funktioner för att lägga till och validera dessa datum, vilket skapar en central punkt för hantering av avgiftsfria perioder.

Denna funktionalitet kompletteras ytterligare av TollFreeDateChecker, som ansvarar för att separera logiken för att kontrollera avgiftsfria
datum från själva hanteringen av datumen. Detta bidrar till enklare underhåll och uppdateringar av systemet. Genom att anamma principerna för
SoC-principen och Don't Repeat Yourself (DRY), minimeras kodupprepning och systemets underhållbarhet förbättras avsevärt.

Med en väl dokumenterad kodstruktur (genom tydliga kodkommentarer) förenklas förståelsen och integrationen av dessa komponenter för andra utvecklare.
Detta stärker kodbasens modularitet och läsbarhet, vilket i sin tur faciliterar systemets skalbarhet och gör felsökningen mer effektiv.
*/