using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TDD_Kata;

namespace TDD_Kata.Tests
{
    [TestFixture]
    public class TDD_KataTests
    {
        public Calculator sut { get; set; }

        [SetUp]
        public void Init()
        {
            sut = new Calculator();
        }
        [Test]
        public void CanDetectIfZeroOrEmpty()
        {

            Assert.AreEqual(0,sut.Add(""));
        }
        [Test]
        public void CanCountOneNumber()
        {
            Assert.AreEqual(1,sut.Add("1"));
        }
        [Test]
        public void CanCountTwoNumber()
        {
            Assert.AreEqual(3, sut.Add("1,2"));
        }
        [Test]
        public void CanAddAndFindSpace()
        {
            Assert.AreEqual(10, sut.Add("4\n1,2%3"));
        }
        [Test]
        public void NegativeNumbersNotAllowed()
        {
            //Assert.Throws<NegativeNumberException>();
        }
        [Test]
        public void MoreThan1000NotAllowed()
        {
            Assert.AreEqual(2, sut.Add("1001,2,1002"));
        }
    }
}
