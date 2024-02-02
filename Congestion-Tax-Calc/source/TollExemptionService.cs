using System;
namespace TollFeeCalculator
{
    public class TollExemptionService
    {
        // List of toll-free vehicle types
        private readonly List<string> _exemptVehicleTypes;

        public TollExemptionService()
        {
            // En lista över fordonstyper som är undantagna från trängselskatt.
            // Lätt att addera nya typer som är undantagna från trängselskatt
            _exemptVehicleTypes = new List<string> { "Diplomat", "Foreign", "Military" };
        }

        // Determines if a vehicle is toll-free based on its type
        public bool IsExempt(string vehicleType)
        {
            // Kontrollerar om det angivna fordonet är undantaget från trängselskatt.
            return _exemptVehicleTypes.Contains(vehicleType);
        }
    }
}