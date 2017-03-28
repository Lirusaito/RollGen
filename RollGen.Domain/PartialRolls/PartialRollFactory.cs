namespace RollGen.Domain.PartialRolls
{
    internal interface IPartialRollFactory
    {
        PartialRoll Build(int quantity);
        PartialRoll Build(string rollExpression);
    }
}
