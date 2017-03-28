using NUnit.Framework;

namespace RollGen.Tests.Integration.Stress
{
    [TestFixture]
    public class d6Tests : ProvidedDiceTests
    {
        protected override int Die
        {
            get { return 6; }
        }

        protected override int GetRoll(int quantity)
        {
            return Dice.Roll(quantity).D6().AsSum();
        }

        [Test]
        public override void RollWithLargestDieRollPossible()
        {
            Stress(AssertRollWithLargestDieRollPossible);
        }
    }
}