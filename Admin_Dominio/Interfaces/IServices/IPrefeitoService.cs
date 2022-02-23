using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Projeto_desafio_API_Admin.Entities;

namespace Admin_Dominio.Interfaces.IServices
{
    public interface IPrefeitoService
    {
        Task<IEnumerable<Prefeito>> ObterTodos(); //<IEnumerable<Entidade>> Vai me retornar uma lista do objeto
        Task<Prefeito> ObterPorId(int id);
        Task<IEnumerable<Prefeito>> Consultar(Expression<Func<Prefeito, bool>> predicate);
        Task<Prefeito> Inserir(Prefeito prefeito);
        Task<bool> Alterar(Prefeito prefeito, int id);        
        Task<bool> Excluir(int id);
    }
}