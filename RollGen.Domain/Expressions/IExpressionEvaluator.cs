namespace RollGen.Domain.Expressions
{
    internal interface IExpressionEvaluator
    {
        T Evaluate<T>(string expression);
    }
}
