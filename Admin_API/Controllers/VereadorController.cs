using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Admin_API.Util;
using Admin_API.ViewModels;
using Admin_API.ViewModels.Vereador;
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
    public class VereadorController: ControllerBase
    {
        private readonly IVereadorService _vereadorService;
        private readonly IMapper _mapper;

        public VereadorController(IVereadorService vereadorService, IMapper mapper)
        {
            _vereadorService = vereadorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IEnumerable<GetVereadorViewModel>>(await _vereadorService.ObterTodos()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mapper.Map<GetVereadorViewModel>(await _vereadorService.ObterPorId(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] VereadorViewModel vereador)
        {
            vereador.Foto = await new UploadImagem().Image(vereador.Imagem);
            var deput = await _vereadorService.Inserir(_mapper.Map<Vereador>(vereador));
            if (string.IsNullOrEmpty(deput.ToString()))
            {
                return UnprocessableEntity("Não foi possível cadastrar o vereador. Cpf inválidoou já cadastrado");
            }
            return Ok("Cadastrado com sucesso");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromForm] PutVereadorViewModel vereador)
        {
            var path = await new UploadImagem().Image(vereador.Imagem);
            if (!string.IsNullOrEmpty(path))
            {
                vereador.Foto = path;
            }           
            
            var deput = await _vereadorService.Alterar(_mapper.Map<Vereador>(vereador),id);

            if (!deput)
            {
                return UnprocessableEntity("Não foi possível alterar os dados. Tente novamente mais tarde");
            }
            return Ok("Atualizado com sucesso");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _vereadorService.Excluir(id);
            if (string.IsNullOrEmpty(result.ToString()))
            {
                return UnprocessableEntity("Não foi possível excluir. Tente novamente mais tarde");
            }
            return Ok("Excluído com sucesso");
        }

    }
}