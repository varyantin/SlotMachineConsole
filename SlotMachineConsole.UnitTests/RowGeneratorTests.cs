using BedeSlotMachineConsole.Symbols;
using BedeSlotMachineConsole.RowGenerators;

namespace BedeSlotMachineConsole.UnitTests

{
    public class Tests
    {

        private static List<ISymbol> oneSymbol = new ISymbol[] { 
            new TestSymbol { Display = "One", Probability = 1.0m, Coeficient = 0.0m}
        }.ToList();

        private List<ISymbol> bad = new ISymbol[] {
            new TestSymbol { Display = "11", Probability = 0.11m, Coeficient = 0.0m},
            new TestSymbol { Display = "66", Probability = 0.66m, Coeficient = 0.0m}
        }.ToList();


        private List<ISymbol> three_11_23_66 = new ISymbol[] {
            new TestSymbol { Display = "11", Probability = 0.11m, Coeficient = 0.0m},
            new TestSymbol { Display = "23", Probability = 0.23m, Coeficient = 0.0m},
            new TestSymbol { Display = "66", Probability = 0.66m, Coeficient = 0.0m}
        }.ToList();

        private List<ISymbol> two_19_81 = new ISymbol[] {
            new TestSymbol { Display = "19", Probability = 0.19m, Coeficient = 0.0m},
            new TestSymbol { Display = "81", Probability = 0.81m, Coeficient = 0.0m}
        }.ToList();

        private List<ISymbol> four_51_3_17_29 = new ISymbol[] {
            new TestSymbol { Display = "51", Probability = 0.51m, Coeficient = 0.0m},
            new TestSymbol { Display = "3", Probability = 0.03m, Coeficient = 0.0m},
            new TestSymbol { Display = "17", Probability = 0.17m, Coeficient = 0.0m},
            new TestSymbol { Display = "29", Probability = 0.29m, Coeficient = 0.0m}
        }.ToList();


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RowGeneratorGeneratesRowsWithCorrectLenght()
        {
            var generator = new RowGenerator(new TestSequentialRandomNumberSource(10));
            generator.ConfigureSeeds(oneSymbol);
            var row = generator.GetRow(5);
            Assert.That(row.All(x=>x is TestSymbol), Is.True);
            Assert.That(row.Count, Is.EqualTo(5));
        }

        [Test]
        public void RowGeneratorWillThrowIfGenerationIsAttemptedBeforeConfiguration()
        {
            var generator = new RowGenerator(new TestSequentialRandomNumberSource(1000000));
            Assert.Throws<InvalidOperationException>( () => generator.GetRow(3));
        }

        [Test]
        public void RowGeneratorWillThrowIfConfiguredWithZeroElements()
        {
            var generator = new RowGenerator(new TestSequentialRandomNumberSource(1000000));
            Assert.Throws<ArgumentException>(() => generator.ConfigureSeeds(Enumerable.Empty<ISymbol>().ToList()));
        }

        [Test]
        public void RowGeneratorWillThrowIfSumOfProabilitiesIsNotUnitiy()
        {
            var generator = new RowGenerator(new TestSequentialRandomNumberSource(1000000));
            Assert.Throws<ArgumentException>(() => generator.ConfigureSeeds(bad));
        }



        [Test]
        public void RowGeneratorGeneratesRowsWithCorrectProbability()
        {
            RowGeneratorGeneratesRowsWithCorrectProbability(three_11_23_66);
            RowGeneratorGeneratesRowsWithCorrectProbability(two_19_81);
            RowGeneratorGeneratesRowsWithCorrectProbability(four_51_3_17_29);
        }


        private void RowGeneratorGeneratesRowsWithCorrectProbability(List<ISymbol> seed)
        {
            var generator = new RowGenerator(new TestSequentialRandomNumberSource(1000000));
            generator.ConfigureSeeds(seed);
            var resultDict = new Dictionary<string, double>();
            seed.ForEach(x => resultDict[x.Display] = 0);

            for (int i = 0; i < 1000000; i++)
            {
                var row = generator.GetRow(1);
                resultDict[row[0].Display] = resultDict[row[0].Display] + 1;

            }
            var sigma = 0.01m;
            seed.ForEach(x => Assert.That(resultDict[x.Display] / 1000000.0, Is.InRange(x.Probability - sigma, x.Probability + sigma)));
        }
    }
}