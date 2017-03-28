using NUnit.Framework;

namespace RollGen.Tests.Integration.Stress
{
    [TestFixture]
    public class D8Tests : ProvidedDiceTests
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
        public override void RollWithLargestDieRollPossible()
        {
            Stress(AssertRollWithLargestDieRollPossible);
        }
    }
}