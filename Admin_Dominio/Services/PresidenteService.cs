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
    public class PresidenteService : IPresidenteService
    {
        private readonly IPresidenteRepository _presidenteRepository;

        public PresidenteService(IPresidenteRepository presidenteRepository)
        {
            _presidenteRepository = presidenteRepository;
        }
        public async Task<bool> Alterar(Presidente presidente, int id)
        {
            try
            {
                var response = await _presidenteRepository.ObterPorId(id);

                if (string.IsNullOrEmpty(response.ToString()))
                {
                    return false;
                }

                var path = string.IsNullOrEmpty(presidente.Foto) ? response.Foto : presidente.Foto;

                response.AlterarDados(presidente.Nome, presidente.Endereco, presidente.Telefone, presidente.SiglaPartido, presidente.NomePartido, presidente.ProjetoLei, path);

                await _presidenteRepository.Alterar(response);

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
                var deput = await _presidenteRepository.ObterPorId(id);
                if (deput == null)
                {
                    return false;
                }
                await _presidenteRepository.Excluir(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Presidente> Inserir(Presidente presidente)
        {
            try
            {
                if (!Cpf.ValidacaoCPF(presidente.Cpf))
                {
                    return null;
                }
                var deput = await _presidenteRepository.Consultar(x => x.Cpf == presidente.Cpf);

                if (deput.Count() > 0)
                {
                    return null;
                }
                await _presidenteRepository.Inserir(presidente);

                return presidente;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<Presidente> ObterPorId(int id)
        {
            return await _presidenteRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Presidente>> ObterTodos()
        {
            return await _presidenteRepository.ObterTodos(); ;
        }

        public async Task<IEnumerable<Presidente>> Consultar(Expression<Func<Presidente, bool>> predicate)
        {
            return await _presidenteRepository.Consultar(predicate);
        }

        public void Dispose()
        {
            _presidenteRepository?.Dispose();
        }
    }
}