using DueWebApp.Dto;
using DueWebApp.Models;

namespace DueWebApp.Interfaces
{
    public interface IUE
    {
        public Task<List<UE>?> GetUE();
        public Task<string> PostUE(UEDto UE);
    }
}
