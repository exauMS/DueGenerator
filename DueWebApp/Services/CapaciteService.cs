using DueWebApp.Dto;
using DueWebApp.Interfaces;
using DueWebApp.Models;

namespace DueWebApp.Services
{
    public class CapaciteService : ICapacite
    {
        private readonly HttpClient httpClient;

        public CapaciteService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<Capacite>?> GetCapacite()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "getAllCapacite");
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Capacite>>();
        }

        public async Task<string> PostCapacite(CapaciteDto capacite)
        {
            var response = await httpClient.PostAsJsonAsync("postCapacite", capacite);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
