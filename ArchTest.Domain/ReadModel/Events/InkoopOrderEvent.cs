using System;

namespace ArchTest.Domain.ReadModel.Events
{
    public class InkoopOrderEvent : BaseEvent
    {
        public InkoopOrderEvent(Guid inkoopOrderId)
        {
            InkoopOrderId = inkoopOrderId;
        }

        public Guid InkoopOrderId { get; }
    }
}
