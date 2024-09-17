using System.ComponentModel.DataAnnotations;

namespace CatalogOnlineWeb.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required]
        [StringLength(20)]
        public string Nume { get; set; }
        [Required]
        [StringLength(20)]
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }  
    }
}
