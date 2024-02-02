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

/*
Kodens ansvar är att identifiera avgiftsfria datum, jag anväde SoC-principen genom att tydligt markera var i koden justeringar kan behövas
för att möta nya krav. Genom att integrera `TollFreeDates.cs` med definierade gränssnitt och metodanrop, lyckades jag minska systemets koppling,
vilket förenklar processen att genomföra ändringar utan att störa övriga delar av systemet.

Denna arkitektur är i linje med OCP-principen, genom att tillåta nya datum att läggas till utan att behöva modifiera den befintliga koden,
har jag förbättrat systemets förmåga att anpassa sig till förändringar. Jag designade strukturen med tanke på framtiden, speciellt för att
underlätta utvecklingen av enhetstester. Denna separation av datumhantering i `TollFreeDates` och kontroll i `TollFreeDateChecker` gör det möjligt
att testa varje del för sig, vilket effektiviserar testprocessen.

Genom att dokumentera noggrant, strävar jag efter att göra det enklare för nya utvecklare att snabbt förstå deras roll inom systemet.
Denna strategi för att bibehålla modularitet genom att allokera specifika ansvarsområden till dedikerade klasser bidrar till ett mer hanterbart
och utvecklingsbart system. Denna metodik är kritisk för att upprätthålla systemets hållbarhet och skalbarhet över tid.
*/