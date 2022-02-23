using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Projeto_desafio_API_Admin.Entities;

namespace Admin_Dominio.Interfaces.IServices
{
    public interface IVereadorService
    {
        Task<IEnumerable<Vereador>> ObterTodos(); //<IEnumerable<Entidade>> Vai me retornar uma lista do objeto
        Task<Vereador> ObterPorId(int id);
        Task<IEnumerable<Vereador>> Consultar(Expression<Func<Vereador, bool>> predicate);
        Task<Vereador> Inserir(Vereador vereador);
        Task<bool> Alterar(Vereador vereador, int id);        
        Task<bool> Excluir(int id);
    }
}