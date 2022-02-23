using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Projeto_desafio_API_Admin.Entities;

namespace Admin_Dominio.Interfaces.IServices
{
    public interface IMinistroService
    {
        Task<IEnumerable<Ministro>> ObterTodos(); //<IEnumerable<Entidade>> Vai me retornar uma lista do objeto
        Task<Ministro> ObterPorId(int id);
        Task<IEnumerable<Ministro>> Consultar(Expression<Func<Ministro, bool>> predicate);
        Task<Ministro> Inserir(Ministro ministro);
        Task<bool> Alterar(Ministro ministro, int id);        
        Task<bool> Excluir(int id);
    }
}