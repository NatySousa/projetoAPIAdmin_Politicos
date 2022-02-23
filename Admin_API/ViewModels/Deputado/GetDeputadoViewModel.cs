using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin_API.ViewModels.Deputado
{
    public class GetDeputadoViewModel //classe sem a IFormFile Imagem
    {
        [Key]
        public int Id { get; set; }
        public bool Processo { get; set; }
        public string Representante { get; set; }
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
