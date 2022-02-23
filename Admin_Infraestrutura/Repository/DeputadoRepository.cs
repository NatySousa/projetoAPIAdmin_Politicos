using System.Threading.Tasks;
using Admin_Dominio.Interfaces.IRepositories;
using Admin_Infraestrutura.Context;
using Projeto_desafio_API_Admin.Entities;

namespace Admin_Infraestrutura.Repository
{
    public class DeputadoRepository : BaseRepository<Deputado>, IDeputadoRepository
    {
        private readonly ApplicationDbContext _context;

        public DeputadoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}