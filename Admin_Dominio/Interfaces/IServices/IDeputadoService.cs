using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Projeto_desafio_API_Admin.Entities;

namespace Admin_Dominio.Interfaces.IServices
{
    public interface IDeputadoService 
    {
        Task<IEnumerable<Deputado>> ObterTodos(); //<IEnumerable<Entidade>> Vai me retornar uma lista do objeto
        Task<Deputado> ObterPorId(int id);
        Task<IEnumerable<Deputado>> Consultar(Expression<Func<Deputado, bool>> predicate);
        Task<Deputado> Inserir(Deputado deputado);
        Task<bool> Alterar(Deputado deputado, int id);        
        Task<bool> Excluir(int id);
    }
}