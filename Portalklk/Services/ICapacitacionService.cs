using RecursosHumanos.Shared;

namespace Portalklk.Services
{
    public interface ICapacitacionService
    {
        Task<List<CapacitacionGetDTO>> List();
        Task<CapacitacionGetDTO> Get(int id);
        Task Update(int id, CapacitacionUpdateDTO capacitacion);
        Task Delete(int id);
    }
}
