using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedeSlotMachineConsole.Symbols
{
    public class PineappleSymbol : ISymbol
    {
        public string Display => "P";

        public decimal Coeficient => 0.8m;

        public decimal Probability => 0.15m;

    }
}
