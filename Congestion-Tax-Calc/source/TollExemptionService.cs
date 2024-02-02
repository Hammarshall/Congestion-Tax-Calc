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

/*
Här specificeras vilka fordon som är befriade från trängselskatt, vilket illustrerar tillämpningen av SoC genom att koncentrera sig på undantagslogiken
för fordon. Användandet av IVehicle-interfacet reducerar beroendet på specifika fordonstyper, vilket ökar systemets flexibilitet och förenklar
underhållsarbetet. En klar ansvarsindelning gör koden lättillgänglig och förståelig, vilket effektiviserar processen för framtida utveckling och
förståelse av systemets funktioner. Dessutom lägger denna kodstruktur en solid grund för testbarhet, vilket bidrar till utvecklingen av pålitliga
enhetstester för att bekräfta undantagslogikens korrekthet.

Denna metod bidrar till en flexibel och modulär systemarkitektur som kan anpassas för att uppfylla både aktuella och framtida behov utan att
kompromissa systemets integritet. Genom att isolera logiken för avgiftsundantag från andra delar av systemet, som avgiftsberäkning och datumhantering,
förbättras den totala systemkvaliteten och stabiliteten. Detta är av yttersta vikt för att skapa hållbara och anpassningsbara lösningar som kan
navigera i den ständigt föränderliga tekniska landskapet.
*/