using NUnit.Framework;

namespace RollGen.Tests.Integration.Stress
{
    [TestFixture]
    public class d2Tests : ProvidedDiceTests
    {
        protected override int Die
        {
            get { return 2; }
        }

        protected override int GetRoll(int quantity)
        {
            return Dice.Roll(quantity).D2().AsSum();
        }

        [Test]
        public void StressD2WithMaxQuantity()
        {
            stressor.Stress(AssertRollWithLargestQuantityPossible);
        }

        [Test]
        public void StressD2()
        {
            stressor.Stress(AssertRoll);
        }
    }
}