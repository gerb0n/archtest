using CQRSlite.Domain;
using System;

namespace ArchTest.Entity
{
    public class VerlaadBeurt : AggregateRoot
    {
        public Guid? SchipId { get; set; }
        public DateTime Datum { get; set; }
        public string Bijzonderheden { get; set; }
    }
}
