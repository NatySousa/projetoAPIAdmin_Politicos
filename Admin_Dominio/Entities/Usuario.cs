using System;

namespace Admin_Dominio.Entities
{
    public class Usuario
    {
         public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}