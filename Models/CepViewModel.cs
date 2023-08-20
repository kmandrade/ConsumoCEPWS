using System.ComponentModel.DataAnnotations;

namespace ConsumoCEPWS.Models
{
    public class CepViewModel
    {
        public string? Rua { get; set; }
        public int NumeroCasa { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório.")]
        [MaxLength(9)]
        public string? CEP { get; set; }
        public string? Complemento { get; set; }
        public string? Cidade { get; set; }

    }
}
