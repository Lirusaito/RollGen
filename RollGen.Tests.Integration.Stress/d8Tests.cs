using NUnit.Framework;

namespace RollGen.Tests.Integration.Stress
{
    [TestFixture]
    public class d8Tests : ProvidedDiceTests
    {
        protected override int Die
        {
            get { return 8; }
        }

        protected override int GetRoll(int quantity)
        {
            return Dice.Roll(quantity).D8().AsSum();
        }

        [Test]
        public void StressD8WithMaxQuantity()
        {
            stressor.Stress(AssertRollWithLargestQuantityPossible);
        }

        [Test]
        public void StressD8()
        {
            stressor.Stress(AssertRoll);
        }
    }
}