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

        /// <summary>
        /// Deze 'rules' hebben een X aantal entiteiten nodig om hun business-logica uit te voeren. Of zouden de business-rules altijd en alleen maar afhankelijk moeten zijn van hun aggregate-root?
        /// Maar hoe krijg je die entiteiten/objecten binnen de ze functie. Dit gaat per rule verschillen.
        /// </summary>
        public void Execute()
        {
            // Er wordt een check uitgevoerd of een verlaadbeurt al aangevraagd is. Dit is typisch zo'n business-rule zodat er geen twee aanvragen verstuurd worden.
            // Is dit de juiste plek? Of zou dit eigenlijk 

            if (false) //if (VerlaadBeurt != null) //<- zou dit moeten zijn maar voor debugging statement veranderd
            {
                throw new InvalidOperationException($"VerlaadBeurt al aangevraagd voor inkooporderplaats <id-here>");
            }
        }

        public bool ShouldBeExecuted(ICommand command)
        {
            // Adhv bovenstaande Triggers kan bepaald worden bij elk commands deze rule actief moet zijn.
            // Wellicht niet voldoende en zijn er meerdere variabelen die bepalen of een rule uitgevoerd moet worden. Ik weet niet meer hoe dat zat bij ACD.
            return Triggers.Contains(command.GetType());
        }
    }
}
