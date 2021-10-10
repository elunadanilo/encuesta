using Encuesta.Data;
using Encuesta.Data.Models;
using Encuesta.Helpers;
using Encuesta.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IConfiguration _configuration;
        public LoginService(ILoginRepository loginRepository, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
        }

        public async Task<string> GenerarTokenService(TblUsuario usuario = null, string oldtoken = null)
        {
            return await GenerarTokenServicio(usuario, oldtoken);
        }

        public async Task<TblUsuario> ValidarCredencialesService(UserLogin usuario)
        {
            return await _loginRepository.ValidarCredencialesRepository(usuario);
        }

        public async Task<string> GenerarTokenServicio(TblUsuario usuario = null, string oldToken = "")
        {
                if (!string.IsNullOrEmpty(oldToken))
                {
                    oldToken = oldToken.Split(' ')[1];
                    if (VerificaToken(oldToken))
                    {
                        var oldClaims = new JwtSecurityTokenHandler().ReadJwtToken(oldToken);

                        usuario = new TblUsuario()
                        {
                            IdUsuario = int.Parse(oldClaims.Payload["IdUsuario"].ToString()),
                            Usuario = oldClaims.Payload["Usuario"].ToString(),
                            Nombre = oldClaims.Payload["Nombre"].ToString(),
                            Administrador = bool.Parse(oldClaims.Payload["Administrador"].ToString())
                        };
                    }
                    else
                        return "";
                }
                var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));

                var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);

                var header = new JwtHeader(signingCredentials);

                //claims
                var claims = new[]
                {
                    new Claim("IdUsuario",usuario.IdUsuario.ToString()),
                    new Claim("Usuario",usuario.Usuario),
                    new Claim("Nombre",usuario.Nombre),
                    new Claim("Rol",usuario.Administrador.ToString())
                };

                //payload
                var payload = new JwtPayload(
                     _configuration["Authentication:Issuer"],
                     _configuration["Authentication:Audience"],
                     claims,
                     DateTime.UtcNow,
                    // DateTime.UtcNow.AddMinutes(5)
                    DateTime.UtcNow.AddHours(3)
                );
                var token = new JwtSecurityToken(header, payload);

                return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool VerificaToken(string token)
        {
                if (token.Contains("Bearer"))
                    token = token.Split(' ')[1];

                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = GetValidationParameters();

                IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                return true;
        }

        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidIssuer = _configuration["Authentication:Issuer"],
                ValidAudience = _configuration["Authentication:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]))
            };
        }
    }
}
