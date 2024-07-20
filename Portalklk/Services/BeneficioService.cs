using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using RecursosHumanos.Shared;

namespace Portalklk.Services
{
    public class BeneficioService : IBeneficioService
    {
        private readonly HttpClient _httpClient;

        public BeneficioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BeneficioGetDTO>> List()
        {
            var response = await _httpClient.GetFromJsonAsync<List<BeneficioGetDTO>>("api/Beneficios");
            return response ?? new List<BeneficioGetDTO>();
        }

        public async Task<BeneficioGetDTO> Get(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _httpClient.GetFromJsonAsync<BeneficioGetDTO>($"api/Beneficios/{id}");
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task Update(int id, BeneficioUpdateDTO beneficio)
        {
            await _httpClient.PutAsJsonAsync($"api/Beneficios/{id}", beneficio);
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Beneficios/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task Create(BeneficioInsertDTO beneficio) // Implementar método de inserción
        {
            await _httpClient.PostAsJsonAsync("api/Beneficios", beneficio);
        }
    }
}
