using DueWebAPI.Models;

namespace DueWebAPI.Interfaces
{
    public interface ICapacite
    {
        public Task<Capacite> getCapacite(int id);
        public Task<IEnumerable<Capacite>> GetAllCapacite();
        public Task<Capacite> postCapacite(Capacite capacite);

       
    }
}
