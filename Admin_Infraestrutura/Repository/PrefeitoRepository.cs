using Admin_Dominio.Interfaces.IRepositories;
using Admin_Infraestrutura.Context;
using Projeto_desafio_API_Admin.Entities;

namespace Admin_Infraestrutura.Repository
{
    public class PrefeitoRepository : BaseRepository<Prefeito>, IPrefeitoRepository
    {
        private readonly ApplicationDbContext _context;

        public PrefeitoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}