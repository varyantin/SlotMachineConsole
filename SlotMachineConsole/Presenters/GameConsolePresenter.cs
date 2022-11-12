using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BedeSlotMachineConsole.Games;
using BedeSlotMachineConsole.Symbols;

namespace BedeSlotMachineConsole.Presenters
{
    public static class GameConsolePresenter
    {
        public static decimal QueryBetValue(decimal maximum)
        {
            decimal? value = null;
            while (value == null)
            {
                Console.WriteLine("Enter stake amount");
                var input = Console.ReadLine();
                if (decimal.TryParse(input, out var numericConversion))
                {
                    if (numericConversion > 0.0m && numericConversion <= maximum)
                    {
                        value = numericConversion;
                    }
                    else
                    {
                        Console.WriteLine($"Please choose amount between 0.0 and {maximum:0.00}!");
                    }
                }
                else
                {
                    Console.WriteLine($"Please enter valid number between 0.0 and {maximum:0.00}!");
                }
            }

            return value.Value;
        }

        public static void PresentWinnings(PlayResult result)
        {
            Console.WriteLine($"You have won: {result.TotalWinnings:0.00}");
        }

        public static void PresentLines(PlayResult result)
        {
            _ = result.Rows ?? throw new ArgumentException("Result contains now rows.");

            foreach (var row in result.Rows)
            {
                if (row != null)
                {
                    foreach (var s in row)
                    {
                        Console.Write(s.Display);
                    }
                    Console.WriteLine();
                }
                else
                {
                    throw new InvalidDataException("Row in the result should not be null.");
                }
            }
        }
    }
}
