using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet4.Models
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório")]
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }

        [Required(ErrorMessage = "O email do cliente é obrigatório")]
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Observacao { get; set; }
    }
}
