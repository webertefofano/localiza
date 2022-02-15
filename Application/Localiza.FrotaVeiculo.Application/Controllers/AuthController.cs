using Localiza.FrotaVeiculo.Application.Models.Auth;
using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Localiza.FrotaVeiculo.Domain.Interfaces;
using Localiza.FrotaVeiculo.Infra.CrossCutting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Application.Auth.Controllers
{
    [ApiController]
    [Route("api/v1/Token")]
    public class AuthController : ControllerBase
    {
        private IBaseService<Usuario> _baseUserService;
        private IAuthService _authService;

        public AuthController(IBaseService<Usuario> baseUserService, IAuthService authService)
        {
            _baseUserService = baseUserService;
            _authService = authService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(LoginResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Token(LoginModel model)
        {
            int idUsuario = 0;
            DateTime inicio = DateTime.Now;

            if (ModelState.IsValid)
            {
                Usuario user = _authService.Login(model.Login, model.Password);
                if (user != null)
                {
                    idUsuario = user.IdUsuario;

                    List<Permissao> listaRole = _authService.GetUsuarioPermissao(user.IdUsuario);

                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, user.Login.ToString()));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.IdUsuario.ToString()));

                    foreach (var item in listaRole)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item.Nome));
                    }

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Util.GetJwtKey()));

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Issuer = Util.GetJwtIssuer(),
                        Audience = Util.GetJwtAudience(),
                        Expires = DateTime.UtcNow.AddHours(Util.GetJwtExpireHour()),
                        SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    LoginResponseModel ret = new LoginResponseModel();
                    ret.Login = model.Login;
                    ret.Token = tokenString;
                    ret.idUsuario = user.IdUsuario;
                    ret.Expiracao = DateTime.UtcNow.AddHours(Util.GetJwtExpireHour());
                    
                    
                    //_erroService.AddLog(inicio, idUsuario, (user == null || user.IdEmpresaAtual == null) ? 0 : (int)user.IdEmpresaAtual, null, model.Cliente, JsonConvert.SerializeObject(model), JsonConvert.SerializeObject(ret), "Login efetuado com sucesso.", string.Empty, false, "api/v1/Token");

                    return Ok(ret);
                }

                //_erroService.AddLog(inicio, idUsuario, (user == null || user.IdEmpresaAtual == null) ? 0 : (int)user.IdEmpresaAtual, null, model.Cliente, model.Login, "Usuário ou senha inválido.", string.Empty, string.Empty, false, "api/v1/Token");
                return Unauthorized("LOGIN USUÁRIO E/OU SENHA INVÁLIDO"); //401
            }

            //_erroService.AddLog(inicio, idUsuario, 0, null, model.Cliente, JsonConvert.SerializeObject(model), null, "Erro na Requisição", null, false, "api/v1/Token");
            return BadRequest(); //400           
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}