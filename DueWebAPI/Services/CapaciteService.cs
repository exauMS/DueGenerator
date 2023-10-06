using DueWebAPI.Data;
using DueWebAPI.Interfaces;
using DueWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DueWebAPI.Services
{
    public class CapaciteService : ICapacite
    {
        private readonly DataContext dataContext;

        public CapaciteService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<IEnumerable<Capacite>> GetAllCapacite()
        {
           return await dataContext.CapaciteTable.ToListAsync();
        }

        public async Task<Capacite> getCapacite(int id)
        {
            return await dataContext.CapaciteTable.FindAsync(id);
        }

        public async Task<Capacite> postCapacite(Capacite capacite)
        {
            //test competence existe
            var competence = dataContext.CompetenceTable.FirstOrDefault(c => c.Id == capacite.CompetenceId);
            if (competence == null) return null;

            dataContext.CapaciteTable.Add(capacite);
            await dataContext.SaveChangesAsync();
            return capacite;
        }
    }
}
