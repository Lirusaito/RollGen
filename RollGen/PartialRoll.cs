using System.Collections.Generic;

namespace RollGen
{
    public abstract class PartialRoll
    {
        public string CurrentRollExpression { get; protected set; }

        public abstract PartialRoll D(int die);
        public abstract PartialRoll Keeping(int amountToKeep);

        public abstract int AsSum();
        public abstract IEnumerable<int> AsIndividualRolls();
        public abstract double AsPotentialAverage();
        public abstract int AsPotentialMinimum();
        public abstract int AsPotentialMaximum();
        public abstract bool AsTrueOrFalse();

        public PartialRoll D2() => D(2);
        public PartialRoll D3() => D(3);
        public PartialRoll D4() => D(4);
        public PartialRoll D6() => D(6);
        public PartialRoll D8() => D(8);
        public PartialRoll D10() => D(10);
        public PartialRoll D12() => D(12);
        public PartialRoll D20() => D(20);
        public PartialRoll Percentile() => D(100);
    }
}