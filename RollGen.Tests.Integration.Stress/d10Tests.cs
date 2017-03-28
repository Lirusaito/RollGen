﻿using NUnit.Framework;

namespace RollGen.Tests.Integration.Stress
{
    [TestFixture]
    public class D10Tests : ProvidedDiceTests
    {
        protected override int Die
        {
            get { return 10; }
        }

        protected override int GetRoll(int quantity)
        {
            return Dice.Roll(quantity).D10().AsSum();
        }

        [Test]
        public override void RollWithLargestDieRollPossible()
        {
            Stress(AssertRollWithLargestDieRollPossible);
        }
    }
}