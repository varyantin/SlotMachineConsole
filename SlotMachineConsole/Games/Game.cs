using BedeSlotMachineConsole.RowGenerators;
using BedeSlotMachineConsole.Rules;
using BedeSlotMachineConsole.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedeSlotMachineConsole.Games
{
    public class Game
    {
        private readonly IRowGenerator rowGenerator;
        private readonly IRowRule rowRule;
        private bool isConfigured = false;
        private GameConfig? config;

        public Game(IRowGenerator rowGenerator, IRowRule rowRule)
        {
            this.rowGenerator = rowGenerator;
            this.rowRule = rowRule;
        }

        public void Configure(GameConfig config)
        {
            if (config is null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            this.config = config;
            rowGenerator.ConfigureSeeds(config.Seeds);
            isConfigured = true;
        }

        public PlayResult Play(decimal bet)
        {
            if (!isConfigured) throw new InvalidOperationException("Cannot play the game without configuration.");


            var result = new PlayResult();
            result.Config = config!;
            result.Bet = bet;
            result.Rows = Enumerable.Range(0, config!.RowCount).Select(i => rowGenerator.GetRow(config.RowLength)).ToList();
            result.RowResults = result.Rows.Select(r =>
                 new RowResult
                 {
                     IsWinning = rowRule.IsWinning(r),
                     WinningCoeficient = rowRule.WinningCoeficient(r)
                 }).ToList();
            result.TotalWinningCoeficient = result.RowResults.Where(r => r.IsWinning).Sum(r => r.WinningCoeficient);
            result.TotalWinnings = Math.Round(result.Bet * result.TotalWinningCoeficient, 2);

            return result;

        }
    }
}
