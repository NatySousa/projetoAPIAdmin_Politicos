using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Admin_Dominio.Interfaces.IRepositories;
using Admin_Dominio.Interfaces.IServices;
using Admin_Dominio.Util;
using Projeto_desafio_API_Admin.Entities;

namespace Admin_Dominio.Services
{
    public class GovernadorService : IGovernadorService
    {
        private readonly IGovernadorRepository _governadorRespository;

        public GovernadorService(IGovernadorRepository governadorRespository)
        {
            _governadorRespository = governadorRespository;
        }

        public async Task<bool> Alterar(Governador governador, int id)
        {
            try
            {
                var response = await _governadorRespository.ObterPorId(id);

                if (string.IsNullOrEmpty(response.ToString()))
                {
                    return false;
                }

                var path = string.IsNullOrEmpty(governador.Foto) ? response.Foto : governador.Foto;

                response.AlterarDados(governador.Processo, governador.Nome, governador.Endereco, governador.Telefone, governador.SiglaPartido, governador.NomePartido, governador.ProjetoLei, path);

                await _governadorRespository.Alterar(response);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> Excluir(int id)
        {
            try
            {
                var deput = await _governadorRespository.ObterPorId(id);
                if (deput == null)
                {
                    return false;
                }
                await _governadorRespository.Excluir(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Governador> Inserir(Governador governador)
        {
            try
            {
                if (!Cpf.ValidacaoCPF(governador.Cpf))
                {
                    return null;
                }
                var deput = await _governadorRespository.Consultar(x => x.Cpf == governador.Cpf);

                if (deput.Count() > 0)
                {
                    return null;
                }
                await _governadorRespository.Inserir(governador);

                return governador;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<Governador> ObterPorId(int id)
        {
            return await _governadorRespository.ObterPorId(id);
        }

        public async Task<IEnumerable<Governador>> ObterTodos()
        {
            return await _governadorRespository.ObterTodos(); ;
        }

        public async Task<IEnumerable<Governador>> Consultar(Expression<Func<Governador, bool>> predicate)
        {
            return await _governadorRespository.Consultar(predicate);
        }

        public void Dispose()
        {
            _governadorRespository?.Dispose();
        }
    }
}