using DueWebAPI.Models;

namespace DueWebAPI.Interfaces
{
    public interface IDepartement
    {
        public Task<Departement> getDepartement(int id);
        public Task<IEnumerable<Departement>> GetAllDepartement();
        public Task<string> postDepartement(Departement departement);
    }
}
