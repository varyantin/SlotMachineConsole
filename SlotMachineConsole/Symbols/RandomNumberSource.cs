using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedeSlotMachineConsole.Symbols
{
    public class RandomNumberSource : IRandomNumberSource
    {
        private readonly Random rand = new Random();
        public decimal GetRandomDecimalUpTo(decimal upperLimit)
        {
            return (decimal)rand.NextDouble() * upperLimit;
        }
    }
}
