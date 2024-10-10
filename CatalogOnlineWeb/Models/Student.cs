using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CatalogOnlineWeb.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [DisplayName("Nume*")]
        [Required(ErrorMessage = "Acest camp este obligatoriu!")]
        [StringLength(20)]
        public string Nume { get; set; }
		[DisplayName("Prenume*")]
		[Required(ErrorMessage = "Acest camp este obligatoriu!")]
        [StringLength(20)]
        public string Prenume { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Acest camp este obligatoriu!")]
		[DisplayName("Parola*")]
		public string Parola { get; set; }
		//[Required(ErrorMessage = "Acest camp este obligatoriu!")]
		[Range(1, 4, ErrorMessage = "An invalid!")]
        public int? An { get; set; }

        public Student()
        {
            An = 1;
        }
    }
}
