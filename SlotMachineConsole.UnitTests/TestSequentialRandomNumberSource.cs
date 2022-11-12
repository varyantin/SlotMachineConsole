using BedeSlotMachineConsole.Symbols;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedeSlotMachineConsole.UnitTests
{
    internal class TestSequentialRandomNumberSource : IRandomNumberSource
    {
        public TestSequentialRandomNumberSource(int loopCount)
        {
            this.loopCount = loopCount;
        }

        private decimal counter = 0.0m;
        private decimal? increment = null;
        private readonly int loopCount;
        private decimal? lastUpperLimit;
        public decimal GetRandomDecimalUpTo(decimal upperLimit)
        {
            if (lastUpperLimit != null && lastUpperLimit != upperLimit)
            {
                throw new InvalidOperationException("Cannot change the upper limit on this test random number source");
            }

            lastUpperLimit = upperLimit;

            if (increment == null)
            {
                increment = upperLimit / loopCount;
            }

            counter += increment ?? throw new InvalidOperationException("Failed initializing test random number source");
            if (counter >= upperLimit) { counter = 0.0m; }
            return counter;
        }
    }
}
