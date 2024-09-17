using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogOnlineWeb.Models
{
    public class Nota
    {
        [Key]
        public int NotaId { get; set; }
        public DateTime Data { get; set; }
        [ForeignKey(nameof(Contract))]
        public int ContractId { get; set; }
        public double Valoare { get; set; }
    }
}
