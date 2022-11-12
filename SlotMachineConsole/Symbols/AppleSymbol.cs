using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BedeSlotMachineConsole.Symbols
{
    public class AppleSymbol : ISymbol
    {
        public string Display => "A";

        public decimal Coeficient => 0.4m;

        public decimal Probability => 0.45m;

    }
}
