using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Admin_API.Util;
using Admin_API.ViewModels;
using Admin_API.ViewModels.Governador;
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
    public class GovernadorController: ControllerBase
    {
        private readonly IGovernadorService _governadorService;
        private readonly IMapper _mapper;

        public GovernadorController(IGovernadorService governadorService, IMapper mapper)
        {
            _governadorService = governadorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IEnumerable<GetGovernadorViewModel>>(await _governadorService.ObterTodos()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mapper.Map<GetGovernadorViewModel>(await _governadorService.ObterPorId(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] GovernadorViewModel governador)
        {
            governador.Foto = await new UploadImagem().Image(governador.Imagem);
            var deput = await _governadorService.Inserir(_mapper.Map<Governador>(governador));
            if (deput ==null)
            {
                return UnprocessableEntity("Não foi possível cadastrar o deputado. Cpf inválidoou já cadastrado");
            }
            return Ok("Cadastrado com sucesso");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromForm] PutGovernadorViewModel governador)
        { 
            var path = await new UploadImagem().Image(governador.Imagem);
            if (!string.IsNullOrEmpty(path))
            {
                governador.Foto = path;
            }           
            
            var deput = await _governadorService.Alterar(_mapper.Map<Governador>(governador),id);

            if (!deput)
            {
                return UnprocessableEntity("Não foi possível alterar os dados. Tente novamente mais tarde");
            }
            return Ok("Atualizado com sucesso");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _governadorService.Excluir(id);
            if (string.IsNullOrEmpty(result.ToString()))
            {
                return UnprocessableEntity("Não foi possível excluir. Tente novamente mais tarde");
            }
            return Ok("Excluído com sucesso");
        }

        

    }
}
    