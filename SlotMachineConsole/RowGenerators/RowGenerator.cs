using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BedeSlotMachineConsole.Symbols;

namespace BedeSlotMachineConsole.RowGenerators
{

    public class RowGenerator : IRowGenerator
    {
        public class SymbolRange
        {
            public decimal Start { get; set; }
            public decimal End { get; set; }
            public ISymbol? Symbol { get; set; }
        }

        private IList<SymbolRange>? ranges;
        private readonly IRandomNumberSource randomNumberSource;
        private decimal randomRangeEnd;
        private bool isConfigured = false;

        public RowGenerator(IRandomNumberSource randomNumberSource)
        {
            randomRangeEnd = 0.0m;
            this.randomNumberSource = randomNumberSource;
        }

        public void ConfigureSeeds(IList<ISymbol> seeds)
        {
            ArgumentNullException.ThrowIfNull(seeds);
            if (seeds.Count == 0) throw new ArgumentException("The seeds have to be at least one");
            if (seeds.Sum(s => s.Probability) != 1.0m) throw new ArgumentException("The sum of the seed probabilities has to be 1");

            randomRangeEnd = 0.0m;
            ranges = new List<SymbolRange>();

            foreach (var s in seeds)
            {
                var range = new SymbolRange { Start = randomRangeEnd, End = randomRangeEnd + s.Probability, Symbol = s };
                ranges.Add(range);
                randomRangeEnd += s.Probability;
            }

            isConfigured = true;
        }

        private ISymbol GetRandomSymbol()
        {
            if (!isConfigured) throw new InvalidOperationException("Row generator has to be configured before generation is possible.");

            var pick = randomNumberSource.GetRandomDecimalUpTo(randomRangeEnd);
            var symbol = ranges!.FirstOrDefault(r => r.Start <= pick && r.End > pick)
                ?? throw new InvalidOperationException("Random picker picked the wrong random.");

            return symbol.Symbol!;
        }

        public IList<ISymbol> GetRow(int lenght)
        {
            return Enumerable.Range(0, lenght).Select(i => GetRandomSymbol()).ToList();
        }
    }
}
