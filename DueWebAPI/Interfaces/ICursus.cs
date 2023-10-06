using DueWebAPI.Models;

namespace DueWebAPI.Interfaces
{
    public interface ICursus
    {
        public Task<Cursus> getCursus(int id);
        public Task<IEnumerable<Cursus>> GetAllCursus();
        public Task<string> postCursus(Cursus cursus);
        
    }
}
