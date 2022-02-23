namespace Projeto_desafio_API_Admin.Entities
{
    public class Presidente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string SiglaPartido { get; set; }
        public string NomePartido { get; set; }
        public string ProjetoLei { get; set; }
        public string Foto { get; set; }
        public void AlterarDados(string nome, string endereco, string telefone, string siglaPartido, string nomePartido, string projetoLei, string foto)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            SiglaPartido = siglaPartido;
            NomePartido = nomePartido;
            ProjetoLei = projetoLei;
            Foto = foto;
        }
    }
}