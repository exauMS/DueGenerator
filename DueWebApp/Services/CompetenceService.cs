using DueWebApp.Dto;
using DueWebApp.Interfaces;
using DueWebApp.Models;

namespace DueWebApp.Services
{
    public class CompetenceService : ICompetence
    {
        private readonly HttpClient httpClient;

        public CompetenceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Competence>?> GetCompetences()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "getAllCompetence");
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Competence>>();
        }

        public async Task<string> PostCompetence(CompetenceDto competence)
        {
            var response = await httpClient.PostAsJsonAsync("postCompetence", competence);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
