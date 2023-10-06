using DueWebAPI.Models;

namespace DueWebAPI.Interfaces
{
    public interface ICompetence
    {
        public Task<Competence> getCompetence(int id);
        public Task<IEnumerable<Competence>> GetAllCompetence();
        public Task<Competence> postCompetence(Competence competence);

    }
}
