using Ninject;
using NUnit.Framework;
using System;

namespace RollGen.Tests.Integration.Stress
{
    [TestFixture]
    public class dTests : StressTests
    {
        [Inject]
        public IDice Dice { get; set; }

        [TestCase(1, Limits.Die)]
        [TestCase(Limits.Quantity, 1)]
        public void RollWithLargestDieRollPossible(int quantity, int die)
        {
            stressor.Stress(() => AssertRoll(quantity, die));
        }

        [Test]
        public void RollWithLargestDieRollPossible()
        {
            var rootOfLimit = Convert.ToInt32(Math.Floor(Math.Sqrt(Limits.ProductOfQuantityAndDie)));
            stressor.Stress(() => AssertRoll(rootOfLimit, rootOfLimit));
        }

        private void AssertRoll(int quantity, int die)
        {
            var roll = Dice.Roll(quantity).D(die).AsSum();
            Assert.That(roll, Is.InRange(quantity, quantity * die));
        }
    }
}