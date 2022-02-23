using Admin_Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Projeto_desafio_API_Admin.Entities;

namespace Admin_Infraestrutura.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //criando atributo genérico DbSet<> para cada entidade que eu quero mapear no banco
        public DbSet<Deputado> Deputados { get; set; }
        public DbSet<Governador> Governadores { get; set; }
        public DbSet<Ministro> Ministros { get; set; }
        public DbSet<Prefeito> Prefeitos { get; set; }
        public DbSet<Presidente> Presidentes { get; set; }
        public DbSet<Senador> Senadores { get; set; }
        public DbSet<Vereador> Vereadores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}