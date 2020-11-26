using System;
using System.Collections.Generic;

namespace ArchTest.Domain.ReadModel.Dto
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OpdrachtgeverId { get; set; }
        public Guid BevrachterId { get; set; }
        public Guid LadingId { get; set; }
        public int? Hoeveelheid { get; set; }

        public List<PlaatsItem> LaadPlaatsen { get; set; }
    }
}
