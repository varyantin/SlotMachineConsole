using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BedeSlotMachineConsole.BettingStakes;

namespace BedeSlotMachineConsole.Presenters
{
    public static class BettingStakeConsolePresenter
    {
        public static void Deposit(BettingStake bettingStake)
        {
            decimal? value = null;
            while (value == null)
            {
                Console.WriteLine("Please deposit money you would like to play with:");
                var input = Console.ReadLine();
                if (decimal.TryParse(input, out var numericConversion))
                {
                    value = numericConversion;
                }
                else
                {
                    Console.WriteLine($"Please enter valid number.");
                }
            }

            bettingStake.Deposit(value.Value);
        }

        public static void PresentBalance(BettingStake bettingStake)
        {
            Console.WriteLine($"Current balance is: {bettingStake.Balance:0.00}");
        }
    }
}
