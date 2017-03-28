using Ninject;
using NUnit.Framework;

namespace RollGen.Tests.Integration.Stress
{
    [TestFixture]
    public abstract class ProvidedDiceTests : StressTests
    {
        [Inject]
        public IDice Dice { get; set; }

        protected abstract int Die { get; }

        protected abstract int GetRoll(int quantity);

        protected void AssertRollWithLargestQuantityPossible()
        {
            var roll = GetRoll(Limits.Quantity);
            Assert.That(roll, Is.InRange(Limits.Quantity, Limits.Quantity * Die));
        }

        protected void AssertRoll()
        {
            var roll = GetRoll(1);
            Assert.That(roll, Is.InRange(1, Die));
        }
    }
}