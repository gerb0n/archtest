using CQRSlite.Domain;
using System;
using System.Collections.Generic;

namespace ArchTest.Domain.WriteModel.Entities
{
    /// <summary>
    /// InkoopOrder kan best wel eens zo groot zijn als Customer bij ACD.
    /// Wat is de les die geleerd is bij ACD? Meerdere aggregrate roots? Andere manier van werken? Het is nu bij mij ook zo'n partial class constructie wat uit de klauwen 'kan' lopen.
    /// Heb geen zin in trage intellisense e.d.
    /// Ook heb ik alle actions verhuist naar Mutations folder.
    /// </summary>
    public partial class InkoopOrder : AggregateRoot
    {
        public Guid OpdrachtgeverId { get; set; }
        public Guid BevrachterId { get; set; }
        public Guid LadingId { get; set; }
        public int? Hoeveelheid { get; set; }

        public List<InkoopOrderPlaats> LaadPlaatsen { get; set; }
    }
}
