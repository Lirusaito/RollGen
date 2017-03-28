using RollGen.Domain.Expressions;
using System;

namespace RollGen.Domain.PartialRolls
{
    internal class DomainPartialRollFactory : IPartialRollFactory
    {
        private readonly Random random;
        private readonly IExpressionEvaluator expressionEvaluator;

        public DomainPartialRollFactory(Random random, IExpressionEvaluator expressionEvaluator)
        {
            this.random = random;
            this.expressionEvaluator = expressionEvaluator;
        }

        public PartialRoll Build(int quantity)
        {
            return new NumericPartialRoll(quantity, random, expressionEvaluator);
        }

        public PartialRoll Build(string rollExpression)
        {
            return new ExpressionPartialRoll(rollExpression, random, expressionEvaluator);
        }
    }
}
