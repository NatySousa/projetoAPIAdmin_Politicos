using Admin_Dominio.Interfaces.IRepositories;
using Admin_Infraestrutura.Context;
using Projeto_desafio_API_Admin.Entities;

namespace Admin_Infraestrutura.Repository
{
    public class MinistroRepository : BaseRepository<Ministro>, IMinistroRepository
    {
        private readonly ApplicationDbContext _context;

        public MinistroRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}