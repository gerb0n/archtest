using System;

namespace ArchTest.Domain.Commands.Inkoop
{
    public class VerlaadBeurtAanvragen : InkoopOrderCommand
    {
        public VerlaadBeurtAanvragen(Guid inkoopOrderId, Guid inkoopOrderPlaatsId, Guid? schipId, DateTime datum, string bijzonderheden)
            : base(inkoopOrderId)
        {
            InkoopOrderPlaatsId = inkoopOrderPlaatsId;
            SchipId = schipId;
            Datum = datum;
            Bijzonderheden = bijzonderheden;
        }

        public Guid InkoopOrderPlaatsId { get; }
        public Guid? SchipId { get; }
        public DateTime Datum { get; }
        public string Bijzonderheden { get; }
    }
}
