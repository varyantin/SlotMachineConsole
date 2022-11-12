using BedeSlotMachineConsole.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedeSlotMachineConsole.Rules
{
    public class RowRuleSameOrWildcard : IRowRule
    {
        public bool IsWinning(IList<ISymbol> symbols)
        {
            return symbols
                .Where(s => s is not IWildcard)
                .Select(s => s.GetType().FullName)
                .Distinct()
                .Count() == 1;
        }

        public decimal WinningCoeficient(IList<ISymbol> symbols)
        {
            return symbols
                .Where(s => s is not IWildcard)
                .Sum(s => s.Coeficient);

        }
    }
}
