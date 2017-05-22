using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Bank;

namespace bank.tests
{
    [TestFixture]
    public class BankTests
    {
        [Test]
        public void CanDepositMoney()
        {
            var sut = new BankAccount();

            sut.Deposit(1000);

            Assert.AreEqual(1000, sut.Balance);
            
        }
        [Test]
        public void CanWithDraw()
        {
            var sut = new BankAccount();

            sut.WithDraw(1000);

            Assert.AreEqual(-1000, sut.Balance, "Can Withdraw");
        }
        




    }
}
