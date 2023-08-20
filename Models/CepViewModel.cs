using System.ComponentModel.DataAnnotations;

namespace ConsumoCEPWS.Models
{
    public class CepViewModel
    {
        public string? Rua { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório.")]
        [MinLength(9, ErrorMessage = "O campo deve ter pelo menos 9 caracteres.")]
        public string? CEP { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Bairro { get; set; }

    }
}
