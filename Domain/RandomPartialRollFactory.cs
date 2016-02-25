﻿using System;

namespace RollGen.Domain
{
    public class RandomPartialRollFactory : PartialRollFactory
    {
        private readonly Random random;

        public RandomPartialRollFactory(Random random)
        {
            this.random = random;
        }

        public PartialRoll Build(int quantity)
        {
            return new RandomPartialRoll(quantity, random);
        }
    }
}
