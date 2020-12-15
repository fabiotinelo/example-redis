using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Rede.Redis.Web.Controllers
{

    //https://tableless.com.br/autenticacao-em-apis-aspnet-core-com-jwt-refresh-token/

    [Route("api")]
    [ApiController]
    public class OAuthController : Controller
    {
        private string jwtKey = "1234567812345678123456781234567812345678";
        private string jwtIssuer = "Test.com";
        private double expiresMinutes = 123;

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]UserModel userModel)
        {
            IActionResult response = Unauthorized();

            if (userModel.User.Equals("teste") && userModel.Password.Equals("123"))
            {
                var tokenString = GenerateJSONWebToken();
                response = Ok(new { token = tokenString });
            }

            return response;
        }


        [HttpGet]
        [Authorize]
        [Route("obter-dados")]
        public ActionResult<string> Get()
        {
            return $"Dados obtidos com sucesso - {DateTime.Now}";
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(jwtIssuer,
                                              jwtIssuer,
                                              null,
                                              expires: DateTime.Now.AddMinutes(expiresMinutes),
                                              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
