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
    public class MinistroService : IMinistroService
    {
        private readonly IMinistroRepository _ministroRespository;

        public MinistroService(IMinistroRepository ministroRespository)
        {
            _ministroRespository = ministroRespository;
        }

        public async Task<bool> Alterar(Ministro ministro, int id)
        {
            try
            {
                var response = await _ministroRespository.ObterPorId(id);

                if (string.IsNullOrEmpty(response.ToString()))
                {
                    return false;
                }

                var path = string.IsNullOrEmpty(ministro.Foto) ? response.Foto : ministro.Foto;

                response.AlterarDados(ministro.Nome, ministro.Endereco, ministro.Telefone, ministro.SiglaPartido, ministro.NomePartido, ministro.ProjetoLei, path);

                await _ministroRespository.Alterar(response);

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
                var deput = await _ministroRespository.ObterPorId(id);
                if (deput == null)
                {
                    return false;
                }
                await _ministroRespository.Excluir(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Ministro> Inserir(Ministro ministro)
        {
            try
            {
                if (!Cpf.ValidacaoCPF(ministro.Cpf))
                {
                    return null;
                }
                var deput = await _ministroRespository.Consultar(x => x.Cpf == ministro.Cpf);

                if (deput.Count() > 0)
                {
                    return null;
                }
                await _ministroRespository.Inserir(ministro);

                return ministro;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<Ministro> ObterPorId(int id)
        {
            return await _ministroRespository.ObterPorId(id);
        }

        public async Task<IEnumerable<Ministro>> ObterTodos()
        {
            return await _ministroRespository.ObterTodos(); ;
        }

        public async Task<IEnumerable<Ministro>> Consultar(Expression<Func<Ministro, bool>> predicate)
        {
            return await _ministroRespository.Consultar(predicate);
        }

        public void Dispose()
        {
            _ministroRespository?.Dispose();
        }
    }
}