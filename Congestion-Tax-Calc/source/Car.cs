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