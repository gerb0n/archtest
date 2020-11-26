using ArchTest.Domain.ReadModel.Dto;
using ArchTest.Domain.WriteModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArchTest.Domain
{
    public class ArchTestContext : DbContext
    {
        public ArchTestContext(DbContextOptions<ArchTestContext> options)
            : base(options)
        {

        }

        // Write
        public DbSet<InkoopOrder> InkoopOrders { get; set; }
        public DbSet<InkoopOrderPlaats> InkoopOrderPlaatsen { get; set; }

        // Read
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PlaatsItem> PlaatsItem { get; set; }

    }
}
