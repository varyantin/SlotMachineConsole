using BedeSlotMachineConsole.Games;
using BedeSlotMachineConsole.RowGenerators;
using BedeSlotMachineConsole.Rules;
using BedeSlotMachineConsole.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BedeSlotMachineConsole.UnitTests
{
    public class GameTests
    {

        [Test]
        public void GameProducesExpectedResult()
        {
            Assert.Pass();
        }

        [Test]
        public void GameThrowsIfPlayedWithoutConfig()
        {
            var game = new Game(new RowGenerator(new RandomNumberSource()), new RowRuleSameOrWildcard());
            Assert.Throws<InvalidOperationException>(() => game.Play(10.00m));
        }
    }
}
