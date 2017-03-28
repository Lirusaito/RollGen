using NUnit.Framework;

namespace RollGen.Tests.Integration.Stress
{
    [TestFixture]
    public class d20Tests : ProvidedDiceTests
    {
        protected override int Die
        {
            get { return 20; }
        }

        protected override int GetRoll(int quantity)
        {
            return Dice.Roll(quantity).D20().AsSum();
        }

        [Test]
        public void StressD20WithMaxQuantity()
        {
            stressor.Stress(AssertRollWithLargestQuantityPossible);
        }

        [Test]
        public void StressD20()
        {
            stressor.Stress(AssertRoll);
        }
    }
}