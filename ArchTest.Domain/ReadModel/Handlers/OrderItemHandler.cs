using ArchTest.Domain.ReadModel.Dto;
using ArchTest.Domain.ReadModel.Events;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchTest.Domain.ReadModel.Handlers
{
    public class OrderItemHandler :
        ICancellableQueryHandler<InkoopOrderCreated>,
        ICancellableQueryHandler<LaadPlaatsAdded>,
        ICancellableQueryHandler<VerlaadBeurtAangevraagd>
    {
        private readonly ArchTestContext _dbContext;

        public OrderItemHandler(ArchTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(InkoopOrderCreated message)
        {
            var orderItem = new OrderItem();
            orderItem.Id = message.InkoopOrderId;
            _dbContext.OrderItems.Add(orderItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Handle(LaadPlaatsAdded message)
        {
            var orderItem = await GetOrderItem(message.InkoopOrderId);
            orderItem.LaadPlaatsen = orderItem.LaadPlaatsen ?? new List<PlaatsItem>();
            orderItem.LaadPlaatsen.Add(new PlaatsItem
            {
                Id = message.InkoopOrderPlaatsId,
                PlaatsId = message.PlaatsId,
                VestigingId = message.VestigingId,
                OverslagbedrijfId = message.OverslagBedrijfId,
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task Handle(VerlaadBeurtAangevraagd message)
        {
            var orderItem = await GetOrderItem(message.InkoopOrderId);
            var plaats = orderItem.LaadPlaatsen.First(lp => lp.Id == message.InkoopOrderPlaatsId);

            plaats.SchipId = message.SchipId;
            plaats.Datum = message.Datum;
            plaats.Bijzonderheden = message.Bijzonderheden;

            await _dbContext.SaveChangesAsync();
        }

        private Task<OrderItem> GetOrderItem(Guid id)
        {
            return _dbContext.OrderItems
                .Include(o => o.LaadPlaatsen)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
