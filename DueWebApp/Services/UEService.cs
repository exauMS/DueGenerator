using DueWebApp.Dto;
using DueWebApp.Interfaces;
using DueWebApp.Models;

namespace DueWebApp.Services
{
    public class UEService : IUE
    {
        private readonly HttpClient httpClient;

        public UEService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<UE>?> GetUE()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "getAllUE");
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<UE>>();
        }

        public async Task<string> PostUE(UEDto UE)
        {
            var response = await httpClient.PostAsJsonAsync("postUE", UE);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
