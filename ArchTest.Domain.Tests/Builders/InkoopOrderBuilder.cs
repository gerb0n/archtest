using ArchTest.Entity;
using System;

namespace ArchTest.Domain.Tests.Builders
{
    public class InkoopOrderBuilder
    {
        private InkoopOrder _inkoopOrder;

        public InkoopOrderBuilder()
        {
            _inkoopOrder = new InkoopOrder();
        }

        public InkoopOrderBuilder Default(
            Guid? opdrachtgeverId = null,
            Guid? bevrachterId = null,
            Guid? ladingId = null,
            int? hoeveelheid = 10)
        {
            _inkoopOrder.Create(
                opdrachtgeverId ?? Guid.NewGuid(),
                bevrachterId ?? Guid.NewGuid(),
                ladingId ?? Guid.NewGuid(),
                hoeveelheid);
            return this;
        }

        public InkoopOrderBuilder WithPlaats(InkoopOrderPlaats plaats = null)
        {
            plaats = plaats ?? new InkoopOrderPlaats();

            _inkoopOrder.AddLaadPlaats(plaats);
            return this;
        }

        public InkoopOrder Build()
        {
            return _inkoopOrder;
        }
    }
}
