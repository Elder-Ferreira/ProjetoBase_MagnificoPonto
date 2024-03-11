using System.ComponentModel.DataAnnotations;

namespace ProjetoBase_MagnificoPonto.Models
{
    [Display (Name = "Usuários")]
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Telefone { get; set; }
    }
}