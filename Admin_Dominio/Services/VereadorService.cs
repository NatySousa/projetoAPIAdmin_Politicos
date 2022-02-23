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
    public class VereadorService : IVereadorService
    {
        private readonly IVereadorRepository _vereadorRespository;

        public VereadorService(IVereadorRepository vereadorRespository)
        {
            _vereadorRespository = vereadorRespository;
        }

        public async Task<bool> Alterar(Vereador vereador, int id)
        {
            try
            {
                var response = await _vereadorRespository.ObterPorId(id);

                if (string.IsNullOrEmpty(response.ToString()))
                {
                    return false;
                }

                var path = string.IsNullOrEmpty(vereador.Foto) ? response.Foto : vereador.Foto;

                response.AlterarDados(vereador.Processo, vereador.Nome, vereador.Endereco, vereador.Telefone, vereador.SiglaPartido, vereador.NomePartido, vereador.ProjetoLei, path);

                await _vereadorRespository.Alterar(response);

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
                var deput = await _vereadorRespository.ObterPorId(id);
                if (deput == null)
                {
                    return false;
                }
                await _vereadorRespository.Excluir(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Vereador> Inserir(Vereador vereador)
        {
            try
            {
                if (!Cpf.ValidacaoCPF(vereador.Cpf))
                {
                    return null;
                }
                var deput = await _vereadorRespository.Consultar(x => x.Cpf == vereador.Cpf);

                if (deput.Count() > 0)
                {
                    return null;
                }
                await _vereadorRespository.Inserir(vereador);

                return vereador;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<Vereador> ObterPorId(int id)
        {
            return await _vereadorRespository.ObterPorId(id);
        }

        public async Task<IEnumerable<Vereador>> ObterTodos()
        {
            return await _vereadorRespository.ObterTodos();;
        }

        public async Task<IEnumerable<Vereador>> Consultar(Expression<Func<Vereador, bool>> predicate)
        {
            return await _vereadorRespository.Consultar(predicate);
        } 

        public void Dispose()
        {
            _vereadorRespository?.Dispose();
        }
    }
}