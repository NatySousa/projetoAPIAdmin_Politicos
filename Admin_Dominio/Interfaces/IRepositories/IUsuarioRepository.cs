using System.Threading.Tasks;
using Admin_Dominio.Entities;

namespace Admin_Dominio.Interfaces.IRepositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
         Task<Usuario> Obter(string nome);
    }
}