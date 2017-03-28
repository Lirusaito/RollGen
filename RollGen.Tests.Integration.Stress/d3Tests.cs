using NUnit.Framework;

namespace RollGen.Tests.Integration.Stress
{
    [TestFixture]
    public class D3Tests : ProvidedDiceTests
    {
        protected override int Die
        {
            get { return 3; }
        }

        protected override int GetRoll(int quantity)
        {
            return Dice.Roll(quantity).D3().AsSum();
        }

        [Test]
        public override void RollWithLargestDieRollPossible()
        {
            Stress(AssertRollWithLargestDieRollPossible);
        }
    }
}