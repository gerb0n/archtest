using CQRSlite.Commands;
using System;

namespace ArchTest.Domain.Commands
{
    public class VerlaadBeurtAanvragen : InkoopOrderCommand, ICommand
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
