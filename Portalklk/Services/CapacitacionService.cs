using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using RecursosHumanos.Shared;

namespace Portalklk.Services
{
    public class CapacitacionService : ICapacitacionService
    {
        private readonly HttpClient _httpClient;

        public CapacitacionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CapacitacionGetDTO>> List()
        {
            var response = await _httpClient.GetFromJsonAsync<List<CapacitacionGetDTO>>("https://localhost:5001/api/capacitacion");
            return response ?? new List<CapacitacionGetDTO>();
        }

        public async Task<CapacitacionGetDTO> Get(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _httpClient.GetFromJsonAsync<CapacitacionGetDTO>($"https://localhost:5001/api/capacitacion/{id}");
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task Update(int id, CapacitacionUpdateDTO capacitacion)
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:5001/api/capacitacion/{id}", capacitacion);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"https://localhost:5001/api/capacitacion/{id}");
        }
    }
}
