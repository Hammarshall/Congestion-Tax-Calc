using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using TollFeeCalculator;

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

/*
Implementerar Modularitet och SoC genom att fokusera på motorcykelspecifika funktioner samtidigt som IVehicle-gränssnittet
efterlevs för att uppnå Låg Koppling och främja kodåteranvändning. Denna design följer OCP för enkel utvidgning och optimerar testbarheten.

Genom att använda LSP-principen, garanteras det att Motorbike smidigt kan fungera som en IVehicle i systemet,
vilket förenklar enhetstestning och upprätthåller systemets integritet, vilket leder till en hållbar och utbyggbar kodstruktur.
*/