using ArchTest.Domain.WriteModel.Entities;
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

        public InkoopOrderBuilder WithPlaats(
            Guid? plaatsId = null,
            Guid? vestigingId = null,
            Guid? overslagbedrijfId = null)
        {
            _inkoopOrder.AddLaadPlaats(
                plaatsId ?? Guid.NewGuid(),
                vestigingId ?? Guid.NewGuid(),
                overslagbedrijfId ?? Guid.NewGuid());

            return this;
        }

        public InkoopOrder Build()
        {
            return _inkoopOrder;
        }
    }
}
