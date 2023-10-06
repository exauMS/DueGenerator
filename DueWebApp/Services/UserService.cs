using DueWebApp.Interfaces;
using DueWebApp.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using DueWebApp.Dto;
using System.Runtime.Intrinsics.X86;

namespace DueWebApp.Services
{
    public class UserService : IUser
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

       

        public async Task<string?> GetToken(Login login)
        {
            var response =  await httpClient.PostAsJsonAsync("login", login);
            response.EnsureSuccessStatusCode();
            
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<List<User>?> GetUsers(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "getUsersInfo");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<User>>();
        }

        public async Task<string> PostUser(UserDto user, string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //var request = new HttpRequestMessage(HttpMethod.Post, "Register");
            //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync("Register",user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> DeleteUser(int id, string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.DeleteAsync("Delete/"+id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
