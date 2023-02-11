using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjetoExoApi.Interfaces;
using ProjetoExoApi.Models;
using ProjetoExoApi.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProjetoExoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;
        public LoginController(IUsuarioRepository iUsuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository;
        }

        [HttpPost]

        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _iUsuarioRepository.Login(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return Unauthorized(new {msg = "Email ou senha invalido"});
                }

                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.Tipo)
                };

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ProjetoExoApi-chave-autenticacao"));

                var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                    issuer: "ProjetoExoApi",
                    audience: "ProjetoExoApi",
                    claims: minhasClaims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: credenciais
                    );
                return Ok(
                    new {token = new JwtSecurityTokenHandler().WriteToken(meuToken)}
                    );
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

    }
}
