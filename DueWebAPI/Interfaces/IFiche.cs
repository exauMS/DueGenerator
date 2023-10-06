using DueWebAPI.Models;

namespace DueWebAPI.Interfaces
{
    public interface IFiche
    {
        public Task<IEnumerable<Fiche>> GetAllFiche();
        public Task<Fiche> postFiche(Fiche fiche);
        public Task<Fiche> getFiche(int id);
    }
}
