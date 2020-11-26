using System;

namespace ArchTest.Domain.ReadModel.Dto
{
    public class PlaatsItem
    {
        public Guid Id { get; set; }
        public Guid PlaatsId { get; set; }
        public Guid VestigingId { get; set; }
        public Guid? OverslagbedrijfId { get; set; }
        public Guid? SchipId { get; set; }
        public DateTime Datum { get; set; }
        public string Bijzonderheden { get; set; }
    }
}
