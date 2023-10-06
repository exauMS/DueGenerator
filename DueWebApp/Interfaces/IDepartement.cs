using DueWebApp.Dto;
using DueWebApp.Models;

namespace DueWebApp.Interfaces
{
    public interface IDepartement
    {
        public Task<List<Departement>?> GetDepartements();
        public Task<string> PostDepartement(DepartementDto departement);
    }
}
