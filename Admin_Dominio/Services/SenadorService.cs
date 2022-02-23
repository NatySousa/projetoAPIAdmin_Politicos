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
    public class SenadorService : ISenadorService
    {
        private readonly ISenadorRepository _senadorRespository;

        public SenadorService(ISenadorRepository senadorRespository)
        {
            _senadorRespository = senadorRespository;
        }

        public async Task<bool> Alterar(Senador senador, int id)
        {
            try
            {
                var response = await _senadorRespository.ObterPorId(id);

                if (string.IsNullOrEmpty(response.ToString()))
                {
                    return false;
                }

                var path = string.IsNullOrEmpty(senador.Foto) ? response.Foto : senador.Foto;

                response.AlterarDados(senador.Nome, senador.Endereco, senador.Telefone, senador.SiglaPartido, senador.NomePartido, senador.ProjetoLei, path);

                await _senadorRespository.Alterar(response);

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
                var deput = await _senadorRespository.ObterPorId(id);
                if (deput == null)
                {
                    return false;
                }
                await _senadorRespository.Excluir(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Senador> Inserir(Senador senador)
        {
            try
            {
                if (!Cpf.ValidacaoCPF(senador.Cpf))
                {
                    return null;
                }
                var deput = await _senadorRespository.Consultar(x => x.Cpf == senador.Cpf);

                if (deput.Count() > 0)
                {
                    return null;
                }
                await _senadorRespository.Inserir(senador);

                return senador;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<Senador> ObterPorId(int id)
        {
            return await _senadorRespository.ObterPorId(id);
        }

        public async Task<IEnumerable<Senador>> ObterTodos()
        {
            return await _senadorRespository.ObterTodos(); ;
        }

        public async Task<IEnumerable<Senador>> Consultar(Expression<Func<Senador, bool>> predicate)
        {
            return await _senadorRespository.Consultar(predicate);
        }

        public void Dispose()
        {
            _senadorRespository?.Dispose();
        }
    }
}