using DueWebAPI.Data;
using DueWebAPI.Interfaces;
using DueWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DueWebAPI.Services
{
    public class DepartementService : IDepartement
    {
        private readonly DataContext dataContext;

        public DepartementService(DataContext dataContext) 
        {
            this.dataContext = dataContext;
        }

        public async Task<IEnumerable<Departement>> GetAllDepartement()
        {
            return await dataContext.DepartementTable.ToListAsync();
        }

        public async Task<Departement> getDepartement(int id)
        {
            return await dataContext.DepartementTable.FindAsync();
        }

        public async Task<string> postDepartement(Departement departement)
        {
            dataContext.DepartementTable.Add(departement);
            await dataContext.SaveChangesAsync();
            return "departement created!";
        }
    }
}
