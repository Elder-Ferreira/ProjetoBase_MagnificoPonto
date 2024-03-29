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
        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Preco { get; set; }
        [Required]
        [StringLength(800)]
        [Display(Name = "Descrição do item")]
        public string Descrição { get; set; }
        [Required]
        public bool ProntaEntrega { get; set; }
        [Display(Name = "Tempo para confecção")]
        [Required]
        public int TempoConfeccao { get; set; }
    }
}
