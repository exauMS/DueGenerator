using DueWebAPI.Data;
using DueWebAPI.Interfaces;
using DueWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DueWebAPI.Services
{
    public class CursusService : ICursus
    {
        private readonly DataContext dataContext;

        public CursusService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<IEnumerable<Cursus>> GetAllCursus()
        {
            return await dataContext.CursusTable.ToListAsync();
        }

        public async Task<Cursus> getCursus(int id)
        {
            return await dataContext.CursusTable.FindAsync(id);
        }

        public async Task<string> postCursus(Cursus cursus)
        {
            //test departement existe
            var departement = dataContext.DepartementTable.FirstOrDefault(d => d.Id == cursus.DepartementId);
            if (departement == null) return null;

            dataContext.CursusTable.Add(cursus);
            await dataContext.SaveChangesAsync();
            return "Cursus created.";
        }
    }
}
