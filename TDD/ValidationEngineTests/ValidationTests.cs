using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ValidationEngine;

namespace ValidationEngineTests
{
    [TestFixture]
    public class ValidationTests
    {
        [Test]
        public void TrueForValidAddress()
        {
            var sut = new Email();

            var result = sut.isValidEmail("asvimalo@gmail.com");

            Assert.IsTrue(result);
        }
        [Test]
        public void FalseForValidAddress()
        {
            var sut = new Email();

            var result = sut.isValidEmail("asvimalo1@gmail.com");

            Assert.IsFalse(result);
        }
        [Test]
        public void FalseForValidAddress2()
        {
            var sut = new Email();

            var result = sut.isValidEmail("asvimalo@1gmail.com");

            Assert.IsFalse(result);
        }
        [Test]
        public void FalseForValidAddressWithPoint()
        {
            var sut = new Email();

            var result = sut.isValidEmail("asvi.malo@gmail");

            Assert.IsFalse(result);
        }
        [Test]
        public void FalseForValidAddressEmpty()
        {
            var sut = new Email();

            var result = sut.isValidEmail("");

            Assert.IsFalse(result);
        }
        //[Test]
        //public  FalseForValidAddressEmpty()
        //{
        //    var sut = new Email();

        //    var result = sut.isValidEmail("");

        //    Assert.Throws<Exe>;
        //}
    }
}
