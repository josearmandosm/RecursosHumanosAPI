using RecursosHumanos.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portalklk.Services
{
    public interface IBeneficioService
    {
        Task<List<BeneficioGetDTO>> List();
        Task<BeneficioGetDTO> Get(int id);
        Task Update(int id, BeneficioUpdateDTO beneficio);
        Task<bool> Delete(int id);
        Task Create(BeneficioInsertDTO beneficio);
    }
}
