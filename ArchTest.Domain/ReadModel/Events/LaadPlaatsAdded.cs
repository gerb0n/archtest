using System;

namespace ArchTest.Domain.ReadModel.Events
{
    public class LaadPlaatsAdded : InkoopOrderEvent
    {
        public LaadPlaatsAdded(
            Guid inkoopOrderId,
            Guid inkoopOrderPlaatsId,
            Guid plaatsId,
            Guid vestigingId,
            Guid? overslagBedrijfId)
            : base(inkoopOrderId)
        {
            InkoopOrderPlaatsId = inkoopOrderPlaatsId;
            PlaatsId = plaatsId;
            VestigingId = vestigingId;
            OverslagBedrijfId = overslagBedrijfId;
        }

        public Guid InkoopOrderPlaatsId { get; }
        public Guid PlaatsId { get; }
        public Guid VestigingId { get; }
        public Guid? OverslagBedrijfId { get; }
    }
}
