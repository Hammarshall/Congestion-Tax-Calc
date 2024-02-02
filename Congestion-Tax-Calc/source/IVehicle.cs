using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using TollFeeCalculator;

namespace TollFeeCalculator
{
    public interface IVehicle
    {
        // Definierar ett gränssnitt för fordon som inkluderar de
        // grundläggande egenskaperna och beteendena som alla fordonstyper ska ha.
        string GetVehicleType(); // Hämtar en sträng som representerar fordonstypen.
        bool IsTollExempt(); //check om avgiftsfri
    }
}

/*
Att tillämpa IVehicle-gränssnittet skapas en konsistent och skalbar struktur för olika fordonstyper,
vilket utnyttjar ISP-Principen och polymorfism för att förbättra typsäkerhet och tillåta flexibel beteendemodifikation.
I Vehicle.cs och dess konkreta implementeringar, såsom Car.cs och Motorbike.cs, etableras ett klart definierat kontrakt som
specificerar de nödvändiga egenskaperna för fordon, vilket underlättar SoC-principen. Denna design bidrar till att minska
beroendena mellan systemkomponenter och ökar kohesionen inom varje fordonstyp, vilket resulterar i en mer modulär och
lättunderhållen kodstruktur som enkelt kan skalas upp och anpassas efter behov.
*/