using DueWebApp.Dto;
using DueWebApp.Models;

namespace DueWebApp.Interfaces
{
    public interface ICursus
    {
        public Task<List<Cursus>?> GetCursus();
        public Task<string> PostCursus(CursusDto cursus);
    }
}
