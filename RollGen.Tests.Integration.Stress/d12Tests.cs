using NUnit.Framework;

namespace RollGen.Tests.Integration.Stress
{
    [TestFixture]
    public class D12Tests : ProvidedDiceTests
    {
        protected override int Die
        {
            get { return 12; }
        }

        protected override int GetRoll(int quantity)
        {
            return Dice.Roll(quantity).D12().AsSum();
        }

        [Test]
        public override void RollWithLargestDieRollPossible()
        {
            Stress(AssertRollWithLargestDieRollPossible);
        }
    }
}