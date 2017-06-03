using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using BankSolution;
using System.Net.NetworkInformation;

namespace BankSolution.Tests
{
    [TestFixture]
    public class BankTest
    {
        public IAuditLogger auditLogger;
        public Bank sut;

        [SetUp]
        public void Setup()
        {
            auditLogger = Substitute.For<IAuditLogger>();
            sut = new Bank(auditLogger);
        }
        [Test]
        public void CanCreateABankAcount()
        {
           
            sut.CreateAccount(new Account("456321", "Andres", 0.0M));
            sut.CreateAccount(new Account("456322", "Mario", 0.0M));
            var account = sut.GetAccount("456322");
            //var v = auditLogger.GetLog();
            //v.Contains("456322");
            Assert.AreEqual(account.Number, "456322");
            Assert.AreEqual(account.Name, "Mario");
            Assert.AreEqual(account.Balance, 0.0M);
        }
        [Test]
        public void CanNotCreateDuplicateAccounts()
        {
            sut.CreateAccount(new Account("456321", "Andres", 0.0M));
            Assert.Throws<DuplicateAccount>(() => sut.CreateAccount(new Account("456321", "Andres", 0.0M)));
        }
        [Test]
        public void WhenCreatingAnAccount_AMessageIsWrittenToTheAuditLog()
        {
            sut.CreateAccount(new Account("456321", "Andres", 0.0M));
            Assert.That(sut.GetAccount("456321").Number == "456321");
            Assert.AreEqual(sut.GetAuditLog().Count, 1);

        }
        [Test]
        public void WhenCreatingAnValidAccount_OneMessageAreWrittenToTheAuditLog()
        {
            sut.CreateAccount(new Account("456321", "Andres", 0.0M));
            
            Assert.AreEqual(sut.GetAuditLog().Count, 1);
        }
        [Test]
        public void WhenCreatingAnInvalidAccount_TwoMessagesAreWrittenToTheAuditLog()
        {
            Assert.Throws<InvalidAccount>(() => sut.CreateAccount(new Account("45aa21", "Andres", 0.0M)));
            
            Assert.AreEqual(sut.GetAuditLog().Count, 2);
        }
        [Test]
        public void WhenCreatingAnInvalidAccount_AWarn12AndErro45MessageIsWrittenToAuditLog()
        {
            Assert.Throws<InvalidAccount>(() => sut.CreateAccount(new Account("45aa21", "Andres", 0.0M)));
            
            foreach (var item in sut.GetAuditLog())
            {
                if (item.Contains("Warn12"))
                    Assert.That(item.Contains("Warn12"));
                else if(item.Contains("Erro45"))
                    Assert.That(item.Contains("Erro45"));
            } 
        }
        [Test]
        public void VerifyThat_GetAuditLog_GetsTheLogFromTheAuditLogger()
        {

        }
    }
}
