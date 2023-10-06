using DueWebAPI.Data;
using DueWebAPI.Interfaces;
using DueWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DueWebAPI.Services
{
    public class UEService : IUE
    {
        private readonly DataContext dataContext;

        public UEService(DataContext dataContext) 
        {
            this.dataContext = dataContext;
        }

        public async Task<IEnumerable<UE>> GetAllUE()
        {
            return await dataContext.UETable.ToListAsync();
        }

        public async Task<UE> getUE(int id)
        {
            return await dataContext.UETable.FindAsync();
        }

        public async Task<string> postUE(UE UE)
        {
            //test cursus existe
            var cursus = dataContext.CursusTable.FirstOrDefault(c => c.Id == UE.CursusId);
            if (cursus == null) return null;

            dataContext.UETable.Add(UE);
            await dataContext.SaveChangesAsync();
            return "UE created.";
        }
    }
}
