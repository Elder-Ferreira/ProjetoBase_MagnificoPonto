using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProjetoBase_MagnificoPonto.Models
{
    public class ImagemModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CaminhoImagem { get; set; }
        [DataType(DataType.Currency)]
        [Precision(16, 2)]
        public decimal Preco { get; set; }
    }
}
