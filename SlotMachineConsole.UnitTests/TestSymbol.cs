using BedeSlotMachineConsole.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedeSlotMachineConsole.UnitTests
{
    internal class TestSymbol : ISymbol
    {
        public TestSymbol()
        {
            Display = "NotSet";
        }

        public string Display { get; set; }

        public decimal Coeficient { get; set; }

        public decimal Probability { get; set; }
    }
}
