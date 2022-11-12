using BedeSlotMachineConsole.Rules;
using BedeSlotMachineConsole.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedeSlotMachineConsole.UnitTests
{
    public class RoleRuleSameOrWildcardTests
    {
        private List<ISymbol> three_apples_yes_1_2 = new ISymbol[] {
            new AppleSymbol(),
            new AppleSymbol(),
            new AppleSymbol(),
        }.ToList();

        private List<ISymbol> apple_apple_pineapple_no_1_6 = new ISymbol[] {
            new AppleSymbol(),
            new AppleSymbol(),
            new PineappleSymbol(),
        }.ToList();

        private List<ISymbol> banana_apple_banana_no_1_6 = new ISymbol[] {
            new BananaSymbol(),
            new AppleSymbol(),
            new BananaSymbol(),
        }.ToList();


        private List<ISymbol> banana_wildcard_banana_yes_1_2 = new ISymbol[] {
            new BananaSymbol(),
            new WildcardSymbol(),
            new BananaSymbol(),
        }.ToList();


        private List<ISymbol> pineapple_pineapple_wildcard_yes_1_6 = new ISymbol[] {
            new PineappleSymbol(),
            new PineappleSymbol(),
            new WildcardSymbol(),
        }.ToList();


        [Test]
        public void IsWinningValidatesRuleCorrectly()
        {
            IsWinningValidatesRuleCorrectly(three_apples_yes_1_2, true);
            IsWinningValidatesRuleCorrectly(apple_apple_pineapple_no_1_6, false);
            IsWinningValidatesRuleCorrectly(banana_apple_banana_no_1_6, false);
            IsWinningValidatesRuleCorrectly(banana_wildcard_banana_yes_1_2, true);
            IsWinningValidatesRuleCorrectly(pineapple_pineapple_wildcard_yes_1_6, true);
        }

        private void IsWinningValidatesRuleCorrectly(List<ISymbol> seed, bool shouldBeWinning)
        {
            var rule = new RowRuleSameOrWildcard();
            Assert.That(rule.IsWinning(seed), Is.EqualTo(shouldBeWinning));
        }

        [Test]
        public void WinnigCoeficientIsCalculatedCorrectly()
        {
            WinnigCoeficientIsCalculatedCorrectly(three_apples_yes_1_2, 1.2m);
            WinnigCoeficientIsCalculatedCorrectly(apple_apple_pineapple_no_1_6, 1.6m);
            WinnigCoeficientIsCalculatedCorrectly(banana_apple_banana_no_1_6, 1.6m);
            WinnigCoeficientIsCalculatedCorrectly(banana_wildcard_banana_yes_1_2, 1.2m);
            WinnigCoeficientIsCalculatedCorrectly(pineapple_pineapple_wildcard_yes_1_6, 1.6m);
        }

        private void WinnigCoeficientIsCalculatedCorrectly(List<ISymbol> seed, decimal expectedCoeficient)
        {
            var rule = new RowRuleSameOrWildcard();
            Assert.That(rule.WinningCoeficient(seed), Is.EqualTo(expectedCoeficient));
        }


    }
}
