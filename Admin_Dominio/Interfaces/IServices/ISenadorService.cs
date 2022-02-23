using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Projeto_desafio_API_Admin.Entities;

namespace Admin_Dominio.Interfaces.IServices
{
    public interface ISenadorService
    {
        Task<IEnumerable<Senador>> ObterTodos(); //<IEnumerable<Entidade>> Vai me retornar uma lista do objeto
        Task<Senador> ObterPorId(int id);
        Task<IEnumerable<Senador>> Consultar(Expression<Func<Senador, bool>> predicate);
        Task<Senador> Inserir(Senador senador);
        Task<bool> Alterar(Senador senador, int id);        
        Task<bool> Excluir(int id);
    }
}