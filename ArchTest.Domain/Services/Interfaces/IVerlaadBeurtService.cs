using System.Threading.Tasks;

namespace ArchTest.Domain.Services.Interfaces
{
    public interface IVerlaadBeurtService
    {
        Task VerlaadBeurtAanvraagMailSturen(Entity.InkoopOrderPlaats inkoopOrderPlaats);
    }
}
