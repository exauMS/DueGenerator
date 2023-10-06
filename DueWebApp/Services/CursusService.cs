using DueWebApp.Dto;
using DueWebApp.Interfaces;
using DueWebApp.Models;
using System.Net.Http;

namespace DueWebApp.Services
{
    public class CursusService : ICursus
    {
        private readonly HttpClient httpClient;

        public CursusService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Cursus>?> GetCursus()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "getAllCursus");
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Cursus>>();
        }

        public async Task<string> PostCursus(CursusDto cursus)
        {
            var response = await httpClient.PostAsJsonAsync("postCursus", cursus);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
