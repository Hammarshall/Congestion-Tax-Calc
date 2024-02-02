using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using TollFeeCalculator;

namespace TollFeeCalculator
{
    public class Car : IVehicle
    {
        // GetVehicleType från IVehicle-gränssnittet = enhetlig behandling av fordonstyper.
        private readonly TollExemptionService _exemptionService;

        public Car(TollExemptionService exemptionService)
        {
            _exemptionService = exemptionService;
        }

        // Returnerar fordonstypssträng, måste implementeras av alla typer, enhetligt och förutsägbart.
        public string GetVehicleType()
        {
            return "Car";
        }

        public bool IsTollExempt()
        {
            return _exemptionService.IsExempt(GetVehicleType());
        }

        // Här kan ytterligare specifika metoder och egenskaper för car läggas till.

    }
}

/*
Definiera en bilklass med distinkta attribut och funktioner, faciliterar integrationen av IVehicle-interfacet en harmonisering av fordonens
egenskaper och beteenden av flera fordonstyper. Detta främjar polymorfism och optimerar TollCalculators förmåga att smidigt hantera en mångfald av fordon.

Resulterar i konsistent hantering av olika fordon genom polymorfism och i linje med ISP-Principen inom SOLID-principerna, vilket förstärker systemets
anpassningsbarhet och expansionsmöjligheter.

TollExemptionService drar nytta av detta gränssnitt för att identifiera fordon som är befriade från avgifter, vilket minskar beroendet till specifika
fordonstyper och bidrar till en modulär systemarkitektur. Implementeringen av IVehicle förbättrar inte bara kodens läsbarhet och underhållbarhet
utan också den övergripande robustheten och skalbarheten i systemet.
*/