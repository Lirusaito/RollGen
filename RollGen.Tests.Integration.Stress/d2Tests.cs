using NUnit.Framework;

namespace RollGen.Tests.Integration.Stress
{
    [TestFixture]
    public class D2Tests : ProvidedDiceTests
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
        public override void RollWithLargestDieRollPossible()
        {
            Stress(AssertRollWithLargestDieRollPossible);
        }
    }
}