using Admin_Dominio.Interfaces.IRepositories;
using Admin_Infraestrutura.Context;
using Projeto_desafio_API_Admin.Entities;

namespace Admin_Infraestrutura.Repository
{
    public class PresidenteRepository : BaseRepository<Presidente>, IPresidenteRepository
    {
        private readonly ApplicationDbContext _context;

        public PresidenteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}