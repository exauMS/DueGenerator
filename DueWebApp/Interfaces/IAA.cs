using DueWebApp.Dto;
using DueWebApp.Models;

namespace DueWebApp.Interfaces
{
    public interface IAA
    {
        public Task<List<AA>?> GetAA();
        public Task<string> PostAA(AADto AA);
    }
}
