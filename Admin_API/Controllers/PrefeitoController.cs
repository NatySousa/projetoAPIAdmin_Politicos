using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Admin_API.Util;
using Admin_API.ViewModels;
using Admin_API.ViewModels.Prefeito;
using Admin_Dominio.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_desafio_API_Admin.Entities;

namespace Admin_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PrefeitoController: ControllerBase
    {
        private readonly IPrefeitoService _prefeitoService;
        private readonly IMapper _mapper;

        public PrefeitoController(IPrefeitoService prefeitoService, IMapper mapper)
        {
            _prefeitoService = prefeitoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IEnumerable<GetPrefeitoViewModel>>(await _prefeitoService.ObterTodos()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mapper.Map<GetPrefeitoViewModel>(await _prefeitoService.ObterPorId(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] PrefeitoViewModel prefeito)
        {
            if (prefeito is null)
            {
                throw new ArgumentNullException(nameof(prefeito));
            }

            prefeito.Foto = await new UploadImagem().Image(prefeito.Imagem);
            var deput = await _prefeitoService.Inserir(_mapper.Map<Prefeito>(prefeito));
            if (string.IsNullOrEmpty(deput.ToString()))
            {
                return UnprocessableEntity("Não foi possível cadastrar o prefeito. Cpf inválidoou já cadastrado");
            }
            return Ok("Cadastrado com sucesso");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromForm] PutPrefeitoViewModel prefeito)
        {
            var path = await new UploadImagem().Image(prefeito.Imagem);
            if (!string.IsNullOrEmpty(path))
            {
                prefeito.Foto = path;
            }           
            
            var deput = await _prefeitoService.Alterar(_mapper.Map<Prefeito>(prefeito),id);

            if (!deput)
            {
                return UnprocessableEntity("Não foi possível alterar os dados. Tente novamente mais tarde");
            }
            return Ok("Atualizado com sucesso");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _prefeitoService.Excluir(id);
            if (string.IsNullOrEmpty(result.ToString()))
            {
                return UnprocessableEntity("Não foi possível excluir. Tente novamente mais tarde");
            }
            return Ok("Excluído com sucesso");
        }

    }
}