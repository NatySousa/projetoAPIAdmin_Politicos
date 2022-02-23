using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Admin_API.ViewModels.Vereador
{
    public class PutVereadorViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Processo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "O campo precisa ter 11 caracteres")]
        public string SiglaPartido { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NomePartido { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string ProjetoLei { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public IFormFile Imagem { get; set; }
        public string Foto { get; set; }
    }
}