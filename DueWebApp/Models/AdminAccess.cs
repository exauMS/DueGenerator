namespace DueWebApp.Models
{
    public class AdminAccess
    {
        public List<User>? Users { get; set; }
        public List<Departement>? Departements { get; set; }
        public List<Cursus>? Cursus { get; set; }
        public List<Competence>? Competences { get; set; }
        public List<UE>? UE { get; set; }
        public List<AA>? AA { get; set; }
        public List<Fiche>? Fiches { get; set; }
        public List<Fiche>? FilterFiches { get; set; }
    }
}
