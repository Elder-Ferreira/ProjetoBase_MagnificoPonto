using System.ComponentModel.DataAnnotations;
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
        public Cor Cor { get; set; }
        [Required]
        public Tamanho Tamanho { get; set; }
        [Required]
        public double Preco { get; set; }
        [Required]
        public bool ProntaEntrega { get; set; }
        [Required]
        public int TempoConfeccao { get; set; }
    }

    public enum Cor
    {
        Verde,
        Azul,
        Rosa,
        Amarelo
    }

    public enum Tamanho 
    { 
        Pequeno,
        Medio,
        Grande
    
    }

}