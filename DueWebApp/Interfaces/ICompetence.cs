using DueWebApp.Dto;
using DueWebApp.Models;

namespace DueWebApp.Interfaces
{
    public interface ICompetence
    {
        public Task<List<Competence>?> GetCompetences();
        public Task<string> PostCompetence(CompetenceDto competence);
    }
}
