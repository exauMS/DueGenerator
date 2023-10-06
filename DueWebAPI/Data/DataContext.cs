using DueWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DueWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<AA> AATable { get; set; }
        public DbSet<Capacite> CapaciteTable { get; set; }
        public DbSet<Competence> CompetenceTable { get; set; }
        public DbSet<Cursus> CursusTable { get; set; }
        public DbSet<Departement> DepartementTable { get; set; }
        public DbSet<Professeur> ProfesseurTable { get; set; }
        public DbSet<UE> UETable { get; set; }
        public DbSet<Fiche> FicheTable { get; set; }






    }
}
