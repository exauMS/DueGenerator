namespace DueWebAPI.Models
{
    public class Fiche
    {
        public int FicheId { get; set; }
        public string Annee { get; set; } = string.Empty;
        public string Titre { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Departement { get; set; } = string.Empty;
        public string Cursus { get; set; } = string.Empty;
        public string Orientation { get; set; } = string.Empty;
        public string Implantation { get; set; } = string.Empty;
        public string NumSecretariat { get; set; } = string.Empty;
        public string Cycle { get; set; } = string.Empty;
        public string Bloc { get; set; } = string.Empty;
        public string Quadrimestre { get; set; } = string.Empty;
        public string NiveauCertification { get; set; } = string.Empty;
        public string UEPrerequis { get; set; } = string.Empty;
        public string UECorequis { get; set; } = string.Empty;
        public string VolHoraire { get; set; } = string.Empty;
        public string Ects { get; set; } = string.Empty;
        public string LangueEnseignement { get; set; } = string.Empty;
        public string LangueEvaluation { get; set; } = string.Empty;
        public string ResponsableUE { get; set; } = string.Empty;
        public string TitulaireAA { get; set; } = string.Empty;
        public string Competences { get; set; } = string.Empty;
        public string Capacites { get; set; } = string.Empty;
        public string Acquis { get; set; } = string.Empty;
        public string ContenuSynthetique { get; set; } = string.Empty;
        public string MethodeApprentissage { get; set; } = string.Empty;
        public string SupportCours { get; set; } = string.Empty;
       public string TypeEvaluation { get; set; } = string.Empty;
       public string CalculNote { get; set; } = string.Empty;
    }
}
