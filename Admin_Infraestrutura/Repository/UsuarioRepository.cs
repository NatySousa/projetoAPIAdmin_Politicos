using System.Linq;
using System.Threading.Tasks;
using Admin_Dominio.Entities;
using Admin_Dominio.Interfaces.IRepositories;
using Admin_Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;

namespace Admin_Infraestrutura.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
         private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> Obter(string nome)
        {
            var usuario = await _context.Usuarios.ToListAsync();
            return usuario.Where(u => u.Nome == nome).FirstOrDefault();
        }
    }
}