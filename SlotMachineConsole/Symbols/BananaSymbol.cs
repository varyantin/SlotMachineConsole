using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedeSlotMachineConsole.Symbols
{
    public class BananaSymbol : ISymbol
    {
        public string Display => "B";

        public decimal Coeficient => 0.6m;

        public decimal Probability => 0.35m;

    }
}
