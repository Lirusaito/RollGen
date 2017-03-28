using Albatross.Expression;
using Ninject.Modules;
using RollGen.Domain.Expressions;
using RollGen.Domain.PartialRolls;
using System;

namespace RollGen.Domain.IoC.Modules
{
    internal class CoreModule : NinjectModule
    {
        public override void Load()
        {
            Bind<Random>().ToSelf().InSingletonScope();
            Bind<IDice>().To<DomainDice>();
            Bind<IPartialRollFactory>().To<DomainPartialRollFactory>();
            Bind<IExpressionEvaluator>().To<AlbatrossExpressionEvaluator>();
            Bind<IParser>().ToMethod(c => Parser.GetParser());
        }
    }
}