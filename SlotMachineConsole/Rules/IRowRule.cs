using BedeSlotMachineConsole.Symbols;

namespace BedeSlotMachineConsole.Rules
{
    public interface IRowRule
    {
        public bool IsWinning(IList<ISymbol> symbols);
        public decimal WinningCoeficient(IList<ISymbol> symbols);
    }
}