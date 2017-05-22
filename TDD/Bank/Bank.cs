using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bank
{
    public class BankAccount
    {
        public decimal Balance { get; set; }

        public void Deposit(int amount)
        {
            Balance += amount;
        }
        public void WithDraw(int amount)
        {
            Balance -= amount;
        }
    }
}
