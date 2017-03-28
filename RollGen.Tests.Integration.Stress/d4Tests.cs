using NUnit.Framework;

namespace RollGen.Tests.Integration.Stress
{
    [TestFixture]
    public class D4Tests : ProvidedDiceTests
    {
        protected override int Die
        {
            get { return 4; }
        }

        protected override int GetRoll(int quantity)
        {
            return Dice.Roll(quantity).D4().AsSum();
        }

        [Test]
        public void StressD4WithMaxQuantity()
        {
            stressor.Stress(AssertRollWithLargestQuantityPossible);
        }

        [Test]
        public void StressD4()
        {
            stressor.Stress(AssertRoll);
        }
    }
}