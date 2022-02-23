using System;
using System.Threading.Tasks;
using Admin_API.Security;
using Admin_API.Util;
using Admin_API.ViewModels;
using Admin_Dominio.Interfaces.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Admin_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase // gera o token e valida o usuário
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AuthViewModel model,
            [FromServices] TokenService tokenService)
        {
            try
            {
                //consultando o usuario no banco de dados atraves do email e senha
                var usuario = await _usuarioRepository.Obter(model.Nome);
                var senhaCriptografada = new Criptografia().CriarHash(model.Senha);//criptografando a senha recebida para compara com a do banco
                

                if(senhaCriptografada != usuario.Senha)
                {
                    return StatusCode(401, "Acesso negado, usuário ou senha inválido.");
                }

                //verificar se existe no banco de dados o usuario
                //com o email e senha informado..
                if (usuario != null)
                {
                    //autenticar o usuario!
                    return Ok(
                        new
                        {
                            Mensagem = "Usuário autenticado com sucesso",
                            AccessToken = tokenService.GerarToken(usuario.Nome),
                            usuario //dados do usuário
                        }
                        );
                }
                else
                {
                    return StatusCode(401, "Acesso negado, usuário inválido.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

    }
    
}