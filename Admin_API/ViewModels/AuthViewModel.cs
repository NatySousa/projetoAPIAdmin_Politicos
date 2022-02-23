using System.ComponentModel.DataAnnotations;

namespace Admin_API.ViewModels
{
    public class AuthViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome.")]
        public string Nome { get; set; }

        [MinLength(4, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha.")]
        public string Senha { get; set; }
    }
}