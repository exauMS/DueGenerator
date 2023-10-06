using DueWebApp.Dto;
using DueWebApp.Interfaces;
using DueWebApp.Models;
using System.Net.Http.Headers;

namespace DueWebApp.Services
{
    public class DepartementService : IDepartement
    {
        private readonly HttpClient httpClient;

        public DepartementService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Departement>?> GetDepartements()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "getAllDepartement");
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Departement>>();
        }

        public async Task<string> PostDepartement(DepartementDto departement)
        {
          
            var response = await httpClient.PostAsJsonAsync("postDepartement", departement);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
