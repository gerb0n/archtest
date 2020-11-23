using CQRSlite.Commands;
using System;

namespace ArchTest.Domain.Commands.Inkoop
{
    public class InkoopOrderCommand : ICommand
    {
        public InkoopOrderCommand(Guid inkoopOrderId)
        {
            InkoopOrderId = inkoopOrderId;
        }

        public Guid InkoopOrderId { get; }
    }
}
