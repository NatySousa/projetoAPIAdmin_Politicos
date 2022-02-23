using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Admin_API.Security
{
    public class TokenService
    {
         private readonly AppSettings _appSettings;

        //método construtor (inicialização)
        public TokenService(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        //Método que irá gerar o TOKEN dos usuario
        public string GerarToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, email) }),
                Expires = DateTime.Now.AddDays(1), //Token válido por 1 dia
                SigningCredentials = new SigningCredentials (new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var accessToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(accessToken);
        }
    }
}