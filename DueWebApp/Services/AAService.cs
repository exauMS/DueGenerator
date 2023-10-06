using DueWebApp.Dto;
using DueWebApp.Interfaces;
using DueWebApp.Models;

namespace DueWebApp.Services
{
    public class AAService : IAA
    {
        private readonly HttpClient httpClient;

        public AAService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<AA>?> GetAA()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "getAllAA");
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<AA>>();
        }

        public async Task<string> PostAA(AADto AA)
        {
            var response = await httpClient.PostAsJsonAsync("postAA", AA);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
