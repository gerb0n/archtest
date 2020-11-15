using CQRSlite.Domain;
using System;

namespace ArchTest.Entity
{
    public partial class InkoopOrderPlaats : AggregateRoot
    {
        public Guid PlaatsId { get; set; }
        public Guid VestigingId { get; set; }
        public Guid? OverslagbedrijfId { get; set; }

        public VerlaadBeurt VerlaadBeurt { get; set; }
    }
}
