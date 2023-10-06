using DueWebApp.Dto;
using DueWebApp.Models;

namespace DueWebApp.Interfaces
{
    public interface ICapacite
    {
        public Task<List<Capacite>?> GetCapacite();
        public Task<string> PostCapacite(CapaciteDto capacite);
    }
}
