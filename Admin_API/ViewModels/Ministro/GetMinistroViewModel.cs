
using System.ComponentModel.DataAnnotations;

namespace Admin_API.ViewModels.Ministro
{
    public class GetMinistroViewModel //classe sem dados sensíveis
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string SiglaPartido { get; set; }
        public string NomePartido { get; set; }
        public string ProjetoLei { get; set; }
        public string Foto { get; set; }
    }
}