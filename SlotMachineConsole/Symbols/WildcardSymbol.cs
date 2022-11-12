using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedeSlotMachineConsole.Symbols
{
    public class WildcardSymbol : ISymbol, IWildcard
    {
        public string Display => "*";

        public decimal Coeficient => 0.0m;

        public decimal Probability => 0.05m;

    }
}
