using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CatalogOnlineWeb.Models
{
    public class Disciplina
    {
        [Key]
        public int DisciplinaId { get; set; }

        [DisplayName("Titlu*")]
        [Required(ErrorMessage = "Acest camp este obligatoriu!")]
        [StringLength(40)]
        public string Titlu { get; set; }

        [DisplayName("An*")]
        [Range(1, 4, ErrorMessage = "Valoarea poate fi doar intre 1 si 4!")]
        [Required(ErrorMessage = "Acest camp este obligatoriu!")]
        public int? An { get; set; }

        [DisplayName("Semestru*")]
        [Range(1, 2, ErrorMessage = "Valoarea poate fi doar intre 1 si 2!")]
        [Required(ErrorMessage = "Acest camp este obligatoriu!")]
        public int? Semestru { get; set; }
        [DisplayName("Credite*")]
        [Range(1, 6, ErrorMessage = "Valoarea poate fi doar intre 1 si 6!")]
        [Required(ErrorMessage = "Acest camp este obligatoriu!")]
        public int Credite { get; set; }    
    }
}
