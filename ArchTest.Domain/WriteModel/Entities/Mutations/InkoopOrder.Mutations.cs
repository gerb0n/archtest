using ArchTest.Domain.ReadModel.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArchTest.Domain.WriteModel.Entities
{
    public partial class InkoopOrder
    {
        public void Create(
            Guid opdrachtgeverId,
            Guid bevrachterId,
            Guid ladingId,
            int? hoeveelheid)
        {
            Id = Guid.NewGuid();
            OpdrachtgeverId = opdrachtgeverId;
            BevrachterId = bevrachterId;
            LadingId = ladingId;
            Hoeveelheid = hoeveelheid;

            ApplyEvent(new InkoopOrderCreated(Id, OpdrachtgeverId, BevrachterId, LadingId, Hoeveelheid));
        }

        public void AddLaadPlaats(Guid plaatsId, Guid vestigingId, Guid? overslagBedrijfId)
        {
            var newPlaatsId = Guid.NewGuid();

            var plaats = new InkoopOrderPlaats();
            plaats.Create(
                newPlaatsId,
                plaatsId,
                vestigingId,
                overslagBedrijfId);

            AssertNoPlaatsDuplicates(this.LaadPlaatsen, plaats, nameof(plaats));
            LaadPlaatsen = LaadPlaatsen ?? new List<InkoopOrderPlaats>();
            LaadPlaatsen.Add(plaats);

            ApplyChange(new LaadPlaatsAdded(Id, newPlaatsId, plaatsId, vestigingId, overslagBedrijfId));
        }

        private void AssertNoPlaatsDuplicates(List<InkoopOrderPlaats> plaatsen, InkoopOrderPlaats plaats, string fieldName)
        {
            if (plaatsen?.Any(cp => cp.Id == plaats.Id) ?? false)
            {
                throw new ArgumentException("Plaats already exists", fieldName);
            }
        }
    }
}
