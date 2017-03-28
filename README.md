# RollGen

Rolls a set of dice, as determined by the D20 die system.

[![Build Status](https://travis-ci.org/DnDGen/RollGen.svg?branch=master)](https://travis-ci.org/DnDGen/RollGen)

## Syntax

### Use

To use RollGen, simple adhere to the verbose, fluid syntax:

```C#
var standardRoll = dice.Roll(4).D6().AsSum();
var customRoll = dice.Roll(92).D(66).AsSum();
var expressionRoll = dice.Roll("5+3d4*2").AsSum();

var chainedRolls = dice.Roll().D2().D(5).Keeping(1).D6().AsSum(); //1d2d5k1d6 Evaluated left to right -> ((1d2)d5k1)d6

var individualRolls = dice.Roll(4).D6().AsIndividualRolls();
var parsedRolls = dice.Roll("5+3d4*2").AsIndividualRolls(); //NOTE: This will only return 1 roll, the same as AsSum()

var keptRolls = dice.Roll(4).D6().Keeping(3).AsIndividualRolls(); //Returns the highest 3 rolls
var expressionKeptRolls = dice.Roll("3d4k2").AsSum(); //Returns the sum of 2 highest rolls

var averageRoll = dice.Roll(4).D6().AsPotentialAverage(); //Returns the average roll for the expression.  For here, it will return 14.
var expressionAverageRoll = dice.Roll("5+3d4*3").AsPotentialAverage(); //5+7.5*3, returning 27.5 

var success = dice.Roll().Percentile().AsTrueOrFalse(); //Returns true if high, false if low
var expressionSuccess = dice.Roll("5+3d4*2").AsTrueOrFalse(); //Returns true if high, false if low
var explicitExpressionSuccess = dice.Roll("2d6 >= 1d12").AsTrueOrFalse(); //Evalutes boolean expression after rolling

var containsRoll = dice.ContainsRoll("This contains a roll of 4d6k3 for rolling stats"); //will return true here
var summedSentence = dice.ReplaceRollsWithSumExpression("This contains a roll of 4d6k3 for rolling stats"); //returns "This contains a roll of (5 + 3 + 2) for rolling stats"
var rolledSentence = dice.ReplaceRollsWithSumExpression("This contains a roll of 4d6k3 for rolling stats"); //returns "This contains a roll of 10 for rolling stats"
var rolledComplexSentence = dice.ReplaceWrappedExpression<double>("Fireball does {min(4d6,10) + 0.5} damage"); //returns "Fireball does 15.5 damage"

```

Important things to note:

1. If your first roll is an expression (a string), then you cannot extend it with additional rolls (such `D6()`, `D(7)`, or `Keeping(4)`).
2. When retrieving individual rolls from an expression, only the sum of the expression is returned.  This is because determining what an "individual roll" is within a complex expression is not certain.  As an example, what would individual rolls be for `1d2+3d4`?
3. Paranthetical statements in expressions (such as `5*(2d3-4)`) are not supported.  Mathematical expressions supported are `+`, `-`, `*`, `/`, and `%`, as well as die rolls as demonstrated above.  Spaces are allowed in the expression strings
4. For replacement methods on `IDice`, there is an option to do "lenient" replacements (optional boolean).  The difference:
    a. "1d2 ghouls and 2d4 zombies" strict -> "1 ghouls and 5 zombies"
    b. "1d2 ghouls and 2d4 zombies" lenient -> "1 ghouls an3 zombies" (it reads "and 2d4" as "an(d 2d4)")


### Getting `IDice` Objects

You can obtain dice from the domain project. Because the dice are very complex and are decorated in various ways, there is not a (recommended) way to build these objects manually. Please use the ModuleLoader for Ninject.

```C#
var kernel = new StandardKernel();
var rollGenModuleLoader = new RollGenModuleLoader();

rollGenModuleLoader.LoadModules(kernel);
```

Your particular syntax for how the Ninject injection should work will depend on your project (class library, web site, etc.).  Each of the examples below work independently.  You should use the one that is appropriate for your project.

```C#
[Inject] //Ninject property
public IDice MyDice { get; set; }

public MyClass()
{ }

public int Roll()
{
    return MyDice.Roll(4).D6().Keeping(3).AsSum();
}
```

```C#
private myDice;

public MyClass(IDice dice) //This works if you are calling Ninject to build MyClass
{
    myDice = dice;
}

public int Roll()
{
    return myDice.Roll(4).D6().Keeping(3).AsSum();
}
```

```C#
public MyClass()
{ }

public int Roll()
{
    var myDice = DiceFactory.Create(); //Located in RollGen.Domain.IoC, in the RollGen.Domain NuGet package
    return myDice.Roll(4).D6().Keeping(3).AsSum();
}
```

### Installing RollGen

The project is on [Nuget](https://www.nuget.org/packages/DnDGen.RollGen). Install via the NuGet Package Manager.

    PM > Install-Package DnDGen.RollGen

#### There's RollGen and RollGen.Domain - which do I install?

That depends on your project.  If you are making a library that will only **reference** RollGen, but does not expressly implement it (such as the TreasureGen project), then you only need the RollGen package.  If you actually want to run and implement the dice (such as on the DnDGenSite or in the tests for TreasureGen), then you need RollGen.Domain, which will install RollGen as a dependency.
