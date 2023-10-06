using DueWebAPI.Models;

namespace DueWebAPI.Interfaces
{
    public interface IAA
    {
        public Task<IEnumerable<AA>> GetAllAA();
        public Task<AA> getAA(int id);
        public Task<AA> postAA(AA AA);
       
    }
}
