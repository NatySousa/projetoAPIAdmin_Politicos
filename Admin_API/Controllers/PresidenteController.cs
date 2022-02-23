using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Admin_API.Util;
using Admin_API.ViewModels;
using Admin_API.ViewModels.Presidente;
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
    public class PresidenteController: ControllerBase
    {
        private readonly IPresidenteService _presidenteService;
        private readonly IMapper _mapper;

        public PresidenteController(IPresidenteService presidenteService, IMapper mapper)
        {
            _presidenteService = presidenteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IEnumerable<GetPresidenteViewModel>>(await _presidenteService.ObterTodos()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mapper.Map<GetPresidenteViewModel>(await _presidenteService.ObterPorId(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] PresidenteViewModel presidente)
        {
            presidente.Foto = await new UploadImagem().Image(presidente.Imagem);
            var deput = await _presidenteService.Inserir(_mapper.Map<Presidente>(presidente));
            if (string.IsNullOrEmpty(deput.ToString()))
            {
                return UnprocessableEntity("Não foi possível cadastrar o presidente. Cpf inválidoou já cadastrado");
            }
            return Ok("Cadastrado com sucesso");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromForm] PutPresidenteViewModel presidente)
        {
            var path = await new UploadImagem().Image(presidente.Imagem);
            if (!string.IsNullOrEmpty(path))
            {
                presidente.Foto = path;
            }           
            
            var deput = await _presidenteService.Alterar(_mapper.Map<Presidente>(presidente),id);

            if (!deput)
            {
                return UnprocessableEntity("Não foi possível alterar os dados. Tente novamente mais tarde");
            }
            return Ok("Atualizado com sucesso");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _presidenteService.Excluir(id);
            if (string.IsNullOrEmpty(result.ToString()))
            {
                return UnprocessableEntity("Não foi possível excluir. Tente novamente mais tarde");
            }
            return Ok("Excluído com sucesso");
        }

    }
}