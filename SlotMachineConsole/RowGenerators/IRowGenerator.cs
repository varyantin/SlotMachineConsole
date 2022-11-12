using BedeSlotMachineConsole.Symbols;

namespace BedeSlotMachineConsole.RowGenerators
{
    public interface IRowGenerator
    {
        void ConfigureSeeds(IList<ISymbol> seeds);
        IList<ISymbol> GetRow(int lenght);
    }
}