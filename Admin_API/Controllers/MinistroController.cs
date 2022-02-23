using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Admin_API.Util;
using Admin_API.ViewModels;
using Admin_API.ViewModels.Ministro;
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
    public class MinistroController: ControllerBase
    {
        private readonly IMinistroService _ministroService;
        private readonly IMapper _mapper;

        public MinistroController(IMinistroService ministroService, IMapper mapper)
        {
            _ministroService = ministroService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IEnumerable<GetMinistroViewModel>>(await _ministroService.ObterTodos()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mapper.Map<GetMinistroViewModel>(await _ministroService.ObterPorId(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] MinistroViewModel ministro)
        {
            ministro.Foto = await new UploadImagem().Image(ministro.Imagem);
            var deput = await _ministroService.Inserir(_mapper.Map<Ministro>(ministro));
            if (string.IsNullOrEmpty(deput.ToString()))
            {
                return UnprocessableEntity("Não foi possível cadastrar o ministro. Cpf inválidoou já cadastrado");
            }
            return Ok("Cadastrado com sucesso");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromForm] PutMinistroViewModel ministro)
        {
            var path = await new UploadImagem().Image(ministro.Imagem);
            if (!string.IsNullOrEmpty(path))
            {
                ministro.Foto = path;
            }           
            
            var deput = await _ministroService.Alterar(_mapper.Map<Ministro>(ministro),id);

            if (!deput)
            {
                return UnprocessableEntity("Não foi possível alterar os dados. Tente novamente mais tarde");
            }
            return Ok("Atualizado com sucesso");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ministroService.Excluir(id);
            if (string.IsNullOrEmpty(result.ToString()))
            {
                return UnprocessableEntity("Não foi possível excluir. Tente novamente mais tarde");
            }
            return Ok("Excluído com sucesso");
        }

    }
}