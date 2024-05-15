using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBase_MagnificoPonto.Models
{
    [Table("VendaProdutos")]
    public class VendaProdutoModel
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Today;
    }
}
