using ArchTest.Domain.Services.Interfaces;
using ArchTest.EF;
using ArchTest.Entity;
using System.Threading.Tasks;

namespace ArchTest.Domain.Services
{
    public class VerlaadBeurtService : IVerlaadBeurtService
    {
        private readonly ArchTestContext _dbContext;

        public VerlaadBeurtService(ArchTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task VerlaadBeurtAanvraagMailSturen(InkoopOrderPlaats inkoopOrderPlaats)
        {
            // vestiging ophalen adhv id
            // bij vestiging kijken of property X actief is
            // zoja mail sturen, zo nee niet

            //  hoe unittest je welke flow het invalt
            return Task.CompletedTask;
        }
    }
}
