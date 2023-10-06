namespace DueWebApp.Models
{
    public class UE
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int CursusId { get; set; }
    }
}
