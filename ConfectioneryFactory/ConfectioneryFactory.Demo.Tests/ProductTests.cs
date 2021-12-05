using System;
using NUnit.Framework;
using ConfectioneryFactory.Domain;

namespace ConfectioneryFactory.Demo.Tests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("\0")]
        [TestCase("\n")]
        [TestCase("\r")]
        [TestCase("\t")]
    }
}