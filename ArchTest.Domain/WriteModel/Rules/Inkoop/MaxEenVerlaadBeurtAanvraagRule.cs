using ArchTest.Domain.Commands.Inkoop;
using ArchTest.Domain.WriteModel.Entities;
using CQRSlite.Commands;
using System;
using System.Linq;

namespace ArchTest.Domain.Rules.Inkoop
{
    public class MaxEenVerlaadBeurtAanvraagRule : BaseRule<MaxEenVerlaadBeurtAanvraagRuleContext>, IRule
    {
        private Type[] Triggers => new[] {
            typeof(VerlaadBeurtAanvragen)
        };

        public void Execute(IRuleContext c)
        {
            var context = ParseContext(c);

            if (context.InkoopOrderPlaats?.VerlaadBeurt != null)
            {
                throw new InvalidOperationException($"VerlaadBeurt al aangevraagd voor inkooporderplaats {context.InkoopOrderPlaats.Id}");
            }
        }

        public bool ShouldBeExecuted(ICommand command)
        {
            return Triggers.Contains(command.GetType());
        }
    }

    public class MaxEenVerlaadBeurtAanvraagRuleContext : IRuleContext
    {
        public InkoopOrderPlaats InkoopOrderPlaats { get; set; }
    }
}
