using DueWebApp.Interfaces;
using DueWebApp.Models;

namespace DueWebApp.Services
{
    public class FicheService : IFiche
    {
        private readonly HttpClient httpClient;

        public FicheService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<Fiche>?> GetFiches()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "getAllFiche");
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Fiche>>();
        }

        public async Task<string> PostFiche(Fiche fiche)
        {
            var response = await httpClient.PostAsJsonAsync("postFiche", fiche);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
