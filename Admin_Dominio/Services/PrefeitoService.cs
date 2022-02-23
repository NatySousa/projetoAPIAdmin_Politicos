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
    public class PrefeitoService : IPrefeitoService
    {
        private readonly IPrefeitoRepository _prefeitoRespository;

        public PrefeitoService(IPrefeitoRepository prefeitoRespository)
        {
            _prefeitoRespository = prefeitoRespository;
        }

        public async Task<bool> Alterar(Prefeito prefeito, int id)
        {
            try
            {
                var response = await _prefeitoRespository.ObterPorId(id);

                if (string.IsNullOrEmpty(response.ToString()))
                {
                    return false;
                }

                var path = string.IsNullOrEmpty(prefeito.Foto) ? response.Foto : prefeito.Foto;

                response.AlterarDados(prefeito.Nome, prefeito.Endereco, prefeito.Telefone, prefeito.SiglaPartido, prefeito.NomePartido, prefeito.ProjetoLei, path);

                await _prefeitoRespository.Alterar(response);

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
                var deput = await _prefeitoRespository.ObterPorId(id);
                if (deput == null)
                {
                    return false;
                }
                await _prefeitoRespository.Excluir(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Prefeito> Inserir(Prefeito prefeito)
        {
            try
            {
                if (!Cpf.ValidacaoCPF(prefeito.Cpf))
                {
                    return null;
                }
                var deput = await _prefeitoRespository.Consultar(x => x.Cpf == prefeito.Cpf);

                if (deput.Count() > 0)
                {
                    return null;
                }
                await _prefeitoRespository.Inserir(prefeito);

                return prefeito;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<Prefeito> ObterPorId(int id)
        {
            return await _prefeitoRespository.ObterPorId(id);
        }

        public async Task<IEnumerable<Prefeito>> ObterTodos()
        {
            return await _prefeitoRespository.ObterTodos(); ;
        }

        public async Task<IEnumerable<Prefeito>> Consultar(Expression<Func<Prefeito, bool>> predicate)
        {
            return await _prefeitoRespository.Consultar(predicate);
        }

        public void Dispose()
        {
            _prefeitoRespository?.Dispose();
        }
    }
}