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

        public abstract void RollWithLargestDieRollPossible();

        protected void AssertRollWithLargestDieRollPossible()
        {
            var roll = GetRoll(Limits.Quantity);
            Assert.That(roll, Is.InRange(Limits.Quantity, Limits.Quantity * Die));
        }
    }
}