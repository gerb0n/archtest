using ArchTest.Domain.WriteModel.Entities;
using System.Threading.Tasks;

namespace ArchTest.Domain.Services.Interfaces
{
    public interface IVerlaadBeurtService
    {
        Task VerlaadBeurtAanvraagMailSturen(InkoopOrderPlaats inkoopOrderPlaats);
    }
}
