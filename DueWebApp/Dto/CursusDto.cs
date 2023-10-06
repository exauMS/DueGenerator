using DueWebApp.Models;

namespace DueWebApp.Dto
{
    public class CursusDto
    {
        public string Name { get; set; } = string.Empty;
        public string Implentation { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public int DepartementId { get; set; }
    }
}
