using ProjetoBase_MagnificoPonto.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace ProjetoBase_MagnificoPonto.Models
{
    [Display(Name = "Produtos")]
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public double Referencia { get; set; }
        [Required]  
        public CorType Cor { get; set; }
        [Required]
        public TamanhoType Tamanho { get; set; }
        [Display(Name = "Preço")]
        [Required]
        public double Preco { get; set; }
        [Required]
        public bool ProntaEntrega { get; set; }
        [Display(Name = "Tempo para confecção")]
        [Required]
        public int TempoConfeccao { get; set; }
    }
}