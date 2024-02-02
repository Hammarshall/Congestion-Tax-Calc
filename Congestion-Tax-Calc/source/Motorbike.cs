using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculator
{
    public class Motorbike : IVehicle
    {
        // Anger fordonstypen för en motorcykel. Viktigt för avgiftsberäkningar och logik som är beroende av fordonstyp.
        private readonly TollExemptionService _exemptionService;

        public Motorbike(TollExemptionService exemptionService)
        {
            _exemptionService = exemptionService;
        }

        public string GetVehicleType()
        {
            return "Motorbike";
        }

        public bool IsTollExempt()
        {
            return _exemptionService.IsExempt(GetVehicleType());
        }

        // Här kan ytterligare specifika metoder och egenskaper för Motorbike läggas till.
    }
}
