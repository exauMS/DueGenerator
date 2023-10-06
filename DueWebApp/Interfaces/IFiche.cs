using DueWebApp.Dto;
using DueWebApp.Models;

namespace DueWebApp.Interfaces
{
    public interface IFiche
    {
        public Task<List<Fiche>?> GetFiches();
        public Task<string> PostFiche(Fiche fiche);
    }
}
