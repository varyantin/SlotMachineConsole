using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedeSlotMachineConsole.BettingStakes
{
    public class BettingStake
    {
        public decimal Balance { get; private set; }

        public bool Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }

            return false;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
    }
}
