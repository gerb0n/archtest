using CQRSlite.Domain;
using System;
using System.Collections.Generic;

namespace ArchTest.Entity
{
    public partial class InkoopOrder : AggregateRoot
    {
        public Guid OpdrachtgeverId { get; set; }
        public Guid BevrachterId { get; set; }
        public Guid LadingId { get; set; }
        public int? Hoeveelheid { get; set; }

        public List<InkoopOrderPlaats> LaadPlaatsen { get; set; }
    }
}
