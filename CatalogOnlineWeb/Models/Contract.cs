using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace CatalogOnlineWeb.Models
{
    public class Contract
    {
        [Key]
        public int ContractId { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        [ForeignKey(nameof(Disciplina))]
        public int DisciplinaId { get; set; }
        public double Medie { get; set; }
        public List<Nota> Note { get; set; }
    }
}
