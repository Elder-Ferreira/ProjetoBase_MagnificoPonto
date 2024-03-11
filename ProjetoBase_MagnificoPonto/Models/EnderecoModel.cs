using System.ComponentModel.DataAnnotations;

namespace ProjetoBase_MagnificoPonto.Models
{
    public class EnderecoModel
    {
        [Display(Name = "Dados para entrega")]
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
            public string Telefone { get; set; }
            [Required]
            public string CPF { get; set; }
            [Required]
            public string Rua { get; set; }
            [Required]
            public string Numero { get; set; }
            [Required]
            public string Bairro { get; set; }
            [Required]
            public string Cep { get; set; }
            [Required]
            public string Complemento { get; set; }
            [Required]
            public string Referencia { get; set; }
        }

        public int MyProperty { get; set; }
    }

}

