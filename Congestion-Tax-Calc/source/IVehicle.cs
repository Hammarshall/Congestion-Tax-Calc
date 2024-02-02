using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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