using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBase_MagnificoPonto.Models
{
    [Table("Galerias")]
    public class Galeria
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CaminhoImagem { get; set; }
        [Precision(16, 2)]
        public decimal Preco { get; set; }
    }
}
