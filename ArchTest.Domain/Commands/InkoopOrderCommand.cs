using System;

namespace ArchTest.Domain.Commands
{
    public class InkoopOrderCommand
    {
        public InkoopOrderCommand(Guid inkoopOrderId)
        {
            InkoopOrderId = inkoopOrderId;
        }

        public Guid InkoopOrderId { get; }
    }
}
