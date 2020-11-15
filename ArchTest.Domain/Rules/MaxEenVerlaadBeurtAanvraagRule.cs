using ArchTest.Domain.Commands;
using CQRSlite.Commands;
using System;
using System.Linq;

namespace ArchTest.Domain.Rules
{
    public class MaxEenVerlaadBeurtAanvraagRule : IRule
    {
        private Type[] Triggers => new[] {
            typeof(VerlaadBeurtAanvragen)
        };

        public void Execute()
        {
            // Hoe krijg ik mijn entity hier of andere waarden die van toepassing zijn op deze business rule
            // Hier of in Entity Mutation?
            //if (VerlaadBeurt != null)
            if (false)
            {
                throw new InvalidOperationException($"VerlaadBeurt al aangevraagd voor inkooporderplaats <id-here>");
            }
        }

        public bool ShouldBeExecuted(ICommand command)
        {
            return Triggers.Contains(command.GetType());
        }
    }
}
