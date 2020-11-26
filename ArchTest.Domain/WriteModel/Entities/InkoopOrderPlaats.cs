using System;

namespace ArchTest.Domain.WriteModel.Entities
{
    public partial class InkoopOrderPlaats
    {
        public Guid Id { get; set; }
        public Guid PlaatsId { get; set; }
        public Guid VestigingId { get; set; }
        public Guid? OverslagbedrijfId { get; set; }

        public VerlaadBeurt VerlaadBeurt { get; set; }
    }
}
