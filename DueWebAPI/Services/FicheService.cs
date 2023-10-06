using DueWebAPI.Data;
using DueWebAPI.Interfaces;
using DueWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DueWebAPI.Services
{
    public class FicheService : IFiche
    {
        private readonly DataContext dataContext;

        public FicheService(DataContext dataContext) 
        {
            this.dataContext = dataContext;
        }
        public async Task<IEnumerable<Fiche>> GetAllFiche()
        {
            return await dataContext.FicheTable.ToListAsync();
        }

        public async Task<Fiche> getFiche(int id)
        {
            return await dataContext.FicheTable.FindAsync(id);
        }

        public async Task<Fiche> postFiche(Fiche fiche)
        {
            dataContext.Add(fiche);
            await dataContext.SaveChangesAsync();
            return fiche; 
        }
    }
}
