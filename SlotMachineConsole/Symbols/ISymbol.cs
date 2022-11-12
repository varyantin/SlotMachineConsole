using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedeSlotMachineConsole.Symbols
{
    public interface ISymbol
    {
        public string Display { get; }
        public decimal Coeficient { get; }
        public decimal Probability { get; }
    }
}
