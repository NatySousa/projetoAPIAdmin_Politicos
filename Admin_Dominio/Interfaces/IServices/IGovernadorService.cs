using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Projeto_desafio_API_Admin.Entities;

namespace Admin_Dominio.Interfaces.IServices
{
    public interface IGovernadorService
    {
        Task<IEnumerable<Governador>> ObterTodos(); //<IEnumerable<Entidade>> Vai me retornar uma lista do objeto
        Task<Governador> ObterPorId(int id);
        Task<IEnumerable<Governador>> Consultar(Expression<Func<Governador, bool>> predicate);
        Task<Governador> Inserir(Governador governador);
        Task<bool> Alterar(Governador governador, int id);        
        Task<bool> Excluir(int id);
    }
}