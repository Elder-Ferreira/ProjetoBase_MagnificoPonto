using ProjetoBase_MagnificoPonto.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBase_MagnificoPonto.Models
{
    public class Amigurumi
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public double Referencia { get; set; }
        [Required]
        public CorType Cor { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        [Required]
        public double Preco { get; set; }
        [Required]
        public bool ProntaEntrega { get; set; }
        [Display(Name = "Tempo para confecção")]
        [Required]
        public int TempoConfeccao { get; set; }
    }
}
