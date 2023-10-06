using DueWebAPI.Data;
using DueWebAPI.Interfaces;
using DueWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DueWebAPI.Services
{
    public class CompetenceService : ICompetence
    {
        private readonly DataContext dataContext;

        public CompetenceService(DataContext dataContext) 
        {
            this.dataContext = dataContext;
        }
        public async Task<IEnumerable<Competence>> GetAllCompetence()
        {
            return await dataContext.CompetenceTable.ToListAsync();
        }

        public async Task<Competence> getCompetence(int id)
        {
            return await dataContext.CompetenceTable.FindAsync(id);
        }

        public async Task<Competence> postCompetence(Competence competence)
        {
            dataContext.CompetenceTable.Add(competence);
            await dataContext.SaveChangesAsync();
            return competence;
        }
    }
}
