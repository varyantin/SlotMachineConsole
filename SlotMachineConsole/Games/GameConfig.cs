using BedeSlotMachineConsole.Symbols;

namespace BedeSlotMachineConsole.Games
{
    public class GameConfig
    {
        private GameConfig()
        {
            throw new InvalidOperationException("Cannot and should not consutrct config without values.");
        }

        public GameConfig(int rowLength, int rowCount, IList<ISymbol> seeds)
        {
            RowLength = rowLength;
            RowCount = rowCount;
            Seeds = seeds ?? throw new ArgumentNullException(nameof(seeds));
        }

        public int RowLength { get; internal set; }
        public int RowCount { get; internal set; }
        public IList<ISymbol> Seeds { get; internal set; }
    }
}