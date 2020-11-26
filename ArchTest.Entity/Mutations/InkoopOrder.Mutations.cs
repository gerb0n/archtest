using System;
using System.Collections.Generic;
using System.Linq;

namespace ArchTest.Entity
{
    public partial class InkoopOrder
    {
        public void Create(
            Guid opdrachtgeverId,
            Guid bevrachterId,
            Guid ladingId,
            int? hoeveelheid)
        {
            OpdrachtgeverId = opdrachtgeverId;
            BevrachterId = bevrachterId;
            LadingId = ladingId;
            Hoeveelheid = hoeveelheid;
        }

        public void AddLaadPlaats(InkoopOrderPlaats laadPlaats)
        {
            AssertNoPlaatsDuplicates(this.LaadPlaatsen, laadPlaats, nameof(laadPlaats));

            LaadPlaatsen = LaadPlaatsen ?? new List<InkoopOrderPlaats>();
            LaadPlaatsen.Add(laadPlaats);
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
