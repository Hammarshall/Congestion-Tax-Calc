using System;
using System.Globalization;
using TollFeeCalculator;

namespace TollFeeCalculator
{
    public class TollFeeCalculator
    {
        private readonly TollFeeSchedule _tollFeeSchedule; // Hanterar avgiftsschemat baserat på tidpunkt.
        private readonly TollFreeDates _tollFreeDates; // Kontrollerar avgiftsfria datum.
        private readonly TollExemptionService _tollExemptionService; // Avgör fordon avgifts fritt
        private readonly List<TollFeePeriod> _feePeriods; // Lista över avgiftsperioder
        private readonly TollFreeDateChecker _dateChecker; // Kontrollerar avgiftsfria datum, tex helgdagar.

        // Skapar en instans av TollFeeCalculator med en fördefinierad lista av avgiftsperioder.
        public TollFeeCalculator(List<TollFeePeriod> feePeriods, TollFreeDates tollFreeDates)
        {
            _tollFeeSchedule = new TollFeeSchedule();
            _tollFreeDates = tollFreeDates ?? new TollFreeDates();
            _tollExemptionService = new TollExemptionService();// Initierar för undantag
            _dateChecker = new TollFreeDateChecker(_tollFreeDates);// Använder gamla/ nya instansen av TollFreeDates
            _feePeriods = feePeriods ?? throw new ArgumentNullException(nameof(feePeriods));//lista av avgiftsperioder tillhandahålls
        }

        public int CalculateTotalFee(List<DateTime> passages, IVehicle vehicle)
        {
            //Beräknar och Kontrollerar totala avgiften för fordon baserat passagetider, hänsyn till avgiftsfria datum, maxgräns.
            if (vehicle.IsTollExempt() || passages == null || passages.Count == 0) return 0; // avgiftsfria fordon eller om ingen passage hittas

            int totalFee = 0; // Ackumulerad totalavgift
            DateTime? lastChargedTime = null; //Senaste tidpunkten för avgiftsuttag

            foreach (var passage in passages.OrderBy(p => p)) //Går igenom varje passage i kronologisk ordning.
            {
                if (_dateChecker.IsTollFreeDate(passage) || (lastChargedTime != null && passage.Subtract(lastChargedTime.Value).TotalMinutes < 60))
                    continue; // Ignorerar passager som är avgiftsfria eller inom en timme från föregående avgift

                //Beräknar avgiften för varje passage
                int passageFee = GetPassageFee(passage);
                totalFee += passageFee; //Adderar till tot avgiften.
                lastChargedTime = passage; //Uppdaterar senaste tidpunkten för avgiftsuttag.

                if (totalFee >= 60) //Returnerar maxavgiften gränsen nås
                    return 60;
            }
            return totalFee; //Returnerar totalavgiften
        }

        private int GetPassageFee(DateTime passage)
        {
            //Hämtar avgiften för en enskild passage baserat på passagetidpunkten.
            var timeOfDay = passage.TimeOfDay;
            var feePeriod = _feePeriods.FirstOrDefault(p => timeOfDay >= p.Start && timeOfDay < p.End);
            return feePeriod != null ? feePeriod.Fee : 0; // Returnerar avgiften för den matchande perioden eller 0 om ingen matchning
        }
    }
}