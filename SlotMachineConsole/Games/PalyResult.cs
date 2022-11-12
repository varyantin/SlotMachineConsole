using BedeSlotMachineConsole.Symbols;

namespace BedeSlotMachineConsole.Games
{
    public class PlayResult
    {
        public IList<IList<ISymbol>>? Rows { get; internal set; }
        public GameConfig? Config { get; internal set; }
        public decimal Bet { get; internal set; }
        public decimal TotalWinningCoeficient { get; internal set; }
        public decimal TotalWinnings { get; internal set; }
        internal IList<RowResult>? RowResults { get; set; }
    }
}