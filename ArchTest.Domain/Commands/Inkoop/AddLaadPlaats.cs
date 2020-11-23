using System;

namespace ArchTest.Domain.Commands.Inkoop
{
    public class AddLaadPlaats : InkoopOrderCommand
    {
        public AddLaadPlaats(
            Guid inkoopOrderId,
            Guid plaatsId,
            Guid vestigingId,
            Guid? overslagId)
            : base(inkoopOrderId)
        {
            PlaatsId = plaatsId;
            VestigingId = vestigingId;
            OverslagId = overslagId;
        }

        public Guid PlaatsId { get; }
        public Guid VestigingId { get; }
        public Guid? OverslagId { get; }
    }
}
