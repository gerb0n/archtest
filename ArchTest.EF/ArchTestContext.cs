using ArchTest.Entity;
using Microsoft.EntityFrameworkCore;

namespace ArchTest.EF
{
    public class ArchTestContext : DbContext
    {
        public ArchTestContext(DbContextOptions<ArchTestContext> options)
            : base(options)
        {

        }

        public DbSet<InkoopOrder> InkoopOrders { get; set; }
        public DbSet<InkoopOrderPlaats> InkoopOrderPlaatsen { get; set; }
    }
}
