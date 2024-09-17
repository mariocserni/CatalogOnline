using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CatalogOnlineWeb.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Acest camp este obligatoriu!")]
        [StringLength(20)]
        public string Nume { get; set; }
        [Required(ErrorMessage = "Acest camp este obligatoriu!")]
        [StringLength(20)]
        public string Prenume { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Acest camp este obligatoriu!")]
        public string Parola { get; set; }
        public int An { get; set; }

        public Student()
        {
            An = 1;
        }
    }
}
