using ArchTest.Core.Utils;
using System;

namespace ArchTest.Entity
{
    public partial class InkoopOrderPlaats
    {
        public void Create(
            Guid plaatsId,
            Guid vestigingId,
            Guid? overslagbedrijfId)
        {
            AssertionHelper.AssertFieldIsNotNullOrDefault(plaatsId, nameof(plaatsId));
            AssertionHelper.AssertFieldIsNotNullOrDefault(vestigingId, nameof(vestigingId));

            PlaatsId = plaatsId;
            VestigingId = vestigingId;
            OverslagbedrijfId = overslagbedrijfId;
        }

        public void VerlaadBeurtAanvragen(Guid? schipId, DateTime datum, string bijzonderheden)
        {
            AssertionHelper.AssertFieldIsNotNullOrDefault(datum, nameof(datum));

            // Hier? Of in Rule?
            if (VerlaadBeurt != null)
            {
                throw new InvalidOperationException($"VerlaadBeurt al aangevraagd voor inkooporderplaats {Id}");
            }

            VerlaadBeurt = new VerlaadBeurt
            {
                SchipId = schipId,
                Datum = datum,
                Bijzonderheden = bijzonderheden
            };
        }
    }
}
