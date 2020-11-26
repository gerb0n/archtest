using System;

namespace ArchTest.Domain.Commands.Inkoop
{
    public class AddLaadPlaats : InkoopOrderCommand
    {
        public AddLaadPlaats(
            Guid inkoopOrderId,
            Guid plaatsId,
            Guid vestigingId,
            Guid? overslagBedrijfId)
            : base(inkoopOrderId)
        {
            PlaatsId = plaatsId;
            VestigingId = vestigingId;
            OverslagBedrijfId = overslagBedrijfId;
        }

        public Guid PlaatsId { get; }
        public Guid VestigingId { get; }
        public Guid? OverslagBedrijfId { get; }
    }
}
