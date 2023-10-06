using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DueWebAPI.Models
{
    public class Capacite
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int CompetenceId { get; set; }
    }
}
