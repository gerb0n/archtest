using System;

namespace ArchTest.Domain.ReadModel.Events
{
    public class InkoopOrderCreated : InkoopOrderEvent
    {
        public InkoopOrderCreated(
            Guid inkoopOrderId,
            Guid opdrachtgeverId,
            Guid bevrachterId,
            Guid ladingId,
            int? hoeveelheid)
            : base(inkoopOrderId)
        {
            OpdrachtgeverId = opdrachtgeverId;
            BevrachterId = bevrachterId;
            LadingId = ladingId;
            Hoeveelheid = hoeveelheid;
        }

        public Guid OpdrachtgeverId { get; }

        public Guid BevrachterId { get; }

        public Guid LadingId { get; }

        public int? Hoeveelheid { get; }
    }
}
