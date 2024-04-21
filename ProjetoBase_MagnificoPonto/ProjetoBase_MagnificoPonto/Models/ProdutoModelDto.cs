using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProjetoBase_MagnificoPonto.Models
{
    public class ProdutoModelDto
    {
        [Required, MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        public string Referencia { get; set; }

        [Required]
        public string Cor { get; set; }

        [Required]
        public string Tamanho { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public string Categoria { get; set; }

        [Required, MaxLength(5000)]
        public string Descrição { get; set; }

        [Required]
        public int TempoConfeccao { get; set; }    
        
        public bool ProntaEntrega { get; set; }

        public DateTime CreatedAt { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
