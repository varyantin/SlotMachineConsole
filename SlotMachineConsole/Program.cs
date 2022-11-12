// See https://aka.ms/new-console-template for more information
using BedeSlotMachineConsole;
using BedeSlotMachineConsole.BettingStakes;
using BedeSlotMachineConsole.Games;
using BedeSlotMachineConsole.Presenters;
using BedeSlotMachineConsole.RowGenerators;
using BedeSlotMachineConsole.Rules;
using BedeSlotMachineConsole.Symbols;

var stake = new BettingStake();
var randomNumberSource = new RandomNumberSource();
var rowGenerator = new RowGenerator(randomNumberSource);
var rowRule = new RowRuleSameOrWildcard();
var game = new Game(rowGenerator, rowRule);

var gameConfig = new GameConfig(
    rowCount: 3,
    rowLength: 3,
    seeds: new ISymbol[] {
        new AppleSymbol(),
        new BananaSymbol(),
        new PineappleSymbol(),
        new WildcardSymbol()
    }.ToList()
);

game.Configure(gameConfig);

BettingStakeConsolePresenter.Deposit(stake);

while (stake.Balance > 0.0m)
{
    var bet = GameConsolePresenter.QueryBetValue(stake.Balance);
    stake.Withdraw(bet);
    var result = game.Play(bet);
    GameConsolePresenter.PresentLines(result);
    GameConsolePresenter.PresentWinnings(result);
    stake.Deposit(result.TotalWinnings);
    BettingStakeConsolePresenter.PresentBalance(stake);
}


Console.WriteLine("Game over!");
