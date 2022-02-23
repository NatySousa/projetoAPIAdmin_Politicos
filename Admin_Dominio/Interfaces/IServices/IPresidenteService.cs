using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Projeto_desafio_API_Admin.Entities;

namespace Admin_Dominio.Interfaces.IServices
{
    public interface IPresidenteService
    {
        Task<IEnumerable<Presidente>> ObterTodos(); //<IEnumerable<Entidade>> Vai me retornar uma lista do objeto
        Task<Presidente> ObterPorId(int id);
        Task<IEnumerable<Presidente>> Consultar(Expression<Func<Presidente, bool>> predicate);
        Task<Presidente> Inserir(Presidente presidente);
        Task<bool> Alterar(Presidente presidente, int id);        
        Task<bool> Excluir(int id);
    }
}