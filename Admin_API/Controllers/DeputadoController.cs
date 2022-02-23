using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Admin_API.Util;
using Admin_API.ViewModels;
using Admin_API.ViewModels.Deputado;
using Admin_Dominio.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_desafio_API_Admin.Entities;

namespace Admin_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DeputadoController : ControllerBase
    {
        private readonly IDeputadoService _deputadoService;
        private readonly IMapper _mapper;

        public DeputadoController(IDeputadoService deputadoService, IMapper mapper)
        {
            _deputadoService = deputadoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IEnumerable<GetDeputadoViewModel>>(await _deputadoService.ObterTodos()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mapper.Map<GetDeputadoViewModel>(await _deputadoService.ObterPorId(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] DeputadoViewModel deputado)
        {
            deputado.Foto = await new UploadImagem().Image(deputado.Imagem);
            var deput = await _deputadoService.Inserir(_mapper.Map<Deputado>(deputado));
            if (string.IsNullOrEmpty(deput.ToString()))
            {
                return UnprocessableEntity("Não foi possível cadastrar o deputado. Cpf inválidoou já cadastrado");
            }
            return Ok("Cadastrado com sucesso");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromForm] PutDeputadoViewModel deputado)
        {            
            var path = await new UploadImagem().Image(deputado.Imagem);
            if (!string.IsNullOrEmpty(path))
            {
                deputado.Foto = path;
            }           
            
            var deput = await _deputadoService.Alterar(_mapper.Map<Deputado>(deputado),id);

            if (!deput)
            {
                return UnprocessableEntity("Não foi possível alterar os dados. Tente novamente mais tarde");
            }
            return Ok("Atualizado com sucesso");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _deputadoService.Excluir(id);
            if (string.IsNullOrEmpty(result.ToString()))
            {
                return UnprocessableEntity("Não foi possível excluir. Tente novamente mais tarde");
            }
            return Ok("Excluído com sucesso");
        }

    }
}