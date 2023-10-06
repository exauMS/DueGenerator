using DueWebAPI.Data;
using DueWebAPI.Interfaces;
using DueWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DueWebAPI.Services
{
    public class AAService : IAA
    {
        private readonly DataContext dataContext;

        public AAService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<AA> getAA(int id)
        {
           return await dataContext.AATable.FindAsync(id);
        }

        public async Task<IEnumerable<AA>> GetAllAA()
        {
            return await dataContext.AATable.ToListAsync();
        }

        public async Task<AA> postAA(AA AA)
        {
            dataContext.AATable.Add(AA);
            await dataContext.SaveChangesAsync();
            return AA;
        }
    }
}
