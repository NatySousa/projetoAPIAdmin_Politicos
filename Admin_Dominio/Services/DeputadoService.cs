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
    public class DeputadoService : IDeputadoService
    {
        private readonly IDeputadoRepository _deputadoRepository;

        public DeputadoService(IDeputadoRepository deputadoRepository)
        {
            _deputadoRepository = deputadoRepository;
        }

        public async Task<bool> Alterar(Deputado deputado, int id)
        {
            try
            {
                var response = await _deputadoRepository.ObterPorId(id);

                if (string.IsNullOrEmpty(response.ToString()))
                {
                    return false;
                }

                var path = string.IsNullOrEmpty(deputado.Foto) ? response.Foto : deputado.Foto;

                response.AlterarDados(deputado.Processo, deputado.Representante, deputado.Nome, deputado.Endereco, deputado.Telefone, deputado.SiglaPartido, deputado.NomePartido, deputado.ProjetoLei, path);

                await _deputadoRepository.Alterar(response);

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
                var deput = await _deputadoRepository.ObterPorId(id);
                if (deput == null)
                {
                    return false;
                }
                await _deputadoRepository.Excluir(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Deputado> Inserir(Deputado deputado)
        {
            try
            {
                if (!Cpf.ValidacaoCPF(deputado.Cpf))
                {
                    return null;
                }
                var deput = await _deputadoRepository.Consultar(x => x.Cpf == deputado.Cpf);

                if (deput.Count() > 0)
                {
                    return null;
                }
                await _deputadoRepository.Inserir(deputado);

                return deputado;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<Deputado> ObterPorId(int id)
        {
            return await _deputadoRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Deputado>> ObterTodos()
        {
            return await _deputadoRepository.ObterTodos();;
        }

        public async Task<IEnumerable<Deputado>> Consultar(Expression<Func<Deputado, bool>> predicate)
        {
            return await _deputadoRepository.Consultar(predicate);
        } 

        public void Dispose()
        {
            _deputadoRepository?.Dispose();
        }
    }
}