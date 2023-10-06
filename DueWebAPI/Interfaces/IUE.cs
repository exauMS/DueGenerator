using DueWebAPI.Models;

namespace DueWebAPI.Interfaces
{
    public interface IUE
    {
        public Task<UE> getUE(int id);
        public Task<IEnumerable<UE>> GetAllUE();
        public Task<string> postUE(UE UE);
       
    }
}
