namespace DueWebApp.Models
{
    public class Cursus
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Implentation { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public int DepartementId { get; set; }
    }
}
