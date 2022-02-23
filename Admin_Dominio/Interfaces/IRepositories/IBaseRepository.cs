using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Admin_Dominio.Interfaces.IRepositories
{
    public interface IBaseRepository<T> : IDisposable where T : class // IBaseRepository<T> está recebendo uma classe genérica T, no momento em que ela for herdada será passada a classe real
    {
        Task<IEnumerable<T>> ObterTodos(); //<IEnumerable<T>> Vai me retornar uma lista do objeto
        Task<T> ObterPorId(int id);
        Task<IEnumerable<T>> Consultar(Expression<Func<T, bool>> predicate); //Vai buscar somente pelo parametro fornecido
        Task Inserir(T entities);
        Task Alterar(T entities);
        Task Excluir(int id);
        Task<int> SaveChangesAsync();
    }
}