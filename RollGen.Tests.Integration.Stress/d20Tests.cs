using NUnit.Framework;

namespace RollGen.Tests.Integration.Stress
{
    [TestFixture]
    public class D20Tests : ProvidedDiceTests
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
        public override void RollWithLargestDieRollPossible()
        {
            Stress(AssertRollWithLargestDieRollPossible);
        }
    }
}